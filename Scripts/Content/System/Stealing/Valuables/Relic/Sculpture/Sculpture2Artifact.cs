namespace Server.Items
{
	public class Sculpture2Artifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 3;

		[Constructable]
		public Sculpture2Artifact() : base(0x241B)
		{
		}

		public Sculpture2Artifact(Serial serial) : base(serial)
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