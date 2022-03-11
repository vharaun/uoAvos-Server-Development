namespace Server.Items
{
	[FlipableAttribute(0xFAF, 0xFB0)]
	[Server.Engines.Craft.Anvil]
	public class Anvil : Item
	{
		[Constructable]
		public Anvil() : base(0xFAF)
		{
			Movable = false;
		}

		public Anvil(Serial serial) : base(serial)
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