using Server;
using Server.Commands;
using Server.Commands.Generic;
using Server.Engines.Facet;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

/// This file is the command registry for the commands in the 'Scripts/Communication/Game/Command/Type' 
/// and the 'Scripts/Engine/WorldMap/Editing/Commands' directories. 
/// 
/// Editing any of the entries contained in this file could result in loss of function.
/// 
/// CommandHandler Format: Register (yourCommand, AccessLevel.AccessLevel, new CommandEventHandler(yourCommand_OnCommand));
/// Instructions: Look for this namespace below: Server.Commands
///               
/// TargetCommand Format: Register (new yourCommand()); 
/// Instructions: Look for this namespace below:  Server.Commands.Generic
///                         
/// If you follow the directions above you will be able to add new commands to your server seamlessly.

#region Register CH

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		public static void Initialize()
		{
			CommandSystem.Prefix = "[";

			Register("Animate", AccessLevel.GameMaster, new CommandEventHandler(Animate_OnCommand));
			Register("APN", AccessLevel.Counselor, new CommandEventHandler(APN_OnCommand));
			Register("AutoPageNotify", AccessLevel.Counselor, new CommandEventHandler(APN_OnCommand));
			Register("B", AccessLevel.GameMaster, new CommandEventHandler(BroadcastMessage_OnCommand));
			Register("BackgroundSave", AccessLevel.Administrator, new CommandEventHandler(BackgroundSave_OnCommand));
			Register("Bank", AccessLevel.GameMaster, new CommandEventHandler(Bank_OnCommand));
			Register("BC", AccessLevel.GameMaster, new CommandEventHandler(BroadcastMessage_OnCommand));
			Register("BCast", AccessLevel.GameMaster, new CommandEventHandler(BroadcastMessage_OnCommand));
			Register("BGSave", AccessLevel.Administrator, new CommandEventHandler(BackgroundSave_OnCommand));
			Register("Cast", AccessLevel.Counselor, new CommandEventHandler(Cast_OnCommand));
			Register("ClearFacet", AccessLevel.Administrator, new CommandEventHandler(ClearFacet_OnCommand));
			Register("Client", AccessLevel.Counselor, new CommandEventHandler(Client_OnCommand));
			Register("DropHolding", AccessLevel.Counselor, new CommandEventHandler(DropHolding_OnCommand));
			Register("Echo", AccessLevel.Counselor, new CommandEventHandler(Echo_OnCommand));
			Register("GetFollowers", AccessLevel.GameMaster, new CommandEventHandler(GetFollowers_OnCommand));
			Register("Go", AccessLevel.Counselor, new CommandEventHandler(Go_OnCommand));
			Register("Help", AccessLevel.Player, new CommandEventHandler(Help_OnCommand));
			Register("Light", AccessLevel.Counselor, new CommandEventHandler(Light_OnCommand));
			Register("Move", AccessLevel.GameMaster, new CommandEventHandler(Move_OnCommand));
			Register("ReplaceBankers", AccessLevel.Administrator, new CommandEventHandler(ReplaceBankers_OnCommand));
			Register("S", AccessLevel.Counselor, new CommandEventHandler(StaffMessage_OnCommand));
			Register("Save", AccessLevel.Administrator, new CommandEventHandler(Save_OnCommand));
			Register("SaveBG", AccessLevel.Administrator, new CommandEventHandler(BackgroundSave_OnCommand));
			Register("SM", AccessLevel.Counselor, new CommandEventHandler(StaffMessage_OnCommand));
			Register("SMsg", AccessLevel.Counselor, new CommandEventHandler(StaffMessage_OnCommand));
			Register("Sound", AccessLevel.GameMaster, new CommandEventHandler(Sound_OnCommand));
			Register("SpeedBoost", AccessLevel.Counselor, new CommandEventHandler(SpeedBoost_OnCommand));
			Register("Stats", AccessLevel.Counselor, new CommandEventHandler(Stats_OnCommand));
			Register("Stuck", AccessLevel.Counselor, new CommandEventHandler(Stuck_OnCommand));
			Register("ViewEquip", AccessLevel.GameMaster, new CommandEventHandler(ViewEquip_OnCommand));
			Register("Where", AccessLevel.Counselor, new CommandEventHandler(Where_OnCommand));
		}

		public static void Register(string command, AccessLevel access, CommandEventHandler handler)
		{
			CommandSystem.Register(command, access, handler);
		}
	}
}

#endregion

#region Register TC

