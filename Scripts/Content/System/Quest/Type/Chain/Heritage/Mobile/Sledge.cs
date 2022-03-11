using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Sledge (Buc's Den)")]
	public class Sledge : BaseCreature
	{
		public override bool IsInvulnerable => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074188, // Weakling! You are not up to the task I have.
				1074195  // You there, in the stupid hat!   Come here.
			));
		}

		[Constructable]
		public Sledge()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Sledge";
			Title = "the Versatile";
			Body = 400;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			AddItem(new Tunic(Utility.RandomNeutralHue()));
			AddItem(new LongPants(Utility.RandomBlueHue()));
			AddItem(new Cloak(Utility.RandomBrightHue()));
			AddItem(new ElvenBoots(Utility.RandomNeutralHue()));
			AddItem(new Backpack());
		}

		public Sledge(Serial serial)
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