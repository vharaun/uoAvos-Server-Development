using System;
using System.Collections.Generic;

namespace Server.Spells.Ranger
{
	public class HuntersAimSpell : RangerSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(3.0);

		private static readonly Dictionary<Mobile, (Timer, object[])> m_Table = new();

		public HuntersAimSpell(Mobile caster, Item scroll)
			: base(caster, scroll, RangerSpellName.HuntersAim)
		{
		}

		public override void OnCast()
		{
			if (!Caster.CanBeginAction(typeof(HuntersAimSpell)))
			{
				Caster.SendLocalizedMessage(1005559);
			}
			else if (CheckSequence())
			{
				RemoveEffect(Caster);

				_ = Caster.BeginAction(typeof(HuntersAimSpell));

				var span = 1.0 * GetScalar(Caster);
				var timer = new InternalTimer(Caster, TimeSpan.FromMinutes(span));

				var mods = new object[]
				{
					new StatMod(StatType.Dex, "[Ranger] Dex Offset", 5, TimeSpan.Zero),
					new StatMod(StatType.Str, "[Ranger] Str Offset", 5, TimeSpan.Zero),

					new DefaultSkillMod(SkillName.Archery, true, 20),
					new DefaultSkillMod(SkillName.Tactics, true, 20),
				};

				m_Table[Caster] = (timer, mods);

				foreach (var mod in mods)
				{
					if (mod is StatMod statMod)
					{
						Caster.AddStatMod(statMod);
					}
					else if (mod is SkillMod skillMod)
					{
						Caster.AddSkillMod(skillMod);
					}
				}

				timer.Start();
			}

			FinishSequence();
		}

		public static double GetScalar(Mobile m)
		{
			var val = 1.0;

			if (m.CanBeginAction(typeof(HuntersAimSpell)))
			{
				val = 1.5;
			}

			return val;
		}

		public static bool HasEffect(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void RemoveEffect(Mobile m)
		{
			(Timer Timer, object[] Mods) state;

			if (m_Table.TryGetValue(m, out state))
			{
				_ = m_Table.Remove(m);

				state.Timer?.Stop();

				if (state.Mods?.Length > 0)
				{
					foreach (var mod in state.Mods)
					{
						if (mod is StatMod statMod)
						{
							_ = m.RemoveStatMod(statMod.Name);
						}
						else if (mod is SkillMod skillMod)
						{
							m.RemoveSkillMod(skillMod);
						}
					}
				}

			}

			m.EndAction(typeof(HuntersAimSpell));
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Owner;

			public InternalTimer(Mobile owner, TimeSpan duration)
				: base(duration)
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				RemoveEffect(m_Owner);
			}
		}
	}
}
