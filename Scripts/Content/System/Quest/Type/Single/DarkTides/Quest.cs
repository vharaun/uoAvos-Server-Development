using Server.Engines.Quests.Items;
using Server.Engines.Quests.Mobiles;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.Quests.Definitions
{
	public class DarkTidesQuest : QuestSystem
	{
		private static readonly Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( NecroAcceptConversation_DarkTidesQuest ),
				typeof( AnimateMaabusCorpseObjective_DarkTidesQuest ),
				typeof( BankerConversation_DarkTidesQuest ),
				typeof( CashBankCheckObjective_DarkTidesQuest ),
				typeof( FetchAbraxusScrollObjective_DarkTidesQuest ),
				typeof( FindBankObjective_DarkTidesQuest ),
				typeof( FindCallingScrollObjective_DarkTidesQuest ),
				typeof( FindCityOfLightObjective_DarkTidesQuest ),
				typeof( FindCrystalCaveObjective_DarkTidesQuest ),
				typeof( FindMaabusCorpseObjective_DarkTidesQuest ),
				typeof( FindMaabusTombObjective_DarkTidesQuest ),
				typeof( FindMardothAboutKronusObjective_DarkTidesQuest ),
				typeof( FindMardothAboutVaultObjective_DarkTidesQuest ),
				typeof( FindMardothEndObjective_DarkTidesQuest ),
				typeof( FindVaultOfSecretsObjective_DarkTidesQuest ),
				typeof( FindWellOfTearsObjective_DarkTidesQuest ),
				typeof( HorusConversation_DarkTidesQuest ),
				typeof( LostCallingScrollConversation_DarkTidesQuest ),
				typeof( MaabasConversation_DarkTidesQuest ),
				typeof( MardothEndConversation_DarkTidesQuest ),
				typeof( MardothKronusConversation_DarkTidesQuest ),
				typeof( MardothVaultConversation_DarkTidesQuest ),
				typeof( NecroRadarConversation_DarkTidesQuest ),
				typeof( ReadAbraxusScrollConversation_DarkTidesQuest ),
				typeof( ReadAbraxusScrollObjective_DarkTidesQuest ),
				typeof( ReanimateMaabusConversation_DarkTidesQuest ),
				typeof( RetrieveAbraxusScrollObjective_DarkTidesQuest ),
				typeof( ReturnToCrystalCaveObjective_DarkTidesQuest ),
				typeof( SecondHorusConversation_DarkTidesQuest ),
				typeof( SpeakCavePasswordObjective_DarkTidesQuest ),
				typeof( UseCallingScrollObjective_DarkTidesQuest ),
				typeof( VaultOfSecretsConversation_DarkTidesQuest ),
				typeof( FindHorusAboutRewardObjective_DarkTidesQuest ),
				typeof( HealConversation_DarkTidesQuest ),
				typeof( HorusRewardConversation_DarkTidesQuest )
			};

		public override Type[] TypeReferenceTable => m_TypeReferenceTable;

		public override object Name =>
				// Dark Tides
				1060095;

		public override object OfferMessage =>
				/* <I>An old man who looks to be 200 years old from the looks
* of his translucently pale and heavily wrinkled skin, turns
* to you and gives you a half-cocked grin that makes you
* feel somewhat uneasy.<BR><BR>
* 
* After a short pause, he begins to speak to you...</I><BR><BR>
* 
* Hmm. What's this?  Another budding Necromancer to join the
* ranks of Evil?  Here... let me take a look at you...  Ah
* yes...  Very Good! I sense the forces of evil are strong
* within you, child – but you need training so that you can
* learn to focus your skills against those aligned against
* our cause.  You are destined to become a legendary
* Necromancer - with the proper training, that only I can
* give you.<BR><BR>
* 
* <I>Mardoth pauses just long enough to give you a wide,
* skin-crawling grin.</I><BR><BR>
* 
* Let me introduce myself. I am Mardoth, the guildmaster of
* the Necromantic Brotherhood.  I have taken it upon myself
* to train anyone willing to learn the dark arts of Necromancy.
* The path of destruction, decay and obliteration is not an
* easy one.  Only the most evil and the most dedicated can
* hope to master the sinister art of death.<BR><BR>
* 
* I can lend you training and help supply you with equipment –
* in exchange for a few services rendered by you, of course.
* Nothing major, just a little death and destruction here and
* there - the tasks should be easy as a tasty meat pie for one
* as treacherous and evil as yourself.<BR><BR>
* 
* What do you say?  Do we have a deal?
*/
				1060094;

		public override TimeSpan RestartDelay => TimeSpan.MaxValue;
		public override bool IsTutorial => true;

		public override int Picture => 0x15B5;

		public DarkTidesQuest(PlayerMobile from) : base(from)
		{
		}

		// Serialization
		public DarkTidesQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation(new NecroAcceptConversation_DarkTidesQuest());
		}

		public override bool IgnoreYoungProtection(Mobile from)
		{
			if (from is SummonedPaladin)
			{
				return true;
			}

			return base.IgnoreYoungProtection(from);
		}

		public static bool HasLostCallingScroll(Mobile from)
		{
			var pm = from as PlayerMobile;

			if (pm == null)
			{
				return false;
			}

			var qs = pm.Quest;

			if (qs is DarkTidesQuest)
			{
				if (qs.IsObjectiveInProgress(typeof(FindMardothAboutKronusObjective_DarkTidesQuest)) || qs.IsObjectiveInProgress(typeof(FindWellOfTearsObjective_DarkTidesQuest)) || qs.IsObjectiveInProgress(typeof(UseCallingScrollObjective_DarkTidesQuest)))
				{
					var pack = from.Backpack;

					return (pack == null || pack.FindItemByType(typeof(KronusScroll)) == null);
				}
			}

			return false;
		}
	}

	#region Conversation

	public class NecroAcceptConversation_DarkTidesQuest : QuestConversation
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

		public NecroAcceptConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			var bag = Mardoth.GetNewContainer();

			bag.DropItem(new DarkTidesHorn());

			System.From.AddToBackpack(bag);

			System.AddConversation(new ReanimateMaabusConversation_DarkTidesQuest());
		}
	}

	public class ReanimateMaabusConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* Excellent choice, young apprentice of evil!<BR><BR>
