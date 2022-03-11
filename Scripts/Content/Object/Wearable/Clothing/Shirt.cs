namespace Server.Items
{
	/// Shirt
	[FlipableAttribute(0x1517, 0x1518)]
	public class Shirt : BaseShirt
	{
		[Constructable]
		public Shirt() : this(0)
		{
		}

		[Constructable]
		public Shirt(int hue) : base(0x1517, hue)
		{
			Weight = 1.0;
		}

		public Shirt(Serial serial) : base(serial)
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

			if (Weight == 2.0)
			{
				Weight = 1.0;
			}
		}
	}

	/// FormalShirt
	[Flipable(0x2310, 0x230F)]
	public class FormalShirt : BaseMiddleTorso
	{
		[Constructable]
		public FormalShirt() : this(0)
		{
		}

		[Constructable]
		public FormalShirt(int hue) : base(0x2310, hue)
		{
			Weight = 1.0;
		}

		public FormalShirt(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			if (Weight == 2.0)
			{
				Weight = 1.0;
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	/// FancyShirt
	[FlipableAttribute(0x1efd, 0x1efe)]
	public class FancyShirt : BaseShirt
	{
		[Constructable]
		public FancyShirt() : this(0)
		{
		}

		[Constructable]
		public FancyShirt(int hue) : base(0x1EFD, hue)
		{
			Weight = 2.0;
		}

		public FancyShirt(Serial serial) : base(serial)
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

	/// Tunic
	[Flipable(0x1fa1, 0x1fa2)]
	public class Tunic : BaseMiddleTorso
	{
		[Constructable]
		public Tunic() : this(0)
		{
		}

		[Constructable]
		public Tunic(int hue) : base(0x1FA1, hue)
		{
			Weight = 5.0;
		}

		public Tunic(Serial serial) : base(serial)
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

	/// Doublet
	[Flipable(0x1f7b, 0x1f7c)]
	public class Doublet : BaseMiddleTorso
	{
		[Constructable]
		public Doublet() : this(0)
		{
		}

		[Constructable]
		public Doublet(int hue) : base(0x1F7B, hue)
		{
			Weight = 2.0;
		}

		public Doublet(Serial serial) : base(serial)
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

	/// ElvenShirt
	public class ElvenShirt : BaseShirt
	{
		public override Race RequiredRace => Race.Elf;

		[Constructable]
		public ElvenShirt() : this(0)
		{
		}

		[Constructable]
		public ElvenShirt(int hue) : base(0x3175, hue)
		{
			Weight = 2.0;
		}

		public ElvenShirt(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	/// ElvenDarkShirt
	public class ElvenDarkShirt : BaseShirt
	{
		public override Race RequiredRace => Race.Elf;
		[Constructable]
		public ElvenDarkShirt() : this(0)
		{
		}

		[Constructable]
		public ElvenDarkShirt(int hue) : base(0x3176, hue)
		{
			Weight = 2.0;
		}

		public ElvenDarkShirt(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}
}