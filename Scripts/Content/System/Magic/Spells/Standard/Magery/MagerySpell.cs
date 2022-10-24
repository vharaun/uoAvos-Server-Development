using Server.Items;

using System;

namespace Server.Spells.Magery
{
	public abstract class MagerySpell : Spell
	{
		private static readonly double m_ChanceOffset = 20.0;
		private static readonly double m_ChanceLength = 100.0 / 7.0;

		public new MagerySpellName ID => (MagerySpellName)base.ID;

		public override SkillName CastSkill => SkillName.Magery;
		public override SkillName DamageSkill => SkillName.EvalInt;

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds((3 + (int)Circle) * CastDelaySecondsPerTick);

		public MagerySpell(Mobile caster, Item scroll, MagerySpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public MagerySpell(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{
		}

		public override bool ConsumeReagents()
		{
			if (base.ConsumeReagents())
			{
				return true;
			}

			var count = 1;

			if (!Core.SE && Circle != SpellCircle.Invalid)
			{
				count += (int)Circle;
			}

			if (ArcaneGem.ConsumeCharges(Caster, count))
			{
				return true;
			}

			return false;
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			var mod = Circle != SpellCircle.Invalid ? (int)Circle : 0;

			if (Scroll != null)
			{
				mod -= 2;
			}

			var avg = m_ChanceLength * mod;

			min = avg - m_ChanceOffset;
			max = avg + m_ChanceOffset;
		}

		public override int GetManaRequirement(int mana)
		{
			if (Scroll is BaseWand)
			{
				return 0;
			}

			return base.GetManaRequirement(mana);
		}

		public override double GetResistSkill(Mobile m)
		{
			var mod = Circle != SpellCircle.Invalid ? (int)Circle : 0;

			var maxSkill = ((1 + mod) * 10) + ((1 + (mod / 6)) * 25);

			if (m.Skills[SkillName.MagicResist].Value < maxSkill)
			{
				m.CheckSkill(SkillName.MagicResist, 0.0, m.Skills[SkillName.MagicResist].Cap);
			}

			return m.Skills[SkillName.MagicResist].Value;
		}

		public override TimeSpan GetCastDelay()
		{
			if (!Core.ML && Scroll is BaseWand)
			{
				return TimeSpan.Zero;
			}

			if (!Core.AOS)
			{
				if (Circle != SpellCircle.Invalid)
				{
					return TimeSpan.FromSeconds(0.5 + (0.25 * (int)Circle));
				}

				return TimeSpan.FromSeconds(0.5);
			}

			return base.GetCastDelay();
		}
	}
}