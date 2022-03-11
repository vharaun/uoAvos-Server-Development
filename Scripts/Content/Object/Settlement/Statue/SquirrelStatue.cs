namespace Server.Items
{
	/// Facing South
	public class SquirrelStatueSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new SquirrelStatueSouthDeed();

		[Constructable]
		public SquirrelStatueSouthAddon()
		{
			AddComponent(new AddonComponent(0x2D11), 0, 0, 0);
		}

		public SquirrelStatueSouthAddon(Serial serial) : base(serial)
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

	public class SquirrelStatueSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new SquirrelStatueSouthAddon();
		public override int LabelNumber => 1072884;  // squirrel statue (south)

		[Constructable]
		public SquirrelStatueSouthDeed()
		{
		}

		public SquirrelStatueSouthDeed(Serial serial) : base(serial)
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
	public class SquirrelStatueEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new SquirrelStatueEastDeed();

		[Constructable]
		public SquirrelStatueEastAddon()
		{
			AddComponent(new AddonComponent(0x2D10), 0, 0, 0);
		}

		public SquirrelStatueEastAddon(Serial serial) : base(serial)
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

	public class SquirrelStatueEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new SquirrelStatueEastAddon();
		public override int LabelNumber => 1073398;  // squirrel statue (east)

		[Constructable]
		public SquirrelStatueEastDeed()
		{
		}

		public SquirrelStatueEastDeed(Serial serial) : base(serial)
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