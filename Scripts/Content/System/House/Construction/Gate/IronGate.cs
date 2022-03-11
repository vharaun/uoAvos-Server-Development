namespace Server.Items
{
	public class IronGate : BaseDoor
	{
		[Constructable]
		public IronGate(DoorFacing facing) : base(0x824 + (2 * (int)facing), 0x825 + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset(facing))
		{
		}

		public IronGate(Serial serial) : base(serial)
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

	public class IronGateShort : BaseDoor
	{
		[Constructable]
		public IronGateShort(DoorFacing facing) : base(0x84c + (2 * (int)facing), 0x84d + (2 * (int)facing), 0xEC, 0xF3, BaseDoor.GetOffset(facing))
		{
		}

		public IronGateShort(Serial serial) : base(serial)
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