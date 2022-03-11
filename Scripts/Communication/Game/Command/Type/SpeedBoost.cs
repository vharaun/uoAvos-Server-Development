using Server.Network;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("SpeedBoost [true|false]")]
		[Description("Enables a speed boost for the invoker.  Disable with paramaters.")]
		private static void SpeedBoost_OnCommand(CommandEventArgs e)
		{
			var from = e.Mobile;

			if (e.Length <= 1)
			{
				if (e.Length == 1 && !e.GetBoolean(0))
				{
					from.Send(SpeedControl.Disable);
					from.SendMessage("Speed boost has been disabled.");
				}
				else
				{
					from.Send(SpeedControl.MountSpeed);
					from.SendMessage("Speed boost has been enabled.");
				}
			}
			else
			{
				from.SendMessage("Format: SpeedBoost [true|false]");
			}
		}
	}
}