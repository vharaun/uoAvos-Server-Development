namespace Server.Engines.Stealables
{
	public class EmptyJars2 : Item
	{
		[Constructable]
		public EmptyJars2()
			: base(0xe45)
		{
			Movable = true;
			Stackable = false;
		}

		public EmptyJars2(Serial serial)

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