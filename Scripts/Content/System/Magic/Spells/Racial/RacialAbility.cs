using System;

namespace Server.Spells.Racial
{
	public abstract class RacialAbility : Spell
	{
		public new RacialAbilityName ID => (RacialAbilityName)base.ID;

		public abstract Race Race { get; }

		public virtual bool Passive => false;

		public override bool RevealOnCast => !Passive;

		public override bool ClearHandsOnCast => false;

		public override bool ShowHandMovement => !Passive;

		public override bool BlockedByHorrificBeast => false;

		public override bool BlockedByAnimalForm => false;

		public override bool BlocksMovement => false;

		public override bool CheckNextSpellTime => !Passive;

		public override TimeSpan CastDelayBase => TimeSpan.Zero;

		public override TimeSpan CastDelayMinimum => TimeSpan.Zero;

		public override bool UseCastDelayMin => true;

		public override bool UseCastDelayMods => false;

		public override SkillName CastSkill => SkillName.Focus;
		public override SkillName DamageSkill => SkillName.Focus;

		public RacialAbility(Mobile caster, Item scroll, RacialAbilityName id)
			: base(caster, scroll, (SpellName)id)
		{ }

		public RacialAbility(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{ }

		public override bool Cast()
		{
			return Caster.Race == Race && base.Cast();
		}

		public override bool CheckCast()
		{
			return Passive || base.CheckCast();
		}

		public override bool CheckInterrupt(SpellInterrupt type, bool resistable)
		{
			return !Passive && base.CheckInterrupt(type, resistable);
		}

		public override bool ConsumeReagents()
		{
			return true;
		}

		public override void DoFizzle()
		{
			if (!Passive)
			{
				base.DoFizzle();
			}
		}

		public override void DoHurtFizzle()
		{
			if (!Passive)
			{
				base.DoHurtFizzle();
			}
		}

		public override void SayMantra()
		{
			if (!Passive)
			{
				base.SayMantra();
			}
		}
	}
}
