using Server.Mobiles;

using System;

namespace Server.Spells.Necromancy
{
	public class WraithFormSpell : NecromancyTransformation
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public override Body Body => Caster.Female ? 747 : 748;

		public override int Hue => Caster.Female ? 0 : 0x4001;

		public override int PhysResistOffset => +15;
		public override int FireResistOffset => -5;
		public override int NrgyResistOffset => -5;

		public WraithFormSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, NecromancySpellName.WraithForm)
		{
		}

		public override void DoEffect(Mobile m)
		{
			if (m is PlayerMobile pm)
			{
				pm.IgnoreMobiles = true;
			}

			m.PlaySound(0x17F);
			m.FixedParticles(0x374A, 1, 15, 9902, 1108, 4, EffectLayer.Waist);
		}

		public override void RemoveEffect(Mobile m)
		{
			if (m is PlayerMobile pm && m.AccessLevel == AccessLevel.Player)
			{
				pm.IgnoreMobiles = false;
			}
		}
	}
}