namespace Server.Spells.Racial
{
	public abstract class RacialPassiveAbility : RacialAbility
	{
		public override sealed bool Passive => true;

		public RacialPassiveAbility(Mobile caster, Item scroll, RacialAbilityName id)
			: base(caster, scroll, id)
		{ }

		public RacialPassiveAbility(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{ }

		public override void OnCast()
		{ }
	}
}
