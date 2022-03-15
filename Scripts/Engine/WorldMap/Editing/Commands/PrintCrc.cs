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
		[Usage("PrintCrc")]
		[Description("Increases the Z value of a static.")]
		private static void printCrc_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;
			Map playerMap = from.Map;
			TileMatrix tm = playerMap.Tiles;

			int blocknum = (((from.Location.X >> 3) * tm.BlockHeight) + (from.Location.Y >> 3));
			byte[] LandData = BlockUtility.GetLandData(blocknum, playerMap.MapID);
			byte[] StaticsData = BlockUtility.GetRawStaticsData(blocknum, playerMap.MapID);

			byte[] blockData = new byte[LandData.Length + StaticsData.Length];
			Array.Copy(LandData, blockData, LandData.Length);
			Array.Copy(StaticsData, 0, blockData, LandData.Length, StaticsData.Length);

			UInt16 crc = CRC.Fletcher16(blockData);
			Console.WriteLine("CRC is 0x" + crc.ToString("X4"));
		}
	}
}