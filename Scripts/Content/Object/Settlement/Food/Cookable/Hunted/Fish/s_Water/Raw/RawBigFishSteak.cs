namespace Server.Items
{
	public class RawBigFishSteak : CookableFood
	{
		public override double DefaultWeight => 0.1;

		[Constructable]
		public RawBigFishSteak() : this(1)
		{
		}

		[Constructable]
		public RawBigFishSteak(int amount) : base(0x097A, 10)
		{
			Stackable = true;
			Amount = amount;
		}

		public RawBigFishSteak(Serial serial) : base(serial)
		{
		}

		public override Food Cook()
		{
			return new BigFishSteak();
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