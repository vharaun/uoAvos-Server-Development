namespace Server.Items
{
	/// FullBookcase
	[Furniture]
	[Flipable(0xa97, 0xa99, 0xa98, 0xa9a, 0xa9b, 0xa9c)]
	public class FullBookcase : BaseContainer
	{
		[Constructable]
		public FullBookcase() : base(0xA97)
		{
			Weight = 1.0;
		}

		public FullBookcase(Serial serial) : base(serial)
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

	/// EmptyBookcase
	[Furniture]
	[Flipable(0xa9d, 0xa9e)]
	public class EmptyBookcase : BaseContainer
	{
		[Constructable]
		public EmptyBookcase() : base(0xA9D)
		{
		}

		public EmptyBookcase(Serial serial) : base(serial)
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

			if (version == 0 && Weight == 1.0)
			{
				Weight = -1;
			}
		}
	}
}