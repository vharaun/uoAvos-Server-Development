namespace Server.Engines.Stealables
{
	public class GoldWire : Item
	{
		[Constructable]
		public GoldWire() : this(1)
		{
		}

		[Constructable]
		public GoldWire(int amount) : base(0x1878)
		{
			Stackable = true;
			Weight = 5.0;
			Amount = amount;
		}

		public GoldWire(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version < 1 && Weight == 2.0)
			{
				Weight = 5.0;
			}
		}
	}
}