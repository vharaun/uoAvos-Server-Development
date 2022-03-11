namespace Server.Items
{
	public class Maggots : Item
	{
		public override int LabelNumber => 1075090;  // Monsterous Interred Grizzle Maggots

		[Constructable]
		public Maggots() : base(0x2633)
		{
		}

		public Maggots(Serial serial) : base(serial)
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