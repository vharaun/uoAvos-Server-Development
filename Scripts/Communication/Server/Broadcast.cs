using Server.Network;

using System;

namespace Server.Misc
{
	public class AttackMessage
	{
		private const string AggressorFormat = "You are attacking {0}!";
		private const string AggressedFormat = "{0} is attacking you!";
		private const int Hue = 0x22;

		private static readonly TimeSpan Delay = TimeSpan.FromMinutes(1.0);

		public static void Initialize()
		{
			EventSink.AggressiveAction += new AggressiveActionEventHandler(EventSink_AggressiveAction);
		}

		public static void EventSink_AggressiveAction(AggressiveActionEventArgs e)
		{
			var aggressor = e.Aggressor;
			var aggressed = e.Aggressed;

			if (!aggressor.Player || !aggressed.Player)
			{
				return;
			}

			if (!CheckAggressions(aggressor, aggressed))
			{
				aggressor.LocalOverheadMessage(MessageType.Regular, Hue, true, String.Format(AggressorFormat, aggressed.Name));
				aggressed.LocalOverheadMessage(MessageType.Regular, Hue, true, String.Format(AggressedFormat, aggressor.Name));
			}
		}

		public static bool CheckAggressions(Mobile m1, Mobile m2)
		{
			var list = m1.Aggressors;

			for (var i = 0; i < list.Count; ++i)
			{
				var info = list[i];

				if (info.Attacker == m2 && DateTime.UtcNow < (info.LastCombatTime + Delay))
				{
					return true;
				}
			}

			list = m2.Aggressors;

			for (var i = 0; i < list.Count; ++i)
			{
				var info = list[i];

				if (info.Attacker == m1 && DateTime.UtcNow < (info.LastCombatTime + Delay))
				{
					return true;
				}
			}

			return false;
		}
	}

	public class LoginStats
	{
		public static void Initialize()
		{
			// Register our event handler
			EventSink.Login += new LoginEventHandler(EventSink_Login);
		}

		private static void EventSink_Login(LoginEventArgs args)
		{
			var userCount = NetState.Instances.Count;
			var itemCount = World.Items.Count;
			var mobileCount = World.Mobiles.Count;

			var m = args.Mobile;

			m.SendMessage("Welcome, {0}! There {1} currently {2} user{3} online, with {4} item{5} and {6} mobile{7} in the world.",
				args.Mobile.Name,
				userCount == 1 ? "is" : "are",
				userCount, userCount == 1 ? "" : "s",
				itemCount, itemCount == 1 ? "" : "s",
				mobileCount, mobileCount == 1 ? "" : "s");
		}
	}

	public class ServerDown
	{
		public static void Initialize()
		{
			EventSink.Crashed += new CrashedEventHandler(EventSink_Crashed);
			EventSink.Shutdown += new ShutdownEventHandler(EventSink_Shutdown);
		}

		public static void EventSink_Crashed(CrashedEventArgs e)
		{
			try
			{
				World.Broadcast(0x35, true, "The server has crashed.");
			}
			catch
			{
			}
		}

		public static void EventSink_Shutdown(ShutdownEventArgs e)
		{
			try
			{
				World.Broadcast(0x35, true, "The server has shut down.");
			}
			catch
			{
			}
		}
	}

	public class WelcomeTimer : Timer
	{
		private readonly Mobile m_Mobile;
		private int m_State;
		private readonly int m_Count;
		private static readonly string[] m_Messages = (TestCenter.Enabled ?
			new string[]
				{
					"Welcome to this test shard.  You are able to customize your character's stats and skills at anytime to anything you wish.  To see the commands to do this just say 'help'.",
					"You will find a bank check worth 1,000,000 gold in your bank!",
					"A spellbook and a bag of reagents has been placed into your bank box.",
					"Various tools have been placed into your bank.",
					"Various raw materials like ingots, logs, feathers, hides, bottles, etc, have been placed into your bank.",
					"5 unmarked recall runes, 5 Felucca moonstones and 5 Trammel moonstones have been placed into your bank box.",
					"One of each level of treasure map has been placed in your bank box.",
					"You will find 9000 silver pieces deposited into your bank box.  Spend it as you see fit and enjoy yourself!",
					"You will find 9000 gold pieces deposited into your bank box.  Spend it as you see fit and enjoy yourself!",
					"A bag of PowerScrolls has been placed in your bank box."
				} :
			new string[]
				{	//Yes, this message is a pathetic message, It's suggested that you change it.
					"Welcome to this shard.",
					"Please enjoy your stay."
				});

		public WelcomeTimer(Mobile m) : this(m, m_Messages.Length)
		{
		}

		public WelcomeTimer(Mobile m, int count) : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(10.0))
		{
			m_Mobile = m;
			m_Count = count;
		}

		protected override void OnTick()
		{
			if (m_State < m_Count)
			{
				m_Mobile.SendMessage(0x35, m_Messages[m_State++]);
			}

			if (m_State == m_Count)
			{
				Stop();
			}
		}
	}
}