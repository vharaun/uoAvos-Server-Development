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
	public class DelStaticCommand : BaseCommand
	{
		public DelStaticCommand()
		{
			AccessLevel = AccessLevel.GameMaster;	
			Supports = CommandSupport.Simple; // Supports = CommandSupport.AllNPCs | CommandSupport.AllItems;
			Commands = new string[] { "DelStatic" };
			ObjectTypes = ObjectTypes.All;
			Usage = "DelStatic";
			Description = "Delete a static.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			if (obj is StaticTarget)
			{
				new DeleteStatic(e.Mobile.Map.MapID, (StaticTarget)obj).DoOperation();
			}
		}
	}
}