* 
* I will not waste our time with pleasantries.  There is much work
* to be done – especially in light of the recent Paladin ambushes
* that we have suffered.  The necromantic brotherhood is working
* towards the summoning of the elder daemon Kronus, who will rise
* from the Well of Tears to help us finally crush the Paladin forces
* that have plagued our lands for so long now.<BR><BR>
* 
* To summon Kronus, we must energize the Well of Tears with a series
* of dark rituals.  Unfortunately the rituals needed to sufficiently
* energize the Well of Tears have been lost to us.  Your task will be
* to recover one of the ritual scrolls needed for the summoning.<BR><BR>
*  
* You will need to find the corpse of the Arch Necromancer Maabus, which
* has been laid to rest in the tomb of elders.  We believe his spirit may
* have memory of where we may find the scrolls needed for the summoning.
* You will need to awaken him from the slumber of death, using your
* Animate Dead spell, of course.<BR><BR>
* 
* To reach the tomb, step onto the magical teleporter just to the
* <a href = "?ForceTopic13">West</a> of where I am standing.<BR><BR>
* 
* Once you have been teleported, follow the path, which will lead you to
* the tomb of Maabus.<BR><BR>One more thing before you go:<BR><BR>
* 
* Should you get into trouble out there or should you lose your way, do
* not worry. I have also given you a magical horn - a <I>Horn of Retreat</I>.
* Play the horn at any time to open a magical gateway that leads back to this
* tower.<BR><BR>
* 
* Should your horn run out of <a href = "?ForceTopic83">charges</a>, simply
* hand me the horn to have it recharged.<BR><BR>
* 
* Good luck friend.
*/
				1060099;

		private static readonly QuestItemInfo[] m_Info = new QuestItemInfo[]
			{
				new QuestItemInfo( 1026153, 6178 ), // teleporter
				new QuestItemInfo( 1049117, 4036 ), // Horn of Retreat
				new QuestItemInfo( 1048032, 3702 )  // a bag
			};

		public override QuestItemInfo[] Info => m_Info;

		public ReanimateMaabusConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindMaabusTombObjective_DarkTidesQuest());
		}
	}

	public class MaabasConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Maabus emits an ear-crawling screech as his body reanimates.
