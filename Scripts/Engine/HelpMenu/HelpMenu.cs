using Server.Accounting;
using Server.Gumps;
using Server.Menus.Questions;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;

using System;
using System.IO;

namespace Server.Engines.Help
{
	public class ContainedMenu : QuestionMenu
	{
		private readonly Mobile m_From;

		public ContainedMenu(Mobile from) : base("You already have an open help request. We will have someone assist you as soon as possible.  What would you like to do?", new string[] { "Leave my old help request like it is.", "Remove my help request from the queue." })
		{
			m_From = from;
		}

		public override void OnCancel(NetState state)
		{
			m_From.SendLocalizedMessage(1005306, "", 0x35); // Help request unchanged.
		}

		public override void OnResponse(NetState state, int index)
		{
			if (index == 0)
			{
				m_From.SendLocalizedMessage(1005306, "", 0x35); // Help request unchanged.
			}
			else if (index == 1)
			{
				var entry = PageQueue.GetEntry(m_From);

				if (entry != null && entry.Handler == null)
				{
					m_From.SendLocalizedMessage(1005307, "", 0x35); // Removed help request.
					entry.AddResponse(entry.Sender, "[Canceled]");
					PageQueue.Remove(entry);
				}
				else
				{
					m_From.SendLocalizedMessage(1005306, "", 0x35); // Help request unchanged.
				}
			}
		}
	}

	public class HelpGump : Gump
	{
		public static void Initialize()
		{
			EventSink.HelpRequest += new HelpRequestEventHandler(EventSink_HelpRequest);
		}

		private static void EventSink_HelpRequest(HelpRequestEventArgs e)
		{
			var pm = (PlayerMobile)e.Mobile;

			if (AutoStaffTeamToggle.Enabled)
			{
				if (((pm.LastTimePaged + CanHelpAgain) <= DateTime.UtcNow))
				{
					if (e.Mobile.HasGump(typeof(GM_StaffKeywords)))
					{
						e.Mobile.CloseGump(typeof(GM_StaffKeywords));
						e.Mobile.SendMessage("Please Close The Keywords Window Before Pressing The Help Button.");
						return;
					}

					var sm = new GameMaster_GM();

					switch (Utility.Random(6))
					{
						case 0: sm.MoveToWorld(new Point3D(e.Mobile.X + 1, e.Mobile.Y, e.Mobile.Z), e.Mobile.Map); break;
						case 1: sm.MoveToWorld(new Point3D(e.Mobile.X + 2, e.Mobile.Y, e.Mobile.Z), e.Mobile.Map); break;
						case 2: sm.MoveToWorld(new Point3D(e.Mobile.X + 3, e.Mobile.Y, e.Mobile.Z), e.Mobile.Map); break;
						case 3: sm.MoveToWorld(new Point3D(e.Mobile.X, e.Mobile.Y + 1, e.Mobile.Z), e.Mobile.Map); break;
						case 4: sm.MoveToWorld(new Point3D(e.Mobile.X, e.Mobile.Y + 2, e.Mobile.Z), e.Mobile.Map); break;
						case 5: sm.MoveToWorld(new Point3D(e.Mobile.X, e.Mobile.Y + 3, e.Mobile.Z), e.Mobile.Map); break;
					}

					pm.LastTimePaged = DateTime.UtcNow;
					return;
				}
				e.Mobile.SendMessage("You May Only Page Staff Once Every Thirty Minutes. If You Need Assistance Now, Please Visit Our Website At: www.yoursitename.com");
				return;
			}

			foreach (var g in e.Mobile.NetState.Gumps)
			{
				if (g is HelpGump)
				{
					return;
				}
			}

			if (!PageQueue.CheckAllowedToPage(e.Mobile))
			{
				return;
			}

			if (PageQueue.Contains(e.Mobile))
			{
				e.Mobile.SendMenu(new ContainedMenu(e.Mobile));
			}
			else
			{
				e.Mobile.SendGump(new HelpGump(e.Mobile));
			}
		}

		private static bool IsYoung(Mobile m)
		{
			if (m is PlayerMobile)
			{
				return ((PlayerMobile)m).Young;
			}

			return false;
		}

		public static TimeSpan CanHelpAgain => TimeSpan.FromMinutes(30);

