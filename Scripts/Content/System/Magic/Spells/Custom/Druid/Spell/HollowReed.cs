using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class HollowReedSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public HollowReedSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.HollowReed)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				_ = SpellHelper.AddStatBonus(Caster, m, StatType.Str);
				_ = SpellHelper.AddStatBonus(Caster, m, StatType.Dex);

				m.PlaySound(0x15);
				m.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly HollowReedSpell m_Owner;

			public InternalTarget(HollowReedSpell owner) 
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
