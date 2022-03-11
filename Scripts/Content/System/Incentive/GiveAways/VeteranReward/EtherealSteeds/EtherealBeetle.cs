namespace Server.Mobiles
{
	public class EtherealBeetle : EtherealMount
	{
		public override int LabelNumber => 1049748;  // Ethereal Beetle Statuette

		[Constructable]
		public EtherealBeetle()
			: base(0x260F, 0x3E97)
		{
		}

		public EtherealBeetle(Serial serial)
			: base(serial)
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

			if (Name == "an ethereal beetle")
			{
				Name = null;
			}
		}
	}
}