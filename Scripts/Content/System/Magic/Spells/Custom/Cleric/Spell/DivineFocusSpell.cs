using System;
using System.Collections.Generic;

namespace Server.Spells.Cleric
{
	public class DivineFocusSpell : ClericSpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public DivineFocusSpell(Mobile caster, Item scroll)
			: base(caster, scroll, ClericSpellName.DivineFocus)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (HasEffect(Caster))
			{
				Caster.SendMessage("This spell is already in effect.");
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.FixedParticles(0x375A, 1, 15, 0x480, 1, 4, EffectLayer.Waist);

				var t = new InternalTimer(Caster);

				m_Table[Caster] = t;

				t.Start();
			}

			FinishSequence();
		}

		public static bool HasEffect(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void EndEffect(Mobile m)
		{
			if (m_Table.TryGetValue(m, out var t))
			{
				_ = m_Table.Remove(m);

				t?.Stop();
			}
		}

		public static double GetScalar(Mobile m)
		{
			var val = 1.0;

			if (HasEffect(m))
			{
				val = 1.5;
			}

			return val;
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_Owner;

			public InternalTimer(Mobile owner)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(1.5))
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if (m_Owner.Alive && m_Owner.Mana >= 3)
				{
					m_Owner.Mana -= 3;
					return;
				}

				m_Owner.SendMessage("Your mind weakens and you are unable to maintain your divine focus.");

				EndEffect(m_Owner);
			}
		}
	}
}
