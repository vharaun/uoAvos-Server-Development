using Server.Items;
using Server.Mobiles;

using System;

namespace Server.Engines.ChainQuests.Definitions
{
	/// New Haven Training
	public class SplitEnds : ChainQuest
	{
		public SplitEnds()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075506; // Split Ends
			Description = 1075507; // *sighs* I think bowcrafting is a might beyond my talents. Say there, you look a bit more confident with tools. Can I persuade thee to make a few arrows? You could have my satchel in return... 'tis useless to me! You'll need a fletching kit to start, some feathers, and a few arrow shafts. Just use the fletching kit while you have the other things, and I'm sure you'll figure out the rest.
			RefusalMessage = 1075508; // Oh. Well. I'll just keep trying alone, I suppose...
			InProgressMessage = 1072271; // You're not quite done yet.  Get back to work!
			CompletionMessage = 1072272; // Thanks for helping me out.  Here's the reward I promised you.

			Objectives.Add(new CollectObjective(20, typeof(Arrow), 1023902)); // arrow

			Rewards.Add(new ItemReward(1074282, typeof(AndricSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Andric"), new Point3D(3742, 2582, 40), Map.Trammel);
		}
	}

	public class IShotAnArrowIntoTheAir : ChainQuest
	{
		public IShotAnArrowIntoTheAir()
		{
			Activated = true;
			Title = 1075486; // I Shot an Arrow Into the Air...
			Description = 1075482; // Truth be told, the only way to get a feel for the bow is to shoot one and there's no better practice target than a sheep. If ye can shoot ten of them I think ye will have proven yer abilities. Just grab a bow and make sure to take enough ammunition. Bows tend to use arrows and crossbows use bolts. Ye can buy 'em or have someone craft 'em. How about it then? Come back here when ye are done.
			RefusalMessage = 1075483; // Fair enough, the bow isn't for everyone. Good day then.
			InProgressMessage = 1075484; // Return once ye have killed ten sheep with a bow and not a moment before.

			Objectives.Add(new KillObjective(10, new Type[] { typeof(Sheep) }, 1018270)); // sheep

			Rewards.Add(ItemReward.BagOfTrinkets);
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Kashiel"), new Point3D(3744, 2586, 40), Map.Trammel);
		}
	}

	public class BakersDozen : ChainQuest
	{
		public BakersDozen()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075478; // Baker's Dozen
			Description = 1075479; // You there! Do you know much about the ways of cooking? If you help me out, I'll show you a thing or two about how it's done. Bring me some cookie mix, about 5 batches will do it, and I will reward you. Although, I don't think you can buy it, you can make some in a snap! First get a rolling pin or frying pan or even a flour sifter. Then you mix one pinch of flour with some water and you've got some dough! Take that dough and add one dollop of honey and you've got sweet dough. add one more drop of honey and you've got cookie mix. See? Nothing to it! Now get to work!
			RefusalMessage = 1075480; // Argh, I absolutely must have more of these 'cookies!' Come back if you change your mind.
			InProgressMessage = 1072271; // You're not quite done yet.  Get back to work!
			CompletionMessage = 1075481; // Thank you! I haven't been this excited about food in months!

			Objectives.Add(new CollectObjective(5, typeof(CookieMix), 1024159)); // cookie mix

			Rewards.Add(new ItemReward(1074282, typeof(AsandosSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Asandos"), new Point3D(3505, 2513, 27), Map.Trammel);
		}
	}

	public class AStitchInTime : ChainQuest
	{
		public AStitchInTime()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075523; // A Stitch in Time
			Description = 1075522; // Oh how I wish I had a fancy dress like the noble ladies of Castle British! I don't have much... but I have a few trinkets I might trade for it. It would mean the world to me to go to a fancy ball and dance the night away. Oh, and I could tell you how to make one! You just need to use your sewing kit on enough cut cloth, that's all.
			RefusalMessage = 1075526; // Won't you reconsider? It'd mean the world to me, it would!
			InProgressMessage = 1075527; // Hello again! Do you need anything? You may want to visit the tailor's shop for cloth and a sewing kit, if you don't already have them.
			CompletionMessage = 1075528; // It's gorgeous! I only have a few things to give you in return, but I can't thank you enough! Maybe I'll even catch Uzeraan's eye at the, er, *blushes* I mean, I can't wait to wear it to the next town dance!

			Objectives.Add(new CollectObjective(1, typeof(FancyDress), 1027935)); // fancy dress

			Rewards.Add(new ItemReward(1075524, typeof(AnOldRing))); // an old ring
			Rewards.Add(new ItemReward(1075525, typeof(AnOldNecklace))); // an old necklace
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Clairesse"), new Point3D(3492, 2546, 20), Map.Trammel);
		}
	}

	public class BatteredBucklers : ChainQuest
	{
		public BatteredBucklers()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075511; // Battered Bucklers
			Description = 1075512; // Hey there! Yeah... you! Ya' any good with a hammer? Tell ya what, if yer thinking about tryin' some metal work, and have a bit of skill, I can show ya how to bend it into shape. Just get some of those ingots there, and grab a hammer and use it over here at this forge. I need a few more bucklers hammered out to fill this here order with...  hmmm about ten more. that'll give some taste of how to work the metal.
			RefusalMessage = 1075514; // Not enough muscle on yer bones to use it? hmph, probably afraid of the sparks markin' up yer loverly skin... to good for some honest labor... ha!... off with ya!
			InProgressMessage = 1075515; // Come On! Whats that... a bucket? We need ten bucklers... not spitoons.
			CompletionMessage = 1075516; // Thanks for the help. Here's something for ya to remember me by.

			Objectives.Add(new CollectObjective(10, typeof(Buckler), 1027027)); // buckler

			Rewards.Add(new ItemReward(1074282, typeof(GervisSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Gervis"), new Point3D(3505, 2749, 0), Map.Trammel);
		}
	}

	public class MoreOrePlease : ChainQuest
	{
		public MoreOrePlease()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075530; // More Ore Please
			Description = 1075529; // Have a pickaxe? My supplier is late and I need some iron ore so I can complete a bulk order for another merchant. If you can get me some soon I'll pay you double what it's worth on the market. Just find a cave or mountainside and try to use your pickaxe there, maybe you'll strike a good vein! 5 large pieces should do it.
			RefusalMessage = 1075531; // Not feeling strong enough today? Its alright, I didn't need a bucket of rocks anyway.
			InProgressMessage = 1075532; // Hmmm… we need some more Ore. Try finding a mountain or cave, and give it a whack.
			CompletionMessage = 1075533; // I see you found a good vien! Great!  This will help get this order out on time. Good work!

			Objectives.Add(new InternalObjective());

			Rewards.Add(new ItemReward(1074282, typeof(MuggSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Mugg"), new Point3D(3507, 2747, 0), Map.Trammel);
		}

		private class InternalObjective : CollectObjective
		{
			// Any type of ore is allowed
			public InternalObjective()
				: base(5, typeof(BaseOre), 1026585) // ore
			{
			}

			public override bool CheckItem(Item item)
			{
				return (item.ItemID == 6585); // Only large pieces count
			}
		}
	}

	public class ComfortableSeating : ChainQuest
	{
		public ComfortableSeating()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075517; // Comfortable Seating
			Description = 1075518; // Hail friend, hast thou a moment? A mishap with a saw hath left me in a sorry state, for it shall be a while before I canst return to carpentry. In the meantime, I need a comfortable chair that I may rest. Could thou craft a straw chair?  Only a tool, such as a dovetail saw, a few boards, and some skill as a carpenter is needed. Remember, this is a piece of furniture, so please pay attention to detail.
			RefusalMessage = 1072687; // I quite understand your reluctance.  If you reconsider, I'll be here.
			InProgressMessage = 1075509; // Is all going well? I look forward to the simple comforts in my very own home.
			CompletionMessage = 1074720; // This is perfect!

			Objectives.Add(new CollectObjective(1, typeof(BambooChair), "straw chair"));

			Rewards.Add(new ItemReward(1074282, typeof(LowelSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Lowel"), new Point3D(3440, 2645, 27), Map.Trammel);
		}
	}

	public class ThePenIsMightier : ChainQuest
	{
		public ThePenIsMightier()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075542; // The Pen is Mightier
			Description = 1075543; // Do you know anything about 'Inscription?' I've been trying to get my hands on some hand crafted Recall scrolls for a while now, and I could really use some help. I don't have a scribe's pen, let alone a spellbook with Recall in it, or blank scrolls, so there's no way I can do it on my own. How about you though? I could trade you one of my old leather bound books for some.
			RefusalMessage = 1075546; // Hmm, thought I had your interest there for a moment. It's not everyday you see a book made from real daemon skin, after all!
			InProgressMessage = 1075547; // Inscribing... yes, you'll need a scribe's pen, some reagents, some blank scroll, and of course your own magery book. You might want to visit the magery shop if you're lacking some materials.
			CompletionMessage = 1075548; // Ha! Finally! I've had a rune to the waterfalls near Justice Isle that I've been wanting to use for the longest time, and now I can visit at last. Here's that book I promised you... glad to be rid of it, to be honest.

			Objectives.Add(new CollectObjective(5, typeof(RecallScroll), "recall scroll"));

			Rewards.Add(new ItemReward(1075545, typeof(RedLeatherBook))); // a book bound in red leather
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Lyle"), new Point3D(3503, 2584, 14), Map.Trammel);
		}
	}

	public class AClockworkPuzzle : ChainQuest
	{
		public AClockworkPuzzle()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075535; // A clockwork puzzle
			Description = 1075534; // 'Tis a riddle, you see! "What kind of clock is only right twice per day? A broken one!" *laughs heartily* Ah, yes *wipes eye*, that's one of my favorites! Ah... to business. Could you fashion me some clock parts? I wish my own clocks to be right all the day long! You'll need some tinker's tools and some iron ingots, I think, but from there it should be just a matter of working the metal.
			RefusalMessage = 1072981; // Or perhaps you'd rather not.
			InProgressMessage = 1072271; // You're not quite done yet.  Get back to work!
			CompletionMessage = 1075536; // Wonderful! Tick tock, tick tock, soon all shall be well with grandfather's clock!

			Objectives.Add(new CollectObjective(5, typeof(ClockParts), 1024175)); // clock parts

			Rewards.Add(new ItemReward(1074282, typeof(NibbetSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Nibbet"), new Point3D(3459, 2525, 53), Map.Trammel);
		}
	}

	public class DeliciousFishes : ChainQuest
	{
		public DeliciousFishes()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075555; // Delicious Fishes
			Description = 1075556; // Ello there, looking for a good place on the dock to fish? I like the southeast corner meself. What's that? Oh, no, *sighs* me pole is broken and in for fixin'. My grandpappy gave me that pole, means a lot you see. Miss the taste of fish though... Oh say, since you're here, could you catch me a few fish? I can cook a mean fish steak, and I'll split 'em with you! But make sure it's one of the green kind, they're the best for seasoning!
			RefusalMessage = 1075558; // Ah, you're missin' out my friend, you're missing out. My peppercorn fishsteaks are famous on this little isle of ours!
			InProgressMessage = 1075559; // Eh? Find yerself a pole and get close to some water. Just toss the line on in and hopefully you won't snag someone's old boots! Remember, that's twenty of them green fish we'll be needin', so come back when you've got em, 'aight?
			CompletionMessage = 1075560; // Just a moment my friend, just a moment! *rummages in his pack* Here we are! My secret blend of peppers always does the trick, never fails, no not once. These'll fill you up much faster than that tripe they sell in the market!

			Objectives.Add(new CollectObjective(5, typeof(SaltwaterFish), 1022508)); // fish

			Rewards.Add(new ItemReward(1075557, typeof(PeppercornFishsteak), 3)); // peppercorn fishsteak
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Norton"), new Point3D(3502, 2603, 1), Map.Trammel);
		}
	}

	public class FleeAndFatigue : ChainQuest
	{
		public FleeAndFatigue()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075487; // Flee and Fatigue
			Description = 1075488; // I was just *coughs* ambushed near the moongate. *wheeze* Why do I pay my taxes? Where were the guards? You then, you an Alchemist? If you can make me a few Refresh potions, I will be back on my feet and can give those lizards the what for! Find a mortar and pestle, a good amount of black pearl, and ten empty bottles to store the finished potions in. Just use the mortar and pestle and the rest will surely come to you. When you return, the favor will be repaid.
			RefusalMessage = 1075489; // Fine fine, off with *cough* thee then! The next time you see a lizardman though, give him a whallop for me, eh?
			InProgressMessage = 1075490; // Just remember you need to use your mortar and pestle while you have empty bottles and some black pearl. Refresh potions are what I need.
			CompletionMessage = 1075491; // *glug* *glug* Ahh... Yes! Yes! That feels great! Those lizardmen will never know what hit 'em! Here, take this, I can get more from the lizards.

			Objectives.Add(new CollectObjective(10, typeof(RefreshPotion), "refresh potions"));

			Rewards.Add(new ItemReward(1074282, typeof(SadrahSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Sadrah"), new Point3D(3742, 2731, 7), Map.Trammel);
		}
	}

	public class ChopChopOnTheDouble : ChainQuest
	{
		public ChopChopOnTheDouble()
		{
			Activated = true;
			HasRestartDelay = true;
			Title = 1075537; // Chop Chop, On The Double!
			Description = 1075538; // That's right, move it! I need sixty logs on the double, and they need to be freshly cut! If you can get them to me fast I'll have your payment in your hands before you have the scent of pine out from beneath your nostrils. Just get a sharp axe and hack away at some of the trees in the land and your lumberjacking skill will rise in no time.
			RefusalMessage = 1072981; // Or perhaps you'd rather not.
			InProgressMessage = 1072271; // You're not quite done yet.  Get back to work!
			CompletionMessage = 1075539; // Ahhh! The smell of fresh cut lumber. And look at you, all strong and proud, as if you had done an honest days work!

			Objectives.Add(new CollectObjective(60, typeof(Log), 1027133)); // log

			Rewards.Add(new ItemReward(1074282, typeof(HargroveSatchel))); // Craftsmans's Satchel
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Hargrove"), new Point3D(3445, 2633, 28), Map.Trammel);
		}
	}


	/// New Haven Skill Training
	public class CleansingOldHaven : ChainQuest
	{
		public CleansingOldHaven()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077719; // Cleansing Old Haven
			Description = 1077722; // Head East out of town to Old Haven. Consecrate your weapon, cast Divine Fury, and battle monsters there until you have raised your Chivalry skill to 50.<br><center>------</center><br>Hail, friend. The life of a Paladin is a life of much sacrifice, humility, bravery, and righteousness. If you wish to pursue such a life, I have an assignment for you. Adventure east to Old Haven, consecrate your weapon, and lay to rest the undead that inhabit there.<br><br>Each ability a Paladin wishes to invoke will require a certain amount of "tithing points" to use. A Paladin can earn these tithing points by donating gold at a shrine or holy place. You may tithe at this shrine.<br><br>Return to me once you feel that you are worthy of the rank of Apprentice Paladin.
			RefusalMessage = 1077723; // Farewell to you my friend. Return to me if you wish to live the life of a Paladin.
			InProgressMessage = 1077724; // There are still more undead to lay to rest. You still have more to learn. Return to me once you have done so.
			CompletionMessage = 1077726; // Well done, friend. While I know you understand Chivalry is its own reward, I would like to reward you with something that will protect you in battle. It was passed down to me when I was a lad. Now, I am passing it on you. It is called the Bulwark Leggings. Thank you for your service.
			CompletionNotice = 1077725; // You have achieved the rank of Apprentice Paladin. Return to Aelorn in New Haven to report your progress.

			Objectives.Add(new GainSkillObjective(SkillName.Chivalry, 500, true, true));

			Rewards.Add(new ItemReward(1077727, typeof(BulwarkLeggings))); // Bulwark Leggings
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Aelorn"), new Point3D(3527, 2516, 45), Map.Trammel);
		}
	}

	public class TheRudimentsOfSelfDefense : ChainQuest
	{
		public TheRudimentsOfSelfDefense()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077609; // The Rudiments of Self Defense
			Description = 1077610; // Head East out of town and go to Old Haven. Battle monster there until you have raised your Wrestling skill to 50.Listen up! If you want to learn the rudiments of self-defense, you need toughening up, and there's no better way to toughen up than engaging in combat. Head East out of town to Old Haven and battle the undead there in hand to hand combat. Afraid of dying, you say? Well, you should be! Being an adventurer isn't a bed of posies, or roses, or however that saying goes. If you take a dirt nap, go to one of the nearby wandering healers and they'll get you back on your feet.Come back to me once you feel that you are worthy of the rank Apprentice Wrestler and i will reward you wit a prize.
			RefusalMessage = 1077611; // Ok, featherweight. come back to me if you want to learn the rudiments of self-defense.
			InProgressMessage = 1077630; // You have not achived the rank of Apprentice Wrestler. Come back to me once you feel that you are worthy of the rank Apprentice Wrestler and i will reward you with something useful.
			CompletionMessage = 1077613; // It's about time! Looks like you managed to make it through your self-defense training. As i promised, here's a little something for you. When worn, these Gloves of Safeguarding will increase your awareness and resistances to most elements except poison. Oh yeah, they also increase your natural health regeneration aswell. Pretty handy gloves, indeed. Oh, if you are wondering if your meditation will be hinered while wearing these gloves, it won't be. Mages can wear cloth and leather items without needing to worry about that. Now get out of here and make something of yourself.
			CompletionNotice = 1077612; // You have achieved the rank of Apprentice Wrestler. Return to Dimethro in New Haven to receive your prize.

			Objectives.Add(new GainSkillObjective(SkillName.Wrestling, 500, true, true));

			Rewards.Add(new ItemReward(1077614, typeof(GlovesOfSafeguarding))); // Gloves Of Safeguarding
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Dimethro"), new Point3D(3528, 2520, 25), Map.Trammel);
		}
	}

	public class CrushingBonesAndTakingNames : ChainQuest
	{
		public CrushingBonesAndTakingNames()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078070; // Crushing Bones and Taking Names
			Description = 1078065; // Head East out of town and go to Old Haven. While wielding your mace,battle monster there until you have raised your Mace Fighting skill to 50. I see you want to learn a real weapon skill and not that toothpick training Jockles hasto offer. Real warriors are called Armsmen, and they wield mace weapons. No doubt about it. Nothing is more satisfying than knocking the wind out of your enemies, smashing there armor, crushing their bones, and taking there names. Want to learn how to wield a mace? Well i have an assignment for you. Head East out of town and go to Old Haven. Undead have plagued the town, so there are plenty of bones for you to smash there. Come back to me after you have ahcived the rank of Apprentice Armsman, and i will reward you with a real weapon.
			RefusalMessage = 1078068; // I thought you wanted to be an Armsman and really make something of yourself. You have potential, kid, but if you want to play with toothpicks, run to Jockles and he will teach you how to clean your teeth with a sword. If you change your mind, come back to me, and i will show you how to wield a real weapon.
			InProgressMessage = 1078067; // Listen kid. There are a lot of undead in Old Haven, and you haven't smashed enough of them yet. So get back there and do some more cleansing.
			CompletionMessage = 1078069; // Now that's what I'm talking about! Well done! Don't you like crushing bones and taking names? As i promised, here is a war mace for you. It hits hard. It swings fast. It hits often. What more do you need? Now get out of here and crush some more enemies!
			CompletionNotice = 1078068; // You have achieved the rank of Apprentice Armsman. Return to Churchill in New Haven to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Macing, 500, true, true));

			Rewards.Add(new ItemReward(1078062, typeof(ChurchillsWarMace))); // Churchill's War Mace
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Churchill"), new Point3D(3531, 2531, 20), Map.Trammel);
		}
	}

	public class SwiftAsAnArrow : ChainQuest
	{
		public SwiftAsAnArrow()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078201; // Swift as an Arrow
			Description = 1078205; // Head East out of town and go to Old Haven. While wielding your bow or crossbow, battle monster there until you have raised your Archery skill to 50. Well met, friend. Imagine yourself in a distant grove of trees, You raise your bow, take slow, careful aim, and with the twitch of a finger, you impale your prey with a deadly arrow. You look like you would make a excellent archer, but you will need practice. There is no better way to practice Archery than when you life is on the line. I have a challenge for you. Head East out of town and go to Old Haven. While wielding your bow or crossbow, battle the undead that reside there. Make sure you bring a healthy supply of arrows (or bolts if you prefer a crossbow). If you wish to purchase a bow, crossbow, arrows, or bolts, you can purchase them from me or the Archery shop in town. You can also make your own arrows with the Bowcraft/Fletching skill. You will need fletcher's tools, wood to turn into sharft's, and feathers to make arrows or bolts. Come back to me after you have achived the rank of Apprentice Archer, and i will reward you with a fine Archery weapon.
			RefusalMessage = 1078206; // I understand that Archery may not be for you. Feel free to visit me in the future if you change your mind.
			InProgressMessage = 1078207; // You're doing great as an Archer! however, you need more practice.
			CompletionMessage = 1078209; // Congratulation! I want to reward you for your accomplishment. Take this composite bow. It is called " Heartseeker". With it, you will shoot with swiftness, precision, and power. I hope "Heartseeker" serves you well.
			CompletionNotice = 1078208; // You have achieved the rank of Apprentice Archer. Return to Robyn in New Haven to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Archery, 500, true, true));

			Rewards.Add(new ItemReward(1078210, typeof(Heartseeker))); // Heartseeker
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Robyn"), new Point3D(3535, 2531, 20), Map.Trammel);
		}
	}

	public class EnGuarde : ChainQuest
	{
		public EnGuarde()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078186; // En Guarde!
			Description = 1078190; // Head East out of town to Old Haven. Battle monsters there until you have raised your Fencing skill to 50.<br><center>------</center><br>Well hello there, lad. Fighting with elegance and precision is far more enriching than slugging an enemy with a club or butchering an enemy with a sword. Learn the art of Fencing if you want to master combat and look good doing it!<br><br>The key to being a successful fencer is to be the complement and not the opposition to your opponent's strength. Watch for your opponent to become off balance. Then finish him off with finesse and flair.<br><br>There are some undead that need cleansing out in Old Haven towards the East. Head over there and slay them, but remember, do it with style!<br><br>Come back to me once you have achieved the rank of Apprentice Fencer, and I will reward you with a prize.
			RefusalMessage = 1078191; // I understand, lad. Being a hero isn't for everyone. Run along, then. Come back to me if you change your mind.
			InProgressMessage = 1078192; // You're doing well so far, but you're not quite ready yet. Head back to Old Haven, to the East, and kill some more undead.
			CompletionMessage = 1078194; // Excellent! You are beginning to appreciate the art of Fencing. I told you fighting with elegance and precision is more enriching than fighting like an ogre.<br><br>Since you have returned victorious, please take this war fork and use it well. The war fork is a finesse weapon, and this one is magical! I call it "Recaro's Riposte". With it, you will be able to parry and counterstrike with ease! Your enemies will bask in your greatness and glory! Good luck to you, lad, and keep practicing!
			CompletionNotice = 1078193; // You have achieved the rank of Apprentice Fencer. Return to Recaro in New Haven to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Fencing, 500, true, true));

			Rewards.Add(new ItemReward(1078195, typeof(RecarosRiposte))); // Recaro's Riposte
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Recaro"), new Point3D(3536, 2534, 20), Map.Trammel);
		}
	}

	public class TheArtOfWar : ChainQuest
	{
		public TheArtOfWar()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077667; // The Art of War
			Description = 1077670; // Head East out of town to Old Haven. Battle monsters there until you have raised your Tactics skill to 50.<br><center>------</center><br>Knowing how to hold a weapon is only half of the battle. The other half is knowing how to use it against an opponent. It's one thing to kill a few bunnies now and then for fun, but a true warrior knows that the right moves to use against a lich will pretty much get your arse fried by a dragon.<br><br>I'll help teach you how to fight so that when you do come up against that dragon, maybe you won't have to walk out of there "OooOOooOOOooOO'ing" and looking for a healer.<br><br>There are some undead that need cleaning out in Old Haven towards the east. Why don't you head on over there and practice killing things?<br><br>When you feel like you've got the basics down, come back to me and I'll see if I can scrounge up an item to help you in your adventures later on.
			RefusalMessage = 1077671; // That's too bad. I really thought you had it in you. Well, I'm sure those undead will still be there later, so if you change your mind, feel free to stop on by and I'll help you the best I can.
			InProgressMessage = 1077672; // You're making some progress, that i can tell, but you're not quite good enough to last for very long out there by yourself. Head back to Old Haven, to the east, and kill some more undead.
			CompletionMessage = 1077674; // Hey, good job killing those undead! Hopefully someone will come along and clean up the mess. All that blood and guts tends to stink after a few days, and when the wind blows in from the east, it can raise a mighty stink!<br><br>Since you performed valiantly, please take these arms and use them well. I've seen a few too many harvests to be running around out there myself, so you might as well take it.<br><br>There is a lot left for you to learn, but I think you'll do fine. Remember to keep your elbows in and stick'em where it hurts the most!
			CompletionNotice = 1077673; // You have achieved the rank of Apprentice Warrior. Return to Alden Armstrong in New Haven to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Tactics, 500, true, true));

			Rewards.Add(new ItemReward(1077675, typeof(ArmsOfArmstrong))); // Arms of Armstrong
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "AldenArmstrong"), new Point3D(3535, 2538, 20), Map.Trammel);
		}
	}

	public class TheWayOfTheBlade : ChainQuest
	{
		public TheWayOfTheBlade()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077658; // The way of The Blade
			Description = 1077661; // Head East out of town and go to Old Haven. While wielding your sword, battle monster there until you have raised your Swordsmanship skill to 50. *as you approach, you notice Jockles sizing you up with a skeptical look on his face* i can see you want to learn how to handle a blade. It's a lot harder than it looks, and you're going to have to put alot of time and effort if you ever want to be half as good as i am. I'll tell you what, kid, I'll help you get started, but you're going to have to do all the work if you want to learn something. East of here, outside of town, is Old Haven. It's been overrun with the nastiest of undead you've seen, which makes it a perfect place for you to turn that sloppy grin on your face into actual skill at handling a sword. Make sure you have a sturdy Swordsmanship weapon in good repair before you leave. 'tis no fun to travel all the way down there just to find out you forgot your blade! When you feel that you've cut down enough of those foul smelling things to learn how to handle a blade without hurting yourself, come back to me. If i think you've improved enough, I'll give you something suited for a real warrior.
			RefusalMessage = 1077662; // Ha! I had a feeling you were a lily-livered pansy. You might have potential, but you're scared by a few smelly undead, maybe it's better that you stay away from sharp objects. After all, you wouldn't want to hurt yourself swinging a sword. If you change your mind, I might give you another chance...maybe.
			InProgressMessage = 1077663; // *Jockles looks you up and down* Come on! You've got to work harder than that to get better. Now get out of here, go kill some more of those undead to the east in Old Haven, and don't come back till you've got real skill.
			CompletionMessage = 1077665; // Well, well, look at what we have here! You managed to do it after all. I have to say, I'm a little surprised that you came back in one piece, but since you did. I've got a little something for you. This is a fine blade that served me well in my younger days. Of course I've got much better swords at my disposal now, so I'll let you go ahead and use it under one condition. Take goodcare of it and treat it with the respect that a fine sword deserves. You're one of the quickers learners I've seen, but you still have a long way to go. Keep at it, and you'll get there someday. Happy hunting, kid.
			CompletionNotice = 1077664; // You have achieved the rank of Apprentice Swordsman. Return to Jockles in New Haven to see what kind of reward he has waiting for you. Hopefully he'll be a little nicer this time!

			Objectives.Add(new GainSkillObjective(SkillName.Swords, 500, true, true));

			Rewards.Add(new ItemReward(1077666, typeof(JocklesQuicksword))); // Jockles' Quicksword
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Jockles"), new Point3D(3535, 2544, 20), Map.Trammel);
		}
	}

	public class ThouAndThineShield : ChainQuest
	{
		public ThouAndThineShield()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077704; // Thou and Thine Shield
			Description = 1077707; // Head East out of town and go to Old Haven. Battle monsters, or simply let them hit you, while holding a shield or a weapon until you have raised your Parrying skill to 50. Oh, hello. You probably want me to teach you how to parry, don't you? Very Well. First, you'll need a weapon or a shield. Obviously shields work best of all, but you can parry with a 2-handed weapon. Or if you're feeling particularly brave, a 1-handed weapon will do in a pinch, I'd advise you to go to Old Haven, which you'll find to the East, and practice blocking incoming blows from the undead there. You'll learn quickly if you have more than one opponent attacking you at the same time to practice parrying lots of blows at once. That's the quickest way to master the art of parrying. If you manage to improve your skill enough, i have a shield that you might find useful. Come back to me when you've trained to an apprentice level.
			RefusalMessage = 1077708; // It's your choice, obviously, but I'd highly suggest that you learn to parry before adventuring out into the world. Come talk to me again when you get tired of being beat on by your opponents
			InProgressMessage = 1077709; // You're doing well, but in my opinion, I Don't think you really want to continue on without improving your parrying skill a bit more. Go to Old Haven, to the East, and practice blocking blows with a shield.
			CompletionMessage = 1077711; // Well done! You're much better at parrying blows than you were when we first met. You should be proud of your new ability and I bet your body is greatful to you aswell. *Tyl Ariadne laughs loudly at his ownn (mostly lame) joke*	Oh yes, I did promise you a shield if I thought you were worthy of having it, so here you go. My father made these shields for the guards who served my father faithfully for many years, and I just happen to have obe that i can part with. You should find it useful as you explore the lands.Good luck, and may the Virtues be your guide.
			CompletionNotice = 1077710; // You have achieved the rank of Apprentice Warrior (for Parrying). Return to Tyl Ariadne in New Haven as soon as you can to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Parry, 500, true, true));

			Rewards.Add(new ItemReward(1077694, typeof(EscutcheonDeAriadne))); // Escutcheon de Ariadne
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "TylAriadne"), new Point3D(3525, 2556, 20), Map.Trammel);
		}
	}

	public class DefyingTheArcane : ChainQuest
	{
		public DefyingTheArcane()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077621; // Defying the Arcane
			Description = 1077623; // Head East out of town and go to Old Haven. Battle spell casting monsters there until you have raised your Resisting Spells skill to 50.<br><center>------</center><br>Hail and well met! To become a true master of the arcane art of Magery, I suggest learning the complementary skill known as Resisting Spells. While the name of this skill may suggest that it helps with resisting all spells, this is not the case. This skill helps you lessen the severity of spells that lower your stats or ones that last for a specific duration of time. It does not lessen damage from spells such as Energy Bolt or Flamestrike.<BR><BR>The Magery spells that can be resisted are Clumsy, Curse, Feeblemind, Mana Drain, Mana Vampire, Paralyze, Paralyze Field, Poison, Poison Field, and Weaken.<BR><BR>The Necromancy spells that can be resisted are Blood Oath, Corpse Skin, Mind Rot, and Pain Spike.<BR><BR>At higher ranks, the Resisting Spells skill also benefits you by adding a bonus to your minimum elemental resists. This bonus is only applied after all other resist modifications - such as from equipment - has been calculated. It's also not cumulative. It compares the number of your minimum resists to the calculated value of your modifications and uses the higher of the two values.<BR><BR>As you can see, Resisting Spells is a difficult skill to understand, and even more difficult to master. This is because in order to improve it, you will have to put yourself in harm's way - as in the path of one of the above spells.<BR><BR>Undead have plagued the town of Old Haven. We need your assistance in cleansing the town of this evil influence. Old Haven is located east of here. Battle the undead spell casters that inhabit there.<BR><BR>Comeback to me once you feel that you are worthy of the rank of Apprentice Mage and I will reward you with an arcane prize.
			RefusalMessage = 1077624; // The ability to resist powerful spells is a taxing experience. I understand your resistance in wanting to pursue it. If you wish to reconsider, feel free to return to me for Resisting Spells training. Good journey to you!
			InProgressMessage = 1077632; // You have not achieved the rank of Apprentice Mage. Come back to me once you feel that you are worthy of the rank of Apprentice Mage and I will reward you with an arcane prize.
			CompletionMessage = 1077626; // You have successfully begun your journey in becoming a true master of Magery. On behalf of the New Haven Mage Council I wish to present you with this bracelet. When worn, the Bracelet of Resilience will enhance your resistances vs. the elements, physical, and poison harm. The Bracelet of Resilience also magically enhances your ability fend off ranged and melee attacks. I hope it serves you well.
			CompletionNotice = 1077625; // You have achieved the rank of Apprentice Mage (for Resisting Spells). Return to Alefian in New Haven to receive your arcane prize.

			Objectives.Add(new GainSkillObjective(SkillName.MagicResist, 500, true, true));

			Rewards.Add(new ItemReward(1077627, typeof(BraceletOfResilience))); // Bracelet of Resilience
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Alefian"), new Point3D(3473, 2497, 72), Map.Trammel);
		}
	}

	public class StoppingTheWorld : ChainQuest
	{
		public StoppingTheWorld()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077597; // Stopping the World
			Description = 1077598; // Head East out of town and go to Old Haven. Use spells and abilites to deplete your mana and meditate there until you have raised your Meditation skill to 50.	Well met! I can teach you how to 'Stop the World' around you and focus your inner energies on replenishing you mana. What is mana? Mana is the life force for everyone who practices arcane arts. When a practitioner of magic invokes a spell or scribes a scroll. It consumes mana. Having a abundant supply of mana is vital to excelling as a practitioner of the arcane. Those of us who study the art of Meditation are also known as stotics. The Meditation skill allows stoics to increase the rate at which they regenerate mana A Stoic needs to perform abilities or cast spells to deplete mana before he can meditate to replenish it. Meditation can occur passively or actively. Actively Meditation is more difficult to master but allows for the stoic to replenish mana at a significantly faster rate. Metal armor inerferes with the regenerative properties of Meditation. It is wise to wear leather or cloth protection when meditating. Head east out of town and go to Old Haven. Use spells and abilities to deplete your mana and actively meditate to replenish it.	Come back once you feel you are at the worthy rank of Apprentice Stoic and i will reward you with a arcane prize.
			RefusalMessage = 1077599; // Seek me out if you ever wish to study the art of Meditation. Good journey.
			InProgressMessage = 1077628; // You have not achived the rank of Apprentice Stoic. Come back to me once you feel that you are worthy of the rank Apprentice Stoic and i will reward you with a arcane prize.
			CompletionMessage = 1077626; // You have successfully begun your journey in becoming a true master of Magery. On behalf of the New Haven Mage Council I wish to present you with this bracelet. When worn, the Bracelet of Resilience will enhance your resistances vs. the elements, physical, and poison harm. The Bracelet of Resilience also magically enhances your ability fend off ranged and melee attacks. I hope it serves you well.
			CompletionNotice = 1077600; // You have achieved the rank of Apprentice Stoic (for Meditation). Return to Gustar in New Haven to receive your arcane prize.

			Objectives.Add(new GainSkillObjective(SkillName.Meditation, 500, true, true));

			Rewards.Add(new ItemReward(1077602, typeof(PhilosophersHat))); // Philosopher's Hat
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Gustar"), new Point3D(3474, 2492, 91), Map.Trammel);
		}
	}

	public class ScribingArcaneKnowledge : ChainQuest
	{
		public ScribingArcaneKnowledge()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077615; // Scribing Arcane Knowledge
			Description = 1077616; // While Here ar the New Haven Magery Library, use scribe's pen and scribe 3rd and 4th circle Magery scrolls that you have in your spellbook. Remeber, you will need blank scrolls aswell. Do this until you have raised your Inscription skill to 50. Greetings and welcome to the New Haven Magery Library! You wish to learn how to scribe spell scrolls? You have come to the right place! Inscribeed in a steady hand and imbued with te power of reagents, a scroll can mean the difference between life and death in a perilous situation. Those knowledgeable in Inscription man transcribe spells to create useful and valuale magical scrolls. Before you can inscribe a spell, you must first be able to cast the spell without the aid of a scroll. This means that you need the appropriate level of proficiency as a mage, the required mana, and the required reagents. Second, you will need a blank scroll to write on and a scribe's pen. Then, you will need to decide which particular spell you wish to scribe. It may sound easy, but there is a bit more to it. As with the development of all skills, you need to practice Inscription of lower level spells before you can move onto the more difficult ones. The most important aspect of Inscription is mana. Inscribing a scroll with a magic spell drains your mana. When inscribing 3rd or lower spells this is will not be much of a problem for these spells consume a small amount of mana. However, when you are inscribing higher circle spells, you may see your mana drain rapidly. When this happens, pause or meditate before continuing.I suggest you begin scribing any 3rd and 4th circle spells that you know. If you don't possess ant, you can alwayers barter with one of the local mage merchants or a fellow adventurer that is a seasoned Scribe. Come back to me once you feel that you are the worthy rankof Apprentice Scribe and i will reward you with an arcane prize.
			RefusalMessage = 1077617; // I understand. When you are ready, feel free to return to me for Inscription training. Thanks for stopping by!
			InProgressMessage = 1077631; // You have not achived the rank of Apprentice Scribe. Come back to me once you feel that you are worthy of the rank Apprentice Scribe and i will reward you with a arcane prize.
			CompletionMessage = 1077619; // Scribing is a very fulfilling pursuit. I am please to see you embark on this journey. You sling a pen well! On behalf of the New Haven Mage Council I wish to present you with this spellbook. When equipped, the Hallowed Spellbook greatly enhanced the potency of your offensive soells when used against Undead. Be mindful, though. While this book is equiped you invoke powerful spells and abilities vs Humanoids, such as other humans, orcs, ettins, and trolls. Your offensive spells will diminish in effectiveness. I suggest unequipping the Hallowed Spellbook when battling Humanoids. I hope this spellbook serves you well.
			CompletionNotice = 1077618; // You have achieved the rank of Apprentice Scribe. Return to Jillian in New Haven to receive your arcane prize.

			Objectives.Add(new GainSkillObjective(SkillName.Inscribe, 500, true, true));

			Rewards.Add(new ItemReward(1077620, typeof(HallowedSpellbook))); // Hallowed Spellbook
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Jillian"), new Point3D(3465, 2490, 71), Map.Trammel);
		}
	}

	public class TheMagesApprentice : ChainQuest
	{
		public TheMagesApprentice()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077576; // The Mage's Apprentice
			Description = 1077577; // Head East out of town and go to Old Haven. Cast fireballs and lightning bolts against monsters there until you have raised your Magery skill to 50. Greetings. You seek to unlock the secrets of the arcane art of Magery. The New Haven Mage Council has an assignment for you. Undead have plagued the town of Old Haven. We need your assistance in cleansing the town of this evil influence. Old Haven is located east of here. I suggest using your offensive Magery spells such as Fireball and Lightning Bolt against the Undead that inhabit there. Make sure you have plenty of reagents before embarking on your journey. Reagents are required to cast Magery spells. You can purchase extra reagents at the nearby Reagent shop, or you can find reagents growing in the nearby wooded areas. You can see which reagents are required for each spell by looking in your spellbook. Come back to me once you feel that you are worthy of the rank of Apprentice Mage and I will reward you with an arcane prize.
			RefusalMessage = 1077578; // Very well, come back to me when you are ready to practice Magery. You have so much arcane potential. 'Tis a shame to see it go to waste. The New Haven Mage Council could really use your help.
			InProgressMessage = 1077579; // You have not achieved the rank of Apprentice Mage. Come back to me once you feel that you are worthy of the rank of Apprentice Mage and I will reward you with an arcane prize.
			CompletionMessage = 1077581; // Well done! On behalf of the New Haven Mage Council I wish to present you with this staff. Normally a mage must unequip weapons before spell casting. While wielding your new Ember Staff, however, you will be able to invoke your Magery spells. Even if you do not currently possess skill in Mace Fighting, the Ember Staff will allow you to fight as if you do. However, your Magery skill will be temporarily reduced while doing so. Finally, the Ember Staff occasionally smites a foe with a Fireball while wielding it in melee combat. I hope the Ember Staff serves you well.
			CompletionNotice = 1077580; // You have achieved the rank of Apprentice Mage. Return to Kaelynna in New Haven to receive your arcane prize.

			Objectives.Add(new GainSkillObjective(SkillName.Magery, 500, true, true));

			Rewards.Add(new ItemReward(1077582, typeof(EmberStaff))); // Ember Staff
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Kaelynna"), new Point3D(3486, 2491, 52), Map.Trammel);
		}
	}

	public class ScholarlyTask : ChainQuest
	{
		public ScholarlyTask()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077603; // A Scholarly Task
			Description = 1077604; // Head East out of town and go to Old Haven. Use Evaluating Intelligence on all creatures you see there. You can also cast Magery spells as well to raise Evaluating Intelligence. Do these activities until you have raised your Evaluating Intelligence skill to 50.<br><center>------</center><br>Hello. Truly knowing your opponent is essential for landing your offensive spells with precision. I can teach you how to enhance the effectiveness of your offensive spells, but first you must learn how to size up your opponents intellectually. I have a scholarly task for you. Head East out of town and go to Old Haven. Use Evaluating Intelligence on all creatures you see there. You can also cast Magery spells as well to raise Evaluating Intelligence.<BR><BR>Come back to me once you feel that you are worthy of the rank of Apprentice Scholar and I will reward you with an arcane prize.
			RefusalMessage = 1077605; // Return to me if you reconsider and wish to become an Apprentice Scholar.
			InProgressMessage = 1077629; // You have not achieved the rank of Apprentice Scholar. Come back to me once you feel that you are worthy of the rank of Apprentice Scholar and I will reward you with an arcane prize.
			CompletionMessage = 1077607; // You have completed the task. Well done. On behalf of the New Haven Mage Council I wish to present you with this ring. When worn, the Ring of the Savant enhances your intellectual aptitude and increases your mana pool. Your spell casting abilities will take less time to invoke and recovering from such spell casting will be hastened. I hope the Ring of the Savant serves you well.
			CompletionNotice = 1077606; // You have achieved the rank of Apprentice Scholar. Return to Mithneral in New Haven to receive your arcane prize.

			Objectives.Add(new GainSkillObjective(SkillName.EvalInt, 500, true, true));

			Rewards.Add(new ItemReward(1077608, typeof(RingOfTheSavant))); // Ring of the Savant
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Mithneral"), new Point3D(3485, 2491, 71), Map.Trammel);
		}
	}

	public class TheRightToolForTheJob : ChainQuest
	{
		public TheRightToolForTheJob()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077741; // The Right Tool for the Job
			Description = 1077744; // Create new scissors and hammers while inside Amelia's workshop. Try making scissors up to 45 skill, the switch to making hammers until 50 skill.<br><center>-----</center><br>Hello! I guess you're here to learn something about Tinkering, eh? You've come to the right place, as Tinkering is what I've dedicated my life to. <br><br>You'll need two things to get started: a supply of ingots and the right tools for the job. You can either buy ingots from the market, or go mine them yourself. As for tools, you can try making your own set of Tinker's Tools, or if you'd prefer to buy them, I have some for sale.<br><br>Working here in my shop will let me give you pointers as you go, so you'll be able to learn faster than anywhere else. Start off making scissors until you reach 45 tinkering skill, then switch to hammers until you've achieved 50. Once you've done that, come talk to me and I'll give you something for your hard work.
			RefusalMessage = 1077745; // I’m disappointed that you aren’t interested in learning more about Tinkering. It’s really such a useful skill!<br><br>*Amelia smiles*<br><br>At least you know where to find me if you change your mind, since I rarely spend time outside of this shop.
			InProgressMessage = 1077746; // Nice going! You're not quite at Apprentice Tinkering yet, though, so you better get back to work. Remember that the quickest way to learn is to make scissors up until 45 skill, and then switch to hammers. Also, don't forget that working here in my shop will let me give you tips so you can learn faster.
			CompletionMessage = 1077748; // You've done it! Look at our brand new Apprentice Tinker! You've still got quite a lot to learn if you want to be a Grandmaster Tinker, but I believe you can do it! Just keep in mind that if you're tinkering just to practice and improve your skill, make items that are moderately difficult (60-80% success chance), and try to stick to ones that use less ingots.  <br><br>Come here, my brand new Apprentice Tinker, I want to give you something special. I created this just for you, so I hope you like it. It's a set of Tinker's Tools that contains a bit of magic. These tools have more charges than any Tinker's Tools a Tinker can make. You can even use them to make a normal set of tools, so that way you won't ever find yourself stuck somewhere with no tools!
			CompletionNotice = 1077747; // You have achieved the rank of Apprentice Tinker. Talk to Amelia Youngstone in New Haven to see what kind of reward she has waiting for you.

			Objectives.Add(new GainSkillObjective(SkillName.Tinkering, 500, true, true));

			Rewards.Add(new ItemReward(1077749, typeof(AmeliasToolbox))); // Amelia’s Toolbox
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "AmeliaYoungstone"), new Point3D(3459, 2529, 53), Map.Trammel);
		}
	}

	public class KnowThineEnemy : ChainQuest
	{
		public KnowThineEnemy()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077685; // Know Thine Enemy
			Description = 1077688; // Head East out of town to Old Haven. Battle monsters there, or heal yourself and other players, until you have raised your Anatomy skill to 50.<br><center>------</center><br>Hail and well met. You must be here to improve your knowledge of Anatomy. Well, you've come to the right place because I can teach you what you need to know. At least all you'll need to know for now. Haha!<br><br>Knowing about how living things work inside can be a very useful skill. Not only can you learn where to strike an opponent to hurt him the most, but you can use what you learn to heal wounds better as well. Just walking around town, you can even tell if someone is strong or weak or if they happen to be particularly dexterous or not.<BR><BR>If you're interested in learning more, I'd advise you to head out to Old Haven, just to the east, and jump into the fray. You'll learn best by engaging in combat while keeping you and your fellow adventurers healed, or you can even try sizing up your opponents.<br><br>While you're gone, I'll dig up something you may find useful.
			RefusalMessage = 1077689; // It's your choice, but I wouldn't head out there without knowing what makes those things tick inside! If you change your mind, you can find me right here dissecting frogs, cats or even the occasional unlucky adventurer.
			InProgressMessage = 1077690; // I'm surprised to see you back so soon. You've still got a ways to go if you want to really understand the science of Anatomy. Head out to Old Haven and practice combat and healing yourself or other adventurers.
			CompletionMessage = 1077692; // By the Virtues, you've done it! Congratulations mate! You still have quite a ways to go if you want to perfect your knowledge of Anatomy, but I know you'll get there someday. Just keep at it.<br><br>In the meantime, here's a piece of armor that you might find useful. It's not fancy, but it'll serve you well if you choose to wear it.<br><br>Happy adventuring, and remember to keep your cranium separate from your clavicle!
			CompletionNotice = 1077691; // You have achieved the rank of Apprentice Healer (for Anatomy). Return to Andreas Vesalius in New Haven as soon as you can to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Anatomy, 500, true, true));

			Rewards.Add(new ItemReward(1077693, typeof(TunicOfGuarding))); // Tunic of Guarding
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "AndreasVesalius"), new Point3D(3457, 2550, 35), Map.Trammel);
		}
	}

	public class BruisesBandagesAndBlood : ChainQuest
	{
		public BruisesBandagesAndBlood()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077676; // Bruises, Bandages and Blood
			Description = 1077679; // Head East out of town and go to Old Haven. Heal yourself and other players until you have raised your Healing skill to 50.<br><center>------</center><br>Ah, welcome to my humble practice. I am Avicenna, New Haven's resident Healer. A lot of adventurers head out into the wild from here, so I keep rather busy when they come back bruised, bleeding, or worse.<br><br>I can teach you how to bandage a wound, sure, but it's not a job for the queasy! For some folks, the mere sight of blood is too much for them, but it's something you'll get used to over time. It is one thing to cut open a living thing, but it's quite another to sew it back up and save it from sure death. 'Tis noble work, healing.<br><br>Best way for you to practice fixing up wounds is to head east out to Old Haven and either practice binding up your own wounds, or practice on someone else. Surely they'll be grateful for the assistance.<br><br>Make sure to take enough bandages with you! You don't want to run out in the middle of a tough fight.
			RefusalMessage = 1077680; // No? Are you sure? Well, when you feel that you're ready to practice your healing, come back to me. I'll be right here, fixing up adventurers and curing the occasional cold!
			InProgressMessage = 1077681; // Hail! 'Tis good to see you again. Unfortunately, you're not quite ready to call yourself an Apprentice Healer quite yet. Head back out to Old Haven, due east from here, and bandage up some wounds. Yours or someone else's, it doesn't much matter.
			CompletionMessage = 1077683; // Hello there, friend. I see you've returned in one piece, and you're an Apprentice Healer to boot! You should be proud of your accomplishment, as not everyone has "the touch" when it comes to healing.<br><br>I can't stand to see such good work go unrewarded, so I have something I'd like you to have. It's not much, but it'll help you heal just a little faster, and maybe keep you alive.<br><br>Good luck out there, friend, and don't forget to help your fellow adventurer whenever possible!
			CompletionNotice = 1077682; // You have achieved the rank of Apprentice Healer. Return to Avicenna in New Haven as soon as you can to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Healing, 500, true, true));

			Rewards.Add(new ItemReward(1077684, typeof(HealersTouch))); // Healer's Touch
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Avicenna"), new Point3D(3464, 2558, 35), Map.Trammel);
		}
	}

	public class TheInnerWarrior : ChainQuest
	{
		public TheInnerWarrior()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077696; // The Inner Warrior
			Description = 1077699; // Head East out of town to Old Haven. Expend stamina and mana until you have raised your Focus skill to 50.<br><center>------</center><br>Well, hello there. Don't you look like quite the adventurer!<br><br>You want to learn more about Focus, do you? I can teach you something about that, but first you should know that not everyone can be disciplined enough to excel at it. Focus is the ability to achieve inner balance in both body and spirit, so that you recover from physical and mental exertion faster than you otherwise would.<br><br>If you want to practice Focus, the best place to do that is east of here, in Old Haven, where you'll find an undead infestation. Exert yourself physically by engaging in combat and moving quickly. For testing your mental balance, expend mana in whatever way you find most suitable to your abilities. Casting spells and using abilities work well for consuming your mana.<br><br>Go. Train hard, and you will find that your concentration will improve naturally. When you've improved your ability to focus yourself at an Apprentice level, come back to me and I shall give you something worthy of your new ability.
			RefusalMessage = 1077700; // I'm disappointed. You have a lot of inner potential, and it would pain me greatly to see you waste that. Oh well. If you change your mind, I'll be right here.
			InProgressMessage = 1077701; // Hello again. I see you've returned, but it seems that your Focus skill hasn't improved as much as it could have. Just head east, to Old Haven, and exert yourself physically and mentally as much as possible. To do this physically, engage in combat and move as quickly as you can. For exerting yourself mentally, expend mana in whatever way you find most suitable to your abilities. Casting spells and using abilities work well for consuming your mana.<br><br>Return to me when you have gained enough Focus skill to be considered an Apprentice Stoic.
			CompletionMessage = 1077703; // Look who it is! I knew you could do it if you just had the discipline to apply yourself. It feels good to recover from battle so quickly, doesn't it? Just wait until you become a Grandmaster, it's amazing!<br><br>Please take this gift, as you've more than earned it with your hard work. It will help you recover even faster during battle, and provides a bit of protection as well.<br><br>You have so much more potential, so don't stop trying to improve your Focus now! Safe travels!
			CompletionNotice = 1077702; // You have achieved the rank of Apprentice Stoic (for Focus). Return to Sarsmea Smythe in New Haven to see what kind of reward she has waiting for you.

			Objectives.Add(new GainSkillObjective(SkillName.Focus, 500, true, true));

			Rewards.Add(new ItemReward(1077695, typeof(ClaspOfConcentration))); // Clasp of Concentration
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "SarsmeaSmythe"), new Point3D(3492, 2577, 15), Map.Trammel);
		}
	}

	public class TheArtOfStealth : ChainQuest
	{
		public TheArtOfStealth()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078154; // The Art of Stealth
			Description = 1078158; // Head East out of town and go to Old Haven. While wielding your fencing weapon, battle monsters with focus attack and summon mirror images up to 40 Ninjitsu skill, and continue practicing focus attack on monsters until 50 Ninjitsu skill.<br><center>------</center><br>Welcome, young one. You seek to learn Ninjitsu. With it, and the book of Ninjitsu, a Ninja can evoke a number of special abilities including transforming into a variety of creatures that give unique bonuses, using stealth to attack unsuspecting opponents or just plain disappear into thin air! If you do not have a book of Ninjitsu, you can purchase one from me.<br><br>I have an assignment for you. Head East out of town and go to Old Haven. While wielding your fencing weapon, battle monsters with focus attack and summon mirror images up to Novice rank, and continue focusing your attacks for greater damage on monsters until you become an Apprentice Ninja. Each image will absorb one attack. The art of deception is a strong defense. Use it wisely.<br><br>Come back to me once you have achieved the rank of Apprentice Ninja, and I shall reward you with something useful.
			RefusalMessage = 1078159; // Come back to me if you with to learn Ninjitsu in the future.
			InProgressMessage = 1078160; // You have not achieved the rank of Apprentice Ninja. Come back to me once you have done so.
			CompletionMessage = 1078162; // You have done well, young one. Please accept this kryss as a gift. It is called the "Silver Serpent Blade". With it, you will strike with precision and power. This should aid you in your journey as a Ninja. Farewell.
			CompletionNotice = 1078161; // You have achieved the rank of Apprentice Ninja. Return to Ryuichi in New Haven to see what kind of reward he has waiting for you.

			Objectives.Add(new GainSkillObjective(SkillName.Ninjitsu, 500, true, true));

			Rewards.Add(new ItemReward(1078163, typeof(SilverSerpentBlade))); // Silver Serpent Blade
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Ryuichi"), new Point3D(3422, 2520, 21), Map.Trammel);
		}
	}

	public class BecomingOneWithTheShadows : ChainQuest
	{
		public BecomingOneWithTheShadows()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078164; // Becoming One with the Shadows
			Description = 1078168; // Practice hiding in the Ninja Dojo until you reach 50 Hiding skill.<br><center>------</center><br>Come closer. Don't be afraid. The shadows will not harm you. To be a successful Ninja, you must learn to become one with the shadows. The Ninja Dojo is the ideal place to learn the art of concealment. Practice hiding here.<br><br>Talk to me once you have achieved the rank of Apprentice Rogue (for Hiding), and I shall reward you.
			RefusalMessage = 1078169; // If you wish to become one with the shadows, come back and talk to me.
			InProgressMessage = 1078170; // You have not achieved the rank of Apprentice Rogue (for Hiding). Talk to me when you feel you have accomplished this.
			CompletionMessage = 1078172; // Not bad at all. You have learned to control your fear of the dark and you are becoming one with the shadows. If you haven't already talked to Jun, I advise you do so. Jun can teach you how to stealth undetected. Hiding and Stealth are essential skills to master when becoming a Ninja.<br><br>As promised, I have a reward for you. Here are some smokebombs. As long as you are an Apprentice Ninja and have mana available you will be able to use them. They will allow you to hide while in the middle of combat. I hope these serve you well.
			CompletionNotice = 1078171; // You have achieved the rank of Apprentice Rogue (for Hiding). Return to Chiyo in New Haven to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Hiding, 500, true, true));

			Rewards.Add(new ItemReward(1078173, typeof(BagOfSmokeBombs))); // Bag of Smoke Bombs
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Chiyo"), new Point3D(3420, 2516, 21), Map.Trammel);
		}
	}

	public class WalkingSilently : ChainQuest
	{
		public WalkingSilently()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078174; // Walking Silently
			Description = 1078178; // Head East out of town and go to Old Haven. While wearing normal clothes, practice Stealth there until you reach 50 Stealth skill.<br><center>------</center><br>You there. You're not very quiet in your movements. I can help you with that. Not only must you must learn to become one with the shadows, but also you must learn to quiet your movements. Old Haven is the ideal place to learn how to Stealth.<br><br>Head East out of town and go to Old Haven. While wearing normal clothes, practice Stealth there. Stealth becomes more difficult as you wear heavier pieces of armor, so for now, only wear clothes while practicing Stealth.<br><br>You can only Stealth once you are hidden.  If you become visible, use your Hiding skill, and begin slowing walking.<br><br>Come back to me once you have achieved the rank of Apprentice Rogue (for Stealth), and I will reward you with something useful.
			RefusalMessage = 1078179; // If you want to learn to quiet your movements, talk to me, and I will help you.
			InProgressMessage = 1078180; // You have not achieved the rank of Apprentice Rogue (for Stealth). Come back to me when you feel you have accomplished this.
			CompletionMessage = 1078182; // Good. You have learned to quiet your movements. If you haven't already talked to Chiyo, I advise you do so. Chiyo can teach you how to become one with the shadows. Hiding and Stealth are essential skills to master when becoming a Ninja.<br><br>Here is your reward. This leather Ninja jacket is called "Twilight Jacket". It will offer greater protection to you. I hope this serve you well.
			CompletionNotice = 1078181; // You have achieved the rank of Apprentice Rogue (for Stealth). Return to Jun in New Haven to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Stealth, 500, true, true));

			Rewards.Add(new ItemReward(1078183, typeof(TwilightJacket))); // Twilight Jacket
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Jun"), new Point3D(3422, 2516, 21), Map.Trammel);
		}
	}

	public class EyesOfARanger : ChainQuest
	{
		public EyesOfARanger()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078211; // Eyes of a Ranger
			Description = 1078217; // Track animals, monsters, and people on Haven Island until you have raised your Tracking skill to 50.<br><center>------</center><br>Hello friend. I am Walker, Grandmaster Ranger. An adventurer needs to keep alive in the wilderness. Being able to track those around you is essential to surviving in dangerous places. Certain Ninja abilities are more potent when the Ninja possesses Tracking knowledge. If you want to be a Ninja, or if you simply want to get a leg up on the creatures that habit these parts, I advise you learn how to track them.<br><br>You can track any animals, monsters, or people on Haven Island. Clear your mind, focus, and note any tracks in the ground or sounds in the air that can help you find your mark. You can do it, friend. I have faith in you.<br><br>Come back to me once you have achieved the rank of Apprentice Ranger (for Tracking), and I will give you something that may help you in your travels. Take care, friend.
			RefusalMessage = 1078218; // Farewell, friend. Be careful out here. If you change your mind and want to learn Tracking, come back and talk to me.
			InProgressMessage = 1078219; // So far so good, kid. You are still alive, and you are getting the hang of Tracking. There are many more animals, monsters, and people to track. Come back to me once you have tracked them.
			CompletionMessage = 1078221; // I knew you could do it! You have become a fine Ranger. Just keep practicing, and one day you will become a Grandmaster Ranger. Just like me.<br><br>I have a little something for you that will hopefully aid you in your journeys. These leggings offer some resistances that will hopefully protect you from harm. I hope these serve you well. Farewell, friend.
			CompletionNotice = 1078220; // You have achieved the rank of Apprentice Ranger (for Tracking). Return to Walker in New Haven to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Tracking, 500, true, true));

			Rewards.Add(new ItemReward(1078222, typeof(WalkersLeggings))); // Walker's Leggings
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Walker"), new Point3D(3429, 2518, 19), Map.Trammel);
		}
	}

	public class TheWayOfTheSamurai : ChainQuest
	{
		public TheWayOfTheSamurai()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078007; // The Way of the Samurai
			Description = 1078010; // Head East out of town and go to Old Haven. use the Confidence defensive stance and attempt to honorably execute monsters there until you have raised your Bushido skill to 50.<br><center>------</center><br>Greetings. I see you wish to learn the Way of the Samurai. Wielding a blade is easy. Anyone can grasp a sword's hilt. Learning how to fight properly and skillfully is to become an Armsman. Learning how to master weapons, and even more importantly when not to use them, is the Way of the Warrior. The Way of the Samurai. The Code of the Bushido. That is why you are here.<br><br>Adventure East to Old Haven. Use the Confidence defensive stance and attempt to honorably execute the undead that inhabit there. You will need a book of Bushido to perform these abilities. If you do not possess a book of Bushido, you can purchase one from me. <br><br>If you fail to honorably execute the undead, your defenses will be greatly weakened: Resistances will suffer and Resisting Spells will suffer. A successful parry instantly ends the weakness. If you succeed, however, you will be infused with strength and healing. Your swing speed will also be boosted for a short duration. With practice, you will learn how to master your Bushido abilities.<br><br>Return to me once you feel that you have become an Apprentice Samurai.
			RefusalMessage = 1078011; // Good journey to you. Return to me if you wish to live the life of a Samurai.
			InProgressMessage = 1078012; // You are not ready to become an Apprentice Samurai. There are still more undead to lay to rest. Return to me once you have done so.
			CompletionMessage = 1078014; // You have proven yourself young one. You will continue to improve as your skills are honed with age. You are an honorable warrior, worthy of the rank of Apprentice Samurai.  Please accept this no-dachi as a gift. It is called "The Dragon's Tail". Upon a successful strike in combat, there is a chance this mighty weapon will replenish your stamina equal to the damage of your attack. I hope "The Dragon's Tail" serves you well. You have earned it. Farewell for now.
			CompletionNotice = 1078013; // You have achieved the rank of Apprentice Samurai. Return to Hamato in New Haven to report your progress.

			Objectives.Add(new GainSkillObjective(SkillName.Bushido, 500, true, true));

			Rewards.Add(new ItemReward(1078015, typeof(TheDragonsTail))); // The Dragon's Tail
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Hamato"), new Point3D(3493, 2414, 55), Map.Trammel);
		}
	}

	public class TheAllureOfDarkMagic : ChainQuest
	{
		public TheAllureOfDarkMagic()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078036; // The Allure of Dark Magic
			Description = 1078039; // Head East out of town and go to Old Haven. Cast Evil Omen and Pain Spike against monsters there until you have raised your Necromancy skill to 50.<br><center>------</center><br>Welcome! I see you are allured by the dark magic of Necromancy. First, you must prove yourself worthy of such knowledge. Undead currently occupy the town of Old Haven. Practice your harmful Necromancy spells on them such as Evil Omen and Pain Spike.<br><br>Make sure you have plenty of reagents before embarking on your journey. Reagents are required to cast Necromancy spells. You can purchase extra reagents from me, or you can find reagents growing in the nearby wooded areas. You can see which reagents are required for each spell by looking in your spellbook.<br><br>Come back to me once you feel that you are worthy of the rank of Apprentice Necromancer and I will reward you with the knowledge you desire.
			RefusalMessage = 1078040; // You are weak after all. Come back to me when you are ready to practice Necromancy.
			InProgressMessage = 1078041; // You have not achieved the rank of Apprentice Necromancer. Come back to me once you feel that you are worthy of the rank of Apprentice Necromancer and I will reward you with the knowledge you desire.
			CompletionMessage = 1078043; // You have done well, my young apprentice. Behold! I now present to you the knowledge you desire. This spellbook contains all the Necromancer spells. The power is intoxicating, isn't it?
			CompletionNotice = 1078042; // You have achieved the rank of Apprentice Necromancer. Return to Mulcivikh in New Haven to receive the knowledge you desire.

			Objectives.Add(new GainSkillObjective(SkillName.Necromancy, 500, true, true));

			Rewards.Add(new InternalReward());
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Mulcivikh"), new Point3D(3548, 2456, 15), Map.Trammel);
		}

		private class InternalReward : ItemReward
		{
			public InternalReward()
				: base(1078052, typeof(BookOfNecromancy)) // Complete Necromancer Spellbook
			{
			}

			public override Item CreateItem()
			{
				var item = base.CreateItem();

				var book = item as Spellbook;

				if (book != null)
				{
					book.Content = (1ul << book.BookCount) - 1;
				}

				return item;
			}
		}
	}

	public class ChannelingTheSupernatural : ChainQuest
	{
		public ChannelingTheSupernatural()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1078044; // Channeling the Supernatural
			Description = 1078047; // Head East out of town and go to Old Haven. Use Spirit Speak and channel energy from either yourself or nearby corpses there. You can also cast Necromancy spells as well to raise Spirit Speak. Do these activities until you have raised your Spirit Speak skill to 50.<br><center>------</center><br>How do you do? Channeling the supernatural through Spirit Speak allows you heal your wounds. Such channeling expends your mana, so be mindful of this. Spirit Speak enhances the potency of your Necromancy spells. The channeling powers of a Medium are quite useful when practicing the dark magic of Necromancy.<br><br>It is best to practice Spirit Speak where there are a lot of corpses. Head East out of town and go to Old Haven. Undead currently reside there. Use Spirit Speak and channel energy from either yourself or nearby corpses. You can also cast Necromancy spells as well to raise Spirit Speak.<br><br>Come back to me once you feel that you are worthy of the rank of Apprentice Medium and I will reward you with something useful.
			RefusalMessage = 1078048; // Channeling the supernatural isn't for everyone. It is a dark art. See me if you ever wish to pursue the life of a Medium.
			InProgressMessage = 1078049; // Back so soon? You have not achieved the rank of Apprentice Medium. Come back to me once you feel that you are worthy of the rank of Apprentice Medium and I will reward you with something useful.
			CompletionMessage = 1078051; // Well done! Channeling the supernatural is taxing, indeed. As promised, I will reward you with this bag of Necromancer reagents. You will need these if you wish to also pursue the dark magic of Necromancy. Good journey to you.
			CompletionNotice = 1078050; // You have achieved the rank of Apprentice Medium. Return to Morganna in New Haven to receive your reward.

			Objectives.Add(new GainSkillObjective(SkillName.SpiritSpeak, 500, true, true));

			Rewards.Add(new ItemReward(1078053, typeof(BagOfNecromancerReagents))); // Bag of Necromancer Reagents
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "Morganna"), new Point3D(3547, 2463, 15), Map.Trammel);
		}
	}

	public class TheDeluciansLostMine : ChainQuest
	{
		public TheDeluciansLostMine()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077750; // The Delucian’s Lost Mine
			Description = 1077753; // Find Jacob's Lost Mine and mine iron ore there, using a pickaxe or shovel. Bring it back to Jacob's forge and smelt the ore into ingots, until you have raised your Mining skill to 50. You may find a packhorse useful for hauling the ore around. The animal trainer in New Haven has packhorses for sale.<br><center>-----</center><br>Howdy! Welcome to my camp. It's not much, I know, but it's all I'll be needin' up here. I don't need them fancy things those townspeople have down there in New Haven. Nope, not one bit. Just me, Bessie, my pick and a thick vein 'o valorite.<br><br>Anyhows, I'm guessin' that you're up here to ask me about minin', aren't ya? Well, don't be expectin' me to tell you where the valorite's at, cause I ain't gonna tell the King of Britannia, much less the likes of you. But I will show ya how to mine and smelt iron, cause there certainly is a 'nough of up in these hills.<br><br>*Jacob looks around, with a perplexed look on his face*<br><br>Problem is, I can't remember where my iron mine's at, so you'll have to find it yourself. Once you're there, have at it with a pickaxe or shovel, then haul it back to camp and I'll show ya how to smelt it. Ya look a bit wimpy, so you might wanna go buy yourself a packhorse in town from the animal trainer to help you haul around all that ore.<br><br>When you're an Apprentice Miner, talk to me and I'll give ya a little somethin' I've got layin' around here... somewhere.
			RefusalMessage = 1077754; // Couldn’t find my iron mine, could ya? Well, neither can I!<br><br>*Jacob laughs*<br><br>Oh, ya don’t wanna find it? Well, allrighty then, ya might as well head on back down to town then and stop cluttering up my camp. Come back and talk to me if you’re interested in learnin’ ‘bout minin’.
			InProgressMessage = 1077755; // Where ya been off a gallivantin’ all day, pilgrim? You ain’t seen no hard work yet! Get yer arse back out there to my mine and dig up some more iron. Don’t forget to take a pickaxe or shovel, and if you’re so inclined, a packhorse too.
			CompletionMessage = 1077757; // Dang gun it! If that don't beat all! Ya went and did it, didn’t ya? What we got ourselves here is a mighty fine brand spankin’ new Apprentice Miner!<br><br>I can see ya put some meat on them bones too while you were at it!<br><br>Here’s that little somethin’ I told ya I had for ya. It’s a pickaxe with some high falutin’ magic inside that’ll help you find the good stuff when you’re off minin’. It wears out fast, though, so you can only use it a few times a day.<br><br>Welp, I’ve got some smeltin’ to do, so off with ya. Good luck, pilgrim!
			CompletionNotice = 1077756; // You have achieved the rank of Apprentice Miner. Return to Jacob Waltz in at his camp in the hills above New Haven as soon as you can to claim your reward.

			Objectives.Add(new GainSkillObjective(SkillName.Mining, 500, true, true));

			Rewards.Add(new ItemReward(1077758, typeof(JacobsPickaxe))); // Jacob's Pickaxe
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "JacobWaltz"), new Point3D(3504, 2741, 0), Map.Trammel);
		}
	}

	public class ItsHammerTime : ChainQuest
	{
		public ItsHammerTime()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = 1077732; // It’s Hammer Time!
			Description = 1077735; // Create new daggers and maces using the forge and anvil in George's shop. Try making daggers up to 45 skill, the switch to making maces until 50 skill.<br><center>-----</center><br>Hail, and welcome to my humble shop. I'm George Hephaestus, New Haven's blacksmith. I assume that you're here to ask me to train you to be an Apprentice Blacksmith. I certainly can do that, but you're going to have to supply your own ingots.<br><br>You can always buy them at the market, but I highly suggest that you mine your own. That way, any items you sell will be pure profit!<br><br>So, once you have a supply of ingots, use my forge and anvil here to create items. You'll also need a supply of the proper tools; you can use a smith's hammer, a sledgehammer or tongs. You can either make them yourself if you have the tinkering skill, or buy them from a tinker at the market.<br><br>Since I'll be around to give you advice, you'll learn faster here than anywhere else. Start off making daggers until you reach 45 blacksmithing skill, then switch to maces until you've achieved 50. Once you've done that, come talk to me and I'll give you something for your hard work.
			RefusalMessage = 1077736; // You're not interested in learning to be a smith, eh? I thought for sure that's why you were here. Oh well, if you change your mind, you can always come back and talk to me.
			InProgressMessage = 1077737; // You’re doing well, but you’re not quite there yet. Remember that the quickest way to learn is to make daggers up until 45 skill, and then switch to maces. Also, don’t forget that using my forge and anvil will help you learn faster.
			CompletionMessage = 1077739; // I've been watching you get better and better as you've been smithing, and I have to say, you're a natural! It's a long road to being a Grandmaster Blacksmith, but I have no doubt that if you put your mind to it you'll get there someday. Let me give you one final piece of advice. If you're smithing just to practice and improve your skill, make items that are moderately difficult (60-80% success chance), and try to stick to ones that use less ingots.<br><br>Now that you're an Apprentice Blacksmith, I have something for you. While you were busy practicing, I was crafting this hammer for you. It's finely balanced, and has a bit of magic imbued within that will help you craft better items. However, that magic needs to restore itself over time, so you can only use it so many times per day. I hope you find it useful!
			CompletionNotice = 1077738; // You have achieved the rank of Apprentice Blacksmith. Return to George Hephaestus in New Haven to see what kind of reward he has waiting for you.

			Objectives.Add(new GainSkillObjective(SkillName.Blacksmith, 500, true, true));

			Rewards.Add(new ItemReward(1077740, typeof(HammerOfHephaestus))); // Hammer of Hephaestus
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 0, "GeorgeHephaestus"), new Point3D(3471, 2542, 36), Map.Trammel);
		}
	}
}