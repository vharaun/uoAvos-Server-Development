namespace Server.Items
{
	[FlipableAttribute(0x1081, 0x1082)]
	public class SpinedLeather : BaseLeather
	{
		[Constructable]
		public SpinedLeather() : this(1)
		{
		}

		[Constructable]
		public SpinedLeather(int amount) : base(CraftResource.SpinedLeather, amount)
		{
		}

		public SpinedLeather(Serial serial) : base(serial)
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