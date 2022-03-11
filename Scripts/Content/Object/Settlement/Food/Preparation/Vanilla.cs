namespace Server.Items
{
	public class Vanilla : Item
	{
		public override int LabelNumber => 1080009;  // Vanilla
		public override double DefaultWeight => 1.0;

		[Constructable]
		public Vanilla()
			: this(1)
		{
		}

		[Constructable]
		public Vanilla(int amount)
			: base(0xE2A)
		{
			Hue = 0x462;
			Stackable = true;
			Amount = amount;
		}

		public Vanilla(Serial serial)
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