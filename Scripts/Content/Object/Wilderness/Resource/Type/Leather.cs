namespace Server.Items
{
	[FlipableAttribute(0x1081, 0x1082)]
	public class Leather : BaseLeather
	{
		[Constructable]
		public Leather() : this(1)
		{
		}

		[Constructable]
		public Leather(int amount) : base(CraftResource.RegularLeather, amount)
		{
		}

		public Leather(Serial serial) : base(serial)
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