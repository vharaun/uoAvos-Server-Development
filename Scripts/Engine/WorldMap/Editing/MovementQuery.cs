using Server;
using Server.Mobiles;
using Server.Network;

using System;

namespace Server.Engine.Facet
{
	public class MovementQuery : FacetEditingQuery
	{

		public static void Initialize()
		{
			PlayerMobile.BlockQuery = new MovementQuery();
		}

		public MovementQuery()
		{
		}

		public int QueryMobile(Mobile m, int previousMapBlock)
		{
			int blocknum = (((m.Location.X >> 3) * m.Map.Tiles.BlockHeight) + (m.Location.Y >> 3));

			if (blocknum != previousMapBlock)
			{
				m.Send(new Server.Engine.Facet.QueryClientHash(m));
			}

			return blocknum;
		}
	}
}