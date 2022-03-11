namespace Server.Items
{
	public class CupsArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 4;

		[Constructable]
		public CupsArtifact() : base(0x24E1)
		{
		}

		public CupsArtifact(Serial serial) : base(serial)
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