using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class SpringOfLifeSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public SpringOfLifeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.SpringOfLife)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				Effects.PlaySound(p, Caster.Map, 0x11);

				var time = Caster.Skills[SkillName.AnimalLore].Value * 1.2;

				if (time > 300)
				{
					time = 300;
				}

				var delay = TimeSpan.FromSeconds(time);

				var heal = (int)(Caster.Skills[DamageSkill].Value * 0.6);

				var eable = Caster.Map.GetMobilesInRange(new Point3D(p), 3);

				foreach (var m in eable)
				{
					if (Caster.CanBeBeneficial(m, false))
					{
						if (m.BeginAction(typeof(SpringOfLifeSpell)))
						{
							Caster.DoBeneficial(m);

							m.FixedParticles(0x375A, 9, 20, 5027, EffectLayer.Head);

							m.Heal(heal + Utility.Random(1, 10), Caster);

							m.FixedParticles(0x375A, 9, 20, 5027, EffectLayer.Waist);
							m.PlaySound(0xAF);

							_ = Timer.DelayCall(delay, m.EndAction, typeof(SpringOfLifeSpell));
						}
					}
				}

				eable.Free();
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly SpringOfLifeSpell m_Owner;

			public InternalTarget(SpringOfLifeSpell owner)
				: base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D p)
				{
					m_Owner.Target(p);
				}
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
