namespace Server.Items
{
	public class BricksFloor1 : BaseFloor
	{
		[Constructable]
		public BricksFloor1() : base(0x4E2, 8)
		{
		}

		public BricksFloor1(Serial serial) : base(serial)
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

	public class BricksFloor2 : BaseFloor
	{
		[Constructable]
		public BricksFloor2() : base(0x537, 4)
		{
		}

		public BricksFloor2(Serial serial) : base(serial)
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