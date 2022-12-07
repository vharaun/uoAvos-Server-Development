namespace Server.Spells.Racial
{
	public class WorkhorseRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Human;

		public WorkhorseRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.WorkHorse)
		{ }
	}
}
