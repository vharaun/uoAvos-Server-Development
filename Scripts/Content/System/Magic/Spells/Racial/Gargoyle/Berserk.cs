namespace Server.Spells.Racial
{
	public class BerserkRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Gargoyle;

		public BerserkRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.Berserk)
		{ }
	}
}
