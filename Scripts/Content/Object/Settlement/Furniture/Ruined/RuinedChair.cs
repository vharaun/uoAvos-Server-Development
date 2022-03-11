namespace Server.Items
{
	[FlipableAttribute(0xC1B, 0xC1C, 0xC1E, 0xC1D)]
	public class RuinedChair : Item
	{
		[Constructable]
		public RuinedChair() : base(0xC1B)
		{
			Movable = false;
		}

		public RuinedChair(Serial serial) : base(serial)
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