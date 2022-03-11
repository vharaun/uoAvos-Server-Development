namespace Server.Commands.Generic
{
	public class BringToPackCommand : BaseCommand
	{
		public BringToPackCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.AllItems;
			Commands = new string[] { "BringToPack" };
			ObjectTypes = ObjectTypes.Items;
			Usage = "BringToPack";
			Description = "Brings a targeted item to your backpack.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			var item = obj as Item;

			if (item != null)
			{
				if (e.Mobile.PlaceInBackpack(item))
				{
					AddResponse("The item has been placed in your backpack.");
				}
				else
				{
					AddResponse("Your backpack could not hold the item.");
				}
			}
		}
	}
}