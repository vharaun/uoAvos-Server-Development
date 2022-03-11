using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Brinnae (The Heartwood)")]
	public class Brinnae : BaseCreature
	{
		public override bool IsInvulnerable => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074212, // *yawn* You busy?
				1074210 // Hi.  Looking for something to do?
			));
		}

		[Constructable]
		public Brinnae()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Brinnae";
			Title = "the wise";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new ElvenBoots());
			AddItem(new FemaleLeafChest());
			AddItem(new LeafArms());
			AddItem(new HidePants());
			AddItem(new ElvenCompositeLongbow());
		}

		public Brinnae(Serial serial)
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