namespace Server.Items
{
	public class RawPig : CookableFood
	{
		[Constructable]
		public RawPig() : this(1)
		{
		}

		[Constructable]
		public RawPig(int amount) : base(0x2101, 10)
		{
			Name = "Raw Pig Carcass";
			Weight = 50.0;
			Hue = 0x0A93;

			Amount = amount;
		}

		public override Food Cook()
		{
			return new RoastPig();
		}

		public RawPig(Serial serial) : base(serial)
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