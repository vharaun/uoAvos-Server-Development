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
		[Usage("queryclienthash")]
		[Description("sends the client a request to hash its surrounding blocks")]
		public static void queryClientHash_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;
			from.Send(new Server.Engine.Facet.QueryClientHash(from));
		}
	}
}