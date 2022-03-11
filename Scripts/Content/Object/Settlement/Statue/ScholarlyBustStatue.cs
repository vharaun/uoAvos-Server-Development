namespace Server.Items
{
	/// Facing: South
	public class BustSouth : Item
	{
		[Constructable]
		public BustSouth() : base(0x12CB)
		{
			Weight = 10;
		}

		public BustSouth(Serial serial) : base(serial)
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

	/// Facing: East
	public class BustEast : Item
	{
		[Constructable]
		public BustEast() : base(0x12CA)
		{
			Weight = 10;
		}

		public BustEast(Serial serial) : base(serial)
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