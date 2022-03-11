namespace Server.Items
{
	public class FrostwoodBoard : Board
	{
		[Constructable]
		public FrostwoodBoard()
			: this(1)
		{
		}

		[Constructable]
		public FrostwoodBoard(int amount)
			: base(CraftResource.Frostwood, amount)
		{
		}

		public FrostwoodBoard(Serial serial)
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