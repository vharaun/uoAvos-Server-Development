using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Cleric
{
	public class SacredBoonSpell : ClericSpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public SacredBoonSpell(Mobile caster, Item scroll)
			: base(caster, scroll, ClericSpellName.SacredBoon)
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
			else if (CheckBSequence(m, false))
			{
				RemoveEffect(m);

				var t = new InternalTimer(Caster, m, TimeSpan.FromSeconds(30.0));
				
				m_Table[m] = t;

				t.Start();

				SpellHelper.Turn(Caster, m);

				m.PlaySound(0x202);
				m.FixedParticles(0x376A, 1, 62, 9923, 3, 3, EffectLayer.Waist);
				m.FixedParticles(0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist);

				m.SendMessage("A magic aura surrounds you causing your wounds to heal faster.");
			}

			FinishSequence();
		}

		public static bool HasEffect(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void RemoveEffect(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var timer))
			{
				_ = m_Table.Remove(m);

				timer?.Stop();
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Caster;
			private readonly Mobile m_Target;

			private readonly DateTime m_Expire;

			public InternalTimer(Mobile caster, Mobile target, TimeSpan duration)
				: base(TimeSpan.FromSeconds(4.0), TimeSpan.FromSeconds(4.0))
			{
				m_Caster = caster;
				m_Target = target;

				m_Expire = DateTime.UtcNow.Add(duration);
			}

			private void Expire()
			{
				Stop();

				RemoveEffect(m_Target);
			}

			protected override void OnTick()
			{
				if (!m_Target.Alive)
				{
					Expire();
					return;
				}

				var heal = 1.0 * Utility.RandomMinMax(6, 9);

				heal += m_Caster.Skills[SkillName.Magery].Value / 50.0;
				heal *= DivineFocusSpell.GetScalar(m_Caster);

				m_Target.Heal((int)heal, m_Caster);

				m_Target.PlaySound(0x202);
				m_Target.FixedParticles(0x376A, 1, 62, 9923, 3, 3, EffectLayer.Waist);
				m_Target.FixedParticles(0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist);

				var now = DateTime.UtcNow;

				if (now >= m_Expire)
				{
					Expire();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly SacredBoonSpell m_Owner;

			public InternalTarget(SacredBoonSpell owner)
				: base(12, false, TargetFlags.Beneficial)
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
