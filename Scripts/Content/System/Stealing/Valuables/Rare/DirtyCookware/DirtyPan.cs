namespace Server.Engines.Stealables
{
	public class DirtyPan : Item
	{
		[Constructable]
		public DirtyPan() : base(0x9E8)
		{
			Weight = 1.0;
		}

		public DirtyPan(Serial serial) : base(serial)
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