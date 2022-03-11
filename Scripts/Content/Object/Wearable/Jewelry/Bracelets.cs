namespace Server.Items
{
	/// GoldBracelet
	public class GoldBracelet : BaseBracelet
	{
		[Constructable]
		public GoldBracelet() : base(0x1086)
		{
			Weight = 0.1;
		}

		public GoldBracelet(Serial serial) : base(serial)
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

	/// SilverBracelet
	public class SilverBracelet : BaseBracelet
	{
		[Constructable]
		public SilverBracelet() : base(0x1F06)
		{
			Weight = 0.1;
		}

		public SilverBracelet(Serial serial) : base(serial)
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
