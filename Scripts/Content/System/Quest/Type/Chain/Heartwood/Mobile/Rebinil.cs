using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Rebinil : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Rebinil()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Rebinil";
			Title = "the healer";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Sandals(0x715));
			AddItem(new FemaleElvenRobe(0x742));
			AddItem(new RoyalCirclet());
		}

		public Rebinil(Serial serial)
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