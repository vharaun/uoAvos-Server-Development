using Server.Engines.Help;

namespace Server.Commands.Generic
{
	public class TellCommand : BaseCommand
	{
		private readonly bool m_InGump;

		public TellCommand(bool inGump)
		{
			m_InGump = inGump;

			AccessLevel = AccessLevel.Counselor;
			Supports = CommandSupport.AllMobiles;
			ObjectTypes = ObjectTypes.Mobiles;

			if (inGump)
			{
				Commands = new string[] { "Message", "Msg" };
				Usage = "Message \"text\"";
				Description = "Sends a message to a targeted player.";
			}
			else
			{
				Commands = new string[] { "Tell" };
				Usage = "Tell \"text\"";
				Description = "Sends a system message to a targeted player.";
			}
		}

		public override void Execute(CommandEventArgs e, object obj)
		{
			var mob = (Mobile)obj;
			var from = e.Mobile;

			CommandLogging.WriteLine(from, "{0} {1} {2} {3} \"{4}\"", from.AccessLevel, CommandLogging.Format(from), m_InGump ? "messaging" : "telling", CommandLogging.Format(mob), e.ArgString);

			if (m_InGump)
			{
				mob.SendGump(new MessageSentGump(mob, from.Name, e.ArgString));
			}
			else
			{
				mob.SendMessage(e.ArgString);
			}
		}
	}
}