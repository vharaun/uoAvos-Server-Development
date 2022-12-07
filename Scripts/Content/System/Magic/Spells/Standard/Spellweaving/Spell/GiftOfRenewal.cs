using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
	public class GiftOfRenewalSpell : SpellweavingSpell
	{
		private static readonly Dictionary<Mobile, EffectState> m_Table = new();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(3.0);

		public GiftOfRenewalSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.GiftOfRenewal)
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
			else if (HasEffect(m))
			{
				Caster.SendLocalizedMessage(501775); // This spell is already in effect.
			}
			else if (!Caster.CanBeginAction(typeof(GiftOfRenewalSpell)))
			{
				Caster.SendLocalizedMessage(501789); // You must wait before trying again.
			}
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				Caster.FixedEffect(0x374A, 10, 20);
				Caster.PlaySound(0x5C9);

				if (m.Poisoned)
				{
					m.CurePoison(m);
				}
				else
				{
					var skill = Caster.Skills.Spellweaving.Value;

					var hitsPerRound = 5 + (int)((skill / 24.0) + FocusLevel);
					var duration = TimeSpan.FromSeconds(30.0 + (FocusLevel * 10.0));

					m_Table[m] = new EffectState(Caster, m, hitsPerRound, duration);

					Caster.BeginAction(typeof(GiftOfRenewalSpell));

					BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.GiftOfRenewal, 1031602, 1075797, duration, m, hitsPerRound.ToString()));
				}
			}

			FinishSequence();
		}

		public static bool HasEffect(Mobile m)
		{
			return m != null && m_Table.ContainsKey(m);
		}

		public static void StopEffect(Mobile m, bool message)
		{
			if (m_Table.TryGetValue(m, out var info))
			{
				info.Timer.Stop();

				m_Table.Remove(m);

				BuffInfo.RemoveBuff(m, BuffIcon.GiftOfRenewal);

				Timer.DelayCall(TimeSpan.FromSeconds(60.0), info.Caster.EndAction, typeof(GiftOfRenewalSpell));

				if (m.Alive)
				{
					m.PlaySound(0x455);
				}

				if (message)
				{
					m.SendLocalizedMessage(1075071); // The Gift of Renewal has faded.
				}
			}
		}

		private class EffectState
		{
			public Mobile Caster { get; }
			public Mobile Target { get; }

			public DateTime Expire { get; }

			public int HitsPerRound { get; }

			public InternalTimer Timer { get; }

			public EffectState(Mobile caster, Mobile target, int hitsPerRound, TimeSpan duration)
			{
				Caster = caster;
				Target = target;

				Expire = DateTime.UtcNow.Add(duration);

				HitsPerRound = hitsPerRound;

				Timer = new InternalTimer(this);
				Timer.Start();
			}
		}

		private class InternalTimer : Timer
		{
			public EffectState State { get; }

			public InternalTimer(EffectState state)
				: base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.0))
			{
				State = state;
			}

			protected override void OnTick()
			{
				if (!State.Target.Alive)
				{
					StopEffect(State.Target, false);
					return;
				}

				if (DateTime.UtcNow >= State.Expire)
				{
					StopEffect(State.Target, true);
					return;
				}

				if (State.Target.Hits < State.Target.HitsMax)
				{
					SpellHelper.Heal(State.HitsPerRound, State.Target, State.Caster);

					State.Target.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
				}
			}
		}

		public class InternalTarget : Target
		{
			private readonly GiftOfRenewalSpell m_Owner;

			public InternalTarget(GiftOfRenewalSpell owner)
				: base(10, false, TargetFlags.Beneficial)
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