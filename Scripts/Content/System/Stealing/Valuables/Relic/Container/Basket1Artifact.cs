namespace Server.Items
{
	public class Basket1Artifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 1;

		[Constructable]
		public Basket1Artifact() : base(0x24DD)
		{
		}

		public Basket1Artifact(Serial serial) : base(serial)
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