namespace Server.Mobiles
{
	public class SummonedDoppleganger : BaseTalismanSummon
	{
		[Constructable]
		public SummonedDoppleganger() : base()
		{
			Name = "a doppleganger";
			Body = 0x309;
			BaseSoundID = 0x451;
		}

		public SummonedDoppleganger(Serial serial) : base(serial)
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