
using System;

namespace Server.Spells.Necromancy
{
	public class LichFormSpell : NecromancyTransformation
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public override Body Body => 749;

		public override int FireResistOffset => -10;
		public override int ColdResistOffset => +10;
		public override int PoisResistOffset => +10;

		public override double TickRate => 2.5;

		public LichFormSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, NecromancySpellName.LichForm)
		{
		}

		public override void DoEffect(Mobile m)
		{
			m.PlaySound(0x19C);
			m.FixedParticles(0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot);
		}

		public override void OnTick(Mobile m)
		{
			--m.Hits;
		}
	}
}