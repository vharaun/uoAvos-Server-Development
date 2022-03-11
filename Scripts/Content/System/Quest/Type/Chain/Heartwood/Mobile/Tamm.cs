using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Tamm (The Heartwood)")]
	public class Tamm : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074213, // Hey buddy.  Looking for work?
				1074187 // Want a job?
			));
		}

		[Constructable]
		public Tamm()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Tamm";
			Title = "the guard";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new ElvenBoots());
			AddItem(new HidePants());
			AddItem(new HidePauldrons());
			AddItem(new WingedHelm());
			AddItem(new HideChest());
			AddItem(new ElvenCompositeLongbow());
		}

		public Tamm(Serial serial)
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