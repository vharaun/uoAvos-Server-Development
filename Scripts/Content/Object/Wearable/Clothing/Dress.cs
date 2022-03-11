namespace Server.Items
{
	/// PlainDress
	[Flipable(0x1f01, 0x1f02)]
	public class PlainDress : BaseOuterTorso
	{
		[Constructable]
		public PlainDress() : this(0)
		{
		}

		[Constructable]
		public PlainDress(int hue) : base(0x1F01, hue)
		{
			Weight = 2.0;
		}

		public PlainDress(Serial serial) : base(serial)
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

			if (Weight == 3.0)
			{
				Weight = 2.0;
			}
		}
	}

	/// GildedDress
	[Flipable(0x230E, 0x230D)]
	public class GildedDress : BaseOuterTorso
	{
		[Constructable]
		public GildedDress() : this(0)
		{
		}

		[Constructable]
		public GildedDress(int hue) : base(0x230E, hue)
		{
			Weight = 3.0;
		}

		public GildedDress(Serial serial) : base(serial)
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

	/// FancyDress
	[Flipable(0x1F00, 0x1EFF)]
	public class FancyDress : BaseOuterTorso
	{
		[Constructable]
		public FancyDress() : this(0)
		{
		}

		[Constructable]
		public FancyDress(int hue) : base(0x1F00, hue)
		{
			Weight = 3.0;
		}

		public FancyDress(Serial serial) : base(serial)
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

	/// Kamishimo
	[Flipable(0x2799, 0x27E4)]
	public class Kamishimo : BaseOuterTorso
	{
		[Constructable]
		public Kamishimo() : this(0)
		{
		}

		[Constructable]
		public Kamishimo(int hue) : base(0x2799, hue)
		{
			Weight = 3.0;
		}

		public Kamishimo(Serial serial) : base(serial)
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

	/// HakamaShita
	[Flipable(0x279C, 0x27E7)]
	public class HakamaShita : BaseOuterTorso
	{
		[Constructable]
		public HakamaShita() : this(0)
		{
		}

		[Constructable]
		public HakamaShita(int hue) : base(0x279C, hue)
		{
			Weight = 3.0;
		}

		public HakamaShita(Serial serial) : base(serial)
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