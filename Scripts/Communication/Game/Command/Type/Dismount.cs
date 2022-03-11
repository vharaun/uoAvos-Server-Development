using Server.Mobiles;
using Server.Targeting;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		private class DismountTarget : Target
		{
			public DismountTarget() : base(-1, false, TargetFlags.None)
			{
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is Mobile)
				{
					CommandLogging.WriteLine(from, "{0} {1} dismounting {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targeted));

					var targ = (Mobile)targeted;

					for (var i = 0; i < targ.Items.Count; ++i)
					{
						var item = targ.Items[i];

						if (item is IMountItem)
						{
							var mount = ((IMountItem)item).Mount;

							if (mount != null)
							{
								mount.Rider = null;
							}

							if (targ.Items.IndexOf(item) == -1)
							{
								--i;
							}
						}
					}

					for (var i = 0; i < targ.Items.Count; ++i)
					{
						var item = targ.Items[i];

						if (item.Layer == Layer.Mount)
						{
							item.Delete();
							--i;
						}
					}
				}
			}
		}
	}
}


namespace Server.Commands.Generic
{
	public class DismountCommand : BaseCommand
	{
		public DismountCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.AllMobiles;
			Commands = new string[] { "Dismount" };
			ObjectTypes = ObjectTypes.Mobiles;
			Usage = "Dismount";
			Description = "Forcefully dismounts a given target.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			var from = e.Mobile;
			var mob = (Mobile)obj;

			CommandLogging.WriteLine(from, "{0} {1} dismounting {2}", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(mob));

			var takenAction = false;

			for (var i = 0; i < mob.Items.Count; ++i)
			{
				var item = mob.Items[i];

				if (item is IMountItem)
				{
					var mount = ((IMountItem)item).Mount;

					if (mount != null)
					{
						mount.Rider = null;
						takenAction = true;
					}

					if (mob.Items.IndexOf(item) == -1)
					{
						--i;
					}
				}
			}

			for (var i = 0; i < mob.Items.Count; ++i)
			{
				var item = mob.Items[i];

				if (item.Layer == Layer.Mount)
				{
					takenAction = true;
					item.Delete();
					--i;
				}
			}

			if (takenAction)
			{
				AddResponse("They have been dismounted.");
			}
			else
			{
				LogFailure("They were not mounted.");
			}
		}
	}
}