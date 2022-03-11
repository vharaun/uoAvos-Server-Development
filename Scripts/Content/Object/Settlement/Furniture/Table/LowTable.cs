namespace Server.Items
{
	/// PlainLowTable
	[Furniture]
	public class PlainLowTable : Item
	{
		[Constructable]
		public PlainLowTable() : base(0x281A)
		{
			Weight = 1.0;
		}

		public PlainLowTable(Serial serial) : base(serial)
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

		}
	}

	/// ElegantLowTable
	[Furniture]
	public class ElegantLowTable : Item
	{
		[Constructable]
		public ElegantLowTable() : base(0x2819)
		{
			Weight = 1.0;
		}

		public ElegantLowTable(Serial serial) : base(serial)
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

		}
	}
}