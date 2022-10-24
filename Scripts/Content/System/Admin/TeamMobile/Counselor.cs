using Server.Accounting;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Network;

using System;
using System.Collections.Generic;
using System.IO;

namespace Server.Mobiles
{
	public class Counselor_PR : BaseGuildmaster
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override NpcGuild NpcGuild => NpcGuild.MerchantsGuild;

		#region Interactions: Based On Keywords

		private readonly bool m_Gated;

		#endregion Edited By: A.A.R

		#region Automated Greetings For Players

		private static bool m_Talked;
		private readonly string[] npcSpeech = new string[]
		{
			"Welcome traveller! how may I assist thee?",
		};

		#endregion Edited By: A.A.R

		[Constructable]
		public Counselor_PR()
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

			Title = "[PR]";
			NameHue = 11;

			VendorAccessLevel = AccessLevel.Player;
			AccessLevel = AccessLevel.Counselor;

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

			CantWalk = false;

			//----------This Makes The NPC Equip HandHeld Items---------------//

			switch (Utility.Random(3))
			{
				case 0: AddItem(new BookOfNinjitsu()); break;
				case 1: AddItem(new BookOfBushido()); break;
				case 2: AddItem(new BookOfChivalry()); break;
			}

			//----------This Sets What Cloth The NPC Will Wear----------------//

