using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Andros : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Andros()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Andros";
			Title = "the Blacksmith";
			BodyValue = 0x190;
			Hue = 0x8409;
			FacialHairItemID = 0x2041;
			FacialHairHue = 0x45E;
			HairItemID = 0x2049;
			HairHue = 0x45E;

			InitStats(100, 100, 25);

			AddItem(new Backpack());
			AddItem(new Boots(0x901));
			AddItem(new FancyShirt(0x60B));
			AddItem(new LongPants(0x1BB));
			AddItem(new FullApron(0x901));
			AddItem(new SmithHammer());
		}

		public Andros(Serial serial)
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