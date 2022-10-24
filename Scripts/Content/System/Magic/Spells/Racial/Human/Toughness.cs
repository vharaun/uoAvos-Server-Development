namespace Server.Spells.Racial
{
	public class ToughnessRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Human;

		public ToughnessRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.Toughness)
		{ }
	}
}
