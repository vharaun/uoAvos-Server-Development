namespace Server.Items
{
	[Flipable(0xC1B, 0xC1C, 0xC1E, 0xC1D)]
	public class BrokenStandingChairComponent : AddonComponent
	{
		public override int LabelNumber => 1076259;  // Standing Broken Chair

		public BrokenStandingChairComponent() : base(0xC1B)
		{
		}

		public BrokenStandingChairComponent(Serial serial) : base(serial)
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

	public class BrokenStandingChairAddon : BaseAddon
	{
		public override BaseAddonDeed Deed => new BrokenStandingChairDeed();

		[Constructable]
		public BrokenStandingChairAddon() : base()
		{
			AddComponent(new BrokenStandingChairComponent(), 0, 0, 0);
		}

		public BrokenStandingChairAddon(Serial serial) : base(serial)
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

	public class BrokenStandingChairDeed : BaseAddonDeed
	{
		public override BaseAddon Addon => new BrokenStandingChairAddon();
		public override int LabelNumber => 1076259;  // Standing Broken Chair

		[Constructable]
		public BrokenStandingChairDeed() : base()
		{
			LootType = LootType.Blessed;
		}

		public BrokenStandingChairDeed(Serial serial) : base(serial)
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