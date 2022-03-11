namespace Server.Items
{
	/// Facing South
	public class DarkFlowerTapestrySouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new DarkFlowerTapestrySouthDeed();

		[Constructable]
		public DarkFlowerTapestrySouthAddon()
		{
			AddComponent(new AddonComponent(0xFDD), 0, 0, 0);
			AddComponent(new AddonComponent(0xFDE), 1, 0, 0);
		}

		public DarkFlowerTapestrySouthAddon(Serial serial) : base(serial)
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

	public class DarkFlowerTapestrySouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new DarkFlowerTapestrySouthAddon();
		public override int LabelNumber => 1049396;  // a dark flower tapestry deed facing south

		[Constructable]
		public DarkFlowerTapestrySouthDeed()
		{
		}

		public DarkFlowerTapestrySouthDeed(Serial serial) : base(serial)
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
	public class DarkFlowerTapestryEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new DarkFlowerTapestryEastDeed();

		[Constructable]
		public DarkFlowerTapestryEastAddon()
		{
			AddComponent(new AddonComponent(0xFE0), 0, 0, 0);
			AddComponent(new AddonComponent(0xFDF), 0, 1, 0);
		}

		public DarkFlowerTapestryEastAddon(Serial serial) : base(serial)
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

	public class DarkFlowerTapestryEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new DarkFlowerTapestryEastAddon();
		public override int LabelNumber => 1049395;  // a dark flower tapestry deed facing east

		[Constructable]
		public DarkFlowerTapestryEastDeed()
		{
		}

		public DarkFlowerTapestryEastDeed(Serial serial) : base(serial)
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