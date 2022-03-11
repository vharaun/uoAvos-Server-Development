namespace Server.Items
{
	public class FreshwaterFish : Item, ICarvable
	{
		public void Carve(Mobile from, Item item)
		{
			base.ScissorHelper(from, new RawFreshwaterFishSteak(), 4);
		}

		[Constructable]
		public FreshwaterFish() : this(1)
		{
		}

		[Constructable]
		public FreshwaterFish(int amount) : base(Utility.Random(0x09CC, 4))
		{
			Name = "Freshwater Fish";
			Weight = 1.0;
			Amount = amount;

			Stackable = true;
		}

		public FreshwaterFish(Serial serial) : base(serial)
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