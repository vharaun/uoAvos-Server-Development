using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Master Gnosos (Bedlam)")]
	public class MasterGnosos : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1074186); // Come here, I have a task.
		}

		[Constructable]
		public MasterGnosos()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Master Gnosos";
			Title = "the necromancer";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = 0x83E8;
			InitStats(100, 100, 25);

			HairItemID = 0x2049;
			FacialHairItemID = 0x204B;

			AddItem(new Backpack());
			AddItem(new Shoes(0x485));
			AddItem(new Robe(0x497));

			SetSkill(SkillName.EvalInt, 60.0, 80.0);
			SetSkill(SkillName.Inscribe, 60.0, 80.0);
			SetSkill(SkillName.MagicResist, 60.0, 80.0);
			SetSkill(SkillName.SpiritSpeak, 60.0, 80.0);
			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Necromancy, 60.0, 80.0);
		}

		public MasterGnosos(Serial serial)
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