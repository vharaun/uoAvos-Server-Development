using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Anolly (The Heartwood)")]
	public class Anolly : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		[Constructable]
		public Anolly()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Anolly";
			Title = "the bark weaver";
			Race = Race.Elf;
			BodyValue = 0x25D;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			SetSkill(SkillName.Meditation, 60.0, 80.0);
			SetSkill(SkillName.Focus, 60.0, 80.0);

			AddItem(new Sandals(0x901));
			AddItem(new ShortPants(0x3B3));
			AddItem(new FullApron(0x1BB));
			AddItem(new SmithHammer());
		}

		public Anolly(Serial serial)
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