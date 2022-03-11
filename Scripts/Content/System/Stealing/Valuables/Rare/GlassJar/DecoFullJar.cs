namespace Server.Engines.Stealables
{
	public class DecoFullJar : Item
	{
		[Constructable]
		public DecoFullJar()
			: base(0x1006)
		{
			Movable = true;
			Stackable = false;
		}

		public DecoFullJar(Serial serial)
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