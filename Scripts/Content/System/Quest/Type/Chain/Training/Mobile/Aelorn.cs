using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Aelorn : KeeperOfChivalry
	{
		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078133); // Hail, friend. Want to live the life of a paladin?
		}

		[Constructable]
		public Aelorn()
		{
			Name = "Aelorn";
			Title = "the Chivalry Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x203C;
			HairHue = 0x47D;
			FacialHairItemID = 0x204D;
			FacialHairHue = 0x47D;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.MagicResist, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Meditation, 120.0);
			SetSkill(SkillName.Focus, 120.0);
			SetSkill(SkillName.Chivalry, 120.0);
		}

		public override void InitOutfit()
		{
			AddItem(new Backpack());
			AddItem(new VikingSword());
			AddItem(new PlateChest());
			AddItem(new PlateLegs());
			AddItem(new PlateGloves());
			AddItem(new PlateArms());
			AddItem(new PlateGorget());
			AddItem(new OrderShield());
		}

		public Aelorn(Serial serial)
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