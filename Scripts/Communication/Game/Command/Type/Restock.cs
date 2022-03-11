using Server.Mobiles;

namespace Server.Commands.Generic
{
	public class RestockCommand : BaseCommand
	{
		public RestockCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.AllNPCs;
			Commands = new string[] { "Restock" };
			ObjectTypes = ObjectTypes.Mobiles;
			Usage = "Restock";
			Description = "Manually restocks a targeted vendor, refreshing the quantity of every item the vendor sells to the maximum. This also invokes the maximum quantity adjustment algorithms.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			if (obj is BaseVendor)
			{
				CommandLogging.WriteLine(e.Mobile, "{0} {1} restocking {2}", e.Mobile.AccessLevel, CommandLogging.Format(e.Mobile), CommandLogging.Format(obj));

				((BaseVendor)obj).Restock();
				AddResponse("The vendor has been restocked.");
			}
			else
			{
				AddResponse("That is not a vendor.");
			}
		}
	}
}