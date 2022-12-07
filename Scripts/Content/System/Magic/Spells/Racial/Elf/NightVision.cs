namespace Server.Spells.Racial
{
	public class NightVisionRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Elf;

		public NightVisionRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.NightVision)
		{ }
	}
}
