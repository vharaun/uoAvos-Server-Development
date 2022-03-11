using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Jockles : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078135); // Talk to me to learn the way of the blade.
		}

		[Constructable]
		public Jockles()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Jockles";
			Title = "the Swordsmanship Instructor";
			BodyValue = 0x190;
			Hue = 0x83FA;
			HairItemID = 0x203C;
			HairHue = 0x8A7;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Focus, 120.0);

			AddItem(new Backpack());
			AddItem(new Broadsword());
			AddItem(new PlateChest());
			AddItem(new PlateLegs());
			AddItem(new PlateGloves());
			AddItem(new PlateArms());
			AddItem(new PlateGorget());
			AddItem(new OrderShield());
		}

		public Jockles(Serial serial)
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