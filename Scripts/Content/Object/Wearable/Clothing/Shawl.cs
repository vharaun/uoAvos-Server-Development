namespace Server.Items
{
	/// FurSarong
	[Flipable(0x230C, 0x230B)]
	public class FurSarong : BaseOuterLegs
	{
		[Constructable]
		public FurSarong() : this(0)
		{
		}

		[Constructable]
		public FurSarong(int hue) : base(0x230C, hue)
		{
			Weight = 3.0;
		}

		public FurSarong(Serial serial) : base(serial)
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

			if (Weight == 4.0)
			{
				Weight = 3.0;
			}
		}
	}
}