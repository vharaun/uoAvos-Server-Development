using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Definitions
{
	public class TerribleHatchlingsQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( AcceptConversation_TerribleHatchlingsQuest ),
				typeof( DirectionConversation_TerribleHatchlingsQuest ),
				typeof( TakeCareConversation_TerribleHatchlingsQuest ),
				typeof( EndConversation_TerribleHatchlingsQuest ),
				typeof( FirstKillObjective_TerribleHatchlingsQuest ),
				typeof( SecondKillObjective_TerribleHatchlingsQuest ),
				typeof( ThirdKillObjective_TerribleHatchlingsQuest ),
				typeof( ReturnObjective_TerribleHatchlingsQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				// Terrible Hatchlings
				1063314;

		public override object OfferMessage =>
				/* The Deathwatch Beetle Hatchlings have trampled through my fields
* again, what a nuisance! Please help me get rid of the terrible
* hatchlings. If you kill 10 of them, you will be rewarded.
* The Deathwatch Beetle Hatchlings live in The Waste -
* the desert close to this city.<BR><BR>
* 
* Will you accept this challenge?
*/
				1063315;

		public override TimeSpan RestartDelay => TimeSpan.MaxValue;
		public override bool IsTutorial => true;

		public override int Picture => 0x15CF;

		public TerribleHatchlingsQuest(PlayerMobile from) : base(from)
		{
		}

		// Serialization
		public TerribleHatchlingsQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation(new AcceptConversation_TerribleHatchlingsQuest());
		}
	}

	#region Conversation

	public class AcceptConversation_TerribleHatchlingsQuest : QuestConversation
	{
		public override object Message =>
				/* <I><U>Important Quest Information</U></I><BR><BR>
* 
* During your quest, any important information that a
* <a href = "?ForceTopic31">NPC</a> gives you, will appear in a window
* such as this one.  You can review the information at any time during your
* quest.<BR><BR>
* 
* <U>Getting Help</U><BR><BR>
* 
* Some of the text you will come across during your quest,
* will be underlined <a href = "?ForceTopic73">links to the codex of wisdom</a>,
* or online help system.  You can click on the text to get detailed information
* on the underlined subject.  You may also access the Codex Of Wisdom by
* pressing "F1" or by clicking on the "?" on the toolbar at the top of
* your screen.<BR><BR><U>Context Menus</U><BR><BR>
* 
* Context menus can be called up by single left-clicking (or Shift + single
* left-click, if you changed it) on most objects or NPCs in the world.
* Nearly everything, including your own avatar will have context menus available.
* Bringing up your avatar's context menu will give you options to cancel your quest
* and review various quest information.<BR><BR>
*/
				1049092;

		public AcceptConversation_TerribleHatchlingsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FirstKillObjective_TerribleHatchlingsQuest());
		}
	}

	public class DirectionConversation_TerribleHatchlingsQuest : QuestConversation
	{
		public override object Message =>
				// The Deathwatch Beetle Hatchlings live in The Waste - the desert close to this city.
				1063323;

		public override bool Logged => false;

		public DirectionConversation_TerribleHatchlingsQuest()
		{
		}
	}

	public class TakeCareConversation_TerribleHatchlingsQuest : QuestConversation
	{
		public override object Message =>
				// I know you can take care of those nasty Deathwatch Beetle Hatchlings! No get to it!
				1063324;

		public override bool Logged => false;

		public TakeCareConversation_TerribleHatchlingsQuest()
		{
		}
	}

	public class EndConversation_TerribleHatchlingsQuest : QuestConversation
	{
		public override object Message =>
				/* Thank you for helping me get rid of these vile beasts!
* You have been rewarded for your good deeds. If you wish to
* help me in the future, visit me again.<br><br>
* 
* Farewell.
*/
				1063321;

		public EndConversation_TerribleHatchlingsQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	#endregion

	#region Objective

	public class FirstKillObjective_TerribleHatchlingsQuest : QuestObjective
	{
		public override object Message =>
				// Kill 10 Deathwatch Beetle Hatchlings and return to Ansella Gryen.
				1063316;

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				// Deathwatch Beetle Hatchlings killed:
				gump.AddHtmlLocalized(70, 260, 270, 100, 1063318, 0x12DC6BF, false, false);

				gump.AddLabel(70, 280, 0x64, "0");
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, "10");
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public FirstKillObjective_TerribleHatchlingsQuest()
		{
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is DeathwatchBeetleHatchling)
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new SecondKillObjective_TerribleHatchlingsQuest());
		}
	}

	public class SecondKillObjective_TerribleHatchlingsQuest : QuestObjective
	{
		public override object Message =>
				/* Great job! One less terrible hatchling in the Waste!<BR><BR>
* 
* Once you've killed 10 of the Deathwatch Beetle Hatchlings,
* return to Ansella for your reward!
*/
				1063320;

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				// Deathwatch Beetle Hatchlings killed:
				gump.AddHtmlLocalized(70, 260, 270, 100, 1063318, 0x12DC6BF, false, false);

				gump.AddLabel(70, 280, 0x64, "1");
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, "10");
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public SecondKillObjective_TerribleHatchlingsQuest()
		{
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is DeathwatchBeetleHatchling)
			{
				Complete();
				System.AddObjective(new ThirdKillObjective_TerribleHatchlingsQuest(2));
			}
		}

		public override void OnRead()
		{
			if (!Completed)
			{
				Complete();
				System.AddObjective(new ThirdKillObjective_TerribleHatchlingsQuest(1));
			}
		}
	}

	public class ThirdKillObjective_TerribleHatchlingsQuest : QuestObjective
	{
		public override object Message =>
				// Continue killing Deathwatch Beetle Hatchlings.
				1063319;

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				// Deathwatch Beetle Hatchlings killed:
				gump.AddHtmlLocalized(70, 260, 270, 100, 1063318, 0x12DC6BF, false, false);

				gump.AddLabel(70, 280, 0x64, CurProgress.ToString());
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, "10");
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public override int MaxProgress => 10;

		public ThirdKillObjective_TerribleHatchlingsQuest(int startingProgress)
		{
			CurProgress = startingProgress;
		}

		public ThirdKillObjective_TerribleHatchlingsQuest()
		{
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is DeathwatchBeetleHatchling)
			{
				CurProgress++;
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnObjective_TerribleHatchlingsQuest());
		}
	}

	public class ReturnObjective_TerribleHatchlingsQuest : QuestObjective
	{
		public override object Message =>
				// Return to Ansella Gryen for your reward.
				1063313;

		public ReturnObjective_TerribleHatchlingsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new EndConversation_TerribleHatchlingsQuest());
		}
	}

	#endregion
}