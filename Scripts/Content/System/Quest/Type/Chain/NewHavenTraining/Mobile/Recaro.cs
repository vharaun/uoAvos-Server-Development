using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Recaro : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1078187); // The art of fencing requires a dexterous hand, a quick wit and fleet feet.
		}

		[Constructable]
		public Recaro()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Recaro";
			Title = "the Fencer Instructor";
			BodyValue = 0x190;
			Hue = 0x83EA;
			HairItemID = 0x203C;
			HairHue = 0x455;
			FacialHairItemID = 0x204D;
			FacialHairHue = 0x455;

			InitStats(100, 100, 25);

			SetSkill(SkillName.Anatomy, 120.0);
			SetSkill(SkillName.Parry, 120.0);
			SetSkill(SkillName.Healing, 120.0);
			SetSkill(SkillName.Tactics, 120.0);
			SetSkill(SkillName.Fencing, 120.0);
			SetSkill(SkillName.Focus, 120.0);

			AddItem(new Backpack());
			AddItem(new Shoes(0x455));
			AddItem(new WarFork());

			Item item;

			item = new StuddedLegs {
				Hue = 0x455
			};
			AddItem(item);

			item = new StuddedGloves {
				Hue = 0x455
			};
			AddItem(item);

			item = new StuddedGorget {
				Hue = 0x455
			};
			AddItem(item);

			item = new StuddedChest {
				Hue = 0x455
			};
			AddItem(item);

			item = new StuddedArms {
				Hue = 0x455
			};
			AddItem(item);
		}

		public Recaro(Serial serial)
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