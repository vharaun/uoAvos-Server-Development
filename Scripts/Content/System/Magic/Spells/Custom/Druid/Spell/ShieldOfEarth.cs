using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class ShieldOfEarthSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public ShieldOfEarthSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.ShieldOfEarth)
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
			{
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var dx = Caster.Location.X - p.X;
				var dy = Caster.Location.Y - p.Y;
				var rx = (dx - dy) * 44;
				var ry = (dx + dy) * 44;

				bool eastToWest;

				if (rx >= 0 && ry >= 0)
				{
					eastToWest = false;
				}
				else if (rx >= 0)
				{
					eastToWest = true;
				}
				else if (ry >= 0)
				{
					eastToWest = true;
				}
				else
				{
					eastToWest = false;
				}

				Effects.PlaySound(p, Caster.Map, 0x50);

				for (var i = -2; i <= 2; ++i)
				{
					var loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);

					if (SpellHelper.AdjustField(ref loc, Caster.Map, 22, true) && Caster.InLOS(loc))
					{
						var item = new InternalItem(30.0);

						item.MoveToWorld(loc, Caster.Map);

						Effects.SendLocationParticles(item, 0x376A, 9, 10, 5025);
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
				: base(0x0C92)
			{
				Movable = false;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(duration));
				m_Timer.Start();
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
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
			private readonly ShieldOfEarthSpell m_Owner;

			public InternalTarget(ShieldOfEarthSpell owner)
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
