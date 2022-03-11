
using System;

namespace Server.Commands.Generic
{
	public class FirewallCommand : BaseCommand
	{
		public FirewallCommand()
		{
			AccessLevel = AccessLevel.Administrator;
			Supports = CommandSupport.AllMobiles;
			Commands = new string[] { "Firewall" };
			ObjectTypes = ObjectTypes.Mobiles;
			Usage = "Firewall";
			Description = "Adds a targeted player to the firewall (list of blocked IP addresses). This command does not ban or kick.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			var from = e.Mobile;
			var targ = (Mobile)obj;
			var state = targ.NetState;

			if (state != null)
			{
				CommandLogging.WriteLine(from, "{0} {1} firewalling {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targ));

				try
				{
					Firewall.Add(state.Address);
					AddResponse("They have been firewalled.");
				}
				catch (Exception ex)
				{
					LogFailure(ex.Message);
				}
			}
			else
			{
				LogFailure("They are not online.");
			}
		}
	}
}