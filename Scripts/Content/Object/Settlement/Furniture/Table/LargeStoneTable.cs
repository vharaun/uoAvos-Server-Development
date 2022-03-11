namespace Server.Items
{
	/// Facing South
	public class LargeStoneTableSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new LargeStoneTableSouthDeed();

		public override bool RetainDeedHue => true;

		[Constructable]
		public LargeStoneTableSouthAddon() : this(0)
		{
		}

		[Constructable]
		public LargeStoneTableSouthAddon(int hue)
		{
			AddComponent(new AddonComponent(0x1205), 0, 0, 0);
			AddComponent(new AddonComponent(0x1206), 1, 0, 0);
			AddComponent(new AddonComponent(0x1204), 2, 0, 0);
			Hue = hue;
		}

		public LargeStoneTableSouthAddon(Serial serial) : base(serial)
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
		}
	}

	public class LargeStoneTableSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new LargeStoneTableSouthAddon(Hue);
		public override int LabelNumber => 1044512;  // large stone table (South)

		[Constructable]
		public LargeStoneTableSouthDeed()
		{
		}

		public LargeStoneTableSouthDeed(Serial serial) : base(serial)
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

	/// Facing East
	public class LargeStoneTableEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new LargeStoneTableEastDeed();

		public override bool RetainDeedHue => true;

		[Constructable]
		public LargeStoneTableEastAddon() : this(0)
		{
		}

		[Constructable]
		public LargeStoneTableEastAddon(int hue)
		{
			AddComponent(new AddonComponent(0x1202), 0, 0, 0);
			AddComponent(new AddonComponent(0x1203), 0, 1, 0);
			AddComponent(new AddonComponent(0x1201), 0, 2, 0);
			Hue = hue;
		}

		public LargeStoneTableEastAddon(Serial serial) : base(serial)
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
		}
	}

	public class LargeStoneTableEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new LargeStoneTableEastAddon(Hue);
		public override int LabelNumber => 1044511;  // large stone table (east)

		[Constructable]
		public LargeStoneTableEastDeed()
		{
		}

		public LargeStoneTableEastDeed(Serial serial) : base(serial)
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