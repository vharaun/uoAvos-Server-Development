namespace Server.Items
{
	public class SandstoneFloorN : BaseFloor
	{
		[Constructable]
		public SandstoneFloorN() : base(0x525, 4)
		{
		}

		public SandstoneFloorN(Serial serial) : base(serial)
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

	public class SandstoneFloorW : BaseFloor
	{
		[Constructable]
		public SandstoneFloorW() : base(0x529, 4)
		{
		}

		public SandstoneFloorW(Serial serial) : base(serial)
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

	public class DarkSandstoneFloorN : BaseFloor
	{
		[Constructable]
		public DarkSandstoneFloorN() : base(0x52F, 4)
		{
		}

		public DarkSandstoneFloorN(Serial serial) : base(serial)
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

	public class DarkSandstoneFloorW : BaseFloor
	{
		[Constructable]
		public DarkSandstoneFloorW() : base(0x533, 4)
		{
		}

		public DarkSandstoneFloorW(Serial serial) : base(serial)
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