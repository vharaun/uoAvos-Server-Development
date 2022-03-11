using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Belulah (Nujel'm)")] // On OSI it's "Belulah (Nu'Jelm)" (incorrect spelling)
	public class Belulah : BaseCreature
	{
		public override bool IsInvulnerable => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			/*
			 * 1074205 - Oh great adventurer, would you please assist a weak soul in need of aid?
			 * 1074206 - Excuse me please traveler, might I have a little of your time?
			 */
			ChainQuestSystem.Tell(this, pm, Utility.Random(1074205, 2));
		}

		[Constructable]
		public Belulah()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Belulah";
			Title = "the scorned";
			Female = true;
			Body = 401;
			Hue = Race.RandomSkinHue();
			InitStats(100, 100, 25);

			Utility.AssignRandomHair(this, true);

			AddItem(new FancyShirt(Utility.RandomBlueHue()));
			AddItem(new LongPants(Utility.RandomNondyedHue()));
			AddItem(new Boots());
		}

		public Belulah(Serial serial)
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