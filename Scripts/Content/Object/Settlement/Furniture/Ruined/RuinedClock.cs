namespace Server.Items
{
	public class RuinedClock : Item
	{
		[Constructable]
		public RuinedClock() : base(0xC1F)
		{
			Movable = false;
		}

		public RuinedClock(Serial serial) : base(serial)
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