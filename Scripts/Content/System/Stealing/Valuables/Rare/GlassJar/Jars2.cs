namespace Server.Engines.Stealables
{
	public class Jars2 : Item
	{
		[Constructable]
		public Jars2()
			: base(0xE4d)
		{
			Movable = true;
			Stackable = false;
		}

		public Jars2(Serial serial)
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