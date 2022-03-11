namespace Server.Items
{
	/// Facing South
	public class AlchemistTableSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new AlchemistTableSouthDeed();

		[Constructable]
		public AlchemistTableSouthAddon()
		{
			AddComponent(new AddonComponent(0x2DD4), 0, 0, 0);
		}

		public AlchemistTableSouthAddon(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class AlchemistTableSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new AlchemistTableSouthAddon();
		public override int LabelNumber => 1073396;  // alchemist table (south)

		[Constructable]
		public AlchemistTableSouthDeed()
		{
		}

		public AlchemistTableSouthDeed(Serial serial) : base(serial)
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
	public class AlchemistTableEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new AlchemistTableEastDeed();

		[Constructable]
		public AlchemistTableEastAddon()
		{
			AddComponent(new AddonComponent(0x2DD3), 0, 0, 0);
		}

		public AlchemistTableEastAddon(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(1); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();
		}
	}

	public class AlchemistTableEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new AlchemistTableEastAddon();
		public override int LabelNumber => 1073397;  // alchemist table (east)

		[Constructable]
		public AlchemistTableEastDeed()
		{
		}

		public AlchemistTableEastDeed(Serial serial) : base(serial)
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