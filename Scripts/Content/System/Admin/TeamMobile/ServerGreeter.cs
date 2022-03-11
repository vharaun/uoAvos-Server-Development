using Server.ContextMenus;
using Server.Items;
using Server.Items.Staff;

using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class ServerGreeter : BaseGuildmaster
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override bool ClickTitle => false;
		public override NpcGuild NpcGuild => NpcGuild.BardsGuild;

		#region Automated Greetings For All Approaching Players

		private static bool m_Talked;
		private readonly string[] npcSpeech = new string[]
		{
			"Trash Bags For Sale!",
		};

		#endregion Edited By: A.A.R

		[Constructable]
		public ServerGreeter() : base("merchant")
		{

			//----------This Randomizes The Sex Of The NPC For Individuality---------//

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

			//--------This Creates A Random Look To The NPC For Individuality--------//

			Title = "[SG]";
			NameHue = 11;

			VendorAccessLevel = AccessLevel.Player;
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

			//-------------This Toggles The NPC Movement: On Or Off------------------//

			CantWalk = true;
			CanSwim = false;

			//--------------This Makes The NPC Equip HandHeld Items------------------//

			switch (Utility.Random(3))
			{
				case 0: AddItem(new BookOfNinjitsu()); break;
				case 1: AddItem(new BookOfBushido()); break;
				case 2: AddItem(new BookOfChivalry()); break;
			}

			//-------------This Sets What Clothes The NPC Will Wear------------------//

			AddItem(new ShortPants(Utility.RandomNeutralHue()));
			AddItem(new Shirt(Utility.RandomNeutralHue()));
			AddItem(new Sandals(Utility.RandomNeutralHue()));
		}

		//------This Gives The NPC Some Active Emotion In The Game---------------//

		public void Emote()
		{
			switch (Utility.Random(3))
			{
				case 0:
					PlaySound(Female ? 785 : 1056);
					Say("*cough!*");
					break;
				case 1:
					PlaySound(Female ? 818 : 1092);
					Say("*sniff*");
					break;
				default:
					break;
			}
		}

		//------This Code Makes This NPC Behave As An AccessLevel Vendor---------//

		public override bool IsActiveVendor => true;

		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBServerGreeter());
		}

		//------Automated Greeting Timer For All Approaching Players-------------//

		public override void OnMovement(Mobile m, Point3D oldLocation)
		{
			if (m_Talked == false)
			{
				if (m.InRange(this, 4))
				{
					m_Talked = true;
					SayRandom(npcSpeech, this);
					Move(GetDirectionTo(m.Location));

					var t = new SpamTimer();
					t.Start();
				}
			}
		}

		private class SpamTimer : Timer
		{
			public SpamTimer() : base(TimeSpan.FromSeconds(20))
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

		//-----Server Players Get Jailed For Saying Inappropriate Words----------//

		#region Unacceptable Player Speech

		public override bool HandlesOnSpeech(Mobile from)
		{
			if (from.InRange(Location, 5))
			{
				return true;
			}

			return base.HandlesOnSpeech(from);
		}

		private readonly List<string> m_UnacceptableWords = new List<string>(new string[]
		{
            #region Prohibited Word List

            "ass","asshole","blowjob","bitch","bitches","biatch","biatches","breasts","chinc","chink","cunnilingus","cum","cumstain","cocksucker","clit",
			"chigaboo","cunt","clitoris","cock","dick","dickhead","dyke","dildo","fuck","fucktard","felatio","fag","faggot","hitler","jigaboo","jizzm",
			"jizz","jiz","jism","jiss","jis","jerkoff","jackoff", "kyke","kike","klit","lezbo","lesbo","nigga","niggas","nigger","piss","penis","prick",
			"pussy","retard","retarded","spic","shit","shithead","spunk","spunker","smeg","smegg","twat","tit","tits","titties", "tittys","titie","tities",
			"tity","tard","vagina","wop","wigger","wiger"

            #endregion Edited By: A.A.R
        });

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
				#region Location To Send Players If They Say Unacceptable Words

				from.MoveToWorld(new Point3D(1483, 1617, 20), Map.Trammel);

				#endregion Edited By: A.A.R

				from.SendMessage("You Have Been Jailed For Using Inappropriate Language And/Or Out Of Character, Real-World, References In Front Of A Staff Member");
				return;
			}
		}

		#endregion Edited By: Morxeton

		//-----NPC Talk Context Menu Selection On The Mobile For Tips------------//

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);
			list.Add(new GameMaster_Entry(from, this));
		}

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

		//------------------------------------------------------------------------//

		public ServerGreeter(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version 0      
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}

	public class SBServerGreeter : SBInfo
	{
		private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBServerGreeter()
		{
		}

		public override IShopSellInfo SellInfo => m_SellInfo;
		public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add(new GenericBuyInfo(typeof(RobeOfEntitlement), 0, 20, 0x2683, 0));
				Add(new GenericBuyInfo(typeof(CommUnit), 0, 20, 0x1F07, 0));
				Add(new GenericBuyInfo(typeof(StaffOfAnnulment), 0, 20, 0x13F8, 0));
				Add(new GenericBuyInfo(typeof(LensesOfResist), 0, 20, 0x2FB8, 0));
				Add(new GenericBuyInfo(typeof(CollarOfVisibility), 0, 20, 0x1F08, 0));
				Add(new GenericBuyInfo(typeof(RingOfReduction), 0, 20, 0x1F09, 0));
				Add(new GenericBuyInfo(typeof(BraceletOfEthics), 0, 20, 0x1F06, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add(typeof(RobeOfEntitlement), 0);
				Add(typeof(CommUnit), 0);
				Add(typeof(StaffOfAnnulment), 0);
				Add(typeof(LensesOfResist), 0);
				Add(typeof(CollarOfVisibility), 0);
				Add(typeof(RingOfReduction), 0);
				Add(typeof(BraceletOfEthics), 0);
			}
		}
	}
}