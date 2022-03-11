namespace Server.Items
{
	/// Facing: North
	public class Painting5NorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 8;

		[Constructable]
		public Painting5NorthArtifact() : base(0x2415)
		{
		}

		public Painting5NorthArtifact(Serial serial) : base(serial)
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
	public class Painting5WestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 8;

		[Constructable]
		public Painting5WestArtifact() : base(0x2416)
		{
		}

		public Painting5WestArtifact(Serial serial) : base(serial)
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