* He turns and angrily screams at you</I>:<BR><BR>
* 
* YOU INFIDEL!  HOW DARE YOU AWAKEN MAABUS!?!<BR><BR>
* 
* <I>Maabus continues to scream at you angrily for some time.
* As he settles down, you explain to him the purpose of your visit.
* Once you explain that you are on a quest to summon the elder daemon
* Kronus, Maabus begins to cooperate, and begins to speak in a more
* reasonable tone</I>:<BR><BR>
* 
* Well, why didn’t you say so?  If you’re going to raise Kronus from
* the Well of Tears, you must first complete a long series of dark
* rituals.  I once owned one of the scrolls needed for the summoning,
* but alas it was lost to me when I lost my life to a cowardly Paladin
* ambush near the Paladin city of Light.  They would have probably
* hidden the scroll in their precious crystal cave near the city.<BR><BR>
* 
* There is a teleporter in the corner of this tomb.  It will transport
* you near the crystal cave at which I believe one of the calling scrolls
* is hidden.  Good luck.<BR><BR>
* 
* <I>Maabus' body slumps back into the coffinas your magic expires</I>.
*/
				1060103;

		private static readonly QuestItemInfo[] m_Info = new QuestItemInfo[]
			{
				new QuestItemInfo( 1026153, 6178 ) // teleporter
			};

		public override QuestItemInfo[] Info => m_Info;

		public MaabasConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindCrystalCaveObjective_DarkTidesQuest());
		}
	}

	public class HorusConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* <I>An old man, dressed in slightly tattered armor, whom you recognize
* to be a Paladin stands before the Crystal Cave staring blankly into
* the space in front of him.  As he begins to speak to you, you realize
* this man is blind.  You attempt to persuade the blind man that you are
* a Paladin seeking to inspect the scroll of calling...</I><BR><BR>
* 
* Greetings traveler!<BR><BR>
* 
* You seek entrance to the Crystal Cave, home of the Calling Scroll?  Hmm.
* You reak of death and decay, brother.  You reak of death like a Necromancer,
* but yet you claim to be a Paladin in hopes that I will grant thee passage
* into the cave?<BR><BR>
* 
* Please don’t think ill of me for this, but I’m just a blind, old man looking
* to keep the brotherhood of Paladins safe from the clutches of the elder daemon
* Kronus.  The Necromancers have been after this particular scroll for quite some
* time, so we must take all the security precautions we can.<BR><BR>
* 
* Before I can let you pass into the Crystal Cave, you must speak to me the secret
* word that is kept in the Scroll of Abraxus in the Vault of Secrets at the Paladin
* city of Light.  It’s the only way that I can be sure you are who you claim to be,
* since Necromancers cannot enter the Vault due to powerful protective magic that
* the brotherhood has blessed the vault with.
*/
				1060105;

		public HorusConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindMardothAboutVaultObjective_DarkTidesQuest());
		}
	}

	public class MardothVaultConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* <I>Mardoth looks at you expectantly until you tell him that you failed
* to retrieve the scroll...</I><BR><BR>
* 
* You failed?  Very unfortunate...  So now you must find your way into
* the paladin’s Vault of Secrets, eh?  Well, you won't be able to get in
* – there is a powerful magic aura that protects the Vault from all
* Necromancers.  We simply cannot enter.  However, that's not to say you
* familiar spirit can't.<BR><BR>
* 
* <I>Mardoth grins with obvious satisfaction
* as he explains the details of the <a href="?ForceTopic127">Summon
* Familiar</a> spell to you...</I>, which will allow you to summon a
* scavenging Horde Minion to steal the scroll.<BR><BR>
* 
* Very well.  You are prepared to go.  Take the teleporter just to the
* <a href = "?ForceTopic13">West</a> of where I am standing to transport
* to the Paladin city of Light.  Once you have arrived in the city, follow
* the road of glowing runes to the Vault of Secrets.  You know what to do.
*/
				1060107;

		public MardothVaultConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindCityOfLightObjective_DarkTidesQuest());
		}
	}

	public class VaultOfSecretsConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* You have arrived in the Vault of Secrets.  You can feel the
* protective magic in this place restricting you, making you
* feel nearly claustrophobic.<BR><BR>
* 
* Just ahead of you and out of your reach, you see a collection
* of scrolls and books, one of them being entitled
* 'Scroll of Abraxus' .  You can only assume that this scroll
* holds the current password required to enter the Crystal Cave.<BR><BR>
* 
* This would be a good opportunity to <a href="?ForceTopic127">summon
* your familiar</a>.  Since your familiar is not a Necromancer, it
* will not be affected by the anti-magic aura that surrounds the Vault.<BR><BR>
* 
* Summon your familiar with the <a href="?ForceTopic127">Summon Familiar</a> spell.
*/
				1060110;

		private static readonly QuestItemInfo[] m_Info = new QuestItemInfo[]
			{
				new QuestItemInfo( 1023643, 8787 ) // spellbook
			};

		public override QuestItemInfo[] Info => m_Info;

		public VaultOfSecretsConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FetchAbraxusScrollObjective_DarkTidesQuest());
		}
	}

	public class ReadAbraxusScrollConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* You have obtained the Scroll of Abraxus, which contains the secret
