namespace Server.Engines.Stealables
{
	public class EmptyJar : Item
	{
		[Constructable]
		public EmptyJar()
			: base(0x1005)
		{
			Movable = true;
			Stackable = false;
		}

		public EmptyJar(Serial serial)
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