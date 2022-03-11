namespace Server.Items
{
	public class SeaHorseFish : BaseAquaticLife
	{
		public override int LabelNumber => 1074414;  // A sea horse

		[Constructable]
		public SeaHorseFish() : base(0x3B10)
		{
		}

		public SeaHorseFish(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}