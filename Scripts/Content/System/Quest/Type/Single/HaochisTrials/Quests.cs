using Server.Engines.Quests.Items;
using Server.Engines.Quests.Mobiles;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Definitions
{
	public class HaochisTrialsQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( AcceptConversation_HaochisTrialsQuest ),
				typeof( RadarConversation_HaochisTrialsQuest ),
				typeof( FirstTrialIntroConversation_HaochisTrialsQuest ),
				typeof( FirstTrialKillConversation_HaochisTrialsQuest ),
				typeof( GainKarmaConversation_HaochisTrialsQuest ),
				typeof( SecondTrialIntroConversation_HaochisTrialsQuest ),
				typeof( SecondTrialAttackConversation_HaochisTrialsQuest ),
				typeof( ThirdTrialIntroConversation_HaochisTrialsQuest ),
				typeof( ThirdTrialKillConversation_HaochisTrialsQuest ),
				typeof( FourthTrialIntroConversation_HaochisTrialsQuest ),
				typeof( FourthTrialCatsConversation_HaochisTrialsQuest ),
				typeof( FifthTrialIntroConversation_HaochisTrialsQuest ),
				typeof( FifthTrialReturnConversation_HaochisTrialsQuest ),
				typeof( LostSwordConversation_HaochisTrialsQuest ),
				typeof( SixthTrialIntroConversation_HaochisTrialsQuest ),
				typeof( SeventhTrialIntroConversation_HaochisTrialsQuest ),
				typeof( EndConversation_HaochisTrialsQuest ),
				typeof( FindHaochiObjective_HaochisTrialsQuest ),
				typeof( FirstTrialIntroObjective_HaochisTrialsQuest ),
				typeof( FirstTrialKillObjective_HaochisTrialsQuest ),
				typeof( FirstTrialReturnObjective_HaochisTrialsQuest ),
				typeof( SecondTrialIntroObjective_HaochisTrialsQuest ),
				typeof( SecondTrialAttackObjective_HaochisTrialsQuest ),
				typeof( SecondTrialReturnObjective_HaochisTrialsQuest ),
				typeof( ThirdTrialIntroObjective_HaochisTrialsQuest ),
				typeof( ThirdTrialKillObjective_HaochisTrialsQuest ),
				typeof( ThirdTrialReturnObjective_HaochisTrialsQuest ),
				typeof( FourthTrialIntroObjective_HaochisTrialsQuest ),
				typeof( FourthTrialCatsObjective_HaochisTrialsQuest ),
				typeof( FourthTrialReturnObjective_HaochisTrialsQuest ),
				typeof( FifthTrialIntroObjective_HaochisTrialsQuest ),
				typeof( FifthTrialReturnObjective_HaochisTrialsQuest ),
				typeof( SixthTrialIntroObjective_HaochisTrialsQuest ),
				typeof( SixthTrialReturnObjective_HaochisTrialsQuest ),
				typeof( SeventhTrialIntroObjective_HaochisTrialsQuest ),
				typeof( SeventhTrialReturnObjective_HaochisTrialsQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				// Haochi's Trials
				1063022;

		public override object OfferMessage =>
				/* <i>As you enter the courtyard you notice a faded sign.
* It reads: </i><br><br>
* 
* Welcome to your new home, Samurai.<br><br>
* 
* Though your skills are only a shadow of what they can be some day,
* you must prove your adherence to the code of the Bushido.<br><br>
* 
* Seek Daimyo Haochi for guidance.<br><br>
* 
* <i>Will you accept the challenge?</i>
*/
				1063023;

		public override TimeSpan RestartDelay => TimeSpan.MaxValue;
		public override bool IsTutorial => true;

		public override int Picture => 0x15D7;

		public HaochisTrialsQuest(PlayerMobile from) : base(from)
		{
		}

		// Serialization
		public HaochisTrialsQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation(new AcceptConversation_HaochisTrialsQuest());
		}

		private bool m_SentRadarConversion;

		public override void Slice()
		{
			if (!m_SentRadarConversion && (From.Map != Map.Malas || From.X < 360 || From.X > 400 || From.Y < 760 || From.Y > 780))
			{
				m_SentRadarConversion = true;
				AddConversation(new RadarConversation_HaochisTrialsQuest());
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

		public static bool HasLostHaochisKatana(Mobile from)
		{
			var pm = from as PlayerMobile;

			if (pm == null)
			{
				return false;
			}

			var qs = pm.Quest;

			if (qs is HaochisTrialsQuest)
			{
				if (qs.IsObjectiveInProgress(typeof(FifthTrialReturnObjective_HaochisTrialsQuest)))
				{
					var pack = from.Backpack;

					return (pack == null || pack.FindItemByType(typeof(HaochisKatana)) == null);
				}
			}

			return false;
		}
	}

	#region Conversation

	public class AcceptConversation_HaochisTrialsQuest : QuestConversation
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

		public AcceptConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindHaochiObjective_HaochisTrialsQuest());
		}
	}

	public class RadarConversation_HaochisTrialsQuest : QuestConversation
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

		public RadarConversation_HaochisTrialsQuest()
		{
		}
	}

	public class FirstTrialIntroConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* Greetings. I am Daimyo Haochi, the Feudal Lord of this region. <BR><BR>
