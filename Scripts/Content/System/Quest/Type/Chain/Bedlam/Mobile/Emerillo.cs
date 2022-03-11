using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Emerillo (Bedlam)")]
	public class Emerillo : BaseCreature
	{
		public override bool IsInvulnerable => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1074222); // Could I trouble you for some assistance?
		}

		[Constructable]
		public Emerillo()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Emerillo";
			Title = "the cook";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new Backpack());
			AddItem(new Sandals(Utility.RandomNeutralHue()));
			AddItem(new ShortPants(Utility.RandomPinkHue()));
			AddItem(new Shirt());
			AddItem(new HalfApron(0x8FD));
		}

		public Emerillo(Serial serial)
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