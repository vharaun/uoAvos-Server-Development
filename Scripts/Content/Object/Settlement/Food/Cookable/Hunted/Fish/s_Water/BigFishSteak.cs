namespace Server.Items
{
	public class BigFishSteak : Food
	{
		public override double DefaultWeight => 0.1;

		[Constructable]
		public BigFishSteak() : this(1)
		{
		}

		[Constructable]
		public BigFishSteak(int amount) : base(amount, 0x97B)
		{
			FillFactor = 3;
		}

		public BigFishSteak(Serial serial) : base(serial)
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