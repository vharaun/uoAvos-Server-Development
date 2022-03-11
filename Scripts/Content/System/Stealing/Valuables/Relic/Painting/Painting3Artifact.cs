namespace Server.Items
{
	public class Painting3Artifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 5;

		[Constructable]
		public Painting3Artifact() : base(0x2411)
		{
		}

		public Painting3Artifact(Serial serial) : base(serial)
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