namespace Server.Spells.Racial
{
	public class MasterArtisanRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Human;

		public MasterArtisanRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.MasterArtisan)
		{ }
	}
}
