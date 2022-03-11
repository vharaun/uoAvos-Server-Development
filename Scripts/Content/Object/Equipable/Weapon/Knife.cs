using Server.Targeting;

using System;

namespace Server.Items
{
	/// AssassinSpike
	[FlipableAttribute(0x2D21, 0x2D2D)]
	public class AssassinSpike : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.InfectiousStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ShadowStrike;

		public override int AosStrengthReq => 15;
		public override int AosMinDamage => 10;
		public override int AosMaxDamage => 12;
		public override int AosSpeed => 50;
		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 15;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 12;
		public override int OldSpeed => 50;

		public override int DefMissSound => 0x239;
		public override SkillName DefSkill => SkillName.Fencing;

		public override int InitMinHits => 30;  // TODO
		public override int InitMaxHits => 60;  // TODO

		[Constructable]
		public AssassinSpike() : base(0x2D21)
		{
			Weight = 4.0;
		}

		public AssassinSpike(Serial serial) : base(serial)
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

	/// ButcherKnife
	[FlipableAttribute(0x13F6, 0x13F7)]
	public class ButcherKnife : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.InfectiousStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;

		public override int AosStrengthReq => 5;
		public override int AosMinDamage => 9;
		public override int AosMaxDamage => 11;
		public override int AosSpeed => 49;
		public override float MlSpeed => 2.25f;

		public override int OldStrengthReq => 5;
		public override int OldMinDamage => 2;
		public override int OldMaxDamage => 14;
		public override int OldSpeed => 40;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 40;

		[Constructable]
		public ButcherKnife() : base(0x13F6)
		{
			Weight = 1.0;
		}

		public ButcherKnife(Serial serial) : base(serial)
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

	/// ButchersWarCleaver
	public class ButchersWarCleaver : WarCleaver
	{
		public override int LabelNumber => 1073526;  // butcher's war cleaver

		[Constructable]
		public ButchersWarCleaver() : base()
		{
		}

		public ButchersWarCleaver(Serial serial) : base(serial)
		{
		}

		public override void AppendChildNameProperties(ObjectPropertyList list)
		{
			base.AppendChildNameProperties(list);

			list.Add(1072512); // Bovine Slayer
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

	/// Cleaver
	[FlipableAttribute(0xEC3, 0xEC2)]
	public class Cleaver : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.BleedAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.InfectiousStrike;

		public override int AosStrengthReq => 10;
		public override int AosMinDamage => 11;
		public override int AosMaxDamage => 13;
		public override int AosSpeed => 46;
		public override float MlSpeed => 2.50f;

		public override int OldStrengthReq => 10;
		public override int OldMinDamage => 2;
		public override int OldMaxDamage => 13;
		public override int OldSpeed => 40;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 50;

		[Constructable]
		public Cleaver() : base(0xEC3)
		{
			Weight = 2.0;
		}

		public Cleaver(Serial serial) : base(serial)
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

			if (Weight == 1.0)
			{
				Weight = 2.0;
			}
		}
	}

	/// ChargedAssassinSpike
	public class ChargedAssassinSpike : AssassinSpike
	{
		public override int LabelNumber => 1073518;  // charged assassin spike

		[Constructable]
		public ChargedAssassinSpike()
		{
			WeaponAttributes.HitLightning = 10;
		}

		public ChargedAssassinSpike(Serial serial) : base(serial)
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

	/// Dagger
	[FlipableAttribute(0xF52, 0xF51)]
	public class Dagger : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.InfectiousStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ShadowStrike;

		public override int AosStrengthReq => 10;
		public override int AosMinDamage => 10;
		public override int AosMaxDamage => 11;
		public override int AosSpeed => 56;
		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 1;
		public override int OldMinDamage => 3;
		public override int OldMaxDamage => 15;
		public override int OldSpeed => 55;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 40;

		public override SkillName DefSkill => SkillName.Fencing;
		public override WeaponType DefType => WeaponType.Piercing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public Dagger() : base(0xF52)
		{
			Weight = 1.0;
		}

		public Dagger(Serial serial) : base(serial)
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

