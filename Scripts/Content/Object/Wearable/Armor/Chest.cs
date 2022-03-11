namespace Server.Items
{
	#region Bone Chests

	/// BoneChest
	[FlipableAttribute(0x144f, 0x1454)]
	public class BoneChest : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 60;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -6;

		public override int ArmorBase => 30;
		public override int RevertArmorBase => 11;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public BoneChest() : base(0x144F)
		{
			Weight = 6.0;
		}

		public BoneChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			if (Weight == 1.0)
			{
				Weight = 6.0;
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// DaemonChest
	[FlipableAttribute(0x144f, 0x1454)]
	public class DaemonChest : BaseArmor
	{
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 6;
		public override int BaseColdResistance => 7;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 7;

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int AosStrReq => 60;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -6;

		public override int ArmorBase => 46;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041372;  // daemon bone armor

		[Constructable]
		public DaemonChest() : base(0x144F)
		{
			Weight = 6.0;
			Hue = 0x648;

			ArmorAttributes.SelfRepair = 1;
		}

		public DaemonChest(Serial serial) : base(serial)
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
				Weight = 6.0;
			}

			if (ArmorAttributes.SelfRepair == 0)
			{
				ArmorAttributes.SelfRepair = 1;
			}
		}
	}

	#endregion

	#region Chainmail Chests

	/// ChainChest
	[FlipableAttribute(0x13bf, 0x13c4)]
	public class ChainChest : BaseArmor
	{
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 60;
		public override int OldStrReq => 20;

		public override int OldDexBonus => -5;

		public override int ArmorBase => 28;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;

		[Constructable]
		public ChainChest() : base(0x13BF)
		{
			Weight = 7.0;
		}

		public ChainChest(Serial serial) : base(serial)
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

	#endregion

	#region Cloth Chests

	/// LeatherNinjaJacket
	public class LeatherNinjaJacket : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 10;
		public override int OldStrReq => 10;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherNinjaJacket() : base(0x2793)
		{
			Weight = 5.0;
		}

		public LeatherNinjaJacket(Serial serial) : base(serial)
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

	#endregion

	#region Dragon Chests

	/// DragonChest
	[FlipableAttribute(0x2641, 0x2642)]
	public class DragonChest : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 75;
		public override int OldStrReq => 60;

		public override int OldDexBonus => -8;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Dragon;
		public override CraftResource DefaultResource => CraftResource.RedScales;

		[Constructable]
		public DragonChest() : base(0x2641)
		{
			Weight = 10.0;
		}

		public DragonChest(Serial serial) : base(serial)
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
				Weight = 15.0;
			}
		}
	}

	#endregion

	#region Leather Chests

	/// LeatherChest
	[FlipableAttribute(0x13cc, 0x13d3)]
	public class LeatherChest : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 25;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherChest() : base(0x13CC)
		{
			Weight = 6.0;
		}

		public LeatherChest(Serial serial) : base(serial)
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
				Weight = 6.0;
			}
		}
	}

	/// FemaleLeatherChest
	[FlipableAttribute(0x1c06, 0x1c07)]
	public class FemaleLeatherChest : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 25;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		public override bool AllowMaleWearer => false;

		[Constructable]
		public FemaleLeatherChest() : base(0x1C06)
		{
			Weight = 1.0;
		}

		public FemaleLeatherChest(Serial serial) : base(serial)
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

	/// HideChest
	[FlipableAttribute(0x2B74, 0x316B)]
	public class HideChest : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 15;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public HideChest() : base(0x2B74)
		{
			Weight = 6.0;
		}

		public HideChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// HideFemaleChest
	[FlipableAttribute(0x2B79, 0x3170)]
	public class HideFemaleChest : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 35;
		public override int OldStrReq => 35;

		public override int ArmorBase => 15;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		public override bool AllowMaleWearer => false;

		[Constructable]
		public HideFemaleChest() : base(0x2B79)
		{
			Weight = 6.0;
		}

		public HideFemaleChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// LeafChest
	[FlipableAttribute(0x2FC5, 0x317B)]
	public class LeafChest : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 20;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeafChest() : base(0x2FC5)
		{
			Weight = 2.0;
		}

		public LeafChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// FemaleLeafChest
	[FlipableAttribute(0x2FCB, 0x3181)]
	public class FemaleLeafChest : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 20;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		public override bool AllowMaleWearer => false;

		[Constructable]
		public FemaleLeafChest() : base(0x2FCB)
		{
			Weight = 2.0;
		}

		public FemaleLeafChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// StuddedChest
	[FlipableAttribute(0x13db, 0x13e2)]
	public class StuddedChest : BaseArmor
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

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public StuddedChest() : base(0x13DB)
		{
			Weight = 8.0;
		}

		public StuddedChest(Serial serial) : base(serial)
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

	/// FemaleStuddedChest
	[FlipableAttribute(0x1c02, 0x1c03)]
	public class FemaleStuddedChest : BaseArmor
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

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		public override bool AllowMaleWearer => false;

		[Constructable]
		public FemaleStuddedChest() : base(0x1C02)
		{
			Weight = 6.0;
		}

		public FemaleStuddedChest(Serial serial) : base(serial)
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
				Weight = 6.0;
			}
		}
	}

	/// LeatherDo
	public class LeatherDo : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 40;
		public override int OldStrReq => 40;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherDo() : base(0x27C6)
		{
			Weight = 6.0;
		}

		public LeatherDo(Serial serial) : base(serial)
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

	/// StuddedDo
	public class StuddedDo : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 55;
		public override int OldStrReq => 55;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public StuddedDo() : base(0x27C7)
		{
			Weight = 8.0;
		}

		public StuddedDo(Serial serial) : base(serial)
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

	#endregion

	#region Platemail Chests

	/// PlateChest
	[FlipableAttribute(0x1415, 0x1416)]
	public class PlateChest : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 95;
		public override int OldStrReq => 60;

		public override int OldDexBonus => -8;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateChest() : base(0x1415)
		{
			Weight = 10.0;
		}

		public PlateChest(Serial serial) : base(serial)
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
				Weight = 10.0;
			}
		}
	}

	/// FemalePlateChest
	[FlipableAttribute(0x1c04, 0x1c05)]
	public class FemalePlateChest : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 95;
		public override int OldStrReq => 45;

		public override int OldDexBonus => -5;

		public override bool AllowMaleWearer => false;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public FemalePlateChest() : base(0x1C04)
		{
			Weight = 4.0;
		}

		public FemalePlateChest(Serial serial) : base(serial)
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

	/// WoodlandChest
	[FlipableAttribute(0x2B67, 0x315E)]
	public class WoodlandChest : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 95;
		public override int OldStrReq => 95;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
		public override Race RequiredRace => Race.Elf;

		[Constructable]
		public WoodlandChest() : base(0x2B67)
		{
			Weight = 8.0;
		}

		public WoodlandChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// FemaleElvenPlateChest
	[FlipableAttribute(0x2B6D, 0x3164)]
	public class FemaleElvenPlateChest : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 95;
		public override int OldStrReq => 95;

		public override bool AllowMaleWearer => false;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public FemaleElvenPlateChest() : base(0x2B6D)
		{
			Weight = 8.0;
		}

		public FemaleElvenPlateChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// PlateDo
	public class PlateDo : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 60;
		public override int InitMaxHits => 70;

		public override int AosStrReq => 85;
		public override int OldStrReq => 85;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateDo() : base(0x277D)
		{
			Weight = 10.0;
		}

		public PlateDo(Serial serial) : base(serial)
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

	#endregion

	#region Ringmail Chests

	/// RingmailChest
	[FlipableAttribute(0x13ec, 0x13ed)]
	public class RingmailChest : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 1;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 40;
		public override int OldStrReq => 20;

		public override int OldDexBonus => -2;

		public override int ArmorBase => 22;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;

		[Constructable]
		public RingmailChest() : base(0x13EC)
		{
			Weight = 15.0;
		}

		public RingmailChest(Serial serial) : base(serial)
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
				Weight = 15.0;
			}
		}
	}

	#endregion
}