namespace Server.Items
{
	public class BowlFlour : Item
	{
		[Constructable]
		public BowlFlour() : base(0xa1e)
		{
			Weight = 1.0;
		}

		public BowlFlour(Serial serial) : base(serial)
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