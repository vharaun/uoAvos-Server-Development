namespace Server.Spells.Racial
{
	public class StrongBackRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Human;

		public StrongBackRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.StrongBack)
		{ }
	}
}
