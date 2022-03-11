using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	//[QuesterName( "Clarisse" )] // On OSI the gumps refer to her as this, different from actual name
	public class Clairesse : BaseCreature
	{
		public override bool IsInvulnerable => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074205, // Oh great adventurer, would you please assist a weak soul in need of aid?
				1074213 // Hey buddy.  Looking for work?
			));
		}

		[Constructable]
		public Clairesse()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Clairesse";
			Title = "the servant";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Shoes(Utility.RandomNeutralHue()));
			AddItem(new PlainDress(0x3C9));
		}

		public Clairesse(Serial serial)
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