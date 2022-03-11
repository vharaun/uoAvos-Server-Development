namespace Server.Engines.Stealables
{
	public class EmptyJars3 : Item
	{
		[Constructable]
		public EmptyJars3()
			: base(0xe46)
		{
			Movable = true;
			Stackable = false;
		}

		public EmptyJars3(Serial serial)
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