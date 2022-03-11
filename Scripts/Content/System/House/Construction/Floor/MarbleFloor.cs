namespace Server.Items
{
	public class MarbleFloor : BaseFloor
	{
		[Constructable]
		public MarbleFloor() : base(0x50D, 2)
		{
		}

		public MarbleFloor(Serial serial) : base(serial)
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

	public class GreenMarbleFloor : BaseFloor
	{
		[Constructable]
		public GreenMarbleFloor() : base(0x50F, 2)
		{
		}

		public GreenMarbleFloor(Serial serial) : base(serial)
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

	public class GreyMarbleFloor : BaseFloor
	{
		[Constructable]
		public GreyMarbleFloor() : base(0x511, 4)
		{
		}

		public GreyMarbleFloor(Serial serial) : base(serial)
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

	public class MarblePavers : BaseFloor
	{
		[Constructable]
		public MarblePavers() : base(0x495, 4)
		{
		}

		public MarblePavers(Serial serial) : base(serial)
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