using System;
using System.Collections;

namespace Server.Spells.Bushido
{
	public class ConfidenceSpell : BushidoSpell
	{
		private static readonly Hashtable m_Table = new();
		private static readonly Hashtable m_RegenTable = new();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(0.25);

		public ConfidenceSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, BushidoSpellName.Confidence)
		{
		}

		public override void OnBeginCast()
		{
			base.OnBeginCast();

			Caster.FixedEffect(0x37C4, 10, 7, 4, 3);
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.SendLocalizedMessage(1063115); // You exude confidence.

				Caster.FixedParticles(0x375A, 1, 17, 0x7DA, 0x960, 0x3, EffectLayer.Waist);
				Caster.PlaySound(0x51A);

				OnCastSuccessful(Caster);

				BeginConfidence(Caster);
				BeginRegenerating(Caster);
			}

			FinishSequence();
		}

		public static bool IsConfident(Mobile m)
		{
			return m_Table.Contains(m);
		}

		public static void BeginConfidence(Mobile m)
		{
			var t = (Timer)m_Table[m];

			t?.Stop();

			m_Table[m] = t = new InternalTimer(m);

			t.Start();
		}

		public static void EndConfidence(Mobile m)
		{
			var t = (Timer)m_Table[m];

			t?.Stop();

			m_Table.Remove(m);

			OnEffectEnd(m, BushidoSpellName.Confidence);
		}

		public static bool IsRegenerating(Mobile m)
		{
			return m_RegenTable.Contains(m);
		}

		public static void BeginRegenerating(Mobile m)
		{
			var t = (Timer)m_RegenTable[m];

			t?.Stop();

			m_RegenTable[m] = t = new RegenTimer(m);

			t.Start();
		}

		public static void StopRegenerating(Mobile m)
		{
			var t = (Timer)m_RegenTable[m];

			t?.Stop();

			m_RegenTable.Remove(m);
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Mobile;

			public InternalTimer(Mobile m) 
				: base(TimeSpan.FromSeconds(15.0))
			{
				m_Mobile = m;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				EndConfidence(m_Mobile);

				m_Mobile.SendLocalizedMessage(1063116); // Your confidence wanes.
			}
		}

		private class RegenTimer : Timer
		{
			private readonly Mobile m_Mobile;
			private int m_Ticks;
			private readonly int m_Hits;

			public RegenTimer(Mobile m) : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
			{
				m_Mobile = m;
				m_Hits = 15 + (m.Skills.Bushido.Fixed * m.Skills.Bushido.Fixed / 57600);
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				++m_Ticks;

				if (m_Ticks >= 5)
				{
					m_Mobile.Hits += (m_Hits - (m_Hits * 4 / 5));
					StopRegenerating(m_Mobile);
				}

				m_Mobile.Hits += (m_Hits / 5);
			}
		}
	}
}