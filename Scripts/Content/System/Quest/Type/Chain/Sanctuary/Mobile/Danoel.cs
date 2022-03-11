using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Danoel (Sanctuary)")]
	public class Danoel : BaseCreature
	{
		// TODO: Add quests: Spring Cleaning

		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, 1074197); // Pardon me, but if you could spare some time I’d greatly appreciate it.
		}

		[Constructable]
		public Danoel()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Danoel";
			Title = "the metal weaver";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new ElvenBoots(0x901));
			AddItem(new ElvenPants(0x386));
			AddItem(new ElvenShirt(0x75F));
			AddItem(new FullApron(0x1BB));
			AddItem(new RoyalCirclet());
			AddItem(new SmithHammer());
		}

		public Danoel(Serial serial)
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