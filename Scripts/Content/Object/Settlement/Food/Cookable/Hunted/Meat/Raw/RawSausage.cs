namespace Server.Items
{
	public class RawSausage : CookableFood
	{
		[Constructable]
		public RawSausage() : this(1)
		{
		}

		[Constructable]
		public RawSausage(int amount) : base(0x09C0, 10)
		{
			Name = "Raw Ribs";
			Weight = 5.0;

			Stackable = true;
			Amount = amount;
		}

		public override Food Cook()
		{
			return new Sausage();
		}

		public RawSausage(Serial serial) : base(serial)
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