		public static bool CheckCombat(Mobile m)
		{
			for (var i = 0; i < m.Aggressed.Count; ++i)
			{
				var info = m.Aggressed[i];

				if (DateTime.UtcNow - info.LastCombatTime < TimeSpan.FromSeconds(30.0))
				{
					return true;
				}
			}

			return false;
		}

		public HelpGump(Mobile from) : base(0, 0)
		{
			from.CloseGump(typeof(HelpGump));

			var isYoung = IsYoung(from);

			AddBackground(50, 25, 540, 430, 2600);

			AddPage(0);

			AddHtmlLocalized(150, 50, 360, 40, 1001002, false, false); // <CENTER><U>Ultima Online Help Menu</U></CENTER>
			AddButton(425, 415, 2073, 2072, 0, GumpButtonType.Reply, 0); // Close

			AddPage(1);

			if (isYoung)
			{
				AddButton(80, 75, 5540, 5541, 9, GumpButtonType.Reply, 2);
				AddHtml(110, 75, 450, 58, @"<BODY><BASEFONT COLOR=BLACK><u>Young Player Haven Transport.</u> Select this option if you want to be transported to Haven.</BODY>", true, true);

				AddButton(80, 140, 5540, 5541, 1, GumpButtonType.Reply, 2);
				AddHtml(110, 140, 450, 58, @"<u>General question about Ultima Online.</u> Select this option if you have a general gameplay question, need help learning to use a skill, or if you would like to search the UO Knowledge Base.", true, true);

				AddButton(80, 205, 5540, 5541, 2, GumpButtonType.Reply, 0);
				AddHtml(110, 205, 450, 58, @"<u>My character is physically stuck in the game.</u> This choice only covers cases where your character is physically stuck in a location they cannot move out of. This option will only work two times in 24 hours.", true, true);

				AddButton(80, 270, 5540, 5541, 0, GumpButtonType.Page, 3);
				AddHtml(110, 270, 450, 58, @"<u>Another player is harassing me.</u> Another player is verbally harassing your character. When you select this option you will be sending a text log to Origin Systems. To see what constitutes harassment please visit http://support.uo.com/gm_9.html.", true, true);

				AddButton(80, 335, 5540, 5541, 0, GumpButtonType.Page, 2);
				AddHtml(110, 335, 450, 58, @"<u>Other.</u> If you are experiencing a problem in the game that does not fall into one of the other categories or is not addressed on the Support web page (located at http://support.uo.com), please use this option.", true, true);
			}
			else
			{
				AddButton(80, 90, 5540, 5541, 1, GumpButtonType.Reply, 2);
				AddHtml(110, 90, 450, 74, @"<u>General question about Ultima Online.</u> Select this option if you have a general gameplay question, need help learning to use a skill, or if you would like to search the UO Knowledge Base.", true, true);

				AddButton(80, 170, 5540, 5541, 2, GumpButtonType.Reply, 0);
				AddHtml(110, 170, 450, 74, @"<u>My character is physically stuck in the game.</u> This choice only covers cases where your character is physically stuck in a location they cannot move out of. This option will only work two times in 24 hours.", true, true);

				AddButton(80, 250, 5540, 5541, 0, GumpButtonType.Page, 3);
				AddHtml(110, 250, 450, 74, @"<u>Another player is harassing me.</u> Another player is verbally harassing your character. When you select this option you will be sending a text log to Origin Systems. To see what constitutes harassment please visit http://support.uo.com/gm_9.html.", true, true);

				AddButton(80, 330, 5540, 5541, 0, GumpButtonType.Page, 2);
				AddHtml(110, 330, 450, 74, @"<u>Other.</u> If you are experiencing a problem in the game that does not fall into one of the other categories or is not addressed on the Support web page (located at http://support.uo.com), please use this option.", true, true);
			}

			AddPage(2);

			AddButton(80, 90, 5540, 5541, 3, GumpButtonType.Reply, 0);
			AddHtml(110, 90, 450, 74, @"<u>Report a bug or contact Origin.</u> Use this option to launch your web browser and mail in a bug report. Your report will be read by our Quality Assurance Staff. We apologize for not being able to reply to individual reports. ", true, true);

			AddButton(80, 170, 5540, 5541, 4, GumpButtonType.Reply, 0);
			AddHtml(110, 170, 450, 74, @"<u>Suggestion for the Game.</u> If you'd like to make a suggestion for the game, it should be directed to the Development Team Members who participate in the discussion forums on the UO.Com web site. Choosing this option will take you to the Discussion Forums. ", true, true);

			AddButton(80, 250, 5540, 5541, 5, GumpButtonType.Reply, 0);
			AddHtml(110, 250, 450, 74, @"<u>Account Management</u> For questions regarding your account such as forgotten passwords, payment options, account activation, and account transfer, please choose this option.", true, true);

			AddButton(80, 330, 5540, 5541, 6, GumpButtonType.Reply, 0);
			AddHtml(110, 330, 450, 74, @"<u>Other.</u> If you are experiencing a problem in the game that does not fall into one of the other categories or is not addressed on the Support web page (located at http://support.uo.com), and requires in-game assistance, use this option. ", true, true);

			AddPage(3);

			AddButton(80, 90, 5540, 5541, 7, GumpButtonType.Reply, 0);
			AddHtmlLocalized(110, 90, 450, 145, 1062572, true, true); /* <U><CENTER>Another player is harassing me (or Exploiting).</CENTER></U><BR>
																		 * VERBAL HARASSMENT<BR>
																		 * Use this option when another player is verbally harassing your character.
																		 * Verbal harassment behaviors include but are not limited to, using bad language, threats etc..
																		 * Before you submit a complaint be sure you understand what constitutes harassment
																		 * <A HREF="http://uo.custhelp.com/cgi-bin/uo.cfg/php/enduser/std_adp.php?p_faqid=40">– what is verbal harassment? -</A>
																		 * and that you have followed these steps:<BR>
																		 * 1. You have asked the player to stop and they have continued.<BR>
																		 * 2. You have tried to remove yourself from the situation.<BR>
																		 * 3. You have done nothing to instigate or further encourage the harassment.<BR>
																		 * 4. You have added the player to your ignore list.
																		 * <A HREF="http://uo.custhelp.com/cgi-bin/uo.cfg/php/enduser/std_adp.php?p_faqid=138">- How do I ignore a player?</A><BR>
																		 * 5. You have read and understand Origin’s definition of harassment.<BR>
																		 * 6. Your account information is up to date. (Including a current email address)<BR>
																		 * *If these steps have not been taken, GMs may be unable to take action against the offending player.<BR>
																		 * **A chat log will be review by a GM to assess the validity of this complaint.
																		 * Abuse of this system is a violation of the Rules of Conduct.<BR>
																		 * EXPLOITING<BR>
																		 * Use this option to report someone who may be exploiting or cheating.
																		 * <A HREF="http://uo.custhelp.com/cgi-bin/uo.cfg/php/enduser/std_adp.php?p_faqid=41">– What constitutes an exploit?</a>
																		 */

			AddButton(80, 240, 5540, 5541, 8, GumpButtonType.Reply, 0);
			AddHtmlLocalized(110, 240, 450, 145, 1062573, true, true); /* <U><CENTER>Another player is harassing me using game mechanics.</CENTER></U><BR>
																		  * <BR>
																		  * PHYSICAL HARASSMENT<BR>
																		  * Use this option when another player is harassing your character using game mechanics.
																		  * Physical harassment includes but is not limited to luring, Kill Stealing, and any act that causes a players death in Trammel.
																		  * Before you submit a complaint be sure you understand what constitutes harassment
																		  * <A HREF="http://uo.custhelp.com/cgi-bin/uo.cfg/php/enduser/std_adp.php?p_faqid=59"> – what is physical harassment?</A>
																		  * and that you have followed these steps:<BR>
																		  * 1. You have asked the player to stop and they have continued.<BR>
																		  * 2. You have tried to remove yourself from the situation.<BR>
																		  * 3. You have done nothing to instigate or further encourage the harassment.<BR>
																		  * 4. You have added the player to your ignore list.
																		  * <A HREF="http://uo.custhelp.com/cgi-bin/uo.cfg/php/enduser/std_adp.php?p_faqid=138"> - how do I ignore a player?</A><BR>
																		  * 5. You have read and understand Origin’s definition of harassment.<BR>
																		  * 6. Your account information is up to date. (Including a current email address)<BR>
																		  * *If these steps have not been taken, GMs may be unable to take action against the offending player.<BR>
																		  * **This issue will be reviewed by a GM to assess the validity of this complaint.
																		  * Abuse of this system is a violation of the Rules of Conduct.
																		  */

			AddButton(150, 390, 5540, 5541, 0, GumpButtonType.Page, 1);
			AddHtmlLocalized(180, 390, 335, 40, 1001015, false, false); // NO  - I meant to ask for help with another matter.
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			var from = state.Mobile;

			var type = (PageType)(-1);

			switch (info.ButtonID)
			{
				case 0: // Close/Cancel
					{
						from.SendLocalizedMessage(501235, "", 0x35); // Help request aborted.

						break;
					}
				case 1: // General question
					{
						type = PageType.Question;
						break;
					}
				case 2: // Stuck
					{
						var house = BaseHouse.FindHouseAt(from);

						if (house != null && house.IsAosRules && !from.Region.IsPartOf(typeof(Engines.ConPVP.SafeZone))) // Dueling
						{
							from.Location = house.BanLocation;
						}
						else if (from.Region.IsPartOf(typeof(Server.Regions.Jail)))
						{
							from.SendLocalizedMessage(1114345, "", 0x35); // You'll need a better jailbreak plan than that!
						}
						else if (Factions.Sigil.ExistsOn(from))
						{
							from.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
						}
						else if (from is PlayerMobile && ((PlayerMobile)from).CanUseStuckMenu() && from.Region.CanUseStuckMenu(from) && !CheckCombat(from) && !from.Frozen && !from.Criminal && (Core.AOS || !from.Murderer))
						{
							var menu = new StuckMenu(from, from, true);

							menu.BeginClose();

							from.SendGump(menu);
						}
						else
						{
							type = PageType.Stuck;
						}

						break;
					}
				case 3: // Report bug or contact Origin
					{
						type = PageType.Bug;
						break;
					}
				case 4: // Game suggestion
					{
						type = PageType.Suggestion;
						break;
					}
				case 5: // Account management
					{
						type = PageType.Account;
						break;
					}
				case 6: // Other
					{
						type = PageType.Other;
						break;
					}
				case 7: // Harassment: verbal/exploit
					{
						type = PageType.VerbalHarassment;
						break;
					}
				case 8: // Harassment: physical
					{
						type = PageType.PhysicalHarassment;
						break;
					}
				case 9: // Young player transport
					{
						if (IsYoung(from))
						{
							if (from.Region.IsPartOf(typeof(Regions.Jail)))
							{
								from.SendLocalizedMessage(1114345, "", 0x35); // You'll need a better jailbreak plan than that!
							}
							else if (from.Region.IsPartOf("Haven Island"))
							{
								from.SendLocalizedMessage(1041529); // You're already in Haven
							}
							else
							{
								from.MoveToWorld(new Point3D(3503, 2574, 14), Map.Trammel);
							}
						}

						break;
					}
			}

			if (type != (PageType)(-1) && PageQueue.CheckAllowedToPage(from))
			{
				from.SendGump(new PagePromptGump(from, type));
			}
		}
	}

