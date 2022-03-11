namespace Server.Items
{
	#region Bone Arms

	/// BoneArms
	[FlipableAttribute(0x144e, 0x1453)]
	public class BoneArms : BaseArmor
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

		public override int OldDexBonus => -2;

		public override int ArmorBase => 30;
		public override int RevertArmorBase => 4;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public BoneArms() : base(0x144E)
		{
			Weight = 2.0;
		}

		public BoneArms(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			if (Weight == 1.0)
			{
				Weight = 2.0;
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// DaemonArms
	[FlipableAttribute(0x144e, 0x1453)]
	public class DaemonArms : BaseArmor
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

		public override int OldDexBonus => -2;

		public override int ArmorBase => 46;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041371;  // daemon bone arms

		[Constructable]
		public DaemonArms() : base(0x144E)
		{
			Weight = 2.0;
			Hue = 0x648;

			ArmorAttributes.SelfRepair = 1;
		}

		public DaemonArms(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			if (Weight == 1.0)
			{
				Weight = 2.0;
			}
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

	#region Dragon Arms

	[FlipableAttribute(0x2657, 0x2658)]
	public class DragonArms : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 75;
		public override int OldStrReq => 20;

		public override int OldDexBonus => -2;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Dragon;
		public override CraftResource DefaultResource => CraftResource.RedScales;

		[Constructable]
		public DragonArms() : base(0x2657)
		{
			Weight = 5.0;
		}

		public DragonArms(Serial serial) : base(serial)
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

	#region Leather Arms

	/// LeatherArms
	[FlipableAttribute(0x13cd, 0x13c5)]
	public class LeatherArms : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherArms() : base(0x13CD)
		{
			Weight = 2.0;
		}

		public LeatherArms(Serial serial) : base(serial)
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
				Weight = 2.0;
			}
		}
	}

	/// LeatherBustierArms
	[FlipableAttribute(0x1c0a, 0x1c0b)]
	public class LeatherBustierArms : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 20;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		public override bool AllowMaleWearer => false;

		[Constructable]
		public LeatherBustierArms() : base(0x1C0A)
		{
			Weight = 1.0;
		}

		public LeatherBustierArms(Serial serial) : base(serial)
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

	/// LeatherHiroSode
	public class LeatherHiroSode : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherHiroSode() : base(0x277E)
		{
			Weight = 1.0;
		}

		public LeatherHiroSode(Serial serial) : base(serial)
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

	/// LeafArms
	[FlipableAttribute(0x2FC8, 0x317E)]
	public class LeafArms : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 15;
		public override int OldStrReq => 15;

		public override int ArmorBase => 13;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeafArms() : base(0x2FC8)
		{
			Weight = 2.0;
		}

		public LeafArms(Serial serial) : base(serial)
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

	/// HidePauldrons(Arms)
	[FlipableAttribute(0x2B77, 0x316E)]
	public class HidePauldrons : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 20;
		public override int OldStrReq => 20;

		public override int ArmorBase => 15;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public HidePauldrons() : base(0x2B77)
		{
			Weight = 4.0;
		}

		public HidePauldrons(Serial serial) : base(serial)
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

	/// StuddedArms
	[FlipableAttribute(0x13dc, 0x13d4)]
	public class StuddedArms : BaseArmor
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

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public StuddedArms() : base(0x13DC)
		{
			Weight = 4.0;
		}

		public StuddedArms(Serial serial) : base(serial)
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

	/// StuddedBustierArms
	[FlipableAttribute(0x1c0c, 0x1c0d)]
	public class StuddedBustierArms : BaseArmor
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
		public StuddedBustierArms() : base(0x1C0C)
		{
			Weight = 1.0;
		}

		public StuddedBustierArms(Serial serial) : base(serial)
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

	/// StuddedHiroSode
	public class StuddedHiroSode : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 55;

		public override int AosStrReq => 30;
		public override int OldStrReq => 30;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public StuddedHiroSode() : base(0x277F)
		{
			Weight = 1.0;
		}

		public StuddedHiroSode(Serial serial) : base(serial)
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

	#region Platemail Arms

	/// PlateArms
	[FlipableAttribute(0x1410, 0x1417)]
	public class PlateArms : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 80;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -2;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateArms() : base(0x1410)
		{
			Weight = 5.0;
		}

		public PlateArms(Serial serial) : base(serial)
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
				Weight = 5.0;
			}
		}
	}

	/// PlateHiroSode
	public class PlateHiroSode : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 75;
		public override int OldStrReq => 75;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateHiroSode() : base(0x2780)
		{
			Weight = 3.0;
		}

		public PlateHiroSode(Serial serial) : base(serial)
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

	/// WoodlandArms
	[FlipableAttribute(0x2B6C, 0x3163)]
	public class WoodlandArms : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 80;
		public override int OldStrReq => 80;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
		public override Race RequiredRace => Race.Elf;

		[Constructable]
		public WoodlandArms() : base(0x2B6C)
		{
			Weight = 5.0;
		}

		public WoodlandArms(Serial serial) : base(serial)
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

	#region Ringmail Arms

	/// RingmailArms
	[FlipableAttribute(0x13ee, 0x13ef)]
	public class RingmailArms : BaseArmor
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
		public RingmailArms() : base(0x13EE)
		{
			Weight = 15.0;
		}

		public RingmailArms(Serial serial) : base(serial)
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