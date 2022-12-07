namespace Server.Spells.Racial
{
	public class JackOfAllTradesRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Human;

		public JackOfAllTradesRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.JackOfAllTrades)
		{ }
	}
}
