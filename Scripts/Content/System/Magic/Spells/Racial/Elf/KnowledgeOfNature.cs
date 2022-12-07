namespace Server.Spells.Racial
{
	public class KnowledgeOfNatureRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Elf;

		public KnowledgeOfNatureRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.KnowledgeOfNature)
		{ }
	}
}
