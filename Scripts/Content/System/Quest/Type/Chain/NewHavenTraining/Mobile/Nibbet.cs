using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Nibbet : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Nibbet()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Nibbet";
			Title = "the tinker";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Boots(0x591));
			AddItem(new ShortPants(0xF8));
			AddItem(new Shirt(0x2D));
			AddItem(new FullApron(0x288));
		}

		public Nibbet(Serial serial)
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