namespace Server.Spells.Racial
{
	public class EvasiveRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Elf;

		public EvasiveRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.Evasive)
		{ }
	}
}
