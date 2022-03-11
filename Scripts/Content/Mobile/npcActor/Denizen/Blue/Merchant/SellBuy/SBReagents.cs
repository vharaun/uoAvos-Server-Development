using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBReagents : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBReagents()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				/// Reagents: Magery
				Add(new GenericBuyInfo(typeof(BlackPearl), 5, 20, 0xF7A, 0));
				Add(new GenericBuyInfo(typeof(Bloodmoss), 5, 20, 0xF7B, 0));
				Add(new GenericBuyInfo(typeof(Garlic), 3, 20, 0xF84, 0));
				Add(new GenericBuyInfo(typeof(Ginseng), 3, 20, 0xF85, 0));
				Add(new GenericBuyInfo(typeof(MandrakeRoot), 3, 20, 0xF86, 0));
				Add(new GenericBuyInfo(typeof(Nightshade), 3, 20, 0xF88, 0));
				Add(new GenericBuyInfo(typeof(SpidersSilk), 3, 20, 0xF8D, 0));
				Add(new GenericBuyInfo(typeof(SulfurousAsh), 3, 20, 0xF8C, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				/// Reagents: Magery
				Add(typeof(BlackPearl), 3);
				Add(typeof(Bloodmoss), 3);
				Add(typeof(Garlic), 2);
				Add(typeof(Ginseng), 2);
				Add(typeof(MandrakeRoot), 2);
				Add(typeof(Nightshade), 2);
				Add(typeof(SpidersSilk), 2);
				Add(typeof(SulfurousAsh), 2);
			}
		}
	}
}