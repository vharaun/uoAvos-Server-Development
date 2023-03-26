using Server.Items;

namespace Server.Spells.Necromancy
{
	public abstract class NecromancySpell : Spell
	{
		public new NecromancySpellName ID => (NecromancySpellName)base.ID;

		public override SkillName CastSkill => SkillName.Necromancy;
		public override SkillName DamageSkill => SkillName.SpiritSpeak;

		public override bool ClearHandsOnCast => false;
		
		// Necromancer spells are not affected by fast cast items, though they are by fast cast recovery
		public override double CastDelayFastScalar => Core.SE ? base.CastDelayFastScalar : 0; 

		public NecromancySpell(Mobile caster, Item scroll, NecromancySpellName id)
			: base(caster, scroll, (SpellName)id)
		{
		}

		public NecromancySpell(Mobile caster, Item scroll, SpellInfo info) 
			: base(caster, scroll, info)
		{
		}

		public override int ComputeKarmaAward()
		{
			//TODO: Verify this formula being that Necro spells don't HAVE a circle.
			var karma = -(40 + (int)(10 * (CastDelayBase.TotalSeconds / CastDelaySecondsPerTick)));

			if (Core.ML) // Pub 36: "Added a new property called Increased Karma Loss which grants higher karma loss for casting necromancy spells."
			{
				karma += AOS.Scale(karma, AosAttributes.GetValue(Caster, AosAttribute.IncreasedKarmaLoss));
			}

			return karma;
		}

		public override void GetCastSkills(ref double req, out double min, out double max)
		{
			min = max = req;

			if (Scroll == null)
			{
				max += 40.0;
			}
		}

		public override bool ConsumeReagents()
		{
			if (base.ConsumeReagents())
			{
				return true;
			}

			if (ArcaneGem.ConsumeCharges(Caster, 1))
			{
				return true;
			}

			return false;
		}
	}
}