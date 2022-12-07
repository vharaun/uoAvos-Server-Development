namespace Server.Spells.Ranger
{
	public abstract class RangerSpell : Spell
	{
		public new RangerSpellName ID => (RangerSpellName)base.ID;

		public override SkillName CastSkill => SkillName.Tracking;
		public override SkillName DamageSkill => SkillName.Archery;

		public override bool ClearHandsOnCast => false;

		public RangerSpell(Mobile caster, Item scroll, RangerSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public RangerSpell(Mobile caster, Item scroll, SpellInfo info) 
			: base(caster, scroll, info)
		{
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			min = req;
			max = req + 30.0;
		}
	}
}

