using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Mulcivikh : Mage
	{
		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078131); // Allured by dark magic, aren't you?
		}

		[Constructable]
		public Mulcivikh()
		{
			Name = "Mulcivikh";
			Title = "the Necromancy Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x203D;
			HairHue = 0x457;

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
			AddItem(new Sandals(0x8FD));
			AddItem(new BoneHelm());

			Item item;

			item = new LeatherLegs {
				Hue = 0x2C3
			};
			AddItem(item);

			item = new LeatherGloves {
				Hue = 0x2C3
			};
			AddItem(item);

			item = new LeatherGorget {
				Hue = 0x2C3
			};
			AddItem(item);

			item = new LeatherChest {
				Hue = 0x2C3
			};
			AddItem(item);

			item = new LeatherArms {
				Hue = 0x2C3
			};
			AddItem(item);
		}

		public Mulcivikh(Serial serial)
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