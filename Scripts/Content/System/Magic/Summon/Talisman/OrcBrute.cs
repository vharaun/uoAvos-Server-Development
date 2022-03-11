namespace Server.Mobiles
{
	public class SummonedOrcBrute : BaseTalismanSummon
	{
		[Constructable]
		public SummonedOrcBrute() : base()
		{
			Body = 189;
			Name = "an orc brute";
			BaseSoundID = 0x45A;
		}

		public SummonedOrcBrute(Serial serial) : base(serial)
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