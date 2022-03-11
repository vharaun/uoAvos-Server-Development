namespace Server.Items
{
	/// Skirt
	[Flipable(0x1516, 0x1531)]
	public class Skirt : BaseOuterLegs
	{
		[Constructable]
		public Skirt() : this(0)
		{
		}

		[Constructable]
		public Skirt(int hue) : base(0x1516, hue)
		{
			Weight = 4.0;
		}

		public Skirt(Serial serial) : base(serial)
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

	/// Kilt
	[Flipable(0x1537, 0x1538)]
	public class Kilt : BaseOuterLegs
	{
		[Constructable]
		public Kilt() : this(0)
		{
		}

		[Constructable]
		public Kilt(int hue) : base(0x1537, hue)
		{
			Weight = 2.0;
		}

		public Kilt(Serial serial) : base(serial)
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