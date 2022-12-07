using Server.Items;

using System;

namespace Server.Spells.Necromancy
{
	public class VampiricEmbraceSpell : NecromancyTransformation
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public override Body Body => Caster.Female ? 745 : 744;
		public override int Hue => 0x847E;

		public override int FireResistOffset => -25;

		public VampiricEmbraceSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, NecromancySpellName.VampiricEmbrace)
		{
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			if (Caster.Skills[CastSkill].Value >= req)
			{
				min = 80.0;
				max = 120.0;
			}
			else
			{
				base.GetCastSkills(ref req, out min, out max);
			}
		}

		public override void DoEffect(Mobile m)
		{
			Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x373A, 1, 17, 1108, 7, 9914, 0);
			Effects.SendLocationParticles(EffectItem.Create(m.Location, m.Map, EffectItem.DefaultDuration), 0x376A, 1, 22, 67, 7, 9502, 0);
			Effects.PlaySound(m.Location, m.Map, 0x4B1);
		}
	}
}