using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Ben : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Ben()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Ben";
			Title = "the Apprentice Necromancer";
			BodyValue = 0x190;
			Hue = 0x83FD;
			HairItemID = 0x2048;
			HairHue = 0x463;
			FacialHairItemID = 0x204C;
			FacialHairHue = 0x463;

			InitStats(100, 100, 25);

			AddItem(new Backpack());
			AddItem(new Shoes(0x901));
			AddItem(new LongPants(0x1BB));
			AddItem(new FancyShirt(0x756));

		}

		public Ben(Serial serial)
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