* 
* Since you are here at my side, you must wish to learn the ways of the Samurai.<BR><BR>
* 
* Wielding a blade is easy, anyone can grasp a sword’s hilt. Learning how to
* fight properly and skillfully is to become an Armsman.<BR><BR>
* 
* Learning how to master weapons, and even more importantly when not to use
* them, is the Way of the Warrior. The Way of the Samurai. The Code of the
* Bushido. That is why you are here. <BR><BR>
* 
* You will go through 7 trials to prove your adherence to the Samurai code. <BR><BR>
* 
* The first trial will test your decision making skills. You only have to enter
* the area beyond the green passageway. <BR><BR>
* 
* Do not attempt to hurry your trials. The guards will only let you through
* to each trial when I have deemed you ready.<br><br>
* 
* As a last resort you may use the golden teleporter tiles in each trial area
* but do so at your own risk. You may not be able to return and complete your
* trials once you have chosen to escape.
*/
				1063029;

		public FirstTrialIntroConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FirstTrialIntroObjective_HaochisTrialsQuest());
		}
	}

	public class FirstTrialKillConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* Beyond you are two troubled groups.<BR><BR>
* 
* The Cursed Souls were once proud warriors that were ensorcelled
* by an evil mage. The mage trapped and killed them later but the spell
* has not lifted from their souls in death. <BR><BR>
* 
* The Young Ronin were former Samurai in training who lost their way.
* They are loyal only to those with enough coin in their pocket. <BR><BR>
* 
* You must decide who needs to be fought to the death. You may wish to
* <a href="?ForceTopic27">review combat techniques</a> as well as
* <a href = "?ForceTopic29">information on healing yourself</a>. <BR><BR>
* 
* Return to Daimyo Haochi after you have finished with your trial.<br><br>
* 
* If you should die during any of your trials, visit one of the Ankh Shrines
* and you will be resurrected. You should retrieve your belongings from your
* body before returning to the Daimyo or you may not be able to return to your corpse.
*/
				1063031;

		public FirstTrialKillConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FirstTrialKillObjective_HaochisTrialsQuest());
		}
	}

	public class GainKarmaConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message
		{
			get
			{
				if (m_CursedSoul)
				{
					// You have just gained some <a href="?ForceTopic45">Karma</a> for killing a Cursed Soul.
					return 1063040;
				}
				else
				{
					// You have just gained some <a href="?ForceTopic45">Karma</a> for killing a Young Ronin.
					return 1063041;
				}
			}
		}

		public override bool Logged => false;

		private bool m_CursedSoul;

		public GainKarmaConversation_HaochisTrialsQuest(bool cursedSoul)
		{
			m_CursedSoul = cursedSoul;
		}

		public GainKarmaConversation_HaochisTrialsQuest()
		{
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_CursedSoul = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_CursedSoul);
		}
	}

	public class SecondTrialIntroConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message
		{
			get
			{
				if (m_CursedSoul)
				{
					/* It is good that you rid the land of the Cursed Souls so they can
					 * be at peace in death. They had been cursed for doing what they
					 * thought was an honorable deed. Now they can have respect in their death.<BR><BR>
					 * 
					 * I have placed a reward in your pack. <BR><BR>
					 * 
					 * The second trial will test your courage. You only have to follow the yellow
					 * path to see what awaits you.
					 */
					return 1063045;
				}
				else
				{
					/* It is good that you rid the land of those dishonorable Samurai.
					 * Perhaps they will learn a greater lesson in death.<BR><BR>
					 * 
					 * I have placed a reward in your pack.<BR><BR>
					 * 
					 * The second trial will test your courage. You only have to follow
					 * the yellow path to see what awaits you.
					 */
					return 1063046;
				}
			}
		}

		private bool m_CursedSoul;

		public SecondTrialIntroConversation_HaochisTrialsQuest(bool cursedSoul)
		{
			m_CursedSoul = cursedSoul;
		}

		public SecondTrialIntroConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SecondTrialIntroObjective_HaochisTrialsQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_CursedSoul = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_CursedSoul);
		}
	}

	public class SecondTrialAttackConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* Beyond the guards is a test of courage.  You must face your fear and attack a
