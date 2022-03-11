using Server.Mobiles;

namespace Server.Engines.ChainQuests.Mobiles
{
	[QuesterName("Szandor")]
	public class SkeletonOfSzandor : BaseCreature
	{
		public override bool IsInvulnerable => true;

		[Constructable]
		public SkeletonOfSzandor()
			: base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
		{
			Name = "Skeleton of Szandor";
			Title = "the Late Architect";
			Hue = 0x83F2; // TODO: Random human hue? Why???
			Body = 0x32;
			InitStats(100, 100, 25);
		}

		public SkeletonOfSzandor(Serial serial)
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