namespace Server.Engines.Stealables
{
	public class EmptyJars4 : Item
	{
		[Constructable]
		public EmptyJars4()
			: base(0xe47)
		{
			Movable = true;
			Stackable = false;
		}

		public EmptyJars4(Serial serial)
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