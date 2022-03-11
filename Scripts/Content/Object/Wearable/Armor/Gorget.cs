namespace Server.Items
{
	#region Leather Gorgets

	/// LeatherGorget
	public class LeatherGorget : BaseArmor
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
		public LeatherGorget() : base(0x13C7)
		{
			Weight = 1.0;
		}

		public LeatherGorget(Serial serial) : base(serial)
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

	/// HideGorget
	[FlipableAttribute(0x2B76, 0x316D)]
	public class HideGorget : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 15;
		public override int OldStrReq => 15;

		public override int ArmorBase => 15;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.Half;

		[Constructable]
		public HideGorget() : base(0x2B76)
		{
			Weight = 3.0;
		}

		public HideGorget(Serial serial) : base(serial)
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

			if (Weight == 2.0)
			{
				Weight = 1.0;
			}
		}
	}

	/// LeafGorget
	public class LeafGorget : BaseArmor
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
		public LeafGorget() : base(0x2FC7)
		{
			Weight = 2.0;
		}

		public LeafGorget(Serial serial) : base(serial)
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

	/// StuddedGorget
	public class StuddedGorget : BaseArmor
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
		public StuddedGorget() : base(0x13D6)
		{
			Weight = 1.0;
		}

		public StuddedGorget(Serial serial) : base(serial)
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

			if (Weight == 2.0)
			{
				Weight = 1.0;
			}
		}
	}

	/// LeatherMempo
	public class LeatherMempo : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 30;
		public override int OldStrReq => 30;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherMempo() : base(0x277A)
		{
			Weight = 2.0;
		}

		public LeatherMempo(Serial serial) : base(serial)
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

	/// StuddedMempo(Gorget)
	public class StuddedMempo : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 40;

		public override int AosStrReq => 30;
		public override int OldStrReq => 30;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Studded;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public StuddedMempo() : base(0x279D)
		{
			Weight = 2.0;
		}

		public StuddedMempo(Serial serial) : base(serial)
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

	#region Platemail Gorgets

	/// PlateGorget
	public class PlateGorget : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 45;
		public override int OldStrReq => 30;

		public override int OldDexBonus => -1;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateGorget() : base(0x1413)
		{
			Weight = 2.0;
		}

		public PlateGorget(Serial serial) : base(serial)
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

	/// WoodlandGorget
	[FlipableAttribute(0x2B69, 0x3160)]
	public class WoodlandGorget : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 45;
		public override int OldStrReq => 45;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
		public override Race RequiredRace => Race.Elf;

		[Constructable]
		public WoodlandGorget() : base(0x2B69)
		{
		}

		public WoodlandGorget(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			if (version == 0)
			{
				Weight = -1;
			}
		}
	}

	/// PlateMempo
	public class PlateMempo : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 60;
		public override int InitMaxHits => 70;

		public override int AosStrReq => 50;
		public override int OldStrReq => 50;

		public override int ArmorBase => 4;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateMempo() : base(0x2779)
		{
			Weight = 3.0;
		}

		public PlateMempo(Serial serial) : base(serial)
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