namespace Server.Items
{
	public class DamagedBooksArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 1;

		[Constructable]
		public DamagedBooksArtifact() : base(0xC16)
		{
		}

		public DamagedBooksArtifact(Serial serial) : base(serial)
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