namespace Server.Items
{
	#region Bone Helmets

	/// BoneHelm
	[FlipableAttribute(0x1451, 0x1456)]
	public class BoneHelm : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 20;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public BoneHelm() : base(0x1451)
		{
			Weight = 3.0;
		}

		public BoneHelm(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);

			if (Weight == 1.0)
			{
				Weight = 3.0;
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	/// DaemonHelm
	[FlipableAttribute(0x1451, 0x1456)]
	public class DaemonHelm : BaseArmor
	{
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 6;
		public override int BaseColdResistance => 7;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 7;

		public override int InitMinHits => 255;
		public override int InitMaxHits => 255;

		public override int AosStrReq => 20;
		public override int OldStrReq => 40;

		public override int ArmorBase => 46;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041374;  // daemon bone helmet

		[Constructable]
		public DaemonHelm() : base(0x1451)
		{
			Hue = 0x648;
			Weight = 3.0;

			ArmorAttributes.SelfRepair = 1;
		}

		public DaemonHelm(Serial serial) : base(serial)
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
				Weight = 3.0;
			}

			if (ArmorAttributes.SelfRepair == 0)
			{
				ArmorAttributes.SelfRepair = 1;
			}
		}
	}

	/// OrcHelm
	public class OrcHelm : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 30;
		public override int OldStrReq => 10;

		public override int ArmorBase => 20;

		public override double DefaultWeight => 5;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.None;

		[Constructable]
		public OrcHelm() : base(0x1F0B)
		{
		}

		public OrcHelm(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			if (version == 0 && (Weight == 1 || Weight == 5))
			{
				Weight = -1;
			}
		}
	}

	#endregion

	#region Cloth Helmets

	/// LeatherNinjaHood
	public class LeatherNinjaHood : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 45;

		public override int AosStrReq => 10;
		public override int OldStrReq => 10;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherNinjaHood() : base(0x278E)
		{
			Weight = 2.0;
		}

		public LeatherNinjaHood(Serial serial) : base(serial)
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

	#region Chainmail Helmets         

	/// ChainCoif
	[FlipableAttribute(0x13BB, 0x13C0)]
	public class ChainCoif : BaseArmor
	{
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 1;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 60;
		public override int OldStrReq => 20;

		public override int ArmorBase => 28;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;

		[Constructable]
		public ChainCoif() : base(0x13BB)
		{
			Weight = 1.0;
		}

		public ChainCoif(Serial serial) : base(serial)
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

	/// ChainHatsuburi
	public class ChainHatsuburi : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 4;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 50;
		public override int OldStrReq => 50;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;

		[Constructable]
		public ChainHatsuburi() : base(0x2774)
		{
			Weight = 7.0;
		}

		public ChainHatsuburi(Serial serial) : base(serial)
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

	#region Dragon Helmets

	/// DragonHelm
	[Flipable(0x2645, 0x2646)]
	public class DragonHelm : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 75;
		public override int OldStrReq => 40;

		public override int OldDexBonus => -1;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Dragon;
		public override CraftResource DefaultResource => CraftResource.RedScales;

		[Constructable]
		public DragonHelm() : base(0x2645)
		{
			Weight = 5.0;
		}

		public DragonHelm(Serial serial) : base(serial)
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

	#endregion

	#region Leather Helmets

	/// LeatherCap
	[FlipableAttribute(0x1db9, 0x1dba)]
	public class LeatherCap : BaseArmor
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
		public LeatherCap() : base(0x1DB9)
		{
			Weight = 2.0;
		}

		public LeatherCap(Serial serial) : base(serial)
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

	/// LeatherJingasa
	public class LeatherJingasa : BaseArmor
	{
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherJingasa() : base(0x2776)
		{
			Weight = 3.0;
		}

		public LeatherJingasa(Serial serial) : base(serial)
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

	#region Platemail Helmets

	/// Bascinet
	public class Bascinet : BaseArmor
	{
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 40;
		public override int InitMaxHits => 50;

		public override int AosStrReq => 40;
		public override int OldStrReq => 10;

		public override int ArmorBase => 18;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public Bascinet() : base(0x140C)
		{
			Weight = 5.0;
		}

		public Bascinet(Serial serial) : base(serial)
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

	/// CloseHelm
	public class CloseHelm : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 55;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public CloseHelm() : base(0x1408)
		{
			Weight = 5.0;
		}

		public CloseHelm(Serial serial) : base(serial)
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

	/// Helmet
	public class Helmet : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 45;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public Helmet() : base(0x140A)
		{
			Weight = 5.0;
		}

		public Helmet(Serial serial) : base(serial)
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

	/// NorseHelm
	public class NorseHelm : BaseArmor
	{
		public override int BasePhysicalResistance => 4;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 4;
		public override int BasePoisonResistance => 4;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 55;
		public override int OldStrReq => 40;

		public override int ArmorBase => 30;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public NorseHelm() : base(0x140E)
		{
			Weight = 5.0;
		}

		public NorseHelm(Serial serial) : base(serial)
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

	/// PlateHelm
	public class PlateHelm : BaseArmor
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

		public override int OldDexBonus => -1;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateHelm() : base(0x1412)
		{
			Weight = 5.0;
		}

		public PlateHelm(Serial serial) : base(serial)
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

	/// PlateHatsuburi
	public class PlateHatsuburi : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 65;
		public override int OldStrReq => 65;

		public override int ArmorBase => 4;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateHatsuburi() : base(0x2775)
		{
			Weight = 5.0;
		}

		public PlateHatsuburi(Serial serial) : base(serial)
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

	/// SmallPlateJingasa
	public class SmallPlateJingasa : BaseArmor
	{
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 55;
		public override int OldStrReq => 55;

		public override int ArmorBase => 4;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public SmallPlateJingasa() : base(0x2784)
		{
			Weight = 5.0;
		}

		public SmallPlateJingasa(Serial serial) : base(serial)
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

	/// LightPlateJingasa
	public class LightPlateJingasa : BaseArmor
	{
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 60;

		public override int AosStrReq => 55;
		public override int OldStrReq => 55;

		public override int ArmorBase => 4;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public LightPlateJingasa() : base(0x2781)
		{
			Weight = 5.0;
		}

		public LightPlateJingasa(Serial serial) : base(serial)
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

	/// HeavyPlateJingasa
	public class HeavyPlateJingasa : BaseArmor
	{
		public override int BasePhysicalResistance => 7;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 70;

		public override int AosStrReq => 55;
		public override int OldStrReq => 55;

		public override int ArmorBase => 4;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public HeavyPlateJingasa() : base(0x2777)
		{
			Weight = 5.0;
		}

		public HeavyPlateJingasa(Serial serial) : base(serial)
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

	/// DecorativePlateKabuto
	public class DecorativePlateKabuto : BaseArmor
	{
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 70;
		public override int OldStrReq => 70;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public DecorativePlateKabuto() : base(0x2778)
		{
			Weight = 6.0;
		}

		public DecorativePlateKabuto(Serial serial) : base(serial)
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

	/// StandardPlateKabuto
	public class StandardPlateKabuto : BaseArmor
	{
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 60;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 70;
		public override int OldStrReq => 70;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public StandardPlateKabuto() : base(0x2789)
		{
			Weight = 6.0;
		}

		public StandardPlateKabuto(Serial serial) : base(serial)
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

	/// PlateBattleKabuto
	public class PlateBattleKabuto : BaseArmor
	{
		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 2;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 60;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 70;
		public override int OldStrReq => 70;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateBattleKabuto() : base(0x2785)
		{
			Weight = 6.0;
		}

		public PlateBattleKabuto(Serial serial) : base(serial)
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

	/// RavenHelm
	[FlipableAttribute(0x2B71, 0x3168)]
	public class RavenHelm : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public RavenHelm() : base(0x2B71)
		{
			Weight = 5.0;
		}

		public RavenHelm(Serial serial) : base(serial)
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

	/// VultureHelm
	[FlipableAttribute(0x2B72, 0x3169)]
	public class VultureHelm : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public VultureHelm() : base(0x2B72)
		{
			Weight = 5.0;
		}

		public VultureHelm(Serial serial) : base(serial)
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

	/// WingedHelm
	[FlipableAttribute(0x2B73, 0x316A)]
	public class WingedHelm : BaseArmor
	{
		public override Race RequiredRace => Race.Elf;

		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 1;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 2;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 45;
		public override int InitMaxHits => 55;

		public override int AosStrReq => 25;
		public override int OldStrReq => 25;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public WingedHelm() : base(0x2B73)
		{
			Weight = 5.0;
		}

		public WingedHelm(Serial serial) : base(serial)
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

	#endregion
}