using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Cleric
{
	public class DampenSpiritSpell : ClericSpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public DampenSpiritSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, ClericSpellName.DampenSpirit)
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
				RemoveEffect(m);

				SpellHelper.Turn(Caster, m);

				m.FixedParticles(0x374A, 10, 15, 5032, EffectLayer.Head);
				m.PlaySound(0x1F8);
				m.SendMessage("You feel your spirit weakening.");

				var t = new InternalTimer(Caster, m, TimeSpan.FromSeconds(25.0));

				m_Table[m] = t;

				t.Start();
			}

			FinishSequence();
		}

		public static bool HasEffect(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void RemoveEffect(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var timer))
			{
				_ = m_Table.Remove(m);

				timer?.Stop();
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Caster;
			private readonly Mobile m_Target;
			private readonly DateTime m_Expire;

			public InternalTimer(Mobile caster, Mobile target, TimeSpan duration) 
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(1.5))
			{
				m_Caster = caster;
				m_Target = target;
				m_Expire = DateTime.UtcNow.Add(duration);
			}

			private void Expire()
			{
				Stop();

				RemoveEffect(m_Target);

				if (m_Target.Alive)
				{
					m_Target.SendMessage("Your spirit begins to recover.");
				}
			}

			protected override void OnTick()
			{
				if (!m_Target.Alive)
				{
					Expire();
					return;
				}

				m_Target.Stam = Math.Max(0, m_Target.Stam - 3);

				m_Target.DoHarmful(m_Caster);

				var now = DateTime.UtcNow;

				if (now >= m_Expire)
				{
					Expire();
				}
			}
		}

		private class InternalTarget : Target
		{
			private readonly DampenSpiritSpell m_Owner;

			public InternalTarget(DampenSpiritSpell owner) 
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
