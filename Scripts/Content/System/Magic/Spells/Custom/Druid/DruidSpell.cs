using System;

namespace Server.Spells.Druid
{
	public abstract class DruidSpell : Spell
	{
		public new DruidSpellName ID => (DruidSpellName)base.ID;

		public override bool ClearHandsOnCast => false;

		public override SkillName CastSkill => SkillName.AnimalLore;
		public override SkillName DamageSkill => SkillName.AnimalLore;

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(3 * CastDelaySecondsPerTick);

		public DruidSpell(Mobile caster, Item scroll, DruidSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public DruidSpell(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.Karma <= 0)
			{
				Caster.SendMessage("You must have positive karma to commune with nature.");
				return false;
			}

			return true;
		}

		public override double GetResistSkill(Mobile m)
		{
			var maxSkill = (1 + (int)Circle) * 10;
			maxSkill += (1 + ((int)Circle / 6)) * 25;

			if (m.Skills[SkillName.MagicResist].Value < maxSkill)
			{
				m.CheckSkill(SkillName.MagicResist, 0.0, m.Skills[SkillName.MagicResist].Cap);
			}

			return m.Skills[SkillName.MagicResist].Value;
		}
	}
}
