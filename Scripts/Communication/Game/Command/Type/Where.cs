using System.Text;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Where")]
		[Description("Tells the commanding player his coordinates, region, and facet.")]
		public static void Where_OnCommand(CommandEventArgs e)
		{
			var from = e.Mobile;
			var map = from.Map;

			from.SendMessage("You are at {0} {1} {2} in {3}.", from.X, from.Y, from.Z, map);

			if (map != null)
			{
				var reg = from.Region;

				if (!reg.IsDefault)
				{
					var builder = new StringBuilder();

					builder.Append(reg.ToString());
					reg = reg.Parent;

					while (reg != null)
					{
						builder.Append(" <- " + reg.ToString());
						reg = reg.Parent;
					}

					from.SendMessage("Your region is {0}.", builder.ToString());
				}
			}
		}
	}
}