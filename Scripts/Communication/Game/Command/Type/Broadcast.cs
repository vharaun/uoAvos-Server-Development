using Server.Network;

using System;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("BCast <text>")]
		[Aliases("B", "BC")]
		[Description("Broadcasts a message to everyone online.")]
		public static void BroadcastMessage_OnCommand(CommandEventArgs e)
		{
			BroadcastMessage(AccessLevel.Player, 0x482, String.Format("Staff message from {0}:", e.Mobile.Name));
			BroadcastMessage(AccessLevel.Player, 0x482, e.ArgString);
		}

		public static void BroadcastMessage(AccessLevel ac, int hue, string message)
		{
			foreach (var state in NetState.Instances)
			{
				var m = state.Mobile;

				if (m != null && m.AccessLevel >= ac)
				{
					m.SendMessage(hue, message);
				}
			}
		}

		[Usage("SMsg <text>")]
		[Aliases("S", "SM")]
		[Description("Broadcasts a message to all online staff.")]
		public static void StaffMessage_OnCommand(CommandEventArgs e)
		{
			BroadcastMessage(AccessLevel.Counselor, e.Mobile.SpeechHue, String.Format("[{0}] {1}", e.Mobile.Name, e.ArgString));
		}
	}
}