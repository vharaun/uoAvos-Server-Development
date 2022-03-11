namespace Server.Items
{
	/// Bardiche
	[FlipableAttribute(0xF4D, 0xF4E)]
	public class Bardiche : BasePoleArm
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
		public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;

		public override int AosStrengthReq => 45;
		public override int AosMinDamage => 17;
		public override int AosMaxDamage => 18;
		public override int AosSpeed => 28;
		public override float MlSpeed => 3.75f;

		public override int OldStrengthReq => 40;
		public override int OldMinDamage => 5;
		public override int OldMaxDamage => 43;
		public override int OldSpeed => 26;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 100;

		[Constructable]
		public Bardiche() : base(0xF4D)
		{
			Weight = 7.0;
		}

		public Bardiche(Serial serial) : base(serial)
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

	/// Halberd
	[FlipableAttribute(0x143E, 0x143F)]
	public class Halberd : BasePoleArm
	{
		public override WeaponAbility PrimaryAbility => WeaponAbility.WhirlwindAttack;
		public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;

		public override int AosStrengthReq => 95;
		public override int AosMinDamage => 18;
		public override int AosMaxDamage => 19;
		public override int AosSpeed => 25;
		public override float MlSpeed => 4.25f;

		public override int OldStrengthReq => 45;
		public override int OldMinDamage => 5;
		public override int OldMaxDamage => 49;
		public override int OldSpeed => 25;

		public override int InitMinHits => 31;
		public override int InitMaxHits => 80;

		[Constructable]
		public Halberd() : base(0x143E)
		{
			Weight = 16.0;
		}

		public Halberd(Serial serial) : base(serial)
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