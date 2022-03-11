using Server.Accounting;
using Server.Network;

using System;

namespace Server.Misc
{
	public class Paperdoll
	{
		public static void Initialize()
		{
			EventSink.PaperdollRequest += new PaperdollRequestEventHandler(EventSink_PaperdollRequest);
		}

		public static void EventSink_PaperdollRequest(PaperdollRequestEventArgs e)
		{
			var beholder = e.Beholder;
			var beheld = e.Beheld;

			beholder.Send(new DisplayPaperdoll(beheld, Titles.ComputeTitle(beholder, beheld), beheld.AllowEquipFrom(beholder)));

			if (ObjectPropertyList.Enabled)
			{
				var items = beheld.Items;

				for (var i = 0; i < items.Count; ++i)
				{
					beholder.Send(items[i].OPLPacket);
				}

				// NOTE: OSI sends MobileUpdate when opening your own paperdoll.
				// It has a very bad rubber-banding affect. What positive affects does it have?
			}
		}
	}

	public class Profile
	{
		public static void Initialize()
		{
			EventSink.ProfileRequest += new ProfileRequestEventHandler(EventSink_ProfileRequest);
			EventSink.ChangeProfileRequest += new ChangeProfileRequestEventHandler(EventSink_ChangeProfileRequest);
		}

		public static void EventSink_ChangeProfileRequest(ChangeProfileRequestEventArgs e)
		{
			var from = e.Beholder;

			if (from.ProfileLocked)
			{
				from.SendMessage("Your profile is locked. You may not change it.");
			}
			else
			{
				from.Profile = e.Text;
			}
		}

		public static void EventSink_ProfileRequest(ProfileRequestEventArgs e)
		{
			var beholder = e.Beholder;
			var beheld = e.Beheld;

			if (!beheld.Player)
			{
				return;
			}

			if (beholder.Map != beheld.Map || !beholder.InRange(beheld, 12) || !beholder.CanSee(beheld))
			{
				return;
			}

			var header = Titles.ComputeTitle(beholder, beheld);

			var footer = "";

			if (beheld.ProfileLocked)
			{
				if (beholder == beheld)
				{
					footer = "Your profile has been locked.";
				}
				else if (beholder.AccessLevel >= AccessLevel.Counselor)
				{
					footer = "This profile has been locked.";
				}
			}

			if (footer.Length == 0 && beholder == beheld)
			{
				footer = GetAccountDuration(beheld);
			}

			var body = beheld.Profile;

			if (body == null || body.Length <= 0)
			{
				body = "";
			}

			beholder.Send(new DisplayProfile(beholder != beheld || !beheld.ProfileLocked, beheld, header, body, footer));
		}

		private static string GetAccountDuration(Mobile m)
		{
			var a = m.Account as Account;

			if (a == null)
			{
				return "";
			}

			var ts = DateTime.UtcNow - a.Created;

			string v;

			if (Format(ts.TotalDays, "This account is {0} day{1} old.", out v))
			{
				return v;
			}

			if (Format(ts.TotalHours, "This account is {0} hour{1} old.", out v))
			{
				return v;
			}

			if (Format(ts.TotalMinutes, "This account is {0} minute{1} old.", out v))
			{
				return v;
			}

			if (Format(ts.TotalSeconds, "This account is {0} second{1} old.", out v))
			{
				return v;
			}

			return "";
		}

		public static bool Format(double value, string format, out string op)
		{
			if (value >= 1.0)
			{
				op = String.Format(format, (int)value, (int)value != 1 ? "s" : "");
				return true;
			}

			op = null;
			return false;
		}
	}
}