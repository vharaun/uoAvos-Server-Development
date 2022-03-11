using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Daelas : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Daelas()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Daelas";
			Title = "the arborist";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots(0x901));
			AddItem(new ElvenPants(0x8AB));

			Item item;

			item = new LeafChest {
				Hue = 0x8B0
			};
			AddItem(item);

			item = new LeafGloves {
				Hue = 0x1BB
			};
			AddItem(item);

		}

		public Daelas(Serial serial)
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