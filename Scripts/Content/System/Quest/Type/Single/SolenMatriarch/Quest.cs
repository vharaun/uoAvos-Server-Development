using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Definitions
{
	public class SolenMatriarchQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( DontOfferConversation_SolenMatriarchQuest ),
				typeof( AcceptConversation_SolenMatriarchQuest ),
				typeof( DuringKillInfiltratorsConversation_SolenMatriarchQuest ),
				typeof( GatherWaterConversation_SolenMatriarchQuest ),
				typeof( DuringWaterGatheringConversation_SolenMatriarchQuest ),
				typeof( ProcessFungiConversation_SolenMatriarchQuest ),
				typeof( DuringFungiProcessConversation_SolenMatriarchQuest ),
				typeof( FullBackpackConversation_SolenMatriarchQuest ),
				typeof( EndConversation_SolenMatriarchQuest ),
				typeof( KillInfiltratorsObjective_SolenMatriarchQuest ),
				typeof( ReturnAfterKillsObjective_SolenMatriarchQuest ),
				typeof( GatherWaterObjective_SolenMatriarchQuest ),
				typeof( ReturnAfterWaterObjective_SolenMatriarchQuest ),
				typeof( ProcessFungiObjective_SolenMatriarchQuest ),
				typeof( GetRewardObjective_SolenMatriarchQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				// Solen Matriarch Quest
				1054147;

		public override object OfferMessage
		{
			get
			{
				if (IsFriend(From, RedSolen))
				{
					/* <I>The Solen Matriarch smiles happily as you greet her.</I><BR><BR>
					 * 
					 * Hello again. It is always good to see a friend of our colony.<BR><BR>
					 * 
					 * Would you like me to process some zoogi fungus into powder of translocation
					 * for you? I would be happy to do so if you will first undertake a couple
					 * tasks for me.<BR><BR>
					 * 
					 * First, I would like for you to eliminate some infiltrators from the other
					 * solen colony. They are spying on my colony, and I fear for the safety of my
					 * people. They must be slain.<BR><BR>
					 * 
					 * After that, I must ask that you gather some water for me. Our water supplies
					 * are inadequate, so we must try to supplement our reserve using water vats here
					 * in our lair.<BR><BR>
					 * 
					 * Will you accept my offer?
					 */
					return 1054083;
				}
				else
				{
					/* <I>The Solen Matriarch smiles happily as she eats the seed you offered.</I><BR><BR>
					 * 
					 * I think you for that seed. I was quite delicious. So full of flavor.<BR><BR>
					 * 
					 * Hmm... if you would like, I could make you a friend of my colony. This would stop
					 * the warriors, workers, and queens of my colony from thinking you are an intruder,
					 * thus they would not attack you. In addition, as a friend of my colony I will process
					 * zoogi fungus into powder of translocation for you.<BR><BR>
					 * 
					 * To become a friend of my colony, I ask that you complete a couple tasks for me. These
					 * are the same tasks I will ask of you when you wish me to process zoogi fungus,
					 * by the way.<BR><BR>
					 * 
					 * First, I would like for you to eliminate some infiltrators from the other solen colony.
					 * They are spying on my colony, and I fear for the safety of my people. They must
					 * be slain.<BR><BR>
					 * 
					 * After that, I must ask that you gather some water for me. Our water supplies are
					 * inadequate, so we must try to supplement our reserve using water vats here in our
					 * lair.<BR><BR>
					 * 
					 * Will you accept my offer?
					 */
					return 1054082;
				}
			}
		}

		public override TimeSpan RestartDelay => TimeSpan.Zero;
		public override bool IsTutorial => false;

		public override int Picture => 0x15C9;

		private bool m_RedSolen;

		public bool RedSolen => m_RedSolen;

		public SolenMatriarchQuest(PlayerMobile from, bool redSolen) : base(from)
		{
			m_RedSolen = redSolen;
		}

		// Serialization
		public SolenMatriarchQuest()
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

			AddConversation(new AcceptConversation_SolenMatriarchQuest());
		}

		public static bool IsFriend(PlayerMobile player, bool redSolen)
		{
			if (redSolen)
			{
				return player.SolenFriendship == SolenFriendship.Red;
			}
			else
			{
				return player.SolenFriendship == SolenFriendship.Black;
			}
		}

		public static bool GiveRewardTo(PlayerMobile player)
		{
			var gold = new Gold(Utility.RandomMinMax(250, 350));

			if (player.PlaceInBackpack(gold))
			{
				player.SendLocalizedMessage(1054076); // You have been given some gold.
				return true;
			}
			else
			{
				gold.Delete();
				return false;
			}
		}
	}

	#region Conversation

	public class DontOfferConversation_SolenMatriarchQuest : QuestConversation
	{
		private bool m_Friend;

		public override object Message
		{
			get
			{
				if (m_Friend)
				{
					/* <I>The Solen Matriarch smiles as you greet her.</I><BR><BR>
					 * 
					 * It is good to see you again. I would offer to process some zoogi fungus for you,
					 * but you seem to be busy with another task at the moment. Perhaps you should
					 * finish whatever is occupying your attention at the moment and return to me once
					 * you're done.
					 */
					return 1054081;
				}
				else
				{
					/* <I>The Solen Matriarch smiles as she eats the seed you offered.</I><BR><BR>
					 * 
					 * Thank you for that seed. It was quite delicious.  <BR><BR>
					 * 
					 * I would offer to make you a friend of my colony, but you seem to be busy with
					 * another task at the moment. Perhaps you should finish whatever is occupying
					 * your attention at the moment and return to me once you're done.
					 */
					return 1054079;
				}
			}
		}

		public override bool Logged => false;

		public DontOfferConversation_SolenMatriarchQuest(bool friend)
		{
			m_Friend = friend;
		}

		public DontOfferConversation_SolenMatriarchQuest()
		{
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_Friend = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Friend);
		}
	}

	public class AcceptConversation_SolenMatriarchQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen Matriarch looks pleased that you've accepted.</I><BR><BR>
