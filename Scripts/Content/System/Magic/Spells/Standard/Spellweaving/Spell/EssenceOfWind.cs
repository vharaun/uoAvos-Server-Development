using System;
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
	public class EssenceOfWindSpell : SpellweavingSpell
	{
		private static readonly Dictionary<Mobile, EffectState> m_Table = new();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(3.0);

		public EssenceOfWindSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, SpellweavingSpellName.EssenceOfWind)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.PlaySound(0x5C6);

				var range = 5 + FocusLevel;
				var damage = 25 + FocusLevel;

				var skill = Caster.Skills.Spellweaving.Value;

				var duration = TimeSpan.FromSeconds((skill / 24.0) + FocusLevel);

				var fcMalus = FocusLevel + 1;
				var ssiMalus = 2 * (FocusLevel + 1);

				foreach (var m in Caster.GetMobilesInRange(range))
				{
					if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && Caster.InLOS(m))
					{
						Caster.DoHarmful(m);

						SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);

						if (!CheckResisted(m)) // No message on resist
						{
							StopDebuffing(m, false);

							m_Table[m] = new EffectState(m, fcMalus, ssiMalus, duration);

							BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.EssenceOfWind, 1075802, duration, m, $"{fcMalus}\t{ssiMalus}"));
						}
					}
				}
			}

			FinishSequence();
		}

		public static int GetFCMalus(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var info))
			{
				return info.FCMalus;
			}

			return 0;
		}

		public static int GetSSIMalus(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var info))
			{
				return info.SSIMalus;
			}

			return 0;
		}

		public static bool IsDebuffed(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void StopDebuffing(Mobile m, bool message)
		{
			if (m_Table.TryGetValue(m, out var info))
			{
				info.Timer.Stop();

				m_Table.Remove(m);

				BuffInfo.RemoveBuff(m, BuffIcon.EssenceOfWind);
			}
		}

		private class EffectState
		{
			public Mobile Defender { get; }
			public int FCMalus { get; }
			public int SSIMalus { get; }
			public Timer Timer { get; }

			public EffectState(Mobile defender, int fcMalus, int ssiMalus, TimeSpan duration)
			{
				Defender = defender;
				FCMalus = fcMalus;
				SSIMalus = ssiMalus;

				Timer = Timer.DelayCall(duration, StopDebuffing, Defender, true);
			}
		}
	}
}