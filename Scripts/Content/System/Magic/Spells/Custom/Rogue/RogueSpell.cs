using System;

namespace Server.Spells.Rogue
{
	public abstract class RogueSpell : Spell
	{
		public new RogueSpellName ID => (RogueSpellName)base.ID;

		public override SkillName CastSkill => SkillName.Stealing;
		public override SkillName DamageSkill => SkillName.Hiding;

		public override TimeSpan CastDelayBase => TimeSpan.Zero;
		public override TimeSpan CastDelayMinimum => TimeSpan.Zero;

		public override bool UseCastDelayMin => true;
		public override bool UseCastDelayMods => false;

		public override bool ClearHandsOnCast => false;

		public RogueSpell(Mobile caster, Item scroll, RogueSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public RogueSpell(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public override bool ConsumeReagents()
		{
			return true;
		}
	}
}
