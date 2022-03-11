namespace Server.Items
{
	/// Facing: North
	public class TeapotNorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 3;

		[Constructable]
		public TeapotNorthArtifact() : base(0x24E6)
		{
		}

		public TeapotNorthArtifact(Serial serial) : base(serial)
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
	public class TeapotWestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 3;

		[Constructable]
		public TeapotWestArtifact() : base(0x24E7)
		{
		}

		public TeapotWestArtifact(Serial serial) : base(serial)
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