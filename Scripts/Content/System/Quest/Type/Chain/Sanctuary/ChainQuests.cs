using Server.Engines.ChainQuests.Mobiles;
using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.ChainQuests.Definitions
{
	public class BrokenShaft : ChainQuest
	{
		public BrokenShaft()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074018; // Broken Shaft
			Description = 1074112; // What do humans know of archery? Humans can barely shoot straight. Why, your efforts are absurd. In fact, I will make a wager - if these so called human arrows I've heard about are really as effective and innovative as human braggarts would have me believe, then I'll trade you something useful.  I might even teach you something of elven craftsmanship.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(Arrow), 1023902)); // arrow

			Rewards.Add(ItemReward.FletchingSatchel);
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Beotham"), new Point3D(6285, 114, 0), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Beotham"), new Point3D(6285, 114, 0), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Danoel"), new Point3D(6282, 116, 0), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Danoel"), new Point3D(6282, 116, 0), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Tallinin"), new Point3D(6279, 122, 0), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Tallinin"), new Point3D(6279, 122, 0), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Tiana"), new Point3D(6257, 112, -10), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Tiana"), new Point3D(6257, 112, -10), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "LorekeeperOolua"), new Point3D(6250, 124, 0), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "LorekeeperOolua"), new Point3D(6250, 124, 0), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "LorekeeperRollarn"), new Point3D(6244, 110, 0), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "LorekeeperRollarn"), new Point3D(6244, 110, 0), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Dallid"), new Point3D(6277, 104, -10), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Dallid"), new Point3D(6277, 104, -10), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Canir"), new Point3D(6274, 130, 0), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Canir"), new Point3D(6274, 130, 0), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Yellienir"), new Point3D(6257, 126, 0), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Yellienir"), new Point3D(6257, 126, 0), Map.Felucca);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "ElderOnallan"), new Point3D(6258, 108, -10), Map.Trammel);
			PutSpawner(new Spawner(1, 5, 10, 0, 0, "ElderOnallan"), new Point3D(6258, 108, -10), Map.Felucca);
		}
	}

	public class BendingTheBow : ChainQuest
	{
		public BendingTheBow()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074019; // Bending the Bow
			Description = 1074113; // Human craftsmanship! Ha! Why, take an elven bow. It will last for a lifetime, never break and always shoot an arrow straight and true. Can't say the same for a human, can you? Bring me some of these human made bows, and I will show you.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(Bow), 1025041)); // bow

			Rewards.Add(ItemReward.FletchingSatchel);
		}
	}

	public class ArmsRace : ChainQuest
	{
		public ArmsRace()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074020; // Arms Race
			Description = 1074114; // Leave it to a human to try and improve upon perfection. To take a bow and turn it into a mechanical contraption like a crossbow. I wish to see more of this sort of "invention". Fetch for me a crossbow, human.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(Crossbow), 1023919)); // crossbow

			Rewards.Add(ItemReward.FletchingSatchel);
		}
	}

	public class ImprovedCrossbows : ChainQuest
	{
		public ImprovedCrossbows()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074021; // Improved Crossbows
			Description = 1074115; // How lazy is man! You cannot even be bothered to pull your own drawstring and hold an arrow ready? You must invent a device to do it for you? I cannot understand, but perhaps if I examine a heavy crossbow for myself, I will see their appeal. Go and bring me such a device and I will repay your meager favor.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(HeavyCrossbow), 1025116)); // heavy crossbow

			Rewards.Add(ItemReward.FletchingSatchel);
		}
	}

	public class BuildingTheBetterCrossbow : ChainQuest
	{
		public BuildingTheBetterCrossbow()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074022; // Building the Better Crossbow
			Description = 1074116; // More is always better for a human, eh? Take these repeating crossbows. What sort of mind invents such a thing? I must look at it more closely. Bring such a contraption to me and you'll receive a token for your efforts.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(RepeatingCrossbow), 1029923)); // repeating crossbow

			Rewards.Add(ItemReward.FletchingSatchel);
		}
	}

	public class InstrumentOfWar : ChainQuest
	{
		public InstrumentOfWar()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074055; // Instrument of War
			Description = 1074149; // Pathetic, this human craftsmanship! Take their broadswords - overgrown butter knives, in reality. No, I cannot do them justice - you must see for yourself. Bring me broadswords and I will demonstrate their feebleness.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(12, typeof(Broadsword), 1023934)); // broadsword

			Rewards.Add(ItemReward.BlacksmithSatchel);
		}
	}

	public class TheShield : ChainQuest
	{
		public TheShield()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074054; // The Shield
			Description = 1074148; // I doubt very much a human shield would stop a good stout elven arrow. You doubt me? I will show you - get me some of these heater shields and I will piece them with sharp elven arrows!
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(HeaterShield), 1027030)); // heater shield

			Rewards.Add(ItemReward.BlacksmithSatchel);
		}
	}

	public class MusicToMyEars : ChainQuest
	{
		public MusicToMyEars()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074023; // Music to my Ears
			Description = 1074117; // You think you know something of music? Laughable! Take your lap harp. Crude, indelicate instruments that make a noise not unlike the wailing of a choleric child or a dying cat. I will show you - bring lap harps, and I will demonstrate.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(LapHarp), 1023762)); // lap harp

			Rewards.Add(ItemReward.CarpentrySatchel);
		}
	}

	public class TheGlassEye : ChainQuest
	{
		public TheGlassEye()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074050; // The Glass Eye
			Description = 1074144; // Humans are so pathetically weak, they must be augmented by glass and metal! Imagine such a thing! I must see one of these spyglasses for myself, to understand the pathetic limits of human sight!
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(Spyglass), 1025365)); // spyglass

			Rewards.Add(ItemReward.TinkerSatchel);
		}
	}

	public class LazyHumans : ChainQuest
	{
		public LazyHumans()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074024; // Lazy Humans
			Description = 1074118; // Human fancy knows no bounds!  It's pathetic that they are so weak that they must create a special stool upon which to rest their feet when they recline!  Humans don't have any clue how to live.  Bring me some of these foot stools to examine and I may teach you something worthwhile.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(FootStool), 1022910)); // foot stool

			Rewards.Add(ItemReward.CarpentrySatchel);
		}
	}

	public class InventiveTools : ChainQuest
	{
		public InventiveTools()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074048; // Inventive Tools
			Description = 1074142; // Bring me some of these tinker's tools! I am certain, in the hands of an elf, they will fashion objects of ingenuity and delight that will shame all human invention! Hurry, do this quickly and I might deign to show you my skill.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(TinkerTools), 1027868)); // tinker's tools

			Rewards.Add(ItemReward.TinkerSatchel);
		}
	}

	public class PixieDustToDust : ChainQuest
	{
		public PixieDustToDust()
		{
			Activated = true;
			Title = 1073661; // Pixie dust to dust
			Description = 1073700; // Is there anything more foul than a pixie? They have cruel eyes and a mind for mischief, I say. I don't care if some think they're cute -- I say kill them and let the Avatar sort them out. In fact, if you were to kill a few pixies, I'd make sure you had a few coins to rub together, if you get my meaning.
			RefusalMessage = 1073733; // Perhaps you'll change your mind and return at some point.
			InProgressMessage = 1073741; // There's too much cuteness in the world -- kill those pixies!

			Objectives.Add(new KillObjective(10, new Type[] { typeof(Pixie) }, "pixies"));

			Rewards.Add(ItemReward.LargeBagOfTreasure);
		}
	}

	public class AnImpressivePlaid : ChainQuest
	{
		public AnImpressivePlaid()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074044; // An Impressive Plaid
			Description = 1074138; // I do not believe humans are so ridiculous as to wear something called a "kilt". Bring for me some of these kilts, if they truly exist, and I will offer you meager reward.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(Kilt), 1025431)); // kilt

			Rewards.Add(ItemReward.TailorSatchel);
		}
	}

	public class ANiceShirt : ChainQuest
	{
		public ANiceShirt()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074045; // A Nice Shirt
			Description = 1074139; // Humans call that a fancy shirt? I would wager the ends are frayed, the collar worn, the buttons loosely stitched. Bring me fancy shirts and I will demonstrate the many ways in which they are inferior.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(FancyShirt), 1027933)); // fancy shirt

			Rewards.Add(ItemReward.TailorSatchel);
		}
	}

	public class LeatherAndLace : ChainQuest
	{
		public LeatherAndLace()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074047; // Leather and Lace
			Description = 1074141; // No self respecting elf female would ever wear a studded bustier! I will prove it - bring me such clothing and I will show you how ridiculous they are!
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(StuddedBustierArms), 1027180)); // studded bustier

			Rewards.Add(ItemReward.TailorSatchel);
		}
	}

	public class FeyHeadgear : ChainQuest
	{
		public FeyHeadgear()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074043; // Fey Headgear
			Description = 1074137; // Humans do not deserve to wear a thing such as a flower garland. Help me prevent such things from falling into the clumsy hands of humans -- bring me flower garlands!
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(FlowerGarland), 1028965)); // flower garland

			Rewards.Add(ItemReward.TailorSatchel);
		}
	}

	public class NewCloak : ChainQuest
	{
		public NewCloak()
		{
			Activated = true;
			Title = 1074684; // New Cloak
			Description = 1074685; // I have created a masterpiece!  And all I need to finish it off is the soft fur of a wolf.  But not just ANY wolf -- oh no, no, that wouldn't do.  I've heard tales of a mighty beast, Grobu, who is bonded to the leader of the troglodytes.  Only Grobu's fur will do.  Will you retrieve it for me?
			RefusalMessage = 1074655; // Perhaps I thought too highly of you.
			InProgressMessage = 1074686; // I've told you all I know of the creature.  Until you return with Grobu's fur I can't finish my cloak.
			CompletionMessage = 1074687; // Ah! So soft, so supple.  What a wonderful texture.  Here you are ... my thanks.

			Objectives.Add(new CollectObjective(1, typeof(GrobusFur), "Grobu's Fur"));

			Rewards.Add(ItemReward.TailorSatchel);
		}
	}

	public class ADishBestServedCold : ChainQuest
	{
		public ADishBestServedCold()
		{
			Activated = true;
			Title = 1072372; // A Dish Best Served Cold
			Description = 1072657; // *mutter* I'll have my revenge.  Oh!  You there.  Fancy some orc extermination?  I despise them all.  Bombers, brutes -- you name it, if it's orcish I want it killed.
			RefusalMessage = 1072667; // Hrmph.  Well maybe another time then.
			InProgressMessage = 1072668; // Shouldn't you be slaying orcs?

			Objectives.Add(new KillObjective(10, new Type[] { typeof(Orc) }, "orcs", new QuestArea(1074807, "Sanctuary"))); // Sanctuary
			Objectives.Add(new KillObjective(5, new Type[] { typeof(OrcBomber) }, "orc bombers", new QuestArea(1074807, "Sanctuary"))); // Sanctuary
			Objectives.Add(new KillObjective(3, new Type[] { typeof(OrcBrute) }, "orc brutes", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.BagOfTreasure);
		}
	}

	public class ArchEnemies : ChainQuest
	{
		public ArchEnemies()
		{
			Activated = true;
			Title = 1073085; // Arch Enemies
			Description = 1073575; // Vermin! They get into everything! I told the boy to leave out some poisoned cheese -- and they shot him. What else can I do? Unless…these ratmen are skilled with a bow, but I'd lay a wager you're better, eh? Could you skin a few of the wretches for me?
			RefusalMessage = 1073580; // I hope you'll reconsider. Until then, farwell.
			InProgressMessage = 1073595; // I don't see 10 tails from Ratman Archers on your belt -- and until I do, no reward for you.

			Objectives.Add(new KillObjective(10, new Type[] { typeof(RatmanArcher) }, "ratman archers"));

			Rewards.Add(ItemReward.BagOfTreasure);
		}
	}

	public class Vermin : ChainQuest
	{
		public Vermin()
		{
			Activated = true;
			Title = 1072995; // Vermin
			Description = 1073029; // You've got to help me out! Those ratmen have been causing absolute havok around here.  Kill them off before they destroy my land.  I'll pay you if you kill off twelve of those dirty rats.
			RefusalMessage = 1072270; // Well, okay. But if you decide you are up for it after all, c'mon back and see me.
			InProgressMessage = 1072271; // You're not quite done yet.  Get back to work!

			Objectives.Add(new KillObjective(12, new Type[] { typeof(Ratman) }, "ratmen"));

			Rewards.Add(ItemReward.BagOfTrinkets);
		}
	}

	public class MougGuurMustDie : ChainQuest
	{
		public override Type NextQuest => typeof(LeaderOfThePack);

		public MougGuurMustDie()
		{
			Activated = true;
			Title = 1072368; // Moug-Guur Must Die
			Description = 1072561; // You there!  Yes, you.  Kill Moug-Guur, the leader of the orcs in this depressing place, and I'll make it worth your while.
			RefusalMessage = 1072571; // Fine. It's no skin off my teeth.
			InProgressMessage = 1072572; // Small words.  Kill Moug-Guur.  Go.  Now!
			CompletionMessage = 1072573; // You're better than I thought you'd be.  Not particularly bad, but not entirely inept.

			Objectives.Add(new KillObjective(1, new Type[] { typeof(MougGuur) }, "Moug-Guur", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.BagOfTreasure);
		}
	}

	public class LeaderOfThePack : ChainQuest
	{
		public override Type NextQuest => typeof(SayonaraSzavetra);
		public override bool IsChainTriggered => true;

		public LeaderOfThePack()
		{
			Activated = true;
			Title = 1072560; // Leader of the Pack
			Description = 1072574; // Well now that Moug-Guur is no more -- and I can't say I'm weeping for his demise -- it's time for the ratmen to experience a similar loss of leadership.  Slay Chiikkaha.  In return, I'll satisfy your greed temporarily.
			RefusalMessage = 1072575; // Alright, if you'd rather not, then run along and do whatever worthless things you do when I'm not giving you direction.
			InProgressMessage = 1072576; // How difficult is this?  The rats live in the tunnels.  Go into the tunnels and find the biggest, meanest rat and execute him.  Loitering around here won't get the task done.
			CompletionMessage = 1072577; // It's about time!  Could you have taken longer?

			Objectives.Add(new KillObjective(1, new Type[] { typeof(Chiikkaha) }, "Chiikkaha", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.BagOfTreasure);
		}
	}

	public class SayonaraSzavetra : ChainQuest
	{
		public override bool IsChainTriggered => true;

		public SayonaraSzavetra()
		{
			Activated = true;
			Title = 1072375; // Sayonara, Szavetra
			Description = 1072578; // Hmm, maybe you aren't entirely worthless.  I suspect a demoness of Szavetra's calibre will tear you apart ...  We might as well find out.  Kill the succubus, yada yada, and you'll be richly rewarded.
			RefusalMessage = 1072579; // Hah!  I knew you couldn't handle it.
			InProgressMessage = 1072581; // Hahahaha!  I can see the fear in your eyes.  Pathetic.  Szavetra is waiting for you.
			CompletionMessage = 1072582; // Amazing!  Simply astonishing ... you survived.  Well, I supposed I should indulge your avarice with a reward.

			Objectives.Add(new KillObjective(1, new Type[] { typeof(Szavetra) }, "Szavetra", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.Strongbox);
		}
	}

	public class TappingTheKeg : ChainQuest
	{
		public TappingTheKeg()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074037; // Tapping the Keg
			Description = 1074131; // I have acquired a barrel of human brewed beer. I am loathe to drink it, but how else to prove how inferior it is? I suppose I shall need a barrel tap to drink. Go, bring me a barrel tap quickly, so I might get this over with.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(BarrelTap), 1024100)); // barrel tap

			Rewards.Add(ItemReward.TinkerSatchel);
		}
	}

	public class WaitingToBeFilled : ChainQuest
	{
		public WaitingToBeFilled()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074036; // Waiting to be Filled
			Description = 1074130; // The only good thing I can say about human made bottles is that they are empty and may yet still be filled with elven wine. Go now, fetch a number of empty bottles so that I might save them from the fate of carrying human-made wine.
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(20, typeof(Bottle), 1023854)); // empty bottle

			Rewards.Add(ItemReward.TinkerSatchel);
		}
	}

	public class BreezesSong : ChainQuest
	{
		public BreezesSong()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1074052; // Breeze's Song
			Description = 1074146; // I understand humans cruely enslave the very wind to their selfish whims! Fancy wind chimes, what a monstrous idea! You must bring me proof of this terrible depredation - hurry, bring me wind chimes!
			RefusalMessage = 1074063; // Fine then, I'm shall find another to run my errands then.
			InProgressMessage = 1074064; // Hurry up! I don't have all day to wait for you to bring what I desire!
			CompletionMessage = 1074065; // These human made goods are laughable! It offends so -- I must show you what elven skill is capable of!

			Objectives.Add(new CollectObjective(10, typeof(FancyWindChimes), 1030291)); // fancy wind chimes

			Rewards.Add(ItemReward.TinkerSatchel);
		}
	}

	public class ProofOfTheDeed : ChainQuest
	{
		public ProofOfTheDeed()
		{
			Activated = true;
			Title = 1072339; // Proof of the Deed
			Description = 1072340; // These human vermin must be erradicated!  They despoil fair Sosaria with their every footfall upon her soil, every exhalation of breath upon her pristine air.  Prove yourself an ally of Sosaria and bring me 20 human ears as proof of your devotion to our cause.
			RefusalMessage = 1072342; // Do you find the task distasteful?  Are you too weak to shoulder the duty of cleansing Sosaria?  So be it.
			InProgressMessage = 1072343; // Well, where is the proof of your deed?  I will honor your actions when you have brought me the ears of the human scum.
			CompletionMessage = 1072344; // Ah, well done.  You have chosen the path of duty and fulfilled your task with honor.

			Objectives.Add(new CollectObjective(20, typeof(SeveredHumanEars), 1032591)); // severed human ears

			Rewards.Add(ItemReward.BagOfTrinkets);
		}
	}

	public class Marauders : ChainQuest
	{
		public override Type NextQuest => typeof(TheBrainsOfTheOperation);

		public Marauders()
		{
			Activated = true;
			Title = 1072374; // Marauders
			Description = 1072686; // What a miserable place we live in.  Look around you at the changes we've wrought. The trees are sprouting leaves once more and the grass is reclaiming the blood-soaked soil.  Who would have imagined we'd find ourselves here?  Our "neighbors" are anything but friendly and those ogres are the worst of the lot. Maybe you'd be interested in helping our community by disposing of some of our least amiable neighbors?
			RefusalMessage = 1072687; // I quite understand your reluctance.  If you reconsider, I'll be here.
			InProgressMessage = 1072688; // You can't miss those ogres, they're huge and just outside the gates here.

			Objectives.Add(new KillObjective(10, new Type[] { typeof(Ogre) }, "ogres", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.BagOfTreasure);
		}
	}

	public class TheBrainsOfTheOperation : ChainQuest
	{
		public override Type NextQuest => typeof(TheBrawn);
		public override bool IsChainTriggered => true;

		public TheBrainsOfTheOperation()
		{
			Activated = true;
			Title = 1072692; // The Brains of the Operation
			Description = 1072707; // *sigh*  We have so much to do to clean this area up.  Even the fine work you did on those ogres didn't have much of an impact on the community.  It's the ogre lords that direct the actions of the other ogres, let's strike at the leaders and perhaps that will thwart the miserable curs.
			RefusalMessage = 1072708; // Reluctance doesn't become a hero like you.  But, as you wish.
			InProgressMessage = 1072709; // Ogre Lords are pretty easy to recognize.  They're the ones ordering the other ogres about in a lordly manner.  Striking down their leadership will throw the ogres into confusion and dismay!

			Objectives.Add(new KillObjective(10, new Type[] { typeof(OgreLord) }, "ogre lords", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.LargeBagOfTreasure);
		}
	}

	public class TheBrawn : ChainQuest
	{
		public override Type NextQuest => typeof(TheBiggerTheyAre);
		public override bool IsChainTriggered => true;

		public TheBrawn()
		{
			Activated = true;
			Title = 1072693; // The Brawn
			Description = 1072710; // Inconceiveable!  We've learned that the ogre leadership has recruited some heavy-duty guards to their cause.  I've never personally fought a cyclopian warrior, but I'm sure you could easily best a few and report back how much trouble they'll cause to our growing community?
			RefusalMessage = 1072711; // Oh, I see.  *sigh*  Perhaps I overestimated your abilities.
			InProgressMessage = 1072712; // Make sure you fully assess all of the cyclopian tactical abilities!

			Objectives.Add(new KillObjective(6, new Type[] { typeof(Cyclops) }, "cyclops", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.LargeBagOfTreasure);
		}
	}

	public class TheBiggerTheyAre : ChainQuest
	{
		public override bool IsChainTriggered => true;

		public TheBiggerTheyAre()
		{
			Activated = true;
			Title = 1072694; // The Bigger They Are ...
			Description = 1072713; // The ogre insurgency has taken a turn for the worse! I've just been advised that the titans have concluded their discussions with the ogres and they've allied. We have virtually no information about titans.  Engage them and appraise their mettle.
			RefusalMessage = 1072714; // Certainly.  You've done enough to merit a breather.  When you're ready for more, report back to me.
			InProgressMessage = 1072715; // Those titans don't skulk very well.  You should be able to track them easily ... their footsteps are easily the largest around.

			Objectives.Add(new KillObjective(3, new Type[] { typeof(Titan) }, "titans", new QuestArea(1074807, "Sanctuary"))); // Sanctuary

			Rewards.Add(ItemReward.LargeBagOfTreasure);
		}
	}

	public class CommonBrigands : ChainQuest
	{
		public CommonBrigands()
		{
			Activated = true;
			Title = 1073082; // Common Brigands
			Description = 1073572; // Thank goodness, a hero like you has arrived! Brigands have descended upon this area like locusts, stealing and looting where ever they go. We need someone to put these vile curs where they belong -- in their graves. Are you up to the task? 
			RefusalMessage = 1073580; // I hope you'll reconsider. Until then, farwell.
			InProgressMessage = 1073592; // The Brigands still plague us. Have you killed 20 of their number?<br>

			Objectives.Add(new KillObjective(20, new Type[] { typeof(Brigand) }, 1074894)); // Common brigands

			Rewards.Add(ItemReward.BagOfTreasure);
		}
	}
}