* password needed to gain passage into the Crystal Cave where the
* Scroll of Calling is kept.  Read the scroll (double click) and
* figure out the password.<BR><BR>
* 
* Once you have the password, return to the Crystal Cave and speak
* the password to the guard.<BR><BR>
* 
* If you do not know the way to the Crystal Cave from the Paladin City,
* you can use the magic teleporter located just outside of the vault.
*/
				1060114;

		public ReadAbraxusScrollConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new ReadAbraxusScrollObjective_DarkTidesQuest());
		}
	}

	public class SecondHorusConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* Very well Paladin, you have proven to me your identity.
* I grant thee passage.<BR><BR>
* 
* Be careful, however – I’ve heard that the cave has been
* infested with a vermin of some sort.  Our High Lord
* Melkeer was supposed to send some troops to clear the
* vermin out of the cave, but that was last week already.
* I fear that he forgot.<BR><BR>
* 
* If you can find it in your goodness to dispose of at
* least 5 of those vermin in there, I shall reward your
* efforts.  If however you are too busy, and I would
* understand if you were, don’t bother with the vermin.<BR><BR>
* 
* You may now pass through the energy barrier to enter the
* Crystal Cave.   Take care honorable Paladin soul.
* Walk in the light my friend.
*/
				1060118;

		public SecondHorusConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindCallingScrollObjective_DarkTidesQuest());
		}
	}

	public class HealConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* You've just slain a creature.  Now is a good time to learn how
* to heal yourself as a Necromancer.<BR><BR>
* 
* As a follower of the dark path, you are able to recover lost
* hitpoints by communing with the spirit world via the skill
* <a href="?ForceTopic133">Spirit Speak</a>.  Learn more about it now,
* <a href="?ForceTopic73">in the codex of Wisdom</a>.
*/
				1061610;

		public HealConversation_DarkTidesQuest()
		{
		}
	}

	public class HorusRewardConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* I thank you for going out of your way to clean out some
* of the vermin in that cave – here is your reward: a bag
* containing 500 gold coins plus a strange and magical artifact
* that should come in handy in your travels.<BR><BR>
* 
* Take care young Paladin!
*/
				1060717;

		public override bool Logged => false;

		public HorusRewardConversation_DarkTidesQuest()
		{
		}
	}

	public class LostCallingScrollConversation_DarkTidesQuest : QuestConversation
	{
		private bool m_FromMardoth;

		public override object Message
		{
			get
			{
				if (m_FromMardoth)
				{
					/* You return without the scroll of Calling?  I'm afraid that
					 * won't do.  You must return to the Crystal Cave and fetch
					 * another scroll.  Use the teleporter to the West of me to
					 * get there.  Return here when you have the scroll.  Do not 
					 * fail me this time, young apprentice of evil.
					 */
					return 1062058;
				}
				else // from well of tears
				{
					/* You have arrived at the well, but no longer have the scroll
					 * of calling.  Use Mardoth's teleporter to return to the
					 * Crystal Cave and fetch another scroll from the box.
					 */
					return 1060129;
				}
			}
		}

		public override bool Logged => false;

		public LostCallingScrollConversation_DarkTidesQuest(bool fromMardoth)
		{
			m_FromMardoth = fromMardoth;
		}

		// Serialization
		public LostCallingScrollConversation_DarkTidesQuest()
		{
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_FromMardoth = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_FromMardoth);
		}
	}

	public class MardothKronusConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* You have returned with the scroll!  I knew I could count on you.
* You can now perform the rite of calling at the Well of Tears.
* This ritual will help charge the Well to prepare for the coming
* of Kronus.   You are prepared to do your part young Necromancer!<BR><BR>
* 
* Just outside of this tower, you will find a path lined with red
* lanterns.  Follow this path to get to the Well of Tears.  Once
* you have arrived at the Well, use the scroll to perform the
* ritual of calling.  Performing the rite will empower the well
* and bring us that much closer to the arrival of Kronus.<BR><BR>
* 
* Once you have completed the ritual, return here for your
* promised reward.
*/
				1060121;

		public MardothKronusConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindWellOfTearsObjective_DarkTidesQuest());
		}
	}

	public class MardothEndConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* You have done as I asked... I knew I could count on you from
