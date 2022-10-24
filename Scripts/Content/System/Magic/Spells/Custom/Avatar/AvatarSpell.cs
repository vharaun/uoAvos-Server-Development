using System;

namespace Server.Spells.Avatar
{
    public abstract class AvatarSpell : Spell
	{
		public new AvatarSpellName ID => (AvatarSpellName)base.ID;

		public override SkillName CastSkill => SkillName.Chivalry; 
        public override SkillName DamageSkill => SkillName.Focus; 

        public override bool ClearHandsOnCast => false; 

        public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(3 * CastDelaySecondsPerTick);

        public override int CastRecoveryBase => 7; 
        public override int CastRecoveryFastScalar => 1; 
        public override int CastRecoveryPerSecond => 4; 
        public override int CastRecoveryMinimum => 0;

		public AvatarSpell(Mobile caster, Item scroll, AvatarSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public AvatarSpell(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

        public override void DoFizzle()
        {
            Caster.PlaySound(0x1D6);
            Caster.NextSpellTime = Core.TickCount;
        }

        public override void DoHurtFizzle()
        {
            Caster.PlaySound(0x1D6);
        }

        public override void OnInterrupt(SpellInterrupt type, bool message)
        {
            base.OnInterrupt(type, message);

			if (message)
			{
				Caster.PlaySound(0x1D6);
			}
        }

        public override void OnBeginCast()
        {
            base.OnBeginCast();

            SendCastEffect();
        }

        public virtual void SendCastEffect()
        {
            Caster.FixedEffect(0x37C4, 10, 42, 4, 3);
        }

        public override void GetCastSkills(ref double req, out double min, out double max)
        {
            min = req;
            max = req + 50.0;
        }

        public int ComputePowerValue(int div)
        {
            return ComputePowerValue(Caster, div);
        }

        public static int ComputePowerValue(Mobile from, int div)
		{
			if (from != null)
			{
				return (int)Math.Sqrt(from.Karma + 20000 + (from.Skills.Chivalry.Fixed * 10)) / div;
			}

			return 0;
		}
	}
}
