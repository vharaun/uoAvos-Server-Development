namespace Server.Items
{
	public class BooksFaceDownArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 3;

		[Constructable]
		public BooksFaceDownArtifact() : base(0x1E21)
		{
		}

		public BooksFaceDownArtifact(Serial serial) : base(serial)
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