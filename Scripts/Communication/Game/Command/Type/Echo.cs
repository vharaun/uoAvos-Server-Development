namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Echo <text>")]
		[Description("Relays (text) as a system message.")]
		public static void Echo_OnCommand(CommandEventArgs e)
		{
			var toEcho = e.ArgString.Trim();

			if (toEcho.Length > 0)
			{
				e.Mobile.SendMessage(toEcho);
			}
			else
			{
				e.Mobile.SendMessage("Format: Echo \"<text>\"");
			}
		}
	}
}