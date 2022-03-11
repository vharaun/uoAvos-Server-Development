using Server.Engines.Quests.Definitions;
using Server.Mobiles;

namespace Server.Engines.Quests.Items
{
	public class DarkTidesHorn : HornOfRetreat
	{
		public override bool ValidateUse(Mobile from)
		{
			var pm = from as PlayerMobile;

			return (pm != null && pm.Quest is DarkTidesQuest);
		}

		[Constructable]
		public DarkTidesHorn()
		{
			DestLoc = new Point3D(2103, 1319, -68);
			DestMap = Map.Malas;
		}

		public DarkTidesHorn(Serial serial) : base(serial)
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