namespace Server.Items
{
	public class Ham : Food
	{
		[Constructable]
		public Ham() : this(1)
		{
		}

		[Constructable]
		public Ham(int amount) : base(amount, 0x09D3)
		{
			Weight = 1.0;
			FillFactor = 5;
		}

		public Ham(Serial serial) : base(serial)
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