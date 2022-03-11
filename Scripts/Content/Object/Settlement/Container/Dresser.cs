namespace Server.Items
{
	/// Drawer
	[Furniture]
	[Flipable(0xa2c, 0xa34)]
	public class Drawer : BaseContainer
	{
		[Constructable]
		public Drawer() : base(0xA2C)
		{
			Weight = 1.0;
		}

		public Drawer(Serial serial) : base(serial)
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

	/// FancyDrawer
	[Furniture]
	[Flipable(0xa30, 0xa38)]
	public class FancyDrawer : BaseContainer
	{
		[Constructable]
		public FancyDrawer() : base(0xA30)
		{
			Weight = 1.0;
		}

		public FancyDrawer(Serial serial) : base(serial)
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

	/// PlainWoodenChest
	[Furniture]
	[Flipable(0x280B, 0x280C)]
	public class PlainWoodenChest : LockableContainer
	{
		[Constructable]
		public PlainWoodenChest() : base(0x280B)
		{
		}

		public PlainWoodenChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 0 && Weight == 15)
			{
				Weight = -1;
			}
		}
	}

	/// OrnateWoodenChest
	[Furniture]
	[Flipable(0x280D, 0x280E)]
	public class OrnateWoodenChest : LockableContainer
	{
		[Constructable]
		public OrnateWoodenChest() : base(0x280D)
		{
		}

		public OrnateWoodenChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 0 && Weight == 15)
			{
				Weight = -1;
			}
		}
	}

	/// GildedWoodenChest
	[Furniture]
	[Flipable(0x280F, 0x2810)]
	public class GildedWoodenChest : LockableContainer
	{
		[Constructable]
		public GildedWoodenChest() : base(0x280F)
		{
		}

		public GildedWoodenChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 0 && Weight == 15)
			{
				Weight = -1;
			}
		}
	}

	/// FinishedWoodenChest
	[Furniture]
	[Flipable(0x2813, 0x2814)]
	public class FinishedWoodenChest : LockableContainer
	{
		[Constructable]
		public FinishedWoodenChest() : base(0x2813)
		{
		}

		public FinishedWoodenChest(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			if (version == 0 && Weight == 15)
			{
				Weight = -1;
			}
		}
	}

	/// TallCabinet
	[Furniture]
	[Flipable(0x2815, 0x2816)]
	public class TallCabinet : BaseContainer
	{
		[Constructable]
		public TallCabinet() : base(0x2815)
		{
			Weight = 1.0;
		}

		public TallCabinet(Serial serial) : base(serial)
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

	/// ShortCabinet
	[Furniture]
	[Flipable(0x2817, 0x2818)]
	public class ShortCabinet : BaseContainer
	{
		[Constructable]
		public ShortCabinet() : base(0x2817)
		{
			Weight = 1.0;
		}

		public ShortCabinet(Serial serial) : base(serial)
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