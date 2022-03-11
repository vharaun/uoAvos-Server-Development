namespace Server.Items
{
	/// FillableSmallCrate
	[Flipable(0x9A9, 0xE7E)]
	public class FillableSmallCrate : FillableContainer
	{
		[Constructable]
		public FillableSmallCrate()
			: base(0x9A9)
		{
			Weight = 1.0;
		}

		public FillableSmallCrate(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// FillableLargeCrate
	[Flipable(0xE3D, 0xE3C)]
	public class FillableLargeCrate : FillableContainer
	{
		[Constructable]
		public FillableLargeCrate()
			: base(0xE3D)
		{
			Weight = 1.0;
		}

		public FillableLargeCrate(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}