namespace Server.Items
{
	/// Beverages


	/// Food Items
	public class EasterEggs : CookableFood
	{
		public override int LabelNumber => 1016105;  // Easter Eggs

		[Constructable]
		public EasterEggs() : base(0x9B5, 15)
		{
			Weight = 0.5;
			Hue = 3 + (Utility.Random(20) * 5);
		}

		public EasterEggs(Serial serial) : base(serial)
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

		public override Food Cook()
		{
			return new FriedEggs();
		}
	}

	public class BrightlyColoredEggs : CookableFood
	{
		public override string DefaultName => "brightly colored eggs";

		[Constructable]
		public BrightlyColoredEggs() : base(0x9B5, 15)
		{
			Weight = 0.5;
			Hue = 3 + (Utility.Random(20) * 5);
		}

		public BrightlyColoredEggs(Serial serial) : base(serial)
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

		public override Food Cook()
		{
			return new FriedEggs();
		}
	}

	/// Candy Items
	public class ChocolateBunny : CandyCane
	{
		[Constructable]
		public ChocolateBunny() : this(1)
		{

		}

		[Constructable]
		public ChocolateBunny(int amount)
			: base(0x3D6B)
		{
			Name = "Chocolate Bunny";
			LootType = LootType.Regular;

			FillFactor = 3;

			Hue = 0;
			Weight = Utility.Random(1, 3);

		}

		public ChocolateBunny(Serial serial)
			: base(serial)
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