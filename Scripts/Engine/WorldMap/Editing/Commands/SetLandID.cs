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
	public class SetLandIDCommand : BaseCommand
	{
		public SetLandIDCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.Simple; // Supports = CommandSupport.AllNPCs | CommandSupport.AllItems;
			Commands = new string[] { "SetLandID" };
			ObjectTypes = ObjectTypes.All;
			Usage = "SetLandID";
			Description = "Set the ID value of a land tile";
		}

		public override bool ValidateArgs(BaseCommandImplementor impl, CommandEventArgs e)
		{
			bool retVal = true;

			if (e.Length != 1)
			{
				e.Mobile.SendMessage("You must specify the Item ID");
				retVal = false;
			}

			return retVal;
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			int ID = e.GetInt32(0);

			if (obj is IPoint3D)
			{
				IPoint3D location = (IPoint3D)obj;
				new SetLandID(location.X, location.Y, e.Mobile.Map.MapID, ID).DoOperation();
			}
		}
	}
}