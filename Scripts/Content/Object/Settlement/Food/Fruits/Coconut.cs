namespace Server.Items
{
	public class Coconut : Food
	{
		[Constructable]
		public Coconut() : this(1)
		{
		}

		[Constructable]
		public Coconut(int amount) : base(amount, 0x1726)
		{
			Weight = 1.0;
			FillFactor = 1;
		}

		public Coconut(Serial serial) : base(serial)
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

	public class SplitCoconut : Food
	{
		[Constructable]
		public SplitCoconut() : this(1)
		{
		}

		[Constructable]
		public SplitCoconut(int amount) : base(amount, 0x1725)
		{
			Weight = 1.0;
			FillFactor = 1;
		}

		public SplitCoconut(Serial serial) : base(serial)
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

	public class OpenCoconut : Food
	{
		[Constructable]
		public OpenCoconut() : this(1)
		{
		}

		[Constructable]
		public OpenCoconut(int amount) : base(amount, 0x1723)
		{
			Weight = 1.0;
			FillFactor = 1;
		}

		public OpenCoconut(Serial serial) : base(serial)
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