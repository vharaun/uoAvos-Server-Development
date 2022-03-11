using Server.Engines.Quests.Items;
using Server.Engines.Quests.Mobiles;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Definitions
{
	public class EminosUndertakingQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( AcceptConversation_EminosUndertakingQuest ),
				typeof( FindZoelConversation_EminosUndertakingQuest ),
				typeof( NinjaRadarConversation_EminosUndertakingQuest ),
				typeof( EnterCaveConversation_EminosUndertakingQuest ),
				typeof( SneakPastGuardiansConversation_EminosUndertakingQuest ),
				typeof( NeedToHideConversation_EminosUndertakingQuest ),
				typeof( UseTeleporterConversation_EminosUndertakingQuest ),
				typeof( GiveZoelNoteConversation_EminosUndertakingQuest ),
				typeof( LostNoteConversation_EminosUndertakingQuest ),
				typeof( GainInnInformationConversation_EminosUndertakingQuest ),
				typeof( ReturnFromInnConversation_EminosUndertakingQuest ),
				typeof( SearchForSwordConversation_EminosUndertakingQuest ),
				typeof( HallwayWalkConversation_EminosUndertakingQuest ),
				typeof( ReturnSwordConversation_EminosUndertakingQuest ),
				typeof( SlayHenchmenConversation_EminosUndertakingQuest ),
				typeof( ContinueSlayHenchmenConversation_EminosUndertakingQuest ),
				typeof( GiveEminoSwordConversation_EminosUndertakingQuest ),
				typeof( LostSwordConversation_EminosUndertakingQuest ),
				typeof( EarnGiftsConversation_EminosUndertakingQuest ),
				typeof( EarnLessGiftsConversation_EminosUndertakingQuest ),
				typeof( FindEminoBeginObjective_EminosUndertakingQuest ),
				typeof( FindZoelObjective_EminosUndertakingQuest ),
				typeof( EnterCaveObjective_EminosUndertakingQuest ),
				typeof( SneakPastGuardiansObjective_EminosUndertakingQuest ),
				typeof( UseTeleporterObjective_EminosUndertakingQuest ),
				typeof( GiveZoelNoteObjective_EminosUndertakingQuest ),
				typeof( GainInnInformationObjective_EminosUndertakingQuest ),
				typeof( ReturnFromInnObjective_EminosUndertakingQuest ),
				typeof( SearchForSwordObjective_EminosUndertakingQuest ),
				typeof( HallwayWalkObjective_EminosUndertakingQuest ),
				typeof( ReturnSwordObjective_EminosUndertakingQuest ),
				typeof( SlayHenchmenObjective_EminosUndertakingQuest ),
				typeof( GiveEminoSwordObjective_EminosUndertakingQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				// Emino's Undertaking
				1063173;

		public override object OfferMessage =>
				// Your value as a Ninja must be proven. Find Daimyo Emino and accept the test he offers.
				1063174;

		public override TimeSpan RestartDelay => TimeSpan.MaxValue;
		public override bool IsTutorial => true;

		public override int Picture => 0x15D5;

		public EminosUndertakingQuest(PlayerMobile from) : base(from)
		{
		}

		// Serialization
		public EminosUndertakingQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation(new AcceptConversation_EminosUndertakingQuest());
		}

		private bool m_SentRadarConversion;

		public override void Slice()
		{
			if (!m_SentRadarConversion && (From.Map != Map.Malas || From.X < 407 || From.X > 431 || From.Y < 801 || From.Y > 830))
			{
				m_SentRadarConversion = true;
				AddConversation(new NinjaRadarConversation_EminosUndertakingQuest());
			}

			base.Slice();
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_SentRadarConversion = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_SentRadarConversion);
		}

		public static bool HasLostNoteForZoel(Mobile from)
		{
			var pm = from as PlayerMobile;

			if (pm == null)
			{
				return false;
			}

			var qs = pm.Quest;

			if (qs is EminosUndertakingQuest)
			{
				if (qs.IsObjectiveInProgress(typeof(GiveZoelNoteObjective_EminosUndertakingQuest)))
				{
					var pack = from.Backpack;

					return (pack == null || pack.FindItemByType(typeof(NoteForZoel)) == null);
				}
			}

			return false;
		}

		public static bool HasLostEminosKatana(Mobile from)
		{
			var pm = from as PlayerMobile;

			if (pm == null)
			{
				return false;
			}

			var qs = pm.Quest;

			if (qs is EminosUndertakingQuest)
			{
				if (qs.IsObjectiveInProgress(typeof(GiveEminoSwordObjective_EminosUndertakingQuest)))
				{
					var pack = from.Backpack;

					return (pack == null || pack.FindItemByType(typeof(EminosKatana)) == null);
				}
			}

			return false;
		}
	}

	#region Conversation

	public class AcceptConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* <I><U>Important Quest Information</U></I><BR><BR>
