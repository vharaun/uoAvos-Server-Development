using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class TylAriadne : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078140); // Want to learn how to parry blows?
		}

		[Constructable]
		public TylAriadne()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Tyl Ariadne";
			Title = "the Parrying Instructor";
			BodyValue = 0x190;
			Hue = 0x8374;
			HairItemID = 0;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Meditation, 120.0);
			SetSkill(SkillName.Focus, 120.0);

			AddItem(new Backpack());
			AddItem(new ElvenBoots(0x96D));

			Item item;

			item = new StuddedLegs {
				Hue = 0x96D
			};
			AddItem(item);

			item = new StuddedGloves {
				Hue = 0x96D
			};
			AddItem(item);

			item = new StuddedGorget {
				Hue = 0x96D
			};
			AddItem(item);

			item = new StuddedChest {
				Hue = 0x96D
			};
			AddItem(item);

			item = new StuddedArms {
				Hue = 0x96D
			};
			AddItem(item);

			item = new DiamondMace {
				Hue = 0x96D
			};
			AddItem(item);
		}

		public TylAriadne(Serial serial)
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