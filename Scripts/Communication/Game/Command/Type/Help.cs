using System.Collections.Generic;
using System.Text;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Help")]
		[Description("Lists all available commands.")]
		public static void Help_OnCommand(CommandEventArgs e)
		{
			var m = e.Mobile;

			var list = new List<CommandEntry>();

			foreach (var entry in CommandSystem.Entries.Values)
			{
				if (m.AccessLevel >= entry.AccessLevel)
				{
					list.Add(entry);
				}
			}

			list.Sort();

			var sb = new StringBuilder();

			if (list.Count > 0)
			{
				sb.Append(list[0].Command);
			}

			for (var i = 1; i < list.Count; ++i)
			{
				var v = list[i].Command;

				if ((sb.Length + 1 + v.Length) >= 256)
				{
					m.SendAsciiMessage(0x482, sb.ToString());
					sb = new StringBuilder();
					sb.Append(v);
				}
				else
				{
					sb.Append(' ');
					sb.Append(v);
				}
			}

			if (sb.Length > 0)
			{
				m.SendAsciiMessage(0x482, sb.ToString());
			}
		}
	}
}