namespace Server.Commands.Generic
{
	public class TargetCommands
	{
		public static void Initialize()
		{
			Register(new AddCommand());
			Register(new AddToPackCommand());
			Register(new BringToPackCommand());
			Register(new ConditionCommand());
			Register(new CountCommand());
			Register(new DeleteCommand());
			Register(new DismountCommand());

			Register(new Factions.FactionKickCommand(Factions.FactionKickType.Ban));
			Register(new Factions.FactionKickCommand(Factions.FactionKickType.Kick));
			Register(new Factions.FactionKickCommand(Factions.FactionKickType.Unban));

			Register(new FirewallCommand());
			Register(new GetCommand());
			Register(new GetTypeCommand());
			Register(new HideCommand(true));
			Register(new HideCommand(false));
			Register(new IncreaseCommand());
			Register(new InterfaceCommand());
			Register(new KickCommand(true));
			Register(new KickCommand(false));
			Register(new KillCommand(true));
			Register(new KillCommand(false));
			Register(new OpenBrowserCommand());
			Register(new PrivSoundCommand());
			Register(new RefreshHouseCommand());
			Register(new RestockCommand());

			Register(new SetCommand());
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "Immortal", "blessed", "true", ObjectTypes.Mobiles));
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "Invul", "blessed", "true", ObjectTypes.Mobiles));
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "Mortal", "blessed", "false", ObjectTypes.Mobiles));
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "NoInvul", "blessed", "false", ObjectTypes.Mobiles));
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "ShaveBeard", "FacialHairItemID", "0", ObjectTypes.Mobiles));
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "ShaveHair", "HairItemID", "0", ObjectTypes.Mobiles));
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "Squelch", "squelched", "true", ObjectTypes.Mobiles));
			Register(new AliasedSetCommand(AccessLevel.GameMaster, "Unsquelch", "squelched", "false", ObjectTypes.Mobiles));

			Register(new SwitchCommand());

			Register(new TeleCommand());
			Register(new TellCommand(true));
			Register(new TellCommand(false));
			Register(new TraceLockdownCommand());
		}

		private static readonly List<BaseCommand> m_AllCommands = new List<BaseCommand>();

		public static List<BaseCommand> AllCommands => m_AllCommands;

		public static void Register(BaseCommand command)
		{
			m_AllCommands.Add(command);

			var impls = BaseCommandImplementor.Implementors;

			for (var i = 0; i < impls.Count; ++i)
			{
				var impl = impls[i];

				if ((command.Supports & impl.SupportRequirement) != 0)
				{
					impl.Register(command);
				}
			}
		}
	}
}

#endregion

#region Register FE

namespace Server.Engine.Facet
{
	public partial class FacetEditingCommands
	{
		public static void Initialize()
		{
			CommandSystem.Prefix = "[";

			Register("LiveFreeze", AccessLevel.Administrator, new CommandEventHandler(LiveFreeze_OnCommand));
			Register("GetBlockNumber", AccessLevel.GameMaster, new CommandEventHandler(getBlockNumber_OnCommand));
			Register("QueryClientHash", AccessLevel.GameMaster, new CommandEventHandler(queryClientHash_OnCommand));
			Register("updateblock", AccessLevel.GameMaster, new CommandEventHandler(updateBlock_OnCommand));
			Register("CircularIndent", AccessLevel.GameMaster, new CommandEventHandler(circularIndent_OnCommand));
			Register("ExportClientFiles", AccessLevel.GameMaster, new CommandEventHandler(exportClientFiles_OnCommand));
			Register("PrintLandData", AccessLevel.GameMaster, new CommandEventHandler(printLandData_OnCommand));
			Register("PrintStaticsData", AccessLevel.GameMaster, new CommandEventHandler(printStaticsData_OnCommand));
			Register("PrintCrc", AccessLevel.GameMaster, new CommandEventHandler(printCrc_OnCommand));

			TargetCommands.Register(new IncStaticYCommand());
			TargetCommands.Register(new IncStaticXCommand());
			TargetCommands.Register(new IncStaticAltCommand());
			TargetCommands.Register(new SetStaticHueCommand());
			TargetCommands.Register(new SetStaticAltCommand());
			TargetCommands.Register(new SetStaticIDCommand());
			TargetCommands.Register(new DelStaticCommand());
			TargetCommands.Register(new AddStaticCommand());
			TargetCommands.Register(new MoveStaticCommand());
			TargetCommands.Register(new IncLandAltCommand());
			TargetCommands.Register(new SetLandAltCommand());
			TargetCommands.Register(new SetLandIDCommand());
		}

		public static void Register(string command, AccessLevel access, CommandEventHandler handler)
		{
			CommandSystem.Register(command, access, handler);
		}
	}
}

#endregion