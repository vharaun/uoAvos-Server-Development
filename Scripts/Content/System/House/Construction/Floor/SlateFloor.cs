namespace Server.Items
{
	public class BlueSlateFloorCenter : BaseFloor
	{
		[Constructable]
		public BlueSlateFloorCenter() : base(0x49B, 1)
		{
		}

		public BlueSlateFloorCenter(Serial serial) : base(serial)
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

	public class GreySlateFloor : BaseFloor
	{
		[Constructable]
		public GreySlateFloor() : base(0x49C, 1)
		{
		}

		public GreySlateFloor(Serial serial) : base(serial)
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