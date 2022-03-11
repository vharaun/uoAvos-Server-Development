using Server.Engines.Quests.Mobiles;
using Server.Mobiles;

using System;
using System.Collections;

namespace Server.Engines.Quests.Definitions
{
	public class StudyOfSolenQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( StudyNestsObjective_StudyOfSolenQuest ),
				typeof( ReturnToNaturalistObjective_StudyOfSolenQuest ),
				typeof( DontOfferConversation_StudyOfSolenQuest ),
				typeof( AcceptConversation_StudyOfSolenQuest ),
				typeof( NaturalistDuringStudyConversation_StudyOfSolenQuest ),
				typeof( EndConversation_StudyOfSolenQuest ),
				typeof( SpecialEndConversation_StudyOfSolenQuest ),
				typeof( FullBackpackConversation_StudyOfSolenQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				// "Study of the Solen Hive"
				1054041;

		public override object OfferMessage =>
				/* <I>The Naturalist looks up from his notes, regarding you with a hopeful
* look in his eyes.</I><BR><BR>
* 
* Um..yes..excuse me. I was wondering if you could offer me a bit of assistance.
* You see, I'm a naturalist of some repute - a gentleman and a scholar if you
* will - primarily interested in the study of insects and arachnids. While I've
* written a few interesting books on the marvelous Terathan race and their bizarre
* culture, now I've heard tales of a truly significant new discovery!<BR><BR>
* 
* Apparently a race of ant-like creatures known as the Solen have appeared in
* our world, scuttling up from some previously hidden home. Can you believe it?
* Truly these are amazing times! To a scholar such as myself this is indeed
* an exciting opportunity.<BR><BR>
* 
* That said, while I may be a genius of some reknown, sharp as a tack and quick
* with the quill, I'm afraid I'm not much of the adventuring type. Though I have
* gained assistance before, I still have many unanswered questions.<BR><BR>
* 
* I am particularly interested in the Solen Egg Nests that are studiously
* protected by the Solen workers. If you would be so kind as to assist me,
* I would ask that you travel into the Solen Hive and inspect each of the
* Solen Egg Nests that reside within. You will have to spend some time examining
* each Nest before you have gathered enough information. Once you are done,
* report back to me and I will reward you as best as I can for your valiant
* efforts!<BR><BR>
* 
* Will you accept my offer?
*/
				1054042;

		public override TimeSpan RestartDelay => TimeSpan.Zero;
		public override bool IsTutorial => false;

		public override int Picture => 0x15C7;

		private Naturalist m_Naturalist;

		public Naturalist Naturalist => m_Naturalist;

		public StudyOfSolenQuest(PlayerMobile from, Naturalist naturalist) : base(from)
		{
			m_Naturalist = naturalist;
		}

		// Serialization
		public StudyOfSolenQuest()
		{
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_Naturalist = (Naturalist)reader.ReadMobile();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Naturalist);
		}

