using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Maul")]
	public class MaulTheBear : GrizzlyBear
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public MaulTheBear()
		{
			Name = "Maul";
			AI = AIType.AI_Vendor;
			FightMode = FightMode.None;
			Tamable = false;
		}

		public MaulTheBear(Serial serial)
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