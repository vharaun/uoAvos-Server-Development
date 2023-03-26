
using System;

namespace Server.Spells.Necromancy
{
	public class HorrificBeastSpell : NecromancyTransformation
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public override Body Body => 746;

		public HorrificBeastSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, NecromancySpellName.HorrificBeast)
		{
		}

		public override void DoEffect(Mobile m)
		{
			m.PlaySound(0x165);
			m.FixedParticles(0x3728, 1, 13, 9918, 92, 3, EffectLayer.Head);

			m.Delta(MobileDelta.WeaponDamage);
			m.CheckStatTimers();
		}

		public override void RemoveEffect(Mobile m)
		{
			m.Delta(MobileDelta.WeaponDamage);
		}
	}
}