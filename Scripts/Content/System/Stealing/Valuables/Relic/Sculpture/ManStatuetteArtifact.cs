namespace Server.Items
{
	/// Facing South
	public class ManStatuetteSouthArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 9;

		[Constructable]
		public ManStatuetteSouthArtifact() : base(0x2848)
		{
		}

		public ManStatuetteSouthArtifact(Serial serial) : base(serial)
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

	/// Facing: East
	public class ManStatuetteEastArtifact : BaseDecorationArtifact
	{
		public override int ArtifactRarity => 9;

		[Constructable]
		public ManStatuetteEastArtifact() : base(0x2849)
		{
		}

		public ManStatuetteEastArtifact(Serial serial) : base(serial)
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