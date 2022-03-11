namespace Server.Items
{
	public class RawHam : CookableFood
	{
		[Constructable]
		public RawHam() : this(1)
		{
		}

		[Constructable]
		public RawHam(int amount) : base(0x9C9, 10)
		{
			Name = "Raw Slab Of Ham";
			Weight = 5.0;

			Amount = amount;
		}

		public override Food Cook()
		{
			return new Ham();
		}

		public RawHam(Serial serial) : base(serial)
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