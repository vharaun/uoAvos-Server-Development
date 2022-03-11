namespace Server.Items
{
	/// Elven Love Seat
	public class ElvenLoveseatSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenLoveseatSouthDeed();

		[Constructable]
		public ElvenLoveseatSouthAddon()
		{
			AddComponent(new AddonComponent(0x308A), 0, 0, 0);
			AddComponent(new AddonComponent(0x308B), 0, -1, 0);
		}

		public ElvenLoveseatSouthAddon(Serial serial) : base(serial)
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
	} // Facing South

	public class ElvenLoveseatSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenLoveseatSouthAddon();
		public override int LabelNumber => 1072867;  // elven loveseat (south)

		[Constructable]
		public ElvenLoveseatSouthDeed()
		{
		}

		public ElvenLoveseatSouthDeed(Serial serial) : base(serial)
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

	public class ElvenLoveseatEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new ElvenLoveseatEastDeed();

		[Constructable]
		public ElvenLoveseatEastAddon()
		{
			AddComponent(new AddonComponent(0x3089), 0, 0, 0);
			AddComponent(new AddonComponent(0x3088), 1, 0, 0);
		}

		public ElvenLoveseatEastAddon(Serial serial) : base(serial)
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
	} // Facing East

	public class ElvenLoveseatEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new ElvenLoveseatEastAddon();
		public override int LabelNumber => 1073372;  // elven loveseat (east)

		[Constructable]
		public ElvenLoveseatEastDeed()
		{
		}

		public ElvenLoveseatEastDeed(Serial serial) : base(serial)
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