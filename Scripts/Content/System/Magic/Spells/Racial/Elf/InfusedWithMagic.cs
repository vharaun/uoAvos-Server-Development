namespace Server.Spells.Racial
{
	public class InfusedWithMagicRacialAbility : RacialPassiveAbility
	{
		public override Race Race => Race.Elf;

		public InfusedWithMagicRacialAbility(Mobile caster, Item scroll)
			: base(caster, scroll, RacialAbilityName.InfusedWithMagic)
		{ }
	}
}
