namespace Server.Items
{
	public class StonePaversLight : BaseFloor
	{
		[Constructable]
		public StonePaversLight() : base(0x519, 4)
		{
		}

		public StonePaversLight(Serial serial) : base(serial)
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

	public class StonePaversMedium : BaseFloor
	{
		[Constructable]
		public StonePaversMedium() : base(0x51D, 4)
		{
		}

		public StonePaversMedium(Serial serial) : base(serial)
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

	public class StonePaversDark : BaseFloor
	{
		[Constructable]
		public StonePaversDark() : base(0x521, 4)
		{
		}

		public StonePaversDark(Serial serial) : base(serial)
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