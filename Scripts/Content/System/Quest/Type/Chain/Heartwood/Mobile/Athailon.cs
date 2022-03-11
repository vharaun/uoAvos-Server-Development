using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Athailon : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Athailon()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Athailon";
			Title = "the expeditionist";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots(0x901));
			AddItem(new WoodlandBelt());
			AddItem(new DiamondMace());

			Item item;

			item = new WoodlandLegs {
				Hue = 0x3B2
			};
			AddItem(item);

			item = new FemaleElvenPlateChest {
				Hue = 0x3B2
			};
			AddItem(item);

			item = new WoodlandArms {
				Hue = 0x3B2
			};
			AddItem(item);

			item = new WingedHelm {
				Hue = 0x3B2
			};
			AddItem(item);

		}

		public Athailon(Serial serial)
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