namespace Server.Items
{
	/// AncientWildStaff
	public class AncientWildStaff : WildStaff
	{
		public override int LabelNumber => 1073550;  // ancient wild staff

		[Constructable]
		public AncientWildStaff()
		{
			WeaponAttributes.ResistPoisonBonus = 5;
		}

		public AncientWildStaff(Serial serial) : base(serial)
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

	/// ArcanistsWildStaff
	public class ArcanistsWildStaff : WildStaff
	{
		public override int LabelNumber => 1073549;  // arcanist's wild staff

		[Constructable]
		public ArcanistsWildStaff()
		{
			Attributes.BonusMana = 3;
			Attributes.WeaponDamage = 3;
		}

		public ArcanistsWildStaff(Serial serial) : base(serial)
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

	/// BlackStaff
	[FlipableAttribute(0xDF1, 0xDF0)]
	public class BlackStaff : BaseStaff
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 13;
		public override int AosMaxDamage => 16;
		public override int AosSpeed => 39;
		public override float MlSpeed => 2.75f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 8;
		public override int OldMaxDamage => 33;
		public override int OldSpeed => 35;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		[Constructable]
		public BlackStaff() : base(0xDF0)
		{
			Weight = 6.0;
		}

		public BlackStaff(Serial serial) : base(serial)
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

	/// GlacialStaff
	public class GlacialStaff : BlackStaff
	{
		//TODO: Pre-AoS stuff
		public override int LabelNumber => 1017413;  // Glacial Staff

		[Constructable]
		public GlacialStaff()
		{
			Hue = 0x480;
			WeaponAttributes.HitHarm = 5 * Utility.RandomMinMax(1, 5);
			WeaponAttributes.MageWeapon = Utility.RandomMinMax(5, 10);

			AosElementDamages[AosElementAttribute.Cold] = 20 + (5 * Utility.RandomMinMax(0, 6));

		}

		public GlacialStaff(Serial serial) : base(serial)
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

	/// GnarledStaff
	[FlipableAttribute(0x13F8, 0x13F9)]
	public class GnarledStaff : BaseStaff
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;

		public override int AosStrengthReq => 20;
		public override int AosMinDamage => 15;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 33;
		public override float MlSpeed => 3.25f;

		public override int OldStrengthReq => 20;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 30;
		public override int OldSpeed => 33;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 50;

		[Constructable]
		public GnarledStaff() : base(0x13F8)
		{
			Weight = 3.0;
		}

		public GnarledStaff(Serial serial) : base(serial)
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

	/// HardenedWildStaff
	public class HardenedWildStaff : WildStaff
	{
		public override int LabelNumber => 1073552;  // hardened wild staff

		[Constructable]
		public HardenedWildStaff()
		{
			Attributes.WeaponDamage = 5;
		}

		public HardenedWildStaff(Serial serial) : base(serial)
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

	/// ThornedWildStaff
	public class ThornedWildStaff : WildStaff
	{
		public override int LabelNumber => 1073551;  // thorned wild staff

		[Constructable]
		public ThornedWildStaff()
		{
			Attributes.ReflectPhysical = 12;
		}

		public ThornedWildStaff(Serial serial) : base(serial)
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

	/// QuarterStaff
	[FlipableAttribute(0xE89, 0xE8a)]
	public class QuarterStaff : BaseStaff
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;

		public override int AosStrengthReq => 30;
		public override int AosMinDamage => 11;
		public override int AosMaxDamage => 14;
		public override int AosSpeed => 48;
		public override float MlSpeed => 2.25f;

		public override int OldStrengthReq => 30;
		public override int OldMinDamage => 8;
		public override int OldMaxDamage => 28;
		public override int OldSpeed => 48;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 60;

		[Constructable]
		public QuarterStaff() : base(0xE89)
		{
			Weight = 4.0;
		}

		public QuarterStaff(Serial serial) : base(serial)
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

	/// WildStaff
	[FlipableAttribute(0x2D25, 0x2D31)]
	public class WildStaff : BaseStaff
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Block;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ForceOfNature;

		public override int AosStrengthReq => 15;
		public override int AosMinDamage => 10;
		public override int AosMaxDamage => 12;
		public override int AosSpeed => 48;
		public override float MlSpeed => 2.25f;

		public override int OldStrengthReq => 15;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 12;
		public override int OldSpeed => 48;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 60;

		[Constructable]
		public WildStaff() : base(0x2D25)
		{
			Weight = 8.0;
		}

		public WildStaff(Serial serial) : base(serial)
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
}