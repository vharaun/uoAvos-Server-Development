using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Nillaen (The Heartwood)")]
	public class LorekeeperNillaen : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		[Constructable]
		public LorekeeperNillaen()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Lorekeeper Nillaen";
			Title = "the keeper of tradition";
			Race = Race.Elf;
			BodyValue = 0x25E;
			Female = true;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new Shoes(0x1BB));
			AddItem(new LongPants(0x1FB));
			AddItem(new ElvenShirt());
			AddItem(new GemmedCirclet());
			AddItem(new BodySash(0x25));
			AddItem(new BlackStaff());
		}

		public LorekeeperNillaen(Serial serial)
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