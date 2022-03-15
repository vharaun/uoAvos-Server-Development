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
	public class IncStaticXCommand : BaseCommand
	{
		public IncStaticXCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.Simple;
			Commands = new string[] { "IncSX" };
			ObjectTypes = ObjectTypes.All;
			Usage = "IncSX";
			Description = "Increases the x value of a static.";
		}
		public override bool ValidateArgs(BaseCommandImplementor impl, CommandEventArgs e)
		{
			bool retVal = true;

			if (e.Length != 1)
			{
				e.Mobile.SendMessage("You must specify an amount to change the x coord.");
				retVal = false;
			}

			return retVal;
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			int change = e.GetInt32(0);

			if (obj is StaticTarget)
			{
				new IncStaticX(e.Mobile.Map.MapID, (StaticTarget)obj, change).DoOperation();
			}
		}
	}

	public class IncStaticYCommand : BaseCommand
	{
		public IncStaticYCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.Simple;
			Commands = new string[] { "IncSY" };
			ObjectTypes = ObjectTypes.All;
			Usage = "IncSY";
			Description = "Increases the y value of a static.";
		}
		public override bool ValidateArgs(BaseCommandImplementor impl, CommandEventArgs e)
		{
			bool retVal = true;

			if (e.Length != 1)
			{
				e.Mobile.SendMessage("You must specify an amount to change the y coord.");
				retVal = false;
			}

			return retVal;
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			int change = e.GetInt32(0);

			if (obj is StaticTarget)
			{
				new IncStaticY(e.Mobile.Map.MapID, (StaticTarget)obj, change).DoOperation();
			}
		}
	}
}