	/// ElvenSpellblade
	[FlipableAttribute(0x2D20, 0x2D2C)]
	public class ElvenSpellblade : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.PsychicAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.BleedAttack;

		public override int AosStrengthReq => 35;
		public override int AosMinDamage => 12;
		public override int AosMaxDamage => 14;
		public override int AosSpeed => 44;
		public override float MlSpeed => 2.50f;

		public override int OldStrengthReq => 35;
		public override int OldMinDamage => 12;
		public override int OldMaxDamage => 14;
		public override int OldSpeed => 44;

		public override int DefMissSound => 0x239;

		public override int InitMinHits => 30;  // TODO
		public override int InitMaxHits => 60;  // TODO

		[Constructable]
		public ElvenSpellblade() : base(0x2D20)
		{
			Weight = 5.0;
			Layer = Layer.TwoHanded;
		}

		public ElvenSpellblade(Serial serial) : base(serial)
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

	/// FierySpellblade
	public class FierySpellblade : ElvenSpellblade
	{
		public override int LabelNumber => 1073515;  // fiery spellblade

		[Constructable]
		public FierySpellblade()
		{
			WeaponAttributes.ResistFireBonus = 5;
		}

		public FierySpellblade(Serial serial) : base(serial)
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

	/// IcySpellblade
	public class IcySpellblade : ElvenSpellblade
	{
		public override int LabelNumber => 1073514;  // icy spellblade

		[Constructable]
		public IcySpellblade()
		{
			WeaponAttributes.ResistColdBonus = 5;
		}

		public IcySpellblade(Serial serial) : base(serial)
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

	/// Kama
	[FlipableAttribute(0x27AD, 0x27F8)]
	public class Kama : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.DefenseMastery;

		public override int AosStrengthReq => 15;
		public override int AosMinDamage => 9;
		public override int AosMaxDamage => 11;
		public override int AosSpeed => 55;
		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 15;
		public override int OldMinDamage => 9;
		public override int OldMaxDamage => 11;
		public override int OldSpeed => 55;

		public override int DefHitSound => 0x232;
		public override int DefMissSound => 0x238;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 60;

		public override SkillName DefSkill => SkillName.Fencing;
		public override WeaponType DefType => WeaponType.Piercing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public Kama() : base(0x27AD)
		{
			Weight = 7.0;
			Layer = Layer.TwoHanded;
		}

		public Kama(Serial serial) : base(serial)
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

	/// KnightsWarCleaver
	public class KnightsWarCleaver : WarCleaver
	{
		public override int LabelNumber => 1073525;  // knight's war cleaver

		[Constructable]
		public KnightsWarCleaver()
		{
			Attributes.RegenHits = 3;
		}

		public KnightsWarCleaver(Serial serial) : base(serial)
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

	/// Lajatang
	[FlipableAttribute(0x27A7, 0x27F2)]
	public class Lajatang : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DefenseMastery;
		public override WeaponAbility SecondaryAbility => WeaponAbility.FrenziedWhirlwind;

		public override int AosStrengthReq => 65;
		public override int AosMinDamage => 16;
		public override int AosMaxDamage => 18;
		public override int AosSpeed => 32;
		public override float MlSpeed => 3.50f;

		public override int OldStrengthReq => 65;
		public override int OldMinDamage => 16;
		public override int OldMaxDamage => 18;
		public override int OldSpeed => 55;

		public override int DefHitSound => 0x232;
		public override int DefMissSound => 0x238;

		public override int InitMinHits => 90;
		public override int InitMaxHits => 95;

		public override SkillName DefSkill => SkillName.Fencing;
		public override WeaponType DefType => WeaponType.Piercing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public Lajatang() : base(0x27A7)
		{
			Weight = 12.0;
			Layer = Layer.TwoHanded;
		}

		public Lajatang(Serial serial) : base(serial)
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

	/// Leafblade
	[FlipableAttribute(0x2D22, 0x2D2E)]
	public class Leafblade : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Feint;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorIgnore;

		public override int AosStrengthReq => 20;
		public override int AosMinDamage => 13;
		public override int AosMaxDamage => 15;
		public override int AosSpeed => 42;
		public override float MlSpeed => 2.75f;

