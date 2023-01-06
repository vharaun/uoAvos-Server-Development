using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Walker : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1078213, // I don't sleep. I wait.
				1078212, // There is no theory of evolution. Just a list of creatures I allow to live.
				1078214 // I can lead a horse to water and make it drink.
			));
		}

		[Constructable]
		public Walker()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Walker";
			Title = "the Tracking Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x203B;
			HairHue = 0x47D;
			FacialHairItemID = 0x204B;
			FacialHairHue = 0x47D;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Hiding, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Tracking, 120.0);
			SetSkill(SkillName.Fencing, 120.0);
			SetSkill(SkillName.Wrestling, 120.0);
			SetSkill(SkillName.Stealth, 120.0);
			SetSkill(SkillName.Ninjitsu, 120.0);

			AddItem(new Backpack());
			AddItem(new Boots(0x455));
			AddItem(new LongPants(0x455));
			AddItem(new FancyShirt(0x47D));
			AddItem(new FloppyHat(0x455));
		}

		public Walker(Serial serial)
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