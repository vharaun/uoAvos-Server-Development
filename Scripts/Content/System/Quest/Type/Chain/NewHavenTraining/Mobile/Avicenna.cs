using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Avicenna : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078137); // A warrior needs to learn how to apply bandages to wounds.
		}

		[Constructable]
		public Avicenna()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Avicenna";
			Title = "the Healing Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x203B;
			HairHue = 0x477;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Focus, 120.0);

			AddItem(new Backpack());
			AddItem(new Robe(0x66D));
			AddItem(new Boots());
			AddItem(new GnarledStaff());
		}

		public Avicenna(Serial serial)
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