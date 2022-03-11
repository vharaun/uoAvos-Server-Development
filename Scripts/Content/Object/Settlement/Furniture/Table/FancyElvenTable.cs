namespace Server.Items
{
	/// Facing South
	public class FancyElvenTableSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new FancyElvenTableSouthDeed();

		[Constructable]
		public FancyElvenTableSouthAddon()
		{
			AddComponent(new AddonComponent(0x3095), 0, 1, 0);
			AddComponent(new AddonComponent(0x3096), 0, 0, 0);
			AddComponent(new AddonComponent(0x3097), 0, -1, 0);
		}

		public FancyElvenTableSouthAddon(Serial serial) : base(serial)
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

	public class FancyElvenTableSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new FancyElvenTableSouthAddon();
		public override int LabelNumber => 1073385;  // hardwood table (south)

		[Constructable]
		public FancyElvenTableSouthDeed()
		{
		}

		public FancyElvenTableSouthDeed(Serial serial) : base(serial)
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
	public class FancyElvenTableEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new FancyElvenTableEastDeed();

		[Constructable]
		public FancyElvenTableEastAddon()
		{
			AddComponent(new AddonComponent(0x3094), -1, 0, 0);
			AddComponent(new AddonComponent(0x3093), 0, 0, 0);
			AddComponent(new AddonComponent(0x3092), 1, 0, 0);
		}

		public FancyElvenTableEastAddon(Serial serial) : base(serial)
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

	public class FancyElvenTableEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new FancyElvenTableEastAddon();
		public override int LabelNumber => 1073386;  // hardwood table (east)

		[Constructable]
		public FancyElvenTableEastDeed()
		{
		}

		public FancyElvenTableEastDeed(Serial serial) : base(serial)
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