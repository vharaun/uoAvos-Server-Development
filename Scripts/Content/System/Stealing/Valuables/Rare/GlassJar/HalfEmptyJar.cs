namespace Server.Engines.Stealables
{
	public class HalfEmptyJar : Item
	{
		[Constructable]
		public HalfEmptyJar()
			: base(0x1007)
		{
			Movable = true;
			Stackable = false;
		}

		public HalfEmptyJar(Serial serial)
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