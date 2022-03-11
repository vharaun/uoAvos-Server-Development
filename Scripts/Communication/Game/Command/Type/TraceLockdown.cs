using Server.Gumps;
using Server.Multis;

namespace Server.Commands.Generic
{
	public class TraceLockdownCommand : BaseCommand
	{
		public TraceLockdownCommand()
		{
			AccessLevel = AccessLevel.Administrator;
			Supports = CommandSupport.Simple;
			Commands = new string[] { "TraceLockdown" };
			ObjectTypes = ObjectTypes.Items;
			Usage = "TraceLockdown";
			Description = "Finds the BaseHouse for which a targeted item is locked down or secured.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			var item = obj as Item;

			if (item == null)
			{
				return;
			}

			if (!item.IsLockedDown && !item.IsSecure)
			{
				LogFailure("That is not locked down.");
				return;
			}

			foreach (var house in BaseHouse.AllHouses)
			{
				if (house.IsSecure(item) || house.IsLockedDown(item))
				{
					e.Mobile.SendGump(new PropertiesGump(e.Mobile, house));
					return;
				}
			}

			LogFailure("No house was found.");
		}
	}
}