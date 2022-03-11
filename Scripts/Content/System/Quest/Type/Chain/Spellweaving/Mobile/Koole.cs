using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Koole (Sanctuary)")]
	public class Koole : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074186, // Come here, I have a task.
				1074218  // Hey!  I want to talk to you, now.
			));
		}

		[Constructable]
		public Koole()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2.0)
		{
			Name = "Koole";
			Title = "the arcanist";
			Race = Race.Elf;
			Body = 605;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			Item item;

			item = new LeafChest {
				Hue = 443
			};
			AddItem(item);

			item = new LeafArms {
				Hue = 443
			};
			AddItem(item);

			AddItem(new LeafTonlet());
			AddItem(new ThighBoots(Utility.RandomAnimalHue()));
			AddItem(new RoyalCirclet());
		}

		public Koole(Serial serial)
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