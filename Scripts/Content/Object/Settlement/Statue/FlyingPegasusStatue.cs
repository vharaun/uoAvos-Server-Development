namespace Server.Items
{
	/// Facing: South
	public class StatuePegasus : Item
	{
		[Constructable]
		public StatuePegasus() : base(0x139D)
		{
			Weight = 10;
		}

		public StatuePegasus(Serial serial) : base(serial)
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
	public class StatuePegasus2 : Item
	{
		[Constructable]
		public StatuePegasus2() : base(0x1228)
		{
			Weight = 10;
		}

		public StatuePegasus2(Serial serial) : base(serial)
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