namespace Server.Items
{
	public class SakeArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 4;

		[Constructable]
		public SakeArtifact() : base(0x24E2)
		{
		}

		public SakeArtifact(Serial serial) : base(serial)
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