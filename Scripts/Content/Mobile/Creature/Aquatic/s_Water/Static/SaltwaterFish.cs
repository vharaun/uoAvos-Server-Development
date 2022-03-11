namespace Server.Items
{
	public class SaltwaterFish : Item, ICarvable
	{
		public void Carve(Mobile from, Item item)
		{
			base.ScissorHelper(from, new RawSaltwaterFishSteak(), 4);
		}

		[Constructable]
		public SaltwaterFish() : this(1)
		{
		}

		[Constructable]
		public SaltwaterFish(int amount) : base(Utility.Random(0x09CC, 4))
		{
			Name = "Saltwater Fish";
			Weight = 1.0;
			Amount = amount;

			Stackable = true;
		}

		public SaltwaterFish(Serial serial) : base(serial)
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