using Server.Engines.Quests.Items;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Definitions
{
	public class AmbitiousQueenQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( DontOfferConversation_AmbitiousQueenQuest ),
				typeof( AcceptConversation_AmbitiousQueenQuest ),
				typeof( DuringKillQueensConversation_AmbitiousQueenQuest ),
				typeof( GatherFungiConversation_AmbitiousQueenQuest ),
				typeof( DuringFungiGatheringConversation_AmbitiousQueenQuest ),
				typeof( EndConversation_AmbitiousQueenQuest ),
				typeof( FullBackpackConversation_AmbitiousQueenQuest ),
				typeof( End2Conversation_AmbitiousQueenQuest ),
				typeof( KillQueensObjective_AmbitiousQueenQuest ),
				typeof( ReturnAfterKillsObjective_AmbitiousQueenQuest ),
				typeof( GatherFungiObjective_AmbitiousQueenQuest ),
				typeof( GetRewardObjective_AmbitiousQueenQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				// Ambitious Solen Queen Quest
				1054146;

		public override object OfferMessage =>
				/* <I>The Solen queen considers you eagerly for a moment then says,</I><BR><BR>
* 
* Yes. Yes, I think you could be of use. Normally, of course, I would handle
* these things on my own, but these are busy times. Much to do, much to do.
* And besides, if I am to one day become the Matriarch, then it will be good to
* have experience trusting others to carry out various tasks for me. Yes.<BR><BR>
* 
* That is my plan, you see - I will become the next Matriarch. Our current
* Matriarch is fine and all, but she won't be around forever. And when she steps
* down, I intend to be the next in line. Ruling others is my destiny, you see.<BR><BR>
* 
* What I ask of you is quite simple. First, I need you to remove some of the
* - well - competition, I suppose. Though I dare say most are hardly competent to
* live up to such a title. I'm referring to the other queens of this colony,
* of course. My dear sisters, so to speak. If you could remove 5 of them, I would
* be most pleased. *sighs* By remove, I mean kill them. Don't make that face
* at me - this is how things work in a proper society, and ours has been more proper
* than most since the dawn of time. It's them or me, and whenever I give it
* any thought, I'm quite sure I'd prefer it to be them.<BR><BR>
* 
* I also need you to gather some zoogi fungus for me - 50 should do the trick.<BR><BR>
* 
* Will you accept my offer?
*/
				1054060;

		public override TimeSpan RestartDelay => TimeSpan.Zero;
		public override bool IsTutorial => false;

		public override int Picture => 0x15C9;

		private bool m_RedSolen;

		public bool RedSolen => m_RedSolen;

		public AmbitiousQueenQuest(PlayerMobile from, bool redSolen) : base(from)
		{
			m_RedSolen = redSolen;
		}

		// Serialization
		public AmbitiousQueenQuest()
		{
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_RedSolen = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_RedSolen);
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation(new AcceptConversation_AmbitiousQueenQuest());
		}

		public static void GiveRewardTo(PlayerMobile player, ref bool bagOfSending, ref bool powderOfTranslocation, ref bool gold)
		{
			if (bagOfSending)
			{
				Item reward = new BagOfSending();

				if (player.PlaceInBackpack(reward))
				{
					player.SendLocalizedMessage(1054074, "", 0x59); // You have been given a bag of sending.
					bagOfSending = false;
				}
				else
				{
					reward.Delete();
				}
			}

			if (powderOfTranslocation)
			{
				Item reward = new PowderOfTranslocation(Utility.RandomMinMax(10, 12));

				if (player.PlaceInBackpack(reward))
				{
					player.SendLocalizedMessage(1054075, "", 0x59); // You have been given some powder of translocation.
					powderOfTranslocation = false;
				}
				else
				{
					reward.Delete();
				}
			}

			if (gold)
			{
				Item reward = new Gold(Utility.RandomMinMax(250, 350));

				if (player.PlaceInBackpack(reward))
				{
					player.SendLocalizedMessage(1054076, "", 0x59); // You have been given some gold.
					gold = false;
				}
				else
				{
					reward.Delete();
				}
			}
		}
	}

	#region Conversation

	public class DontOfferConversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen considers you for a moment then says,</I><BR><BR>
