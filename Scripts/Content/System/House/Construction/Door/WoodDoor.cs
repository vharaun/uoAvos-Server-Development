namespace Server.Items
{
	public class LightWoodDoor : BaseDoor
	{
		[Constructable]
		public LightWoodDoor(DoorFacing facing) : base(0x6D5 + (2 * (int)facing), 0x6D6 + (2 * (int)facing), 0xEA, 0xF1, BaseDoor.GetOffset(facing))
		{
		}

		public LightWoodDoor(Serial serial) : base(serial)
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

	public class MediumWoodDoor : BaseDoor
	{
		[Constructable]
		public MediumWoodDoor(DoorFacing facing) : base(0x6B5 + (2 * (int)facing), 0x6B6 + (2 * (int)facing), 0xEA, 0xF1, BaseDoor.GetOffset(facing))
		{
		}

		public MediumWoodDoor(Serial serial) : base(serial)
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

	public class DarkWoodDoor : BaseDoor
	{
		[Constructable]
		public DarkWoodDoor(DoorFacing facing) : base(0x6A5 + (2 * (int)facing), 0x6A6 + (2 * (int)facing), 0xEA, 0xF1, BaseDoor.GetOffset(facing))
		{
		}

		public DarkWoodDoor(Serial serial) : base(serial)
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

	public class StrongWoodDoor : BaseDoor
	{
		[Constructable]
		public StrongWoodDoor(DoorFacing facing) : base(0x6E5 + (2 * (int)facing), 0x6E6 + (2 * (int)facing), 0xEA, 0xF1, BaseDoor.GetOffset(facing))
		{
		}

		public StrongWoodDoor(Serial serial) : base(serial)
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
	public class DarkWoodHouseDoor : BaseHouseDoor
	{
		[Constructable]
		public DarkWoodHouseDoor(DoorFacing facing) : base(facing, 0x6A5 + (2 * (int)facing), 0x6A6 + (2 * (int)facing), 0xEA, 0xF1, BaseDoor.GetOffset(facing))
		{
		}

		public DarkWoodHouseDoor(Serial serial) : base(serial)
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