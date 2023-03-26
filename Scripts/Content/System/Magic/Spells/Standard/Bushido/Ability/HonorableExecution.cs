using System;
using System.Collections;

namespace Server.Spells.Bushido
{
	public class HonorableExecutionAbility : BushidoAbility
	{
		private static readonly Hashtable m_Table = new();

		public override SpellName ID => SpellName.HonorableExecution;

		public override TextDefinition AbilityMessage => 1063122; // You better kill your enemy with your next hit or you'll be rather sorry...

		public HonorableExecutionAbility()
		{
		}

		public override double GetDamageScalar(Mobile attacker, Mobile defender)
		{
			var bushido = attacker.Skills[SkillName.Bushido].Value;

			// TODO: 20 -> Perfection
			return 1.0 + (bushido * 20) / 10000;
		}

		public override void OnHit(Mobile attacker, Mobile defender, int damage)
		{
			if (!Validate(attacker) || !CheckMana(attacker, true))
			{
				return;
			}

			ClearCurrentMove(attacker);

			if (m_Table[attacker] is HonorableExecutionInfo info)
			{
				info.Clear();

				info.m_Timer?.Stop();
			}

			if (!defender.Alive)
			{
				attacker.FixedParticles(0x373A, 1, 17, 0x7E2, EffectLayer.Waist);

				var bushido = attacker.Skills[SkillName.Bushido].Value;

				attacker.Hits += 20 + (int)((bushido * bushido) / 480.0);

				var swingBonus = Math.Max(1, (int)((bushido * bushido) / 720.0));

				info = new HonorableExecutionInfo(attacker, swingBonus);
				info.m_Timer = Timer.DelayCall(TimeSpan.FromSeconds(20.0), EndEffect, info);

				m_Table[attacker] = info;
			}
			else
			{
				var mods = new ArrayList 
				{
					new ResistanceMod(ResistanceType.Physical, -40),
					new ResistanceMod(ResistanceType.Fire, -40),
					new ResistanceMod(ResistanceType.Cold, -40),
					new ResistanceMod(ResistanceType.Poison, -40),
					new ResistanceMod(ResistanceType.Energy, -40)
				};

				var resSpells = attacker.Skills[SkillName.MagicResist].Value;

				if (resSpells > 0.0)
				{
					mods.Add(new DefaultSkillMod(SkillName.MagicResist, true, -resSpells));
				}

				info = new HonorableExecutionInfo(attacker, mods);
				info.m_Timer = Timer.DelayCall(TimeSpan.FromSeconds(7.0), EndEffect, info);

				m_Table[attacker] = info;
			}

			CheckGain(attacker);
		}

		public static int GetSwingBonus(Mobile target)
		{
			if (m_Table[target] is HonorableExecutionInfo info)
			{
				return info.m_SwingBonus;
			}

			return 0;
		}

		public static bool IsUnderPenalty(Mobile target)
		{
			if (m_Table[target] is HonorableExecutionInfo info)
			{
				return info.m_Penalty;
			}

			return false;
		}

		public static void RemovePenalty(Mobile target)
		{
			if (m_Table[target] is HonorableExecutionInfo info && info.m_Penalty)
			{
				info.Clear();

				info.m_Timer?.Stop();

				m_Table.Remove(target);
			}
		}

		private static void EndEffect(HonorableExecutionInfo info)
		{
			RemovePenalty(info?.m_Mobile);
		}

		private class HonorableExecutionInfo
		{
			public Mobile m_Mobile;
			public int m_SwingBonus;
			public ArrayList m_Mods;
			public bool m_Penalty;
			public Timer m_Timer;

			public HonorableExecutionInfo(Mobile from, int swingBonus) 
				: this(from, swingBonus, null, false)
			{
			}

			public HonorableExecutionInfo(Mobile from, ArrayList mods) 
				: this(from, 0, mods, true)
			{
			}

			public HonorableExecutionInfo(Mobile from, int swingBonus, ArrayList mods, bool penalty)
			{
				m_Mobile = from;
				m_SwingBonus = swingBonus;
				m_Mods = mods;
				m_Penalty = penalty;

				Apply();
			}

			public void Apply()
			{
				if (m_Mods == null)
				{
					return;
				}

				foreach (var mod in m_Mods)
				{
					if (mod is ResistanceMod rm)
					{
						m_Mobile.AddResistanceMod(rm);
					}
					else if (mod is SkillMod sm)
					{
						m_Mobile.AddSkillMod(sm);
					}
				}
			}

			public void Clear()
			{
				if (m_Mods == null)
				{
					return;
				}

				foreach (var mod in m_Mods)
				{
					if (mod is ResistanceMod rm)
					{
						m_Mobile.RemoveResistanceMod(rm);
					}
					else if (mod is SkillMod sm)
					{
						m_Mobile.RemoveSkillMod(sm);
					}
				}
			}
		}
	}
}