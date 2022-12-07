using Server.Targeting;

using System;

namespace Server.Spells.Druid
{
	public class VolcanicEruptionSpell : DruidSpell
	{
		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(2.0);

		public VolcanicEruptionSpell(Mobile caster, Item scroll)
			: base(caster, scroll, DruidSpellName.VolcanicEruption)
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
			else if (!SpellHelper.CheckTown(this, p))
			{
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				Point3D loc;

				if (p is Item item)
				{
					loc = item.GetWorldLocation();
				}
				else
				{
					loc = new Point3D(p);
				}

				var damage = Utility.Random(27, 22) * 1.0;
				var range = 1 + (int)(Caster.Skills[DamageSkill].Value / 10.0);

				var eable = Caster.Map.GetMobilesInRange(loc, range);

				foreach (var m in eable)
				{
					if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
					{
						var toDeal = damage;

						if (CheckResisted(m))
						{
							toDeal *= 0.7;

							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						Caster.DoHarmful(m);

						SpellHelper.Damage(this, m, toDeal, 50, 100, 0, 0, 0);

						m.FixedParticles(0x3709, 20, 10, 5044, EffectLayer.RightFoot);
						m.PlaySound(0x21F);
						m.FixedParticles(0x36BD, 10, 30, 5052, EffectLayer.Head);
						m.PlaySound(0x208);
					}
				}

				eable.Free();
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private readonly VolcanicEruptionSpell m_Owner;

			public InternalTarget(VolcanicEruptionSpell owner)
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

