namespace Server.Items
{
	public class Lime : Food
	{
		[Constructable]
		public Lime() : this(1)
		{
		}

		[Constructable]
		public Lime(int amount) : base(amount, 0x172a)
		{
			Weight = 1.0;
			FillFactor = 1;
		}

		public Lime(Serial serial) : base(serial)
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

	public class Limes : Food
	{
		[Constructable]
		public Limes() : this(1)
		{
		}

		[Constructable]
		public Limes(int amount) : base(amount, 0x172B)
		{
			Weight = 1.0;
			FillFactor = 1;
		}

		public Limes(Serial serial) : base(serial)
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