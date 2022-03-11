namespace Server.Items
{
	/// Club
	[FlipableAttribute(0x13b4, 0x13b3)]
	public class Club : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ShadowStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 11;
		public override int AosMaxDamage => 13;
		public override int AosSpeed => 44;
		public override float MlSpeed => 2.50f;

		public override int OldStrengthReq => 10;
		public override int OldMinDamage => 8;
		public override int OldMaxDamage => 24;
		public override int OldSpeed => 40;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 40;

		[Constructable]
		public Club() : base(0x13B4)
		{
			Weight = 9.0;
		}

		public Club(Serial serial) : base(serial)
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

	/// DiamondMace
	[FlipableAttribute(0x2D24, 0x2D30)]
	public class DiamondMace : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 14;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 37;
		public override float MlSpeed => 3.00f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 14;
		public override int OldMaxDamage => 17;
		public override int OldSpeed => 37;

		public override int InitMinHits => 30;  // TODO
		public override int InitMaxHits => 60;  // TODO

		[Constructable]
		public DiamondMace() : base(0x2D24)
		{
			Weight = 10.0;
		}

		public DiamondMace(Serial serial) : base(serial)
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

	/// EmeraldMace
	public class EmeraldMace : DiamondMace
	{
		public override int LabelNumber => 1073530;  // emerald mace

		[Constructable]
		public EmeraldMace()
		{
			WeaponAttributes.ResistPoisonBonus = 5;
		}

		public EmeraldMace(Serial serial) : base(serial)
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

	/// HammerPick
	[FlipableAttribute(0x143D, 0x143C)]
	public class HammerPick : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 15;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 28;
		public override float MlSpeed => 3.75f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 6;
		public override int OldMaxDamage => 33;
		public override int OldSpeed => 30;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		[Constructable]
		public HammerPick() : base(0x143D)
		{
			Weight = 9.0;
			Layer = Layer.OneHanded;
		}

		public HammerPick(Serial serial) : base(serial)
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

	/// Mace
	[FlipableAttribute(0xF5C, 0xF5D)]
	public class Mace : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 12;
		public override int AosMaxDamage => 14;
		public override int AosSpeed => 40;
		public override float MlSpeed => 2.75f;

		public override int OldStrengthReq => 20;
		public override int OldMinDamage => 8;
		public override int OldMaxDamage => 32;
		public override int OldSpeed => 30;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		[Constructable]
		public Mace() : base(0xF5C)
		{
			Weight = 14.0;
		}

		public Mace(Serial serial) : base(serial)
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

	/// Maul
	[FlipableAttribute(0x143B, 0x143A)]
	public class Maul : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 14;
		public override int AosMaxDamage => 16;
		public override int AosSpeed => 32;
		public override float MlSpeed => 3.50f;

		public override int OldStrengthReq => 20;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 30;
		public override int OldSpeed => 30;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		[Constructable]
		public Maul() : base(0x143B)
		{
			Weight = 10.0;
		}

		public Maul(Serial serial) : base(serial)
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

			if (Weight == 14.0)
			{
				Weight = 10.0;
			}
		}
	}

	/// Nunchaku
	[FlipableAttribute(0x27AE, 0x27F9)]
	public class Nunchaku : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Block;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Feint;

		public override int AosStrengthReq => 15;
		public override int AosMinDamage => 11;
		public override int AosMaxDamage => 13;
		public override int AosSpeed => 47;
		public override float MlSpeed => 2.50f;

		public override int OldStrengthReq => 15;
		public override int OldMinDamage => 11;
		public override int OldMaxDamage => 13;
		public override int OldSpeed => 47;

		public override int DefHitSound => 0x535;
		public override int DefMissSound => 0x239;

		public override int InitMinHits => 40;
		public override int InitMaxHits => 55;

		[Constructable]
		public Nunchaku() : base(0x27AE)
		{
			Weight = 5.0;
		}

		public Nunchaku(Serial serial) : base(serial)
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

	/// RubyMace
	public class RubyMace : DiamondMace
	{
		public override int LabelNumber => 1073529;  // ruby mace

		[Constructable]
		public RubyMace()
		{
			Attributes.WeaponDamage = 5;
		}

		public RubyMace(Serial serial) : base(serial)
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

	/// SapphireMace
	public class SapphireMace : DiamondMace
	{
		public override int LabelNumber => 1073531;  // sapphire mace

		[Constructable]
		public SapphireMace()
		{
			WeaponAttributes.ResistEnergyBonus = 5;
		}

		public SapphireMace(Serial serial) : base(serial)
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

	/// Scepter
	[FlipableAttribute(0x26BC, 0x26C6)]
	public class Scepter : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 14;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 30;
		public override float MlSpeed => 3.50f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 14;
		public override int OldMaxDamage => 17;
		public override int OldSpeed => 30;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		[Constructable]
		public Scepter() : base(0x26BC)
		{
			Weight = 8.0;
		}

		public Scepter(Serial serial) : base(serial)
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

	/// SilverEtchedMace
	public class SilverEtchedMace : DiamondMace
	{
		public override int LabelNumber => 1073532;  // silver-etched mace

		[Constructable]
		public SilverEtchedMace()
		{
			Slayer = SlayerName.Exorcism;
		}

		public SilverEtchedMace(Serial serial) : base(serial)
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

	/// Tetsubo
	[FlipableAttribute(0x27A6, 0x27F1)]
	public class Tetsubo : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.FrenziedWhirlwind;
		public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 12;
		public override int AosMaxDamage => 14;
		public override int AosSpeed => 45;
		public override float MlSpeed => 2.50f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 12;
		public override int OldMaxDamage => 14;
		public override int OldSpeed => 45;

		public override int DefHitSound => 0x233;
		public override int DefMissSound => 0x238;

		public override int InitMinHits => 60;
		public override int InitMaxHits => 65;

		public override WeaponAnimation DefAnimation => WeaponAnimation.Bash2H;

		[Constructable]
		public Tetsubo() : base(0x27A6)
		{
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public Tetsubo(Serial serial) : base(serial)
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

	/// WarHammer
	[FlipableAttribute(0x1439, 0x1438)]
	public class WarHammer : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;

		public override int AosStrengthReq => 95;
		public override int AosMinDamage => 17;
		public override int AosMaxDamage => 18;
		public override int AosSpeed => 28;
		public override float MlSpeed => 3.75f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 8;
		public override int OldMaxDamage => 36;
		public override int OldSpeed => 31;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		public override WeaponAnimation DefAnimation => WeaponAnimation.Bash2H;

		[Constructable]
		public WarHammer() : base(0x1439)
		{
			Weight = 10.0;
			Layer = Layer.TwoHanded;
		}

		public WarHammer(Serial serial) : base(serial)
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

	/// WarMace
	[FlipableAttribute(0x1407, 0x1406)]
	public class WarMace : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 80;
		public override int AosMinDamage => 16;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 26;
		public override float MlSpeed => 4.00f;

		public override int OldStrengthReq => 30;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 30;
		public override int OldSpeed => 32;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		[Constructable]
		public WarMace() : base(0x1407)
		{
			Weight = 17.0;
		}

		public WarMace(Serial serial) : base(serial)
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