* the moment you walked in here!<BR><BR>
* 
* The forces of evil are strong within you.  You will become
* a great Necromancer in this life - perhaps even the greatest.<BR><BR>
* 
* My work for you is done here.  I release you from my service
* to go into the world and fight for our cause...<BR><BR>
* 
* Oh...I almost forgot - your reward.  Here is a magical
* weapon and 2000 gold for you, in the form of a check. Don't
* spend it all in one place though, eh?<BR><BR>
* 
* Actually, before you can spend any of it at all, you will
* have to <a href="?ForceTopic86">cash the check</a> at the
* nearest bank.  Shopkeepers never accept checks for payment,
* they require cash.<BR><BR>
* 
* In your pack, you will find an enchanted sextant.  Use this
* sextant to guide you to the nearest bank.<BR><BR>
* 
* Farewell, and stay true to the ways of the shadow...
*/
				1060133;

		public MardothEndConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.AddObjective(new FindBankObjective_DarkTidesQuest());
		}
	}

	public class BankerConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* <I>The banker smiles at you and greets you in a loud and robust voice...</I><BR><BR>
* 
* Well hello there adventurer! I see you've learned how to cash checks. Wonderful!
* Let me tell you a bit about the banks in this world...<BR><BR>
* 
* Anything that you place into any bank box, can be retrieved from any other
* bank box in the land. For instance, if you place an item into a bank box in
* Britain, it can be retrieved from your bank box in Moonglow or any other city.<BR><BR>
* 
* Bank boxes are very secure. So secure, in fact, that no one can ever get into
* your bank box except for yourself. Security is hard to come by these days,
* but you can trust in the banking system of Britannia! We shall not let you down!<BR><BR>
* 
* I hope to be seeing much more of you as your riches grow! May your bank box overflow
* with the spoils of your adventures.<BR><BR>Farewell adventurer, you are now free to
* explore the world on your own.
*/
				1060137;

		public BankerConversation_DarkTidesQuest()
		{
		}

		public override void OnRead()
		{
			System.Complete();
		}
	}

	public class NecroRadarConversation_DarkTidesQuest : QuestConversation
	{
		public override object Message =>
				/* If you are leaving the tower, you should learn about the Radar Map.<BR><BR>
* 
* The Radar Map (or Overhead View) can be opened by pressing 'ALT-R'
* on your keyboard. It shows your immediate surroundings from a bird's
* eye view.<BR><BR>Pressing ALT-R twice, will enlarge the Radar Map a
* little. Use the Radar Map often as you travel throughout the world
* to familiarize yourself with your surroundings.
*/
				1061692;

		public override bool Logged => false;

		public NecroRadarConversation_DarkTidesQuest()
		{
		}
	}

	#endregion

	#region Objective

	public class AnimateMaabusCorpseObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Re-animate the corpse of Maabus using your <a href="?ForceTopic112">Animate Dead</a>
* spell and question him about the Kronus rituals.
*/
				1060102;

		private static readonly QuestItemInfo[] m_Info = new QuestItemInfo[]
			{
				new QuestItemInfo( 1023643, 8787 ) // spellbook
			};

		public override QuestItemInfo[] Info => m_Info;

		public AnimateMaabusCorpseObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new MaabasConversation_DarkTidesQuest());
		}
	}

	public class FindCrystalCaveObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Take the teleporter in the corner of Maabus' tomb to
* the crystal cave where the calling scroll is kept.
*/
				1060104;

		public FindCrystalCaveObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new HorusConversation_DarkTidesQuest());
		}
	}

	public class FindMardothAboutVaultObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Infiltrate the city of the Paladins and figure out a way into
* the Vault. See Mardoth for help with this objective.
*/
				1060106;

		public FindMardothAboutVaultObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new MardothVaultConversation_DarkTidesQuest());
		}
	}

	public class FindMaabusTombObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Step onto the teleporter near Mardoth and follow the path
* of glowing runes to the tomb of Maabus.
*/
				1060124;

		public FindMaabusTombObjective_DarkTidesQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(2024, 1240, -90), 3))
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new FindMaabusCorpseObjective_DarkTidesQuest());
		}
	}

	public class FindMaabusCorpseObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* This is the tomb of Maabus.  Enter within and find
