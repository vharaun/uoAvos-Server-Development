namespace Server.Items
{
	/// Facing: North
	public class Basket3NorthArtifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 1;

		[Constructable]
		public Basket3NorthArtifact() : base(0x24DA)
		{
		}

		public Basket3NorthArtifact(Serial serial) : base(serial)
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

	/// Facing: West
	public class Basket3WestArtifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 1;

		[Constructable]
		public Basket3WestArtifact() : base(0x24D9)
		{
		}

		public Basket3WestArtifact(Serial serial) : base(serial)
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