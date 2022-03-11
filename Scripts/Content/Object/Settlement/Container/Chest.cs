namespace Server.Items
{
	/// MetalChest
	[DynamicFliping]
	[Flipable(0x9AB, 0xE7C)]
	public class MetalChest : LockableContainer
	{
		[Constructable]
		public MetalChest() : base(0x9AB)
		{
		}

		public MetalChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 0 && Weight == 25)
			{
				Weight = -1;
			}
		}
	}

	/// MetalGoldenChest
	[DynamicFliping]
	[Flipable(0xE41, 0xE40)]
	public class MetalGoldenChest : LockableContainer
	{
		[Constructable]
		public MetalGoldenChest() : base(0xE41)
		{
		}

		public MetalGoldenChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 0 && Weight == 25)
			{
				Weight = -1;
			}
		}
	}

	/// WoodenChest
	[Furniture]
	[Flipable(0xe43, 0xe42)]
	public class WoodenChest : LockableContainer
	{
		[Constructable]
		public WoodenChest() : base(0xe43)
		{
			Weight = 2.0;
		}

		public WoodenChest(Serial serial) : base(serial)
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

			if (Weight == 15.0)
			{
				Weight = 2.0;
			}
		}
	}
}