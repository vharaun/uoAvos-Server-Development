using System;

using Server.Mobiles;

namespace Server.Spells.Mysticism
{
	public class RisingColossusSpell : MysticismSummon<RisingColossus>
	{
		public override int Sound => 0x656;

		public override int Count => 1;
		public override int Slots => 5;

		public override bool Targeted => true;
		public override bool Controlled => false;

		public RisingColossusSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.RisingColossus)
		{
		}

		public override TimeSpan GetDuration()
		{
			var baseSkill = Caster.Skills.Mysticism.Value;
			var boostSkill = GetBoostSkill(Caster);

			return TimeSpan.FromSeconds((baseSkill + boostSkill) / 3.0);
		}

		public override RisingColossus Construct()
		{
			var baseSkill = Caster.Skills.Mysticism.Value;
			var boostSkill = GetBoostSkill(Caster);

			return new RisingColossus(Caster, baseSkill, boostSkill);
		}

		protected override void OnSummon(RisingColossus summoned)
		{
			base.OnSummon(summoned);

			Effects.SendTargetParticles(summoned, 0x3728, 10, 10, 0x13AA, (EffectLayer)255);
		}
	}
}