	public class QualityAssurance : Gump
	{
		public QualityAssurance(Mobile from) : base(0, 0)
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(161, 139, 473, 343, 9200);
			AddItem(156, 454, 6914);
			AddItem(595, 455, 6913);
			AddItem(169, 355, 6920);
			AddItem(599, 138, 6917);
			AddItem(154, 139, 6916);
			AddBackground(180, 154, 442, 289, 9390);
			AddAlphaRegion(206, 194, 390, 209);
			AddTextEntry(213, 203, 377, 192, 0, (int)Buttons.TextEntry1, @"");
			AddImage(111, 220, 10400);
			AddImage(602, 234, 10411);
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button0, GumpButtonType.Reply, 0);//cancel
			AddLabel(316, 157, 695, @"PLAYER FEEDBACK REPORT");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button1, GumpButtonType.Reply, 1);//submit
			AddLabel(239, 441, 930, @"Thank You For Using Our Player Help Paging System!");
			AddLabel(198, 458, 930, @"Please Tell Us About Your Experience And Rate Our Performance");
		}

		public enum Buttons
		{
			Button0,
			Button1,
			TextEntry1,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			var acct = (Account)from.Account;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button0:
					{
						from.CloseGump(typeof(ReportGuild));
						from.SendMessage("You Decide Not To Provide Player Feedback.");
						break;
					}

				case (int)Buttons.Button1:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Filed A Player Feedback Report", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Reports/")) //create directory
						{
							Directory.CreateDirectory("Export/Reports/");
						}

						using (var op = new StreamWriter("Export/Reports/Feedback.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Player Feedback Report Has Been Filed! Thank You.");
						break;
					}
			}
		}
	}
}

