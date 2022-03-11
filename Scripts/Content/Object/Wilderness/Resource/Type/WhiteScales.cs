namespace Server.Items
{
	public class WhiteScales : BaseScales
	{
		[Constructable]
		public WhiteScales() : this(1)
		{
		}

		[Constructable]
		public WhiteScales(int amount) : base(CraftResource.WhiteScales, amount)
		{
		}

		public WhiteScales(Serial serial) : base(serial)
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