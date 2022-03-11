namespace Server.Mobiles
{
	[CorpseName("a deer corpse")]
	public class EnragedHart : BaseEnraged
	{
		public EnragedHart(Mobile summoner) : base(summoner)
		{
			Name = "a great hart";
			Body = 0xea;
		}

		public override int GetAttackSound()
		{
			return 0x82;
		}

		public override int GetHurtSound()
		{
			return 0x83;
		}

		public override int GetDeathSound()
		{
			return 0x84;
		}

		public EnragedHart(Serial serial) : base(serial)
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