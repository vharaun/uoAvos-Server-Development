using Server.Spells;

using System;
using System.Collections;

#region Developer Notations

/// A godsend to a warrior surrounded, the Whirlwind Attack allows the fighter to strike at all nearby targets in one mighty spinning swing.

#endregion

namespace Server.Items
{
	public class WhirlwindAttack : WeaponAbility
	{
		public WhirlwindAttack()
		{
		}

		public override int BaseMana => 15;

		public override void OnHit(Mobile attacker, Mobile defender, int damage)
		{
			if (!Validate(attacker))
			{
				return;
			}

			ClearCurrentAbility(attacker);

			var map = attacker.Map;

			if (map == null)
			{
				return;
			}

			var weapon = attacker.Weapon as BaseWeapon;

			if (weapon == null)
			{
				return;
			}

			if (!CheckMana(attacker, true))
			{
				return;
			}

			attacker.FixedEffect(0x3728, 10, 15);
			attacker.PlaySound(0x2A1);

			var list = new ArrayList();

			foreach (var m in attacker.GetMobilesInRange(1))
			{
				list.Add(m);
			}

			var targets = new ArrayList();

			for (var i = 0; i < list.Count; ++i)
			{
				var m = (Mobile)list[i];

				if (m != defender && m != attacker && SpellHelper.ValidIndirectTarget(attacker, m))
				{
					if (m == null || m.Deleted || m.Map != attacker.Map || !m.Alive || !attacker.CanSee(m) || !attacker.CanBeHarmful(m))
					{
						continue;
					}

					if (!attacker.InRange(m, weapon.MaxRange))
					{
						continue;
					}

					if (attacker.InLOS(m))
					{
						targets.Add(m);
					}
				}
			}

			if (targets.Count > 0)
			{
				var bushido = attacker.Skills.Bushido.Value;
				var damageBonus = 1.0 + Math.Pow((targets.Count * bushido) / 60, 2) / 100;

				if (damageBonus > 2.0)
				{
					damageBonus = 2.0;
				}

				attacker.RevealingAction();

				for (var i = 0; i < targets.Count; ++i)
				{
					var m = (Mobile)targets[i];

					attacker.SendLocalizedMessage(1060161); // The whirling attack strikes a target!
					m.SendLocalizedMessage(1060162); // You are struck by the whirling attack and take damage!

					weapon.OnHit(attacker, m, damageBonus);
				}
			}
		}
	}
}