* great beast. You must choose which beast to slay for there is more than
* one beyond the courtyard doors. <BR><BR>
* 
* The imp entered the courtyard unaware of its surroundings. The dragon came
* knowingly, hunting for the flesh of humans – A feast for the beast. <BR><BR>
* 
* You must rid the courtyard of these beasts but you may only choose one to
* attack. Go and choose wisely.
*/
				1063057;

		public SecondTrialAttackConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SecondTrialAttackObjective_HaochisTrialsQuest());
		}
	}

	public class ThirdTrialIntroConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message
		{
			get
			{
				if (m_Dragon)
				{
					/* You faced the dragon knowing it would be your certain death.
					 * That is the courage of a Samurai. <BR><BR>
					 * 
					 * Your spirit speaks as a Samurai already. <BR><BR>
					 * 
					 * In these lands, death is not forever. The shrines can make you whole
					 * again as can a helpful mage or healer. <BR><BR>
					 * 
					 * Seek them out when you have been mortally wounded. <BR><BR>
					 * 
					 * The next trial will test your benevolence. You only have to walk the blue path.
					 */
					return 1063060;
				}
				else
				{
					/* Fear remains in your eyes but you have learned that not all is
					 * what it appears to be. <BR><BR>
					 * 
					 * You must have known the dragon would slay you instantly.
					 * You elected the weaker opponent though the imp did not come
					 * here to destroy. You have much to learn. <BR><BR>
					 * 
					 * In these lands, death is not forever. The shrines can make you whole
					 * again as can a helpful mage or healer. <BR><BR>
					 * 
					 * Seek them out when you have been mortally wounded. <BR><BR>
					 * 
					 * The next trial will test your benevolence. You only have to walk the blue path.
					 */
					return 1063059;
				}
			}
		}

		private bool m_Dragon;

		public ThirdTrialIntroConversation_HaochisTrialsQuest(bool dragon)
		{
			m_Dragon = dragon;
		}

		public ThirdTrialIntroConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ThirdTrialIntroObjective_HaochisTrialsQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_Dragon = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Dragon);
		}
	}

	public class ThirdTrialKillConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* A pack of wolves circle your feet. They have been injured and are in pain.
* A quick death will end their suffering.<br><br>
* 
* Use your Honorable Execution skill or other means to finish off a wounded wolf.
* Do so and return to Daimyo Haochi.
*/
				1063062;

		public ThirdTrialKillConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ThirdTrialKillObjective_HaochisTrialsQuest());
		}
	}

	public class FourthTrialIntroConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Daimyo Haochi smiles as you walk up to him. Quietly he says:</I><BR><BR>
* 
* A Samurai understands the need to help others even as he wields a blade against
* them. <BR><BR>
* 
* You have shown compassion. A true Samurai is benevolent even to an enemy.
* For this you have been rewarded. <BR><BR>
* 
* And now you must prove yourself again. Walk the red path.
* We will talk again later.
*/
				1063065;

		public FourthTrialIntroConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FourthTrialIntroObjective_HaochisTrialsQuest());
		}
	}

	public class FourthTrialCatsConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* <I>You approach a disheveled gypsy standing near a small shed.