* 
* Very good. Please start by hunting some infiltrators from the other solen
* colony and eliminating them. Slay 7 of them and then return to me.<BR><BR>
* 
* Farewell for now and good hunting.
*/
				1054084;

		public AcceptConversation_SolenMatriarchQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new KillInfiltratorsObjective_SolenMatriarchQuest());
		}
	}

	public class DuringKillInfiltratorsConversation_SolenMatriarchQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen Matriarch looks up as you approach.</I><BR><BR>
* 
* You're back, but you have not yet eliminated 7 infiltrators from the enemy
* colony. Return when you have completed this task.<BR><BR>
* 
* Carry on. I'll be waiting for your return.
*/
				1054089;

		public override bool Logged => false;

		public DuringKillInfiltratorsConversation_SolenMatriarchQuest()
		{
		}
	}

	public class GatherWaterConversation_SolenMatriarchQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen Matriarch nods favorably as you approach her.</I><BR><BR>
* 
* Marvelous! I'm impressed at your ability to hunt and kill enemies for me.
* My colony is thankful.<BR><BR>
* 
* Now I must ask that you gather some water for me. A standard pitcher of water
* holds approximately one gallon. Please decant 8 gallons of fresh water
* into our water vats.<BR><BR>
* 
* Farewell for now.
*/
				1054091;

		public GatherWaterConversation_SolenMatriarchQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new GatherWaterObjective_SolenMatriarchQuest());
		}
	}

	public class DuringWaterGatheringConversation_SolenMatriarchQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen Matriarch looks up as you approach.</I><BR><BR>
