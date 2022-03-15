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
		[Usage("updateblock")]
		[Description("Sends Update statics & terrain Packet to the client.")]
		public static void updateBlock_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			from.Send(new Server.Engine.Facet.UpdateTerrainPacket(new Point2D(from.X >> 3, from.Y >> 3), from));
			from.Send(new Server.Engine.Facet.UpdateStaticsPacket(new Point2D(from.X >> 3, from.Y >> 3), from));

			Console.WriteLine("Sending update statics packet");
		}
	}
}