* 
* During your quest, any important information that a
* <a href = "?ForceTopic31">NPC</a> gives you, will appear in a
* window such as this one.  You can review the information at
* any time during your quest.<BR><BR><U>Getting Help</U><BR><BR>
* 
* Some of the text you will come across during your quest, will
* be underlined <a href = "?ForceTopic73">links to the codex of
* wisdom</a>, or online help system.  You can click on the text
* to get detailed information on the underlined subject.  You
* may also access the Codex Of Wisdom by pressing "F1" or by
* clicking on the "?" on the toolbar at the top of your screen.<BR><BR>
* 
* <U>Context Menus</U><BR><BR>Context menus can be called up by
* single left-clicking (or Shift + single left-click, if you
* changed it) on most objects or NPCs in the world.  Nearly
* everything, including your own avatar will have context menus
* available.  Bringing up your avatar's context menu will give
* you options to cancel your quest and review various quest
* information.<BR><BR>
*/
				1049092;

		public AcceptConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindEminoBeginObjective_EminosUndertakingQuest());
		}
	}

	public class FindZoelConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* Ah, another fledgling unfurls its wings. Welcome to my 
* home young one. <BR><BR>
* 
* I am Daimyo Emino, a passionate collector of sorts. 
* One who is vengeful towards those impeding my reign. <BR><BR>
* 
* You have the look of someone who could help me but 
* your skills are untested. Are you willing to prove 
* your mettle as my hireling? <BR><BR>
* 
* Elite Ninja Zoel awaits you in the backyard. He will 
* lead you to the first trial. You will be directed 
* further when you arrive at your destination. You 
* should speak to him before exploring the yard or cave entrance.
*/
				1063175;

		public FindZoelConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindZoelObjective_EminosUndertakingQuest());
		}
	}

	public class NinjaRadarConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* To view the surrounding area, you should learn about the Radar Map.<BR><BR>
* 
* The Radar Map (or Overhead View) can be opened by pressing 'ALT-R'
* on your keyboard. It shows your immediate surroundings from a
* bird's eye view.<BR><BR>
* 
* Pressing ALT-R twice, will enlarge the Radar Map a little.
* Use the Radar Map often as you travel throughout the world
* to familiarize yourself with your surroundings.
* */
				1063033;

		public override bool Logged => false;

		public NinjaRadarConversation_EminosUndertakingQuest()
		{
		}
	}

	public class EnterCaveConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Zoel studies your face as you approach him. Wryly, he says:</I><BR><BR>
* 
* Daimyo Emino has sent another already? The stains from the 
* last have not yet dried! <BR><BR>
* 
* No matter, we’ll finish you off and clean it all at once, eh? <BR><BR>
* 
* Now to the point, your only task is to survive in the abandoned inn.<BR><BR>
* 
* You will be instructed when you need to act and when you should 
* return to one of us. <BR><BR>
* 
* Only a true Ninja is deft enough to finish and remain alive.<BR><BR>
* 
* Your future... or your demise... lies in this cave beyond. <BR><BR>
* 
* Now go.
*/
				1063177;

		public EnterCaveConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new EnterCaveObjective_EminosUndertakingQuest());
		}
	}

	public class SneakPastGuardiansConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* A glowing archway stands before you. <BR><BR>
* 
* To either side of its frame are mounted demon heads, 
* breathing fire and watching your every move. <BR><BR>
* 
* To pass through, you must first vanish from the demons’ 
* sight. Only then can you slowly traverse the entryway.
*/
				1063180;

		public SneakPastGuardiansConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SneakPastGuardiansObjective_EminosUndertakingQuest());
		}
	}

	public class NeedToHideConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* You’ll need to hide in order to pass through the door. <BR><BR>
