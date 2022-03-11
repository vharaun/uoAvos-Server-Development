namespace Server.Items
{
	public class LeatherTunicArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 9;

		[Constructable]
		public LeatherTunicArtifact() : base(0x13CA)
		{
		}

		public LeatherTunicArtifact(Serial serial) : base(serial)
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