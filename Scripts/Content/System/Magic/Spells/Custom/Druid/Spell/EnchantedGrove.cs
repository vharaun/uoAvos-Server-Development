using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class EnchantedGroveSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(7.0);

		private static readonly (sbyte, sbyte, sbyte, ushort, string)[] m_Offsets =
		{
			(00, 00, 00, 2275, "sacred stone"),

			(-3, 00, 00, 3293, null),
			(-3, 00, 00, 3294, null),

			(-2, -2, 00, 3290, null),
			(-2, -2, 00, 3291, null),

			(-2, +2, 00, 3293, null),
			(-2, +2, 00, 3294, null),

			(00, -3, 00, 3293, null),
			(00, -3, 00, 3294, null),

			(00, +3, 00, 3290, null),
			(00, +3, 00, 3291, null),

			(+2, -2, 00, 3290, null),
			(+2, -2, 00, 3291, null),

			(+2, +2, 00, 3293, null),
			(+2, +2, 00, 3294, null),

			(+3, 00, 00, 3290, null),
			(+3, 00, 00, 3291, null),
		};

		public EnchantedGroveSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.EnchantedGrove)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{ }
			else if (CheckSequence())
			{
				if (Scroll != null)
				{
					Scroll.Consume();
				}

				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				Effects.PlaySound(p, Caster.Map, 0x2);

				var duration = Utility.RandomMinMax(15.0, 30.0);

				foreach (var (x, y, z, itemID, name) in m_Offsets)
				{
					var loc = new Point3D(p.X + x, p.Y + y, p.Z + z);

					if (SpellHelper.AdjustField(ref loc, Caster.Map, 22, false))
					{
						var item = new InternalItem(itemID, name, Caster, duration, x == 0 && y == 0);

						item.MoveToWorld(loc, Caster.Map);
					}
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private InternalTimer m_Timer;

			private Mobile m_Owner;

			private readonly bool m_Processor;

			public override bool BlocksFit => true;

			public InternalItem(int itemID, string name, Mobile owner, double duration, bool processor)
				: base(itemID)
			{
				Movable = false;

				Name = name;

				m_Owner = owner;

				m_Processor = processor;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(duration));
				m_Timer.Start();

				_ = Timer.DelayCall(Process);
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			private void Process()
			{
				if (!m_Processor || Deleted || m_Owner?.Deleted != false)
				{
					return;
				}

				var eable = GetMobilesInRange(5);

				foreach (var m in eable)
				{
					if (m.Player && m.Karma >= 0 && m.Alive)
					{
						var friendly = true;

						for (var j = 0; friendly && j < m_Owner.Aggressors.Count; ++j)
						{
							friendly = m_Owner.Aggressors[j].Attacker != m;
						}

						for (var j = 0; friendly && j < m_Owner.Aggressed.Count; ++j)
						{
							friendly = m_Owner.Aggressed[j].Defender != m;
						}

						if (friendly)
						{
							m.FixedEffect(0x37C4, 1, 12, 1109, 3); // At player

							m.Mana += 1 + (m_Owner.Karma / 10000);
							m.Hits += 1 + (m_Owner.Karma / 10000);
						}
					}
				}

				eable.Free();

				_ = Timer.DelayCall(TimeSpan.FromSeconds(1.0), Process);
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				m_Timer?.Stop();
				m_Timer = null;
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(0); // version

				writer.Write(m_Owner);

				if (m_Timer?.Running == true)
				{
					writer.Write(m_Timer.Next - DateTime.UtcNow);
				}
				else
				{
					writer.Write(TimeSpan.Zero);
				}
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				_ = reader.ReadInt();

				m_Owner = reader.ReadMobile();

				var duration = reader.ReadTimeSpan();

				if (duration > TimeSpan.Zero)
				{
					m_Timer = new InternalTimer(this, duration);
				}
				else
				{
					m_Timer = new InternalTimer(this, TimeSpan.Zero);
				}

				m_Timer.Start();
			}

			private class InternalTimer : Timer
			{
				private readonly InternalItem m_Item;

				public InternalTimer(InternalItem item, TimeSpan duration) : base(duration)
				{
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly EnchantedGroveSpell m_Owner;

			public InternalTarget(EnchantedGroveSpell owner) 
				: base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D p)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
