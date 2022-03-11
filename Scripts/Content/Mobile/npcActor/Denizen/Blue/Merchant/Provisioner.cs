using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class Provisioner : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		[Constructable]
		public Provisioner() : base("the provisioner")
		{
			SetSkill(SkillName.Camping, 45.0, 68.0);
			SetSkill(SkillName.Tactics, 45.0, 68.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBProvisioner());

			if (IsTokunoVendor)
			{
				m_SBInfos.Add(new SBSEHats());
			}
		}

		public Provisioner(Serial serial) : base(serial)
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