namespace Server.Items
{
	public class RawRibs : CookableFood
	{
		[Constructable]
		public RawRibs() : this(1)
		{
		}

		[Constructable]
		public RawRibs(int amount) : base(0x9F1, 10)
		{
			Name = "Raw Ribs";
			Weight = 1.0;

			Stackable = true;
			Amount = amount;
		}

		public override Food Cook()
		{
			return new Ribs();
		}

		public RawRibs(Serial serial) : base(serial)
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