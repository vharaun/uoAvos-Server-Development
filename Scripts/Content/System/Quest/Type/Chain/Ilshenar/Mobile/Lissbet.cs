using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Lissbet : BaseEscortable
	{
		public override bool StaticChainQuester => true;  // Changed "StaticMLQuester" to "StaticChainQuester"
		public override bool InitialInnocent => true;

		public override bool CanShout => true;
		public override void Shout(PlayerMobile pm)
		{
			ChainQuestSystem.Tell(this, pm, Utility.RandomList(
				1074204, // Greetings seeker.  I have an urgent matter for you, if you are willing.
				1074222  // Could I trouble you for some assistance?
			));
		}

		[Constructable]
		public Lissbet()
		{
		}

		public override void InitBody()
		{
			SetStr(40, 50);
			SetDex(70, 80);
			SetInt(80, 90);

			Hue = Utility.RandomSkinHue();
			Female = true;
			Body = 401;
			Name = "Lissbet";
			Title = "the flower girl";

			HairItemID = 0x203D;
			HairHue = 0x1BB;
		}

		public override void InitOutfit()
		{
			AddItem(new Kilt(Utility.RandomYellowHue()));
			AddItem(new FancyShirt(Utility.RandomYellowHue()));
			AddItem(new Sandals());
		}

		public Lissbet(Serial serial)
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