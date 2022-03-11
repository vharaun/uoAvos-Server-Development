namespace Server.Mobiles
{
	public class EtherealOstard : EtherealMount
	{
		public override int LabelNumber => 1041299;  // Ethereal Ostard Statuette

		[Constructable]
		public EtherealOstard()
			: base(0x2135, 0x3EAC)
		{
		}

		public EtherealOstard(Serial serial)
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

			if (Name == "an ethereal ostard")
			{
				Name = null;
			}
		}
	}
}