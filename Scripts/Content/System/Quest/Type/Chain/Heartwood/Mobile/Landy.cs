using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Landy (The Heartwood)")]
	public class Landy : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074211, // I could use some help.
				1074218 // Hey!  I want to talk to you, now.
			));
		}

		[Constructable]
		public Landy()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Landy";
			Title = "the soil nurturer";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new Sandals(Utility.RandomYellowHue()));
			AddItem(new ShortPants(Utility.RandomYellowHue()));
			AddItem(new Tunic(Utility.RandomYellowHue()));

			Item gloves = new LeafGloves {
				Hue = Utility.RandomYellowHue()
			};
			AddItem(gloves);
		}

		public Landy(Serial serial)
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