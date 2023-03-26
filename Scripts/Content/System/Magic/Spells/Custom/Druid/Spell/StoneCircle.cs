using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class StoneCircleSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(3.0);

		private static readonly (sbyte x, sbyte y)[] m_Offsets =
		{
			(-3, 00),
			(-2, -2),
			(-2, -1),
			(-2, +1),
			(-2, +2),
			(-1, -2),
			(-1, +2),
			(00, -3),
			(00, +3),
			(+1, -2),
			(+1, +2),
			(+2, -2),
			(+2, -1),
			(+2, +1),
			(+2, +2),
			(+3, 00),
		};

		public StoneCircleSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.StoneCircle)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p) || !Caster.InLOS(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (!SpellHelper.CheckTown(this, p))
			{
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				Effects.PlaySound(p, Caster.Map, 0x222);

				foreach (var (x, y) in m_Offsets)
				{
					var loc = new Point3D(p.X + x, p.Y + y, p.Z);

					if (SpellHelper.AdjustField(ref loc, Caster.Map, 22, true) && Caster.InLOS(loc))
					{
						var item = new InternalItem(30.0);

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

			public override bool BlocksFit => true;

			public InternalItem(double duration)
				: base(Utility.RandomList(2274, 2275, 2272, 2273, 2279, 2280))
			{
				Movable = false;

				Name = "stone";

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(duration));
				m_Timer.Start();
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			public override bool OnMoveOver(Mobile m)
			{
				m.SendMessage("The magic of the stones prevents you from crossing.");

				return false;
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

				public InternalTimer(InternalItem item, TimeSpan duration)
					: base(duration)
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
			private readonly StoneCircleSpell m_Owner;

			public InternalTarget(StoneCircleSpell owner)
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
