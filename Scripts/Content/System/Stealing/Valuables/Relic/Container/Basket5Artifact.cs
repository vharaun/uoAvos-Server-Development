namespace Server.Items
{
	/// Facing North
	public class Basket5NorthArtifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 2;

		[Constructable]
		public Basket5NorthArtifact() : base(0x24DB)
		{
		}

		public Basket5NorthArtifact(Serial serial) : base(serial)
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
	public class Basket5WestArtifact : BaseDecorationContainerArtifact
	{
		public override int ArtifactRarity => 2;

		[Constructable]
		public Basket5WestArtifact() : base(0x24DC)
		{
		}

		public Basket5WestArtifact(Serial serial) : base(serial)
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