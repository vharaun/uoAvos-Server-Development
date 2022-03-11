using Server.Network;

namespace Server.Commands
{
	public partial class CommandHandlers
	{
		[Usage("Sound <index> [toAll=true]")]
		[Description("Plays a sound to players within 12 tiles of you. The (toAll) argument specifies to everyone, or just those who can see you.")]
		public static void Sound_OnCommand(CommandEventArgs e)
		{
			if (e.Length == 1)
			{
				PlaySound(e.Mobile, e.GetInt32(0), true);
			}
			else if (e.Length == 2)
			{
				PlaySound(e.Mobile, e.GetInt32(0), e.GetBoolean(1));
			}
			else
			{
				e.Mobile.SendMessage("Format: Sound <index> [toAll]");
			}
		}

		private static void PlaySound(Mobile m, int index, bool toAll)
		{
			var map = m.Map;

			if (map == null)
			{
				return;
			}

			CommandLogging.WriteLine(m, "{0} {1} playing sound {2} (toAll={3})", m.AccessLevel, CommandLogging.Format(m), index, toAll);

			Packet p = new PlaySound(index, m.Location);

			p.Acquire();

			foreach (var state in m.GetClientsInRange(12))
			{
				if (toAll || state.Mobile.CanSee(m))
				{
					state.Send(p);
				}
			}

			p.Release();
		}
	}
}

namespace Server.Commands.Generic
{
	public class PrivSoundCommand : BaseCommand
	{
		public PrivSoundCommand()
		{
			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.AllMobiles;
			Commands = new string[] { "PrivSound" };
			ObjectTypes = ObjectTypes.Mobiles;
			Usage = "PrivSound <index>";
			Description = "Plays a sound to a given target.";
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			var from = e.Mobile;

			if (e.Length == 1)
			{
				var index = e.GetInt32(0);
				var mob = (Mobile)obj;

				CommandLogging.WriteLine(from, "{0} {1} playing sound {2} for {3}", from.AccessLevel, CommandLogging.Format(from), index, CommandLogging.Format(mob));
				mob.Send(new PlaySound(index, mob.Location));
			}
			else
			{
				from.SendMessage("Format: PrivSound <index>");
			}
		}
	}
}