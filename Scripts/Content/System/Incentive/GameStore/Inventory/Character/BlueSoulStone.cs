namespace Server.Items
{
	[Flipable]
	public class BlueSoulstone : SoulStone
	{
		[Constructable]
		public BlueSoulstone()
			: this(null)
		{
		}

		[Constructable]
		public BlueSoulstone(string account)
			: base(account, 0x2ADC, 0x2ADD)
		{
		}

		public BlueSoulstone(Serial serial)
			: base(serial)
		{
		}

		public void Flip()
		{
			switch (ItemID)
			{
				case 0x2ADC: ItemID = 0x2AEC; break;
				case 0x2ADD: ItemID = 0x2AED; break;
				case 0x2AEC: ItemID = 0x2ADC; break;
				case 0x2AED: ItemID = 0x2ADD; break;
			}
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