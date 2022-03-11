using Server.Mobiles;

using System;

namespace Server.Engines.ChainQuests.Definitions
{
	public class Responsibility : BaseEscort
	{
		public Responsibility()
		{
			Activated = true;
			Title = 1074352; // Responsibility
			Description = 1074524; // Oh!  I just don't know what to do.  My mother is away and my father told me not to talk to strangers ... *worried frown*  But my grandfather has sent word that he has been hurt and needs me to tend his wounds.  He has a small farm southeast of here.  Would you ... could you ... escort me there safely?
			RefusalMessage = 1074525; // I hope my grandfather will be alright.
			InProgressMessage = 1074526; // Grandfather's farm is a ways west of the Shrine of Spirituality. So, we're not quite there yet.  Thank you again for keeping me safe.

			Objectives.Add(new EscortObjective(new QuestArea(1074781, "Sheep Farm"))); // Sheep Farm

			Rewards.Add(ItemReward.BagOfTrinkets);
		}

		// OSI sends this instead, but it doesn't make sense for an escortable
		//public override void OnComplete( ChainQuestInstance instance )
		//{
		//	instance.Player.SendLocalizedMessage( 1073775, "", 0x23 ); // Your quest is complete. Return for your reward.
		//}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30), 0, 5, "Lissbet"), new Point3D(1568, 1040, -7), Map.Ilshenar);
			PutSpawner(new Spawner(1, 5, 10, 0, 8, "GrandpaCharley"), new Point3D(1322, 1331, -14), Map.Ilshenar);
			PutSpawner(new Spawner(1, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30), 0, 3, "Sheep"), new Point3D(1308, 1324, -14), Map.Ilshenar);
		}
	}

	public class SomethingToWailAbout : ChainQuest
	{
		public SomethingToWailAbout()
		{
			Activated = true;
			Title = 1073071; // Something to Wail About
			Description = 1073561; // Can you hear them? The never-ending howling? The incessant wailing? These banshees, they never cease! Never! They haunt my nights. Please, I beg you -- will you silence them? I would be ever so grateful.
			RefusalMessage = 1073580; // I hope you'll reconsider. Until then, farwell.
			InProgressMessage = 1073581; // Until you kill 12 Wailing Banshees, there will be no peace.

			Objectives.Add(new KillObjective(12, new Type[] { typeof(WailingBanshee) }, "wailing banshees"));

			Rewards.Add(ItemReward.BagOfTreasure);
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 4, "Jelrice"), new Point3D(1176, 1196, -25), Map.Ilshenar);
		}
	}

	public class Runaways : ChainQuest
	{
		public Runaways()
		{
			Activated = true;
			Title = 1072993; // Runaways!
			Description = 1073026; // You've got to help me out! Those wild ostards have been causing absolute havok around here.  Kill them off before they destroy my land.  There are around twelve of them.
			RefusalMessage = 1072270; // Well, okay. But if you decide you are up for it after all, c'mon back and see me.
			InProgressMessage = 1072271; // You're not quite done yet.  Get back to work!

			Objectives.Add(new KillObjective(12, new Type[] { typeof(FrenziedOstard) }, "frenzied ostards"));

			Rewards.Add(ItemReward.BagOfTrinkets);
		}
	}

	public class ViciousPredator : ChainQuest
	{
		public ViciousPredator()
		{
			Activated = true;
			Title = 1072994; // Vicious Predator
			Description = 1073028; // You've got to help me out! Those dire wolves have been causing absolute havok around here.  Kill them off before they destroy my land.  They run around in a pack of around ten.
			RefusalMessage = 1072270; // Well, okay. But if you decide you are up for it after all, c'mon back and see me.
			InProgressMessage = 1072271; // You're not quite done yet.  Get back to work!

			Objectives.Add(new KillObjective(10, new Type[] { typeof(DireWolf) }, "dire wolves"));

			Rewards.Add(ItemReward.BagOfTrinkets);
		}
	}

	public class GuileIrkAndSpite : ChainQuest
	{
		public GuileIrkAndSpite()
		{
			Activated = true;
			Title = 1074739; // Guile, Irk and Spite
			Description = 1074740; // You know them, don't you.  The three?  They look like you, you'll see. They looked like me, I remember, they looked like, well, you'll see.  The three.  They'll drive you mad too, if you let them.  They are trouble, and they need to be slain.  Seek them out.
			RefusalMessage = 1074745; // You just don't understand the gravity of the situation.  If you did, you'd agree to my task.
			InProgressMessage = 1074746; // Perhaps I was unclear.  You'll know them when you see them, because you'll see you, and you, and you.  Hurry now.
			CompletionMessage = 1074747; // Are you one of THEM?  Ahhhh!  Oh, wait, if you were them, then you'd be me.  So you're -- you.  Good job!

			Objectives.Add(new KillObjective(1, new Type[] { typeof(Guile) }, "Guile"));
			Objectives.Add(new KillObjective(1, new Type[] { typeof(Irk) }, "Irk"));
			Objectives.Add(new KillObjective(1, new Type[] { typeof(Spite) }, "Spite"));

			Rewards.Add(ItemReward.Strongbox);
		}

		public override void Generate()
		{
			base.Generate();

			PutSpawner(new Spawner(1, 5, 10, 0, 5, "Yorus"), new Point3D(1389, 423, -24), Map.Ilshenar);
		}
	}
}