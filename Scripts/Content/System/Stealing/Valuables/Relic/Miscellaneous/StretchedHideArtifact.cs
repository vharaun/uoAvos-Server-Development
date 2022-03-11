namespace Server.Items
{
	public class StretchedHideArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 2;

		[Constructable]
		public StretchedHideArtifact() : base(0x106B)
		{
		}

		public StretchedHideArtifact(Serial serial) : base(serial)
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