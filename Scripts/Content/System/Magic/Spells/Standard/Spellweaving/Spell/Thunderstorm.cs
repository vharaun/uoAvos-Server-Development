using System;
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
	public class ThunderstormSpell : SpellweavingSpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.5);

		public ThunderstormSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.Thunderstorm)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.PlaySound(0x5CE);

				var skill = Caster.Skills[SkillName.Spellweaving].Value;

				var damage = Math.Max(11, 10 + (int)(skill / 24.0)) + FocusLevel;

				var sdiBonus = AosAttributes.GetValue(Caster, AosAttribute.SpellDamage);

				var pvmDamage = Math.Min(15, damage * (100 + sdiBonus) / 100);
				var pvpDamage = damage * (100 + sdiBonus) / 100;

				var range = 2 + FocusLevel;
				var duration = TimeSpan.FromSeconds(5 + FocusLevel);

				var targets = Caster.GetMobilesInRange(range);

				foreach (var m in targets)
				{
					if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && Caster.InLOS(m))
					{
						Caster.DoHarmful(m);

						var oldSpell = m.Spell;

						SpellHelper.Damage(this, m, (m.Player && Caster.Player) ? pvpDamage : pvmDamage, 0, 0, 0, 0, 100);

						if (oldSpell != null && oldSpell != m.Spell && !CheckResisted(m))
						{
							Expire(m);

							m_Table[m] = Timer.DelayCall(duration, Expire, m);

							BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Thunderstorm, 1075800, duration, m, GetCastRecoveryMalus(m)));
						}
					}
				}

				targets.Free();
			}

			FinishSequence();
		}

		public static int GetCastRecoveryMalus(Mobile m)
		{
			if (m_Table.ContainsKey(m))
			{
				return 6;
			}

			return 0;
		}

		public static void Expire(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var t))
			{
				t?.Stop();

				m_Table.Remove(m);

				BuffInfo.RemoveBuff(m, BuffIcon.Thunderstorm);
			}
		}
	}
}