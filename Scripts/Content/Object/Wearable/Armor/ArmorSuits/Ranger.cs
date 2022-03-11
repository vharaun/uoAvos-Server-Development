namespace Server.Items
{
	/// RangerGorget
	public class RangerGorget : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041495;  // studded gorget, ranger armor

		[Constructable]
		public RangerGorget() : base(0x13D6)
		{
			Weight = 1.0;
			Hue = 0x59C;
		}

		public RangerGorget(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// RangerChest
	[FlipableAttribute(0x13db, 0x13e2)]
	public class RangerChest : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041497;  // studded tunic, ranger armor

		[Constructable]
		public RangerChest() : base(0x13DB)
		{
			Weight = 8.0;
			Hue = 0x59C;
		}

		public RangerChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (Weight == 1.0)
			{
				Weight = 8.0;
			}
		}
	}

	/// RangerArms
	[FlipableAttribute(0x13dc, 0x13d4)]
	public class RangerArms : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041493;  // studded sleeves, ranger armor

		[Constructable]
		public RangerArms() : base(0x13DC)
		{
			Weight = 4.0;
			Hue = 0x59C;
		}

		public RangerArms(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (Weight == 1.0)
			{
				Weight = 4.0;
			}
		}
	}

	/// RangerGloves
	[FlipableAttribute(0x13d5, 0x13dd)]
	public class RangerGloves : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041494;  // studded gloves, ranger armor

		[Constructable]
		public RangerGloves() : base(0x13D5)
		{
			Weight = 1.0;
			Hue = 0x59C;
		}

		public RangerGloves(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// RangerLegs
	[FlipableAttribute(0x13da, 0x13e1)]
	public class RangerLegs : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 30;
		public override int OldStrReq => 35;

		public override int ArmorBase => 16;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041496;  // studded leggings, ranger armor

		[Constructable]
		public RangerLegs() : base(0x13DA)
		{
			Weight = 3.0;
			Hue = 0x59C;
		}

		public RangerLegs(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (Weight == 3.0)
			{
				Weight = 5.0;
			}
		}
	}
}