* 
* You're back, but you have not yet gathered 8 gallons of water. Return when
* you have completed this task.<BR><BR>
* 
* Carry on. I'll be waiting for your return.
*/
				1054094;

		public override bool Logged => false;

		public DuringWaterGatheringConversation_SolenMatriarchQuest()
		{
		}
	}

	public class ProcessFungiConversation_SolenMatriarchQuest : QuestConversation
	{
		private bool m_Friend;

		public override object Message
		{
			get
			{
				if (m_Friend)
				{
					/* <I>The Solen Matriarch listens as you report the completion of your
					 * tasks to her.</I><BR><BR>
					 * 
					 * I give you my thanks for your help, and I will gladly process some zoogi
					 * fungus into powder of translocation for you. Two of the zoogi fungi are
					 * required for each measure of the powder. I will process up to 200 zoogi fungi
					 * into 100 measures of powder of translocation.<BR><BR>
					 * 
					 * I will also give you some gold for assisting me and my colony, but first let's
					 * take care of your zoogi fungus.
					 */
					return 1054097;
				}
				else
				{
					/* <I>The Solen Matriarch listens as you report the completion of your
					 * tasks to her.</I><BR><BR>
					 * 
					 * I give you my thanks for your help, and I will gladly make you a friend of my
					 * solen colony. My warriors, workers, and queens will not longer look at you
					 * as an intruder and attack you when you enter our lair.<BR><BR>
					 * 
					 * I will also process some zoogi fungus into powder of translocation for you.
					 * Two of the zoogi fungi are required for each measure of the powder. I will
					 * process up to 200 zoogi fungi into 100 measures of powder of translocation.<BR><BR>
					 * 
					 * I will also give you some gold for assisting me and my colony, but first let's
					 * take care of your zoogi fungus.
					 */
					return 1054096;
				}
			}
		}

		public ProcessFungiConversation_SolenMatriarchQuest(bool friend)
		{
			m_Friend = friend;
		}

		public override void OnRead()
		{
			System.AddObjective(new ProcessFungiObjective_SolenMatriarchQuest());
		}

		public ProcessFungiConversation_SolenMatriarchQuest()
		{
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_Friend = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Friend);
		}
	}

	public class DuringFungiProcessConversation_SolenMatriarchQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen Matriarch smiles as you greet her.</I><BR><BR>
* 
* I will gladly process some zoogi fungus into powder of translocation for you.
* Two of the zoogi fungi are required for each measure of the powder.
* I will process up to 200 zoogi fungi into 100 measures of powder of translocation.
*/
				1054099;

		public override bool Logged => false;

		public DuringFungiProcessConversation_SolenMatriarchQuest()
		{
		}
	}

	public class FullBackpackConversation_SolenMatriarchQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen Matriarch looks at you with a smile.</I><BR><BR>
* 
* While I'd like to finish conducting our business, it seems that you're a
* bit overloaded with equipment at the moment.<BR><BR>
* 
* Perhaps you should free some room in your backpack before we proceed.
*/
				1054102;

		private readonly bool m_Logged;

		public override bool Logged => m_Logged;

		public FullBackpackConversation_SolenMatriarchQuest(bool logged)
		{
			m_Logged = logged;
		}

		public FullBackpackConversation_SolenMatriarchQuest()
		{
			m_Logged = true;
		}

		public override void OnRead()
		{
			if (m_Logged)
			{
				System.AddObjective(new GetRewardObjective_SolenMatriarchQuest());
			}
		}
	}

	public class EndConversation_SolenMatriarchQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Solen Matriarch smiles as you greet her.</I><BR><BR>
