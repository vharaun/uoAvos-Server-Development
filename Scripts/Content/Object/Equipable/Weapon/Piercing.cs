namespace Server.Items
{
	/// BladedStaff
	[FlipableAttribute(0x26BD, 0x26C7)]
	public class BladedStaff : BaseSpear
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 14;
		public override int AosMaxDamage => 16;
		public override int AosSpeed => 37;
		public override float MlSpeed => 3.00f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 14;
		public override int OldMaxDamage => 16;
		public override int OldSpeed => 37;

		public override int InitMinHits => 21;
		public override int InitMaxHits => 110;

		public override SkillName DefSkill => SkillName.Swords;

		[Constructable]
		public BladedStaff() : base(0x26BD)
		{
			Weight = 4.0;
		}

		public BladedStaff(Serial serial) : base(serial)
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

	/// DoubleBladedStaff
	[FlipableAttribute(0x26BF, 0x26C9)]
	public class DoubleBladedStaff : BaseSpear
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;

		public override int AosStrengthReq => 50;
		public override int AosMinDamage => 12;
		public override int AosMaxDamage => 13;
		public override int AosSpeed => 49;
		public override float MlSpeed => 2.25f;

		public override int OldStrengthReq => 50;
		public override int OldMinDamage => 12;
		public override int OldMaxDamage => 13;
		public override int OldSpeed => 49;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

		[Constructable]
		public DoubleBladedStaff() : base(0x26BF)
		{
			Weight = 2.0;
		}

		public DoubleBladedStaff(Serial serial) : base(serial)
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

	/// Pike
	[FlipableAttribute(0x26BE, 0x26C8)]
	public class Pike : BaseSpear
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;

		public override int AosStrengthReq => 50;
		public override int AosMinDamage => 14;
		public override int AosMaxDamage => 16;
		public override int AosSpeed => 37;
		public override float MlSpeed => 3.00f;

		public override int OldStrengthReq => 50;
		public override int OldMinDamage => 14;
		public override int OldMaxDamage => 16;
		public override int OldSpeed => 37;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		[Constructable]
		public Pike() : base(0x26BE)
		{
			Weight = 8.0;
		}

		public Pike(Serial serial) : base(serial)
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

	/// ShortSpear
	[FlipableAttribute(0x1403, 0x1402)]
	public class ShortSpear : BaseSpear
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ShadowStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 10;
		public override int AosMaxDamage => 13;
		public override int AosSpeed => 55;
		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 15;
		public override int OldMinDamage => 4;
		public override int OldMaxDamage => 32;
		public override int OldSpeed => 50;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public ShortSpear() : base(0x1403)
		{
			Weight = 4.0;
		}

		public ShortSpear(Serial serial) : base(serial)
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

	/// Spear
	[FlipableAttribute(0xF62, 0xF63)]
	public class Spear : BaseSpear
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;

		public override int AosStrengthReq => 50;
		public override int AosMinDamage => 13;
		public override int AosMaxDamage => 15;
		public override int AosSpeed => 42;
		public override float MlSpeed => 2.75f;

		public override int OldStrengthReq => 30;
		public override int OldMinDamage => 2;
		public override int OldMaxDamage => 36;
		public override int OldSpeed => 46;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

		[Constructable]
		public Spear() : base(0xF62)
		{
			Weight = 7.0;
		}

		public Spear(Serial serial) : base(serial)
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

	/// TribalSpear
	[FlipableAttribute(0xF62, 0xF63)]
	public class TribalSpear : BaseSpear
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;

		public override int AosStrengthReq => 50;
		public override int AosMinDamage => 13;
		public override int AosMaxDamage => 15;
		public override int AosSpeed => 42;
		public override float MlSpeed => 2.75f;

		public override int OldStrengthReq => 30;
		public override int OldMinDamage => 2;
		public override int OldMaxDamage => 36;
		public override int OldSpeed => 46;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

		public override int VirtualDamageBonus => 25;

		public override string DefaultName => "a tribal spear";

		[Constructable]
		public TribalSpear() : base(0xF62)
		{
			Weight = 7.0;
			Hue = 837;
		}

		public TribalSpear(Serial serial) : base(serial)
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

	/// WarFork
	[FlipableAttribute(0x1405, 0x1404)]
	public class WarFork : BaseSpear
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 12;
		public override int AosMaxDamage => 13;
		public override int AosSpeed => 43;
		public override float MlSpeed => 2.50f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 4;
		public override int OldMaxDamage => 32;
		public override int OldSpeed => 45;

		public override int DefHitSound => 0x236;
		public override int DefMissSound => 0x238;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public WarFork() : base(0x1405)
		{
			Weight = 9.0;
		}

		public WarFork(Serial serial) : base(serial)
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