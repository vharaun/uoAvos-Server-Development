namespace Server.Items
{
	/// Facing: North
	public class Painting4NorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 6;

		[Constructable]
		public Painting4NorthArtifact() : base(0x2411)
		{
		}

		public Painting4NorthArtifact(Serial serial) : base(serial)
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
	public class Painting4WestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 6;

		[Constructable]
		public Painting4WestArtifact() : base(0x2412)
		{
		}

		public Painting4WestArtifact(Serial serial) : base(serial)
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