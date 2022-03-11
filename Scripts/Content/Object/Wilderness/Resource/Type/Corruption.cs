namespace Server.Items
{
	public class Corruption : Item
	{
		[Constructable]
		public Corruption()
			: this(1)
		{
		}

		[Constructable]
		public Corruption(int amountFrom, int amountTo)
			: this(Utility.RandomMinMax(amountFrom, amountTo))
		{
		}

		[Constructable]
		public Corruption(int amount)
			: base(0x3184)
		{
			Stackable = true;
			Amount = amount;
		}

		public Corruption(Serial serial)
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
		}
	}
}