namespace Server.Engines.Stealables
{
	public class ForgedMetal : Item
	{
		[Constructable]
		public ForgedMetal() : base(0xFB8)
		{
			Weight = 5.0;
		}

		public ForgedMetal(Serial serial) : base(serial)
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