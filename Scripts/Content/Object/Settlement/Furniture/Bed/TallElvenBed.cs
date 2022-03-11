namespace Server.Items
{
	/// Facing South
	public class TallElvenBedSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new TallElvenBedSouthDeed();

		[Constructable]
		public TallElvenBedSouthAddon()
		{
			AddComponent(new AddonComponent(0x3058), 0, 0, 0); // angolo alto sx
			AddComponent(new AddonComponent(0x3057), -1, 1, 0); // angolo basso sx
			AddComponent(new AddonComponent(0x3059), 0, -1, 0); // angolo alto dx
			AddComponent(new AddonComponent(0x3056), 0, 1, 0); // angolo basso dx
		}

		public TallElvenBedSouthAddon(Serial serial) : base(serial)
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

	public class TallElvenBedSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new TallElvenBedSouthAddon();
		public override int LabelNumber => 1072858;  // tall elven bed (south)

		[Constructable]
		public TallElvenBedSouthDeed()
		{
		}

		public TallElvenBedSouthDeed(Serial serial) : base(serial)
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
	public class TallElvenBedEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new TallElvenBedEastDeed();

		[Constructable]
		public TallElvenBedEastAddon()
		{
			AddComponent(new AddonComponent(0x3054), 0, 0, 0);
			AddComponent(new AddonComponent(0x3053), 1, 0, 0);
			AddComponent(new AddonComponent(0x3055), 2, -1, 0);
			AddComponent(new AddonComponent(0x3052), 2, 0, 0);
		}

		public TallElvenBedEastAddon(Serial serial) : base(serial)
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

	public class TallElvenBedEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new TallElvenBedEastAddon();
		public override int LabelNumber => 1072859;  // tall elven bed (east)

		[Constructable]
		public TallElvenBedEastDeed()
		{
		}

		public TallElvenBedEastDeed(Serial serial) : base(serial)
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