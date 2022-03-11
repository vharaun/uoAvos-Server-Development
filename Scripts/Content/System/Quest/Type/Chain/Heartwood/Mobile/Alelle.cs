using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Alelle : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Alelle()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Alelle";
			Title = "the arborist";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots(0x1BB));

			Item item;

			item = new FemaleLeafChest {
				Hue = 0x3A
			};
			AddItem(item);

			item = new LeafLegs {
				Hue = 0x74C
			};
			AddItem(item);

			item = new LeafGloves {
				Hue = 0x1BB
			};
			AddItem(item);
		}

		public Alelle(Serial serial)
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