		public override int OldStrengthReq => 20;
		public override int OldMinDamage => 13;
		public override int OldMaxDamage => 15;
		public override int OldSpeed => 42;

		public override int DefMissSound => 0x239;
		public override SkillName DefSkill => SkillName.Fencing;

		public override int InitMinHits => 30;  // TODO
		public override int InitMaxHits => 60;  // TODO

		[Constructable]
		public Leafblade() : base(0x2D22)
		{
			Weight = 8.0;
		}

		public Leafblade(Serial serial) : base(serial)
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

	/// LeafbladeOfEase
	public class LeafbladeOfEase : Leafblade
	{
		public override int LabelNumber => 1073524;  // leafblade of ease

		[Constructable]
		public LeafbladeOfEase()
		{
			WeaponAttributes.UseBestSkill = 1;
		}

		public LeafbladeOfEase(Serial serial) : base(serial)
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

	/// Luckblade
	public class Luckblade : Leafblade
	{
		public override int LabelNumber => 1073522;  // luckblade

		[Constructable]
		public Luckblade()
		{
			Attributes.Luck = 20;
		}

		public Luckblade(Serial serial) : base(serial)
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

	/// MagekillerAssassinSpike
	public class MagekillerAssassinSpike : AssassinSpike
	{
		public override int LabelNumber => 1073519;  // magekiller assassin spike

		[Constructable]
		public MagekillerAssassinSpike()
		{
			WeaponAttributes.HitLeechMana = 16;
		}

		public MagekillerAssassinSpike(Serial serial) : base(serial)
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

	/// MagekillerLeafblade
	public class MagekillerLeafblade : Leafblade
	{
		public override int LabelNumber => 1073523;  // maagekiller leafblade

		[Constructable]
		public MagekillerLeafblade()
		{
			WeaponAttributes.HitLeechMana = 16;
		}

		public MagekillerLeafblade(Serial serial) : base(serial)
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

	/// NoDachi
	[FlipableAttribute(0x27A2, 0x27ED)]
	public class NoDachi : BaseSword
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.CrushingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.RidingSwipe;

		public override int AosStrengthReq => 40;
		public override int AosMinDamage => 16;
		public override int AosMaxDamage => 18;
		public override int AosSpeed => 35;
		public override float MlSpeed => 3.50f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 16;
		public override int OldMaxDamage => 18;
		public override int OldSpeed => 35;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x23A;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 90;

		[Constructable]
		public NoDachi() : base(0x27A2)
		{
			Weight = 10.0;
			Layer = Layer.TwoHanded;
		}

		public NoDachi(Serial serial) : base(serial)
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

	/// Sai
	[FlipableAttribute(0x27AF, 0x27FA)]
	public class Sai : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Block;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ArmorPierce;

		public override int AosStrengthReq => 15;
		public override int AosMinDamage => 9;
		public override int AosMaxDamage => 11;
		public override int AosSpeed => 55;
		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 15;
		public override int OldMinDamage => 9;
		public override int OldMaxDamage => 11;
		public override int OldSpeed => 55;

		public override int DefHitSound => 0x23C;
		public override int DefMissSound => 0x232;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 60;

		public override SkillName DefSkill => SkillName.Fencing;
		public override WeaponType DefType => WeaponType.Piercing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public Sai() : base(0x27AF)
		{
			Weight = 7.0;
			Layer = Layer.TwoHanded;
		}

		public Sai(Serial serial) : base(serial)
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

	/// SerratedWarCleaver
	public class SerratedWarCleaver : WarCleaver
	{
		public override int LabelNumber => 1073527;  // serrated war cleaver

		[Constructable]
		public SerratedWarCleaver()
		{
			Attributes.WeaponDamage = 7;
		}

		public SerratedWarCleaver(Serial serial) : base(serial)
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

	/// SkinningKnife
	[FlipableAttribute(0xEC4, 0xEC5)]
	public class SkinningKnife : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ShadowStrike;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Disarm;

