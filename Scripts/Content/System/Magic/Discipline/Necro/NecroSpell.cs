using Server.Items;

namespace Server.Spells.Necromancy
{
	public abstract class NecromancerSpell : Spell
	{
		public abstract double RequiredSkill { get; }
		public abstract int RequiredMana { get; }

		public override SkillName CastSkill => SkillName.Necromancy;
		public override SkillName DamageSkill => SkillName.SpiritSpeak;

		//public override int CastDelayBase{ get{ return base.CastDelayBase; } } // Reference, 3

		public override bool ClearHandsOnCast => false;

		public override double CastDelayFastScalar => (Core.SE ? base.CastDelayFastScalar : 0);  // Necromancer spells are not affected by fast cast items, though they are by fast cast recovery

		public NecromancerSpell(Mobile caster, Item scroll, SpellInfo info) : base(caster, scroll, info)
		{
		}

		public override int ComputeKarmaAward()
		{
			//TODO: Verify this formula being that Necro spells don't HAVE a circle.
			//int karma = -(70 + (10 * (int)Circle));
			var karma = -(40 + (int)(10 * (CastDelayBase.TotalSeconds / CastDelaySecondsPerTick)));

			if (Core.ML) // Pub 36: "Added a new property called Increased Karma Loss which grants higher karma loss for casting necromancy spells."
			{
				karma += AOS.Scale(karma, AosAttributes.GetValue(Caster, AosAttribute.IncreasedKarmaLoss));
			}

			return karma;
		}

		public override void GetCastSkills(out double min, out double max)
		{
			min = RequiredSkill;
			max = Scroll != null ? min : RequiredSkill + 40.0;
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

		public override int GetMana()
		{
			return RequiredMana;
		}
	}

	public abstract class TransformationSpell : NecromancerSpell, ITransformationSpell
	{
		public abstract int Body { get; }
		public virtual int Hue => 0;

		public virtual int PhysResistOffset => 0;
		public virtual int FireResistOffset => 0;
		public virtual int ColdResistOffset => 0;
		public virtual int PoisResistOffset => 0;
		public virtual int NrgyResistOffset => 0;

		public TransformationSpell(Mobile caster, Item scroll, SpellInfo info) : base(caster, scroll, info)
		{
		}

		public override bool BlockedByHorrificBeast => false;

		public override bool CheckCast()
		{
			if (!TransformationSpellHelper.CheckCast(Caster, this))
			{
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			TransformationSpellHelper.OnCast(Caster, this);

			FinishSequence();
		}

		public virtual double TickRate => 1.0;

		public virtual void OnTick(Mobile m)
		{
		}

		public virtual void DoEffect(Mobile m)
		{
		}

		public virtual void RemoveEffect(Mobile m)
		{
		}
	}
}