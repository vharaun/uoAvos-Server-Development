using Server.Mobiles;

using System;

namespace Server.Spells.Mysticism
{
	public class AnimatedWeaponSpell : MysticismSummon<AnimatedWeapon>
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.5);

		public override int Sound => 0x64A;

		public override int Count => 1;
		public override int Slots => 4;

		public override bool Targeted => true;
		public override bool Controlled => false;

		public AnimatedWeaponSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.AnimatedWeapon)
		{
		}

		public int GetLevel()
		{
			return (int)((GetBaseSkill(Caster) + GetBoostSkill(Caster)) / 2.0);
		}

		public override TimeSpan GetDuration()
		{
			return TimeSpan.FromSeconds(10.0 + GetLevel());
		}

		public override AnimatedWeapon Construct()
		{
			return new AnimatedWeapon(Caster, GetLevel());
		}

		protected override void OnSummon(AnimatedWeapon summoned)
		{
			base.OnSummon(summoned);

			Effects.SendTargetParticles(summoned, 0x3728, 10, 10, 0x13AA, (EffectLayer)255);
		}
	}
}