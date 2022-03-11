namespace Server.Items
{
	/// Facing South
	public class OrnateElvenTableSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new OrnateElvenTableSouthDeed();

		[Constructable]
		public OrnateElvenTableSouthAddon()
		{
			AddComponent(new AddonComponent(0x308F), 0, 1, 0);
			AddComponent(new AddonComponent(0x3090), 0, 0, 0);
			AddComponent(new AddonComponent(0x3091), 0, -1, 0);
		}

		public OrnateElvenTableSouthAddon(Serial serial) : base(serial)
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

	public class OrnateElvenTableSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new OrnateElvenTableSouthAddon();
		public override int LabelNumber => 1072869;  // ornate table (south)

		[Constructable]
		public OrnateElvenTableSouthDeed()
		{
		}

		public OrnateElvenTableSouthDeed(Serial serial) : base(serial)
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
	public class OrnateElvenTableEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new OrnateElvenTableEastDeed();

		[Constructable]
		public OrnateElvenTableEastAddon()
		{
			AddComponent(new AddonComponent(0x308E), -1, 0, 0);
			AddComponent(new AddonComponent(0x308D), 0, 0, 0);
			AddComponent(new AddonComponent(0x308C), 1, 0, 0);
		}

		public OrnateElvenTableEastAddon(Serial serial) : base(serial)
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

	public class OrnateElvenTableEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new OrnateElvenTableEastAddon();
		public override int LabelNumber => 1073384;  // ornate table (east)

		[Constructable]
		public OrnateElvenTableEastDeed()
		{
		}

		public OrnateElvenTableEastDeed(Serial serial) : base(serial)
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