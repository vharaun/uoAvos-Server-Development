namespace Server.Engines.Stealables
{
	public class ChiselsNorth : Item
	{
		[Constructable]
		public ChiselsNorth() : base(0x1026)
		{
			Weight = 1.0;
		}

		public ChiselsNorth(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}