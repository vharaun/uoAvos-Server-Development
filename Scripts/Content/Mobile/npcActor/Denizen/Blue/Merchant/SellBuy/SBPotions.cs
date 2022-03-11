using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBPotions : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBPotions()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				/// Potions: Magery
				Add(new GenericBuyInfo(typeof(NightSightPotion), 15, 10, 0xF06, 0));
				Add(new GenericBuyInfo(typeof(AgilityPotion), 15, 10, 0xF08, 0));
				Add(new GenericBuyInfo(typeof(StrengthPotion), 15, 10, 0xF09, 0));
				Add(new GenericBuyInfo(typeof(RefreshPotion), 15, 10, 0xF0B, 0));
				Add(new GenericBuyInfo(typeof(LesserCurePotion), 15, 10, 0xF07, 0));
				Add(new GenericBuyInfo(typeof(LesserHealPotion), 15, 10, 0xF0C, 0));
				Add(new GenericBuyInfo(typeof(LesserPoisonPotion), 15, 10, 0xF0A, 0));
				Add(new GenericBuyInfo(typeof(LesserExplosionPotion), 21, 10, 0xF0D, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				/// Potions: Magery
				Add(typeof(NightSightPotion), 7);
				Add(typeof(AgilityPotion), 7);
				Add(typeof(StrengthPotion), 7);
				Add(typeof(RefreshPotion), 7);
				Add(typeof(LesserCurePotion), 7);
				Add(typeof(LesserHealPotion), 7);
				Add(typeof(LesserPoisonPotion), 7);
				Add(typeof(LesserExplosionPotion), 10);
			}
		}
	}
}