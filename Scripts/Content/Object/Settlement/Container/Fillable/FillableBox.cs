namespace Server.Items
{
	/// FillableWoodenBox
	[Flipable(0x9AA, 0xE7D)]
	public class FillableWoodenBox : FillableContainer
	{
		[Constructable]
		public FillableWoodenBox()
			: base(0x9AA)
		{
			Weight = 4.0;
		}

		public FillableWoodenBox(Serial serial)
			: base(serial)
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

	/// FillableMetalBox
	[Flipable(0x9A8, 0xE80)]
	public class FillableMetalBox : FillableContainer
	{
		[Constructable]
		public FillableMetalBox()
			: base(0x9A8)
		{
		}

		public FillableMetalBox(Serial serial)
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

			if (version == 0 && Weight == 3)
			{
				Weight = -1;
			}
		}
	}
}