* 
* Hmmm... I could perhaps benefit from your assistance, but you seem to be
* busy with another task at the moment. Return to me when you complete whatever
* it is that you're working on and maybe I can still put you to good use.
*/
				1054059;

		public override bool Logged => false;

		public DontOfferConversation_AmbitiousQueenQuest()
		{
		}
	}

	public class AcceptConversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen smiles as you decide to help her.</I><BR><BR>
* 
* Excellent. We'll worry about the zoogi fungus later - start by eliminating
* 5 queens from my colony.<BR><BR>That part's important, by the way; they must
* be queens from my colony. Killing queens from the other solen colony does
* little to help me become Matriarch of this colony and will not count
* toward your task.<BR><BR>
* 
* Oh, and none of those nasty infiltrator queens either. They perform a necessary
* duty, I suppose, spying on the other colony. I fail to see why that couldn't be
* left totally to the warriors, though. Nevertheless, they do not count as well.<BR><BR>
* 
* Very well. Carry on. I'll be waiting for your return.
*/
				1054061;

		public AcceptConversation_AmbitiousQueenQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new KillQueensObjective_AmbitiousQueenQuest());
		}
	}

	public class DuringKillQueensConversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen looks up as you approach.</I><BR><BR>
* 
* You're back, but you have not yet eliminated 5 queens from my colony.
* Return when you have completed this task.<BR><BR>
* 
* Remember, by the way, that queens from the other solen colony and
* infiltrator queens do not count toward your task.<BR><BR>
* 
* Very well. Carry on. I'll be waiting for your return.
*/
				1054066;

		public override bool Logged => false;

		public DuringKillQueensConversation_AmbitiousQueenQuest()
		{
		}
	}

	public class GatherFungiConversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen looks pleased to see you.</I><BR><BR>
* 
* Splendid! You've done quite well in reducing my competition to become
* the next Matriarch. Now I must ask that you gather some zoogi fungus for me.
* I must practice processing it into powder of translocation.<BR><BR>
* 
* I believe the amount we agreed upon earlier was 50. Please return when
* you have that amount and then give them to me.<BR><BR>
* 
* Farewell for now.
*/
				1054068;

		public GatherFungiConversation_AmbitiousQueenQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new GatherFungiObjective_AmbitiousQueenQuest());
		}
	}

	public class DuringFungiGatheringConversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen looks up as you approach.</I><BR><BR>
* 
* Do you have the zoogi fungus?<BR><BR>
* 
* If so, give them to me. Otherwise, go gather some and then return to me.
*/
				1054070;

		public override bool Logged => false;

		public DuringFungiGatheringConversation_AmbitiousQueenQuest()
		{
		}
	}

	public class EndConversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen smiles as she takes the zoogi fungus from you.</I><BR><BR>
* 
* Wonderful! I greatly appreciate your help with these tasks. My plans are beginning
* to take shape ensuring that I will be the next Matriarch. But there is still
* much to be done until then.<BR><BR>
* 
* You've done what I've asked of you and for that I thank you. Please accept this
* bag of sending and some powder of translocation as a reward. Oh, and I suppose
* I should give you some gold as well. Yes, yes. Of course.
*/
				1054073;

		public EndConversation_AmbitiousQueenQuest()
		{
		}

		public override void OnRead()
		{
			var bagOfSending = true;
			var powderOfTranslocation = true;
			var gold = true;

			AmbitiousQueenQuest.GiveRewardTo(System.From, ref bagOfSending, ref powderOfTranslocation, ref gold);

			if (!bagOfSending && !powderOfTranslocation && !gold)
			{
				System.Complete();
			}
			else
			{
				System.AddConversation(new FullBackpackConversation_AmbitiousQueenQuest(true, bagOfSending, powderOfTranslocation, gold));
			}
		}
	}

	public class FullBackpackConversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen looks at you with a smile.</I><BR><BR>
