using Server.Items;

namespace Server.Spells.Ninjitsu
{
	public class FocusAttackAbility : NinjitsuAbility
	{
		public override SpellName ID => SpellName.FocusAttack;

		public override TextDefinition AbilityMessage => 1063095; // You prepare to focus all of your abilities into your next strike.

		public FocusAttackAbility()
		{
		}

		public override bool Validate(Mobile from)
		{
			if (from.FindItemOnLayer(Layer.TwoHanded) as BaseShield != null)
			{
				from.SendLocalizedMessage(1063096); // You cannot use this ability while holding a shield.
				return false;
			}

			if (from.FindItemOnLayer(Layer.OneHanded) is BaseWeapon handOne && handOne is not BaseRanged)
			{
				return base.Validate(from);
			}

			if (from.FindItemOnLayer(Layer.TwoHanded) is BaseWeapon handTwo && handTwo is not BaseRanged)
			{
				return base.Validate(from);
			}

			from.SendLocalizedMessage(1063097); // You must be wielding a melee weapon without a shield to use this ability.
			return false;
		}

		public override double GetDamageScalar(Mobile attacker, Mobile defender)
		{
			var ninjitsu = attacker.Skills[SkillName.Ninjitsu].Value;

			return 1.0 + (ninjitsu * ninjitsu) / 43636;
		}

		public override double GetPropertyBonus(Mobile attacker)
		{
			var ninjitsu = attacker.Skills[SkillName.Ninjitsu].Value;

			var bonus = (ninjitsu * ninjitsu) / 43636;

			return 1.0 + (bonus * 3 + 0.01);
		}

		public override bool OnBeforeDamage(Mobile attacker, Mobile defender)
		{
			return Validate(attacker) && CheckMana(attacker, true);
		}

		public override void OnHit(Mobile attacker, Mobile defender, int damage)
		{
			ClearCurrentMove(attacker);

			attacker.SendLocalizedMessage(1063098); // You focus all of your abilities and strike with deadly force!
			attacker.PlaySound(0x510);

			CheckGain(attacker);
		}
	}
}