		public override int AosStrengthReq => 5;
		public override int AosMinDamage => 9;
		public override int AosMaxDamage => 11;
		public override int AosSpeed => 49;
		public override float MlSpeed => 2.25f;

		public override int OldStrengthReq => 5;
		public override int OldMinDamage => 1;
		public override int OldMaxDamage => 10;
		public override int OldSpeed => 40;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 40;

		[Constructable]
		public SkinningKnife() : base(0xEC4)
		{
			Weight = 1.0;
		}

		public SkinningKnife(Serial serial) : base(serial)
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

	/// SpellbladeOfDefense
	public class SpellbladeOfDefense : ElvenSpellblade
	{
		public override int LabelNumber => 1073516;  // spellblade of defense

		[Constructable]
		public SpellbladeOfDefense()
		{
			Attributes.DefendChance = 5;
		}

		public SpellbladeOfDefense(Serial serial) : base(serial)
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

	/// Tekagi
	[FlipableAttribute(0x27Ab, 0x27F6)]
	public class Tekagi : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.DualWield;
		public override WeaponAbility SecondaryAbility => WeaponAbility.TalonStrike;

		public override int AosStrengthReq => 10;
		public override int AosMinDamage => 10;
		public override int AosMaxDamage => 12;
		public override int AosSpeed => 53;
		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 10;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 12;
		public override int OldSpeed => 53;

		public override int DefHitSound => 0x238;
		public override int DefMissSound => 0x232;

		public override int InitMinHits => 35;
		public override int InitMaxHits => 60;

		public override SkillName DefSkill => SkillName.Fencing;
		public override WeaponType DefType => WeaponType.Piercing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public Tekagi() : base(0x27AB)
		{
			Weight = 5.0;
			Layer = Layer.TwoHanded;
		}

		public Tekagi(Serial serial) : base(serial)
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

	/// Tessen
	[FlipableAttribute(0x27A3, 0x27EE)]
	public class Tessen : BaseBashing
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Feint;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Block;

		public override int AosStrengthReq => 10;
		public override int AosMinDamage => 10;
		public override int AosMaxDamage => 12;
		public override int AosSpeed => 50;
		public override float MlSpeed => 2.00f;

		public override int OldStrengthReq => 10;
		public override int OldMinDamage => 10;
		public override int OldMaxDamage => 12;
		public override int OldSpeed => 50;

		public override int DefHitSound => 0x232;
		public override int DefMissSound => 0x238;

		public override int InitMinHits => 55;
		public override int InitMaxHits => 60;

		public override WeaponAnimation DefAnimation => WeaponAnimation.Bash2H;

		[Constructable]
		public Tessen() : base(0x27A3)
		{
			Weight = 6.0;
			Layer = Layer.TwoHanded;
		}

		public Tessen(Serial serial) : base(serial)
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

	/// ThrowingDagger
	[FlipableAttribute(0xF52, 0xF51)]
	public class ThrowingDagger : Item
	{
		public override string DefaultName => "a throwing dagger";

		[Constructable]
		public ThrowingDagger() : base(0xF52)
		{
			Weight = 1.0;
			Layer = Layer.OneHanded;
		}

		public ThrowingDagger(Serial serial) : base(serial)
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

		public override void OnDoubleClick(Mobile from)
		{
			if (from.Items.Contains(this))
			{
				var t = new InternalTarget(this);
				from.Target = t;
			}
			else
			{
				from.SendMessage("You must be holding that weapon to use it.");
			}
		}

		private class InternalTarget : Target
		{
			private readonly ThrowingDagger m_Dagger;

