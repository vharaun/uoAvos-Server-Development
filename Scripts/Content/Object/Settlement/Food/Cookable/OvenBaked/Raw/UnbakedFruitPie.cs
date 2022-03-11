namespace Server.Items
{
	public class UnbakedFruitPie : CookableFood
	{
		public override int LabelNumber => 1041334;  // unbaked fruit pie

		[Constructable]
		public UnbakedFruitPie() : base(0x1042, 25)
		{
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new FruitPie();
		}

		public UnbakedFruitPie(Serial serial) : base(serial)
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