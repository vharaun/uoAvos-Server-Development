namespace Server.Items
{
	public class FlowersArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 7;

		[Constructable]
		public FlowersArtifact() : base(0x284A)
		{
		}

		public FlowersArtifact(Serial serial) : base(serial)
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