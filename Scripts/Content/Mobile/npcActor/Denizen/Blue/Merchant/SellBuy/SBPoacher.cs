using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBPoacher : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBPoacher()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new AnimalBuyInfo(1, typeof(Gorilla), 550, 10, 204, 0));
				Add(new AnimalBuyInfo(1, typeof(BrownBear), 855, 10, 167, 0));
				Add(new AnimalBuyInfo(1, typeof(GrizzlyBear), 1767, 10, 212, 0));
				Add(new AnimalBuyInfo(1, typeof(Panther), 1271, 10, 214, 0));
				Add(new AnimalBuyInfo(1, typeof(TimberWolf), 768, 10, 225, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}