using Server.Network;

namespace Server.Spells.Racial
{
	public abstract class RacialTransformation : RacialAbility, ITransformationSpell
	{
		public static void Initialize()
		{
			EventSink.Login += e =>
			{
				var context = TransformationSpellHelper.GetContext(e.Mobile);

				if (context?.Spell is RacialTransformation spell && spell.SpeedBoost)
				{
					_ = e.Mobile.Send(SpeedControl.MountSpeed);
				}
			};
		}

		public abstract Body Body { get; }

		public virtual int Hue => 0;

		public virtual double TickRate => 1.0;

		public virtual int PhysResistOffset => 0;
		public virtual int FireResistOffset => 0;
		public virtual int ColdResistOffset => 0;
		public virtual int PoisResistOffset => 0;
		public virtual int NrgyResistOffset => 0;

		public virtual bool SpeedBoost => false;

		public RacialTransformation(Mobile caster, Item scroll, SpellInfo info)
			: base(caster, scroll, info)
		{ }

		public override bool CheckCast()
		{
			if (TransformationSpellHelper.CheckCast(Caster, this))
			{
				return base.CheckCast();
			}

			return false;
		}

		public override void OnCast()
		{
			_ = TransformationSpellHelper.OnCast(Caster, this);

			FinishSequence();
		}

		public virtual void OnTick(Mobile m)
		{ }

		public virtual void DoEffect(Mobile m)
		{
			if (SpeedBoost)
			{
				_ = m.Send(SpeedControl.MountSpeed);
			}
		}

		public virtual void RemoveEffect(Mobile m)
		{
			if (SpeedBoost)
			{
				_ = m.Send(SpeedControl.Disable);
			}
		}
	}
}
