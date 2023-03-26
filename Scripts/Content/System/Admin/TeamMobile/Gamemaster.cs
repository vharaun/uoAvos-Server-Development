using Server.Accounting;
using Server.Commands;
using Server.ContextMenus;
using Server.Engines.CannedEvil;
using Server.Gumps;
using Server.Items;
using Server.Network;

using System;
using System.Collections.Generic;
using System.IO;

namespace Server.Mobiles
{
	public class GameMaster_GM : BaseGuildmaster
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override NpcGuild NpcGuild => NpcGuild.MerchantsGuild;

		#region Interactions: Based On Keywords

		private bool m_Gated;

		#endregion Edited By: A.A.R

		#region NPC Auto-Deletion Timer

		private DateTime m_npcAutoDelete;

		#endregion Edited By: A.A.R

		#region Automated Greetings For Players

		private static bool m_Talked;
		private readonly string[] npcSpeech = new string[]
		{
			"Welcome traveller! how may I assist thee?",
		};

		#endregion Edited By: A.A.R

		[Constructable]
		public GameMaster_GM()
			: base("merchant")
		{

			//----------This Randomizes The Sex Of The NPC--------------------//

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
			}

			//----------This Creates A Random Look To The NPC-----------------//

			Title = "[GM]";
			NameHue = 11;

			VendorAccessLevel = AccessLevel.Counselor;
			AccessLevel = AccessLevel.GameMaster;

			SpeechHue = Utility.RandomDyedHue();
			Hue = Utility.RandomSkinHue();

			var hair = new Item(Utility.RandomList(0x203B, 0x2049, 0x2048, 0x204A)) {
				Hue = Utility.RandomNondyedHue(),
				Layer = Layer.Hair,
				Movable = false
			};
			AddItem(hair);

			if (Utility.RandomBool() && !Female)
			{
				var beard = new Item(Utility.RandomList(0x203E, 0x203F, 0x2040, 0x2041, 0x204B, 0x204C, 0x204D)) {
					Hue = hair.Hue,
					Layer = Layer.FacialHair,
					Movable = false
				};

				AddItem(beard);
			}

			//----------This Toggles The NPC Movement: On Or Off--------------//

			CantWalk = true;

			//----------This Makes The NPC Equip HandHeld Items---------------//

			switch (Utility.Random(3))
			{
				case 0: AddItem(new BookOfNinjitsu()); break;
				case 1: AddItem(new BookOfBushido()); break;
				case 2: AddItem(new BookOfChivalry()); break;
			}

			//----------This Sets What Cloth The NPC Will Wear----------------//

			var robe = new GameMaster_GM_Robe {
				AccessLevel = AccessLevel.GameMaster,
				Movable = false,
				Hue = 0x26,
				LootType = LootType.Blessed
			};
			AddItem(robe);

			//----------NPC Auto-Deletion Timer (Timer Set At 5min)----------//

