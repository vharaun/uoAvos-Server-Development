namespace Server.Engines.Stealables
{
	public class DirtyKettle : Item
	{
		[Constructable]
		public DirtyKettle() : base(0x9DC)
		{
			Weight = 1.0;
		}

		public DirtyKettle(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}