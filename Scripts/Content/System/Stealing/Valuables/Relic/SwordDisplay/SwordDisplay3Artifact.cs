namespace Server.Items
{
	/// Facing: South
	public class SwordDisplay3SouthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 8;

		[Constructable]
		public SwordDisplay3SouthArtifact() : base(0x2855)
		{
		}

		public SwordDisplay3SouthArtifact(Serial serial) : base(serial)
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

	/// Facing East
	public class SwordDisplay3EastArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 8;

		[Constructable]
		public SwordDisplay3EastArtifact() : base(0x2856)
		{
		}

		public SwordDisplay3EastArtifact(Serial serial) : base(serial)
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