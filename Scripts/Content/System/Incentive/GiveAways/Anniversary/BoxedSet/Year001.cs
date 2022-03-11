namespace Server.Items
{
	[FlipableAttribute(0x46A5, 0x46A6)]
	public class AnniversaryGiftBox001 : BaseContainer
	{
		public override int DefaultGumpID => 0x11E;

		[Constructable]
		public AnniversaryGiftBox001()
			: base(Utility.RandomBool() ? 0x46A5 : 0x46A6)
		{
			Hue = GiftBoxHues.RandomGiftBoxHue;

			switch (Utility.Random(2))
			{
				case 1:
					{
						DropItem(new CherryBlossomTreeAddon());
						DropItem(new CherryBlossomTrunkAddon());
						break;
					}
				case 0:
					{
						DropItem(new AppleTreeDeed());
						DropItem(new PeachTreeDeed());
						break;
					}

			}
		}

		public AnniversaryGiftBox001(Serial serial)
			: base(serial)
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