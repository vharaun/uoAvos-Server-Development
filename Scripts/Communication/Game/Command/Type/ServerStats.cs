namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Stats")]
		[Description("View some stats about the server.")]
		public static void Stats_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendMessage("Open Connections: {0}", Network.NetState.Instances.Count);
			e.Mobile.SendMessage("Mobiles: {0}", World.Mobiles.Count);
			e.Mobile.SendMessage("Items: {0}", World.Items.Count);
		}
	}
}