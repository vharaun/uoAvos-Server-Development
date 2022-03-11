using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class Herbalist : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override NpcGuild NpcGuild => NpcGuild.MagesGuild;

		[Constructable]
		public Herbalist() : base("the herbalist")
		{
			SetSkill(SkillName.Alchemy, 80.0, 100.0);
			SetSkill(SkillName.Cooking, 80.0, 100.0);
			SetSkill(SkillName.TasteID, 80.0, 100.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBReagents());
		}

		public override VendorShoeType ShoeType => Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals;

		public Herbalist(Serial serial) : base(serial)
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