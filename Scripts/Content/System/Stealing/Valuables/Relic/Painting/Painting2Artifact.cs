namespace Server.Items
{
	/// Facing: North
	public class Painting2NorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 4;

		[Constructable]
		public Painting2NorthArtifact() : base(0x240F)
		{
		}

		public Painting2NorthArtifact(Serial serial) : base(serial)
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
	public class Painting2WestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 4;

		[Constructable]
		public Painting2WestArtifact() : base(0x2410)
		{
		}

		public Painting2WestArtifact(Serial serial) : base(serial)
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