* 
* While I'd like to finish conducting our business, it seems that you're a
* bit overloaded with equipment at the moment.<BR><BR>
* 
* Perhaps you should free some room in your backpack before we proceed.
*/
				1054077;

		private readonly bool m_Logged;
		private bool m_BagOfSending;
		private bool m_PowderOfTranslocation;
		private bool m_Gold;

		public override bool Logged => m_Logged;

		public FullBackpackConversation_AmbitiousQueenQuest(bool logged, bool bagOfSending, bool powderOfTranslocation, bool gold)
		{
			m_Logged = logged;

			m_BagOfSending = bagOfSending;
			m_PowderOfTranslocation = powderOfTranslocation;
			m_Gold = gold;
		}

		public FullBackpackConversation_AmbitiousQueenQuest()
		{
			m_Logged = true;
		}

		public override void OnRead()
		{
			if (m_Logged)
			{
				System.AddObjective(new GetRewardObjective_AmbitiousQueenQuest(m_BagOfSending, m_PowderOfTranslocation, m_Gold));
			}
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_BagOfSending = reader.ReadBool();
			m_PowderOfTranslocation = reader.ReadBool();
			m_Gold = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_BagOfSending);
			writer.Write(m_PowderOfTranslocation);
			writer.Write(m_Gold);
		}
	}

	public class End2Conversation_AmbitiousQueenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen queen looks up as you approach.</I><BR><BR>
* 
* Ah good, you've returned. I will conclude our business by giving you any
* remaining rewards I owe you for aiding me.
*/
				1054078;

		public End2Conversation_AmbitiousQueenQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	#endregion

	#region Objective

	public class KillQueensObjective_AmbitiousQueenQuest : QuestObjective
	{
		public override object Message =>
				// Kill 5 red/black solen queens.
				((AmbitiousQueenQuest)System).RedSolen ? 1054062 : 1054063;

		public override int MaxProgress => 5;

		public KillQueensObjective_AmbitiousQueenQuest()
		{
		}

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				// Red/Black Solen Queens killed:
				gump.AddHtmlLocalized(70, 260, 270, 100, ((AmbitiousQueenQuest)System).RedSolen ? 1054064 : 1054065, BaseQuestGump.Blue, false, false);
				gump.AddLabel(70, 280, 0x64, CurProgress.ToString());
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, MaxProgress.ToString());
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public override bool IgnoreYoungProtection(Mobile from)
		{
			if (Completed)
			{
				return false;
			}

			var redSolen = ((AmbitiousQueenQuest)System).RedSolen;

			if (redSolen)
			{
				return from is RedSolenQueen;
			}
			else
			{
				return from is BlackSolenQueen;
			}
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			var redSolen = ((AmbitiousQueenQuest)System).RedSolen;

			if (redSolen)
			{
				if (creature is RedSolenQueen)
				{
					CurProgress++;
				}
			}
			else
			{
				if (creature is BlackSolenQueen)
				{
					CurProgress++;
				}
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnAfterKillsObjective_AmbitiousQueenQuest());
		}
	}

	public class ReturnAfterKillsObjective_AmbitiousQueenQuest : QuestObjective
	{
		public override object Message =>
				/* You've completed your task of slaying solen queens. Return to
* the ambitious queen who asked for your help.
*/
				1054067;

		public ReturnAfterKillsObjective_AmbitiousQueenQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new GatherFungiConversation_AmbitiousQueenQuest());
		}
	}

	public class GatherFungiObjective_AmbitiousQueenQuest : QuestObjective
	{
		public override object Message =>
				/* Gather zoogi fungus until you have 50 of them, then give them
* to the ambitious queen you are helping.
*/
				1054069;

		public GatherFungiObjective_AmbitiousQueenQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new EndConversation_AmbitiousQueenQuest());
		}
	}

	public class GetRewardObjective_AmbitiousQueenQuest : QuestObjective
	{
		public override object Message =>
				// Return to the ambitious solen queen for your reward.
				1054148;

		private bool m_BagOfSending;
		private bool m_PowderOfTranslocation;
		private bool m_Gold;

		public bool BagOfSending { get => m_BagOfSending; set => m_BagOfSending = value; }
		public bool PowderOfTranslocation { get => m_PowderOfTranslocation; set => m_PowderOfTranslocation = value; }
		public bool Gold { get => m_Gold; set => m_Gold = value; }

		public GetRewardObjective_AmbitiousQueenQuest(bool bagOfSending, bool powderOfTranslocation, bool gold)
		{
			m_BagOfSending = bagOfSending;
			m_PowderOfTranslocation = powderOfTranslocation;
			m_Gold = gold;
		}

		public GetRewardObjective_AmbitiousQueenQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new End2Conversation_AmbitiousQueenQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_BagOfSending = reader.ReadBool();
			m_PowderOfTranslocation = reader.ReadBool();
			m_Gold = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_BagOfSending);
			writer.Write(m_PowderOfTranslocation);
			writer.Write(m_Gold);
		}
	}

	#endregion
}