* 
* To find out how to use active skills, visit the 
* <a href = "?ForceTopic73">Codex of Wisdom</a>. 
* To activate a skill, locate it on your skills 
* list and click the blue button located to the 
* left of the skill's name.<br><br>Once you have 
* successfully hidden, you may move slowly through the door.
* 
*/
				1063181;

		public NeedToHideConversation_EminosUndertakingQuest()
		{
		}
	}

	public class UseTeleporterConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/*
* Through the door lies a short passageway. 
* The path ends abruptly at a strange tile on the floor.  
* The special tile is known as a teleporter.  
* Step on the teleporter tile and you will be transported 
* to a new location.
*/
				1063182;

		public UseTeleporterConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new UseTeleporterObjective_EminosUndertakingQuest());
		}
	}

	public class GiveZoelNoteConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Daimyo Emino smiles as you approach him:</I> <BR><BR>
* 
* I see that you have survived both the first trial and Zoel’s temper. <BR><BR>
* 
* For that you have been rewarded with Leggings and Gloves
* befitting your occupation. The material is the only armor
* a <b><I>True Ninja</i></b> needs. <BR><BR>
* 
* You have yet to prove yourself fully, young hireling. 
* Another trial must be met. Off to Zoel you go. 
* Bring him this note so he knows we have spoken.
*/
				1063184;

		public GiveZoelNoteConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new GiveZoelNoteObjective_EminosUndertakingQuest());
		}
	}

	public class LostNoteConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				// You have lost my note? I will scribe another for you. Try not to lose this one.
				1063187;

		public override bool Logged => false;

		public LostNoteConversation_EminosUndertakingQuest()
		{
		}
	}

	public class GainInnInformationConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Zoel quickly grabs the scroll from your
* hand and reads the note:</i> <BR><BR>
* 
* Still alive then? You’ll have to impress me 
* further before I will give my approval of 
* you to Daimyo Emino. <BR><BR>
* 
* You must return to the inn and begin the next trial. <BR><BR>
* 
* We believe an associate has, shall we say, 
* inadvertently negated our contract. <BR><BR>
* 
* Find out what information you can and return
* to Daimyo Emino with the news. And be careful
* not to lose your head.<BR><BR>
* 
* The Blue Teleporter Tile in Daimyo Emino’s
* residence will lead you to your fate. 
* I suggest you hurry. <BR><BR>
* 
* ...And take care to tread softly. There
* is no greater traitor than a heavy footfall upon a path.
*/
				1063189;

		public GainInnInformationConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new GainInnInformationObjective_EminosUndertakingQuest());
		}
	}

	public class ReturnFromInnConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* You quietly approach the door and see 
* a woman named Jedah Entille speaking 
* to a shady figure in dark clothing. 
* You move closer so you can overhear 
* the conversation. Fortunately, your 
* entrance did not alert the preoccupied party. <BR><BR>
* 
* Jedah’s brash voice permeates the air:<I><BR><BR> 
* 
* Now that it is hidden, we’ll hide out here 
* until Daimyo Emino forgets about us. 
* Once he realizes his beloved sword is missing, 
* he’ll surely start looking for the thieves. 
* We will be long gone by that time. </I><BR><BR>
* 
* After overhearing the conversation, 
* you understand why you were sent on 
* this trial. You must immediately tell 
* Daimyo Emino what you have learned.
* */
				1063196;

		public ReturnFromInnConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ReturnFromInnObjective_EminosUndertakingQuest());
		}
	}

	public class SearchForSwordConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Daimyo Emino frowns as you relay the information. 
* He pauses for a moment before speaking to you:</i> <BR><BR>
* 
* Jedah was once one of my most promising students, 
* but her greed will be her downfall. <BR><BR>
* 
* I will send one of my disciples to deal with her later. 
* It is more important to get that sword back first. <BR><BR>
* 
* I’m counting on you to find it. She would have kept it 
* close to her. Take the White Teleporter, located in my 
* backyard, and check inside boxes and chests around the 
* treasure room of the inn and return it to me when you 
* find it.<BR><BR>
* 
* Be very careful. Jedah was an expert with traps and no 
* doubt she’s protecting the sword with them. <BR><BR>
* 
* If you find a trap, try timing it and you may be able 
* to avoid damage. <BR><BR>
* 
* I’ve provided you with several heal potions in case you 
* become injured. <BR><BR>
* 
* In the bag you will also find more clothing appropriate 
* to your new found profession. <BR><BR>
* 
* Please return the sword to me. I implore you not to take 
* anything else that may be hidden in the Inn. <BR><BR>
* 
* Thank you.
*/
				1063199;

		public SearchForSwordConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SearchForSwordObjective_EminosUndertakingQuest());
		}
	}

	public class HallwayWalkConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* A narrow hallway greets the teleporter. 
