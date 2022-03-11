namespace Server.Items
{
	/// Facing: North
	public class SwordDisplay4NorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 9;

		[Constructable]
		public SwordDisplay4NorthArtifact() : base(0x2854)
		{
		}

		public SwordDisplay4NorthArtifact(Serial serial) : base(serial)
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
	public class SwordDisplay4WestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 8;

		[Constructable]
		public SwordDisplay4WestArtifact() : base(0x2853)
		{
		}

		public SwordDisplay4WestArtifact(Serial serial) : base(serial)
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