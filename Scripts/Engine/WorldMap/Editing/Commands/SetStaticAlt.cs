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
	public class SetStaticAltCommand : BaseCommand
	{
		public SetStaticAltCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.Simple; // Supports = CommandSupport.AllNPCs | CommandSupport.AllItems;
			Commands = new string[] { "SetStaticAlt" };
			ObjectTypes = ObjectTypes.All;
			Usage = "SetStaticAlt";
			Description = "Set the Z value of a static.";
		}

		public override bool ValidateArgs(BaseCommandImplementor impl, CommandEventArgs e)
		{
			bool retVal = true;

			if (e.Length != 1)
			{
				e.Mobile.SendMessage("You must specify the z coord.");
				retVal = false;
			}

			return retVal;
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			int change = e.GetInt32(0);

			if (obj is StaticTarget)
			{
				new SetStaticAltitude(e.Mobile.Map.MapID, (StaticTarget)obj, change).DoOperation();
			}
		}
	}
}