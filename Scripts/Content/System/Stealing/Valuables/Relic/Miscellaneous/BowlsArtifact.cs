namespace Server.Items
{
	/// Facing: Vertical
	public class BowlsVerticalArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 3;

		[Constructable]
		public BowlsVerticalArtifact() : base(0x24DF)
		{
		}

		public BowlsVerticalArtifact(Serial serial) : base(serial)
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

	/// Facing: Horizontal
	public class BowlsHorizontalArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 4;

		[Constructable]
		public BowlsHorizontalArtifact() : base(0x24E0)
		{
		}

		public BowlsHorizontalArtifact(Serial serial) : base(serial)
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