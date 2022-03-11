namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Light <level>")]
		[Description("Set your local lightlevel.")]
		public static void Light_OnCommand(CommandEventArgs e)
		{
			e.Mobile.LightLevel = e.GetInt32(0);
		}
	}
}