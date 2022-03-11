namespace Server.Items
{
	/// Necklace
	public class Necklace : BaseNecklace
	{
		[Constructable]
		public Necklace() : base(0x1085)
		{
			Weight = 0.1;
		}

		public Necklace(Serial serial) : base(serial)
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

	/// GoldNecklace
	public class GoldNecklace : BaseNecklace
	{
		[Constructable]
		public GoldNecklace() : base(0x1088)
		{
			Weight = 0.1;
		}

		public GoldNecklace(Serial serial) : base(serial)
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

	/// GoldBeadNecklace
	public class GoldBeadNecklace : BaseNecklace
	{
		[Constructable]
		public GoldBeadNecklace() : base(0x1089)
		{
			Weight = 0.1;
		}

		public GoldBeadNecklace(Serial serial) : base(serial)
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

	/// SilverNecklace
	public class SilverNecklace : BaseNecklace
	{
		[Constructable]
		public SilverNecklace() : base(0x1F08)
		{
			Weight = 0.1;
		}

		public SilverNecklace(Serial serial) : base(serial)
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

	/// SilverBeadNecklace
	public class SilverBeadNecklace : BaseNecklace
	{
		[Constructable]
		public SilverBeadNecklace() : base(0x1F05)
		{
			Weight = 0.1;
		}

		public SilverBeadNecklace(Serial serial) : base(serial)
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
