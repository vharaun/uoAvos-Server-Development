namespace Server.Items
{
	public class RawFreshwaterFishSteak : CookableFood
	{
		public override double DefaultWeight => 0.1;

		[Constructable]
		public RawFreshwaterFishSteak() : this(1)
		{
		}

		[Constructable]
		public RawFreshwaterFishSteak(int amount) : base(0x097A, 10)
		{
			Stackable = true;
			Amount = amount;
		}

		public RawFreshwaterFishSteak(Serial serial) : base(serial)
		{
		}

		public override Food Cook()
		{
			return new FreshwaterFishSteak();
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