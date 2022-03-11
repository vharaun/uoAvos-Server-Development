namespace Server.Items
{
	public class AshBoard : Board
	{
		[Constructable]
		public AshBoard()
			: this(1)
		{
		}

		[Constructable]
		public AshBoard(int amount)
			: base(CraftResource.AshWood, amount)
		{
		}

		public AshBoard(Serial serial)
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