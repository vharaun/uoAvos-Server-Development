namespace Server.Engines.Stealables
{
	public class IronWire : Item
	{
		[Constructable]
		public IronWire() : this(1)
		{
		}

		[Constructable]
		public IronWire(int amount) : base(0x1876)
		{
			Stackable = true;
			Weight = 5.0;
			Amount = amount;
		}

		public IronWire(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
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