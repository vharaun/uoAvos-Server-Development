using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Andric : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074205, // Oh great adventurer, would you please assist a weak soul in need of aid?
				1074213 // Hey buddy.  Looking for work?
			));
		}

		[Constructable]
		public Andric()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Andric";
			Title = "the archer trainer";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Archery, 60.0, 80.0);

			AddItem(new Backpack());

			Item item;

			item = new LeatherChest {
				Hue = 0x1BB
			};
			AddItem(item);

			item = new LeatherLegs {
				Hue = 0x6AD
			};
			AddItem(item);

			item = new LeatherArms {
				Hue = 0x6AD
			};
			AddItem(item);

			item = new LeatherGloves {
				Hue = 0x1BB
			};
			AddItem(item);

			AddItem(new Boots(0x1BB));
			AddItem(new CompositeBow());
		}

		public Andric(Serial serial)
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