			var robe = new Counselor_PR_Robe {
				AccessLevel = AccessLevel.Counselor,
				Movable = false,
				Hue = 0x3,
				LootType = LootType.Blessed
			};
			AddItem(robe);
		}

		//----------This Gives Your Staff A Monthly Gift-----------------//

		public class Counselor_Entry : ContextMenuEntry
		{
			private readonly Mobile m_Mobile;
			private readonly Mobile m_Giver;

			public Counselor_Entry(Mobile from, Mobile giver)
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
					if (!mobile.HasGump(typeof(Counselor_Talk)))
					{
						mobile.SendGump(new Counselor_Talk());
					}
				}
			}
		}

		//-------This Code Makes This NPC Behave As An NPC Vendor---------//

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBCounselor());
		}

		//----------------------------------------------------------------//

		#region Automated Greetings For Players

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m.InRange(this, 3) && m is PlayerMobile)
			{
				if (!m.HasGump(typeof(PR_StaffKeywords)))
				{
					m.SendGump(new PR_StaffKeywords());
				}
			}
			if (!m.InRange(this, 3) && m is PlayerMobile)
			{
				if (m.HasGump(typeof(PR_StaffKeywords)))
				{
					m.CloseGump(typeof(PR_StaffKeywords));
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
					var t = new SpamTimer_PR();
					t.Start();
				}
			}
		}

		private class SpamTimer_PR : Timer
		{
			public SpamTimer_PR()
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
  
            > livesupport...... //page livestaff
                 
            > skillcap..........//text displayed
            > skills........... //launch browser
            > statcap.......... //text displayed 
            > playerguide...... //launch browser
            > bestiary......... //launch browser
                    
            > events........... //launch browser
            > eventrequest..... //gump displayed
            > hiring........... //submition gump
            > suggestion....... //submition gump
            > donations........ //submition gump                          
        */
		#endregion Edited By: A.A.R

		#region NPC Counselors - Unacceptable Words

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
				if (m_UnacceptableWords.Contains(word.ToLower()))
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

				#region livesupport
				//Allows Players To Page Real Staff Members Online

				case ("livesupport"):
					{
						args.Mobile.SendGump(new Server.Engines.Help.HelpGump(args.Mobile));
						break;
					}

				#endregion Edited By: A.A.R

				//MMORPG Help Desk

				#region skillcap
				//Helps Players Figure Out What The Skill Cap Is

				case ("skillcap"):
					{
						Say(String.Format("Our server currently has a maximum skillcap of 840. There are no plans to increase this number. A skill cap of 840 allows players to set a maximum of 7 skills to 120.", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#region skills
				//Sometimes Players Need Information On Skills And Skill Gain

				case ("skills"):
					{
						Say(String.Format("My apologies {0}, I am forbidden to assist thee with skill training. However, If you tell me the name of the skill you're having issues with, then I'll be more than happy to redirect you to our online skill guide.", args.Mobile.Name));
						break;
					}

				#region Player Skill Guide References

				case ("alchemy"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/alchemy");
						break;
					}

				case ("anatomy"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/anatomy");
						break;
					}

				case ("animal lore"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/animallore");
						break;
					}

				case ("animal taming"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/animaltaming");
						break;
					}

				case ("archery"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/archery");
						break;
					}

				case ("armslore"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/armslore");
						break;
					}

				case ("begging"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/begging");
						break;
					}

				case ("blacksmithy"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/blacksmithy");
						break;
					}

				case ("bowcraft"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/bowcraft");
						break;
					}

				case ("fletching"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/fletching");
						break;
					}

				case ("bushido"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/bushido");
						break;
					}

				case ("camping"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/camping");
						break;
					}

				case ("carpentry"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/carpentry");
						break;
					}

				case ("cartography"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/cartography");
						break;
					}

				case ("chivalry"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/chivalry");
						break;
					}

				case ("cooking"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/cooking");
						break;
					}

				case ("detect hidden"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/detecthidden");
						break;
					}

				case ("discordance"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/discordance");
						break;
					}

				case ("evaluating intelligence"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/evaluatingintelligence");
						break;
					}

				case ("fencing"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/fencing");
						break;
					}

				case ("fishing"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/fishing");
						break;
					}

				case ("focus"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/focus");
						break;
					}

				case ("forensic evaluation"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/forensicevaluation");
						break;
					}

				case ("healing"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/healing");
						break;
					}

				case ("herding"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/herding");
						break;
					}

				case ("hiding"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/hiding");
						break;
					}

				case ("imbuing"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/imbuing");
						break;
					}

				case ("inscription"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/inscription");
						break;
					}

				case ("item identification"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/itemidentification");
						break;
					}

				case ("lockpicking"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/lockpicking");
						break;
					}

				case ("lumberjacking"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/lumberjacking");
						break;
					}

				case ("macefighting"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/macefighting");
						break;
					}

				case ("magery"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/magery");
						break;
					}

				case ("meditation"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/meditation");
						break;
					}

				case ("mining"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/mining");
						break;
					}

				case ("musicianship"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/musicianship");
						break;
					}

				case ("mysticism"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/mysticism");
						break;
					}

				case ("necromancy"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/necromancy");
						break;
					}

				case ("ninjitsu"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/ninjitsu");
						break;
					}

				case ("parrying"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/parrying");
						break;
					}

				case ("peacemaking"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/peacemaking");
						break;
					}

				case ("poisoning"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/poisoning");
						break;
					}

				case ("provocation"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/provocation");
						break;
					}

				case ("removetrap"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/removetrap");
						break;
					}

				case ("resisting spells"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/resistingspells");
						break;
					}

				case ("snooping"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/snooping");
						break;
					}

				case ("spellweaving"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/spellweaving");
						break;
					}

				case ("spiritspeak"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/spiritspeak");
						break;
					}

				case ("stealing"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/stealing");
						break;
					}

				case ("stealth"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/stealth");
						break;
					}

				case ("swordsmanship"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/swordsmanship");
						break;
					}

				case ("tactics"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/tactics");
						break;
					}

				case ("tailoring"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/tailoring");
						break;
					}

				case ("taste identification"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/tasteidentification");
						break;
					}

				case ("throwing"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/throwing");
						break;
					}

				case ("tinkering"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/tinkering");
						break;
					}

				case ("tracking"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/tracking");
						break;
					}

				case ("veterinary"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/veterinary");
						break;
					}

				case ("wrestling"):
					{
						Say(String.Format("Thank you {0}, allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide/skills/wrestling");
						break;
					}

				#endregion Edited By: A.A.R

				#endregion Edited By: A.A.R

				#region statcap
				//Helps Players Figure Out What The Stat Cap Is

				case ("statcap"):
					{
						Say(String.Format("Our server currently has a maximum statcap of 300. There are no plans to increase this number. A stat cap of 300 allows players to evenly set their strength, dexterity, and intelligence to 100.", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#region playerguide
				//Directs Players To Your Servers Online PlayGuide For Assistance

				case ("playguide"):
					{
						Say(String.Format("'Tis good to keep up-to-date on things {0}. Allow me to redirect you to our online playguide.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/playguide");
						break;
					}

				#endregion Edited By: A.A.R

				#region bestiary

				case ("bestiary"):
					{
						Say(String.Format("We've got a lot of creatures on the server {0}. Allow me to redirect you to our online bestiary.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/bestiary");
						break;
					}

				#endregion Edited By: A.A.R

				//Player Involvment

				#region events
				//Some People Are Interested About How Your Server Came To Be. Tell Them!

				case ("events"):
					{
						Say(String.Format("Ahhh! Inquisitive minds want to know?! Allow me to redirect your request.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/scheduledevents");
						break;
					}

				#endregion Edited By: A.A.R

				#region eventrequest
				//Some People Are Interested About How Your Server Came To Be. Tell Them!

				case ("eventrequest"):
					{
						args.Mobile.SendGump(new PR_EventRequest());
						Say(String.Format("Event requests are always welcome! {0}. Thank you for being proactive. If you have any other event ideas, please let us know!", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#region hiring
				//A Toggle! Just Uncomment Which Response You'd Like To Give Your Players

				#region Yes, Staff Is Hiring
				//An Easy Way Of Directing Your Players To Your Staff Member Application
				/*
                case ("hiring"):
                    {
                        Say(String.Format("Absolutely {0}! Staffing positions are now available. Please visit our website for more information. Thank you for your interest and we hope to hear from you soon!", args.Mobile.Name));
                        args.Mobile.LaunchBrowser("http://www.yoursitename.com/staffapplication");
                        break;
                    }
                */
				#endregion Edited By: A.A.R

				#region No, We're Not Hiring
				//A Nice Way Of Saying, "Dude! Stop Asking If You Can Be A Staff Member!!"

				case ("hiring"):
					{
						Say(String.Format("Our apologies {0}, We're just not hiring at this time. We'll post available positions on our website, as soon as they open up, please be patient and check back soon. Thank you.", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#endregion Edited By: A.A.R

				#region suggestion
				//Everyone Has Their Own Ideas On How They Think Things Should Be

				case ("suggestion"):
					{
						args.Mobile.SendGump(new SuggestionBox());
						Say(String.Format("We would really appreciate your input {0}. Thank you. If you have any other suggestions, please let us know!", args.Mobile.Name));
						break;
					}

				#endregion Edited By: A.A.R

				#region donations
				//Makes It Easier For Players To Donate Funds To Your Server

				case ("donate"):
					{
						Say(String.Format("Donations are very welcome, but not required to play. Money received helps keep this server running stable and lag free! Contributors will receive special priviledges and incentives for their support. If you'd like more information then please visit our website. Thank you.", args.Mobile.Name));
						args.Mobile.LaunchBrowser("http://www.yoursitename.com/donationpage");
						break;
					}

					#endregion Edited By: A.A.R

			}
		}

		#endregion Edited By: A.A.R

		#region Click The NPC To Open Up A Gump

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);
			list.Add(new Counselor_Entry(from, this));
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

		public Counselor_PR(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class SBCounselor : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBCounselor()
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

	public class PR_EventRequest : Gump
	{
		private readonly Mobile caller;

		#region Suggestion Box Gump Configuration

		public PR_EventRequest() : base(0, 0)
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
			AddLabel(349, 157, 695, @"EVENT REQUEST");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button2, GumpButtonType.Reply, 0);
			AddLabel(183, 441, 930, @"This Is Your Server And We Want To  Hear What You Have To Say!");
			AddLabel(227, 458, 930, @"Your Feedback Is Extremely Important To Us! Thank You.");
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
						from.CloseGump(typeof(SuggestionBox));
						from.SendMessage("You Decide Not To Submit An Event Request.");
						break;
					}

				case (int)Buttons.Button2:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Submitted An Event Request", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Requests")) //create directory
						{
							Directory.CreateDirectory("Export/Requests");
						}

						using (var op = new StreamWriter("Export/Requests/Event.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Event Request Has Been Submitted! Thank You.");
						break;
					}
			}
		}
	}

	public class PR_StaffKeywords : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("PR", AccessLevel.GameMaster, new CommandEventHandler(PR_OnCommand));
		}

		[Usage("PR")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void PR_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new PR_StaffKeywords());
		}

		#region StaffKeywords Gump Configuration

		public PR_StaffKeywords() : base(0, 0)
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
> livesupport
  ------------
> skillcap
> skills
> statcap
> playerguide
> bestiary
  ------------
> events
> eventrequest
> hiring
> suggestion
> donations", true, true);
			AddLabel(339, 127, 695, @"STAFF KEYWORDS");
			AddLabel(347, 454, 0, @"SHADOWS EDGE");
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
						from.CloseGump(typeof(PR_StaffKeywords));
						break;
					}

			}
		}
	}

	public class SuggestionBox : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("SuggestionBox", AccessLevel.GameMaster, new CommandEventHandler(SuggestionBox_OnCommand));
		}

		[Usage("SuggestionBox")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void SuggestionBox_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new SuggestionBox());
		}

		#region Suggestion Box Gump Configuration

		public SuggestionBox() : base(0, 0)
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
			AddLabel(345, 157, 695, @"SUGGESTION BOX");
			AddLabel(350, 422, 0, @"SHADOWS EDGE");
			AddButton(521, 422, 12009, 12010, (int)Buttons.Button2, GumpButtonType.Reply, 0);
			AddLabel(183, 441, 930, @"This Is Your Server And We Want To  Hear What You Have To Say!");
			AddLabel(228, 458, 930, @"Your Feedback Is Extremely Important To Us! Thank You.");
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
						from.CloseGump(typeof(SuggestionBox));
						from.SendMessage("You Decide Not To Submit A Suggestion.");
						break;
					}

				case (int)Buttons.Button2:
					{
						var submit = info.GetTextEntry((int)Buttons.TextEntry1).Text;

						Console.WriteLine("");
						Console.WriteLine("{0} From Account {1} Submitted A Suggestion", from.Name, acct.Username);
						Console.WriteLine("");

						if (!Directory.Exists("Export/Suggestions")) //create directory
						{
							Directory.CreateDirectory("Export/Suggestions");
						}

						using (var op = new StreamWriter("Export/Suggestions/Suggestion.txt", true))
						{
							op.WriteLine("");
							op.WriteLine("Name Of Character: {0}, Account:{1}", from.Name, acct.Username);
							op.WriteLine("Message: {0}", submit);
							op.WriteLine("");
						}

						from.SendMessage("Your Suggestion Has Been Submitted! Thank You.");
						break;
					}
			}
		}
	}

	public class Counselor_Talk : Gump
	{
		private readonly Mobile caller;
		public static void Initialize()
		{
			Commands.CommandSystem.Register("PRTalk", AccessLevel.GameMaster, new CommandEventHandler(PRTalk_OnCommand));
		}

		[Usage("PRTalk")]
		[Description("Makes A Call To Your Custom Gump.")]
		public static void PRTalk_OnCommand(CommandEventArgs e)
		{
			e.Mobile.SendGump(new Counselor_Talk());
		}

		#region PR_Talk_Context Gump Configuration

		public Counselor_Talk() : base(0, 0)
		{
			Closable = false;
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
			AddLabel(302, 218, 195, @"SHADOWS EDGE ( 2000 - 2011 )");
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
						from.CloseGump(typeof(Counselor_Talk));
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
								if (DateTime.UtcNow >= pm.PromoGiftLast + m_UseDelay)
								{
									from.AddToBackpack(new PromotionalDeed_PR());
									from.CloseGump(typeof(GameMaster_Talk));

									Console.WriteLine("");
									Console.WriteLine("{0} From Account {1} Has Just Redeemed A Monthly Player Server Gift", from.Name, acct.Username);
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

	#endregion
}