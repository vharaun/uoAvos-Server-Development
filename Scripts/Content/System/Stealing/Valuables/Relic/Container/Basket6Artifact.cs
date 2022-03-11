namespace Server.Items
{
	public class Basket6Artifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 2;

		[Constructable]
		public Basket6Artifact() : base(0x24D5)
		{
		}

		public Basket6Artifact(Serial serial) : base(serial)
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