namespace Server.Engines.Stealables
{
	public class DecoFullJars4 : Item
	{
		[Constructable]
		public DecoFullJars4()
			: base(0xE4b)
		{
			Movable = true;
			Stackable = false;
		}

		public DecoFullJars4(Serial serial)
			: base(serial)
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