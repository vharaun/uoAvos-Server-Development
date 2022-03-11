using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Sadrah : BaseCreature
	{
		public override bool IsInvulnerable => true;

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
		public Sadrah()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Sadrah";
			Title = "the courier";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Boots(0x901));
			AddItem(new Skirt(0x52));
			AddItem(new Shirt(0x127));
			AddItem(new Cloak(0x65));
			AddItem(new Longsword());
		}

		public Sadrah(Serial serial)
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