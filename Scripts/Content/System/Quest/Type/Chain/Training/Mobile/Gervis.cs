using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Gervis : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074205, // Oh great adventurer, would you please assist a weak soul in need of aid?
				1074213, // Hey buddy.  Looking for work?
				1074211 // I could use some help.
			));
		}

		[Constructable]
		public Gervis()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Gervis";
			Title = "the blacksmith trainer";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Blacksmith, 60.0, 80.0);

			AddItem(new Backpack());
			AddItem(new Boots(0x3B3));
			AddItem(new ShortPants(0x1BB));
			AddItem(new Doublet(0x652));
			AddItem(new SmithHammer());

			Item item;

			item = new LeatherGloves {
				Hue = 0x3B2
			};
			AddItem(item);
		}

		public Gervis(Serial serial)
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