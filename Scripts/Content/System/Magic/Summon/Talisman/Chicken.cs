namespace Server.Mobiles
{
	public class SummonedChicken : BaseTalismanSummon
	{
		[Constructable]
		public SummonedChicken() : base()
		{
			Name = "a chicken";
			Body = 0xD0;
			BaseSoundID = 0x6E;
		}

		public SummonedChicken(Serial serial) : base(serial)
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