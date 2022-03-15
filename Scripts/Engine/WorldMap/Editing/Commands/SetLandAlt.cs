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
	public class SetLandAltCommand : BaseCommand
	{
		public SetLandAltCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.Simple;
			Commands = new string[] { "SetLandAlt" };
			ObjectTypes = ObjectTypes.All;
			Usage = "SetLandAlt";
			Description = "Set the Z altitude of a land tile";
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

			if (obj is IPoint3D)
			{
				IPoint3D location = (IPoint3D)obj;
				new SetLandAltitude(location.X, location.Y, e.Mobile.Map.MapID, change).DoOperation();
			}
		}
	}
}