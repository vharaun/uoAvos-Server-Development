namespace Server.Items
{
	/// Facing South
	public class SmallBedSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new SmallBedSouthDeed();

		[Constructable]
		public SmallBedSouthAddon()
		{
			AddComponent(new AddonComponent(0xA63), 0, 0, 0);
			AddComponent(new AddonComponent(0xA5C), 0, 1, 0);
		}

		public SmallBedSouthAddon(Serial serial) : base(serial)
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

	public class SmallBedSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new SmallBedSouthAddon();
		public override int LabelNumber => 1044321;  // small bed (south)

		[Constructable]
		public SmallBedSouthDeed()
		{
		}

		public SmallBedSouthDeed(Serial serial) : base(serial)
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
	public class SmallBedEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new SmallBedEastDeed();

		[Constructable]
		public SmallBedEastAddon()
		{
			AddComponent(new AddonComponent(0xA5D), 0, 0, 0);
			AddComponent(new AddonComponent(0xA62), 1, 0, 0);
		}

		public SmallBedEastAddon(Serial serial) : base(serial)
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

	public class SmallBedEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new SmallBedEastAddon();
		public override int LabelNumber => 1044322;  // small bed (east)

		[Constructable]
		public SmallBedEastDeed()
		{
		}

		public SmallBedEastDeed(Serial serial) : base(serial)
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