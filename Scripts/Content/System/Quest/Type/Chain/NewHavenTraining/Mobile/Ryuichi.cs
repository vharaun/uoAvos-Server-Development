using Server.Items;
using Server.Mobiles;

using System.Collections.Generic;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Ryuichi : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078155); // I can teach you Ninjitsu. The Art of Stealth.
		}

		[Constructable]
		public Ryuichi()
			: base("the Ninjitsu Instructor")
		{
			Name = "Ryuichi";
			Hue = 0x8403;

			SetSkill(SkillName.Hiding, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Tracking, 120.0);
			SetSkill(SkillName.Fencing, 120.0);
			SetSkill(SkillName.Stealth, 120.0);
			SetSkill(SkillName.Ninjitsu, 120.0);
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBNinja());
		}

		public override bool GetGender()
		{
			return false;
		}

		public override void InitOutfit()
		{
			HairItemID = 0x203B;
			HairHue = 0x455;

			AddItem(new SamuraiTabi());
			AddItem(new LeatherNinjaPants());
			AddItem(new LeatherNinjaMitts());
			AddItem(new LeatherNinjaHood());
			AddItem(new LeatherNinjaJacket());
			AddItem(new LeatherNinjaBelt());

			PackGold(100, 200);
		}

		public Ryuichi(Serial serial)
			: base(serial)
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