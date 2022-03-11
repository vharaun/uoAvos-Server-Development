namespace Server.Items
{
	public class Basket4Artifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 2;

		[Constructable]
		public Basket4Artifact() : base(0x24D8)
		{
		}

		public Basket4Artifact(Serial serial) : base(serial)
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