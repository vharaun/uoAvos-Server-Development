using Server.Targeting;

namespace Server.Spells.Cleric
{
	public class TouchOfLifeSpell : ClericSpell
	{
		public TouchOfLifeSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ClericSpellName.TouchOfLife)
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
			else if (CheckBSequence(m, false))
			{
				SpellHelper.Turn(Caster, m);

				m.PlaySound(0x202);
				m.FixedParticles(0x376A, 1, 62, 0x480, 3, 3, EffectLayer.Waist);
				m.FixedParticles(0x3779, 1, 46, 0x481, 5, 3, EffectLayer.Waist);

				var toHeal = (Caster.Skills[SkillName.SpiritSpeak].Value / 2.0) + Utility.Random(5);

				toHeal *= DivineFocusSpell.GetScalar(Caster);

				m.Heal((int)toHeal);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly TouchOfLifeSpell m_Owner;

			public InternalTarget(TouchOfLifeSpell owner) 
				: base(12, false, TargetFlags.Beneficial)
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