		public override void Accept()
		{
			base.Accept();

			if (m_Naturalist != null)
			{
				m_Naturalist.PlaySound(0x431);
			}

			AddConversation(new AcceptConversation_StudyOfSolenQuest());
		}
	}

	public class NestArea
	{
		private static readonly NestArea[] m_Areas = new NestArea[]
			{
				new NestArea( false,    new Rectangle2D( 5861, 1787, 26, 25 ) ),

				new NestArea( false,    new Rectangle2D( 5734, 1788, 14, 50 ),
										new Rectangle2D( 5748, 1800, 3, 34 ),
										new Rectangle2D( 5751, 1808, 2, 20 ) ),

				new NestArea( false,    new Rectangle2D( 5907, 1908, 19, 43 ) ),

				new NestArea( false,    new Rectangle2D( 5721, 1926, 24, 29 ),
										new Rectangle2D( 5745, 1935, 7, 22 ) ),

				new NestArea( true,     new Rectangle2D( 5651, 1853, 21, 32 ),
										new Rectangle2D( 5672, 1857, 6, 20 ) )
			};

		public static int NonSpecialCount
		{
			get
			{
				var n = 0;
				foreach (var area in m_Areas)
				{
					if (!area.Special)
					{
						n++;
					}
				}
				return n;
			}
		}

		public static NestArea Find(IPoint2D p)
		{
			foreach (var area in m_Areas)
			{
				if (area.Contains(p))
				{
					return area;
				}
			}
			return null;
		}

		public static NestArea GetByID(int id)
		{
			if (id >= 0 && id < m_Areas.Length)
			{
				return m_Areas[id];
			}
			else
			{
				return null;
			}
		}

		private readonly bool m_Special;
		private readonly Rectangle2D[] m_Rects;

		public bool Special => m_Special;

		public int ID
		{
			get
			{
				for (var i = 0; i < m_Areas.Length; i++)
				{
					if (m_Areas[i] == this)
					{
						return i;
					}
				}
				return 0;
			}
		}

		private NestArea(bool special, params Rectangle2D[] rects)
		{
			m_Special = special;
			m_Rects = rects;
		}

		public bool Contains(IPoint2D p)
		{
			foreach (var rect in m_Rects)
			{
				if (rect.Contains(p))
				{
					return true;
				}
			}
			return false;
		}
	}

	#region Conversation

	public class DontOfferConversation_StudyOfSolenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Naturalist looks up from his scribbled notes.</I><BR><BR>
* 
* Greetings!<BR><BR>
* 
* If you're interested in helping out a scholar of some repute, I do have some
* work that I could use some assistance with.<BR><BR>
* 
* You seem a little preoccupied with another task right now, however. Perhaps
* you should finish whatever it is that has your attention at the moment and
* return to me once you're done.
*/
				1054052;

		public override bool Logged => false;

		public DontOfferConversation_StudyOfSolenQuest()
		{
		}
	}

	public class AcceptConversation_StudyOfSolenQuest : QuestConversation
	{
		public override object Message =>
				/* Ah! This is splendid news! Each time an assistant travels into the
* Solen Hive to gather information for me, I feel as if I am one step
* closer to some grand discovery. Though I felt the same way when I was
* certain that Terathans had the ability to change their shape to resemble
* various fruits and vegetables - a point on which I am certain further
* study of the beasts will prove correct.<BR><BR>
* 
* In any case, I cannot thank you enough! Please return to me when you have
* studied all the Solen Egg Nests hidden within the Solen Hive.
*/
				1054043;

		public AcceptConversation_StudyOfSolenQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new StudyNestsObjective_StudyOfSolenQuest());
		}
	}

	public class NaturalistDuringStudyConversation_StudyOfSolenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Naturalist looks up from his notes with a frustrated look
* on his face.</I><BR><BR>
* 
* Haven't you finished the task I appointed you yet? Gah! It's so
* difficult to find a good apprentice these days.<BR><BR>
* 
* Remember, you must first find an entrance to the Solen Hive. Once inside,
* I need you to examine the Solen Egg Nests for me. When you have studied
* all four nests, you should have enough information to earn yourself a
* reward.<BR><BR>
* 
* Now go on, away with you! I have piles of notes from other more helpful
* apprentices that I still need to study!
*/
				1054049;

		public override bool Logged => false;

		public NaturalistDuringStudyConversation_StudyOfSolenQuest()
		{
		}
	}

	public class EndConversation_StudyOfSolenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Naturalist looks up from his notes with a pleased expression
