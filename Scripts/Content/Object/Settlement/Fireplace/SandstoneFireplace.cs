namespace Server.Items
{
	/// Facing South
	public class SandstoneFireplaceSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new SandstoneFireplaceSouthDeed();

		[Constructable]
		public SandstoneFireplaceSouthAddon()
		{
			AddComponent(new AddonComponent(0x482), -1, 0, 0);
			AddComponent(new AddonComponent(0x47B), 0, 0, 0);
		}

		public SandstoneFireplaceSouthAddon(Serial serial) : base(serial)
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

	public class SandstoneFireplaceSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new SandstoneFireplaceSouthAddon();
		public override int LabelNumber => 1061845;  // sandstone fireplace (south)

		[Constructable]
		public SandstoneFireplaceSouthDeed()
		{
		}

		public SandstoneFireplaceSouthDeed(Serial serial) : base(serial)
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
	public class SandstoneFireplaceEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new SandstoneFireplaceEastDeed();

		[Constructable]
		public SandstoneFireplaceEastAddon()
		{
			AddComponent(new AddonComponent(0x489), 0, 0, 0);
			AddComponent(new AddonComponent(0x475), 0, 1, 0);
		}

		public SandstoneFireplaceEastAddon(Serial serial) : base(serial)
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

	public class SandstoneFireplaceEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new SandstoneFireplaceEastAddon();
		public override int LabelNumber => 1061844;  // sandstone fireplace (east)

		[Constructable]
		public SandstoneFireplaceEastDeed()
		{
		}

		public SandstoneFireplaceEastDeed(Serial serial) : base(serial)
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