namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("AutoPageNotify")]
		[Aliases("APN")]
		[Description("Toggles your auto-page-notify status.")]
		public static void APN_OnCommand(CommandEventArgs e)
		{
			var m = e.Mobile;

			m.AutoPageNotify = !m.AutoPageNotify;

			m.SendMessage("Your auto-page-notify has been turned {0}.", m.AutoPageNotify ? "on" : "off");
		}
	}
}