namespace Server.Menus.Questions
{
	public class StuckMenuEntry
	{
		private readonly int m_Name;
		private readonly Point3D[] m_Locations;

		public int Name => m_Name;
		public Point3D[] Locations => m_Locations;

		public StuckMenuEntry(int name, Point3D[] locations)
		{
			m_Name = name;
			m_Locations = locations;
		}
	}

	public class StuckMenu : Gump
	{
		private static readonly StuckMenuEntry[] m_Entries = new StuckMenuEntry[]
			{
				// Britain
				new StuckMenuEntry( 1011028, new Point3D[]
					{
						new Point3D( 1522, 1757, 28 ),
						new Point3D( 1519, 1619, 10 ),
						new Point3D( 1457, 1538, 30 ),
						new Point3D( 1607, 1568, 20 ),
						new Point3D( 1643, 1680, 18 )
					} ),

				// Trinsic
				new StuckMenuEntry( 1011029, new Point3D[]
					{
						new Point3D( 2005, 2754, 30 ),
						new Point3D( 1993, 2827,  0 ),
						new Point3D( 2044, 2883,  0 ),
						new Point3D( 1876, 2859, 20 ),
						new Point3D( 1865, 2687,  0 )
					} ),

				// Vesper
				new StuckMenuEntry( 1011030, new Point3D[]
					{
						new Point3D( 2973, 891, 0 ),
						new Point3D( 3003, 776, 0 ),
						new Point3D( 2910, 727, 0 ),
						new Point3D( 2865, 804, 0 ),
						new Point3D( 2832, 927, 0 )
					} ),

				// Minoc
				new StuckMenuEntry( 1011031, new Point3D[]
					{
						new Point3D( 2498, 392,  0 ),
						new Point3D( 2433, 541,  0 ),
						new Point3D( 2445, 501, 15 ),
						new Point3D( 2501, 469, 15 ),
						new Point3D( 2444, 420, 15 )
					} ),

				// Yew
				new StuckMenuEntry( 1011032, new Point3D[]
					{
						new Point3D( 490, 1166, 0 ),
						new Point3D( 652, 1098, 0 ),
						new Point3D( 650, 1013, 0 ),
						new Point3D( 536,  979, 0 ),
						new Point3D( 464,  970, 0 )
					} ),

				// Cove
				new StuckMenuEntry( 1011033, new Point3D[]
					{
						new Point3D( 2230, 1159, 0 ),
						new Point3D( 2218, 1203, 0 ),
						new Point3D( 2247, 1194, 0 ),
						new Point3D( 2236, 1224, 0 ),
						new Point3D( 2273, 1231, 0 )
					} )
			};

