namespace Server.Items
{
	/// Facing: South
	public class StatueSouth2 : Item
	{
		[Constructable]
		public StatueSouth2() : base(0x1227)
		{
			Weight = 10;
		}

		public StatueSouth2(Serial serial) : base(serial)
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

	/// Facing East
	public class StatueEast : Item
	{
		[Constructable]
		public StatueEast() : base(0x139C)
		{
			Weight = 10;
		}

		public StatueEast(Serial serial) : base(serial)
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