* the corpse of the ancient necromancer.
*/
				1061142;

		public FindMaabusCorpseObjective_DarkTidesQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(2024, 1223, -90), 3))
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new AnimateMaabusCorpseObjective_DarkTidesQuest());
		}
	}

	public class FindCityOfLightObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Use the teleporter near Mardoth to be transported
* to the Paladin City of Light.
*/
				1060108;

		public FindCityOfLightObjective_DarkTidesQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(1076, 519, -90), 5))
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new FindVaultOfSecretsObjective_DarkTidesQuest());
		}
	}

	public class FindVaultOfSecretsObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Follow the road paved with glowing runes to
* find the Vault of Secrets.  Be careful not
* to give yourself away as a Necromancer while
* in the city.
*/
				1060109;

		private static readonly QuestItemInfo[] m_Info = new QuestItemInfo[]
			{
				new QuestItemInfo( 1023676, 3679 ) // glowing rune
			};

		public override QuestItemInfo[] Info => m_Info;

		public FindVaultOfSecretsObjective_DarkTidesQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(1072, 455, -90), 1))
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddConversation(new VaultOfSecretsConversation_DarkTidesQuest());
		}
	}

	public class FetchAbraxusScrollObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				// <a href="?ForceTopic127">Summon your Horde Minion familiar</a> to fetch the scroll for you.
				1060196;

		public FetchAbraxusScrollObjective_DarkTidesQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(1076, 450, -84), 5))
			{
				var hmf = Spells.Necromancy.SummonFamiliarSpell.Table[System.From] as HordeMinionFamiliar;

				if (hmf != null && hmf.InRange(System.From, 5) && hmf.TargetLocation == null)
				{
					System.From.SendLocalizedMessage(1060113); // You instinctively will your familiar to fetch the scroll for you.
					hmf.TargetLocation = new Point2D(1076, 450);
				}
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new RetrieveAbraxusScrollObjective_DarkTidesQuest());
		}
	}

	public class RetrieveAbraxusScrollObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Double click your Horde Minion to open his pack and retrieve
* the Scroll of Abraxus that he looted for you.
*/
				1060199;

		public RetrieveAbraxusScrollObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new ReadAbraxusScrollConversation_DarkTidesQuest());
		}
	}

	public class ReadAbraxusScrollObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Find the Crystal Cave password by reading (double click)
* the golden scroll entitled "Scroll of Abraxus" that you
* got from your familiar..
*/
				1060125;

		public ReadAbraxusScrollObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective(new ReturnToCrystalCaveObjective_DarkTidesQuest());
		}
	}

	public class ReturnToCrystalCaveObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Now that you have the password, return to the Crystal Cave
* to speak with the guard there.  Use the teleporter outside
* of the vault to get there if necessary.
*/
				1060115;

		private static readonly QuestItemInfo[] m_Info = new QuestItemInfo[]
			{
				new QuestItemInfo( 1026153, 6178 ) // teleporter
			};

		public override QuestItemInfo[] Info => m_Info;

		public ReturnToCrystalCaveObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddObjective(new SpeakCavePasswordObjective_DarkTidesQuest());
		}
	}

	public class SpeakCavePasswordObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Speak the secret word that you read in the scroll
* stolen from the Vault to Horus the guard, using
* his <a href="?ForceTopic90">context menu</a>.
*/
				1060117;

		public SpeakCavePasswordObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new SecondHorusConversation_DarkTidesQuest());
		}
	}

	public class FindCallingScrollObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Enter the Crystal Cave and find the Scroll of Calling.
