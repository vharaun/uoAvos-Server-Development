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
	public class SetStaticHueCommand : BaseCommand
	{
		public SetStaticHueCommand()
		{
			AccessLevel = AccessLevel.GameMaster;		
			Supports = CommandSupport.Simple; // Supports = CommandSupport.AllNPCs | CommandSupport.AllItems;
			Commands = new string[] { "SetStaticHue" };
			ObjectTypes = ObjectTypes.All;
			Usage = "SetStaticHue";
			Description = "Set the hue value of a static.";
		}

		public override bool ValidateArgs(BaseCommandImplementor impl, CommandEventArgs e)
		{
			bool retVal = true;

			if (e.Length != 1)
			{
				e.Mobile.SendMessage("You must specify the hue");
				retVal = false;
			}

			return retVal;
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			int Hue = e.GetInt32(0);

			if (obj is StaticTarget)
			{
				new SetStaticHue(e.Mobile.Map.MapID, (StaticTarget)obj, Hue).DoOperation();
			}
		}
	}
}