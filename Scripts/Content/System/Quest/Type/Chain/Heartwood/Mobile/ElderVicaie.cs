using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class ElderVicaie : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public ElderVicaie()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Elder Vicaie";
			Title = "the wise";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots());
			AddItem(new Tunic(0x732));

			Item item;

			item = new LeafLegs {
				Hue = 0x3B2
			};
			AddItem(item);
		}

		public ElderVicaie(Serial serial)
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