			public InternalTarget(ThrowingDagger dagger) : base(10, false, TargetFlags.Harmful)
			{
				m_Dagger = dagger;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Dagger.Deleted)
				{
					return;
				}
				else if (!from.Items.Contains(m_Dagger))
				{
					from.SendMessage("You must be holding that weapon to use it.");
				}
				else if (targeted is Mobile)
				{
					var m = (Mobile)targeted;

					if (m != from && from.HarmfulCheck(m))
					{
						var to = from.GetDirectionTo(m);

						from.Direction = to;

						from.Animate(from.Mounted ? 26 : 9, 7, 1, true, false, 0);

						if (Utility.RandomDouble() >= (Math.Sqrt(m.Dex / 100.0) * 0.8))
						{
							from.MovingEffect(m, 0x1BFE, 7, 1, false, false, 0x481, 0);

							AOS.Damage(m, from, Utility.Random(5, from.Str / 10), 100, 0, 0, 0, 0);

							m_Dagger.MoveToWorld(m.Location, m.Map);
						}
						else
						{
							int x = 0, y = 0;

							switch (to & Direction.Mask)
							{
								case Direction.North: --y; break;
								case Direction.South: ++y; break;
								case Direction.West: --x; break;
								case Direction.East: ++x; break;
								case Direction.Up: --x; --y; break;
								case Direction.Down: ++x; ++y; break;
								case Direction.Left: --x; ++y; break;
								case Direction.Right: ++x; --y; break;
							}

							x += Utility.Random(-1, 3);
							y += Utility.Random(-1, 3);

							x += m.X;
							y += m.Y;

							m_Dagger.MoveToWorld(new Point3D(x, y, m.Z), m.Map);

							from.MovingEffect(m_Dagger, 0x1BFE, 7, 1, false, false, 0x481, 0);

							from.SendMessage("You miss.");
						}
					}
				}
			}
		}
	}

	/// TrueAssassinSpike
	public class TrueAssassinSpike : AssassinSpike
	{
		public override int LabelNumber => 1073517;  // true assassin spike

		[Constructable]
		public TrueAssassinSpike()
		{
			Attributes.AttackChance = 4;
			Attributes.WeaponDamage = 4;
		}

		public TrueAssassinSpike(Serial serial) : base(serial)
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

	/// TrueLeafblade
	public class TrueLeafblade : Leafblade
	{
		public override int LabelNumber => 1073521;  // true leafblade

		[Constructable]
		public TrueLeafblade()
		{
			WeaponAttributes.ResistPoisonBonus = 5;
		}

		public TrueLeafblade(Serial serial) : base(serial)
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

	/// TrueSpellblade
	public class TrueSpellblade : ElvenSpellblade
	{
		public override int LabelNumber => 1073513;  // true spellblade

		[Constructable]
		public TrueSpellblade()
		{
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = -1;
		}

		public TrueSpellblade(Serial serial) : base(serial)
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

	/// TrueWarCleaver
	public class TrueWarCleaver : WarCleaver
	{
		public override int LabelNumber => 1073528;  // true war cleaver

		[Constructable]
		public TrueWarCleaver()
		{
			Attributes.WeaponDamage = 4;
			Attributes.RegenHits = 2;
		}

		public TrueWarCleaver(Serial serial) : base(serial)
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

	/// WarCleaver
	[FlipableAttribute(0x2D2F, 0x2D23)]
	public class WarCleaver : BaseKnife
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.Disarm;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Bladeweave;

		public override int AosStrengthReq => 15;
		public override int AosMinDamage => 9;
		public override int AosMaxDamage => 11;
		public override int AosSpeed => 48;
		public override float MlSpeed => 2.25f;

		public override int OldStrengthReq => 15;
		public override int OldMinDamage => 9;
		public override int OldMaxDamage => 11;
		public override int OldSpeed => 48;

		public override int DefHitSound => 0x23B;
		public override int DefMissSound => 0x239;

		public override int InitMinHits => 30;  // TODO
		public override int InitMaxHits => 60;  // TODO

		public override SkillName DefSkill => SkillName.Fencing;
		public override WeaponType DefType => WeaponType.Piercing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Pierce1H;

		[Constructable]
		public WarCleaver() : base(0x2D2F)
		{
			Weight = 10.0;
		}

		public WarCleaver(Serial serial) : base(serial)
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

	/// WoundingAssassinSpike
	public class WoundingAssassinSpike : AssassinSpike
	{
		public override int LabelNumber => 1073520;  // wounding assassin spike

		[Constructable]
		public WoundingAssassinSpike()
		{
			WeaponAttributes.HitHarm = 15;
		}

		public WoundingAssassinSpike(Serial serial) : base(serial)
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