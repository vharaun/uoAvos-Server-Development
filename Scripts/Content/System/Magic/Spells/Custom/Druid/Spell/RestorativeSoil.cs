using Server.Gumps;
using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class RestorativeSoilSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public RestorativeSoilSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.RestorativeSoil)
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
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				Effects.PlaySound(p, Caster.Map, 0x382);

				var loc = new Point3D(p);

				if (SpellHelper.AdjustField(ref loc, Caster.Map, 22, false))
				{
					var item = new InternalItem(30.0);

					item.MoveToWorld(loc, Caster.Map);
				}
				else
				{
					var item = new InternalItem(30.0);

					item.MoveToWorld(Caster.Location, Caster.Map);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private InternalTimer m_Timer;

			public override bool BlocksFit => true;

			public override bool HandlesOnMovement => true;

			public InternalItem(double duration)
				: base(0x913)
			{
				Movable = false;

				Name = "restorative soil";

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(duration));
				m_Timer.Start();
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			public override bool OnMoveOver(Mobile m)
			{
				if (m.Player && !m.Alive)
				{
					_ = m.SendGump(new ResurrectGump(m));

					m.SendMessage("The power of the soil surges through you!");
				}
				else
				{
					m.PlaySound(0x339);
				}

				return true;
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
			private readonly RestorativeSoilSpell m_Owner;

			public InternalTarget(RestorativeSoilSpell owner)
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
