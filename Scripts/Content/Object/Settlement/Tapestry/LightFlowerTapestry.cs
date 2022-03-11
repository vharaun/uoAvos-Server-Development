namespace Server.Items
{
	/// Facing South
	public class LightFlowerTapestrySouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new LightFlowerTapestrySouthDeed();

		[Constructable]
		public LightFlowerTapestrySouthAddon()
		{
			AddComponent(new AddonComponent(0xFD9), 0, 0, 0);
			AddComponent(new AddonComponent(0xFDA), 1, 0, 0);
		}

		public LightFlowerTapestrySouthAddon(Serial serial) : base(serial)
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

	public class LightFlowerTapestrySouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new LightFlowerTapestrySouthAddon();
		public override int LabelNumber => 1049394;  // a flower tapestry deed facing south

		[Constructable]
		public LightFlowerTapestrySouthDeed()
		{
		}

		public LightFlowerTapestrySouthDeed(Serial serial) : base(serial)
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
	public class LightFlowerTapestryEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new LightFlowerTapestryEastDeed();

		[Constructable]
		public LightFlowerTapestryEastAddon()
		{
			AddComponent(new AddonComponent(0xFDC), 0, 0, 0);
			AddComponent(new AddonComponent(0xFDB), 0, 1, 0);
		}

		public LightFlowerTapestryEastAddon(Serial serial) : base(serial)
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

	public class LightFlowerTapestryEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new LightFlowerTapestryEastAddon();
		public override int LabelNumber => 1049393;  // a flower tapestry deed facing east

		[Constructable]
		public LightFlowerTapestryEastDeed()
		{
		}

		public LightFlowerTapestryEastDeed(Serial serial) : base(serial)
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