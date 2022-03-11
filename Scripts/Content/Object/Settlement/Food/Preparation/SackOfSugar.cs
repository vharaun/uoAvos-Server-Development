namespace Server.Items
{
	public class SackOfSugar : Item
	{
		public override int LabelNumber => 1080003;  // Sack of sugar
		public override double DefaultWeight => 1.0;

		[Constructable]
		public SackOfSugar()
			: this(1)
		{
		}

		[Constructable]
		public SackOfSugar(int amount)
			: base(0x1039)
		{
			Hue = 0x461;
			Stackable = true;
			Amount = amount;
		}

		public SackOfSugar(Serial serial)
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