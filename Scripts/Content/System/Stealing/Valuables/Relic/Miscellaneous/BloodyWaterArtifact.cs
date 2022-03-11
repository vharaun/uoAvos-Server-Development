namespace Server.Items
{
	public class BloodyWaterArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 5;

		[Constructable]
		public BloodyWaterArtifact() : base(0xE23)
		{
		}

		public BloodyWaterArtifact(Serial serial) : base(serial)
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