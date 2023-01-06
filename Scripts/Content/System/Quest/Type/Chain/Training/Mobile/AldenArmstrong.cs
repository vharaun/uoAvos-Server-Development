using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class AldenArmstrong : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078136); // There is an art to slaying your enemies swiftly. It's called tactics, and I can teach it to you.
		}

		[Constructable]
		public AldenArmstrong()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Alden Armstrong";
			Title = "the Tactics Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x203B;
			HairHue = 0x44E;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Focus, 120.0);

			AddItem(new Backpack());
			AddItem(new Shoes());
			AddItem(new StuddedLegs());
			AddItem(new StuddedGloves());
			AddItem(new StuddedGorget());
			AddItem(new StuddedChest());
			AddItem(new StuddedArms());
			AddItem(new Katana());
		}

		public AldenArmstrong(Serial serial)
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