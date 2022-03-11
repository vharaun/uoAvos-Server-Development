namespace Server.Items
{
	/// Facing: South
	public class StatueSouth : Item
	{
		[Constructable]
		public StatueSouth() : base(0x139A)
		{
			Weight = 10;
		}

		public StatueSouth(Serial serial) : base(serial)
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
	public class StatueEast2 : Item
	{
		[Constructable]
		public StatueEast2() : base(0x1224)
		{
			Weight = 10;
		}

		public StatueEast2(Serial serial) : base(serial)
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