* The enclosed space is the perfect setting 
* for dangerous traps. Walk through the 
* hallway being careful to avoid the traps. 
* You may be able to time the traps to avoid injury.
*/
				1063201;

		public HallwayWalkConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new HallwayWalkObjective_EminosUndertakingQuest());
		}
	}

	public class ReturnSwordConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* The lid of the chest refuses to budge at first, 
* but slowly you are able to pry the lid open. <BR><BR>
* 
* Inside lies the sword you have been in search of.  
* You quickly take the sword and stash it in your backpack.  
* Bring the sword back to Daimyo Emino.
*/
				1063203;

		public ReturnSwordConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ReturnSwordObjective_EminosUndertakingQuest());
		}
	}

	public class SlayHenchmenConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* Screams echo through the chamber as you walk 
* away from the chest. Jedah’s Henchmen have 
* become cognizant of your presence. <BR><BR>
* 
* It is time for your Ninja Spirit to come alive. 
* Slay 3 of the Henchmen before returning to Daimyo Emino. 
*/
				1063205;

		public SlayHenchmenConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SlayHenchmenObjective_EminosUndertakingQuest());
		}
	}

	public class ContinueSlayHenchmenConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				// Continue killing the henchmen!
				1063208;

		public override bool Logged => false;

		public ContinueSlayHenchmenConversation_EminosUndertakingQuest()
		{
		}
	}

	public class GiveEminoSwordConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* Go to Daimyo Emino. Go back through the chamber the way you came.<BR><BR>
* 
* Give Daimyo Emino the sword when you've returned to his side.
*/
				1063211;

		public GiveEminoSwordConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new GiveEminoSwordObjective_EminosUndertakingQuest());
		}
	}

	public class LostSwordConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				// What? You have returned without the sword? You need to go back and get it again!
				1063212;

		public override bool Logged => false;

		public LostSwordConversation_EminosUndertakingQuest()
		{
		}
	}

	public class EarnGiftsConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* Beyond this path lies Zento City, your future home.