		private static readonly StuckMenuEntry[] m_T2AEntries = new StuckMenuEntry[]
			{
				// Papua
				new StuckMenuEntry( 1011057, new Point3D[]
					{
						new Point3D( 5720, 3109, -1 ),
						new Point3D( 5677, 3176, -3 ),
						new Point3D( 5678, 3227,  0 ),
						new Point3D( 5769, 3206, -2 ),
						new Point3D( 5777, 3270, -1 )
					} ),

				// Delucia
				new StuckMenuEntry( 1011058, new Point3D[]
					{
						new Point3D( 5216, 4033, 37 ),
						new Point3D( 5262, 4049, 37 ),
						new Point3D( 5284, 4006, 37 ),
						new Point3D( 5189, 3971, 39 ),
						new Point3D( 5243, 3960, 37 )
					} )
			};

		private static bool IsInSecondAgeArea(Mobile m)
		{
			if (m.Map != Map.Trammel && m.Map != Map.Felucca)
			{
				return false;
			}

			if (m.X >= 5120 && m.Y >= 2304)
			{
				return true;
			}

			if (m.Region.IsPartOf("Terathan Keep"))
			{
				return true;
			}

			return false;
		}

		private readonly Mobile m_Mobile, m_Sender;
		private readonly bool m_MarkUse;

		private Timer m_Timer;

