using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Aernya (Umbra)")]
	public class Aernya : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Aernya()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Aernya";
			Title = "the Mistress of Admissions";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Sandals(Utility.RandomNeutralHue()));
			AddItem(new Skirt(Utility.RandomBool() ? 0x1 : 0x0));
			AddItem(new Cloak(Utility.RandomBrightHue()));
			AddItem(new FancyShirt(Utility.RandomBool() ? 0x3B2 : 0x3B3));
		}

		public Aernya(Serial serial)
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