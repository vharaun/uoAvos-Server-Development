using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Elder Alejaha (The Heartwood)")]
	public class Alejaha : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1074223); // Have you done it yet?  Oh, I haven’t told you, have I?
		}

		[Constructable]
		public Alejaha()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Elder Alejaha";
			Title = "the wise";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new Sandals(Utility.RandomYellowHue()));
			AddItem(new ElvenShirt(Utility.RandomYellowHue()));
			AddItem(new GemmedCirclet());
			AddItem(new Cloak(Utility.RandomBrightHue()));

			if (Utility.RandomBool())
			{
				AddItem(new Kilt(0x387));
			}
			else
			{
				AddItem(new Skirt(0x387));
			}
		}

		public Alejaha(Serial serial)
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