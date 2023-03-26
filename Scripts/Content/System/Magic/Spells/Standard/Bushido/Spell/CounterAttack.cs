using Server.Items;

using System;
using System.Collections;

namespace Server.Spells.Bushido
{
	public class CounterAttackSpell : BushidoSpell
	{
		private static readonly Hashtable m_Table = new();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(0.25);

		public CounterAttackSpell(Mobile caster, Item scroll) 
			: base(caster, scroll, BushidoSpellName.CounterAttack)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.FindItemOnLayer(Layer.TwoHanded) as BaseShield != null)
			{
				return true;
			}

			if (Caster.FindItemOnLayer(Layer.OneHanded) as BaseWeapon != null)
			{
				return true;
			}

			if (Caster.FindItemOnLayer(Layer.TwoHanded) as BaseWeapon != null)
			{
				return true;
			}

			Caster.SendLocalizedMessage(1062944); // You must have a weapon or a shield equipped to use this ability!
			return false;
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
				Caster.SendLocalizedMessage(1063118); // You prepare to respond immediately to the next blocked blow.

				OnCastSuccessful(Caster);

				StartCountering(Caster);
			}

			FinishSequence();
		}

		public static bool IsCountering(Mobile m)
		{
			return m_Table.Contains(m);
		}

		public static void StartCountering(Mobile m)
		{
			var t = (Timer)m_Table[m];

			t?.Stop();

			m_Table[m] = t = new InternalTimer(m);

			t.Start();
		}

		public static void StopCountering(Mobile m)
		{
			var t = (Timer)m_Table[m];

			t?.Stop();

			m_Table.Remove(m);

			OnEffectEnd(m, BushidoSpellName.CounterAttack);
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Mobile;

			public InternalTimer(Mobile m) 
				: base(TimeSpan.FromSeconds(30.0))
			{
				m_Mobile = m;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				StopCountering(m_Mobile);

				m_Mobile.SendLocalizedMessage(1063119); // You return to your normal stance.
			}
		}
	}
}