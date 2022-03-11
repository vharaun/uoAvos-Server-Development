using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBTaxCollector : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTaxCollector()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo("1041243", typeof(ContractOfEmployment), 1252, 20, 0x14F0, 0));

				if (Multis.BaseHouse.NewVendorSystem)
				{
					Add(new GenericBuyInfo("1062332", typeof(VendorRentalContract), 1252, 20, 0x14F0, 0x672));
				}

				Add(new GenericBuyInfo("1047016", typeof(CommodityDeed), 5, 20, 0x14F0, 0x47));
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