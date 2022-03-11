namespace Server.Items
{
	/// Facing: North
	public class Painting6NorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 9;

		[Constructable]
		public Painting6NorthArtifact() : base(0x2417)
		{
		}

		public Painting6NorthArtifact(Serial serial) : base(serial)
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

	/// Facing: West
	public class Painting6WestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 9;

		[Constructable]
		public Painting6WestArtifact() : base(0x2418)
		{
		}

		public Painting6WestArtifact(Serial serial) : base(serial)
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