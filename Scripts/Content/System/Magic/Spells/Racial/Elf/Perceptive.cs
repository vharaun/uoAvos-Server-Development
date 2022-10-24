namespace Server.Spells.Racial
{
	public class PerceptiveRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Elf;

		public PerceptiveRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.Perceptive)
		{ }
	}
}
