using Server.Targeting;

using System;

namespace Server.Spells.Mysticism
{
	public class MassSleepSpell : MysticismSpell
	{
		public MassSleepSpell(Mobile caster, Item scroll)
			: base(caster, scroll, MysticismSpellName.MassSleep)
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
			{ }
			else if (CheckSequence())
			{
				var factor = ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 20.0) + 3.0;

				var targets = Caster.Map.GetMobilesInRange(new Point3D(p), 3);

				foreach (var m in targets)
				{
					if (m == Caster)
					{
						continue;
					}

					if (SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && Caster.CanSee(m))
					{
						if (!Caster.InLOS(m))
						{
							continue;
						}

						var duration = factor - (GetResistSkill(m) / 10.0);

						if (duration > 0)
						{
							Caster.DoHarmful(m);

							SleepSpell.DoSleep(Caster, m, TimeSpan.FromSeconds(duration));
						}
					}
				}

				targets.Free();
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private readonly MassSleepSpell m_Owner;

			public InternalTarget(MassSleepSpell owner)
				: base(10, true, TargetFlags.Harmful)
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
