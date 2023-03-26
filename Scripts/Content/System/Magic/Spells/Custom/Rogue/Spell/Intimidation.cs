using System;
using System.Collections.Generic;

namespace Server.Spells.Rogue
{
	public class IntimidationSpell : ClericTransformation
	{
		private static readonly Dictionary<Mobile, object[]> m_Table = new();

		public override Body Body => 0;

		public IntimidationSpell(Mobile caster, Item scroll)
			: base(caster, scroll, RogueSpellName.Intimidation)
		{
		}

		public override void DoEffect(Mobile m)
		{
			base.DoEffect(m);

			if (!m_Table.ContainsKey(m))
			{
				var mods = new object[]
				{
					new StatMod(StatType.Dex, "IntimidationDex", -20, TimeSpan.Zero),
					new StatMod(StatType.Str, "IntimidationStr", 20, TimeSpan.Zero),

					new DefaultSkillMod(SkillName.Hiding, true, -20),
					new DefaultSkillMod(SkillName.Stealth, true, -20),
					new DefaultSkillMod(SkillName.Swords, true, 20),
					new DefaultSkillMod(SkillName.Macing, true, 20),
					new DefaultSkillMod(SkillName.Fencing, true, -20),
				};

				m_Table[Caster] = mods;

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
			}
		}

		public override void RemoveEffect(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var mods))
			{
				_ = m_Table.Remove(m);

				if (mods?.Length > 0)
				{
					foreach (var mod in mods)
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
		}
	}
}
