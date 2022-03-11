using Server.Engines.Quests.Definitions;
using Server.Mobiles;

namespace Server.Engines.Quests.Items
{
	public class UzeraanTurmoilHorn : HornOfRetreat
	{
		public override bool ValidateUse(Mobile from)
		{
			var pm = from as PlayerMobile;

			return (pm != null && pm.Quest is UzeraanTurmoilQuest);
		}

		[Constructable]
		public UzeraanTurmoilHorn()
		{
			DestLoc = new Point3D(3597, 2582, 0);
			DestMap = Map.Trammel;
		}

		public UzeraanTurmoilHorn(Serial serial) : base(serial)
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