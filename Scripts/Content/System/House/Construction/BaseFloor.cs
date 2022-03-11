namespace Server.Items
{
	public abstract class BaseFloor : Item
	{
		public BaseFloor(int itemID, int count) : base(Utility.Random(itemID, count))
		{
			Movable = false;
		}

		public BaseFloor(Serial serial) : base(serial)
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