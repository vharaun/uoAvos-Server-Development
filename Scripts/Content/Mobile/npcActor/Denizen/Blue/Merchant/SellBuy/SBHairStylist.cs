using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBHairStylist : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHairStylist()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo("special beard dye", typeof(SpecialBeardDye), 500000, 20, 0xE26, 0));
				Add(new GenericBuyInfo("special hair dye", typeof(SpecialHairDye), 500000, 20, 0xE26, 0));
				Add(new GenericBuyInfo("1041060", typeof(HairDye), 60, 20, 0xEFF, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add(typeof(HairDye), 30);
				Add(typeof(SpecialBeardDye), 250000);
				Add(typeof(SpecialHairDye), 250000);
			}
		}
	}
}