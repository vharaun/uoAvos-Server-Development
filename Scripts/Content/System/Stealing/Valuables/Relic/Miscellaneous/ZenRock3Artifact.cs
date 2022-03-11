namespace Server.Items
{
	public class ZenRock3Artifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 3;

		[Constructable]
		public ZenRock3Artifact() : base(0x24E5)
		{
		}

		public ZenRock3Artifact(Serial serial) : base(serial)
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