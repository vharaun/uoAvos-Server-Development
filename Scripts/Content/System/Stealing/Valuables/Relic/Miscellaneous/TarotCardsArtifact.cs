namespace Server.Items
{
	public class TarotCardsArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 5;

		[Constructable]
		public TarotCardsArtifact() : base(0x12A5)
		{
		}

		public TarotCardsArtifact(Serial serial) : base(serial)
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