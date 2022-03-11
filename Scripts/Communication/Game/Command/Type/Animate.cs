namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Animate <action> <frameCount> <repeatCount> <forward> <repeat> <delay>")]
		[Description("Makes your character do a specified animation.")]
		public static void Animate_OnCommand(CommandEventArgs e)
		{
			if (e.Length == 6)
			{
				e.Mobile.Animate(e.GetInt32(0), e.GetInt32(1), e.GetInt32(2), e.GetBoolean(3), e.GetBoolean(4), e.GetInt32(5));
			}
			else
			{
				e.Mobile.SendMessage("Format: Animate <action> <frameCount> <repeatCount> <forward> <repeat> <delay>");
			}
		}
	}
}