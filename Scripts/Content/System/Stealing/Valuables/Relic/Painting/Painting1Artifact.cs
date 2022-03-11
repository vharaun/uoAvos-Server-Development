namespace Server.Items
{
	/// Facing: North
	public class Painting1NorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 4;

		[Constructable]
		public Painting1NorthArtifact() : base(0x240D)
		{
		}

		public Painting1NorthArtifact(Serial serial) : base(serial)
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
	public class Painting1WestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 4;

		[Constructable]
		public Painting1WestArtifact() : base(0x240E)
		{
		}

		public Painting1WestArtifact(Serial serial) : base(serial)
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