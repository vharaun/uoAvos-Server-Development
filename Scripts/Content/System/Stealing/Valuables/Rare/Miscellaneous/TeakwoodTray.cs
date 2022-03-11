namespace Server.Items
{
	public class TeakwoodTray : Item
	{
		[Constructable]
		public TeakwoodTray() : base(Utility.Random(0x991, 2))
		{
			Name = "Teakwood Tray";
		}

		public TeakwoodTray(Serial serial) : base(serial)
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