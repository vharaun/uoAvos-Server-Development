namespace Server.Items
{
	public class RawSlabOfBacon : CookableFood
	{
		public override double DefaultWeight => 0.1;

		[Constructable]
		public RawSlabOfBacon() : this(1)
		{
		}

		[Constructable]
		public RawSlabOfBacon(int amount) : base(0x976, 10)
		{
			Name = "Raw Slab Of Bacon";
			Amount = amount;
		}

		public override Food Cook()
		{
			return new SlabOfBacon();
		}

		public RawSlabOfBacon(Serial serial) : base(serial)
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