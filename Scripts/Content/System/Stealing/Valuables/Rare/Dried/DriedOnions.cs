namespace Server.Engines.Stealables
{
	public class DriedOnions : Item
	{
		[Constructable]
		public DriedOnions() : this(1)
		{
		}

		[Constructable]
		public DriedOnions(int amount) : base(0xC40)
		{
			Stackable = true;
			Weight = 1.0;
			Amount = amount;
		}

		public DriedOnions(Serial serial) : base(serial)
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