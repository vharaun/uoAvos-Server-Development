namespace Server.Items
{
	public class BrazierArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 2;

		[Constructable]
		public BrazierArtifact() : base(0xE31)
		{
			Light = LightType.Circle150;
		}

		public BrazierArtifact(Serial serial) : base(serial)
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