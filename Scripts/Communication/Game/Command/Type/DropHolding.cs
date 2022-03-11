using Server.Targeting;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("DropHolding")]
		[Description("Drops the item, if any, that a targeted player is holding. The item is placed into their backpack, or if that's full, at their feet.")]
		public static void DropHolding_OnCommand(CommandEventArgs e)
		{
			e.Mobile.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(DropHolding_OnTarget));
			e.Mobile.SendMessage("Target the player to drop what they are holding.");
		}

		public static void DropHolding_OnTarget(Mobile from, object obj)
		{
			if (obj is Mobile && ((Mobile)obj).Player)
			{
				var targ = (Mobile)obj;
				var held = targ.Holding;

				if (held == null)
				{
					from.SendMessage("They are not holding anything.");
				}
				else
				{
					if (from.AccessLevel == AccessLevel.Counselor)
					{
						var pe = Engines.Help.PageQueue.GetEntry(targ);

						if (pe == null || pe.Handler != from)
						{
							if (pe == null)
							{
								from.SendMessage("You may only use this command on someone who has paged you.");
							}
							else
							{
								from.SendMessage("You may only use this command if you are handling their help page.");
							}

							return;
						}
					}

					if (targ.AddToBackpack(held))
					{
						from.SendMessage("The item they were holding has been placed into their backpack.");
					}
					else
					{
						from.SendMessage("The item they were holding has been placed at their feet.");
					}

					held.ClearBounce();

					targ.Holding = null;
				}
			}
			else
			{
				from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(DropHolding_OnTarget));
				from.SendMessage("That is not a player. Try again.");
			}
		}
	}
}