* 
* Ah good, you've returned. I will conclude our business by giving you
* gold I owe you for aiding me.
*/
				1054101;

		public EndConversation_SolenMatriarchQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	#endregion

	#region Objective

	public class KillInfiltratorsObjective_SolenMatriarchQuest : QuestObjective
	{
		public override object Message =>
				// Kill 7 black/red solen infiltrators.
				((SolenMatriarchQuest)System).RedSolen ? 1054086 : 1054085;

		public override int MaxProgress => 7;

		public KillInfiltratorsObjective_SolenMatriarchQuest()
		{
		}

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				// Black/Red Solen Infiltrators killed:
				gump.AddHtmlLocalized(70, 260, 270, 100, ((SolenMatriarchQuest)System).RedSolen ? 1054088 : 1054087, BaseQuestGump.Blue, false, false);
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

			var redSolen = ((SolenMatriarchQuest)System).RedSolen;

			if (redSolen)
			{
				return from is BlackSolenInfiltratorWarrior || from is BlackSolenInfiltratorQueen;
			}
			else
			{
				return from is RedSolenInfiltratorWarrior || from is RedSolenInfiltratorQueen;
			}
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			var redSolen = ((SolenMatriarchQuest)System).RedSolen;

			if (redSolen)
			{
				if (creature is BlackSolenInfiltratorWarrior || creature is BlackSolenInfiltratorQueen)
				{
					CurProgress++;
				}
			}
			else
			{
				if (creature is RedSolenInfiltratorWarrior || creature is RedSolenInfiltratorQueen)
				{
					CurProgress++;
				}
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnAfterKillsObjective_SolenMatriarchQuest());
		}
	}

	public class ReturnAfterKillsObjective_SolenMatriarchQuest : QuestObjective
	{
		public override object Message =>
				/* You've completed your task of slaying solen infiltrators. Return to the
* Matriarch who gave you this task.
*/
				1054090;

		public ReturnAfterKillsObjective_SolenMatriarchQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new GatherWaterConversation_SolenMatriarchQuest());
		}
	}

	public class GatherWaterObjective_SolenMatriarchQuest : QuestObjective
	{
		public override object Message =>
				// Gather 8 gallons of water for the water vats of the solen ant lair.
				1054092;

		public override int MaxProgress => 40;

		public GatherWaterObjective_SolenMatriarchQuest()
		{
		}

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				gump.AddHtmlLocalized(70, 260, 270, 100, 1054093, BaseQuestGump.Blue, false, false); // Gallons of Water gathered:
				gump.AddLabel(70, 280, 0x64, (CurProgress / 5).ToString());
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, (MaxProgress / 5).ToString());
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnAfterWaterObjective_SolenMatriarchQuest());
		}
	}

	public class ReturnAfterWaterObjective_SolenMatriarchQuest : QuestObjective
	{
		public override object Message =>
				// You've completed your task of gathering water. Return to the Matriarch who gave you this task.
				1054095;

		public ReturnAfterWaterObjective_SolenMatriarchQuest()
		{
		}

		public override void OnComplete()
		{
			var player = System.From;
			var redSolen = ((SolenMatriarchQuest)System).RedSolen;

			var friend = SolenMatriarchQuest.IsFriend(player, redSolen);

			System.AddConversation(new ProcessFungiConversation_SolenMatriarchQuest(friend));

			if (redSolen)
			{
				player.SolenFriendship = SolenFriendship.Red;
			}
			else
			{
				player.SolenFriendship = SolenFriendship.Black;
			}
		}
	}

	public class ProcessFungiObjective_SolenMatriarchQuest : QuestObjective
	{
		public override object Message =>
				// Give the Solen Matriarch a stack of zoogi fungus to process into powder of translocation.
				1054098;

		public ProcessFungiObjective_SolenMatriarchQuest()
		{
		}

		public override void OnComplete()
		{
			if (SolenMatriarchQuest.GiveRewardTo(System.From))
			{
				System.Complete();
			}
			else
			{
				System.AddConversation(new FullBackpackConversation_SolenMatriarchQuest(true));
			}
		}
	}

	public class GetRewardObjective_SolenMatriarchQuest : QuestObjective
	{
		public override object Message =>
				// Return to the solen matriarch for your reward.
				1054149;

		public GetRewardObjective_SolenMatriarchQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new EndConversation_SolenMatriarchQuest());
		}
	}

	#endregion
}