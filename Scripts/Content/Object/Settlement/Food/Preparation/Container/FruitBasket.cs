namespace Server.Items // Empty Basket: 0x0990  | Full Basket: 0x0993
{
	public class FruitBasket : BaseContainer
	{

		[Constructable]
		public FruitBasket() : base(0x0990)
		{
			Name = "A Fruit Basket";
			GumpID = 0x41;

			Weight = 1.0;
			Stackable = false;
		}

		public FruitBasket(Serial serial) : base(serial)
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