* To the right of the cave entrance you will find a luminous oval
* object known as a Moongate, step through it and you'll
* find yourself in Zento.<BR><BR>
* 
* You may want to visit Ansella Gryen when you arrive. <BR><BR>
* 
* Please accept the gifts I have placed in your pack. You
* have earned them. Farewell for now.
*/
				1063216;

		public EarnGiftsConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	public class EarnLessGiftsConversation_EminosUndertakingQuest : QuestConversation
	{
		public override object Message =>
				/* You have earned these gifts for returning the sword.
* For that I thank you. <BR><BR>
* 
* However, your reward has been lessened by your greed
* in the treasure room.  Do not think I did not notice your full pockets.
*/
				1063217;

		public EarnLessGiftsConversation_EminosUndertakingQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	#endregion

	#region Objective

	public class FindEminoBeginObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				// Your value as a Ninja must be proven. Find Daimyo Emino and accept the test he offers.
				1063174;

		public FindEminoBeginObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new FindZoelConversation_EminosUndertakingQuest());
		}
	}

	public class FindZoelObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				// Find Elite Ninja Zoel immediately!
				1063176;

		public FindZoelObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new EnterCaveConversation_EminosUndertakingQuest());
		}
	}

	public class EnterCaveObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				// Enter the cave and walk through it. You will be tested as you travel along the path.
				1063179;

		public EnterCaveObjective_EminosUndertakingQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(406, 1141, 0), 2))
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new SneakPastGuardiansConversation_EminosUndertakingQuest());
		}
	}

	public class SneakPastGuardiansObjective_EminosUndertakingQuest : QuestObjective
	{
		private bool m_TaughtHowToUseSkills;

		public bool TaughtHowToUseSkills
		{
			get => m_TaughtHowToUseSkills;
			set => m_TaughtHowToUseSkills = value;
		}

		public override object Message =>
				// Use your Ninja training to move invisibly past the magical guardians.
				1063261;

		public SneakPastGuardiansObjective_EminosUndertakingQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(412, 1123, 0), 3))
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new UseTeleporterConversation_EminosUndertakingQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_TaughtHowToUseSkills = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_TaughtHowToUseSkills);
		}
	}

	public class UseTeleporterObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				/* The special tile is known as a teleporter.
* Step on the teleporter tile and you will be transported to a new location.
*/
				1063183;

		public UseTeleporterObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new GiveZoelNoteConversation_EminosUndertakingQuest());
		}
	}

	public class GiveZoelNoteObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				/* Bring the note to Elite Ninja Zoel and speak with him again. 
* He is near the cave entrance. You can hand the note to Zoel 
* by dragging it and dropping it on his body.
*/
				1063185;

		public GiveZoelNoteObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new GainInnInformationConversation_EminosUndertakingQuest());
		}
	}

	public class GainInnInformationObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				/* Take the Blue Teleporter Tile from Daimyo Emino's
* house to the Abandoned Inn. Quietly look around
* to gain information.
*/
				1063190;

		public GainInnInformationObjective_EminosUndertakingQuest()
		{
		}

		public override void CheckProgress()
		{
			Mobile from = System.From;

			if (from.Map == Map.Malas && from.X > 399 && from.X < 408 && from.Y > 1091 && from.Y < 1099)
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new ReturnFromInnConversation_EminosUndertakingQuest());
		}
	}

	public class ReturnFromInnObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				// Go back through the blue teleporter and tell Daimyo Emino what you’ve overheard.
				1063197;

		public ReturnFromInnObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new SearchForSwordConversation_EminosUndertakingQuest());
		}
	}

	public class SearchForSwordObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				/* Take the white teleporter and check the chests for the sword. 
* Leave everything else behind. Avoid damage from traps you may 
* encounter. To use a potion, make sure at least one hand is 
* free and double click on the bottle.
*/
				1063200;

		public SearchForSwordObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new HallwayWalkConversation_EminosUndertakingQuest());
		}
	}

	public class HallwayWalkObjective_EminosUndertakingQuest : QuestObjective
	{
		private bool m_StolenTreasure;

		public bool StolenTreasure
		{
			get => m_StolenTreasure;
			set => m_StolenTreasure = value;
		}

		public override object Message =>
				/* Walk through the hallway being careful 
* to avoid the traps. You may be able to 
* time the traps to avoid injury.
*/
				1063202;

		public HallwayWalkObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ReturnSwordConversation_EminosUndertakingQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_StolenTreasure = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_StolenTreasure);
		}
	}

	public class ReturnSwordObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				// Take the sword and bring it back to Daimyo Emino.
				1063204;

		public ReturnSwordObjective_EminosUndertakingQuest()
		{
		}

		public override void CheckProgress()
		{
			Mobile from = System.From;

			if (from.Map != Map.Malas || from.Y > 992)
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new SlayHenchmenConversation_EminosUndertakingQuest());
		}
	}

	public class SlayHenchmenObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				// Kill three henchmen.
				1063206;

		public SlayHenchmenObjective_EminosUndertakingQuest()
		{
		}

		public override int MaxProgress => 3;

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				// Henchmen killed:
				gump.AddHtmlLocalized(70, 260, 270, 100, 1063207, BaseQuestGump.Blue, false, false);
				gump.AddLabel(70, 280, 0x64, CurProgress.ToString());
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, MaxProgress.ToString());
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is Henchman)
			{
				CurProgress++;
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new GiveEminoSwordConversation_EminosUndertakingQuest());
		}
	}

	public class GiveEminoSwordObjective_EminosUndertakingQuest : QuestObjective
	{
		public override object Message =>
				/* You have proven your fighting skills. Bring the Sword to
* Daimyo Emino immediately. Be sure to follow the
* path back to the teleporter.
*/
				1063210;

		public GiveEminoSwordObjective_EminosUndertakingQuest()
		{
		}

		public override void OnComplete()
		{
		}
	}

	#endregion
}