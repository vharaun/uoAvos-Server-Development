namespace Server.Items
{
	/// FillableFruitBasket
	public class FillableFruitBasket : FillableContainer
	{
		public override bool IsLockable => false;

		public override int SpawnThreshold => 5;

		public override FillableContentType DefaultContent => FillableContentType.FruitBasket;

		[Constructable]
		public FillableFruitBasket() : base(0x993)
		{
			Name = "A Fruit Basket";
			GumpID = 0x41;

			Weight = 1.0;
			Stackable = false;
		}

		public FillableFruitBasket(Serial serial) : base(serial)
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