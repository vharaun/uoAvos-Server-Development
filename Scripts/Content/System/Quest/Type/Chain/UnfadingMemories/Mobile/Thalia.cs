using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Thalia (Nujel'm)")] // OSI's description is "Bride", not very helpful
	public class Thalia : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Thalia()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Thalia";
			Title = "the Bride";
			Race = Race.Human;
			BodyValue = 0x191;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Sandals(0x8FD));
			AddItem(new FancyDress(0x8FD));

		}

		public Thalia(Serial serial)
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