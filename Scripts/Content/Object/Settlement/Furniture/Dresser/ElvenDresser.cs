namespace Server.Items
{
	/// Facing South
	public class ElvenDresserSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenDresserSouthDeed();

		[Constructable]
		public ElvenDresserSouthAddon()
		{
			AddComponent(new AddonComponent(0x30E5), 0, 0, 0);
			AddComponent(new AddonComponent(0x30E6), 1, 0, 0);
		}

		public ElvenDresserSouthAddon(Serial serial) : base(serial)
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

	public class ElvenDresserSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenDresserSouthAddon();
		public override int LabelNumber => 1072864;  // elven dresser (south)

		[Constructable]
		public ElvenDresserSouthDeed()
		{
		}

		public ElvenDresserSouthDeed(Serial serial) : base(serial)
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
	public class ElvenDresserEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenDresserEastDeed();

		[Constructable]
		public ElvenDresserEastAddon()
		{
			AddComponent(new AddonComponent(0x30E4), 0, 0, 0);
			AddComponent(new AddonComponent(0x30E3), 0, -1, 0);
		}

		public ElvenDresserEastAddon(Serial serial) : base(serial)
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

	public class ElvenDresserEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenDresserEastAddon();
		public override int LabelNumber => 1073388;  // elven dresser (east)

		[Constructable]
		public ElvenDresserEastDeed()
		{
		}

		public ElvenDresserEastDeed(Serial serial) : base(serial)
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