namespace Server.Items
{
	public class BottleArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 1;

		[Constructable]
		public BottleArtifact() : base(0xE28)
		{
		}

		public BottleArtifact(Serial serial) : base(serial)
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