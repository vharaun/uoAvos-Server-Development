namespace Server.Spells.Racial
{
	public class MysticInsightRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Gargoyle;

		public MysticInsightRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.MysticInsight)
		{ }
	}
}
