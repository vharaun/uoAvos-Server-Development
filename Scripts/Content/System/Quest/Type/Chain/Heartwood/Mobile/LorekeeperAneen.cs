using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class LorekeeperAneen : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public LorekeeperAneen()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Lorekeeper Aneen";
			Title = "the keeper of tradition";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Sandals(0x1BB));
			AddItem(new MaleElvenRobe(0x48F));
			AddItem(new MagicWand());
		}

		public LorekeeperAneen(Serial serial)
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