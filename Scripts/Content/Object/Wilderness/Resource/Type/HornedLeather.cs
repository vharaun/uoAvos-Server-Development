namespace Server.Items
{
	[FlipableAttribute(0x1081, 0x1082)]
	public class HornedLeather : BaseLeather
	{
		[Constructable]
		public HornedLeather() : this(1)
		{
		}

		[Constructable]
		public HornedLeather(int amount) : base(CraftResource.HornedLeather, amount)
		{
		}

		public HornedLeather(Serial serial) : base(serial)
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