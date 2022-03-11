namespace Server.Items
{
	public class Basket2Artifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 1;

		[Constructable]
		public Basket2Artifact() : base(0x24D7)
		{
		}

		public Basket2Artifact(Serial serial) : base(serial)
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