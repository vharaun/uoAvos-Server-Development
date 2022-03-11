namespace Server.Items
{
	public class SmallWatermelon : Food
	{
		[Constructable]
		public SmallWatermelon() : this(1)
		{
		}

		[Constructable]
		public SmallWatermelon(int amount) : base(amount, 0xC5D)
		{
			Weight = 5.0;
			FillFactor = 5;
		}

		public SmallWatermelon(Serial serial) : base(serial)
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