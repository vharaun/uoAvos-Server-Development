using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class GraspingRootsSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.5);

		public GraspingRootsSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.GraspingRoots)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				// Algorithm: ((20% of AnimalTamin) + 7) seconds [- 50% if resisted] seems to work??
				var duration = 7.0 + (Caster.Skills[DamageSkill].Value * 0.2);

				// Resist if Str + Dex / 2 is greater than CastSkill eg. AnimalLore seems to work??
				if (Caster.Skills[CastSkill].Value < (m.Str + m.Dex) * 0.5)
				{
					duration *= 0.5;
				}

				// no less than 0 seconds no more than 9 seconds
				if (duration < 0.0)
				{
					duration = 0.0;
				}

				if (duration > 9.0)
				{
					duration = 9.0;
				}

				m.PlaySound(0x2A1);

				m.FixedParticles(0x375A, 2, 10, 5027, 0x3D, 2, EffectLayer.Waist);

				m.Paralyze(TimeSpan.FromSeconds(duration));

				var item = new InternalItem(30.0);

				item.MoveToWorld(m.Location, m.Map);
			}

			FinishSequence();
		}

		private class InternalItem : Item
		{
			private InternalTimer m_Timer;

			public InternalItem(double duration)
				: base(0xC5F)
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
			private readonly GraspingRootsSpell m_Owner;

			public InternalTarget(GraspingRootsSpell owner)
				: base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					m_Owner.Target(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
