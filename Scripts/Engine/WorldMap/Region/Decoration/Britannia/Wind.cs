using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Wind { get; } = Register(DecorationTarget.Britannia, "Wind", new DecorationList[]
			{
				#region Entries
				
				new("Marble Wall", typeof(Static), 693, "", new DecorationEntry[]
				{
					new(5310, 93, 35, ""),
				}),
				new("Marble Wall", typeof(Static), 695, "", new DecorationEntry[]
				{
					new(5310, 118, 35, ""),
				}),
				new("Cave Floor", typeof(Static), 1340, "", new DecorationEntry[]
				{
					new(5258, 198, 15, ""),
				}),
				new("Cave Floor", typeof(Static), 1341, "", new DecorationEntry[]
				{
					new(5259, 198, 15, ""),
				}),
				new("Cave Floor", typeof(Static), 1342, "", new DecorationEntry[]
				{
					new(5258, 199, 15, ""),
				}),
				new("Cave Floor", typeof(Static), 1361, "", new DecorationEntry[]
				{
					new(5259, 199, 15, ""),
				}),
				new("Marble Roof", typeof(Static), 1595, "", new DecorationEntry[]
				{
					new(5154, 107, 25, ""),
				}),
				new("Marble", typeof(Static), 1801, "", new DecorationEntry[]
				{
					new(5220, 144, 0, ""),
					new(5221, 144, 0, ""),
					new(5224, 137, 20, ""),
					new(5224, 140, 20, ""),
					new(5225, 137, 20, ""),
					new(5225, 140, 20, ""),
					new(5226, 137, 20, ""),
					new(5226, 140, 20, ""),
					new(5227, 137, 20, ""),
					new(5227, 140, 20, ""),
					new(5228, 137, 20, ""),
					new(5228, 140, 20, ""),
					new(5244, 169, 15, ""),
					new(5245, 169, 15, ""),
					new(5281, 123, 20, ""),
					new(5282, 123, 20, ""),
					new(5301, 127, 15, ""),
					new(5302, 127, 15, ""),
					new(5321, 85, 25, ""),
					new(5321, 90, 25, ""),
					new(5322, 85, 25, ""),
					new(5322, 90, 25, ""),
					new(5323, 85, 25, ""),
					new(5323, 90, 25, ""),
					new(5324, 85, 25, ""),
					new(5324, 90, 25, ""),
					new(5325, 85, 25, ""),
					new(5325, 90, 25, ""),
					new(5326, 85, 25, ""),
					new(5326, 90, 25, ""),
					new(5327, 85, 25, ""),
					new(5327, 90, 25, ""),
					new(5328, 85, 25, ""),
					new(5328, 90, 25, ""),
					new(5329, 85, 25, ""),
					new(5329, 90, 25, ""),
					new(5330, 85, 25, ""),
					new(5330, 90, 25, ""),
					new(5331, 85, 25, ""),
					new(5331, 90, 25, ""),
					new(5332, 85, 25, ""),
					new(5332, 90, 25, ""),
				}),
				new("Marble Stairs", typeof(Static), 1802, "", new DecorationEntry[]
				{
					new(5179, 50, 17, ""),
					new(5180, 50, 17, ""),
					new(5220, 145, 0, ""),
					new(5221, 145, 0, ""),
					new(5255, 230, 11, ""),
					new(5255, 231, 7, ""),
					new(5301, 128, 15, ""),
					new(5302, 128, 15, ""),
				}),
				new("Marble Stairs", typeof(Static), 1803, "", new DecorationEntry[]
				{
					new(5286, 144, 15, ""),
					new(5310, 134, 15, ""),
					new(5310, 135, 15, ""),
				}),
				new("Marble Stairs", typeof(Static), 1804, "", new DecorationEntry[]
				{
					new(5281, 122, 20, ""),
					new(5282, 122, 20, ""),
				}),
				new("Marble Stairs", typeof(Static), 1805, "", new DecorationEntry[]
				{
					new(5224, 175, 24, ""),
					new(5224, 176, 24, ""),
					new(5237, 164, 15, ""),
					new(5237, 165, 15, ""),
					new(5253, 180, 15, ""),
					new(5253, 181, 15, ""),
					new(5280, 144, 15, ""),
				}),
				new("Stalagmites", typeof(Static), 2272, "", new DecorationEntry[]
				{
					new(5216, 203, 5, ""),
					new(5251, 236, 5, ""),
				}),
				new("Flowstone", typeof(Static), 2275, "", new DecorationEntry[]
				{
					new(5251, 235, 5, ""),
				}),
				new("Stalagmites", typeof(Static), 2276, "", new DecorationEntry[]
				{
					new(5211, 233, 25, ""),
				}),
				new("Stalagmites", typeof(Static), 2279, "", new DecorationEntry[]
				{
					new(5297, 158, 15, ""),
				}),
				new("Slab Of Bacon", typeof(Static), 2423, "", new DecorationEntry[]
				{
					new(5348, 56, 19, ""),
				}),
				new("Raw Fish Steak", typeof(RawSaltwaterFishSteak), 2426, "", new DecorationEntry[]
				{
					new(5343, 57, 19, ""),
				}),
				new("Wedge Of Cheese", typeof(CheeseWedge), 2429, "", new DecorationEntry[]
				{
					new(5354, 53, 19, ""),
				}),
				new("French Bread", typeof(FrenchBread), 2444, "", new DecorationEntry[]
				{
					new(5351, 49, 19, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(5223, 175, 11, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2454, "", new DecorationEntry[]
				{
					new(5160, 33, 23, ""),
					new(5222, 174, 11, ""),
				}),
				new("Bottles Of Liquor", typeof(Static), 2461, "", new DecorationEntry[]
				{
					new(5160, 34, 23, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(5223, 174, 11, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(5223, 174, 11, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(5167, 18, 27, ""),
					new(5179, 18, 27, ""),
					new(5211, 167, 5, ""),
					new(5307, 31, 40, ""),
					new(5307, 35, 40, ""),
					new(5310, 35, 40, ""),
					new(5313, 31, 40, ""),
					new(5316, 35, 40, ""),
				}),
				new("Wooden Box", typeof(FillableWoodenBox), 2474, "", new DecorationEntry[]
				{
					new(5161, 18, 27, ""),
					new(5164, 18, 27, ""),
					new(5170, 18, 27, ""),
					new(5173, 18, 27, ""),
					new(5176, 18, 27, ""),
					new(5207, 167, 5, ""),
					new(5207, 174, 5, ""),
					new(5209, 167, 5, ""),
					new(5209, 174, 5, ""),
					new(5211, 174, 5, ""),
					new(5213, 167, 5, ""),
					new(5213, 174, 5, ""),
					new(5310, 31, 40, ""),
					new(5313, 35, 40, ""),
					new(5316, 31, 40, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5186, 89, 5, ""),
				}),
				new("Eggs", typeof(Eggs), 2485, "", new DecorationEntry[]
				{
					new(5355, 53, 19, ""),
				}),
				new("Cooked Bird", typeof(CookedBird), 2487, "", new DecorationEntry[]
				{
					new(5348, 57, 19, ""),
				}),
				new("Roast Pig", typeof(RoastPig), 2492, "", new DecorationEntry[]
				{
					new(5348, 59, 19, ""),
				}),
				new("Sausage", typeof(Sausage), 2497, "", new DecorationEntry[]
				{
					new(5348, 52, 19, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(5223, 174, 11, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2501, "", new DecorationEntry[]
				{
					new(5160, 36, 23, ""),
				}),
				new("Apple", typeof(Apple), 2512, "", new DecorationEntry[]
				{
					new(5345, 53, 19, ""),
				}),
				new("Ham", typeof(Ham), 2515, "", new DecorationEntry[]
				{
					new(5348, 55, 19, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(5223, 174, 11, ""),
					new(5224, 175, 11, ""),
					new(5346, 74, 31, ""),
				}),
				new("Plate Of Food", typeof(Static), 2520, "", new DecorationEntry[]
				{
					new(5342, 81, 31, ""),
					new(5342, 84, 31, ""),
					new(5343, 78, 31, ""),
					new(5346, 78, 31, ""),
				}),
				new("Plate Of Food", typeof(Static), 2521, "", new DecorationEntry[]
				{
					new(5344, 74, 31, ""),
				}),
				new("Cake", typeof(Cake), 2537, "", new DecorationEntry[]
				{
					new(5349, 49, 19, ""),
				}),
				new("Muffins", typeof(Muffins), 2539, "", new DecorationEntry[]
				{
					new(5346, 49, 19, ""),
				}),
				new("Milk", typeof(Pitcher), 2544, "Content=Milk", new DecorationEntry[]
				{
					new(5180, 19, 31, ""),
				}),
				new("Cut Of Ribs", typeof(Ribs), 2546, "", new DecorationEntry[]
				{
					new(5348, 53, 19, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(5224, 175, 11, ""),
					new(5344, 78, 31, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(5342, 83, 31, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(5224, 175, 11, ""),
					new(5345, 74, 31, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(5342, 82, 31, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(5224, 175, 11, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2601, "Unlit", new DecorationEntry[]
				{
					new(5345, 59, 15, ""),
					new(5346, 50, 15, ""),
					new(5351, 61, 15, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2608, "", new DecorationEntry[]
				{
					new(5308, 108, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(5258, 136, 20, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(5258, 135, 20, ""),
				}),
				new("Candelabra", typeof(Candelabra), 2845, "", new DecorationEntry[]
				{
					new(5152, 53, 31, ""),
				}),
				new("Candelabra", typeof(Static), 2854, "", new DecorationEntry[]
				{
					new(5305, 108, 15, ""),
					new(5341, 73, 25, ""),
					new(5345, 85, 25, ""),
					new(5350, 75, 25, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2855, "", new DecorationEntry[]
				{
					new(5150, 92, 5, ""),
					new(5154, 64, 25, ""),
					new(5163, 92, 5, ""),
					new(5210, 112, 0, ""),
					new(5217, 121, 0, ""),
					new(5225, 172, 5, ""),
					new(5236, 135, 15, ""),
					new(5238, 174, 15, ""),
					new(5238, 181, 15, ""),
					new(5241, 187, 15, ""),
					new(5246, 174, 15, ""),
					new(5246, 181, 15, ""),
					new(5146, 55, 25, ""),
					new(5151, 103, 5, ""),
					new(5157, 91, 5, ""),
					new(5177, 97, 5, ""),
					new(5187, 91, 5, ""),
					new(5197, 94, 5, ""),
					new(5198, 85, 5, ""),
					new(5207, 176, 5, ""),
					new(5208, 169, 5, ""),
					new(5213, 160, 5, ""),
					new(5234, 142, 15, ""),
					new(5234, 152, 15, ""),
					new(5241, 144, 15, ""),
					new(5241, 152, 15, ""),
					new(5265, 161, 15, ""),
				}),
				new("Large Vase", typeof(Static), 2885, "", new DecorationEntry[]
				{
					new(5177, 95, 5, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(5151, 55, 25, ""),
					new(5237, 138, 15, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(5239, 178, 15, ""),
					new(5239, 180, 15, ""),
					new(5243, 178, 15, ""),
					new(5243, 180, 15, ""),
					new(5341, 81, 25, ""),
					new(5341, 83, 25, ""),
					new(5341, 84, 25, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(5222, 173, 5, ""),
					new(5224, 173, 5, ""),
					new(5240, 174, 15, ""),
					new(5242, 174, 15, ""),
					new(5343, 73, 25, ""),
					new(5343, 77, 25, ""),
					new(5344, 73, 25, ""),
					new(5345, 77, 25, ""),
					new(5346, 73, 25, ""),
					new(5346, 77, 25, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "", new DecorationEntry[]
				{
					new(5222, 176, 5, ""),
					new(5224, 176, 5, ""),
					new(5240, 176, 15, ""),
					new(5242, 176, 15, ""),
					new(5268, 124, 20, ""),
					new(5343, 75, 25, ""),
					new(5343, 79, 25, ""),
					new(5344, 79, 25, ""),
					new(5345, 75, 25, ""),
					new(5346, 75, 25, ""),
					new(5346, 79, 25, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(5237, 145, 15, ""),
					new(5237, 149, 15, ""),
					new(5240, 145, 15, ""),
					new(5240, 149, 15, ""),
					new(5241, 178, 15, ""),
					new(5241, 180, 15, ""),
					new(5245, 178, 15, ""),
					new(5245, 180, 15, ""),
					new(5305, 31, 40, ""),
					new(5305, 33, 40, ""),
					new(5305, 36, 40, ""),
					new(5305, 38, 40, ""),
					new(5343, 81, 25, ""),
					new(5343, 82, 25, ""),
					new(5343, 84, 25, ""),
				}),
				new("Metal Signpost", typeof(Static), 2971, "", new DecorationEntry[]
				{
					new(5158, 107, 5, ""),
				}),
				new("Metal Signpost", typeof(Static), 2976, "", new DecorationEntry[]
				{
					new(5200, 98, 5, ""),
				}),
				new("Metal Signpost", typeof(Static), 2977, "", new DecorationEntry[]
				{
					new(5267, 131, 20, ""),
				}),
				new("Metal Signpost", typeof(Static), 2978, "", new DecorationEntry[]
				{
					new(5217, 124, 0, ""),
					new(5236, 155, 15, ""),
				}),
				new("Wand", typeof(Static), 3570, "", new DecorationEntry[]
				{
					new(5145, 82, 29, ""),
				}),
				new("Wand", typeof(Static), 3571, "", new DecorationEntry[]
				{
					new(5145, 74, 29, ""),
					new(5264, 163, 18, ""),
					new(5311, 114, 18, ""),
				}),
				new("Brazier", typeof(Brazier), 3633, "", new DecorationEntry[]
				{
					new(5145, 79, 29, ""),
					new(5145, 62, 25, ""),
					new(5145, 70, 25, ""),
					new(5177, 86, 5, ""),
					new(5177, 88, 5, ""),
					new(5179, 86, 5, ""),
					new(5300, 88, 15, ""),
				}),
				new("Scroll", typeof(Static), 3637, "", new DecorationEntry[]
				{
					new(5176, 90, 9, ""),
				}),
				new("Scroll", typeof(Static), 3640, "", new DecorationEntry[]
				{
					new(5176, 92, 9, ""),
				}),
				new("Spellbook", typeof(Static), 3643, "", new DecorationEntry[]
				{
					new(5145, 64, 30, ""),
					new(5145, 76, 29, ""),
					new(5264, 162, 18, ""),
					new(5304, 36, 46, ""),
					new(5311, 113, 18, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5261, 237, 5, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(5149, 91, 5, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5261, 159, 15, ""),
				}),
				new("Wooden Box", typeof(FillableWoodenBox), 3709, "", new DecorationEntry[]
				{
					new(5162, 23, 27, ""),
					new(5162, 26, 27, ""),
					new(5179, 24, 27, ""),
					new(5179, 27, 27, ""),
				}),
				new("Strong Box", typeof(MetalBox), 3712, "", new DecorationEntry[]
				{
					new(5308, 110, 15, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(5162, 20, 27, ""),
					new(5215, 161, 5, ""),
				}),
				new("Clean Bandage", typeof(Static), 3817, "", new DecorationEntry[]
				{
					new(5259, 129, 20, ""),
					new(5259, 133, 20, ""),
					new(5260, 125, 20, ""),
					new(5264, 124, 20, ""),
					new(5267, 123, 26, ""),
					new(5269, 123, 26, ""),
				}),
				new("Scroll", typeof(Static), 3829, "", new DecorationEntry[]
				{
					new(5291, 93, 21, ""),
				}),
				new("Scroll", typeof(Static), 3831, "", new DecorationEntry[]
				{
					new(5149, 53, 30, ""),
					new(5292, 89, 21, ""),
					new(5292, 95, 21, ""),
				}),
				new("Scroll", typeof(Static), 3833, "", new DecorationEntry[]
				{
					new(5150, 54, 31, ""),
					new(5151, 53, 31, ""),
				}),
				new("Spellbook", typeof(Static), 3834, "", new DecorationEntry[]
				{
					new(5145, 83, 29, ""),
					new(5176, 91, 9, ""),
					new(5291, 95, 21, ""),
					new(5304, 32, 46, ""),
				}),
				new("Bottle", typeof(Static), 3837, "", new DecorationEntry[]
				{
					new(5307, 88, 15, ""),
				}),
				new("Orange Potion", typeof(Static), 3847, "", new DecorationEntry[]
				{
					new(5301, 87, 19, ""),
				}),
				new("Blue Potion", typeof(Static), 3848, "", new DecorationEntry[]
				{
					new(5145, 65, 27, ""),
					new(5301, 87, 19, ""),
				}),
				new("Green Potion", typeof(Static), 3850, "", new DecorationEntry[]
				{
					new(5303, 87, 19, ""),
				}),
				new("Red Potion", typeof(Static), 3851, "", new DecorationEntry[]
				{
					new(5144, 74, 29, ""),
					new(5144, 83, 29, ""),
					new(5304, 37, 46, ""),
				}),
				new("Yellow Potion", typeof(Static), 3852, "", new DecorationEntry[]
				{
					new(5144, 65, 28, ""),
					new(5304, 87, 19, ""),
				}),
				new("Purple Potion", typeof(Static), 3853, "", new DecorationEntry[]
				{
					new(5144, 66, 25, ""),
					new(5304, 87, 19, ""),
				}),
				new("Empty Bottle", typeof(Static), 3854, "", new DecorationEntry[]
				{
					new(5145, 66, 28, ""),
				}),
				new("Batwing", typeof(Static), 3960, "", new DecorationEntry[]
				{
					new(5302, 88, 19, ""),
				}),
				new("Blackmoor", typeof(Static), 3961, "", new DecorationEntry[]
				{
					new(5302, 87, 19, ""),
				}),
				new("Blood Moss", typeof(Static), 3963, "", new DecorationEntry[]
				{
					new(5183, 85, 9, ""),
					new(5264, 164, 18, ""),
					new(5311, 115, 18, ""),
				}),
				new("Daemon Blood", typeof(Static), 3965, "", new DecorationEntry[]
				{
					new(5149, 54, 30, ""),
					new(5293, 90, 24, ""),
					new(5304, 33, 46, ""),
				}),
				new("Brimstone", typeof(Static), 3967, "", new DecorationEntry[]
				{
					new(5144, 66, 28, ""),
				}),
				new("Dragon's Blood", typeof(Static), 3970, "", new DecorationEntry[]
				{
					new(5292, 90, 23, ""),
				}),
				new("Garlic", typeof(Static), 3972, "", new DecorationEntry[]
				{
					new(5292, 94, 24, ""),
				}),
				new("Nightshade", typeof(Static), 3976, "", new DecorationEntry[]
				{
					new(5144, 65, 29, ""),
					new(5145, 75, 29, ""),
					new(5181, 85, 9, ""),
					new(5268, 123, 24, ""),
					new(5294, 89, 21, ""),
				}),
				new("Sulfurous Ash", typeof(Static), 3980, "", new DecorationEntry[]
				{
					new(5144, 84, 29, ""),
				}),
				new("Spiders' Silk", typeof(Static), 3981, "", new DecorationEntry[]
				{
					new(2685, 708, 0, ""),
					new(5145, 81, 29, ""),
				}),
				new("Nox Crystal", typeof(Static), 3982, "", new DecorationEntry[]
				{
					new(5304, 37, 46, ""),
				}),
				new("Wyrm's Heart", typeof(Static), 3985, "", new DecorationEntry[]
				{
					new(5294, 90, 24, ""),
				}),
				new("Pentagram", typeof(Static), 4074, "", new DecorationEntry[]
				{
					new(1361, 883, 0, ""),
					new(5191, 152, 0, ""),
					new(5200, 71, 17, ""),
					new(5217, 18, 15, ""),
				}),
				new("Entrance Teleporter", typeof(SkillTeleporter), 7107, "Skill=Magery;RequiredFixedPoint=715;MessageNumber=503382;PointDest=(5166, 245, 15)", new DecorationEntry[]
				{
					new(1361, 883, 0, ""),
				}),
				new("Book", typeof(DimensionalTravel), 4079, "", new DecorationEntry[]
				{
					new(5241, 175, 22, ""),
				}),
				new("Book", typeof(TheFight), 4079, "", new DecorationEntry[]
				{
					new(5244, 179, 22, ""),
				}),
				new("Book", typeof(RedBook), 4081, "", new DecorationEntry[]
				{
					new(5239, 145, 19, ""),
				}),
				new("Book", typeof(SongOfSamlethe), 4083, "", new DecorationEntry[]
				{
					new(5238, 144, 15, ""),
				}),
				new("Book", typeof(MajorTradeAssociation), 4083, "", new DecorationEntry[]
				{
					new(5240, 178, 21, ""),
				}),
				new("Book", typeof(TalkingToWisps), 4084, "", new DecorationEntry[]
				{
					new(5239, 148, 19, ""),
				}),
				new("Book", typeof(GuideToGuilds), 4084, "", new DecorationEntry[]
				{
					new(5240, 179, 21, ""),
				}),
				new("Book", typeof(DeceitDungeonOfHorror), 4084, "", new DecorationEntry[]
				{
					new(5244, 178, 21, ""),
				}),
				new("Glass Pitcher", typeof(Pitcher), 4086, "", new DecorationEntry[]
				{
					new(5160, 35, 23, ""),
				}),
				new("Pitcher Of Water", typeof(Pitcher), 4089, "Content=Water", new DecorationEntry[]
				{
					new(5180, 20, 31, ""),
				}),
				new("Skull Mug", typeof(Static), 4092, "", new DecorationEntry[]
				{
					new(5180, 21, 31, ""),
				}),
				new("Bread Loaf", typeof(Static), 4156, "", new DecorationEntry[]
				{
					new(5350, 49, 19, ""),
				}),
				new("Baked Pie", typeof(Static), 4161, "", new DecorationEntry[]
				{
					new(5347, 49, 19, ""),
				}),
				new("Unbaked Pie", typeof(Static), 4162, "", new DecorationEntry[]
				{
					new(5348, 49, 19, ""),
				}),
				new("Uncooked Pizza", typeof(Static), 4227, "", new DecorationEntry[]
				{
					new(5352, 49, 19, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(5160, 31, 17, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(5176, 22, 31, ""),
					new(5304, 29, 40, ""),
					new(5304, 40, 40, ""),
				}),
				new("Leg Of Lamb", typeof(LambLeg), 5642, "", new DecorationEntry[]
				{
					new(5348, 54, 19, ""),
				}),
				new("Bananas", typeof(Static), 5921, "", new DecorationEntry[]
				{
					new(5341, 53, 19, ""),
				}),
				new("Coconut", typeof(Static), 5923, "", new DecorationEntry[]
				{
					new(5342, 53, 19, ""),
				}),
				new("Lemon", typeof(Lemon), 5928, "", new DecorationEntry[]
				{
					new(5344, 53, 19, ""),
				}),
				new("Pear", typeof(Pear), 5933, "", new DecorationEntry[]
				{
					new(5343, 53, 19, ""),
				}),
				new("Scales", typeof(Scales), 6226, "", new DecorationEntry[]
				{
					new(5144, 75, 29, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(5144, 81, 29, ""),
					new(5145, 73, 29, ""),
					new(5178, 91, 5, ""),
					new(5180, 92, 5, ""),
					new(5181, 88, 7, ""),
					new(5182, 90, 5, ""),
					new(5267, 153, 18, ""),
					new(5268, 156, 15, ""),
					new(5314, 104, 18, ""),
					new(5315, 107, 15, ""),
					new(5144, 64, 29, ""),
					new(5270, 154, 15, ""),
					new(5317, 105, 15, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6232, "", new DecorationEntry[]
				{
					new(5179, 89, 6, ""),
					new(5266, 155, 15, ""),
					new(5269, 152, 15, ""),
					new(5313, 106, 15, ""),
					new(5316, 103, 15, ""),
				}),
				new("Raw Fish", typeof(Static), 7702, "", new DecorationEntry[]
				{
					new(5343, 58, 19, ""),
				}),
				new("Fish Heads", typeof(Static), 7707, "", new DecorationEntry[]
				{
					new(5343, 59, 19, ""),
				}),
				new("Book", typeof(Static), 7712, "", new DecorationEntry[]
				{
					new(5236, 145, 19, ""),
				}),
				new("Books", typeof(Static), 7713, "", new DecorationEntry[]
				{
					new(5236, 137, 19, ""),
				}),
				new("Books", typeof(Static), 7714, "", new DecorationEntry[]
				{
					new(5237, 137, 19, ""),
				}),
				new("Books", typeof(Static), 7715, "", new DecorationEntry[]
				{
					new(5239, 149, 19, ""),
				}),
				new("Books", typeof(Static), 7717, "", new DecorationEntry[]
				{
					new(5236, 149, 19, ""),
				}),
				new("Strength", typeof(Static), 7996, "", new DecorationEntry[]
				{
					new(5304, 38, 44, ""),
				}),
				new("Arch Cure", typeof(Static), 8005, "", new DecorationEntry[]
				{
					new(5304, 88, 19, ""),
				}),
				
				#endregion
			});
		}
	}
}
