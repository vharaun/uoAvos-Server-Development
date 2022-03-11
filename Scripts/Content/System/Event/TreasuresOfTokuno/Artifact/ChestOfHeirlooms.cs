using Server.Items;

namespace Server.Engines.Events
{
	[Furniture]
	[Flipable(0x2811, 0x2812)]
	public class ChestOfHeirlooms : LockableContainer
	{
		public override int LabelNumber => 1070937;  // Chest of heirlooms

		[Constructable]
		public ChestOfHeirlooms() : base(0x2811)
		{
			Locked = true;
			LockLevel = 95;
			MaxLockLevel = 140;
			RequiredSkill = 95;

			TrapType = TrapType.ExplosionTrap;
			TrapLevel = 10;
			TrapPower = 100;

			GumpID = 0x10B;

			for (var i = 0; i < 10; ++i)
			{
				var item = Loot.ChestOfHeirloomsContains();

				var attributeCount = Utility.RandomMinMax(1, 5);
				var min = 20;
				var max = 80;

				if (item is BaseWeapon)
				{
					var weapon = (BaseWeapon)item;

					if (Core.AOS)
					{
						BaseRunicTool.ApplyAttributesTo(weapon, attributeCount, min, max);
					}
					else
					{
						weapon.DamageLevel = (WeaponDamageLevel)Utility.Random(6);
						weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random(6);
						weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random(6);
					}
				}
				else if (item is BaseArmor)
				{
					var armor = (BaseArmor)item;

					if (Core.AOS)
					{
						BaseRunicTool.ApplyAttributesTo(armor, attributeCount, min, max);
					}
					else
					{
						armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random(6);
						armor.Durability = (ArmorDurabilityLevel)Utility.Random(6);
					}
				}
				else if (item is BaseHat && Core.AOS)
				{
					BaseRunicTool.ApplyAttributesTo((BaseHat)item, attributeCount, min, max);
				}
				else if (item is BaseJewel && Core.AOS)
				{
					BaseRunicTool.ApplyAttributesTo((BaseJewel)item, attributeCount, min, max);
				}

				DropItem(item);
			}
		}

		public ChestOfHeirlooms(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}