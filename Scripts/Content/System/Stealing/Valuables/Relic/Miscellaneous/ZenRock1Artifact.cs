namespace Server.Items
{
	public class ZenRock1Artifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 2;

		[Constructable]
		public ZenRock1Artifact() : base(0x24E4)
		{
		}

		public ZenRock1Artifact(Serial serial) : base(serial)
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