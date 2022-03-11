using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class Farmer : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		[Constructable]
		public Farmer() : base("the farmer")
		{
			SetSkill(SkillName.Lumberjacking, 36.0, 68.0);
			SetSkill(SkillName.TasteID, 36.0, 68.0);
			SetSkill(SkillName.Cooking, 36.0, 68.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBFarmer());
		}

		public override VendorShoeType ShoeType => VendorShoeType.ThighBoots;

		public override int GetShoeHue()
		{
			return 0;
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem(new Server.Items.WideBrimHat(Utility.RandomNeutralHue()));
		}

		public Farmer(Serial serial) : base(serial)
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