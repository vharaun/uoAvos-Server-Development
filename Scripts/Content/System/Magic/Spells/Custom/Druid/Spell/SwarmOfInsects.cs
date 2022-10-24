using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Druid
{
	public class SwarmOfInsectsSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public SwarmOfInsectsSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.SwarmOfInsects)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect(7, Caster, ref m);

				_ = CheckResisted(m); // Check magic resist for skill, but do not use return value

				m.FixedParticles(0x91B, 1, 240, 9916, 1159, 3, EffectLayer.Head);

				// m.FixedParticles( 0x91B, 1, 240, 9916, 0, 3, EffectLayer.Head );
				m.PlaySound(0x1E5);

				var damage = ((Caster.Skills[CastSkill].Value - m.Skills[SkillName.AnimalLore].Value) / 10) + 30;

				if (damage < 1)
				{
					damage = 1;
				}

				if (!m_Table.ContainsKey(m))
				{
					var t = new InternalTimer(m, Math.Max(1, (int)(damage * 0.5)));

					m_Table[m] = t;

					t.Start();
				}
				else
				{
					damage /= 10;
				}

				SpellHelper.Damage(this, m, damage);
			}

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Mobile;
			private readonly int m_ToRestore;

			public InternalTimer(Mobile m, int toRestore)
				: base(TimeSpan.FromSeconds(20.0))
			{
				m_Mobile = m;
				m_ToRestore = toRestore;
			}

			protected override void OnTick()
			{
				_ = m_Table.Remove(m_Mobile);

				if (m_Mobile.Alive)
				{
					m_Mobile.Hits += m_ToRestore;
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly SwarmOfInsectsSpell m_Owner;

			public InternalTarget(SwarmOfInsectsSpell owner)
				: base(12, false, TargetFlags.Harmful)
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
