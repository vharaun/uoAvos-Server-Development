using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Chiyo : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078165); // To be undetected means you cannot be harmed.
		}

		[Constructable]
		public Chiyo()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Chiyo";
			Title = "the Hiding Instructor";
			BodyValue = 0xF7;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Hiding, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Tracking, 120.0);
			SetSkill(SkillName.Fencing, 120.0);
			SetSkill(SkillName.Stealth, 120.0);
			SetSkill(SkillName.Ninjitsu, 120.0);
		}

		public Chiyo(Serial serial)
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