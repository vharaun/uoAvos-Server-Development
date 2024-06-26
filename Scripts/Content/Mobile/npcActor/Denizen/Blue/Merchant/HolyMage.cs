﻿using Server.Items;

using System.Collections.Generic;

#region Developer Notations

/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every Resources For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Every TradeTools For Their Trade
/// In Select Shops There Should ALWAYS Be One Merchant That Sells Products Created From Their Trade

#endregion

namespace Server.Mobiles
{
	public class HolyMage : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		[Constructable]
		public HolyMage() : base("the Holy Mage")
		{
			SetSkill(SkillName.EvalInt, 65.0, 88.0);
			SetSkill(SkillName.Inscribe, 60.0, 83.0);
			SetSkill(SkillName.Magery, 64.0, 100.0);
			SetSkill(SkillName.Meditation, 60.0, 83.0);
			SetSkill(SkillName.MagicResist, 65.0, 88.0);
			SetSkill(SkillName.Wrestling, 36.0, 68.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBHolyMage());
		}

		public Item ApplyHue(Item item, int hue)
		{
			item.Hue = hue;

			return item;
		}

		public override void InitOutfit()
		{
			AddItem(ApplyHue(new Robe(), 0x47E));
			AddItem(ApplyHue(new ThighBoots(), 0x47E));
			AddItem(ApplyHue(new BlackStaff(), 0x47E));

			if (Female)
			{
				AddItem(ApplyHue(new LeatherGloves(), 0x47E));
				AddItem(ApplyHue(new GoldNecklace(), 0x47E));
			}
			else
			{
				AddItem(ApplyHue(new PlateGloves(), 0x47E));
				AddItem(ApplyHue(new PlateGorget(), 0x47E));
			}

			switch (Utility.Random(Female ? 2 : 1))
			{
				case 0: HairItemID = 0x203C; break;
				case 1: HairItemID = 0x203D; break;
			}

			HairHue = 0x47E;

			PackGold(100, 200);
		}

		public HolyMage(Serial serial) : base(serial)
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