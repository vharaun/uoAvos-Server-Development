namespace Server.Engines.Stealables
{
	public class Rope : Item
	{
		[Constructable]
		public Rope() : this(1)
		{
		}

		[Constructable]
		public Rope(int amount) : base(0x14F8)
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
		}

		public Rope(Serial serial) : base(serial)
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