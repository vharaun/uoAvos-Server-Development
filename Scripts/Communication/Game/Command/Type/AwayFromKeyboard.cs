using Server;
using Server.Commands;
using Server.Mobiles;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Commands
{
	public static class AwayFromKeyBoardSystemToggle
	{
		public static bool Enabled = true;
	}

	public class AwayFromKeyboard : Timer
	{
		private static Hashtable m_AFK = new Hashtable();

		private Mobile playerMobile;
		private Point3D location;
		private DateTime afkTimer;

		public string what = "";

		public static void Initialize()
		{
			if (AwayFromKeyBoardSystemToggle.Enabled)
			{
				EventSink.Logout += new LogoutEventHandler(OnLogout);
				EventSink.Speech += new SpeechEventHandler(OnSpeech);
				EventSink.PlayerDeath += new PlayerDeathEventHandler(OnDeath);

				CommandSystem.Register("afk", AccessLevel.Player, new CommandEventHandler(AFK_OnCommand));
			}
			else
			{
				/// Failed At Message Informing Player The System Is Disabled
			}
		}

		public static void AFK_OnCommand(CommandEventArgs e)
		{
			if (m_AFK.Contains(e.Mobile.Serial.Value))
			{
				AwayFromKeyboard afk = (AwayFromKeyboard)m_AFK[e.Mobile.Serial.Value];

				if (afk == null)
				{
					e.Mobile.SendMessage("Afk Object Missing!");
					return;
				}

				afk.WakeUp();

				e.Mobile.Blessed = false;
				e.Mobile.HueMod = -1;
			}
			else
			{
				m_AFK.Add(e.Mobile.Serial.Value, new AwayFromKeyboard(e.Mobile, e.ArgString.Trim()));
				e.Mobile.SendAsciiMessage("Away From Keyboard System Enabled...");
			}
		}

		public static void OnDeath(PlayerDeathEventArgs e)
		{
			if (m_AFK.Contains(e.Mobile.Serial.Value))
			{
				AwayFromKeyboard afk = (AwayFromKeyboard)m_AFK[e.Mobile.Serial.Value];

				if (afk == null)
				{
					e.Mobile.SendMessage("Afk Object Missing!");
					return;
				}

				e.Mobile.PlaySound(e.Mobile.Female ? 814 : 1088);

				afk.WakeUp();
				e.Mobile.Blessed = false;
				e.Mobile.HueMod = -1;
			}
		}

		public static void OnLogout(LogoutEventArgs e)
		{
			if (m_AFK.Contains(e.Mobile.Serial.Value))
			{
				AwayFromKeyboard afk = (AwayFromKeyboard)m_AFK[e.Mobile.Serial.Value];

				if (afk == null)
				{
					e.Mobile.SendMessage("Afk Object Missing!");
					return;
				}

				afk.WakeUp();

				e.Mobile.Blessed = false;
				e.Mobile.HueMod = -1;
			}
		}

		public static void OnSpeech(SpeechEventArgs e)
		{
			if (m_AFK.Contains(e.Mobile.Serial.Value))
			{
				AwayFromKeyboard afk = (AwayFromKeyboard)m_AFK[e.Mobile.Serial.Value];

				if (afk == null)
				{
					e.Mobile.SendMessage("Afk Object Missing!");
					return;
				}

				afk.WakeUp();

				e.Mobile.Blessed = false;
				e.Mobile.HueMod = -1;
			}
		}

		public void WakeUp()
		{
			playerMobile.Blessed = false;
			playerMobile.HueMod = -1;

			m_AFK.Remove(playerMobile.Serial.Value);

			playerMobile.Emote("*yawns*");
			playerMobile.Say("I'm awake!");

			playerMobile.SendAsciiMessage("Away From Keyboard System Disabled...");

			this.Stop();
		}

		public AwayFromKeyboard(Mobile pm, string message) : base(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10))
		{
			if ((message == null) || (message == ""))
			{
				message = "This person is now away from their keyboard";
			}

			playerMobile = pm;
			what = message;
			location = playerMobile.Location;

			afkTimer = DateTime.UtcNow;
			this.Start();
		}

		protected override void OnTick()
		{
			if (!(playerMobile.Location == location))
			{
				playerMobile.Blessed = false;
				playerMobile.HueMod = -1;

				this.WakeUp();

				return;
			}

			playerMobile.Blessed = true;
			playerMobile.HueMod = 0x03E8;

			playerMobile.Say("zZz");

			TimeSpan ts = DateTime.UtcNow.Subtract(afkTimer);

			playerMobile.Emote("*{0} ({1}:{2}:{3})*", what, ts.Hours, ts.Minutes, ts.Seconds);
			playerMobile.PlaySound(playerMobile.Female ? 819 : 1093);
		}
	}
}