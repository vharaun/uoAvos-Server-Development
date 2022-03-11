namespace Server.Items
{
	/// FillableMetalChest
	[Flipable(0x9AB, 0xE7C)]
	public class FillableMetalChest : FillableContainer
	{
		[Constructable]
		public FillableMetalChest()
			: base(0x9AB)
		{
		}

		public FillableMetalChest(Serial serial)
			: base(serial)
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

	/// FillableMetalGoldenChest
	[Flipable(0xE41, 0xE40)]
	public class FillableMetalGoldenChest : FillableContainer
	{
		[Constructable]
		public FillableMetalGoldenChest()
			: base(0xE41)
		{
		}

		public FillableMetalGoldenChest(Serial serial)
			: base(serial)
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

	/// FillableWoodenChest
	[Flipable(0xE43, 0xE42)]
	public class FillableWoodenChest : FillableContainer
	{
		[Constructable]
		public FillableWoodenChest()
			: base(0xE43)
		{
		}

		public FillableWoodenChest(Serial serial)
			: base(serial)
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

			if (version == 0 && Weight == 2)
			{
				Weight = -1;
			}
		}
	}
}