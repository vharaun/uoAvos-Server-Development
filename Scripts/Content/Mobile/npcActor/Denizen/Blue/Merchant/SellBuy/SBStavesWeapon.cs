﻿using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBStavesWeapon : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBStavesWeapon()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo(typeof(BlackStaff), 22, 20, 0xDF1, 0));
				Add(new GenericBuyInfo(typeof(GnarledStaff), 16, 20, 0x13F8, 0));
				Add(new GenericBuyInfo(typeof(QuarterStaff), 19, 20, 0xE89, 0));
				Add(new GenericBuyInfo(typeof(ShepherdsCrook), 20, 20, 0xE81, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add(typeof(BlackStaff), 11);
				Add(typeof(GnarledStaff), 8);
				Add(typeof(QuarterStaff), 9);
				Add(typeof(ShepherdsCrook), 10);
			}
		}
	}
}