using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBHealer : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHealer()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				/// RandomDrugs


				/// Potions: Healing
				Add(new GenericBuyInfo(typeof(LesserHealPotion), 15, 20, 0xF0C, 0));
				Add(new GenericBuyInfo(typeof(RefreshPotion), 15, 20, 0xF0B, 0));

				/// TradeTools
				Add(new GenericBuyInfo(typeof(Bandage), 5, 20, 0xF0E, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				/// RandomDrugs


				/// Potions: Healing
				Add(typeof(LesserHealPotion), 3);
				Add(typeof(RefreshPotion), 3);

				/// TradeTools
				Add(typeof(Bandage), 3);
			}
		}
	}
}