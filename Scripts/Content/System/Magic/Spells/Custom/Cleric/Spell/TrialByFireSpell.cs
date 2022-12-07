using System;
using System.Collections.Generic;

namespace Server.Spells.Cleric
{
	public class TrialByFireSpell : ClericSpell
	{
		private static readonly Dictionary<Mobile, InternalTimer> m_Table = new();

		public TrialByFireSpell(Mobile caster, Item scroll)
			: base(caster, scroll, ClericSpellName.TrialByFire)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				if (m_Table.TryGetValue(Caster, out var timer))
				{
					_ = m_Table.Remove(Caster);

					timer?.Stop();
				}

				Caster.PlaySound(0x208);
				Caster.FixedParticles(0x3709, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot);

				Caster.SendMessage("Your body is covered by holy flames.");

				var duration = TimeSpan.FromMinutes(Caster.Skills[SkillName.Magery].Value / 10.0);

				m_Table[Caster] = timer = new InternalTimer(Caster, duration);

				timer.Start();
			}

			FinishSequence();
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Caster;
			private readonly DateTime m_End;

			public InternalTimer(Mobile caster, TimeSpan duration)
				: base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
			{
				m_Caster = caster;
				m_End = DateTime.UtcNow.Add(duration);
			}

			private void Expire()
			{
				Stop();

				_ = m_Table.Remove(m_Caster);

				m_Caster.SendMessage("The holy fire around you fades.");
			}

			protected override void OnTick()
			{
				if (!m_Caster.Alive)
				{
					Expire();
					return;
				}

				if (DateTime.UtcNow >= m_End)
				{
					Expire();
					return;
				}

				var scale = 1.0 + (m_Caster.Skills[SkillName.Inscribe].Value / 100.0);

				if (m_Caster.Player)
				{
					scale += m_Caster.Int / 1000.0;
					scale += AosAttributes.GetValue(m_Caster, AosAttribute.SpellDamage) / 100.0;
				}

				var baseDamage = 6 + (m_Caster.Skills[SkillName.EvalInt].Value / 5.0);
				var firedmg = scale * (baseDamage + Utility.RandomMinMax(0, 5));

				var eable = m_Caster.GetMobilesInRange(3);

				foreach (var target in eable)
				{
					if (m_Caster == target)
					{
						continue;
					}

					if (!m_Caster.CanBeHarmful(target))
					{
						continue;
					}

					if (!SpellHelper.ValidIndirectTarget(m_Caster, target))
					{
						continue;
					}

					m_Caster.DoHarmful(target);

					target.FixedParticles(0x3709, 10, 30, 5052, 0x480, 0, EffectLayer.LeftFoot);
					target.PlaySound(0x208);

					SpellHelper.Damage(TimeSpan.Zero, target, m_Caster, firedmg, 0, 100, 0, 0, 0);
				}

				eable.Free();
			}
		}
	}
}
