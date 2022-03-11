using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class SBArmourSmith : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBArmourSmith()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo(typeof(BronzeShield), 66, 20, 0x1B72, 0));
				Add(new GenericBuyInfo(typeof(Buckler), 50, 20, 0x1B73, 0));
				Add(new GenericBuyInfo(typeof(MetalKiteShield), 123, 20, 0x1B74, 0));
				Add(new GenericBuyInfo(typeof(HeaterShield), 231, 20, 0x1B76, 0));
				Add(new GenericBuyInfo(typeof(WoodenKiteShield), 70, 20, 0x1B78, 0));
				Add(new GenericBuyInfo(typeof(MetalShield), 121, 20, 0x1B7B, 0));

				Add(new GenericBuyInfo(typeof(WoodenShield), 30, 20, 0x1B7A, 0));

				Add(new GenericBuyInfo(typeof(PlateGorget), 104, 20, 0x1413, 0));
				Add(new GenericBuyInfo(typeof(PlateChest), 243, 20, 0x1415, 0));
				Add(new GenericBuyInfo(typeof(PlateLegs), 218, 20, 0x1411, 0));
				Add(new GenericBuyInfo(typeof(PlateArms), 188, 20, 0x1410, 0));
				Add(new GenericBuyInfo(typeof(PlateGloves), 155, 20, 0x1414, 0));

				Add(new GenericBuyInfo(typeof(PlateHelm), 21, 20, 0x1412, 0));
				Add(new GenericBuyInfo(typeof(CloseHelm), 18, 20, 0x1408, 0));
				Add(new GenericBuyInfo(typeof(CloseHelm), 18, 20, 0x1409, 0));
				Add(new GenericBuyInfo(typeof(Helmet), 31, 20, 0x140A, 0));
				Add(new GenericBuyInfo(typeof(Helmet), 18, 20, 0x140B, 0));
				Add(new GenericBuyInfo(typeof(NorseHelm), 18, 20, 0x140E, 0));
				Add(new GenericBuyInfo(typeof(NorseHelm), 18, 20, 0x140F, 0));
				Add(new GenericBuyInfo(typeof(Bascinet), 18, 20, 0x140C, 0));
				Add(new GenericBuyInfo(typeof(PlateHelm), 21, 20, 0x1419, 0));

				Add(new GenericBuyInfo(typeof(ChainCoif), 17, 20, 0x13BB, 0));
				Add(new GenericBuyInfo(typeof(ChainChest), 143, 20, 0x13BF, 0));
				Add(new GenericBuyInfo(typeof(ChainLegs), 149, 20, 0x13BE, 0));

				Add(new GenericBuyInfo(typeof(RingmailChest), 121, 20, 0x13ec, 0));
				Add(new GenericBuyInfo(typeof(RingmailLegs), 90, 20, 0x13F0, 0));
				Add(new GenericBuyInfo(typeof(RingmailArms), 85, 20, 0x13EE, 0));
				Add(new GenericBuyInfo(typeof(RingmailGloves), 93, 20, 0x13eb, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add(typeof(Tongs), 7);
				Add(typeof(IronIngot), 4);

				Add(typeof(Buckler), 25);
				Add(typeof(BronzeShield), 33);
				Add(typeof(MetalShield), 60);
				Add(typeof(MetalKiteShield), 62);
				Add(typeof(HeaterShield), 115);
				Add(typeof(WoodenKiteShield), 35);

				Add(typeof(WoodenShield), 15);

				Add(typeof(PlateArms), 94);
				Add(typeof(PlateChest), 121);
				Add(typeof(PlateGloves), 72);
				Add(typeof(PlateGorget), 52);
				Add(typeof(PlateLegs), 109);

				Add(typeof(FemalePlateChest), 113);
				Add(typeof(FemaleLeatherChest), 18);
				Add(typeof(FemaleStuddedChest), 25);
				Add(typeof(LeatherShorts), 14);
				Add(typeof(LeatherSkirt), 11);
				Add(typeof(LeatherBustierArms), 11);
				Add(typeof(StuddedBustierArms), 27);

				Add(typeof(Bascinet), 9);
				Add(typeof(CloseHelm), 9);
				Add(typeof(Helmet), 9);
				Add(typeof(NorseHelm), 9);
				Add(typeof(PlateHelm), 10);

				Add(typeof(ChainCoif), 6);
				Add(typeof(ChainChest), 71);
				Add(typeof(ChainLegs), 74);

				Add(typeof(RingmailArms), 42);
				Add(typeof(RingmailChest), 60);
				Add(typeof(RingmailGloves), 26);
				Add(typeof(RingmailLegs), 45);
			}
		}
	}
}