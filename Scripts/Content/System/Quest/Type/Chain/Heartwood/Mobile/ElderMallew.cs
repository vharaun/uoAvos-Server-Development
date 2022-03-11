using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class ElderMallew : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public ElderMallew()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Elder Mallew";
			Title = "the wise";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots(0x1BB));
			AddItem(new Cloak(0x3B2));
			AddItem(new Circlet());

			Item item;

			item = new LeafTonlet {
				Hue = 0x544
			};
			AddItem(item);

			item = new LeafChest {
				Hue = 0x538
			};
			AddItem(item);

			item = new LeafArms {
				Hue = 0x528
			};
			AddItem(item);
		}

		public ElderMallew(Serial serial)
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