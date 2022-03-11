namespace Server.Mobiles
{
	[CorpseName("an eagle corpse")]
	public class EnragedEagle : BaseEnraged
	{
		public EnragedEagle(Mobile summoner) : base(summoner)
		{
			Name = "an eagle";
			Body = 0x5;
			BaseSoundID = 0x2ee;
		}
		public EnragedEagle(Serial serial) : base(serial)
		{
		}
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}