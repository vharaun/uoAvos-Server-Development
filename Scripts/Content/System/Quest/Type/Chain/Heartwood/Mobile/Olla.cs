using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Olla (The Heartwood)")]
	public class Olla : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074187, // Want a job?
				1074185 // Hey you! Want to help me out?
			));
		}

		[Constructable]
		public Olla()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Olla";
			Title = "the metal weaver";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new ElvenBoots());
			AddItem(new LongPants(0x3B3));
			AddItem(new SmithHammer());
			AddItem(new FullApron(0x1BB));
			AddItem(new ElvenShirt());

		}

		public Olla(Serial serial)
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