using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class Butcher : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		[Constructable]
		public Butcher() : base("the butcher")
		{
			SetSkill(SkillName.Anatomy, 45.0, 68.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBButcher());
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem(new Server.Items.HalfApron());
			AddItem(new Server.Items.Cleaver());
		}

		public Butcher(Serial serial) : base(serial)
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