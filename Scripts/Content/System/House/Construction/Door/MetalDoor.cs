namespace Server.Items
{
	public class MetalDoor : BaseDoor
	{
		[Constructable]
		public MetalDoor(DoorFacing facing) : base(0x675 + (2 * (int)facing), 0x676 + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset(facing))
		{
		}

		public MetalDoor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	public class MetalDoor2 : BaseDoor
	{
		[Constructable]
		public MetalDoor2(DoorFacing facing) : base(0x6C5 + (2 * (int)facing), 0x6C6 + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset(facing))
		{
		}

		public MetalDoor2(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// House Door
	public class MetalHouseDoor : BaseHouseDoor
	{
		[Constructable]
		public MetalHouseDoor(DoorFacing facing) : base(facing, 0x675 + (2 * (int)facing), 0x676 + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset(facing))
		{
		}

		public MetalHouseDoor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer) // Default Serialize method
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader) // Default Deserialize method
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}