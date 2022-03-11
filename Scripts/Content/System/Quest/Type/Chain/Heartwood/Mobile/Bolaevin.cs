using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Bolaevin : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Bolaevin()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Bolaevin";
			Title = "the arcanist";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots(0x3B2));
			AddItem(new RoyalCirclet());
			AddItem(new LeafChest());
			AddItem(new LeafArms());

			Item item;

			item = new LeafLegs {
				Hue = 0x1BB
			};
			AddItem(item);
		}

		public Bolaevin(Serial serial)
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