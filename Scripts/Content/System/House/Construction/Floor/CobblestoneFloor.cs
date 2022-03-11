namespace Server.Items
{
	public class CobblestonesFloor : BaseFloor
	{
		[Constructable]
		public CobblestonesFloor() : base(0x515, 4)
		{
		}

		public CobblestonesFloor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}