* You sense that she has not eaten nor bathed in quite some time. <BR><BR>
* 
* Around her is a large colony of mangy and diseased cats. It appears
* she has spent what little money she’s earned to feed the cats instead
* of herself. <BR><BR>
* 
* You have a decision to make. You can give her gold so she can buy some
* food for her animals and herself. You can also remove the necessity
* of the extra mouths to feed so she may concentrate on saving herself.</i><br><br>
* 
* If you elect to give the gypsy money, you can do so by clicking your stack
* of gold and selecting ‘1’. Then dragging it and dropping it on the Gypsy.
*/
				1063067;

		public FourthTrialCatsConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FourthTrialCatsObjective_HaochisTrialsQuest());
		}
	}

	public class FifthTrialIntroConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message
		{
			get
			{
				if (m_KilledCat)
				{
					/* Respect comes from allowing another to make their own decisions.
					 * By denying the gypsy her animals, you negate the respect she is due.
					 * Perhaps you will have learned something to use next time a similar
					 * situation arises. <BR><BR>
					 * 
					 * And now you must prove yourself again. Please retrieve my katana
					 * from the treasure room and return it to me.
					 */
					return 1063071;
				}
				else
				{
					/* You showed respect by helping another out while allowing the gypsy
					 * what little dignity she has left. <BR><BR>
					 * 
					 * Now she will be able to feed herself and gain enough energy to walk
					 * to her camp. <BR><BR>
					 * 
					 * The cats are her family members– cursed by an evil mage. <BR><BR>
					 * 
					 * Once she has enough strength to walk back to the camp, she will be
					 * able to undo the spell. <BR><BR>
					 * 
					 * You have been rewarded for completing your trial. And now you must
					 * prove yourself again. <BR><BR>Please retrieve my katana from the
					 * treasure room and return it to me.
					 */
					return 1063070;
				}
			}
		}

		private bool m_KilledCat;

		public FifthTrialIntroConversation_HaochisTrialsQuest(bool killedCat)
		{
			m_KilledCat = killedCat;
		}

		public FifthTrialIntroConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FifthTrialIntroObjective_HaochisTrialsQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_KilledCat = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_KilledCat);
		}
	}

	public class FifthTrialReturnConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* <i>The guards let you through without question, and pay you no mind as
* you walk into the Daimyo's treasure cache.  A vast fortune in gold,
* gemstones, and jewelry is stored here!  Surely, the Daimyo wouldn't
* miss a single small item...<br><br>
* 
* You spot the sword quickly amongst the cache of gemstones and other valuables.
* In one quick motion you retrieve it and stash it in your pack.</i>
*/
				1063248;

		public FifthTrialReturnConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FifthTrialReturnObjective_HaochisTrialsQuest());
		}
	}

	public class LostSwordConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				// What? You have returned without the sword? Go back and look for it again.
				1063074;

		public override bool Logged => false;

		public LostSwordConversation_HaochisTrialsQuest()
		{
		}
	}

	public class SixthTrialIntroConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message
		{
			get
			{
				if (m_StolenTreasure)
				{
					/* I thank you for returning this sword. However, you should admonished
					 * for also taking treasure that was not asked for nor given back.  <BR><BR>
					 * 
					 * Think about your actions youngling. <BR><BR>
					 * 
					 * Your training is nearly complete. Before you have your final trial,
					 * you should pay homage to Samurai who came before you.  <BR><BR>
					 * 
					 * Go into the Altar Room and light a candle for them.
					 * Afterwards, return to me.
					 */
					return 1063077;
				}
				else
				{
					/* Thank you for returning this sword to me and leaving the remaining
					 * treasure alone. <BR><BR>
					 * 
					 * Your training is nearly complete. Before you have your final trial,
					 * you should pay homage to Samurai who came before you.  <BR><BR>
					 * 
					 * Go into the Altar Room and light a candle for them. Afterwards, return to me.
					 */
					return 1063076;
				}
			}
		}

		private bool m_StolenTreasure;

		public SixthTrialIntroConversation_HaochisTrialsQuest(bool stolenTreasure)
		{
			m_StolenTreasure = stolenTreasure;
		}

		public SixthTrialIntroConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SixthTrialIntroObjective_HaochisTrialsQuest());
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

	public class SeventhTrialIntroConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* You have done well young Samurai. There is but one thing left to do. <BR><BR>
