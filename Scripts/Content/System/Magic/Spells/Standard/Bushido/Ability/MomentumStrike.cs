using Server.Items;

using System.Collections.Generic;

namespace Server.Spells.Bushido
{
	public class MomentumStrikeAbility : BushidoAbility
	{
		public override SpellName ID => SpellName.MomentumStrike;

		public override TextDefinition AbilityMessage => 1070757; // You prepare to strike two enemies with one blow.

		public MomentumStrikeAbility()
		{
		}

		public override void OnHit(Mobile attacker, Mobile defender, int damage)
		{
			if (!Validate(attacker) || !CheckMana(attacker, false))
			{
				return;
			}

			ClearCurrentMove(attacker);

			var weapon = attacker.Weapon as BaseWeapon;

			var targets = new List<Mobile>();

			foreach (var m in attacker.GetMobilesInRange(weapon.MaxRange))
			{
				if (m == defender)
				{
					continue;
				}

				if (m.Combatant != attacker)
				{
					continue;
				}

				targets.Add(m);
			}

			if (targets.Count > 0)
			{
				if (!CheckMana(attacker, true))
				{
					return;
				}

				var target = targets[Utility.Random(targets.Count)];

				var damageBonus = attacker.Skills[SkillName.Bushido].Value / 100.0;

				if (!defender.Alive)
				{
					damageBonus *= 1.5;
				}

				attacker.SendLocalizedMessage(1063171); // You transfer the momentum of your weapon into another enemy!
				target.SendLocalizedMessage(1063172); // You were hit by the momentum of a Samurai's weapon!

				target.FixedParticles(0x37B9, 1, 4, 0x251D, 0, 0, EffectLayer.Waist);

				attacker.PlaySound(0x510);

				weapon.OnSwing(attacker, target, damageBonus);

				CheckGain(attacker);
			}
			else
			{
				attacker.SendLocalizedMessage(1063123); // There are no valid targets to attack!
			}
		}

		public override void CheckGain(Mobile m)
		{
			m.CheckSkill(MoveSkill, RequiredSkill, 120.0);
		}
	}
}