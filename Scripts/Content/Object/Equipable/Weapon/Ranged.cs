
using System;

namespace Server.Items
{
	/// AssassinsShortbow
	public class AssassinsShortbow : MagicalShortbow
	{
		public override int LabelNumber => 1073512;  // assassin's shortbow

		[Constructable]
		public AssassinsShortbow()
		{
			Attributes.AttackChance = 3;
			Attributes.WeaponDamage = 4;
		}

		public AssassinsShortbow(Serial serial) : base(serial)
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

	/// BarbedLongbow
	public class BarbedLongbow : ElvenCompositeLongbow
	{
		public override int LabelNumber => 1073505;  // barbed longbow

		[Constructable]
		public BarbedLongbow()
		{
			Attributes.ReflectPhysical = 12;
		}

		public BarbedLongbow(Serial serial) : base(serial)
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

	/// Bow
	[FlipableAttribute(0x13B2, 0x13B1)]
	public class Bow : BaseRanged
	{
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();

		public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 30;
		public override int AosMinDamage => Core.ML ? 15 : 16;
		public override int AosMaxDamage => Core.ML ? 19 : 18;
		public override int AosSpeed => 25;
		public override float MlSpeed => 4.25f;

		public override int OldStrengthReq => 20;
		public override int OldMinDamage => 9;
		public override int OldMaxDamage => 41;
		public override int OldSpeed => 20;

		public override int DefMaxRange => 10;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 60;

		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
		public Bow() : base(0x13B2)
		{
			Weight = 6.0;
			Layer = Layer.TwoHanded;
		}

		public Bow(Serial serial) : base(serial)
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

			if (Weight == 7.0)
			{
				Weight = 6.0;
			}
		}
	}

	/// CompositeBow
	[FlipableAttribute(0x26C2, 0x26CC)]
	public class CompositeBow : BaseRanged
	{
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();

		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MovingShot;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => Core.ML ? 13 : 15;
		public override int AosMaxDamage => 17;
		public override int AosSpeed => 25;
		public override float MlSpeed => 4.00f;

		public override int OldStrengthReq => 45;
		public override int OldMinDamage => 15;
		public override int OldMaxDamage => 17;
		public override int OldSpeed => 25;

		public override int DefMaxRange => 10;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 70;

		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
		public CompositeBow() : base(0x26C2)
		{
			Weight = 5.0;
		}

		public CompositeBow(Serial serial) : base(serial)
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

	/// Crossbow
	[FlipableAttribute(0xF50, 0xF4F)]
	public class Crossbow : BaseRanged
	{
		public override int EffectID => 0x1BFE;
		public override Type AmmoType => typeof(Bolt);
		public override Item Ammo => new Bolt();

		public override WeaponAbility PrimaryAbility => WeaponAbility.ConcussionBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 18;
		public override int AosMaxDamage => Core.ML ? 22 : 20;
		public override int AosSpeed => 24;
		public override float MlSpeed => 4.50f;

		public override int OldStrengthReq => 30;
		public override int OldMinDamage => 8;
		public override int OldMaxDamage => 43;
		public override int OldSpeed => 18;

		public override int DefMaxRange => 8;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

		[Constructable]
		public Crossbow() : base(0xF50)
		{
			Weight = 7.0;
			Layer = Layer.TwoHanded;
		}

		public Crossbow(Serial serial) : base(serial)
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

	/// ElvenCompositeLongbow
	[FlipableAttribute(0x2D1E, 0x2D2A)]
	public class ElvenCompositeLongbow : BaseRanged
	{
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();

		public override WeaponAbility PrimaryAbility => WeaponAbility.ForceArrow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.SerpentArrow;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 12;
		public override int AosMaxDamage => 16;
		public override int AosSpeed => 27;
		public override float MlSpeed => 4.00f;

		public override int OldStrengthReq => 45;
		public override int OldMinDamage => 12;
		public override int OldMaxDamage => 16;
		public override int OldSpeed => 27;

