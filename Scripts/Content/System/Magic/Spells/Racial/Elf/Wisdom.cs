namespace Server.Spells.Racial
{
	public class WisdomRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Elf;

		public WisdomRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.Wisdom)
		{ }
	}
}
