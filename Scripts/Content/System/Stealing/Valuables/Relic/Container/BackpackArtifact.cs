namespace Server.Items
{
	public class BackpackArtifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 5;

		[Constructable]
		public BackpackArtifact() : base(0x9B2)
		{
		}

		public BackpackArtifact(Serial serial) : base(serial)
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