			m_npcAutoDelete = DateTime.UtcNow + TimeSpan.FromSeconds(180);
		}

		public override void OnThink()
		{
			base.OnThink();
			if (m_npcAutoDelete <= DateTime.UtcNow)
			{
				Delete();
			}
		}

		//----------This Gives Your Staff A Monthly Gift-----------------//

		public class GameMaster_Entry : ContextMenuEntry
		{
			private readonly Mobile m_Mobile;
			private readonly Mobile m_Giver;

			public GameMaster_Entry(Mobile from, Mobile giver)
				: base(6146, 3)
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
				if (!(m_Mobile is PlayerMobile))
				{
					return;
				}

				var mobile = (PlayerMobile)m_Mobile;
				{
					if (!mobile.HasGump(typeof(GameMaster_Talk)))
					{
						mobile.SendGump(new GameMaster_Talk());
					}
				}
			}
		}


		//------This Code Makes This NPC Behave As An NPC Vendor----------//

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBGameMaster());
		}

		//----------------------------------------------------------------//

		#region Automated Greetings For Players

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m.InRange(this, 3) && m is PlayerMobile)
			{
				if (!m.HasGump(typeof(GM_StaffKeywords)))
				{
					m.SendGump(new GM_StaffKeywords());
				}
			}

			if (!m.InRange(this, 3) && m is PlayerMobile)
			{
				if (m.HasGump(typeof(GM_StaffKeywords)))
				{
					m.CloseGump(typeof(GM_StaffKeywords));
				}
			}

			if (m_Talked == false)
			{
				if (m.InRange(this, 4))
				{
					m_Talked = true;
					SayRandom(npcSpeech, this);
					Move(GetDirectionTo(m.Location));
					m.SendMessage("Please use the keywords list to get the help that you need.");

					// Start timer to prevent spam 
					var t = new SpamTimer_GM();
					t.Start();
				}
			}
		}

		private class SpamTimer_GM : Timer
		{
			public SpamTimer_GM()
				: base(TimeSpan.FromSeconds(20))
			{
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				m_Talked = false;
			}
		}

		private static void SayRandom(string[] say, Mobile m)
		{
			m.Say(say[Utility.Random(say.Length)]);
		}

		#endregion Edited By: A.A.R

		#region Interactions: Based On Keywords

		#region Keyword Listing - A Quick Reference
		/*   
            > serverinfo....... //launch browser
            > tosagreement..... //launch browser          
            > serverrules...... //launch browser
            > meetourstaff..... //launch browser
            > showcredits...... //launch browser
                 
            > reportplayer..... //gump displayed
            > reportlag........ //gump displayed  
            > reportguild...... //gump displayed
            > reportdefect..... //gump displayed
            > reportadmin...... //gump displayed
            > livesupport...... //page livestaff

            > teleportme....... //launches gates
            > relocateme....... //moves stuck pm
            > retrievebody..... //retrieves body
            > retrievepets..... //retrieves pets
            > accounthelp...... //gump displayed                     
        */
		#endregion Edited By: A.A.R

		#region NPC GameMaster - Unacceptable Words

		public override bool HandlesOnSpeech(Mobile from)
		{
			if (from.InRange(Location, 5))
			{
				return true;
			}

			return base.HandlesOnSpeech(from);
		}

		#region Unacceptable Word List

		private readonly List<string> m_UnacceptableWords = new List<string>(new string[]{"ass","asshole","blowjob","bitch","bitches","biatch","biatches","breasts","chinc","chink","cunnilingus","cum","cumstain","cocksucker","clit",
				"chigaboo","cunt","clitoris","cock","dick","dickhead","dyke","dildo","fuck","fucktard","felatio","fag","faggot","hitler","jigaboo","jizzm","jizz","jiz","jism","jiss","jis","jerkoff","jackoff", "kyke","kike",
				"klit","lezbo","lesbo","nigga","niggas","nigger","piss","penis","prick","pussy","retard","retarded","spic","shit","spunk","spunker","smeg","smegg","twat","tit","tits","titties", "tittys","titie","tities",
				"tity","tard","vagina","wop","wigger","wiger"});

		#endregion Edited By: A.A.R

		private bool ContainsUnacceptableWords(string speech)
		{
			var speechArray = speech.Split(' ');

			foreach (var word in speechArray)
			{
				if (m_UnacceptableWords.Contains(word.ToLower())) //line 300
				{
					return true;
				}
			}

			return false;
		}

		public override void OnSpeech(SpeechEventArgs args)
		{
			var said = args.Speech.ToLower();
			var from = args.Mobile;

			if (ContainsUnacceptableWords(said))
			{
				from.MoveToWorld(new Point3D(1483, 1617, 20), Map.Trammel); //Location To Send Players If They Say Unacceptable Words
				from.SendMessage("You Have Been Jailed For Using Inappropriate Language And/Or Out Of Character, Real-World, References In Front Of A Staff Member");
				return;
			}

			#endregion Edited By: Morxeton

			switch (said)
			{
				//General Information 

				#region serverinfo
				//Some People Are Interested About How Your Server Came To Be. Tell Them!

				case ("serverinfo"):
					{
						Say(String.Format("Ahhh! Inquisitive minds want to know?! Allow me to redirect your request.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/serverinfo");
						break;
					}

				#endregion Edited By: A.A.R

				#region tosagreement
				//A Players Inability To Understand The Consequences For Breaking The Servers Rules Makes Them Stupid.

				case ("tosagreement"):
					{
						Say(String.Format("Sure! Allow me to redirect you to our website. Thank you.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/termsofservice");
						break;
					}

				#endregion Edited By: A.A.R

				#region serverrules
				//Some People Want To Play By The Rules And/Or Learn To Get Around Them! Either Way, This Should Help.

				case ("serverrules"):
					{
						Say(String.Format("A good law abiding adventurer! 'Tis a pleasure to meet you.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/termsofservice");
						break;
					}

				#endregion Edited By: A.A.R

				#region meetourstaff
				//Every Server Website Should Have A Page Devoted To Staff Introductions!

				case ("meetourstaff"):
					{
						Say(String.Format("Sure! Please be patient while I redirect you to our website. Thank you.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/meetourstaff");
						break;
					}

				#endregion Edited By: A.A.R

				#region showcredits
				//Someone Aside From You Has Also Worked Their Ass Of To Make Your Server What It Is, Give Them Credit!

				case ("showcredits"):
					{
						Say(String.Format("Sure! Please be patient while I redirect you to our website. Thank you.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/credits");
						break;
					}

				#endregion Edited By: A.A.R

				//Player Reporting

				#region reportplayer
				//Lag Sucks, Especially When Hunting, Let Us Know About It!

				case ("reportplayer"):
					{
						args.Mobile.SendGump(new ReportPlayer());
						Say(String.Format("Thank you for your report {0}! We'll get this resolved.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("mailto:yourname@yoursitename.com");
						break;
					}

				#endregion Edited By: A.A.R

				#region reportlag
				//Lag Sucks, Especially When Hunting, Let Us Know About It!

				case ("reportlag"):
					{
						args.Mobile.SendGump(new ReportLag());
						Say(String.Format("Thank you for your report {0}! Sorry about the lag.", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#region reportguild
				//Mob Mentality Can Take Over Sometimes, Report Them!

				case ("reportguild"):
					{
						args.Mobile.SendGump(new ReportGuild());
						Say(String.Format("Thank you for your report {0}! We'll get this resolved.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("mailto:yourname@yoursitename.com");
						break;
					}

				#endregion Edited By: A.A.R

				#region reportdefect
				//Facets Aren't Perfect, Keep Track Of Game Map And Item Defects

				case ("reportdefect"):
					{
						args.Mobile.SendGump(new ReportDefect());
						Say(String.Format("Thank you for your report {0}! We'll be fixing this soon.", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#region reportadmin
				//Staff Can Get Out Of Hand At Times, Report Them!

				case ("reportadmin"):
					{
						args.Mobile.SendGump(new ReportAdmin());
						Say(String.Format("Thank you for your report {0}! We'll get this resolved.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("mailto:yourname@yoursitename.com");
						break;
					}

				#endregion Edited By: A.A.R

				#region livesupport
				//Allows Players To Page Real Staff Members Online

				case ("livesupport"):
					{
						args.Mobile.SendGump(new Server.Engines.Help.HelpGump(args.Mobile));
						break;
					}

				#endregion Edited By: A.A.R

				//Player Assistance

				#region teleportme
				//Assists Players In Finding Their Way After Getting Lost

				case ("teleportme"):
					{
						if (from.Region is Regions.Jail || from.Region is Regions.DungeonRegion || from.Region is ChampionSpawnRegion)
						{
							Say(String.Format("HA!! We can't let you escape that easily!", args.Mobile.Name));
							return;
						}

						if (m_Gated == false)
						{
							m_Gated = true;
							args.Mobile.SendGump(new GM_TeleportMe());
							break;
						}

						Say(String.Format("I've already sent you a gate out of here, please be patient.", args.Mobile.Name));
						Say(String.Format("My mana won't regenerate for thirty minutes.", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#region relocateme
				//Will Move Stuck Players, (Not Teleport Or Gate Them), To A Custom Location

				case ("relocateme"):
					{
						if (from.Region is Regions.Jail || from.Region is Regions.DungeonRegion || from.Region is ChampionSpawnRegion)
						{
							Say(String.Format("HA!! We can't let you escape that easily!", args.Mobile.Name));
							return;
						}

						switch (Utility.Random(6))
						{
							#region Editing Instructions

							#region Add Custom Locations
							/*
                                Simply replace the cases we're using with the commented out ones below with these ones and
                                fill in the x,y,z coordinates you want. This is an alternative to the random spawning points
                                we're using. This option only spawns to one of 3 definative locations of your choosing. If you
                                decide to add more locations just increase the case number by one and copy the format of the 
                                commented out cases below to ensure everything compiles right.
                             
                                case 0: from.MoveToWorld(new Point3D(1490, 1617, 20), Map.Trammel); break;
                                case 1: from.MoveToWorld(new Point3D(1490, 1617, 20), Map.Trammel); break;
                                case 2: from.MoveToWorld(new Point3D(1495, 1617, 20), Map.Trammel); break;
                                case 3: from.MoveToWorld(new Point3D(1500, 1617, 20), Map.Trammel); break;

                                Example On How To Edit This:
                                case #: from.MoveToWorld(new Point3D(xCoordinate, yCoordinate, zCoordinate), Map.FacetName); break;
                             
                                You can find the ' x, y, and z ' coordinates by typing ' [where ' in the game world and it will 
                                display the ' x, y, and z ' coordinates in that exact order on the bottom left of your monitor.     
                            */
							#endregion Edited By: A.A.R

							#region Add Random Locations
							/*
                                The x,y,z coordinates are your characters position to find out your custom facets x,y,z
                                coordinates: in-game - goto the location and type,' [where ' and then plug those numbers
                                below. The numbers will appear in the x,y,z order in-game so its relatively easy to do.

                                case 0: from.MoveToWorld(new Point3D(from.X+1, from.Y, from.Z), from.Map); break;
                                case 1: from.MoveToWorld(new Point3D(from.X+2, from.Y, from.Z), from.Map); break;
                                case 2: from.MoveToWorld(new Point3D(from.X+3, from.Y, from.Z), from.Map); break;
                                case 3: from.MoveToWorld(new Point3D(from.X, from.Y+1, from.Z), from.Map); break;
                                case 4: from.MoveToWorld(new Point3D(from.X, from.Y+2, from.Z), from.Map); break;
                                case 5: from.MoveToWorld(new Point3D(from.X, from.Y+3, from.Z), from.Map); break;
                             
                                Example On How To Edit This:
                                case 0: from.MoveToWorld(new Point3D(from.EditX, from.EditY, from.EditZ), from.Map); break;

                                Leaving the settings: ' from.X ', ' from.Y ', and the ' from.Z ' spawns your character on itself;
                                that is your location. Adding a ' +3 ' to make ' from.Y+3 ' spawns your character 3 tiles away
                                from your itself on the Y axis of the game; likewise adding a ' +2 ' to make ' from.X+2 ' spawns
                                your character 2 tiles away from itself on the X axis of the game. Z is just altitude so its best
                                to leave the Z axis of the game at ' from.Z ', by default this will move your character wherever
                                the variables below takes you, but leaves your feet touching the ground at all times.
                            */
							#endregion Edited By: A.A.R

							#endregion Edited By: A.A.R

							case 0: from.MoveToWorld(new Point3D(from.X + 1, from.Y, from.Z), from.Map); break;
							case 1: from.MoveToWorld(new Point3D(from.X + 2, from.Y, from.Z), from.Map); break;
							case 2: from.MoveToWorld(new Point3D(from.X + 3, from.Y, from.Z), from.Map); break;
							case 3: from.MoveToWorld(new Point3D(from.X, from.Y + 1, from.Z), from.Map); break;
							case 4: from.MoveToWorld(new Point3D(from.X, from.Y + 2, from.Z), from.Map); break;
							case 5: from.MoveToWorld(new Point3D(from.X, from.Y + 3, from.Z), from.Map); break;
						}

						break;
					}

				#endregion Edited By: A.A.R

				#region retrievepets
				//Makes It Easier For Players To Retrieve Their Pets

				case ("retrievepets"):
					{
						var summonablePets = CalculateSummonablePets(args.Mobile);

						if (summonablePets.Count > 0)
						{
							args.Mobile.SendGump(new GM_RetrievePet(summonablePets));
							Say(String.Format("Would you like me to summon your pets {0}?", args.Mobile.Name));
						}
						else
						{
							Say("You don't have any eligible pets to summon!");
						}

						break;
					}

				#endregion Edited By: Morxeton

				#region retrievebody
				//Makes It Easier For Players To Retrieve Their Corpses

				case ("retrievebody"):
					{
						var corpse = from.Corpse;

						if (from.Corpse == null)
						{
							Say(String.Format("HA! Thou art trying to fool me!! This will teach you!", args.Mobile.Name));
							from.BoltEffect(0);
							from.SendMessage("You feel a big jolt of electricity!");
							from.Damage(Utility.Random(20, 55));
							return;
						}

						Effects.SendLocationEffect(new Point3D(from.X, from.Y, from.Z), from.Map, 0x3709, 13);
						from.PlaySound(0x208);

						var fromLoc = corpse.Location;
						corpse.MoveToWorld(from.Location, from.Map);
						break;
					}

				#endregion Edited By: A.A.R

				#region accounthelp
				//Allows Players To View Their Account Info And Change Their Password

				case ("accounthelp"):
					{
						args.Mobile.SendGump(new AccountLogin(args.Mobile));
						Say(String.Format("Please verify your account login information. Thank you.", args.Mobile.Name));
						break;
					}

					#endregion Edited By: A.A.R

			}
		}

		#region retrievepets: CalculateSummonablePets

		private List<Mobile> CalculateSummonablePets(Mobile from)
		{
			var summonablePets = new List<Mobile>();

			var pm = (PlayerMobile)from;

			foreach (var pet in pm.AllFollowers)
			{
				if (!(pet is IMount) || ((IMount)pet).Rider == null)
				{
					summonablePets.Add(pet);
				}
			}

			return summonablePets;
		}

		#endregion Edited By: Morxeton

		#endregion Edited By: A.A.R

		#region Click The NPC To Open Up A Gump

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);
			list.Add(new GameMaster_Entry(from, this));
		}

		#endregion Edited By: A.A.R

		public override bool ClickTitle => false;
		public override bool IsActiveVendor => true;

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			var m = from;
			var mobile = m as PlayerMobile;

			from.SendMessage("I appreciate the offer, but I do this job out of the love for the game.");
			return false;
		}

		public GameMaster_GM(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1); // version

			#region NPC Auto-Deletion Timer

			writer.Write(m_npcAutoDelete);

			#endregion Edited By: A.A.R
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						#region NPC Auto-Deletion Timer

						m_npcAutoDelete = reader.ReadDateTime();

						#endregion Edited By: A.A.R
					}
					break;

				default:
					{

					}
					break;
			}
		}
	}

	public class SBGameMaster : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGameMaster()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo(typeof(Bandage), 5, 20, 0xE21, 0));
				Add(new GenericBuyInfo(typeof(LesserHealPotion), 15, 20, 0xF0C, 0));
				Add(new GenericBuyInfo(typeof(Ginseng), 3, 20, 0xF85, 0));
				Add(new GenericBuyInfo(typeof(Garlic), 3, 20, 0xF84, 0));
				Add(new GenericBuyInfo(typeof(RefreshPotion), 15, 20, 0xF0B, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add(typeof(Bandage), 1);
				Add(typeof(LesserHealPotion), 7);
				Add(typeof(RefreshPotion), 7);
				Add(typeof(Garlic), 2);
				Add(typeof(Ginseng), 2);
			}
		}
	}

	#region Automated Staff Member Gumps

	public class AccountInfo : Gump
	{
		private readonly Mobile m_From;

		private readonly int m_PassLength = 6;

		#region AccountInfo Gump Configuration

		public AccountInfo(Mobile from) : base(0, 0)
		{
			m_From = from;

			var acct = (Account)from.Account;
			var pm = (PlayerMobile)from;
			var ns = from.NetState;
			var v = ns.Version;

			var totalTime = (DateTime.UtcNow - acct.Created);

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddPage(1);

			AddBackground(161, 153, 473, 289, 9200);
			AddItem(156, 415, 6914);
			AddItem(595, 416, 6913);
			AddItem(169, 355, 6920);
			AddItem(599, 153, 6917);
			AddItem(154, 154, 6916);
			AddBackground(196, 182, 412, 235, 9270);
			AddImage(111, 220, 10400);
			AddImage(602, 234, 10411);
			AddButton(612, 337, 22150, 22151, 0, GumpButtonType.Reply, 0);
			AddAlphaRegion(196, 181, 411, 237);
			AddBackground(210, 196, 385, 207, 9270);
			AddLabel(296, 217, 1160, @"GENERAL ACCOUNT INFORMATION");
			AddAlphaRegion(227, 254, 350, 101);
			AddLabel(234, 254, 195, @"Client Version:");
			AddLabel(415, 254, 195, @"Max Player Accounts:");
			AddLabel(552, 254, 64, @"02"); //Edit To Match The Code In AccountHandler.cs
			AddLabel(234, 274, 195, @"IP Address:");
			AddLabel(415, 274, 195, @"Max Account Housing:");
			AddLabel(552, 274, 64, @"02"); //Edit To Match The Code In BaseHouse.cs
			AddLabel(234, 294, 195, @"Creation Date:");
			AddLabel(234, 315, 195, @"Played Time:");
			AddLabel(234, 335, 195, @"Account Age:");
			AddLabel(332, 254, 64, v == null ? "(null)" : v.ToString());
			AddLabel(310, 274, 64, ns.ToString());
			AddLabel(332, 294, 64, acct.Created.ToString());
			AddButton(472, 366, 12010, 12009, 1, GumpButtonType.Page, 2);
			AddLabel(254, 363, 132, @"Click Button To Change Password:");
			AddLabel(385, 230, 1172, acct.Username.ToString());

			var gt = pm.GameTime.Days + " Days, " + pm.GameTime.Hours + " Hrs, " + pm.GameTime.Minutes + " Minutes, " + pm.GameTime.Seconds + " Seconds ";
			AddLabel(318, 315, 64, gt.ToString());

			var tt = totalTime.Days + " Days, " + totalTime.Hours + " Hrs, " + totalTime.Minutes + " Minutes, " + totalTime.Seconds + " Seconds ";
			AddLabel(321, 334, 64, tt.ToString());

			AddPage(2);

			AddBackground(161, 153, 473, 289, 9200);
			AddItem(156, 415, 6914);
			AddItem(595, 416, 6913);
			AddItem(169, 355, 6920);
			AddItem(599, 153, 6917);
			AddItem(154, 154, 6916);
			AddBackground(196, 182, 412, 235, 9270);
			AddImage(111, 220, 10400);
			AddImage(602, 234, 10411);
			AddButton(612, 337, 22150, 22151, 0, GumpButtonType.Reply, 0);
			AddAlphaRegion(196, 181, 411, 237);
			AddBackground(210, 196, 385, 207, 9270);
			AddImageTiled(357, 252, 212, 25, 9304);
			AddImageTiled(357, 287, 212, 25, 9304);
			AddImageTiled(356, 322, 212, 25, 9304);
			AddLabel(256, 217, 1160, @"ACCOUNT LOGIN PASSWORD CONTROL PANEL");
			AddLabel(235, 255, 195, @"Current Password:");
			AddLabel(235, 289, 195, @"New Password:");
			AddLabel(235, 324, 195, @"Confirm Password:");
			AddImage(335, 292, 2092);
			AddTextEntry(357, 252, 212, 25, 0, 1, @"");
			AddTextEntry(357, 287, 212, 25, 0, 2, @"");
			AddTextEntry(356, 322, 212, 25, 0, 3, @"");
			AddButton(472, 366, 12010, 12009, 1, GumpButtonType.Reply, 1);
		}

		#endregion Edited By: A.A.R

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (info.ButtonID == 1)
			{
				var from = state.Mobile;
				var acct = (Account)from.Account;

				var cpass = info.GetTextEntry(1).Text;
				var newpass = info.GetTextEntry(2).Text;
				var newpass2 = info.GetTextEntry(3).Text;

				if (acct.CheckPassword(cpass))
				{
					if (newpass == null || newpass2 == null)
					{
						from.SendMessage(38, "You must type in a new password and confirm it.");
					}
					else if (newpass.Length <= m_PassLength)
					{
						from.SendMessage(38, "Your new password must be at least characters {0} long.", m_PassLength);
					}
					else if (newpass == newpass2)
					{
						from.SendMessage("Your password has been changed to {0}.", newpass);
						acct.SetPassword(newpass);
						//CommandLogging.WriteLine( From, "{0} {1} Has Changed Thier Password For Account {2} Using The Automated GM System", from.AccessLevel, CommandLogging.Format( from ), acct.Username );
					}
					else
					{
						from.SendMessage(38, "Your new password did not match your confirm password. Please check your spelling and try again.");
						from.SendMessage(38, "Just a reminder. Passwords are case sensitive.");
					}
				}
				else
				{
					from.SendMessage(38, "The current password you typed in did not match your current password on record. Please check your spelling and try again.");
					from.SendMessage(38, "Just a reminder. Passwords are case sensitive.");
				}
			}
		}
	}

	public class AccountLogin : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AccountLogin", AccessLevel.Player, new CommandEventHandler(AccountLogin_OnCommand));
		}

		private static void AccountLogin_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new AccountLogin(e.Mobile));
		}

		private readonly Mobile m_From;

		#region AccountLogin Gump Configuration

		public AccountLogin(Mobile owner) : base(0, 0)
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);

			AddBackground(161, 153, 473, 289, 9200);
			AddItem(156, 415, 6914);
			AddItem(595, 416, 6913);
			AddItem(169, 355, 6920);
			AddItem(599, 153, 6917);
			AddItem(154, 154, 6916);
			AddBackground(196, 182, 412, 235, 9270);
			AddImage(111, 220, 10400);
			AddImage(602, 234, 10411);
			AddButton(612, 337, 22150, 22151, 0, GumpButtonType.Reply, 0);
			AddAlphaRegion(196, 181, 411, 237);
			AddBackground(210, 196, 385, 207, 9270);
			AddLabel(288, 217, 1160, @"SERVER AND ACCOUNT INFORMATION");
			AddImageTiled(334, 266, 212, 25, 9304);
			AddImageTiled(334, 307, 212, 25, 9304);
			AddLabel(252, 269, 195, @"Username:");
			AddLabel(252, 309, 195, @"Password:");
			AddButton(472, 366, 12010, 12009, 1, GumpButtonType.Reply, 1);
			AddImage(254, 366, 2092);
			AddTextEntry(334, 266, 212, 25, 0, 1, @"");
			AddTextEntry(334, 307, 212, 25, 0, 2, @"");
		}

		#endregion Edited By: A.A.R

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (info.ButtonID == 1)
			{
				var from = state.Mobile;
				var acct = (Account)from.Account;

				var user = info.GetTextEntry(1).Text;
				var pass = info.GetTextEntry(2).Text;

				if (user == acct.Username && acct.CheckPassword(pass))
				{
					from.SendMessage(64, "Login Confirmed.");
					from.SendGump(new AccountInfo(from));
				}
				else
				{
					from.SendMessage(38, "Either the username or password you entered was incorrect, Please recheck your spelling and remember that passwords and usernames are case sensitive. Please try again.");
				}
			}
		}
	}

	public class ReportAdmin : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("ReportAdmin", AccessLevel.GameMaster, new CommandEventHandler(ReportAdmin_OnCommand));
		}

		[Usage("ReportAdmin")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void ReportAdmin_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new ReportAdmin());
		}

		#region ReportAdmin Gump Configuration

		public ReportAdmin() : base(0, 0)
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
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddLabel(317, 157, 695, @"REPORT A STAFF MEMBER");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button2, GumpButtonType.Reply, 2);
			AddLabel(218, 441, 930, @"Remember To Email Our Staff A Screenshot Of The Incident");
			AddLabel(226, 458, 930, @"Along With The Names Of The People Involved. Thank You.");
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button2,
			TextEntry1,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			var acct = (Account)from.Account;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(ReportAdmin));
						from.SendMessage("You Decide Not To File A Admin Report.");
						break;
					}

				case (int)Buttons.Button2:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Filed A Admin Report", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Reports/")) //create directory
						{
							Directory.CreateDirectory("Export/Reports/");
						}

						using (var op = new StreamWriter("Export/Reports/Admin.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Admin Report Has Been Filed! Thank You.");
						break;
					}
			}
		}
	}

	public class ReportDefect : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("ReportDefect", AccessLevel.GameMaster, new CommandEventHandler(ReportDefect_OnCommand));
		}

		[Usage("ReportDefect")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void ReportDefect_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new ReportDefect());
		}

		#region ReportDefect Gump Configuration

		public ReportDefect() : base(0, 0)
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
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddLabel(343, 157, 695, @"REPORT A DEFECT");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button2, GumpButtonType.Reply, 2);
			AddLabel(211, 441, 930, @"Defect Reports Help Us Fix Our Detail Oriented Game World");
			AddLabel(226, 458, 930, @"Without These Reports There Is Very Little We Can Do");
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button2,
			TextEntry1,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			var acct = (Account)from.Account;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(ReportDefect));
						from.SendMessage("You Decide Not To File A Defect Report.");
						break;
					}

				case (int)Buttons.Button2:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Filed A Defect Report", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Reports/")) //create directory
						{
							Directory.CreateDirectory("Export/Reports/");
						}

						using (var op = new StreamWriter("Export/Reports/Defect.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Defect Report Has Been Filed! Thank You.");
						break;
					}
			}
		}
	}

	public class ReportGuild : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("ReportGuild", AccessLevel.GameMaster, new CommandEventHandler(ReportGuild_OnCommand));
		}

		[Usage("ReportGuild")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void ReportGuild_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new ReportGuild());
		}

		#region ReportGuild Gump Configuration

		public ReportGuild() : base(0, 0)
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
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddLabel(347, 157, 695, @"REPORT A GUILD");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button2, GumpButtonType.Reply, 2);
			AddLabel(218, 441, 930, @"Remember To Email Our Staff A Screenshot Of The Incident");
			AddLabel(226, 458, 930, @"Along With The Names Of The People Involved. Thank You.");
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button2,
			TextEntry1,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			var acct = (Account)from.Account;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(ReportGuild));
						from.SendMessage("You Decide Not To File A Guild Report.");
						break;
					}

				case (int)Buttons.Button2:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Filed A Guild Report", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Reports/")) //create directory
						{
							Directory.CreateDirectory("Export/Reports/");
						}

						using (var op = new StreamWriter("Export/Reports/Guild.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Guild Report Has Been Filed! Thank You.");
						break;
					}
			}
		}
	}

	public class ReportLag : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("ReportLag", AccessLevel.GameMaster, new CommandEventHandler(ReportLag_OnCommand));
		}

		[Usage("ReportLag")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void ReportLag_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new ReportLag());
		}

		#region ReportLag Gump Configuration

		public ReportLag() : base(0, 0)
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
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddLabel(332, 157, 695, @"REPORT A LAG SPIKE");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button2, GumpButtonType.Reply, 2);
			AddLabel(223, 441, 930, @"Lag Spike Reports Help Us Monitor Our Servers Stability");
			AddLabel(226, 458, 930, @"Without These Reports There Is Very Little We Can Do");
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button2,
			TextEntry1,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			var acct = (Account)from.Account;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(ReportLag));
						from.SendMessage("You Decide Not To File A Lag Report.");
						break;
					}

				case (int)Buttons.Button2:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Filed A Lag Report", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Reports/")) //create directory
						{
							Directory.CreateDirectory("Export/Reports/");
						}

						using (var op = new StreamWriter("Export/Reports/Lag.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Lag Report Has Been Filed! Thank You.");
						break;
					}
			}
		}
	}

	public class ReportPlayer : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("ReportPlayer", AccessLevel.GameMaster, new CommandEventHandler(ReportPlayer_OnCommand));
		}

		[Usage("ReportPlayer")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void ReportPlayer_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new ReportPlayer());
		}

		#region ReportPlayer Gump Configuration

		public ReportPlayer() : base(0, 0)
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
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddLabel(341, 157, 695, @"REPORT A PLAYER");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button2, GumpButtonType.Reply, 2);
			AddLabel(218, 441, 930, @"Remember To Email Our Staff A Screenshot Of The Incident");
			AddLabel(226, 458, 930, @"Along With The Names Of The People Involved. Thank You.");
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button2,
			TextEntry1,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			var acct = (Account)from.Account;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(ReportPlayer));
						from.SendMessage("You Decide Not To File A Player Report.");
						break;
					}

				case (int)Buttons.Button2:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Filed A Player Report", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Reports/")) //create directory
						{
							Directory.CreateDirectory("Export/Reports/");
						}

						using (var op = new StreamWriter("Export/Reports/Player.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Player Report Has Been Filed! Thank You.");
						break;
					}
			}
		}
	}

	public class GM_RetrievePet : Gump
	{
		private readonly Mobile caller;

		#region GM_RetrievePet Gump Configuration

		private const int m_Price = 3500;
		private readonly List<Mobile> m_SummonablePets = new List<Mobile>();

		public GM_RetrievePet(List<Mobile> summonablePets) : base(0, 0)
		{

			m_SummonablePets = summonablePets;

			var petCount = m_SummonablePets.Count;
			var price = m_Price * petCount;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(161, 153, 473, 289, 9200);
			AddItem(156, 415, 6914);
			AddItem(595, 416, 6913);
			AddItem(169, 355, 6920);
			AddItem(599, 153, 6917);
			AddItem(154, 154, 6916);
			AddBackground(196, 182, 412, 235, 9270);
			AddImage(111, 220, 10400);
			AddImage(602, 234, 10411);
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 0);//Cancel
			AddAlphaRegion(196, 181, 411, 237);
			AddBackground(210, 196, 385, 207, 9270);
			AddImageTiled(304, 244, 189, 18, 2621);
			AddLabel(280, 218, 195, @"SUMMON PET(S) TO YOUR LOCATION?");
			AddItem(230, 214, 8406);
			AddItem(533, 335, 8465);
			AddItem(231, 278, 9624);
			AddItem(537, 216, 8471);
			AddItem(534, 282, 8464);
			AddItem(222, 342, 8501);
			AddButton(289, 327, 4005, 4006, (int)Buttons.Button2, GumpButtonType.Reply, 0);//YES
			AddButton(289, 356, 4005, 4006, (int)Buttons.Button3, GumpButtonType.Reply, 0);//NO
			AddLabel(361, 328, 695, @"I'll Happily Pay The Gold!");
			AddLabel(361, 357, 695, @"I'll Find My Pets Myself!");
			AddLabel(327, 357, 232, @"No!!!");
			AddLabel(326, 328, 232, @"Yes!");
			AddImageTiled(304, 261, 189, 39, 2624);
			AddLabel(442, 257, 232, price.ToString());
			AddImageTiled(304, 297, 189, 18, 2627);
			AddLabel(309, 281, 694, @"Gold Coins For Your " + petCount + " Pet(s)");
			AddLabel(316, 257, 694, @"The Charge Will Be:");
			AddImage(304, 243, 2362);
			AddImage(482, 243, 2362);
			AddImage(304, 306, 2362);
			AddImage(482, 306, 2362);
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button2,
			Button3,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			from.CloseGump(typeof(GM_RetrievePet));

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(GM_RetrievePet));
						break;
					}
				case (int)Buttons.Button2:
					{

						var price = m_Price * m_SummonablePets.Count;

						if (Banker.Withdraw(from, price))
						{
							from.SendLocalizedMessage(1060398, price.ToString()); // Amount charged  
							from.SendLocalizedMessage(1060022, Banker.GetBalance(from).ToString()); // Amount left, from bank  

							foreach (var pet in m_SummonablePets)
							{
								pet.MoveToWorld(from.Location, from.Map);

								Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x3728, 10, 30, 5052);
								Effects.PlaySound(from.Location, from.Map, 0x201);
							}
						}
						else
						{
							from.SendMessage("You do not have enough money in your bank to summon your pets!");
						}

						break;
					}

				case (int)Buttons.Button3:
					{
						from.CloseGump(typeof(GM_RetrievePet));
						break;
					}
			}
		}
	}

	public class GM_StaffKeywords : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("GM", AccessLevel.GameMaster, new CommandEventHandler(GM_OnCommand));
		}

		[Usage("GM")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void GM_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new GM_StaffKeywords());
		}

		#region StaffKeywords Gump Configuration

		public GM_StaffKeywords() : base(0, 0)
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(279, 111, 231, 377, 9200);
			AddItem(475, 110, 6917);
			AddItem(471, 461, 6913);
			AddImage(229, 215, 10400);
			AddButton(488, 337, 22150, 22151, 0, GumpButtonType.Reply, 0);
			AddItem(274, 460, 6914);
			AddItem(272, 111, 6916);
			AddItem(288, 357, 6920);
			AddBackground(299, 124, 199, 352, 9390);
			AddAlphaRegion(329, 164, 140, 272);
			AddHtml(335, 171, 129, 259, @"> serverinfo
> tosagreement
> serverrules
> meetourstaff
> showcredits
  ------------
> reportplayer
> reportlag
> reportguild
> reportdefect
> reportadmin
> livesupport
  ------------
> teleportme
> relocateme
> retrievebody
> retrievepets
> accounthelp", true, true);
			AddLabel(339, 127, 695, @"STAFF KEYWORDS");
			AddLabel(347, 454, 0, @""); // Brand Server Name Here
			AddImage(478, 232, 10411);
		}

		#endregion Edited By: A.A.R

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			switch (info.ButtonID)
			{
				case 0:
					{
						from.CloseGump(typeof(GM_StaffKeywords));
						break;
					}

			}
		}
	}

	public class GameMaster_Talk : Gump
	{
		private readonly TimeSpan m_UseDelay = TimeSpan.FromDays(30); //Set To 30 Days

		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("GMTalk", AccessLevel.GameMaster, new CommandEventHandler(GMTalk_OnCommand));
		}

		[Usage("GMTalk")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void GMTalk_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new GameMaster_Talk());
		}

		#region GM_Talk_Context Gump Configuration

		public GameMaster_Talk() : base(0, 0)
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(161, 154, 473, 289, 9200);
			AddItem(156, 415, 6914);
			AddItem(595, 416, 6913);
			AddItem(169, 355, 6920);
			AddItem(599, 153, 6917);
			AddItem(154, 154, 6916);
			AddBackground(196, 182, 412, 235, 9270);
			AddImage(111, 220, 10400);
			AddImage(602, 234, 10411);
			AddButton(612, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 1);
			AddAlphaRegion(196, 181, 411, 237);
			AddBackground(210, 196, 385, 207, 9270);
			AddLabel(302, 218, 195, @""); // Brand Server Name Here
			AddLabel(239, 245, 694, @"We're Very Excited That You've Chosen To Be A Part");
			AddLabel(242, 265, 694, @"Of Our Community! As A Token Of Our Appreciation");
			AddLabel(239, 285, 694, @"We'd Like To Offer You A Monthly Promotional Gift!");
			AddButton(386, 340, 4037, 4036, (int)Buttons.Button2, GumpButtonType.Reply, 2);
			AddLabel(320, 312, 695, @"Double Click The Grab Bag!");
			AddItem(210, 339, 2567);
			AddItem(551, 339, 2573);
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button2,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;
			var acct = (Account)from.Account;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(GameMaster_Talk));
						break;
					}

				case (int)Buttons.Button2:
					{
						var m_UseDelay = TimeSpan.FromDays(30); //Set To 30 Days

						if (from.Backpack != null)
						{
							var pm = (PlayerMobile)from;

							if (pm.AccessLevel == AccessLevel.Player)
							{
								from.SendMessage("Sorry Only Staff Can Recieve Rewards Here");
							}

							if (pm.AccessLevel >= AccessLevel.Counselor)
							{
								if (DateTime.UtcNow >= pm.PromoGiftLast + m_UseDelay)
								{
									from.AddToBackpack(new PromotionalDeed_GM());
									from.CloseGump(typeof(GameMaster_Talk));

									Console.WriteLine("");
									Console.WriteLine("{0} From Account {1} Has Just Redeemed A Monthly Staff Server Gift", from.Name, acct.Username);
									Console.WriteLine("");

									from.SendMessage("Check Back Every Thirty (30) Days To Obtain New Promotional Offers");

									pm.PromoGiftLast = DateTime.UtcNow;
								}
								else
								{
									from.SendMessage("You May Only Obtain One (1) Promotional Gift Every Thirty (30) Days");
								}
							}
						}
						break;
					}
			}
		}
	}

	public class GM_TeleportMe : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("GM_TeleportMe", AccessLevel.GameMaster, new CommandEventHandler(GM_TeleportMe_OnCommand));
		}

		[Usage("GM_TeleportMe")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void GM_TeleportMe_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new GM_TeleportMe());
		}

		#region Gump Configuration

		public GM_TeleportMe() : base(0, 0)
		{
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);
			AddBackground(279, 111, 231, 377, 9200);
			AddItem(475, 110, 6917);
			AddItem(471, 461, 6913);
			AddImage(229, 215, 10400);
			AddButton(488, 337, 22150, 22151, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			AddItem(274, 460, 6914);
			AddItem(272, 111, 6916);
			AddItem(288, 357, 6920);
			AddBackground(299, 124, 199, 352, 9390);
			AddLabel(339, 127, 695, @"SELECT A LOCATION");
			AddLabel(347, 454, 0, @""); // Brand Server Name Here
			AddImage(478, 232, 10411);
			AddAlphaRegion(329, 162, 20, 274);
			AddButton(332, 166, 1209, 1210, (int)Buttons.Button3, GumpButtonType.Reply, 3);
			AddButton(332, 193, 1209, 1210, (int)Buttons.Button4, GumpButtonType.Reply, 4);
			AddButton(332, 220, 1209, 1210, (int)Buttons.Button5, GumpButtonType.Reply, 5);
			AddButton(332, 248, 1209, 1210, (int)Buttons.Button6, GumpButtonType.Reply, 6);
			AddButton(332, 276, 1209, 1210, (int)Buttons.Button7, GumpButtonType.Reply, 7);
			AddButton(332, 305, 1209, 1210, (int)Buttons.Button8, GumpButtonType.Reply, 8);
			AddButton(332, 333, 1209, 1210, (int)Buttons.Button9, GumpButtonType.Reply, 9);
			AddButton(332, 362, 1209, 1210, (int)Buttons.Button10, GumpButtonType.Reply, 10);
			AddButton(332, 391, 1209, 1210, (int)Buttons.Button11, GumpButtonType.Reply, 11);
			AddButton(332, 419, 1209, 1210, (int)Buttons.Button12, GumpButtonType.Reply, 12);

			//Edit Location Labels Here
			AddLabel(358, 163, 0, @"Server Location a");
			AddLabel(358, 190, 0, @"Server Location b");
			AddLabel(358, 217, 0, @"Server Location c");
			AddLabel(358, 246, 0, @"Server Location d");
			AddLabel(358, 273, 0, @"Server Location e");
			AddLabel(358, 302, 0, @"Server Location f");
			AddLabel(358, 329, 0, @"Server Location g");
			AddLabel(358, 358, 0, @"Server Location h");
			AddLabel(358, 387, 0, @"Server Location i");
			AddLabel(358, 415, 0, @"Server Location j");
		}

		#endregion Edited By: A.A.R

		public enum Buttons
		{
			Button1,
			Button3,
			Button4,
			Button5,
			Button6,
			Button7,
			Button8,
			Button9,
			Button10,
			Button11,
			Button12,
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var from = sender.Mobile;

			switch (info.ButtonID)
			{
				case (int)Buttons.Button1:
					{
						from.CloseGump(typeof(GM_TeleportMe));
						from.SendMessage("You Decide Not To Travel Anywhere");
						break;
					}

				//Gate To Moonglow Moongate
				case (int)Buttons.Button3:
					{
						var mglg = new MoonglowGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To Britain Moongate
				case (int)Buttons.Button4:
					{
						var brig = new BritainGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To Jhelom Moongate
				case (int)Buttons.Button5:
					{
						var jheg = new JhelomGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To Yew Moongate
				case (int)Buttons.Button6:
					{
						var yewg = new YewGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To Minoc Moongate
				case (int)Buttons.Button7:
					{
						var ming = new MinocGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To Trinsic Moongate
				case (int)Buttons.Button8:
					{
						var trig = new TrinsicGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To SkaraBrae Moongate    
				case (int)Buttons.Button9:
					{
						var skag = new SkaraBraeGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To Magincia Moongate 
				case (int)Buttons.Button10:
					{
						var magg = new MaginciaGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To NewHaven Moongate 
				case (int)Buttons.Button11:
					{
						var nhvg = new NewHavenGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

				//Gate To BucsDen Moongate
				case (int)Buttons.Button12:
					{
						var bucg = new BucsDenGate {
							Location = from.Location,
							Map = from.Map
						};
						break;
					}

			}
		}
	}

	#endregion
}