namespace Server.Items
{
	/// Facing South
	public class ArcaneBookshelfSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ArcaneBookshelfSouthDeed();

		[Constructable]
		public ArcaneBookshelfSouthAddon()
		{
			AddComponent(new AddonComponent(0x3087), 0, 0, 0);
			AddComponent(new AddonComponent(0x3086), 0, 1, 0);
		}

		public ArcaneBookshelfSouthAddon(Serial serial) : base(serial)
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

	public class ArcaneBookshelfSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ArcaneBookshelfSouthAddon();
		public override int LabelNumber => 1072871;  // arcane bookshelf (south)

		[Constructable]
		public ArcaneBookshelfSouthDeed()
		{
		}

		public ArcaneBookshelfSouthDeed(Serial serial) : base(serial)
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
	public class ArcaneBookshelfEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ArcaneBookshelfEastDeed();

		[Constructable]
		public ArcaneBookshelfEastAddon()
		{
			AddComponent(new AddonComponent(0x3084), 0, 0, 0);
			AddComponent(new AddonComponent(0x3085), -1, 0, 0);
		}

		public ArcaneBookshelfEastAddon(Serial serial) : base(serial)
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

	public class ArcaneBookshelfEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ArcaneBookshelfEastAddon();
		public override int LabelNumber => 1073371;  // arcane bookshelf (east)

		[Constructable]
		public ArcaneBookshelfEastDeed()
		{
		}

		public ArcaneBookshelfEastDeed(Serial serial) : base(serial)
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