namespace Server.Items
{
	/// Facing South
	public class ArcanistStatueSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ArcanistStatueSouthDeed();

		[Constructable]
		public ArcanistStatueSouthAddon()
		{
			AddComponent(new AddonComponent(0x2D0F), 0, 0, 0);
		}

		public ArcanistStatueSouthAddon(Serial serial) : base(serial)
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

	public class ArcanistStatueSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ArcanistStatueSouthAddon();
		public override int LabelNumber => 1072885;  // arcanist statue (south)

		[Constructable]
		public ArcanistStatueSouthDeed()
		{
		}

		public ArcanistStatueSouthDeed(Serial serial) : base(serial)
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
	public class ArcanistStatueEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ArcanistStatueEastDeed();

		[Constructable]
		public ArcanistStatueEastAddon()
		{
			AddComponent(new AddonComponent(0x2D0E), 0, 0, 0);
		}

		public ArcanistStatueEastAddon(Serial serial) : base(serial)
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

	public class ArcanistStatueEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ArcanistStatueEastAddon();
		public override int LabelNumber => 1072886;  // arcanist statue (east)

		[Constructable]
		public ArcanistStatueEastDeed()
		{
		}

		public ArcanistStatueEastDeed(Serial serial) : base(serial)
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