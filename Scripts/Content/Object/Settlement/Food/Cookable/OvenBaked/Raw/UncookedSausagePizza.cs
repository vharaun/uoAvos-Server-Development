namespace Server.Items
{
	public class UncookedSausagePizza : CookableFood
	{
		public override int LabelNumber => 1041337;  // uncooked sausage pizza

		[Constructable]
		public UncookedSausagePizza() : base(0x1083, 20)
		{
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new SausagePizza();
		}

		public UncookedSausagePizza(Serial serial) : base(serial)
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