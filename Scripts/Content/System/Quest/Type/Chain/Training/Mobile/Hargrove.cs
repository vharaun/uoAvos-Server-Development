using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Hargrove : BaseCreature
	{
		public override bool IsInvulnerable => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074213, // Hey buddy.  Looking for work?
				1074211 // I could use some help.
			));
		}

		[Constructable]
		public Hargrove()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Hargrove";
			Title = "the Lumberjack";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Boots(0x901));
			AddItem(new StuddedLegs());
			AddItem(new Shirt(0x288));
			AddItem(new Bandana(0x20));
			AddItem(new BattleAxe());

			Item item;

			item = new PlateGloves {
				Hue = 0x21E
			};
			AddItem(item);

		}

		public Hargrove(Serial serial)
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