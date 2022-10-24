using System;

namespace Server.Spells.Chivalry
{
	public abstract class ChivalrySpell : Spell
	{
		public new ChivalrySpellName ID => (ChivalrySpellName)base.ID;

		public override SkillName CastSkill => SkillName.Chivalry;
		public override SkillName DamageSkill => SkillName.Chivalry;

		public override bool ClearHandsOnCast => false;

		public override int CastRecoveryBase => 7;

		public ChivalrySpell(Mobile caster, Item scroll, ChivalrySpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public ChivalrySpell(Mobile caster, Item scroll, SpellInfo info) 
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
			var delay = GetCastDelay();

			Caster.FixedEffect(0x37C4, 10, (int)(delay.TotalSeconds * 28), 4, 3);
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

		public virtual int ComputePowerValue(Mobile from, int div)
		{
			if (from == null)
			{
				return 0;
			}

			var v = (int)Math.Sqrt(from.Karma + 20000 + (from.Skills[DamageSkill].Fixed * 10));

			return v / div;
		}
	}
}