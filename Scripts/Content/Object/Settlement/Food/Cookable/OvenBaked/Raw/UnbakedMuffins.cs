namespace Server.Items
{
	public class UnbakedMuffins : CookableFood
	{
		[Constructable]
		public UnbakedMuffins() : base(0x1042, 25)
		{
			Name = "Unbaked Muffins";
			Hue = 0x0709;
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new Muffins();
		}

		public UnbakedMuffins(Serial serial) : base(serial)
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