using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] SerpentsHold { get; } = Register(DecorationTarget.Britannia, "Serpents Hold", new DecorationList[]
			{
				#region Entries
				
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(3058, 3351, 15, ""),
					new(3055, 3407, 15, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW", new DecorationEntry[]
				{
					new(3059, 3351, 15, ""),
					new(3056, 3407, 15, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW", new DecorationEntry[]
				{
					new(3023, 3432, 15, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(3023, 3431, 15, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2150, "Facing=WestCW", new DecorationEntry[]
				{
					new(2902, 3519, 10, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2152, "Facing=EastCCW", new DecorationEntry[]
				{
					new(2903, 3519, 10, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2158, "Facing=SouthCW", new DecorationEntry[]
				{
					new(2911, 3516, 10, ""),
					new(2911, 3522, 10, ""),
					new(3041, 3467, 15, ""),
					new(3027, 3467, 15, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2160, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(2911, 3515, 10, ""),
					new(2911, 3521, 10, ""),
					new(3041, 3466, 15, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1749, "Facing=WestCW", new DecorationEntry[]
				{
					new(3051, 3375, 15, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1751, "Facing=EastCCW", new DecorationEntry[]
				{
					new(3052, 3375, 15, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1755, "Facing=EastCW", new DecorationEntry[]
				{
					new(3053, 3364, 15, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1757, "Facing=SouthCW", new DecorationEntry[]
				{
					new(2879, 3508, 10, ""),
					new(2887, 3504, 10, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1759, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(2887, 3503, 10, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(3058, 3391, 15, ""),
				}),
				new("Wooden Wall", typeof(Static), 167, "", new DecorationEntry[]
				{
					new(2879, 3498, 10, ""),
				}),
				new("Wooden Wall", typeof(Static), 173, "", new DecorationEntry[]
				{
					new(3050, 3375, 15, ""),
				}),
				new("Stone Wall", typeof(Static), 200, "", new DecorationEntry[]
				{
					new(3036, 3343, 35, ""),
				}),
				new("Stone Pavers", typeof(Static), 1315, "", new DecorationEntry[]
				{
					new(3016, 3345, 35, ""),
				}),
				new("Thatch Roof", typeof(Static), 1447, "", new DecorationEntry[]
				{
					new(2897, 3520, 30, ""),
				}),
				new("Fireplace", typeof(Static), 2266, "", new DecorationEntry[]
				{
					new(3008, 3456, 15, ""),
				}),
				new("Fireplace", typeof(Static), 2267, "", new DecorationEntry[]
				{
					new(3008, 3455, 15, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(3008, 3453, 15, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(2974, 3352, 15, ""),
				}),
				new("Fireplace", typeof(Static), 2399, "", new DecorationEntry[]
				{
					new(2976, 3352, 15, ""),
				}),
				new("Fireplace", typeof(Static), 2400, "", new DecorationEntry[]
				{
					new(2975, 3352, 15, ""),
				}),
				new("Jugs Of Cider", typeof(Static), 2445, "", new DecorationEntry[]
				{
					new(2969, 3416, 15, ""),
				}),
				new("Fruit Basket", typeof(FruitBasket), 2451, "", new DecorationEntry[]
				{
					new(2969, 3404, 19, ""),
					new(2969, 3410, 19, ""),
				}),
				new("Mug", typeof(CeramicMug), 2457, "", new DecorationEntry[]
				{
					new(3031, 3347, 21, ""),
				}),
				new("Bottles Of Ale", typeof(Static), 2466, "", new DecorationEntry[]
				{
					new(2968, 3416, 15, ""),
				}),
				new("Metal Chest", typeof(FillableMetalChest), 2475, "", new DecorationEntry[]
				{
					new(3019, 3424, 15, ""),
				}),
				new("Goblet", typeof(Goblet), 2483, "", new DecorationEntry[]
				{
					new(3030, 3347, 21, ""),
					new(3030, 3355, 21, ""),
					new(3031, 3355, 21, ""),
				}),
				new("Silverware", typeof(Static), 2493, "", new DecorationEntry[]
				{
					new(2914, 3484, 16, ""),
					new(3016, 3458, 19, ""),
				}),
				new("Goblet", typeof(Goblet), 2495, "", new DecorationEntry[]
				{
					new(2970, 3419, 21, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2500, "", new DecorationEntry[]
				{
					new(2970, 3416, 15, ""),
				}),
				new("Silverware", typeof(Static), 2517, "", new DecorationEntry[]
				{
					new(2915, 3484, 16, ""),
				}),
				new("Pitcher", typeof(Static), 2518, "", new DecorationEntry[]
				{
					new(3053, 3420, 21, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(2914, 3484, 16, ""),
					new(2915, 3484, 16, ""),
					new(3016, 3458, 19, ""),
				}),
				new("Pot", typeof(Static), 2532, "", new DecorationEntry[]
				{
					new(3009, 3455, 15, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(3009, 3456, 15, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2542, "Content=Ale", new DecorationEntry[]
				{
					new(2969, 3419, 21, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2543, "Content=Ale", new DecorationEntry[]
				{
					new(2972, 3419, 21, ""),
				}),
				new("Wall Torch", typeof(WallTorch), 2572, "Light=NorthBig", new DecorationEntry[]
				{
					new(2961, 3440, 30, ""),
					new(3049, 3376, 25, ""),
					new(3054, 3376, 30, ""),
				}),
				new("Lantern", typeof(Lantern), 2583, "", new DecorationEntry[]
				{
					new(3016, 3389, 24, ""),
				}),
				new("Lantern", typeof(Lantern), 2584, "Unlit", new DecorationEntry[]
				{
					new(2976, 3410, 24, ""),
				}),
				new("Stool", typeof(Stool), 2602, "", new DecorationEntry[]
				{
					new(3011, 3351, 35, ""),
					new(3052, 3344, 15, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(3017, 3424, 15, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(2911, 3481, 10, ""),
					new(2936, 3498, 10, ""),
					new(2936, 3503, 10, ""),
					new(3000, 3387, 15, ""),
					new(3048, 3420, 15, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(3008, 3428, 15, ""),
					new(3032, 3427, 15, ""),
					new(3057, 3388, 15, ""),
				}),
				new("Dresser", typeof(Static), 2628, "", new DecorationEntry[]
				{
					new(2872, 3509, 10, ""),
				}),
				new("Dresser", typeof(Static), 2629, "", new DecorationEntry[]
				{
					new(2872, 3508, 10, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(3013, 3424, 15, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(2915, 3480, 10, ""),
					new(2967, 3400, 35, ""),
					new(2967, 3410, 35, ""),
					new(2974, 3400, 35, ""),
					new(3054, 3360, 15, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(3048, 3349, 15, ""),
				}),
				new("Bed", typeof(Static), 2650, "", new DecorationEntry[]
				{
					new(2937, 3500, 10, ""),
					new(2993, 3428, 15, ""),
					new(2998, 3424, 15, ""),
					new(2998, 3428, 15, ""),
					new(3033, 3425, 15, ""),
					new(3033, 3428, 15, ""),
					new(3058, 3384, 15, ""),
					new(3058, 3386, 15, ""),
				}),
				new("Bed", typeof(Static), 2651, "", new DecorationEntry[]
				{
					new(2936, 3500, 10, ""),
					new(2992, 3428, 15, ""),
					new(2997, 3424, 15, ""),
					new(2997, 3428, 15, ""),
					new(3032, 3425, 15, ""),
					new(3032, 3428, 15, ""),
					new(3057, 3384, 15, ""),
					new(3057, 3386, 15, ""),
				}),
				new("Bed", typeof(SmallBedEastAddon), 2653, "", new DecorationEntry[]
				{
					new(2992, 3426, 15, ""),
					new(3000, 3348, 35, ""),
					new(3000, 3351, 35, ""),
					new(3000, 3354, 35, ""),
					new(3024, 3352, 35, ""),
					new(3024, 3354, 35, ""),
					new(3024, 3356, 35, ""),
					new(3028, 3352, 35, ""),
					new(3028, 3354, 35, ""),
					new(3028, 3356, 35, ""),
					new(3032, 3352, 35, ""),
					new(3032, 3354, 35, ""),
					new(3032, 3356, 35, ""),
				}),
				new("Bed", typeof(Static), 2654, "", new DecorationEntry[]
				{
					new(3007, 3344, 35, ""),
					new(3013, 3344, 35, ""),
				}),
				new("Bed", typeof(Static), 2655, "", new DecorationEntry[]
				{
					new(3007, 3345, 35, ""),
					new(3013, 3345, 35, ""),
				}),
				new("Bed", typeof(SmallBedSouthAddon), 2659, "", new DecorationEntry[]
				{
					new(2872, 3505, 10, ""),
					new(2876, 3505, 10, ""),
					new(2917, 3480, 10, ""),
					new(3010, 3344, 35, ""),
				}),
				new("Bed", typeof(Static), 2660, "", new DecorationEntry[]
				{
					new(2937, 3496, 10, ""),
					new(3000, 3384, 15, ""),
					new(3048, 3344, 15, ""),
					new(3048, 3360, 15, ""),
					new(3048, 3416, 15, ""),
					new(3050, 3344, 15, ""),
					new(3050, 3416, 15, ""),
					new(3051, 3360, 15, ""),
					new(3060, 3384, 15, ""),
				}),
				new("Bed", typeof(Static), 2661, "", new DecorationEntry[]
				{
					new(2937, 3497, 10, ""),
					new(3000, 3385, 15, ""),
					new(3048, 3345, 15, ""),
					new(3048, 3361, 15, ""),
					new(3048, 3417, 15, ""),
					new(3050, 3345, 15, ""),
					new(3050, 3417, 15, ""),
					new(3051, 3361, 15, ""),
					new(3060, 3385, 15, ""),
				}),
				new("Bed", typeof(Static), 2666, "", new DecorationEntry[]
				{
					new(2992, 3424, 15, ""),
				}),
				new("Bed", typeof(LargeBedEastAddon), 2685, "", new DecorationEntry[]
				{
					new(2962, 3412, 35, ""),
					new(2969, 3411, 35, ""),
				}),
				new("Bed", typeof(LargeBedSouthAddon), 2691, "", new DecorationEntry[]
				{
					new(2962, 3400, 35, ""),
					new(2969, 3400, 35, ""),
					new(3008, 3424, 15, ""),
				}),
				new("Folded Sheet", typeof(Static), 2707, "Hue=0x546", new DecorationEntry[]
				{
					new(3048, 3416, 17, ""),
					new(3050, 3416, 17, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(2941, 3496, 10, ""),
					new(2967, 3400, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(2940, 3496, 10, ""),
					new(2971, 3400, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(2992, 3430, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(2992, 3431, 15, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(2939, 3496, 10, ""),
					new(2966, 3400, 15, ""),
					new(2968, 3400, 15, ""),
					new(2972, 3400, 15, ""),
				}),
				new("Rug", typeof(Static), 2741, "", new DecorationEntry[]
				{
					new(2966, 3402, 35, ""),
				}),
				new("Rug", typeof(Static), 2743, "", new DecorationEntry[]
				{
					new(2965, 3402, 35, ""),
				}),
				new("Rug", typeof(Static), 2744, "", new DecorationEntry[]
				{
					new(2965, 3401, 35, ""),
				}),
				new("Rug", typeof(Static), 2745, "", new DecorationEntry[]
				{
					new(2966, 3401, 35, ""),
				}),
				new("Rug", typeof(Static), 2746, "", new DecorationEntry[]
				{
					new(2966, 3403, 35, ""),
				}),
				new("Rug", typeof(Static), 2747, "", new DecorationEntry[]
				{
					new(2965, 3403, 35, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(2965, 3404, 23, ""),
					new(2965, 3411, 23, ""),
					new(2969, 3403, 19, ""),
					new(2969, 3409, 19, ""),
					new(3050, 3360, 23, ""),
					new(2962, 3410, 43, ""),
					new(2965, 3400, 43, ""),
					new(2969, 3410, 41, ""),
				}),
				new("Lamp Post", typeof(LampPost1), 2848, "", new DecorationEntry[]
				{
					new(2956, 3458, 24, ""),
					new(2961, 3459, 34, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(2938, 3362, 15, ""),
					new(2939, 3347, 15, ""),
				}),
				new("Counter", typeof(Static), 2879, "", new DecorationEntry[]
				{
					new(3000, 3349, 35, ""),
				}),
				new("Counter", typeof(Static), 2880, "", new DecorationEntry[]
				{
					new(3052, 3420, 15, ""),
					new(3053, 3420, 15, ""),
				}),
				new("Water Trough", typeof(WaterTroughSouthAddon), 2883, "", new DecorationEntry[]
				{
					new(2906, 3520, 10, ""),
					new(2898, 3520, 10, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2894, "", new DecorationEntry[]
				{
					new(2913, 3484, 10, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2895, "Hue=0x21", new DecorationEntry[]
				{
					new(2878, 3505, 10, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2895, "Hue=0x26", new DecorationEntry[]
				{
					new(2874, 3505, 10, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2897, "", new DecorationEntry[]
				{
					new(2916, 3484, 10, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2897, "Hue=0x1E", new DecorationEntry[]
				{
					new(2873, 3509, 10, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(2963, 3407, 15, ""),
					new(3029, 3346, 15, ""),
					new(3029, 3348, 15, ""),
					new(3029, 3350, 15, ""),
					new(3029, 3352, 15, ""),
					new(3029, 3354, 15, ""),
					new(3029, 3356, 15, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(3018, 3427, 15, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(3033, 3346, 15, ""),
					new(3033, 3348, 15, ""),
					new(3033, 3350, 15, ""),
					new(3033, 3352, 15, ""),
					new(3033, 3354, 15, ""),
					new(3033, 3356, 15, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(2881, 3496, 10, ""),
					new(3049, 3366, 15, ""),
					new(3049, 3371, 15, ""),
				}),
				new("Foot Stool", typeof(FootStool), 2910, "", new DecorationEntry[]
				{
					new(2906, 3487, 10, ""),
					new(2909, 3517, 10, ""),
					new(2932, 3504, 10, ""),
					new(2939, 3506, 10, ""),
					new(2940, 3505, 10, ""),
					new(2968, 3420, 15, ""),
					new(2970, 3420, 15, ""),
					new(2972, 3420, 15, ""),
					new(2994, 3433, 15, ""),
					new(3005, 3388, 15, ""),
					new(3009, 3451, 15, ""),
					new(3009, 3460, 15, ""),
					new(3010, 3451, 15, ""),
					new(3010, 3460, 15, ""),
					new(3011, 3451, 15, ""),
					new(3011, 3460, 15, ""),
					new(3013, 3453, 15, ""),
					new(3013, 3454, 15, ""),
					new(3013, 3455, 15, ""),
					new(3013, 3456, 15, ""),
					new(3013, 3457, 15, ""),
					new(3013, 3458, 15, ""),
					new(3035, 3427, 15, ""),
					new(3035, 3428, 15, ""),
					new(3037, 3427, 15, ""),
					new(3037, 3428, 15, ""),
					new(3051, 3403, 15, ""),
					new(3052, 3419, 15, ""),
					new(3052, 3421, 15, ""),
					new(3053, 3419, 15, ""),
					new(3053, 3421, 15, ""),
				}),
				new("Bench", typeof(Static), 2911, "", new DecorationEntry[]
				{
					new(2968, 3403, 15, ""),
					new(2968, 3405, 15, ""),
					new(2969, 3425, 15, ""),
					new(2969, 3427, 15, ""),
					new(2970, 3403, 15, ""),
					new(2970, 3405, 15, ""),
					new(2971, 3425, 15, ""),
					new(2971, 3427, 15, ""),
					new(2992, 3437, 15, ""),
					new(3015, 3453, 15, ""),
					new(3015, 3455, 15, ""),
					new(3015, 3458, 15, ""),
					new(3015, 3460, 15, ""),
					new(3017, 3453, 15, ""),
					new(3017, 3455, 15, ""),
					new(3017, 3458, 15, ""),
					new(3017, 3460, 15, ""),
				}),
				new("Bench", typeof(Static), 2912, "", new DecorationEntry[]
				{
					new(2968, 3402, 15, ""),
					new(2968, 3404, 15, ""),
					new(2969, 3424, 15, ""),
					new(2969, 3426, 15, ""),
					new(2970, 3402, 15, ""),
					new(2970, 3404, 15, ""),
					new(2971, 3424, 15, ""),
					new(2971, 3426, 15, ""),
					new(2992, 3436, 15, ""),
					new(3015, 3452, 15, ""),
					new(3015, 3454, 15, ""),
					new(3015, 3457, 15, ""),
					new(3015, 3459, 15, ""),
					new(3017, 3452, 15, ""),
					new(3017, 3454, 15, ""),
					new(3017, 3457, 15, ""),
					new(3017, 3459, 15, ""),
				}),
				new("Metal Signpost", typeof(Static), 2978, "", new DecorationEntry[]
				{
					new(3027, 3360, 15, ""),
				}),
				new("Cards", typeof(Static), 3605, "", new DecorationEntry[]
				{
					new(3015, 3526, 21, ""),
				}),
				new("Cards", typeof(Static), 3606, "", new DecorationEntry[]
				{
					new(3014, 3527, 21, ""),
					new(3033, 3346, 39, ""),
				}),
				new("Cards", typeof(Static), 3607, "", new DecorationEntry[]
				{
					new(3034, 3346, 37, ""),
				}),
				new("Cards", typeof(Static), 3609, "", new DecorationEntry[]
				{
					new(3015, 3525, 21, ""),
				}),
				new("Backgammon Board", typeof(Backgammon), 3612, "", new DecorationEntry[]
				{
					new(3035, 3346, 37, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(2993, 3432, 21, ""),
				}),
				new("Bottle", typeof(Static), 3622, "", new DecorationEntry[]
				{
					new(3000, 3349, 41, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(2939, 3381, 15, ""),
					new(2941, 3381, 15, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3644, "", new DecorationEntry[]
				{
					new(2943, 3401, 0, ""),
					new(2943, 3402, 0, ""),
					new(2944, 3401, 0, ""),
					new(2944, 3402, 0, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(2885, 3420, 35, ""),
					new(2886, 3420, 35, ""),
					new(2952, 3447, 15, ""),
					new(2952, 3448, 15, ""),
					new(2963, 3492, 15, ""),
					new(2963, 3493, 15, ""),
					new(2964, 3492, 15, ""),
					new(2964, 3493, 15, ""),
					new(2964, 3493, 18, ""),
					new(2965, 3491, 15, ""),
					new(2965, 3492, 15, ""),
					new(2965, 3492, 18, ""),
					new(2965, 3493, 15, ""),
					new(2965, 3493, 18, ""),
					new(3011, 3400, 15, ""),
					new(3011, 3401, 15, ""),
					new(3011, 3401, 18, ""),
					new(3012, 3401, 15, ""),
					new(3012, 3401, 18, ""),
					new(3012, 3402, 15, ""),
					new(3013, 3402, 15, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(2940, 3401, 1, ""),
					new(2940, 3402, 1, ""),
					new(2941, 3401, 1, ""),
					new(2941, 3402, 1, ""),
					new(2942, 3401, 1, ""),
					new(2942, 3402, 1, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(2888, 3420, 35, ""),
					new(2952, 3444, 15, ""),
					new(2952, 3451, 15, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(2887, 3420, 35, ""),
					new(2943, 3401, 3, ""),
					new(2943, 3402, 3, ""),
					new(2943, 3403, 0, ""),
					new(2944, 3401, 3, ""),
					new(2944, 3402, 3, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(2872, 3466, 15, ""),
					new(2872, 3476, 15, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(3011, 3424, 15, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(2872, 3473, 15, ""),
					new(2872, 3474, 15, ""),
					new(2873, 3466, 15, ""),
					new(2880, 3415, 35, ""),
					new(2936, 3374, 15, ""),
					new(2936, 3381, 15, ""),
					new(2952, 3446, 15, ""),
					new(2952, 3450, 15, ""),
					new(2952, 3493, 15, ""),
					new(3056, 3348, 15, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3650, "", new DecorationEntry[]
				{
					new(3026, 3352, 35, ""),
					new(3030, 3354, 35, ""),
					new(3034, 3352, 35, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(2963, 3480, 15, ""),
					new(2965, 3480, 15, ""),
					new(3064, 3336, 15, ""),
				}),
				new("Bag", typeof(Bag), 3702, "", new DecorationEntry[]
				{
					new(3009, 3384, 16, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(2906, 3480, 10, ""),
					new(2906, 3480, 15, ""),
					new(2906, 3480, 20, ""),
					new(2907, 3480, 10, ""),
					new(2907, 3480, 15, ""),
					new(2907, 3481, 10, ""),
					new(2932, 3401, 0, ""),
					new(2932, 3401, 5, ""),
					new(2932, 3402, 0, ""),
					new(2932, 3402, 5, ""),
					new(2932, 3403, 0, ""),
					new(2933, 3401, 0, ""),
					new(2933, 3401, 5, ""),
					new(2933, 3401, 10, ""),
					new(2933, 3402, 0, ""),
					new(2933, 3402, 5, ""),
					new(2934, 3401, 0, ""),
					new(2934, 3401, 5, ""),
					new(2934, 3402, 0, ""),
					new(2934, 3402, 5, ""),
					new(2934, 3403, 0, ""),
					new(2935, 3401, 0, ""),
					new(3008, 3457, 15, ""),
					new(3008, 3457, 20, ""),
					new(3012, 3406, 15, ""),
					new(3048, 3368, 15, ""),
					new(3049, 3365, 15, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(2872, 3468, 15, ""),
					new(2873, 3468, 15, ""),
					new(2873, 3474, 15, ""),
					new(2873, 3476, 15, ""),
					new(3008, 3530, 15, ""),
				}),
				new("Metal Chest", typeof(FillableMetalChest), 3708, "", new DecorationEntry[]
				{
					new(2904, 3481, 10, ""),
					new(2936, 3502, 10, ""),
					new(2962, 3408, 15, ""),
					new(3004, 3389, 15, ""),
					new(3048, 3402, 15, ""),
				}),
				new("Wooden Box", typeof(FillableWoodenBox), 3709, "", new DecorationEntry[]
				{
					new(2938, 3500, 10, ""),
					new(3026, 3354, 35, ""),
				}),
				new("Crate", typeof(FillableSmallCrate), 3710, "", new DecorationEntry[]
				{
					new(2904, 3483, 10, ""),
					new(2904, 3483, 13, ""),
					new(2904, 3483, 16, ""),
					new(2904, 3484, 10, ""),
					new(2904, 3484, 13, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(3026, 3356, 35, ""),
					new(3030, 3356, 35, ""),
					new(3034, 3354, 35, ""),
				}),
				new("Mortar And Pestle", typeof(Static), 3739, "", new DecorationEntry[]
				{
					new(2992, 3432, 21, ""),
				}),
				new("Dress Form", typeof(Static), 3782, "", new DecorationEntry[]
				{
					new(2880, 3502, 10, ""),
				}),
				new("Clean Bandage", typeof(Static), 3817, "", new DecorationEntry[]
				{
					new(3012, 3353, 41, ""),
				}),
				new("Scroll", typeof(Static), 3830, "", new DecorationEntry[]
				{
					new(2992, 3434, 21, ""),
				}),
				new("Bottle", typeof(Static), 3843, "", new DecorationEntry[]
				{
					new(3011, 3349, 41, ""),
					new(3011, 3353, 41, ""),
				}),
				new("Arrows", typeof(Static), 3904, "", new DecorationEntry[]
				{
					new(3010, 3348, 21, ""),
					new(3054, 3389, 43, ""),
				}),
				new("Arrows", typeof(Static), 3905, "", new DecorationEntry[]
				{
					new(3009, 3348, 21, ""),
					new(3054, 3388, 43, ""),
				}),
				new("Arrow", typeof(Static), 3906, "", new DecorationEntry[]
				{
					new(3054, 3389, 43, ""),
				}),
				new("Hatchet", typeof(Static), 3907, "", new DecorationEntry[]
				{
					new(2956, 3481, 19, ""),
					new(3017, 3434, 19, ""),
				}),
				new("Crossbow", typeof(Static), 3919, "", new DecorationEntry[]
				{
					new(2880, 3418, 39, ""),
					new(3048, 3372, 21, ""),
				}),
				new("Crossbow", typeof(Static), 3920, "", new DecorationEntry[]
				{
					new(3048, 3370, 21, ""),
					new(3054, 3390, 43, ""),
					new(3054, 3391, 43, ""),
				}),
				new("Dagger", typeof(Static), 3922, "", new DecorationEntry[]
				{
					new(3052, 3401, 19, ""),
				}),
				new("Mace", typeof(Static), 3933, "", new DecorationEntry[]
				{
					new(3051, 3397, 15, ""),
				}),
				new("Broadsword", typeof(Static), 3934, "", new DecorationEntry[]
				{
					new(2880, 3417, 39, ""),
				}),
				new("Longsword", typeof(Static), 3936, "", new DecorationEntry[]
				{
					new(2936, 3377, 19, ""),
					new(3015, 3434, 19, ""),
					new(3052, 3396, 15, ""),
					new(3060, 3398, 19, ""),
					new(3060, 3403, 19, ""),
				}),
				new("Spear", typeof(Static), 3938, "", new DecorationEntry[]
				{
					new(3053, 3392, 15, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3992, "Hue=0x26", new DecorationEntry[]
				{
					new(2880, 3509, 10, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3993, "Hue=0x21", new DecorationEntry[]
				{
					new(2880, 3498, 10, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3994, "Hue=0x1E", new DecorationEntry[]
				{
					new(2880, 3507, 10, ""),
				}),
				new("Sewing Kit", typeof(Static), 3997, "", new DecorationEntry[]
				{
					new(2881, 3504, 16, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(2881, 3505, 13, ""),
				}),
				new("Spool Of Thread", typeof(Static), 4000, "Hue=0x21", new DecorationEntry[]
				{
					new(2880, 3503, 16, ""),
				}),
				new("Spool Of Thread", typeof(Static), 4001, "Hue=0x1E", new DecorationEntry[]
				{
					new(2880, 3503, 16, ""),
				}),
				new("Playing Cards", typeof(Static), 4002, "", new DecorationEntry[]
				{
					new(3014, 3525, 21, ""),
				}),
				new("Playing Cards", typeof(Static), 4003, "", new DecorationEntry[]
				{
					new(2970, 3425, 17, ""),
					new(3016, 3454, 18, ""),
					new(3058, 3341, 21, ""),
				}),
				new("Chess Board", typeof(Chessboard), 4006, "", new DecorationEntry[]
				{
					new(3058, 3343, 20, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(3016, 3455, 19, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(2904, 3482, 10, ""),
					new(3008, 3531, 15, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(3001, 3410, 15, ""),
					new(3003, 3401, 15, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(3007, 3404, 15, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4021, "", new DecorationEntry[]
				{
					new(3002, 3410, 15, ""),
					new(3004, 3401, 15, ""),
				}),
				new("Horse Shoes", typeof(Static), 4022, "", new DecorationEntry[]
				{
					new(3010, 3410, 15, ""),
				}),
				new("Forged Metal", typeof(Static), 4023, "", new DecorationEntry[]
				{
					new(3002, 3401, 15, ""),
				}),
				new("Forged Metal", typeof(Static), 4024, "", new DecorationEntry[]
				{
					new(3003, 3412, 15, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(2905, 3487, 15, ""),
					new(2930, 3505, 15, ""),
					new(3012, 3351, 41, ""),
					new(3030, 3347, 21, ""),
					new(3032, 3350, 21, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(2885, 3497, 14, ""),
					new(2963, 3404, 23, ""),
					new(3018, 3429, 23, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(2905, 3487, 15, ""),
					new(2930, 3505, 15, ""),
					new(3031, 3347, 21, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(2884, 3497, 14, ""),
					new(2963, 3404, 21, ""),
					new(3007, 3387, 25, ""),
					new(3012, 3352, 41, ""),
					new(3018, 3429, 23, ""),
					new(3030, 3346, 21, ""),
					new(3030, 3351, 21, ""),
					new(3031, 3355, 21, ""),
					new(3052, 3402, 19, ""),
				}),
				new("Book", typeof(SongOfSamlethe), 4084, "", new DecorationEntry[]
				{
					new(3007, 3388, 27, ""),
				}),
				new("Glass Pitcher", typeof(Pitcher), 4086, "", new DecorationEntry[]
				{
					new(3012, 3453, 24, ""),
				}),
				new("Skull Mug", typeof(Static), 4093, "", new DecorationEntry[]
				{
					new(2970, 3424, 19, ""),
					new(3010, 3452, 24, ""),
					new(3010, 3459, 23, ""),
					new(3012, 3458, 23, ""),
					new(3016, 3453, 19, ""),
					new(3016, 3459, 19, ""),
					new(3032, 3353, 21, ""),
				}),
				new("Skull Mug", typeof(Static), 4094, "", new DecorationEntry[]
				{
					new(3016, 3458, 19, ""),
					new(3030, 3350, 21, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4095, "", new DecorationEntry[]
				{
					new(3012, 3455, 24, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4097, "", new DecorationEntry[]
				{
					new(2970, 3425, 24, ""),
					new(3012, 3456, 24, ""),
					new(3016, 3452, 19, ""),
					new(3016, 3457, 19, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4098, "", new DecorationEntry[]
				{
					new(2970, 3426, 19, ""),
				}),
				new("Spittoon", typeof(Static), 4099, "", new DecorationEntry[]
				{
					new(2968, 3429, 15, ""),
					new(2973, 3423, 15, ""),
					new(3008, 3461, 15, ""),
					new(3018, 3450, 15, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4106, "", new DecorationEntry[]
				{
					new(3027, 3381, 15, ""),
					new(3048, 3394, 39, ""),
					new(3048, 3396, 39, ""),
					new(3048, 3398, 39, ""),
					new(3048, 3400, 39, ""),
					new(3048, 3402, 39, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4107, "", new DecorationEntry[]
				{
					new(3036, 3379, 15, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(2880, 3496, 10, ""),
				}),
				new("Pile Of Wool", typeof(Static), 4127, "", new DecorationEntry[]
				{
					new(2881, 3497, 10, ""),
				}),
				new("Hammer", typeof(Static), 4139, "", new DecorationEntry[]
				{
					new(2938, 3507, 14, ""),
					new(2941, 3505, 14, ""),
					new(2941, 3508, 14, ""),
				}),
				new("Dough", typeof(Static), 4157, "", new DecorationEntry[]
				{
					new(2972, 3353, 21, ""),
				}),
				new("Globe", typeof(Static), 4167, "", new DecorationEntry[]
				{
					new(3029, 3344, 15, ""),
				}),
				new("Globe", typeof(Static), 4168, "", new DecorationEntry[]
				{
					new(3033, 3344, 15, ""),
				}),
				new("Clock", typeof(Clock), 4171, "", new DecorationEntry[]
				{
					new(2936, 3504, 10, ""),
					new(2936, 3506, 10, ""),
				}),
				new("Clock Frame", typeof(ClockFrame), 4174, "", new DecorationEntry[]
				{
					new(2938, 3505, 14, ""),
					new(2941, 3507, 14, ""),
				}),
				new("Clock Parts", typeof(ClockParts), 4175, "", new DecorationEntry[]
				{
					new(2938, 3507, 14, ""),
					new(2941, 3505, 14, ""),
				}),
				new("Axle With Gears", typeof(AxleGears), 4177, "", new DecorationEntry[]
				{
					new(2938, 3506, 14, ""),
					new(2941, 3508, 14, ""),
				}),
				new("Gears", typeof(Gears), 4180, "", new DecorationEntry[]
				{
					new(2938, 3508, 14, ""),
					new(2941, 3505, 14, ""),
				}),
				new("Sextant", typeof(Static), 4183, "", new DecorationEntry[]
				{
					new(2938, 3506, 14, ""),
					new(2941, 3507, 14, ""),
				}),
				new("Sextant Parts", typeof(SextantParts), 4185, "", new DecorationEntry[]
				{
					new(2938, 3505, 14, ""),
					new(2941, 3506, 14, ""),
				}),
				new("Springs", typeof(Springs), 4189, "", new DecorationEntry[]
				{
					new(2938, 3507, 14, ""),
					new(2941, 3504, 14, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "Hue=0x1E", new DecorationEntry[]
				{
					new(2873, 3499, 10, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4193, "Hue=0x21", new DecorationEntry[]
				{
					new(2875, 3497, 10, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4193, "Hue=0x26", new DecorationEntry[]
				{
					new(2875, 3502, 10, ""),
				}),
				new("Training Dummy", typeof(TrainingDummySouthAddon), 4208, "", new DecorationEntry[]
				{
					new(3029, 3389, 15, ""),
				}),
				new("Training Dummy", typeof(TrainingDummyEastAddon), 4212, "", new DecorationEntry[]
				{
					new(3037, 3389, 15, ""),
				}),
				new("Lever", typeof(Static), 4237, "", new DecorationEntry[]
				{
					new(2956, 3454, 15, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(2912, 3480, 10, ""),
					new(3048, 3347, 15, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(2992, 3435, 21, ""),
				}),
				new("War Axe", typeof(Static), 5039, "", new DecorationEntry[]
				{
					new(3006, 3348, 21, ""),
				}),
				new("Bow", typeof(Static), 5042, "", new DecorationEntry[]
				{
					new(3011, 3348, 21, ""),
				}),
				new("Large Battle Axe", typeof(Static), 5115, "", new DecorationEntry[]
				{
					new(3004, 3348, 21, ""),
				}),
				new("Katana", typeof(Static), 5119, "", new DecorationEntry[]
				{
					new(3016, 3434, 19, ""),
				}),
				new("Map", typeof(Static), 5356, "", new DecorationEntry[]
				{
					new(3030, 3353, 21, ""),
					new(3031, 3350, 21, ""),
					new(3032, 3346, 21, ""),
				}),
				new("Rolled Map", typeof(Static), 5357, "", new DecorationEntry[]
				{
					new(3031, 3348, 21, ""),
					new(3031, 3354, 21, ""),
				}),
				new("Rolled Map", typeof(Static), 5358, "", new DecorationEntry[]
				{
					new(3031, 3356, 21, ""),
					new(3032, 3352, 21, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(3003, 3413, 15, ""),
					new(3004, 3400, 15, ""),
				}),
				new("Flask", typeof(Static), 6187, "", new DecorationEntry[]
				{
					new(3000, 3355, 41, ""),
				}),
				new("Flask", typeof(Static), 6191, "", new DecorationEntry[]
				{
					new(3011, 3354, 41, ""),
				}),
				new("Flask", typeof(Static), 6193, "", new DecorationEntry[]
				{
					new(3013, 3350, 41, ""),
				}),
				new("Flask", typeof(Static), 6212, "", new DecorationEntry[]
				{
					new(3011, 3350, 41, ""),
				}),
				new("Flask", typeof(Static), 6215, "", new DecorationEntry[]
				{
					new(3011, 3344, 41, ""),
				}),
				new("Heating Stand", typeof(HeatingStand), 6218, "", new DecorationEntry[]
				{
					new(3011, 3350, 41, ""),
				}),
				new("Scales", typeof(Scales), 6226, "", new DecorationEntry[]
				{
					new(3012, 3354, 41, ""),
				}),
				new("Empty Vials", typeof(Static), 6236, "", new DecorationEntry[]
				{
					new(3007, 3389, 21, ""),
					new(3012, 3350, 41, ""),
				}),
				new("Full Vials", typeof(Static), 6237, "", new DecorationEntry[]
				{
					new(3010, 3353, 41, ""),
				}),
				new("Full Vials", typeof(Static), 6238, "", new DecorationEntry[]
				{
					new(3007, 3390, 21, ""),
				}),
				new("Iron Wire", typeof(Static), 6262, "", new DecorationEntry[]
				{
					new(3002, 3409, 15, ""),
					new(3003, 3403, 15, ""),
					new(3005, 3409, 15, ""),
					new(3012, 3412, 15, ""),
				}),
				new("Silver Wire", typeof(Static), 6263, "", new DecorationEntry[]
				{
					new(3005, 3402, 15, ""),
					new(3005, 3404, 15, ""),
					new(3008, 3412, 15, ""),
				}),
				new("Bellows", typeof(Static), 6523, "", new DecorationEntry[]
				{
					new(3000, 3403, 15, ""),
					new(3000, 3412, 15, ""),
				}),
				new("Forge", typeof(Static), 6526, "Light=Circle300", new DecorationEntry[]
				{
					new(3001, 3403, 15, ""),
					new(3001, 3412, 15, ""),
				}),
				new("Forge", typeof(Static), 6530, "", new DecorationEntry[]
				{
					new(3002, 3403, 15, ""),
					new(3002, 3412, 15, ""),
				}),
				new("Ore", typeof(Static), 6583, "", new DecorationEntry[]
				{
					new(3011, 3402, 15, ""),
					new(3012, 3403, 15, ""),
					new(3013, 3400, 15, ""),
				}),
				new("Ore", typeof(Static), 6583, "Amount=2", new DecorationEntry[]
				{
					new(3000, 3404, 15, ""),
					new(3001, 3404, 15, ""),
					new(3010, 3407, 15, ""),
					new(3011, 3407, 15, ""),
				}),
				new("Ore", typeof(Static), 6584, "Amount=2", new DecorationEntry[]
				{
					new(3010, 3407, 15, ""),
					new(3011, 3407, 15, ""),
					new(3011, 3408, 15, ""),
				}),
				new("Ore", typeof(Static), 6585, "Amount=2", new DecorationEntry[]
				{
					new(3000, 3405, 15, ""),
					new(3001, 3405, 15, ""),
					new(3010, 3408, 15, ""),
					new(3011, 3408, 15, ""),
				}),
				new("Ore", typeof(Static), 6586, "Amount=2", new DecorationEntry[]
				{
					new(3001, 3406, 15, ""),
					new(3010, 3408, 15, ""),
					new(3011, 3407, 15, ""),
					new(3011, 3408, 15, ""),
					new(3011, 3409, 15, ""),
					new(3012, 3408, 15, ""),
				}),
				new("Ore Cart", typeof(Static), 6787, "", new DecorationEntry[]
				{
					new(3002, 3407, 15, ""),
					new(3012, 3410, 15, ""),
				}),
				new("Keg", typeof(Static), 6870, "", new DecorationEntry[]
				{
					new(3010, 3400, 15, ""),
				}),
				new("Shaft", typeof(Static), 7124, "", new DecorationEntry[]
				{
					new(3048, 3365, 21, ""),
					new(3048, 3366, 21, ""),
					new(3048, 3367, 21, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(2963, 3400, 15, ""),
					new(3017, 3450, 15, ""),
				}),
				
				#endregion
			});
		}
	}
}
