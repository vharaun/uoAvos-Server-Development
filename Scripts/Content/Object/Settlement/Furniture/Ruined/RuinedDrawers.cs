namespace Server.Items
{
	[FlipableAttribute(0xC24, 0xC25)]
	public class RuinedDrawers : Item
	{
		[Constructable]
		public RuinedDrawers() : base(0xC24)
		{
			Movable = false;
		}

		public RuinedDrawers(Serial serial) : base(serial)
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