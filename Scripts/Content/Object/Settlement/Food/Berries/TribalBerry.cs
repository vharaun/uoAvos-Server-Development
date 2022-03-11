namespace Server.Items
{
	public class TribalBerry : Food
	{
		[Constructable]
		public TribalBerry() : this(1)
		{
		}

		[Constructable]
		public TribalBerry(int amount) : base(0x9D0)
		{
			Name = "Tribal Berry";
			Weight = 1.0;
			Hue = 6;

			Amount = amount;
			FillFactor = 1;
			Stackable = true;
		}

		public TribalBerry(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (Hue == 4)
			{
				Hue = 6;
			}
		}
	}
}