* The barrier will now allow you to pass.
*/
				1060119;

		private int m_SkitteringHoppersKilled;
		private bool m_HealConversationShown;
		private bool m_SkitteringHoppersDisposed;

		public FindCallingScrollObjective_DarkTidesQuest()
		{
		}

		public override bool IgnoreYoungProtection(Mobile from)
		{
			return !m_SkitteringHoppersDisposed && from is SkitteringHopper;
		}

		public override bool GetKillEvent(BaseCreature creature, Container corpse)
		{
			return !m_SkitteringHoppersDisposed;
		}

		public override void OnKill(BaseCreature creature, Container corpse)
		{
			if (creature is SkitteringHopper)
			{
				if (!m_HealConversationShown)
				{
					m_HealConversationShown = true;
					System.AddConversation(new HealConversation_DarkTidesQuest());
				}

				if (++m_SkitteringHoppersKilled >= 5)
				{
					m_SkitteringHoppersDisposed = true;
					System.AddObjective(new FindHorusAboutRewardObjective_DarkTidesQuest());
				}
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new FindMardothAboutKronusObjective_DarkTidesQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_SkitteringHoppersKilled = reader.ReadEncodedInt();
			m_HealConversationShown = reader.ReadBool();
			m_SkitteringHoppersDisposed = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(m_SkitteringHoppersKilled);
			writer.Write(m_HealConversationShown);
			writer.Write(m_SkitteringHoppersDisposed);
		}
	}

	public class FindHorusAboutRewardObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* You have disposed of the creatures as Horus has asked.
* See him on your way out of the Crystal Cave to claim your reward.
*/
				1060126;

		public FindHorusAboutRewardObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new HorusRewardConversation_DarkTidesQuest());
		}
	}

	public class FindMardothAboutKronusObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* You have obtained the scroll of calling. See Mardoth
* for further instructions.
*/
				1060127;

		public FindMardothAboutKronusObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new MardothKronusConversation_DarkTidesQuest());
		}
	}

	public class FindWellOfTearsObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Follow the red lanterns to the Well of Tears where
* you will perform the calling of Kronus.
*/
				1060128;

		public FindWellOfTearsObjective_DarkTidesQuest()
		{
		}

		private static readonly Rectangle2D m_WellOfTearsArea = new Rectangle2D(2080, 1346, 10, 10);

		private bool m_Inside;

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && m_WellOfTearsArea.Contains(System.From.Location))
			{
				if (DarkTidesQuest.HasLostCallingScroll(System.From))
				{
					if (!m_Inside)
					{
						System.AddConversation(new LostCallingScrollConversation_DarkTidesQuest(false));
					}
				}
				else
				{
					Complete();
				}

				m_Inside = true;
			}
			else
			{
				m_Inside = false;
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new UseCallingScrollObjective_DarkTidesQuest());
		}
	}

	public class UseCallingScrollObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Use the Scroll of Calling (double click) near the
* Well of Tears to charge the waters for the arrival
* of Kronus.
*/
				1060130;

		public UseCallingScrollObjective_DarkTidesQuest()
		{
		}
	}

	public class FindMardothEndObjective_DarkTidesQuest : QuestObjective
	{
		private bool m_Victory;

		public override object Message
		{
			get
			{
				if (m_Victory)
				{
					/* Victory! You have done as Mardoth has asked of you.
					 * Take as much of your foe's loot as you can carry
					 * and return to Mardoth for your reward.
					 */
					return 1060131;
				}
				else
				{
					/* Although you were slain by the cowardly paladin,
					 * you managed to complete the rite of calling as
					 * instructed. Return to Mardoth.
					 */
					return 1060132;
				}
			}
		}

		public FindMardothEndObjective_DarkTidesQuest(bool victory)
		{
			m_Victory = victory;
		}

		// Serialization
		public FindMardothEndObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new MardothEndConversation_DarkTidesQuest());
		}

		public override void ChildDeserialize(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			m_Victory = reader.ReadBool();
		}

		public override void ChildSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0); // version

			writer.Write(m_Victory);
		}
	}

	public class FindBankObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* Use the enchanted sextant in your pack to locate
* the nearest bank.  Go there and speak with the
* Banker.
*/
				1060134;

		public FindBankObjective_DarkTidesQuest()
		{
		}

		public override void CheckProgress()
		{
			if (System.From.Map == Map.Malas && System.From.InRange(new Point3D(2048, 1345, -84), 5))
			{
				Complete();
			}
		}

		public override void OnComplete()
		{
			System.AddObjective(new CashBankCheckObjective_DarkTidesQuest());
		}
	}

	public class CashBankCheckObjective_DarkTidesQuest : QuestObjective
	{
		public override object Message =>
				/* You have arrived at the Bank. <a href="?ForceTopic38">Open your bank box</a>
* and then <a href="?ForceTopic86">cash the check</a> that Mardoth gave you.
*/
				1060644;

		public CashBankCheckObjective_DarkTidesQuest()
		{
		}

		public override void OnComplete()
		{
			System.AddConversation(new BankerConversation_DarkTidesQuest());
		}
	}

	#endregion
}