namespace Server.Items
{
	[Server.Engines.Craft.Forge]
	public class Forge : Item
	{
		[Constructable]
		public Forge() : base(0xFB1)
		{
			Movable = false;
		}

		public Forge(Serial serial) : base(serial)
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