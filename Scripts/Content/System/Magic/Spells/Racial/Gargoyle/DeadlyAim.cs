namespace Server.Spells.Racial
{
	public class DeadlyAimRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Gargoyle;

		public DeadlyAimRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.DeadlyAim)
		{ }
	}
}