* on his face.</I><BR><BR>
* 
* Ah! Thank you, my goodly apprentice! These notes you have gathered will
* no doubt assist me in my understanding of these fascinating Solen creatures.<BR><BR>
* 
* Now, since you've done such a fine job, I feel that I should give you a little
* reward.<BR><BR>
* 
* I have a botanist friend who has discovered a strange mutation in the plants
* she has grown. Through science and sorcery, she has managed to produce a mutant
* strain of colored seeds the like of which no gardener has laid eyes upon.<BR><BR>
* 
* As a reward for your fine efforts, I present you with this strange rare seed.
* Which reminds me, I still need to compile my notes on Solen dietary habits. They
* are voracious seed eaters, those Solen Matriarchs!<BR><BR>
* 
* In any case, I must get back to my notes now. I give you my thanks once more,
* and bid a good day to you my little apprentice! If you wish to help me out again,
* just say the word.
*/
				1054050;

		public EndConversation_StudyOfSolenQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	public class SpecialEndConversation_StudyOfSolenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Naturalist looks up from his notes with an ecstatic look upon
* his face.</I><BR><BR>
* 
* Oh my! These notes you've brought me - they say you have information on the
* Secret Solen Egg Nest? I've heard many tales of this secret store of special
* Solen Eggs, but there are many missing gaps in my notes concerning it.<BR><BR>
* 
* The notes you've made here will most certainly advance my understanding of
* this mysterious breed of creatures!<BR><BR>
* 
* Considering the amazing effort you put into your work, I feel as if I should
* give you something extra special as a bonus. Hrmm...<BR><BR>
* 
* I have a botanist friend who has discovered a strange mutation in the plants
* she has grown. Through science and sorcery, she has managed to produce a rare
* mutant strain of colored seeds the like of which no gardener has laid
* eyes upon.<BR><BR>
* 
* I've given a few of her seeds out to various apprentices - but I usually keep
* her very rare stock all for myself. They're quite amazing looking! However,
* since you've done such a fine job for me, I'll present you with one of
* these rare fire-red seeds.<BR><BR>
* 
* Once again, my thanks to you! Now I really must get back to studying these notes!
* Take care, my fine apprentice, and come back if you wish to help me further!
*/
				1054051;

		public SpecialEndConversation_StudyOfSolenQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	public class FullBackpackConversation_StudyOfSolenQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The Naturalist looks at you with a friendly expression.</I><BR><BR>
