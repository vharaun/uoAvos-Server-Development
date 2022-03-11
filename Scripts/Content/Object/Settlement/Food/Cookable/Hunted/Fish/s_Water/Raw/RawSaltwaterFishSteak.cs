namespace Server.Items
{
	public class RawSaltwaterFishSteak : CookableFood
	{
		public override double DefaultWeight => 0.1;

		[Constructable]
		public RawSaltwaterFishSteak() : this(1)
		{
		}

		[Constructable]
		public RawSaltwaterFishSteak(int amount) : base(0x097A, 10)
		{
			Stackable = true;
			Amount = amount;
		}

		public RawSaltwaterFishSteak(Serial serial) : base(serial)
		{
		}

		public override Food Cook()
		{
			return new SaltwaterFishSteak();
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