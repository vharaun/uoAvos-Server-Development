namespace Server.Items
{
	public class BlueScales : BaseScales
	{
		[Constructable]
		public BlueScales() : this(1)
		{
		}

		[Constructable]
		public BlueScales(int amount) : base(CraftResource.BlueScales, amount)
		{
		}

		public BlueScales(Serial serial) : base(serial)
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