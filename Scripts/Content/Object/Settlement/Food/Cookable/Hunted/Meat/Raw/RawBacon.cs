namespace Server.Items
{
	public class RawBacon : CookableFood
	{
		public override double DefaultWeight => 0.1;

		[Constructable]
		public RawBacon() : this(1)
		{
		}

		[Constructable]
		public RawBacon(int amount) : base(0x976, 10)
		{
			Name = "Raw Slice Of Bacon";
			Amount = amount;
		}

		public override Food Cook()
		{
			return new Bacon();
		}

		public RawBacon(Serial serial) : base(serial)
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