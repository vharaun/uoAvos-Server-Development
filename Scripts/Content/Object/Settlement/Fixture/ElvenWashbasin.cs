namespace Server.Items
{
	/// Facing South
	public class ElvenWashBasinSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenWashBasinSouthDeed();

		[Constructable]
		public ElvenWashBasinSouthAddon()
		{
			AddComponent(new AddonComponent(0x30E1), 0, 0, 0);
			AddComponent(new AddonComponent(0x30E2), 1, 0, 0);
		}

		public ElvenWashBasinSouthAddon(Serial serial) : base(serial)
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

	public class ElvenWashBasinSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenWashBasinSouthAddon();
		public override int LabelNumber => 1072865;  // elven wash basin (south)

		[Constructable]
		public ElvenWashBasinSouthDeed()
		{
		}

		public ElvenWashBasinSouthDeed(Serial serial) : base(serial)
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
	public class ElvenWashBasinEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenWashBasinEastDeed();

		[Constructable]
		public ElvenWashBasinEastAddon()
		{
			AddComponent(new AddonComponent(0x30DF), 0, 0, 0);
			AddComponent(new AddonComponent(0x30E0), 0, 1, 0);
		}

		public ElvenWashBasinEastAddon(Serial serial) : base(serial)
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

	public class ElvenWashBasinEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenWashBasinEastAddon();
		public override int LabelNumber => 1073387;  // elven wash basin (east)

		[Constructable]
		public ElvenWashBasinEastDeed()
		{
		}

		public ElvenWashBasinEastDeed(Serial serial) : base(serial)
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