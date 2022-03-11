namespace Server.Engines.Stealables
{
	public class DecoBridle2 : Item
	{

		[Constructable]
		public DecoBridle2() : base(0x1375)
		{
			Movable = true;
			Stackable = false;
		}

		public DecoBridle2(Serial serial) : base(serial)
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