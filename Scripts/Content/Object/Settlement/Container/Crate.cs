namespace Server.Items
{
	/// SmallCrate
	[Furniture]
	[Flipable(0x9A9, 0xE7E)]
	public class SmallCrate : LockableContainer
	{
		[Constructable]
		public SmallCrate() : base(0x9A9)
		{
			Weight = 2.0;
		}

		public SmallCrate(Serial serial) : base(serial)
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

			if (Weight == 4.0)
			{
				Weight = 2.0;
			}
		}
	}

	/// MediumCrate
	[Furniture]
	[Flipable(0xE3F, 0xE3E)]
	public class MediumCrate : LockableContainer
	{
		[Constructable]
		public MediumCrate() : base(0xE3F)
		{
			Weight = 2.0;
		}

		public MediumCrate(Serial serial) : base(serial)
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

			if (Weight == 6.0)
			{
				Weight = 2.0;
			}
		}
	}

	/// LargeCrate
	[Furniture]
	[Flipable(0xE3D, 0xE3C)]
	public class LargeCrate : LockableContainer
	{
		[Constructable]
		public LargeCrate() : base(0xE3D)
		{
			Weight = 1.0;
		}

		public LargeCrate(Serial serial) : base(serial)
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

			if (Weight == 8.0)
			{
				Weight = 1.0;
			}
		}
	}
}