		public StuckMenu(Mobile beholder, Mobile beheld, bool markUse) : base(150, 50)
		{
			m_Sender = beholder;
			m_Mobile = beheld;
			m_MarkUse = markUse;

			Closable = false;
			Dragable = false;
			Disposable = false;

			AddBackground(0, 0, 270, 320, 2600);

			AddHtmlLocalized(50, 20, 250, 35, 1011027, false, false); // Chose a town:

			var entries = IsInSecondAgeArea(beheld) ? m_T2AEntries : m_Entries;

			for (var i = 0; i < entries.Length; i++)
			{
				var entry = entries[i];

				AddButton(50, 55 + 35 * i, 208, 209, i + 1, GumpButtonType.Reply, 0);
				AddHtmlLocalized(75, 55 + 35 * i, 335, 40, entry.Name, false, false);
			}

			AddButton(55, 263, 4005, 4007, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(90, 265, 200, 35, 1011012, false, false); // CANCEL
		}

		public void BeginClose()
		{
			StopClose();

			m_Timer = new CloseTimer(m_Mobile);
			m_Timer.Start();

			m_Mobile.Frozen = true;
		}

		public void StopClose()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			m_Mobile.Frozen = false;
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			StopClose();

			if (Factions.Sigil.ExistsOn(m_Mobile))
			{
				m_Mobile.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
			}
			else if (info.ButtonID == 0)
			{
				if (m_Mobile == m_Sender)
				{
					m_Mobile.SendLocalizedMessage(1010588); // You choose not to go to any city.
				}
			}
			else
			{
				var index = info.ButtonID - 1;
				var entries = IsInSecondAgeArea(m_Mobile) ? m_T2AEntries : m_Entries;

				if (index >= 0 && index < entries.Length)
				{
					Teleport(entries[index]);
				}
			}
		}

		private void Teleport(StuckMenuEntry entry)
		{
			if (m_MarkUse)
			{
				m_Mobile.SendLocalizedMessage(1010589); // You will be teleported within the next two minutes.

				new TeleportTimer(m_Mobile, entry, TimeSpan.FromSeconds(10.0 + (Utility.RandomDouble() * 110.0))).Start();

				if (m_Mobile is PlayerMobile)
				{
					((PlayerMobile)m_Mobile).UsedStuckMenu();
				}
			}
			else
			{
				new TeleportTimer(m_Mobile, entry, TimeSpan.Zero).Start();
			}
		}

		private class CloseTimer : Timer
		{
			private readonly Mobile m_Mobile;
			private readonly DateTime m_End;

			public CloseTimer(Mobile m) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.0))
			{
				m_Mobile = m;
				m_End = DateTime.UtcNow + TimeSpan.FromMinutes(3.0);
			}

			protected override void OnTick()
			{
				if (m_Mobile.NetState == null || DateTime.UtcNow > m_End)
				{
					m_Mobile.Frozen = false;
					m_Mobile.CloseGump(typeof(StuckMenu));

					Stop();
				}
				else
				{
					m_Mobile.Frozen = true;
				}
			}
		}

		private class TeleportTimer : Timer
		{
			private readonly Mobile m_Mobile;
			private readonly StuckMenuEntry m_Destination;
			private readonly DateTime m_End;

			public TeleportTimer(Mobile mobile, StuckMenuEntry destination, TimeSpan delay) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.0))
			{
				Priority = TimerPriority.TwoFiftyMS;

				m_Mobile = mobile;
				m_Destination = destination;
				m_End = DateTime.UtcNow + delay;
			}

			protected override void OnTick()
			{
				if (DateTime.UtcNow < m_End)
				{
					m_Mobile.Frozen = true;
				}
				else
				{
					m_Mobile.Frozen = false;
					Stop();

					if (Factions.Sigil.ExistsOn(m_Mobile))
					{
						m_Mobile.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
						return;
					}

					var idx = Utility.Random(m_Destination.Locations.Length);
					var dest = m_Destination.Locations[idx];

					Map destMap;
					if (m_Mobile.Map == Map.Trammel)
					{
						destMap = Map.Trammel;
					}
					else if (m_Mobile.Map == Map.Felucca)
					{
						destMap = Map.Felucca;
					}
					else
					{
						destMap = m_Mobile.Murderer ? Map.Felucca : Map.Trammel;
					}

					Mobiles.BaseCreature.TeleportPets(m_Mobile, dest, destMap);
					m_Mobile.MoveToWorld(dest, destMap);
				}
			}
		}
	}
}