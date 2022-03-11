namespace Server.Engines.Stealables
{
	public class HalfEmptyJars : Item
	{
		[Constructable]
		public HalfEmptyJars()
			: base(0xe4c)
		{
			Movable = true;
			Stackable = false;
		}

		public HalfEmptyJars(Serial serial)
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