namespace Server.Items
{
	public class Coal : Item
	{
		public override string DefaultName => "Coal";

		[Constructable]
		public Coal() : base(0x19b9)
		{
			Stackable = false;
			LootType = LootType.Blessed;
			Hue = 0x965;
		}

		public Coal(Serial serial) : base(serial)
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