		public override int DefMaxRange => 10;

		public override int InitMinHits => 41;
		public override int InitMaxHits => 90;

		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
		public ElvenCompositeLongbow() : base(0x2D1E)
		{
			Weight = 8.0;
		}

		public ElvenCompositeLongbow(Serial serial) : base(serial)
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

	/// FrozenLongbow
	public class FrozenLongbow : ElvenCompositeLongbow
	{
		public override int LabelNumber => 1073507;  // frozen longbow

		[Constructable]
		public FrozenLongbow()
		{
			Attributes.WeaponSpeed = -5;
			Attributes.DefendChance = 10;
		}

		public FrozenLongbow(Serial serial) : base(serial)
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

	/// HeavyCrossbow
	[FlipableAttribute(0x13FD, 0x13FC)]
	public class HeavyCrossbow : BaseRanged
	{
		public override int EffectID => 0x1BFE;
		public override Type AmmoType => typeof(Bolt);
		public override Item Ammo => new Bolt();

		public override WeaponAbility PrimaryAbility => WeaponAbility.MovingShot;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;

		public override int AosStrengthReq => 80;
		public override int AosMinDamage => Core.ML ? 20 : 19;
		public override int AosMaxDamage => Core.ML ? 24 : 20;
		public override int AosSpeed => 22;
		public override float MlSpeed => 5.00f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 11;
		public override int OldMaxDamage => 56;
		public override int OldSpeed => 10;

		public override int DefMaxRange => 8;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public HeavyCrossbow() : base(0x13FD)
		{
			Weight = 9.0;
			Layer = Layer.TwoHanded;
		}

		public HeavyCrossbow(Serial serial) : base(serial)
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

	/// JukaBow
	[FlipableAttribute(0x13B2, 0x13B1)]
	public class JukaBow : Bow
	{
		public override int AosStrengthReq => 80;
		public override int AosDexterityReq => 80;

		public override int OldStrengthReq => 80;
		public override int OldDexterityReq => 80;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsModified => (Hue == 0x453);

		[Constructable]
		public JukaBow()
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsModified)
			{
				from.SendMessage("That has already been modified.");
			}
			else if (!IsChildOf(from.Backpack))
			{
				from.SendMessage("This must be in your backpack to modify it.");
			}
			else if (from.Skills[SkillName.Fletching].Base < 100.0)
			{
				from.SendMessage("Only a grandmaster bowcrafter can modify this weapon.");
			}
			else
			{
				from.BeginTarget(2, false, Targeting.TargetFlags.None, new TargetCallback(OnTargetGears));
				from.SendMessage("Select the gears you wish to use.");
			}
		}

		public void OnTargetGears(Mobile from, object targ)
		{
			var g = targ as Gears;

			if (g == null || !g.IsChildOf(from.Backpack))
			{
				from.SendMessage("Those are not gears."); // Apparently gears that aren't in your backpack aren't really gears at all. :-(
			}
			else if (IsModified)
			{
				from.SendMessage("That has already been modified.");
			}
			else if (!IsChildOf(from.Backpack))
			{
				from.SendMessage("This must be in your backpack to modify it.");
			}
			else if (from.Skills[SkillName.Fletching].Base < 100.0)
			{
				from.SendMessage("Only a grandmaster bowcrafter can modify this weapon.");
			}
			else
			{
				g.Consume();

				Hue = 0x453;
				Slayer = (SlayerName)Utility.Random(2, 25);

				from.SendMessage("You modify it.");
			}
		}

		public JukaBow(Serial serial) : base(serial)
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

	/// LightweightShortbow
	public class LightweightShortbow : MagicalShortbow
	{
		public override int LabelNumber => 1073510;  // lightweight shortbow

		[Constructable]
		public LightweightShortbow()
		{
			Balanced = true;
		}

		public LightweightShortbow(Serial serial) : base(serial)
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

	/// LongbowOfMight
	public class LongbowOfMight : ElvenCompositeLongbow
	{
		public override int LabelNumber => 1073508;  // longbow of might

