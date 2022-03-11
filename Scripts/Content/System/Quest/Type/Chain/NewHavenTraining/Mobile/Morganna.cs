using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Morganna : Mage
	{
		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078132); // Want to learn how to channel the supernatural?
		}

		[Constructable]
		public Morganna()
		{
			Name = "Morganna";
			Title = "the Spirit Speak Instructor";
			BodyValue = 0x191;
			Female = true;
			Hue = 0x83EA;
			HairItemID = 0x203C;
			HairHue = 0x455;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Magery, 120.0);
			SetSkill(SkillName.MagicResist, 120.0);
			SetSkill(SkillName.SpiritSpeak, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Meditation, 120.0);
			SetSkill(SkillName.Necromancy, 120.0);
		}

		public override void InitOutfit()
		{
			AddItem(new Backpack());
			AddItem(new Sandals());
			AddItem(new Robe(0x47D));
			AddItem(new SkullCap(0x455));
		}

		public Morganna(Serial serial)
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