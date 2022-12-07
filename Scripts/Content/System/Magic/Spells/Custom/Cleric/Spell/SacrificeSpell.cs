using Server.Engines.PartySystem;

using System;
using System.Collections.Generic;

namespace Server.Spells.Cleric
{
	public class SacrificeSpell : ClericSpell
	{
		private static readonly Dictionary<Mobile, InternalTimer> m_Table = new();

		public SacrificeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, ClericSpellName.Sacrifice)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				if (HasEffect(Caster))
				{
					RemoveEffect(Caster);

					Caster.PlaySound(0x244);
					Caster.FixedParticles(0x3709, 1, 30, 9965, 1152, 0, EffectLayer.Waist);
					Caster.FixedParticles(0x376A, 1, 30, 9502, 1152, 0, EffectLayer.Waist);

					Caster.SendMessage("You stop sacrificing your essence for the wellbeing of others.");
				}
				else
				{
					Caster.PlaySound(0x244);
					Caster.FixedParticles(0x3709, 1, 30, 9965, 1153, 7, EffectLayer.Waist);
					Caster.FixedParticles(0x376A, 1, 30, 9502, 1153, 3, EffectLayer.Waist);

					Caster.SendMessage("You begin sacrificing your essence for the wellbeing of others.");
					
					var t = new InternalTimer(Caster);

					m_Table[Caster] = t;

					t.Start();
				}
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

			public InternalTimer(Mobile caster)
				: base(TimeSpan.FromSeconds(3.0), TimeSpan.FromSeconds(3.0))
			{
				m_Caster = caster;
			}

			private void Expire()
			{
				Stop();

				RemoveEffect(m_Caster);

				if (m_Caster.Alive)
				{
					m_Caster.SendMessage("You stop sacrificing your essence for the wellbeing of others.");
				}
			}

			protected override void OnTick()
			{
				if (!m_Caster.Alive || m_Caster.Hits <= 1)
				{
					Expire();
					return;
				}

				var p = Party.Get(m_Caster);

				if (p == null)
				{
					Expire();
					return;
				}

				foreach (var info in p.Members)
				{
					if (!m_Caster.Alive || m_Caster.Hits <= 1)
					{
						Expire();
						return;
					}

					var m = info.Mobile;

					if (m == m_Caster || m.Poisoned || m.Hits >= m.HitsMax)
					{
						continue;
					}

					var need = m.HitsMax - m.Hits;

					if (need <= 0)
					{
						continue;
					}

					if (need >= m_Caster.Hits)
					{
						need = m_Caster.Hits - 1;
					}

					m.Heal(need, m_Caster, false);

					m_Caster.Hits -= need;

					m.PlaySound(0x202);
					m.FixedParticles(0x376A, 1, 62, 9923, 3, 3, EffectLayer.Waist);
					m.FixedParticles(0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist);
				}
			}
		}
	}
}
