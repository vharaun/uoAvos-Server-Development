using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Churchill : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078141); // Don't listen to Jockles. Real warriors wield mace weapons!
		}

		[Constructable]
		public Churchill()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Churchill";
			Title = "the Mace Fighting Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x203C;
			HairHue = 0x455;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Macing, 120.0);
			SetSkill(SkillName.Focus, 120.0);

			AddItem(new Backpack());
			AddItem(new OrderShield());
			AddItem(new WarMace());

			Item item;

			item = new PlateLegs {
				Hue = 0x966
			};
			AddItem(item);

			item = new PlateGloves {
				Hue = 0x966
			};
			AddItem(item);

			item = new PlateGorget {
				Hue = 0x966
			};
			AddItem(item);

			item = new PlateChest {
				Hue = 0x966
			};
			AddItem(item);

			item = new PlateArms {
				Hue = 0x966
			};
			AddItem(item);
		}

		public Churchill(Serial serial)
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