* 
* In the final room is the holding cell containing young Ninjas who came to
* take my life. They were caught and placed in my custody. <BR><BR>
* 
* Take care of these miscreants and show them where your loyalty lies. <BR><BR>
* 
* This is your final act as a Samurai in training.
*/
				1063079;

		public SeventhTrialIntroConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new SeventhTrialIntroObjective_HaochisTrialsQuest());
		}
	}

	public class EndConversation_HaochisTrialsQuest : QuestConversation
	{
		public override object Message =>
				/* You have proven yourself young one. You will continue to improve as your skills
* are honed with age. <BR><BR>
* 
* Now it is time for you to explore the lands. Beyond this path lies Zento
* City, your future home.  On these grounds you will find a golden oval object
* known as a Moongate, step through it and you'll find yourself in Zento.<BR><BR>
* 
* You may want to visit Ansella Gryen when you arrive. <BR><BR>
* 
* You have learned the ways. You are an honorable warrior, a Samurai in
* the highest regards. <BR><BR>
* 
* Please accept the gifts I have placed in your pack. You have earned them.
* Farewell for now.
*/
				1063125;

		public EndConversation_HaochisTrialsQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	#endregion

	#region Objective

	public class FindHaochiObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Speak to Daimyo Haochi.
				1063026;

		public FindHaochiObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new FirstTrialIntroConversation_HaochisTrialsQuest());
		}
	}

	public class FirstTrialIntroObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Follow the green path. The guards will now let you through.
				1063030;

		public FirstTrialIntroObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new FirstTrialKillConversation_HaochisTrialsQuest());
		}
	}

	public class FirstTrialKillObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Kill 3 Young Ronin or 3 Cursed Souls. Return to Daimyo Haochi when you have finished.
				1063032;

		public FirstTrialKillObjective_HaochisTrialsQuest()
		{
		}

		private int m_CursedSoulsKilled;
		private int m_YoungRoninKilled;

		public override int MaxProgress => 3;

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is CursedSoul)
			{
				if (m_CursedSoulsKilled == 0)
				{
					System.AddConversation(new GainKarmaConversation_HaochisTrialsQuest(true));
				}

				m_CursedSoulsKilled++;

				// Cursed Souls killed:  ~1_COUNT~
				System.From.SendLocalizedMessage(1063038, m_CursedSoulsKilled.ToString());
			}
			else if (creature is YoungRonin)
			{
				if (m_YoungRoninKilled == 0)
				{
					System.AddConversation(new GainKarmaConversation_HaochisTrialsQuest(false));
				}

				m_YoungRoninKilled++;

				// Young Ronin killed:  ~1_COUNT~
				System.From.SendLocalizedMessage(1063039, m_YoungRoninKilled.ToString());
			}

			CurProgress = Math.Max(m_CursedSoulsKilled, m_YoungRoninKilled);
		}

		public override void OnComplete()
		{
			System.AddObjective(new FirstTrialReturnObjective_HaochisTrialsQuest(m_CursedSoulsKilled > m_YoungRoninKilled));
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_CursedSoulsKilled = reader.ReadEncodedInt();
			m_YoungRoninKilled = reader.ReadEncodedInt();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(m_CursedSoulsKilled);
			writer.WriteEncodedInt(m_YoungRoninKilled);
		}
	}

	public class FirstTrialReturnObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// The first trial is complete. Return to Daimyo Haochi.
				1063044;

		private bool m_CursedSoul;

		public FirstTrialReturnObjective_HaochisTrialsQuest(bool cursedSoul)
		{
			m_CursedSoul = cursedSoul;
		}

		public FirstTrialReturnObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new SecondTrialIntroConversation_HaochisTrialsQuest(m_CursedSoul));
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_CursedSoul = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_CursedSoul);
		}
	}

	public class SecondTrialIntroObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Follow the yellow path. The guards will now let you through.
				1063047;

		public SecondTrialIntroObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new SecondTrialAttackConversation_HaochisTrialsQuest());
		}
	}

	public class SecondTrialAttackObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Choose your opponent and attack one with all your skill.
				1063058;

		public SecondTrialAttackObjective_HaochisTrialsQuest()
		{
		}
	}

	public class SecondTrialReturnObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// The second trial is complete.  Return to Daimyo Haochi.
				1063229;

		private bool m_Dragon;

		public bool Dragon => m_Dragon;

		public SecondTrialReturnObjective_HaochisTrialsQuest(bool dragon)
		{
			m_Dragon = dragon;
		}

		public SecondTrialReturnObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ThirdTrialIntroConversation_HaochisTrialsQuest(m_Dragon));
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_Dragon = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Dragon);
		}
	}

	public class ThirdTrialIntroObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				/* The next trial will test your benevolence. Follow the blue path.
* The guards will now let you through.
*/
				1063061;

		public ThirdTrialIntroObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ThirdTrialKillConversation_HaochisTrialsQuest());
		}
	}

	public class ThirdTrialKillObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				/* Use your Honorable Execution skill to finish off the wounded wolf.
* Double click the icon in your Book of Bushido to activate the skill.
* When you are done, return to Daimyo Haochi.
*/
				1063063;

		public ThirdTrialKillObjective_HaochisTrialsQuest()
		{
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is InjuredWolf)
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new ThirdTrialReturnObjective_HaochisTrialsQuest());
		}
	}

	public class ThirdTrialReturnObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Return to Daimyo Haochi.
				1063064;

		public ThirdTrialReturnObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new FourthTrialIntroConversation_HaochisTrialsQuest());
		}
	}

	public class FourthTrialIntroObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Follow the red path and pass through the guards to the entrance of the fourth trial.
				1063066;

		public FourthTrialIntroObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new FourthTrialCatsConversation_HaochisTrialsQuest());
		}
	}

	public class FourthTrialCatsObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				/* Give the gypsy gold or hunt one of the cats to eliminate the undue
* need it has placed on the gypsy.
*/
				1063068;

		public FourthTrialCatsObjective_HaochisTrialsQuest()
		{
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is DiseasedCat)
			{
				Complete();
				System.AddObjective(new FourthTrialReturnObjective_HaochisTrialsQuest(true));
			}
		}
	}

	public class FourthTrialReturnObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// You have made your choice.  Return now to Daimyo Haochi.
				1063242;

		private bool m_KilledCat;

		public bool KilledCat => m_KilledCat;

		public FourthTrialReturnObjective_HaochisTrialsQuest(bool killedCat)
		{
			m_KilledCat = killedCat;
		}

		public FourthTrialReturnObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new FifthTrialIntroConversation_HaochisTrialsQuest(m_KilledCat));
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_KilledCat = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_KilledCat);
		}
	}

	public class FifthTrialIntroObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Retrieve Daimyo Haochi’s katana from the treasure room.
				1063072;

		private bool m_StolenTreasure;

		public bool StolenTreasure { get => m_StolenTreasure; set => m_StolenTreasure = value; }

		public FifthTrialIntroObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new FifthTrialReturnConversation_HaochisTrialsQuest());
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

	public class FifthTrialReturnObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Give the sword to Daimyo Haochi.
				1063073;

		public FifthTrialReturnObjective_HaochisTrialsQuest()
		{
		}
	}

	public class SixthTrialIntroObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// Light one of the candles near the altar and return to Daimyo Haochi.
				1063078;

		public SixthTrialIntroObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective(new SixthTrialReturnObjective_HaochisTrialsQuest());
		}
	}

	public class SixthTrialReturnObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// You have done as requested.  Return to Daimyo Haochi.
				1063252;

		public SixthTrialReturnObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new SeventhTrialIntroConversation_HaochisTrialsQuest());
		}
	}

	public class SeventhTrialIntroObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				/* Three young Ninja must be dealt with. Your job is to kill them.
* When you have done so, return to Daimyo Haochi.
*/
				1063080;

		public override int MaxProgress => 3;

		public SeventhTrialIntroObjective_HaochisTrialsQuest()
		{
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is YoungNinja)
			{
				CurProgress++;
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new SeventhTrialReturnObjective_HaochisTrialsQuest());
		}
	}

	public class SeventhTrialReturnObjective_HaochisTrialsQuest : QuestObjective
	{
		public override object Message =>
				// The executions are complete.  Return to the Daimyo.
				1063253;

		public SeventhTrialReturnObjective_HaochisTrialsQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new EndConversation_HaochisTrialsQuest());
		}
	}

	#endregion
}