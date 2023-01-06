using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class AndreasVesalius : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078138); // Learning of the body will allow you to excel in combat.
		}

		[Constructable]
		public AndreasVesalius()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Andreas Vesalius";
			Title = "the Anatomy Instructor";
			BodyValue = 0x190;
			Hue = 0x83EC;
			HairItemID = 0x203C;
			HairHue = 0x477;
			FacialHairItemID = 0x203E;
			FacialHairHue = 0x477;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Focus, 120.0);

			AddItem(new Backpack());
			AddItem(new Boots());
			AddItem(new BlackStaff());
			AddItem(new LongPants());
			AddItem(new Tunic(0x66D));
		}

		public AndreasVesalius(Serial serial)
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