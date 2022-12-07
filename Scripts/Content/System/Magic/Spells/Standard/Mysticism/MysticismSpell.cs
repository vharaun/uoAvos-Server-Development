using System;

namespace Server.Spells.Mysticism
{
	public abstract class MysticismSpell : Spell
	{
		public new MysticismSpellName ID => (MysticismSpellName)base.ID;

		public override SkillName CastSkill => SkillName.Mysticism;
		public override SkillName DamageSkill => SkillName.EvalInt;

		public override TimeSpan CastDelayBase => TimeSpan.FromMilliseconds((4 + (int)Circle) * CastDelaySecondsPerTick * 1000);

		public override double CastDelayFastScalar => 1.0;

		public MysticismSpell(Mobile caster, Item scroll, MysticismSpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public MysticismSpell(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			// As per Mysticism page at the UO Herald Playguide
			// This means that we have 25% success chance at min Required Skill

			min = req - 12.5;
			max = req + 37.5;
		}

		/* 
		 * As per OSI Publish 64:
		 * Imbuing is not the only skill associated with Mysticism now.
		 * Players can use EITHER their Focus skill or Imbuing skill.
		 * Evaluate Intelligence no longer has any effect on a Mystic’s spell power.
		 */
		public override double GetDamageSkill(Mobile m)
		{
			return Math.Max(m.Skills[SkillName.Imbuing].Value, m.Skills[SkillName.Focus].Value);
		}

		public override int GetDamageFixed(Mobile m)
		{
			return Math.Max(m.Skills[SkillName.Imbuing].Fixed, m.Skills[SkillName.Focus].Fixed);
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			SendCastEffect();
		}

		public virtual void SendCastEffect()
		{
			var delay = GetCastDelay();

			Caster.FixedEffect(0x37C4, 10, (int)(delay.TotalSeconds * 28), 0x66C, 3);
		}

		public static double GetBaseSkill(Mobile m)
		{
			return m.Skills[SkillName.Mysticism].Value;
		}

		public static double GetBoostSkill(Mobile m)
		{
			return Math.Max(m.Skills[SkillName.Imbuing].Value, m.Skills[SkillName.Focus].Value);
		}
	}
}