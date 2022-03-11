using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBSmithTools : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSmithTools()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo(typeof(IronIngot), 5, 16, 0x1BF2, 0));
				Add(new GenericBuyInfo(typeof(Tongs), 13, 14, 0xFBB, 0));

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add(typeof(Tongs), 7);
				Add(typeof(IronIngot), 4);
			}
		}
	}
}