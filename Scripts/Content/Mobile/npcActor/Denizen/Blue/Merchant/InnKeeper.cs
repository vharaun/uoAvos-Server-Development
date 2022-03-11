using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class InnKeeper : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		[Constructable]
		public InnKeeper() : base("the innkeeper")
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBInnKeeper());

			if (IsTokunoVendor)
			{
				m_SBInfos.Add(new SBSEFood());
			}
		}

		public override VendorShoeType ShoeType => Utility.RandomBool() ? VendorShoeType.Sandals : VendorShoeType.Shoes;

		public InnKeeper(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version 
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}