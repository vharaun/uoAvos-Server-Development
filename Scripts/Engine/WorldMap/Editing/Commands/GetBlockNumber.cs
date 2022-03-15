using Server;
using Server.Commands;
using Server.Commands.Generic;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Engine.Facet
{
	public partial class FacetEditingCommands
	{
		[Usage("GetBlockNumber")]
		[Description("Returns the current block number")]
		private static void getBlockNumber_OnCommand(CommandEventArgs e)
		{
			int x = e.Mobile.Location.X;
			int y = e.Mobile.Location.Y;

			Map map = e.Mobile.Map;
			TileMatrix tm = map.Tiles;

			int blocknum = (((x >> 3) * tm.BlockHeight) + (y >> 3));

			e.Mobile.SendMessage(string.Format("Your block number is {0}", blocknum));
		}
	}
}