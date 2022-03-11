using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBFarmer : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFarmer()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				/// Vegetables
				Add(new GenericBuyInfo(typeof(Cabbage), 5, 20, 0xC7B, 0));
				Add(new GenericBuyInfo(typeof(Cantaloupe), 6, 20, 0xC79, 0));
				Add(new GenericBuyInfo(typeof(Carrot), 3, 20, 0xC78, 0));
				Add(new GenericBuyInfo(typeof(HoneydewMelon), 7, 20, 0xC74, 0));
				Add(new GenericBuyInfo(typeof(Squash), 3, 20, 0xC72, 0));
				Add(new GenericBuyInfo(typeof(Lettuce), 5, 20, 0xC70, 0));
				Add(new GenericBuyInfo(typeof(Onion), 3, 20, 0xC6D, 0));
				Add(new GenericBuyInfo(typeof(Pumpkin), 11, 20, 0xC6A, 0));
				Add(new GenericBuyInfo(typeof(GreenGourd), 3, 20, 0xC66, 0));
				Add(new GenericBuyInfo(typeof(YellowGourd), 3, 20, 0xC64, 0));
				Add(new GenericBuyInfo(typeof(Watermelon), 7, 20, 0xC5C, 0));

				/// Dairy
				Add(new GenericBuyInfo(typeof(Eggs), 3, 20, 0x9B5, 0));

				/// Fruits
				Add(new GenericBuyInfo(typeof(Peach), 3, 20, 0x9D2, 0));
				Add(new GenericBuyInfo(typeof(Pear), 3, 20, 0x994, 0));
				Add(new GenericBuyInfo(typeof(Lemon), 3, 20, 0x1728, 0));
				Add(new GenericBuyInfo(typeof(Lime), 3, 20, 0x172A, 0));
				Add(new GenericBuyInfo(typeof(Grapes), 3, 20, 0x9D1, 0));
				Add(new GenericBuyInfo(typeof(Apple), 3, 20, 0x9D0, 0));

				/// AnimalFeed
				Add(new GenericBuyInfo(typeof(SheafOfHay), 2, 20, 0xF36, 0));

				/// TradeTools
				Add(new BeverageBuyInfo(typeof(Pitcher), BeverageType.Milk, 7, 20, 0x9AD, 0));

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				/// Vegetables
				Add(typeof(Cabbage), 5);
				Add(typeof(Cantaloupe), 5);
				Add(typeof(Carrot), 5);
				Add(typeof(HoneydewMelon), 5);
				Add(typeof(Squash), 5);
				Add(typeof(Lettuce), 5);
				Add(typeof(Onion), 5);
				Add(typeof(Pumpkin), 5);
				Add(typeof(GreenGourd), 5);
				Add(typeof(YellowGourd), 5);
				Add(typeof(Watermelon), 5);

				/// Dairy
				Add(typeof(Eggs), 5);

				/// Fruits
				Add(typeof(Peach), 5);
				Add(typeof(Pear), 5);
				Add(typeof(Lemon), 5);
				Add(typeof(Lime), 5);
				Add(typeof(Grapes), 5);
				Add(typeof(Apple), 5);

				/// AnimalFeed
				Add(typeof(SheafOfHay), 5);

				/// TradeTools
				Add(typeof(Pitcher), 5);
			}
		}
	}
}