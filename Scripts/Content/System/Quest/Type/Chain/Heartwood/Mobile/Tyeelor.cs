using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Tyeelor : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Tyeelor()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Tyeelor";
			Title = "the expeditionist";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots(0x1BB));

			Item item;

			item = new WoodlandLegs {
				Hue = 0x236
			};
			AddItem(item);

			item = new WoodlandChest {
				Hue = 0x236
			};
			AddItem(item);

			item = new WoodlandArms {
				Hue = 0x236
			};
			AddItem(item);

			item = new VultureHelm {
				Hue = 0x236
			};
			AddItem(item);

			item = new WoodlandBelt {
				Hue = 0x236
			};
			AddItem(item);

		}

		public Tyeelor(Serial serial)
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