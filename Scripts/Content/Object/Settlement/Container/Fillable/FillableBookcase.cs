namespace Server.Items
{
	/// LibraryBookcase
	[Flipable(0xA97, 0xA99, 0xA98, 0xA9A, 0xA9B, 0xA9C)]
	public class LibraryBookcase : FillableContainer
	{
		public override bool IsLockable => false;

		public override int SpawnThreshold => 5;

		public override FillableContentType DefaultContent => FillableContentType.Library;

		[Constructable]
		public LibraryBookcase()
			: base(0xA97)
		{
			Weight = 1.0;
		}

		public LibraryBookcase(Serial serial)
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