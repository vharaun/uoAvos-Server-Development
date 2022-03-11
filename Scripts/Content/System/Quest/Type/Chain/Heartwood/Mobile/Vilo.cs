using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Vilo (The Heartwood)")]
	public class Vilo : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074210, // Hi.  Looking for something to do?
				1074220 // May I call you friend?  I have a favor to beg of you.
			));
		}

		[Constructable]
		public Vilo()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Vilo";
			Title = "the guard";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new ElvenBoots(0x901));
			AddItem(new OrnateAxe());
			AddItem(new WoodlandBelt(0x592));
			AddItem(new VultureHelm());
			AddItem(new WoodlandLegs());
			AddItem(new WoodlandChest());
			AddItem(new WoodlandArms());
			AddItem(new WoodlandGorget());
		}

		public Vilo(Serial serial)
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