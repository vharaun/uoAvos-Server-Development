namespace Server.Items
{
	public class Centipede : Item
	{
		[Constructable]
		public Centipede() : base(0x2F3)
		{
			Name = "a centipede";
		}

		public Centipede(Serial serial) : base(serial)
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