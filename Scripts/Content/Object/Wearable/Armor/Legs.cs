namespace Server.Items
{
	#region Bone Legs

	/// BoneLegs
	[FlipableAttribute(0x1452, 0x1457)]
	public class BoneLegs : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 55;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -4;

		public override int ArmorBase => 30;
		public override int RevertArmorBase => 7;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public BoneLegs() : base(0x1452)
		{
			Weight = 3.0;
		}

		public BoneLegs(Serial serial) : base(serial)
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

	/// DaemonLegs
	[FlipableAttribute(0x1452, 0x1457)]
	public class DaemonLegs : BaseArmor
	{
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 6;
		public override int BaseColdResistance => 7;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 7;

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int AosStrReq => 55;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -4;

		public override int ArmorBase => 46;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041375;  // daemon bone leggings

		[Constructable]
		public DaemonLegs() : base(0x1452)
		{
			Weight = 3.0;
			Hue = 0x648;

			ArmorAttributes.SelfRepair = 1;
		}

		public DaemonLegs(Serial serial) : base(serial)
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

			if (ArmorAttributes.SelfRepair == 0)
			{
				ArmorAttributes.SelfRepair = 1;
			}
		}
	}

	#endregion

	#region Chainmail Legs

	[FlipableAttribute(0x13be, 0x13c3)]
	public class ChainLegs : BaseArmor
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

		public override int OldDexBonus => -3;

		public override int ArmorBase => 28;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;

		[Constructable]
		public ChainLegs() : base(0x13BE)
		{
			Weight = 7.0;
		}

		public ChainLegs(Serial serial) : base(serial)
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

	#region Cloth Legs

	/// LeatherNinjaPants
	public class LeatherNinjaPants : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 10;
		public override int OldStrReq => 10;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherNinjaPants() : base(0x2791)
		{
			Weight = 3.0;
		}

		public LeatherNinjaPants(Serial serial) : base(serial)
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

	#region Dragon Legs

	/// DragonLegs
	[FlipableAttribute(0x2647, 0x2648)]
	public class DragonLegs : BaseArmor
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

		public override int OldDexBonus => -6;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Dragon;
		public override CraftResource DefaultResource => CraftResource.RedScales;

		[Constructable]
		public DragonLegs() : base(0x2647)
		{
			Weight = 6.0;
		}

		public DragonLegs(Serial serial) : base(serial)
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

	#region Leather Legs

	/// LeatherLegs
	[FlipableAttribute(0x13cb, 0x13d2)]
	public class LeatherLegs : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 10;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherLegs() : base(0x13CB)
		{
			Weight = 4.0;
		}

		public LeatherLegs(Serial serial) : base(serial)
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

	/// LeatherHaidate
	public class LeatherHaidate : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 20;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;


		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherHaidate() : base(0x278A)
		{
			Weight = 4.0;
		}

		public LeatherHaidate(Serial serial) : base(serial)
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

	/// LeatherSuneate
	public class LeatherSuneate : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 20;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherSuneate() : base(0x2786)
		{
			Weight = 4.0;
		}

		public LeatherSuneate(Serial serial) : base(serial)
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

	/// LeatherSkirt
	[FlipableAttribute(0x1c08, 0x1c09)]
	public class LeatherSkirt : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 10;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		public override bool AllowMaleWearer => false;

		[Constructable]
		public LeatherSkirt() : base(0x1C08)
		{
			Weight = 1.0;
		}

		public LeatherSkirt(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			if (Weight == 3.0)
			{
				Weight = 1.0;
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// LeatherShorts
	[FlipableAttribute(0x1c00, 0x1c01)]
	public class LeatherShorts : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 10;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		public override bool AllowMaleWearer => false;

		[Constructable]
		public LeatherShorts() : base(0x1C00)
		{
			Weight = 3.0;
		}

		public LeatherShorts(Serial serial) : base(serial)
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

	/// HidePants
	[FlipableAttribute(0x2B78, 0x316F)]
	public class HidePants : BaseArmor
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
		public HidePants() : base(0x2B78)
		{
			Weight = 5.0;
		}

		public HidePants(Serial serial) : base(serial)
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

	/// LeafLegs
	[FlipableAttribute(0x2FC9, 0x317F)]
	public class LeafLegs : BaseArmor
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
		public LeafLegs() : base(0x2FC9)
		{
			Weight = 2.0;
		}

		public LeafLegs(Serial serial) : base(serial)
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

	/// LeafTonlet(Legs)
	[FlipableAttribute(0x2FCA, 0x3180)]
	public class LeafTonlet : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 10;
		public override int OldStrReq => 10;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeafTonlet() : base(0x2FCA)
		{
			Weight = 2.0;
		}

		public LeafTonlet(Serial serial) : base(serial)
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

	/// StuddedLegs
	[FlipableAttribute(0x13da, 0x13e1)]
	public class StuddedLegs : BaseArmor
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

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public StuddedLegs() : base(0x13DA)
		{
			Weight = 5.0;
		}

		public StuddedLegs(Serial serial) : base(serial)
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

	/// StuddedHaidate
	public class StuddedHaidate : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 30;
		public override int OldStrReq => 30;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public StuddedHaidate() : base(0x278B)
		{
			Weight = 5.0;
		}

		public StuddedHaidate(Serial serial) : base(serial)
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

	/// StuddedSuneate
	public class StuddedSuneate : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 30;
		public override int OldStrReq => 30;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public StuddedSuneate() : base(0x27D2)
		{
			Weight = 5.0;
		}

		public StuddedSuneate(Serial serial) : base(serial)
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

	#region Platemail Legs

	/// PlateLegs
	[FlipableAttribute(0x1411, 0x141a)]
	public class PlateLegs : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 90;

		public override int OldStrReq => 60;
		public override int OldDexBonus => -6;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateLegs() : base(0x1411)
		{
			Weight = 7.0;
		}

		public PlateLegs(Serial serial) : base(serial)
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

	/// PlateHaidate(Legs)
	public class PlateHaidate : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 80;
		public override int OldStrReq => 80;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateHaidate() : base(0x278D)
		{
			Weight = 7.0;
		}

		public PlateHaidate(Serial serial) : base(serial)
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

	/// PlateSuneate(Legs)
	public class PlateSuneate : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 80;
		public override int OldStrReq => 80;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateSuneate() : base(0x2788)
		{
			Weight = 7.0;
		}

		public PlateSuneate(Serial serial) : base(serial)
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

	/// WoodlandLegs
	[FlipableAttribute(0x2B6B, 0x3162)]
	public class WoodlandLegs : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 90;
		public override int OldStrReq => 90;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
		public override Race RequiredRace => Race.Elf;

		[Constructable]
		public WoodlandLegs() : base(0x2B6B)
		{
			Weight = 8.0;
		}

		public WoodlandLegs(Serial serial) : base(serial)
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

	#endregion

	#region Ringmail Legs

	/// RingmailLegs
	[FlipableAttribute(0x13f0, 0x13f1)]
	public class RingmailLegs : BaseArmor
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

		public override int OldDexBonus => -1;

		public override int ArmorBase => 22;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Ringmail;

		[Constructable]
		public RingmailLegs() : base(0x13F0)
		{
			Weight = 15.0;
		}

		public RingmailLegs(Serial serial) : base(serial)
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
}