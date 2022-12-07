using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class BlendWithForestSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public BlendWithForestSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.BlendWithForest)
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

				m.PlaySound(0x19);
				m.FixedParticles(0x375A, 2, 10, 5027, 0x3D, 2, EffectLayer.Waist);

				m.Paralyze(TimeSpan.FromSeconds(20.0));

				m.Hidden = true;

				var loc = new Point3D(m);

				if (SpellHelper.AdjustField(ref loc, m.Map, 22, false))
				{
					var item = new InternalItem(m, 20.0);

					item.MoveToWorld(loc, m.Map);
				}
			}

			FinishSequence();
		}

		private class InternalItem : Item
		{
			private InternalTimer m_Timer;

			private Mobile m_Owner;

			public InternalItem(Mobile owner, double duration)
				: base(0xC9E)
			{
				Movable = false;

				m_Owner = owner;

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

				m_Owner?.RevealingAction();
				m_Owner = null;
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
			private readonly BlendWithForestSpell m_Owner;

			public InternalTarget(BlendWithForestSpell owner) 
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
