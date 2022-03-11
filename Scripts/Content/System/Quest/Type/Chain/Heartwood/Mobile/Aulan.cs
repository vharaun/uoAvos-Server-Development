using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Aulan (The Heartwood)")]
	public class Aulan : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074188, // Weakling! You are not up to the task I have.
				1074191, // Just keep walking away!  I thought so. Coward!  I’ll bite your legs off!
				1074195 // You there, in the stupid hat!   Come here.
			));
		}

		[Constructable]
		public Aulan()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Aulan";
			Title = "the expeditionist";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			Item item;

			item = new ElvenBoots {
				Hue = Utility.RandomYellowHue()
			};
			AddItem(item);

			AddItem(new ElvenPants(Utility.RandomGreenHue()));
			AddItem(new Cloak(Utility.RandomGreenHue()));
			AddItem(new Circlet());

			item = new HideChest {
				Hue = Utility.RandomYellowHue()
			};
			AddItem(item);

			item = new HideGloves {
				Hue = Utility.RandomYellowHue()
			};
			AddItem(item);
		}

		public Aulan(Serial serial)
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