namespace Server.Mobiles
{
	public class EtherealLlama : EtherealMount
	{
		public override int LabelNumber => 1041300;  // Ethereal Llama Statuette

		[Constructable]
		public EtherealLlama()
			: base(0x20F6, 0x3EAB)
		{
		}

		public EtherealLlama(Serial serial)
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

			if (Name == "an ethereal llama")
			{
				Name = null;
			}
		}
	}
}