namespace Server.Items
{
	/// Facing: North
	public class StatueNorth : Item
	{
		[Constructable]
		public StatueNorth() : base(0x139B)
		{
			Weight = 10;
		}

		public StatueNorth(Serial serial) : base(serial)
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

	/// Facing: West
	public class StatueWest : Item
	{
		[Constructable]
		public StatueWest() : base(0x1226)
		{
			Weight = 10;
		}

		public StatueWest(Serial serial) : base(serial)
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