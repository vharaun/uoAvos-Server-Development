using Server.Events.NewYear;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

using System;

namespace Server.Engines.Events
{
	public class FatherTime
	{
		public static TimeSpan OneSecond = TimeSpan.FromSeconds(1);

		public static void Initialize()
		{
			var now = DateTime.UtcNow;

			if (DateTime.UtcNow >= HolidaySettings.StartNewYear && DateTime.UtcNow <= HolidaySettings.FinishNewYear)
			{
				EventSink.Speech += new SpeechEventHandler(EventSink_Speech);
			}
		}

		private static void EventSink_Speech(SpeechEventArgs e)
		{

			if (Insensitive.Contains(e.Speech, "happy new year"))
			{
				e.Mobile.Target = new FatherTimeTarget();

				// e.Mobile.SendLocalizedMessage(1076764);  /* Pick someone to Trick or Treat. */
			}
		}

		private class FatherTimeTarget : Target
		{
			public FatherTimeTarget()
				: base(15, false, TargetFlags.None)
			{
			}

			protected override void OnTarget(Mobile from, object targ)
			{
				if (targ != null && CheckMobile(from))
				{
					if (!(targ is Mobile))
					{
						// from.SendLocalizedMessage(1076781); /* There is little chance of getting candy from that! */
						return;
					}
					if (!(targ is BaseVendor) || ((BaseVendor)targ).Deleted)
					{
						// from.SendLocalizedMessage(1076765); /* That doesn't look friendly. */
						return;
					}

					var now = DateTime.UtcNow;

					var m_Begged = targ as BaseVendor;

					if (CheckMobile(m_Begged))
					{
						if (m_Begged.NextFatherTime > now)
						{
							// from.SendLocalizedMessage(1076767); /* That doesn't appear to have any more candy. */
							return;
						}

						m_Begged.NextFatherTime = now + TimeSpan.FromMinutes(Utility.RandomMinMax(5, 10));

						if (from.Backpack != null && !from.Backpack.Deleted)
						{
							if (Utility.RandomDouble() > .10)
							{
								switch (Utility.Random(3))
								{
									case 0: m_Begged.Say(1076768); break; /* Oooooh, aren't you cute! */
									case 1: m_Begged.Say(1076779); break; /* All right...This better not spoil your dinner! */
									case 2: m_Begged.Say(1076778); break; /* Here you go! Enjoy! */
									default: break;
								}

								if (Utility.RandomDouble() <= .01 && from.Skills.Begging.Value >= 100)
								{
									from.AddToBackpack(HolidaySettings.RandomNewYearItem);

									from.SendLocalizedMessage(1076777); /* You receive a special treat! */
								}
								else
								{
									from.AddToBackpack(HolidaySettings.RandomNewYearTreat);

									from.SendAsciiMessage("");   /* You receive some candy. */
								}
							}
							else
							{
								if (m_Begged.Karma <= 0)
								{
									from.AddToBackpack(new Coal());
								}
							}
						}
					}
				}
			}
		}

		public static bool CheckMobile(Mobile mobile)
		{
			return (mobile != null && mobile.Map != null && !mobile.Deleted && mobile.Alive && mobile.Map != Map.Internal);
		}
	}
}