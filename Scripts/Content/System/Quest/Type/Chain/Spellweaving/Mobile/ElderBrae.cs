using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Elder Brae (Sanctuary)")]
	public class ElderBrae : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074215, // Don’t test my patience you sniveling worm!
				1074218  // Hey!  I want to talk to you, now.
			));
		}

		[Constructable]
		public ElderBrae()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2.0)
		{
			Name = "Elder Brae";
			Title = "the wise";
			Race = Race.Elf;
			Female = true;
			Body = 606;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new GemmedCirclet());
			AddItem(new FemaleElvenRobe(Utility.RandomBrightHue()));
			AddItem(new ElvenBoots(Utility.RandomAnimalHue()));
		}

		public ElderBrae(Serial serial)
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