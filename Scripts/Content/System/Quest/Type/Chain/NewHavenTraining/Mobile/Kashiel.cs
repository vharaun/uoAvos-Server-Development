using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Kashiel : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Kashiel()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Kashiel";
			Title = "the archer";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());

			Item item;

			item = new LeatherChest {
				Hue = 0x1BB
			};
			AddItem(item);

			item = new LeatherLegs {
				Hue = 0x901
			};
			AddItem(item);

			item = new LeatherArms {
				Hue = 0x901
			};
			AddItem(item);

			item = new LeatherGloves {
				Hue = 0x1BB
			};
			AddItem(item);

			AddItem(new Boots(0x1BB));
			AddItem(new CompositeBow());
		}

		public Kashiel(Serial serial)
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