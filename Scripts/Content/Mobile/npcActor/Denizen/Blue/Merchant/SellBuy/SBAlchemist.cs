using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBAlchemist : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAlchemist()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				/// TradeTools
				Add(new GenericBuyInfo(typeof(PotionKeg), 5, 100, 0xF0E, 0));
				Add(new GenericBuyInfo(typeof(Bottle), 5, 100, 0xF0E, 0));
				Add(new GenericBuyInfo(typeof(MortarPestle), 8, 10, 0xE9B, 0));
				Add(new GenericBuyInfo(typeof(HeatingStand), 2, 100, 0x1849, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				/// TradeTools
				Add(typeof(PotionKeg), 7);
				Add(typeof(Bottle), 7);
				Add(typeof(MortarPestle), 7);
				Add(typeof(HeatingStand), 7);
			}
		}
	}
}