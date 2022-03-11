namespace Server.Engines.Stealables
{
	public class Jars3 : Item
	{
		[Constructable]
		public Jars3()
			: base(0xE4e)
		{
			Movable = true;
			Stackable = false;
		}

		public Jars3(Serial serial)
			: base(serial)
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