using System;
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
	public class AttunementSpell : SpellweavingSpell
	{
		private static readonly Dictionary<Mobile, Timer> m_Table = new();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public AttunementSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.Attunement)
		{
		}

		public override bool CheckCast()
		{
			if (IsAbsorbing(Caster))
			{
				Caster.SendLocalizedMessage(501775); // This spell is already in effect.
				return false;
			}
			
			if (!Caster.CanBeginAction(typeof(AttunementSpell)))
			{
				Caster.SendLocalizedMessage(1075124); // You must wait before casting that spell again.
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				Caster.PlaySound(0x5C3);
				Caster.FixedParticles(0x3728, 1, 13, 0x26B8, 0x455, 7, EffectLayer.Waist);
				Caster.FixedParticles(0x3779, 1, 15, 0x251E, 0x3F, 7, EffectLayer.Waist);

				StopAbsorbing(Caster, false);

				var skill = Caster.Skills.Spellweaving.Value;

				var damageAbsorb = (int)(18 + (skill - 10) / 10 * 3 + (FocusLevel * 6));

				Caster.MeleeDamageAbsorb = damageAbsorb;

				var duration = TimeSpan.FromSeconds(60 + (FocusLevel * 12));

				m_Table[Caster] = Timer.DelayCall(duration, StopAbsorbing, Caster, true);

				BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.AttuneWeapon, 1075798, duration, Caster, damageAbsorb.ToString()));
			}

			FinishSequence();
		}

		public static void TryAbsorb(Mobile defender, ref int damage)
		{
			if (damage == 0 || defender.MeleeDamageAbsorb <= 0 || !IsAbsorbing(defender))
			{
				return;
			}

			var absorbed = Math.Min(damage, defender.MeleeDamageAbsorb);

			damage -= absorbed;

			defender.MeleeDamageAbsorb -= absorbed;
			
			// ~1_damage~ point(s) of damage have been absorbed. A total of ~2_remaining~ point(s) of shielding remain.
			defender.SendLocalizedMessage(1075127, $"{absorbed}\t{defender.MeleeDamageAbsorb}"); 

			if (defender.MeleeDamageAbsorb <= 0)
			{
				StopAbsorbing(defender, true);
			}
		}

		public static bool IsAbsorbing(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void StopAbsorbing(Mobile m, bool message)
		{
			if (m_Table.TryGetValue(m, out var t))
			{
				t?.Stop();

				m_Table.Remove(m);

				m.MeleeDamageAbsorb = 0;

				if (message)
				{
					m.SendLocalizedMessage(1075126); // Your attunement fades.
					m.PlaySound(0x1F8);
				}

				m_Table.Remove(m);

				Timer.DelayCall(TimeSpan.FromSeconds(120.0), m.EndAction, typeof(AttunementSpell));

				BuffInfo.RemoveBuff(m, BuffIcon.AttuneWeapon);
			}
		}
	}
}