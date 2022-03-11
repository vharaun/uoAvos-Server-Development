namespace Server.Items
{
	public class BloodwoodBoard : Board
	{
		[Constructable]
		public BloodwoodBoard()
			: this(1)
		{
		}

		[Constructable]
		public BloodwoodBoard(int amount)
			: base(CraftResource.Bloodwood, amount)
		{
		}

		public BloodwoodBoard(Serial serial)
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