
using System;

namespace Server.Items
{
	#region Bone Gloves

	/// BoneGloves
	[FlipableAttribute(0x1450, 0x1455)]
	public class BoneGloves : BaseArmor
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

		public override int OldDexBonus => -1;

		public override int ArmorBase => 30;
		public override int RevertArmorBase => 2;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		[Constructable]
		public BoneGloves() : base(0x1450)
		{
			Weight = 2.0;
		}

		public BoneGloves(Serial serial) : base(serial)
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

	/// DaemonGloves
	[FlipableAttribute(0x1450, 0x1455)]
	public class DaemonGloves : BaseArmor
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

		public override int OldDexBonus => -1;

		public override int ArmorBase => 46;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Bone;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override int LabelNumber => 1041373;  // daemon bone gloves

		[Constructable]
		public DaemonGloves() : base(0x1450)
		{
			Weight = 2.0;
			Hue = 0x648;

			ArmorAttributes.SelfRepair = 1;
		}

		public DaemonGloves(Serial serial) : base(serial)
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

			if (ArmorAttributes.SelfRepair == 0)
			{
				ArmorAttributes.SelfRepair = 1;
			}
		}
	}

	#endregion

	#region Cloth Gloves

	/// LeatherNinjaMitts
	public class LeatherNinjaMitts : BaseArmor
	{
		public override int BasePhysicalResistance => 2;
		public override int BaseFireResistance => 4;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 25;
		public override int InitMaxHits => 25;

		public override int AosStrReq => 10;
		public override int OldStrReq => 10;

		public override int ArmorBase => 3;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;
		public override CraftResource DefaultResource => CraftResource.RegularLeather;

		public override ArmorMeditationAllowance DefMedAllowance => ArmorMeditationAllowance.All;

		[Constructable]
		public LeatherNinjaMitts() : base(0x2792)
		{
			Weight = 2.0;
		}

		public LeatherNinjaMitts(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(2);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						if (reader.ReadBool())
						{
							reader.ReadInt();
							reader.ReadInt();
						}

						Weight = 2.0;
						ItemID = 0x2792;

						break;
					}
			}
		}
	}

	#endregion

	#region Dragon Gloves

	/// DragonGloves
	[FlipableAttribute(0x2643, 0x2644)]
	public class DragonGloves : BaseArmor
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 3;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 3;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 75;

		public override int AosStrReq => 75;
		public override int OldStrReq => 30;

		public override int OldDexBonus => -2;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Dragon;
		public override CraftResource DefaultResource => CraftResource.RedScales;

		[Constructable]
		public DragonGloves() : base(0x2643)
		{
			Weight = 2.0;
		}

		public DragonGloves(Serial serial) : base(serial)
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

	#endregion

	#region Leather Gloves

	/// LeatherGloves
	[Flipable]
	public class LeatherGloves : BaseArmor, IArcaneEquip
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
		public LeatherGloves() : base(0x13C6)
		{
			Weight = 1.0;
		}

		public LeatherGloves(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version

			if (IsArcane)
			{
				writer.Write(true);
				writer.Write(m_CurArcaneCharges);
				writer.Write(m_MaxArcaneCharges);
			}
			else
			{
				writer.Write(false);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						if (reader.ReadBool())
						{
							m_CurArcaneCharges = reader.ReadInt();
							m_MaxArcaneCharges = reader.ReadInt();

							if (Hue == 2118)
							{
								Hue = ArcaneGem.DefaultArcaneHue;
							}
						}

						break;
					}
			}
		}

		#region Arcane Impl
		private int m_MaxArcaneCharges, m_CurArcaneCharges;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxArcaneCharges
		{
			get => m_MaxArcaneCharges;
			set { m_MaxArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int CurArcaneCharges
		{
			get => m_CurArcaneCharges;
			set { m_CurArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsArcane => (m_MaxArcaneCharges > 0 && m_CurArcaneCharges >= 0);

		public void Update()
		{
			if (IsArcane)
			{
				ItemID = 0x26B0;
			}
			else if (ItemID == 0x26B0)
			{
				ItemID = 0x13C6;
			}

			if (IsArcane && CurArcaneCharges == 0)
			{
				Hue = 0;
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (IsArcane)
			{
				list.Add(1061837, "{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges); // arcane charges: ~1_val~ / ~2_val~
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (IsArcane)
			{
				LabelTo(from, 1061837, String.Format("{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges));
			}
		}

		public void Flip()
		{
			if (ItemID == 0x13C6)
			{
				ItemID = 0x13CE;
			}
			else if (ItemID == 0x13CE)
			{
				ItemID = 0x13C6;
			}
		}
		#endregion
	}

	/// HideGloves
	[FlipableAttribute(0x2B75, 0x316C)]
	public class HideGloves : BaseArmor
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
		public HideGloves() : base(0x2B75)
		{
			Weight = 2.0;
		}

		public HideGloves(Serial serial) : base(serial)
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

	/// LeafGloves
	[Flipable]
	public class LeafGloves : BaseArmor, IArcaneEquip
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
		public LeafGloves() : base(0x2FC6)
		{
			Weight = 2.0;
		}

		public LeafGloves(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version

			if (IsArcane)
			{
				writer.Write(true);
				writer.Write(m_CurArcaneCharges);
				writer.Write(m_MaxArcaneCharges);
			}
			else
			{
				writer.Write(false);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			switch (version)
			{
				case 0:
					{
						if (reader.ReadBool())
						{
							m_CurArcaneCharges = reader.ReadInt();
							m_MaxArcaneCharges = reader.ReadInt();

							if (Hue == 2118)
							{
								Hue = ArcaneGem.DefaultArcaneHue;
							}
						}

						break;
					}
			}
		}

		#region Arcane Impl
		private int m_MaxArcaneCharges, m_CurArcaneCharges;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxArcaneCharges
		{
			get => m_MaxArcaneCharges;
			set { m_MaxArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int CurArcaneCharges
		{
			get => m_CurArcaneCharges;
			set { m_CurArcaneCharges = value; InvalidateProperties(); Update(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsArcane => (m_MaxArcaneCharges > 0 && m_CurArcaneCharges >= 0);

		public void Update()
		{
			if (IsArcane)
			{
				ItemID = 0x26B0; // TODO: Check
			}
			else if (ItemID == 0x26B0)
			{
				ItemID = 0x2FC6;
			}

			if (IsArcane && CurArcaneCharges == 0)
			{
				Hue = 0;
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (IsArcane)
			{
				list.Add(1061837, "{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges); // arcane charges: ~1_val~ / ~2_val~
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (IsArcane)
			{
				LabelTo(from, 1061837, String.Format("{0}\t{1}", m_CurArcaneCharges, m_MaxArcaneCharges));
			}
		}

		public void Flip()
		{
			if (ItemID == 0x2FC6)
			{
				ItemID = 0x317C;
			}
			else if (ItemID == 0x317C)
			{
				ItemID = 0x2FC6;
			}
		}
		#endregion
	}

	/// StuddedGloves
	[FlipableAttribute(0x13d5, 0x13dd)]
	public class StuddedGloves : BaseArmor
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
		public StuddedGloves() : base(0x13D5)
		{
			Weight = 1.0;
		}

		public StuddedGloves(Serial serial) : base(serial)
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

	#endregion

	#region Platemail Gloves

	/// PlateGloves
	[FlipableAttribute(0x1414, 0x1418)]
	public class PlateGloves : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 70;
		public override int OldStrReq => 30;

		public override int OldDexBonus => -2;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;

		[Constructable]
		public PlateGloves() : base(0x1414)
		{
			Weight = 2.0;
		}

		public PlateGloves(Serial serial) : base(serial)
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

	/// WoodlandGloves
	[FlipableAttribute(0x2B6A, 0x3161)]
	public class WoodlandGloves : BaseArmor
	{
		public override int BasePhysicalResistance => 5;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;

		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;

		public override int AosStrReq => 70;
		public override int OldStrReq => 70;

		public override int ArmorBase => 40;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Plate;
		public override Race RequiredRace => Race.Elf;

		[Constructable]
		public WoodlandGloves() : base(0x2B6A)
		{
			Weight = 2.0;
		}

		public WoodlandGloves(Serial serial) : base(serial)
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

	#region Ringmail Gloves

	/// RingmailGloves
	[FlipableAttribute(0x13eb, 0x13f2)]
	public class RingmailGloves : BaseArmor
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
		public RingmailGloves() : base(0x13EB)
		{
			Weight = 2.0;
		}

		public RingmailGloves(Serial serial) : base(serial)
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

	#endregion
}