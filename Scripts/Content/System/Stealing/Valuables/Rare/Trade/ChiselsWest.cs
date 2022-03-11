namespace Server.Engines.Stealables
{
	public class ChiselsWest : Item
	{
		[Constructable]
		public ChiselsWest() : base(0x1027)
		{
			Weight = 1.0;
		}

		public ChiselsWest(Serial serial) : base(serial)
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