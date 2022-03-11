using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	public class Huntsman : Centaur
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public Huntsman()
		{
			Name = "Huntsman";
			AI = AIType.AI_Vendor;
			FightMode = FightMode.None;
		}

		public Huntsman(Serial serial)
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