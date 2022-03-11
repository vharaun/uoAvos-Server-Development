#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class MerchantGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild => NpcGuild.MerchantsGuild;

		[Constructable]
		public MerchantGuildmaster() : base("merchant")
		{
			SetSkill(SkillName.ItemID, 85.0, 100.0);
			SetSkill(SkillName.ArmsLore, 85.0, 100.0);
		}

		public MerchantGuildmaster(Serial serial) : base(serial)
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