namespace Server.Items
{
	public class EggCaseArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 5;

		[Constructable]
		public EggCaseArtifact() : base(0x10D9)
		{
		}

		public EggCaseArtifact(Serial serial) : base(serial)
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