namespace Server.Engines.Stealables
{
	public class Jars4 : Item
	{
		[Constructable]
		public Jars4()
			: base(0xE4f)
		{
			Movable = true;
			Stackable = false;
		}

		public Jars4(Serial serial)
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