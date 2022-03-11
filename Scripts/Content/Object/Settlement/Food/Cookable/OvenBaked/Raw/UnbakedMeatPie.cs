namespace Server.Items
{
	public class UnbakedMeatPie : CookableFood
	{
		public override int LabelNumber => 1041338;  // unbaked meat pie

		[Constructable]
		public UnbakedMeatPie() : base(0x1042, 25)
		{
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new MeatPie();
		}

		public UnbakedMeatPie(Serial serial) : base(serial)
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