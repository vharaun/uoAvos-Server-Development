using Server.Mobiles;
using Server.Targeting;

using System.Collections;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("GetFollowers")]
		[Description("Teleports all pets of a targeted player to your location.")]
		public static void GetFollowers_OnCommand(CommandEventArgs e)
		{
			e.Mobile.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(GetFollowers_OnTarget));
			e.Mobile.SendMessage("Target a player to get their pets.");
		}

		public static void GetFollowers_OnTarget(Mobile from, object obj)
		{
			if (obj is PlayerMobile)
			{
				var master = (PlayerMobile)obj;
				var pets = master.AllFollowers;

				if (pets.Count > 0)
				{
					CommandLogging.WriteLine(from, "{0} {1} getting all followers of {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(master));

					from.SendMessage("That player has {0} pet{1}.", pets.Count, pets.Count != 1 ? "s" : "");

					for (var i = 0; i < pets.Count; ++i)
					{
						var pet = pets[i];

						if (pet is IMount)
						{
							((IMount)pet).Rider = null; // make sure it's dismounted
						}

						pet.MoveToWorld(from.Location, from.Map);
					}
				}
				else
				{
					from.SendMessage("There were no pets found for that player.");
				}
			}
			else if (obj is Mobile && ((Mobile)obj).Player)
			{
				var master = (Mobile)obj;
				var pets = new ArrayList();

				foreach (var m in World.Mobiles.Values)
				{
					if (m is BaseCreature)
					{
						var bc = (BaseCreature)m;

						if ((bc.Controlled && bc.ControlMaster == master) || (bc.Summoned && bc.SummonMaster == master))
						{
							pets.Add(bc);
						}
					}
				}

				if (pets.Count > 0)
				{
					CommandLogging.WriteLine(from, "{0} {1} getting all followers of {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(master));

					from.SendMessage("That player has {0} pet{1}.", pets.Count, pets.Count != 1 ? "s" : "");

					for (var i = 0; i < pets.Count; ++i)
					{
						var pet = (Mobile)pets[i];

						if (pet is IMount)
						{
							((IMount)pet).Rider = null; // make sure it's dismounted
						}

						pet.MoveToWorld(from.Location, from.Map);
					}
				}
				else
				{
					from.SendMessage("There were no pets found for that player.");
				}
			}
			else
			{
				from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(GetFollowers_OnTarget));
				from.SendMessage("That is not a player. Try again.");
			}
		}
	}
}