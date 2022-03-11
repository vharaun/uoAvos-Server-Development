using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Oolua (Sanctuary)")]
	public class LorekeeperOolua : BaseCreature
	{
		// TODO: Add quest Dreadhorn

		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1074187); // Want a job?
		}

		[Constructable]
		public LorekeeperOolua()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Lorekeeper Oolua";
			Title = "the keeper of tradition";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new ElvenBoots(0x75A));
			AddItem(new Skirt(Utility.RandomBrightHue()));
			AddItem(new FancyShirt(0x742));
			AddItem(new Cloak(0x1BB));
			AddItem(new WildStaff());
		}

		public LorekeeperOolua(Serial serial)
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