using Server.Targeting;

using System;

namespace Server.Spells.Cleric
{
	public class SmiteSpell : ClericSpell
	{
		public SmiteSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ClericSpellName.Smite)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckHSequence(m))
			{
				m.BoltEffect(0x480);

				SpellHelper.Turn(Caster, m);

				var damage = Caster.Skills[SkillName.SpiritSpeak].Value * DivineFocusSpell.GetScalar(Caster);

				if (Core.AOS)
				{
					SpellHelper.Damage(TimeSpan.Zero, m, Caster, damage, 0, 0, 0, 0, 100);
				}
				else
				{
					SpellHelper.Damage(TimeSpan.Zero, m, Caster, damage);
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly SmiteSpell m_Owner;

			public InternalTarget(SmiteSpell owner) 
				: base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile m)
				{
					m_Owner.Target(m);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