* 
* I see you've returned with information for me. While I'd like to finish
* conducting our business, it seems that you're a bit overloaded with
* equipment at the moment. Perhaps you'd better free up some room before
* we get to discussing your reward.
*/
				1054053;

		public override bool Logged => false;

		public FullBackpackConversation_StudyOfSolenQuest()
		{
		}
	}

	#endregion

	#region Objective

	public class StudyNestsObjective_StudyOfSolenQuest : QuestObjective
	{
		public override object Message =>
				/* Find an entrance to the Solen Hive, and search within for the Solen
* Egg Nests. Each Nest must be studied for some time without a break in
* concentration in order to gather useful information.<BR><BR>
* 
* Once you have completed your study of the Nests, return to the Naturalist
* who gave you this task.
*/
				1054044;

		public override int MaxProgress => NestArea.NonSpecialCount;

		private NestArea m_CurrentNest;
		private DateTime m_StudyBegin;

		private enum StudyState { Inactive, FirstStep, SecondStep }
		private StudyState m_StudyState;

		private readonly ArrayList m_StudiedNests;
		private bool m_StudiedSpecialNest;

		public bool StudiedSpecialNest => m_StudiedSpecialNest;

		public StudyNestsObjective_StudyOfSolenQuest()
		{
			m_StudiedNests = new ArrayList();
		}

		public override bool GetTimerEvent()
		{
			return true;
		}

		public override void CheckProgress()
		{
			var from = System.From;

			if (m_CurrentNest != null)
			{
				var nest = m_CurrentNest;

				if ((from.Map == Map.Trammel || from.Map == Map.Felucca) && nest.Contains(from))
				{
					if (m_StudyState != StudyState.Inactive)
					{
						var time = DateTime.UtcNow - m_StudyBegin;

						if (time > TimeSpan.FromSeconds(30.0))
						{
							m_StudiedNests.Add(nest);
							m_StudyState = StudyState.Inactive;

							if (m_CurrentNest.Special)
							{
								from.SendLocalizedMessage(1054057); // You complete your examination of this bizarre Egg Nest. The Naturalist will undoubtedly be quite interested in these notes!
								m_StudiedSpecialNest = true;
							}
							else
							{
								from.SendLocalizedMessage(1054054); // You have completed your study of this Solen Egg Nest. You put your notes away.
								CurProgress++;
							}
						}
						else if (m_StudyState == StudyState.FirstStep && time > TimeSpan.FromSeconds(15.0))
						{
							if (!nest.Special)
							{
								from.SendLocalizedMessage(1054058); // You begin recording your completed notes on a bit of parchment.
							}

							m_StudyState = StudyState.SecondStep;
						}
					}
				}
				else
				{
					if (m_StudyState != StudyState.Inactive)
					{
						from.SendLocalizedMessage(1054046); // You abandon your study of the Solen Egg Nest without gathering the needed information.
					}

					m_CurrentNest = null;
				}
			}
			else if (from.Map == Map.Trammel || from.Map == Map.Felucca)
			{
				var nest = NestArea.Find(from);

				if (nest != null)
				{
					m_CurrentNest = nest;
					m_StudyBegin = DateTime.UtcNow;

					if (m_StudiedNests.Contains(nest))
					{
						m_StudyState = StudyState.Inactive;

						from.SendLocalizedMessage(1054047); // You glance at the Egg Nest, realizing you've already studied this one.
					}
					else
					{
						m_StudyState = StudyState.FirstStep;

						if (nest.Special)
						{
							from.SendLocalizedMessage(1054056); // You notice something very odd about this Solen Egg Nest. You begin taking notes.
						}
						else
						{
							from.SendLocalizedMessage(1054045); // You begin studying the Solen Egg Nest to gather information.
						}

						if (from.Female)
						{
							from.PlaySound(0x30B);
						}
						else
						{
							from.PlaySound(0x419);
						}
					}
				}
			}
		}

		public override void RenderProgress(BaseQuestGump gump)
		{
			if (!Completed)
			{
				gump.AddHtmlLocalized(70, 260, 270, 100, 1054055, BaseQuestGump.Blue, false, false); // Solen Nests Studied :
				gump.AddLabel(70, 280, 0x64, CurProgress.ToString());
				gump.AddLabel(100, 280, 0x64, "/");
				gump.AddLabel(130, 280, 0x64, MaxProgress.ToString());
			}
			else
			{
				base.RenderProgress(gump);
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnToNaturalistObjective_StudyOfSolenQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			var count = reader.ReadEncodedInt();
			for (var i = 0; i < count; i++)
			{
				var nest = NestArea.GetByID(reader.ReadEncodedInt());
				m_StudiedNests.Add(nest);
			}

			m_StudiedSpecialNest = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(m_StudiedNests.Count);
			foreach (NestArea nest in m_StudiedNests)
			{
				writer.WriteEncodedInt(nest.ID);
			}

			writer.Write(m_StudiedSpecialNest);
		}
	}

	public class ReturnToNaturalistObjective_StudyOfSolenQuest : QuestObjective
	{
		public override object Message =>
				/* You have studied enough Solen Egg Nests to gather a fair amount of
* useful information. Return to the Naturalist who gave you this task.
*/
				1054048;

		public ReturnToNaturalistObjective_StudyOfSolenQuest()
		{
		}

		public override void RenderProgress(BaseQuestGump gump)
		{
			var count = NestArea.NonSpecialCount.ToString();

			gump.AddHtmlLocalized(70, 260, 270, 100, 1054055, BaseQuestGump.Blue, false, false); // Solen Nests Studied :
			gump.AddLabel(70, 280, 0x64, count);
			gump.AddLabel(100, 280, 0x64, "/");
			gump.AddLabel(130, 280, 0x64, count);
		}
	}

	#endregion
}