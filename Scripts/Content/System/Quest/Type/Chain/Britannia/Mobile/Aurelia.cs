using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Aurelia : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Aurelia()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Aurelia";
			Title = "the Architect's Daughter";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Sandals(Utility.RandomPinkHue()));

			if (Utility.RandomBool())
			{
				AddItem(new Kilt(Utility.RandomPinkHue()));
			}
			else
			{
				AddItem(new Skirt(Utility.RandomPinkHue()));
			}

			AddItem(new FancyShirt(Utility.RandomRedHue()));
		}

		public Aurelia(Serial serial)
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