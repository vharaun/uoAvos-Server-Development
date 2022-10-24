using System;
using System.Collections.Generic;

namespace Server.Spells.Cleric
{
	public class AngelicFaithSpell : ClericTransformation
	{
		private static readonly Dictionary<Mobile, object[]> m_Table = new();

		public override Body Body => 123;

		public override double CastDelayFastScalar => 1.0;

		public override int CastRecoveryBase => Core.ML ? 5 : base.CastRecoveryBase;

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public AngelicFaithSpell(Mobile caster, Item scroll)
			: base(caster, scroll, ClericSpellName.AngelicFaith)
		{
		}

		public override void DoEffect(Mobile m)
		{
			base.DoEffect(m);

			if (!m_Table.ContainsKey(m))
			{
				var mods = new object[]
				{
					new StatMod(StatType.Str, "AngelicFaithStr", 20, TimeSpan.Zero),
					new StatMod(StatType.Dex, "AngelicFaithDex", 20, TimeSpan.Zero),
					new StatMod(StatType.Int, "AngelicFaithInt", 20, TimeSpan.Zero),

					new DefaultSkillMod(SkillName.Macing, true, 20),
					new DefaultSkillMod(SkillName.Healing, true, 20),
					new DefaultSkillMod(SkillName.Anatomy, true, 20),
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

			Caster.PlaySound(0x165);
			Caster.FixedParticles(0x3728, 1, 13, 0x480, 92, 3, EffectLayer.Head);
		}

		public override void RemoveEffect(Mobile m)
		{
			base.RemoveEffect(m);

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
