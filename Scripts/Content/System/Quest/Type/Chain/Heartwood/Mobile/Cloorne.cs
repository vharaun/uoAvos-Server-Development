using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Cloorne : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074185, // Hey you! Want to help me out?
				1074186 //Come here, I have a task.
			));
		}

		[Constructable]
		public Cloorne()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Cloorne";
			Title = "the expeditionist";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new ElvenBoots(0x3B2));
			AddItem(new RadiantScimitar());
			AddItem(new WingedHelm());

			Item item;

			item = new WoodlandLegs {
				Hue = 0x74A
			};
			AddItem(item);

			item = new HideChest {
				Hue = 0x726
			};
			AddItem(item);

			item = new LeafArms {
				Hue = 0x73E
			};
			AddItem(item);
		}

		public Cloorne(Serial serial)
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