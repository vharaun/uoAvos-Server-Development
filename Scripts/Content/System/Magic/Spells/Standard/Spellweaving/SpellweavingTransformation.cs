namespace Server.Spells.Spellweaving
{
	public abstract class SpellweavingTransformation : SpellweavingSpell, ITransformationSpell
	{
		public abstract Body Body { get; }

		public virtual int Hue => 0;

		public virtual double TickRate => 1.0;

		public virtual int PhysResistOffset => 0;
		public virtual int FireResistOffset => 0;
		public virtual int ColdResistOffset => 0;
		public virtual int PoisResistOffset => 0;
		public virtual int NrgyResistOffset => 0;

		public SpellweavingTransformation(Mobile caster, Item scroll, SpellweavingSpellName id)
			: base(caster, scroll, id)
		{
		}

		public SpellweavingTransformation(Mobile caster, Item scroll, SpellInfo info) 
			: base(caster, scroll, info)
		{
		}

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