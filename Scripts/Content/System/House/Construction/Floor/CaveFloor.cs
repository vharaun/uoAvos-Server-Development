namespace Server.Items
{
	public class CaveFloorCenter : BaseFloor
	{
		[Constructable]
		public CaveFloorCenter() : base(0x53B, 4)
		{
		}

		public CaveFloorCenter(Serial serial) : base(serial)
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

	public class CaveFloorSouth : BaseFloor
	{
		[Constructable]
		public CaveFloorSouth() : base(0x541, 3)
		{
		}

		public CaveFloorSouth(Serial serial) : base(serial)
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

	public class CaveFloorEast : BaseFloor
	{
		[Constructable]
		public CaveFloorEast() : base(0x544, 3)
		{
		}

		public CaveFloorEast(Serial serial) : base(serial)
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

	public class CaveFloorWest : BaseFloor
	{
		[Constructable]
		public CaveFloorWest() : base(0x54A, 3)
		{
		}

		public CaveFloorWest(Serial serial) : base(serial)
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

	public class CaveFloorNorth : BaseFloor
	{
		[Constructable]
		public CaveFloorNorth() : base(0x54D, 3)
		{
		}

		public CaveFloorNorth(Serial serial) : base(serial)
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