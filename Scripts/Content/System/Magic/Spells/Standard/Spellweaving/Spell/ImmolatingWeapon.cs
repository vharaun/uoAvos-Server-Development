using Server.Items;

using System;
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
	public class ImmolatingWeaponSpell : SpellweavingSpell
	{
		private static readonly Dictionary<BaseWeapon, EffectState> m_Table = new();

		public override TimeSpan CastDelayBase => TimeSpan.FromSeconds(1.0);

		public ImmolatingWeaponSpell(Mobile caster, Item scroll)
			: base(caster, scroll, SpellweavingSpellName.ImmolatingWeapon)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if (Caster.Weapon is not BaseWeapon weapon || weapon is Fists || weapon is BaseRanged)
			{
				Caster.SendLocalizedMessage(1060179); // You must be wielding a weapon to use this ability!
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (Caster.Weapon is not BaseWeapon weapon || weapon is Fists || weapon is BaseRanged)
			{
				Caster.SendLocalizedMessage(1060179); // You must be wielding a weapon to use this ability!
			}
			else if (CheckSequence())
			{
				Caster.PlaySound(0x5CA);
				Caster.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);

				if (!IsImmolating(weapon)) // On OSI, the effect is not re-applied
				{
					var skill = Caster.Skills.Spellweaving.Value;

					var duration = TimeSpan.FromSeconds(10.0 + (skill / 24.0) + FocusLevel);
					var damage = 5 + (int)((skill / 24.0) + FocusLevel);

					m_Table[weapon] = new EffectState(Caster, damage, weapon, duration);

					weapon.InvalidateProperties();
				}
			}

			FinishSequence();
		}

		public static bool IsImmolating(BaseWeapon weapon)
		{
			return m_Table.ContainsKey(weapon);
		}

		public static int GetImmolatingDamage(BaseWeapon weapon)
		{
			if (m_Table.TryGetValue(weapon, out var entry))
			{
				return entry.Damage;
			}

			return 0;
		}

		public static void DoEffect(BaseWeapon weapon, Mobile target)
		{
			Timer.DelayCall(TimeSpan.FromSeconds(0.25), FinishEffect, weapon, target);
		}

		private static void FinishEffect(BaseWeapon weapon, Mobile target)
		{
			if (m_Table.TryGetValue(weapon, out var entry))
			{
				AOS.Damage(target, entry.Caster, entry.Damage, 0, 100, 0, 0, 0);
			}
		}

		public static void StopImmolating(BaseWeapon weapon)
		{
			if (m_Table.TryGetValue(weapon, out var entry))
			{
				entry.Caster.PlaySound(0x27);

				entry.Timer.Stop();

				m_Table.Remove(weapon);

				weapon.InvalidateProperties();
			}
		}

		private class EffectState
		{
			public Mobile Caster { get; }
			public int Damage { get; }
			public Timer Timer { get; }

			public EffectState(Mobile caster, int damage, BaseWeapon weapon, TimeSpan duration)
			{
				Caster = caster;
				Damage = damage;

				Timer = Timer.DelayCall(duration, StopImmolating, weapon);
			}
		}
	}
}