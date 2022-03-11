using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Drithen (Umbra)")]
	public class Drithen : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1074188); // Weakling! You are not up to the task I have.
		}

		[Constructable]
		public Drithen()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Drithen";
			Title = "the Fierce";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			AddItem(new Backpack());
			AddItem(new ElvenBoots(Utility.RandomNeutralHue()));
			AddItem(new LongPants(Utility.RandomBlueHue()));
			AddItem(new Tunic(Utility.RandomNeutralHue()));
			AddItem(new Cloak(Utility.RandomBrightHue()));

			SetSkill(SkillName.Focus, 60.0, 80.0);
		}

		public Drithen(Serial serial)
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