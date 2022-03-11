namespace Server.Items
{
	public class BlackScales : BaseScales
	{
		[Constructable]
		public BlackScales() : this(1)
		{
		}

		[Constructable]
		public BlackScales(int amount) : base(CraftResource.BlackScales, amount)
		{
		}

		public BlackScales(Serial serial) : base(serial)
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