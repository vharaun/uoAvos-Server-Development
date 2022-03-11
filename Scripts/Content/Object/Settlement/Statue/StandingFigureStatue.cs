namespace Server.Items
{
	/// Facing: SouthEast
	public class StatueSouthEast : Item
	{
		[Constructable]
		public StatueSouthEast() : base(0x1225)
		{
			Weight = 10;
		}

		public StatueSouthEast(Serial serial) : base(serial)
		{
		}

		public override bool ForceShowProperties => ObjectPropertyList.Enabled;

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