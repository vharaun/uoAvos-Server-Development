using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class JacobWaltz : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078124); // You there! I can use some help mining these rocks!
		}

		[Constructable]
		public JacobWaltz()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Jacob Waltz";
			Title = "the Miner Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x2048;
			HairHue = 0x44E;
			FacialHairItemID = 0x204D;
			FacialHairHue = 0x44E;

			InitStats(100, 100, 25);

			SetSkill(SkillName.ArmsLore, 120.0);
			SetSkill(SkillName.Blacksmith, 120.0);
			SetSkill(SkillName.Magery, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Tinkering, 120.0);
			SetSkill(SkillName.Swords, 120.0);
			SetSkill(SkillName.Mining, 120.0);

			AddItem(new Backpack());
			AddItem(new Pickaxe());
			AddItem(new Boots());
			AddItem(new WideBrimHat(0x966));
			AddItem(new ShortPants(0x370));
			AddItem(new Shirt(0x966));
			AddItem(new HalfApron(0x1BB));
		}

		public JacobWaltz(Serial serial)
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