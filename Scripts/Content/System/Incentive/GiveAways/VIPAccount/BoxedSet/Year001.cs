using Server.Items;

namespace Server.Engines.VIPAccount
{
	[FlipableAttribute(0x46A5, 0x46A6)]
	public class LoyaltyAwardBox001 : BaseContainer
	{
		public override int DefaultGumpID => 0x11E;

		[Constructable]
		public LoyaltyAwardBox001()
			: base(Utility.RandomBool() ? 0x46A5 : 0x46A6)
		{
			Hue = GiftBoxHues.RandomGiftBoxHue;

			DropItem(new EarringsOfProtection(AosElementAttribute.Physical));
			DropItem(new EarringsOfProtection(AosElementAttribute.Fire));
			DropItem(new EarringsOfProtection(AosElementAttribute.Cold));
			DropItem(new EarringsOfProtection(AosElementAttribute.Poison));
			DropItem(new EarringsOfProtection(AosElementAttribute.Energy));
		}

		public LoyaltyAwardBox001(Serial serial)
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