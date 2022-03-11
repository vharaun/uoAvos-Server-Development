using Server.Engines.Harvest;

namespace Server.Items
{
	/// Axe
	[FlipableAttribute(0xF49, 0xF4a)]
	public class Axe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 14;
		public override int AosMaxDamage => 16;
		public override int AosSpeed => 37;
		public override float MlSpeed => 3.00f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 6;
		public override int OldMaxDamage => 33;
		public override int OldSpeed => 37;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		[Constructable]
		public Axe() : base(0xF49)
		{
			Weight = 4.0;
		}

		public Axe(Serial serial) : base(serial)
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

	/// BattleAxe
	[FlipableAttribute(0xF47, 0xF48)]
	public class BattleAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 15;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 31;
		public override float MlSpeed => 3.50f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 6;
		public override int OldMaxDamage => 38;
		public override int OldSpeed => 30;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		[Constructable]
		public BattleAxe() : base(0xF47)
		{
			Weight = 4.0;
			Layer = Layer.TwoHanded;
		}

		public BattleAxe(Serial serial) : base(serial)
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

	/// GuardianAxe
	public class GuardianAxe : OrnateAxe
	{
		public override int LabelNumber => 1073545;  // guardian axe

		[Constructable]
		public GuardianAxe()
		{
			Attributes.BonusHits = 4;
			Attributes.RegenHits = 1;
		}

		public GuardianAxe(Serial serial) : base(serial)
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

	/// DoubleAxe
	[FlipableAttribute(0xf4b, 0xf4c)]
	public class DoubleAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.WhirlwindAttack;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 15;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 33;
		public override float MlSpeed => 3.25f;

		public override int OldStrengthReq => 45;
		public override int OldMinDamage => 5;
		public override int OldMaxDamage => 35;
		public override int OldSpeed => 37;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 110;

		[Constructable]
		public DoubleAxe() : base(0xF4B)
		{
			Weight = 8.0;
		}

		public DoubleAxe(Serial serial) : base(serial)
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

	/// ExecutionersAxe
	[FlipableAttribute(0xf45, 0xf46)]
	public class ExecutionersAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 15;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 33;
		public override float MlSpeed => 3.25f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 6;
		public override int OldMaxDamage => 33;
		public override int OldSpeed => 37;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		[Constructable]
		public ExecutionersAxe() : base(0xF45)
		{
			Weight = 8.0;
		}

		public ExecutionersAxe(Serial serial) : base(serial)
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

	/// HeavyOrnateAxe
	public class HeavyOrnateAxe : OrnateAxe
	{
		public override int LabelNumber => 1073548;  // heavy ornate axe

		[Constructable]
		public HeavyOrnateAxe()
		{
			Attributes.WeaponDamage = 8;
		}

		public HeavyOrnateAxe(Serial serial) : base(serial)
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

	/// LargeBattleAxe
	[FlipableAttribute(0x13FB, 0x13FA)]
	public class LargeBattleAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.BleedAttack;

		public override int AosStrengthReq => 80;
		public override int AosMinDamage => 16;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 29;
		public override float MlSpeed => 3.75f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 6;
		public override int OldMaxDamage => 38;
		public override int OldSpeed => 30;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		[Constructable]
		public LargeBattleAxe() : base(0x13FB)
		{
			Weight = 6.0;
		}

		public LargeBattleAxe(Serial serial) : base(serial)
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

	/// OrnateAxe
	[FlipableAttribute(0x2D28, 0x2D34)]
	public class OrnateAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Disarm;
		public override WeaponAbility SecondaryAbility => WeaponAbility.CrushingBlow;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 18;
		public override int AosMaxDamage => 20;
		public override int AosSpeed => 26;
		public override float MlSpeed => 3.50f;

		public override int OldStrengthReq => 45;
		public override int OldMinDamage => 18;
		public override int OldMaxDamage => 20;
		public override int OldSpeed => 26;

		public override int DefMissSound => 0x239;

		public override int InitMinHits => 30;
		public override int InitMaxHits => 60;

		[Constructable]
		public OrnateAxe() : base(0x2D28)
		{
			Weight = 12.0;
			Layer = Layer.TwoHanded;
		}

		public OrnateAxe(Serial serial) : base(serial)
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

	/// SingingAxe
	public class SingingAxe : OrnateAxe
	{
		public override int LabelNumber => 1073546;  // singing axe

		[Constructable]
		public SingingAxe()
		{
			SkillBonuses.SetValues(0, SkillName.Musicianship, 5);
		}

		public SingingAxe(Serial serial) : base(serial)
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

	/// ThunderingAxe
	public class ThunderingAxe : OrnateAxe
	{
		public override int LabelNumber => 1073547;  // thundering axe

		[Constructable]
		public ThunderingAxe()
		{
			WeaponAttributes.HitLightning = 10;
		}

		public ThunderingAxe(Serial serial) : base(serial)
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

	/// TwoHandedAxe
	[FlipableAttribute(0x1443, 0x1442)]
	public class TwoHandedAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ShadowStrike;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 16;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 31;
		public override float MlSpeed => 3.50f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 5;
		public override int OldMaxDamage => 39;
		public override int OldSpeed => 30;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;

		[Constructable]
		public TwoHandedAxe() : base(0x1443)
		{
			Weight = 8.0;
		}

		public TwoHandedAxe(Serial serial) : base(serial)
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

	/// WarAxe
	[FlipableAttribute(0x13B0, 0x13AF)]
	public class WarAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.BleedAttack;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 14;
		public override int AosMaxDamage => 15;
		public override int AosSpeed => 33;
		public override float MlSpeed => 3.25f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 9;
		public override int OldMaxDamage => 27;
		public override int OldSpeed => 40;

		public override int DefHitSound => 0x233;
		public override int DefMissSound => 0x239;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

		public override SkillName DefSkill => SkillName.Macing;
		public override WeaponType DefType => WeaponType.Bashing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Bash1H;

		public override HarvestSystem HarvestSystem => null;

		[Constructable]
		public WarAxe() : base(0x13B0)
		{
			Weight = 8.0;
		}

		public WarAxe(Serial serial) : base(serial)
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