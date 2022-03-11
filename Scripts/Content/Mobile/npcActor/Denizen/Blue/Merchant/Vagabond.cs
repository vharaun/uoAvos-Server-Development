using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class Vagabond : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		[Constructable]
		public Vagabond() : base("the vagabond")
		{
			SetSkill(SkillName.ItemID, 60.0, 83.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBTinker());
			m_SBInfos.Add(new SBVagabond());
		}

		public override void InitOutfit()
		{
			AddItem(new FancyShirt(Utility.RandomBrightHue()));
			AddItem(new Shoes(GetShoeHue()));
			AddItem(new LongPants(GetRandomHue()));

			if (Utility.RandomBool())
			{
				AddItem(new Cloak(Utility.RandomBrightHue()));
			}

			switch (Utility.Random(2))
			{
				case 0: AddItem(new SkullCap(Utility.RandomNeutralHue())); break;
				case 1: AddItem(new Bandana(Utility.RandomNeutralHue())); break;
			}


			Utility.AssignRandomHair(this);
			Utility.AssignRandomFacialHair(this, HairHue);

			PackGold(100, 200);
		}

		public Vagabond(Serial serial) : base(serial)
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