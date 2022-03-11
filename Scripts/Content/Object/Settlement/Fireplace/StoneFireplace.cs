namespace Server.Items
{
	/// Facing South
	public class StoneFireplaceSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new StoneFireplaceSouthDeed();

		[Constructable]
		public StoneFireplaceSouthAddon()
		{
			AddComponent(new AddonComponent(0x967), -1, 0, 0);
			AddComponent(new AddonComponent(0x961), 0, 0, 0);
		}

		public StoneFireplaceSouthAddon(Serial serial) : base(serial)
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

	public class StoneFireplaceSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new StoneFireplaceSouthAddon();
		public override int LabelNumber => 1061849;  // stone fireplace (south)

		[Constructable]
		public StoneFireplaceSouthDeed()
		{
		}

		public StoneFireplaceSouthDeed(Serial serial) : base(serial)
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
	public class StoneFireplaceEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new StoneFireplaceEastDeed();

		[Constructable]
		public StoneFireplaceEastAddon()
		{
			AddComponent(new AddonComponent(0x959), 0, 0, 0);
			AddComponent(new AddonComponent(0x953), 0, 1, 0);
		}

		public StoneFireplaceEastAddon(Serial serial) : base(serial)
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

	public class StoneFireplaceEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new StoneFireplaceEastAddon();
		public override int LabelNumber => 1061848;  // stone fireplace (east)

		[Constructable]
		public StoneFireplaceEastDeed()
		{
		}

		public StoneFireplaceEastDeed(Serial serial) : base(serial)
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