namespace Server.Items
{
	/// Facing: SouthEast
	public class SmallTowerSculpture : Item
	{
		[Constructable]
		public SmallTowerSculpture() : base(0x241A)
		{
			Weight = 20.0;
		}

		public SmallTowerSculpture(Serial serial) : base(serial)
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