namespace Server.Items
{
	public class OakBoard : Board
	{
		[Constructable]
		public OakBoard()
			: this(1)
		{
		}

		[Constructable]
		public OakBoard(int amount)
			: base(CraftResource.OakWood, amount)
		{
		}

		public OakBoard(Serial serial)
			: base(serial)
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