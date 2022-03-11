namespace Server.Items
{
	/// FullApron
	[Flipable(0x153d, 0x153e)]
	public class FullApron : BaseMiddleTorso
	{
		[Constructable]
		public FullApron() : this(0)
		{
		}

		[Constructable]
		public FullApron(int hue) : base(0x153d, hue)
		{
			Weight = 4.0;
		}

		public FullApron(Serial serial) : base(serial)
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

	/// HalfApron
	[FlipableAttribute(0x153b, 0x153c)]
	public class HalfApron : BaseWaist
	{
		[Constructable]
		public HalfApron() : this(0)
		{
		}

		[Constructable]
		public HalfApron(int hue) : base(0x153b, hue)
		{
			Weight = 2.0;
		}

		public HalfApron(Serial serial) : base(serial)
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