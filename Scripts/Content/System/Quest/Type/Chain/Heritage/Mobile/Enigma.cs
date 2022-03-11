using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Enigma : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Enigma()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Enigma";
			BodyValue = 788;
			BaseSoundID = 0x3EE;

			InitStats(100, 100, 25);
		}

		public Enigma(Serial serial)
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