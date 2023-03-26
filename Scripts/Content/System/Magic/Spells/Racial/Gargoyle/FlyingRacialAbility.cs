using Server.Factions;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Spells.Magery;
using Server.Spells.Mysticism;
using Server.Spells.Necromancy;
using Server.Spells.Ninjitsu;

namespace Server.Spells.Racial
{
	public class FlyingRacialAbility : RacialAbility
	{
		public static bool CheckFlyingAllowed(Mobile mob, bool message)
		{
			var reg = mob.Region.GetRegion<BaseRegion>();

			if (reg != null)
			{
				if (!reg.Rules.AllowEthereal)
				{
					if (!reg.OnRuleEnforced(RegionFlags.AllowEthereal, mob, mob, false))
					{
						return false;
					}
				}

				if (!reg.Rules.AllowMount)
				{
					if (!reg.OnRuleEnforced(RegionFlags.AllowMount, mob, mob, false))
					{
						return false;
					}
				}
			}

			return true;
		}

		public override Race Race => Race.Gargoyle;

		public override bool RevealOnCast => false;

		public FlyingRacialAbility(Mobile caster, Item scroll)
			: base(caster, null, RacialAbilityName.Flying)
		{ }

		public override bool CheckInterrupt(SpellInterrupt type, bool resistable)
		{
			if (Caster.Flying)
			{
				return false;
			}

			return type != SpellInterrupt.EquipRequest && type != SpellInterrupt.UseRequest;
		}

		public override void OnInterrupt(SpellInterrupt type, bool message)
		{
			if (Caster.Flying)
			{
				return;
			}

			if (message)
			{
				Caster.SendLocalizedMessage(1113192); // You have been disrupted while attempting to fly!
			}
		}

		public override bool CheckCast()
		{
			if (Caster.Flying)
			{
				return true;
			}

			if (!CheckFlyingAllowed(Caster, true))
			{
				return false;
			}

			if (!BaseMount.CheckMountAllowed(Caster))
			{
				return false;
			}

			if (!Caster.Alive)
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1113082); // You may not fly while dead.
				return false;
			}

			if (Caster.IsBodyMod && !Caster.Body.IsHuman)
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1112453); // You can't fly in your current form!
				return false;
			}

			if (Sigil.ExistsOn(Caster))
			{
				Caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
				return false;
			}

			if (PolymorphSpell.IsPolymorphed(Caster) || IncognitoSpell.IsIncognito(Caster))
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1112453); // You can't fly in your current form!
				return false;
			}

			if (TransformationSpellHelper.UnderTransformation(Caster))
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1112453); // You can't fly in your current form!
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			FinishSequence();

			Caster.Flying = !Caster.Flying;
		}
	}
}
