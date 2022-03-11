using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Yellienir : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Yellienir()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Yellienir";
			Title = "the bark weaver";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots());
			AddItem(new LeafTonlet());
			AddItem(new FemaleLeafChest());
			AddItem(new LeafArms());
			AddItem(new Cloak(0x3B2));
		}

		public Yellienir(Serial serial)
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