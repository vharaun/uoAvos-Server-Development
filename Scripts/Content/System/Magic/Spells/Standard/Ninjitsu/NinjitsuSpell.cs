namespace Server.Spells.Ninjitsu
{
	public abstract class NinjitsuSpell : Spell
	{
		public new NinjitsuSpellName ID => (NinjitsuSpellName)base.ID;

		public override SkillName CastSkill => SkillName.Ninjitsu;
		public override SkillName DamageSkill => SkillName.Ninjitsu;

		public override bool RevealOnCast => false;
		public override bool ClearHandsOnCast => false;
		public override bool ShowHandMovement => false;

		public override bool BlocksMovement => false;

		public override int CastRecoveryBase => 7;

		public NinjitsuSpell(Mobile caster, Item scroll, NinjitsuSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public NinjitsuSpell(Mobile caster, Item scroll, SpellInfo info) 
			: base(caster, scroll, info)
		{
		}

		public override void SendSkillRequirementMessage(double value, SkillName skill)
		{
			Caster.SendMessage($"You need {value:F1} {Caster.Skills[skill].Name} to perform that attack!");
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			min = req - 12.5; //Per 5 on friday 2/16/07
			max = req + 37.5;
		}
	}
}