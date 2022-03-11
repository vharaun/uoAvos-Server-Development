namespace Server.Items
{
	/// Facing: North
	public class SwordDisplay2NorthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 6;

		[Constructable]
		public SwordDisplay2NorthArtifact() : base(0x2845)
		{
		}

		public SwordDisplay2NorthArtifact(Serial serial) : base(serial)
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
	public class SwordDisplay2WestArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 6;

		[Constructable]
		public SwordDisplay2WestArtifact() : base(0x2844)
		{
		}

		public SwordDisplay2WestArtifact(Serial serial) : base(serial)
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