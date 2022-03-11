namespace Server.Items
{
	public class GreyFlagstones : BaseFloor
	{
		[Constructable]
		public GreyFlagstones() : base(0x4FC, 4)
		{
		}

		public GreyFlagstones(Serial serial) : base(serial)
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

	public class SandFlagstones : BaseFloor
	{
		[Constructable]
		public SandFlagstones() : base(0x500, 4)
		{
		}

		public SandFlagstones(Serial serial) : base(serial)
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