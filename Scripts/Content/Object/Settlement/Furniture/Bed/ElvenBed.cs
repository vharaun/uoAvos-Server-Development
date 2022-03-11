namespace Server.Items
{
	/// Facing South
	public class ElvenBedSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenBedSouthDeed();

		[Constructable]
		public ElvenBedSouthAddon()
		{
			AddComponent(new AddonComponent(0x3050), 0, 0, 0);
			AddComponent(new AddonComponent(0x3051), 0, -1, 0);
		}

		public ElvenBedSouthAddon(Serial serial) : base(serial)
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

	public class ElvenBedSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenBedSouthAddon();
		public override int LabelNumber => 1072860;  // elven bed (south)

		[Constructable]
		public ElvenBedSouthDeed()
		{
		}

		public ElvenBedSouthDeed(Serial serial) : base(serial)
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

	/// Facing East
	public class ElvenBedEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenBedEastDeed();

		[Constructable]
		public ElvenBedEastAddon()
		{
			AddComponent(new AddonComponent(0x304D), 0, 0, 0);
			AddComponent(new AddonComponent(0x304C), 1, 0, 0);
		}

		public ElvenBedEastAddon(Serial serial) : base(serial)
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

	public class ElvenBedEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenBedEastAddon();
		public override int LabelNumber => 1072861;  // elven bed (east)

		[Constructable]
		public ElvenBedEastDeed()
		{
		}

		public ElvenBedEastDeed(Serial serial) : base(serial)
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