namespace Server.Engines.Stealables
{
	public class GreenDriedFlowers : Item
	{
		[Constructable]
		public GreenDriedFlowers() : this(1)
		{
		}

		[Constructable]
		public GreenDriedFlowers(int amount) : base(0xC3E)
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
		}

		public GreenDriedFlowers(Serial serial) : base(serial)
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
		}
	}
}