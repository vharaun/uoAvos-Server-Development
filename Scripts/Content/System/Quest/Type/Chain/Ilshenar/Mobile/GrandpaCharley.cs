using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class GrandpaCharley : BaseCreature
	{
		public override bool IsInvulnerable => true;
		public override bool CanTeach => true;

		[Constructable]
		public GrandpaCharley()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Grandpa Charley";
			Title = "the farmer";
			Body = 400;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			var hairHue = 0x3B2 + Utility.Random(2);
			Utility.AssignRandomHair(this, hairHue);

			FacialHairItemID = 0x203E; // Long Beard
			FacialHairHue = hairHue;

			SetSkill(SkillName.ItemID, 80, 90);

			AddItem(new WideBrimHat(Utility.RandomNondyedHue()));
			AddItem(new FancyShirt(Utility.RandomNondyedHue()));
			AddItem(new LongPants(Utility.RandomNondyedHue()));
			AddItem(new Sandals(Utility.RandomNeutralHue()));
			AddItem(new ShepherdsCrook());
			AddItem(new Backpack());
		}

		public GrandpaCharley(Serial serial)
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