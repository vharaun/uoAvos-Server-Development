using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Jun : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078175); // Walk Silently. Remain unseen. I can teach you.
		}

		[Constructable]
		public Jun()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Jun";
			Title = "the Stealth Instructor";
			BodyValue = 0x190;
			Hue = 0x8403;
			HairItemID = 0x203B;
			HairHue = 0x455;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Hiding, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Tracking, 120.0);
			SetSkill(SkillName.Fencing, 120.0);
			SetSkill(SkillName.Stealth, 120.0);
			SetSkill(SkillName.Ninjitsu, 120.0);

			AddItem(new Backpack());
			AddItem(new SamuraiTabi());
			AddItem(new LeatherNinjaPants());
			AddItem(new LeatherNinjaMitts());
			AddItem(new LeatherNinjaHood());
			AddItem(new LeatherNinjaJacket());
			AddItem(new LeatherNinjaBelt());
		}

		public Jun(Serial serial)
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