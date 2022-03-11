namespace Server.Engines.Stealables
{
	public class DriedHerbs : Item
	{
		[Constructable]
		public DriedHerbs() : this(1)
		{
		}

		[Constructable]
		public DriedHerbs(int amount) : base(0xC42)
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
		}

		public DriedHerbs(Serial serial) : base(serial)
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