		[Constructable]
		public LongbowOfMight()
		{
			Attributes.WeaponDamage = 5;
		}

		public LongbowOfMight(Serial serial) : base(serial)
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

	/// MagicalShortbow
	[FlipableAttribute(0x2D2B, 0x2D1F)]
	public class MagicalShortbow : BaseRanged
	{
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();

		public override WeaponAbility PrimaryAbility => WeaponAbility.LightningArrow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.PsychicAttack;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 9;
		public override int AosMaxDamage => 13;
		public override int AosSpeed => 38;
		public override float MlSpeed => 3.00f;

		public override int OldStrengthReq => 45;
		public override int OldMinDamage => 9;
		public override int OldMaxDamage => 13;
		public override int OldSpeed => 38;

		public override int DefMaxRange => 10;

		public override int InitMinHits => 41;
		public override int InitMaxHits => 90;

		[Constructable]
		public MagicalShortbow() : base(0x2D2B)
		{
			Weight = 6.0;
		}

		public MagicalShortbow(Serial serial) : base(serial)
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

	/// MysticalShortbow
	public class MysticalShortbow : MagicalShortbow
	{
		public override int LabelNumber => 1073511;  // mystical shortbow

		[Constructable]
		public MysticalShortbow()
		{
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = -1;
		}

		public MysticalShortbow(Serial serial) : base(serial)
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

	/// RangersShortbow
	public class RangersShortbow : MagicalShortbow
	{
		public override int LabelNumber => 1073509;  // ranger's shortbow

		[Constructable]
		public RangersShortbow()
		{
			Attributes.WeaponSpeed = 5;
		}

		public RangersShortbow(Serial serial) : base(serial)
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

	/// RepeatingCrossbow
	[FlipableAttribute(0x26C3, 0x26CD)]
	public class RepeatingCrossbow : BaseRanged
	{
		public override int EffectID => 0x1BFE;
		public override Type AmmoType => typeof(Bolt);
		public override Item Ammo => new Bolt();

		public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.MovingShot;

		public override int AosStrengthReq => 30;
		public override int AosMinDamage => Core.ML ? 8 : 10;
		public override int AosMaxDamage => 12;
		public override int AosSpeed => 41;
		public override float MlSpeed => 2.75f;

		public override int OldStrengthReq => 30;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 12;
		public override int OldSpeed => 41;

		public override int DefMaxRange => 7;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

		[Constructable]
		public RepeatingCrossbow() : base(0x26C3)
		{
			Weight = 6.0;
		}

		public RepeatingCrossbow(Serial serial) : base(serial)
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

	/// SlayerLongbow
	public class SlayerLongbow : ElvenCompositeLongbow
	{
		public override int LabelNumber => 1073506;  // slayer longbow

		[Constructable]
		public SlayerLongbow()
		{
			Slayer2 = (SlayerName)Utility.RandomMinMax(1, 27);
		}

		public SlayerLongbow(Serial serial) : base(serial)
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

	/// Yumi
	[FlipableAttribute(0x27A5, 0x27F0)]
	public class Yumi : BaseRanged
	{
		public override int EffectID => 0xF42;
		public override Type AmmoType => typeof(Arrow);
		public override Item Ammo => new Arrow();

		public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorPierce;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DoubleShot;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => Core.ML ? 16 : 18;
		public override int AosMaxDamage => 20;
		public override int AosSpeed => 25;
		public override float MlSpeed => 4.5f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 18;
		public override int OldMaxDamage => 20;
		public override int OldSpeed => 25;

		public override int DefMaxRange => 10;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 60;

		public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;

		[Constructable]
		public Yumi() : base(0x27A5)
		{
			Weight = 9.0;
			Layer = Layer.TwoHanded;
		}

		public Yumi(Serial serial) : base(serial)
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

			if (Weight == 7.0)
			{
				Weight = 6.0;
			}
		}
	}
}