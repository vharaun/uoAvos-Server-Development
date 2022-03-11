#region Developer Notations

/// If you wish to add more collectible aquatic life, then you will have to go to 
/// the following file: 'Aquarium.cs' and search for: 'BrineShrimp' 

/// Add your new collectible to the list of cases by copying and pasting the
/// existing code and changing the fish type: 'fish = new MyNewCollectible();'

/// If you wish to add an addition aquarium award item, then you will have to go to 
/// the following file: 'Aquarium.cs' and search for: 'FishBones' 

/// Add your new aquarium reward to the type list by copying and pasting the
/// existing code and changing the type: 'typeof( MyNewAquariumReward )'

#endregion

namespace Server.Items
{
	public partial class AquariumFishNet : SpecialFishingNet
	{
		private BaseAquaticLife GiveFish(Mobile from)
		{
			var skill = from.Skills.Fishing.Value;

			if ((skill / 100.0) >= Utility.RandomDouble())
			{
				var max = (int)skill / 5;

				if (max > 20)
				{
					max = 20;
				}

				switch (Utility.Random(max))
				{
					case 0: return new MinocBlueFish();
					case 1: return new Shrimp();
					case 2: return new FandancerFish();
					case 3: return new GoldenBroadtail();
					case 4: return new RedDartFish();
					case 5: return new AlbinoCourtesanFish();
					case 6: return new MakotoCourtesanFish();
					case 7: return new NujelmHoneyFish();
					case 8: return new Jellyfish();
					case 9: return new SpeckledCrab();
					case 10: return new LongClawCrab();
					case 11: return new AlbinoFrog();
					case 12: return new KillerFrog();
					case 13: return new VesperReefTiger();
					case 14: return new PurpleFrog();
					case 15: return new BritainCrownFish();
					case 16: return new YellowFinBluebelly();
					case 17: return new SpottedBuccaneer();
					case 18: return new SpinedScratcherFish();
					default: return new SmallMouthSuckerFin();
				}
			}

			return new MinocBlueFish();
		}
	}
}