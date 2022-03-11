namespace Server.Mobiles
{
	public class EtherealHorse : EtherealMount
	{
		public override int LabelNumber => 1041298;  // Ethereal Horse Statuette

		[Constructable]
		public EtherealHorse()
			: base(0x20DD, 0x3EAA)
		{
		}

		public EtherealHorse(Serial serial)
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

			if (Name == "an ethereal horse")
			{
				Name = null;
			}

			if (ItemID == 0x2124)
			{
				ItemID = 0x20DD;
			}
		}
	}
}