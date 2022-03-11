using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Bucs { get; } = Register(DecorationTarget.Britannia, "Bucs", new DecorationList[]
			{
				#region Entries
				
				new("Stone Pavers", typeof(Static), 1310, "", new DecorationEntry[]
				{
					new(2669, 2071, -20, ""),
				}),
				new("Stone Pavers", typeof(Static), 1311, "", new DecorationEntry[]
				{
					new(2669, 2072, -20, ""),
				}),
				new("Stone Pavers", typeof(Static), 1312, "", new DecorationEntry[]
				{
					new(2669, 2073, -20, ""),
				}),
				new("Stone", typeof(Static), 1822, "", new DecorationEntry[]
				{
					new(2726, 2133, 0, ""),
					new(2727, 2131, 0, ""),
					new(2727, 2131, 5, ""),
					new(2727, 2131, 10, ""),
					new(2727, 2131, 15, ""),
					new(2727, 2131, 20, ""),
					new(2727, 2131, 25, ""),
					new(2727, 2132, 0, ""),
					new(2727, 2132, 30, ""),
					new(2727, 2133, 0, ""),
					new(2727, 2133, 30, ""),
					new(2727, 2133, 35, ""),
					new(2727, 2134, 0, ""),
					new(2727, 2134, 30, ""),
					new(2727, 2135, 0, ""),
					new(2727, 2135, 5, ""),
					new(2727, 2135, 10, ""),
					new(2727, 2135, 15, ""),
					new(2727, 2135, 20, ""),
					new(2727, 2135, 25, ""),
					new(2728, 2133, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1823, "", new DecorationEntry[]
				{
					new(2727, 2134, 35, ""),
					new(2727, 2135, 30, ""),
				}),
				new("Stone Stairs", typeof(Static), 1847, "", new DecorationEntry[]
				{
					new(2727, 2131, 30, ""),
					new(2727, 2132, 35, ""),
				}),
				new("Stone Stairs", typeof(Static), 1952, "", new DecorationEntry[]
				{
					new(2726, 2132, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1953, "", new DecorationEntry[]
				{
					new(2728, 2134, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1954, "", new DecorationEntry[]
				{
					new(2728, 2132, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 2010, "", new DecorationEntry[]
				{
					new(2726, 2134, 0, ""),
				}),
				new("Bottle Of Ale", typeof(BeverageBottle), 2463, "Content=Ale", new DecorationEntry[]
				{
					new(2659, 2187, 8, ""),
					new(2660, 2203, 8, ""),
					new(2666, 2234, 8, ""),
					new(2668, 2235, 8, ""),
					new(2668, 2236, 8, ""),
					new(2673, 2233, 4, ""),
					new(2675, 2238, 4, ""),
					new(2684, 2233, 4, ""),
				}),
				new("Bottles Of Ale", typeof(Static), 2464, "", new DecorationEntry[]
				{
					new(2666, 2236, 8, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(2730, 2185, 6, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(2662, 2250, -20, ""),
				}),
				new("Metal Chest", typeof(FillableMetalChest), 2475, "", new DecorationEntry[]
				{
					new(2648, 2192, 4, ""),
					new(2649, 2192, 4, ""),
					new(2650, 2192, 4, ""),
					new(2718, 2080, 0, ""),
					new(2719, 2080, 20, ""),
				}),
				new("Silverware", typeof(Static), 2493, "", new DecorationEntry[]
				{
					new(2757, 2219, 6, ""),
				}),
				new("Bottle Of Wine", typeof(BeverageBottle), 2503, "Content=Wine", new DecorationEntry[]
				{
					new(2659, 2201, 8, ""),
					new(2660, 2186, 8, ""),
				}),
				new("Silverware", typeof(Static), 2516, "", new DecorationEntry[]
				{
					new(2748, 2113, 4, ""),
				}),
				new("Pitcher", typeof(Static), 2518, "", new DecorationEntry[]
				{
					new(2668, 2129, 4, ""),
					new(2692, 2200, 4, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(2757, 2219, 6, ""),
				}),
				new("Plate Of Food", typeof(Static), 2523, "", new DecorationEntry[]
				{
					new(2748, 2113, 4, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2542, "Content=Ale", new DecorationEntry[]
				{
					new(2679, 2233, 4, ""),
				}),
				new("Wall Sconce", typeof(WallSconce), 2557, "Light=WestBig", new DecorationEntry[]
				{
					new(2681, 2245, 16, ""),
				}),
				new("Wall Sconce", typeof(WallSconce), 2562, "Light=NorthBig", new DecorationEntry[]
				{
					new(2683, 2241, 16, ""),
					new(2678, 2241, 16, ""),
				}),
				new("Wall Torch", typeof(WallTorch), 2567, "Light=WestBig", new DecorationEntry[]
				{
					new(2728, 2187, 16, ""),
				}),
				new("Wall Torch", typeof(Static), 2572, "Light=NorthBig", new DecorationEntry[]
				{
					new(2729, 2184, 16, ""),
				}),
				new("Candle", typeof(Candle), 2575, "", new DecorationEntry[]
				{
					new(2691, 2200, 4, ""),
				}),
				new("Lantern", typeof(Lantern), 2584, "Unlit", new DecorationEntry[]
				{
					new(2744, 2253, 10, ""),
				}),
				new("Hanging Lantern", typeof(HangingLantern), 2586, "", new DecorationEntry[]
				{
					new(2717, 2104, 9, ""),
					new(2721, 2085, 0, ""),
					new(2721, 2086, 0, ""),
					new(2722, 2086, 0, ""),
					new(2736, 2158, 18, ""),
				}),
				new("Hanging Lantern", typeof(Static), 2589, "", new DecorationEntry[]
				{
					new(2736, 2174, 20, ""),
				}),
				new("Lantern Post", typeof(Static), 2592, "", new DecorationEntry[]
				{
					new(2735, 2157, -1, ""),
					new(2735, 2173, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2598, "Unlit", new DecorationEntry[]
				{
					new(2632, 2086, 14, ""),
				}),
				new("Stool", typeof(Stool), 2602, "", new DecorationEntry[]
				{
					new(2669, 2076, 5, ""),
					new(2709, 2178, 0, ""),
					new(2713, 2086, 0, ""),
					new(2723, 2085, 0, ""),
					new(2726, 2086, 0, ""),
					new(2730, 2260, 0, ""),
					new(2730, 2261, 0, ""),
					new(2731, 2259, 0, ""),
					new(2731, 2262, 0, ""),
					new(2732, 2259, 0, ""),
					new(2732, 2262, 0, ""),
					new(2733, 2260, 0, ""),
					new(2733, 2261, 0, ""),
				}),
				new("Stool", typeof(Static), 2603, "", new DecorationEntry[]
				{
					new(2637, 2080, 10, ""),
					new(2638, 2081, 10, ""),
					new(2638, 2082, 10, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(2676, 2152, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(2664, 2131, 0, ""),
					new(2744, 2115, 0, ""),
					new(2776, 2132, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(2624, 2099, 10, ""),
					new(2712, 2084, 0, ""),
					new(2720, 2084, 0, ""),
				}),
				new("Bedroll", typeof(Static), 2645, "", new DecorationEntry[]
				{
					new(2689, 2201, 0, ""),
					new(2715, 2209, 0, ""),
				}),
				new("Bedroll", typeof(Static), 2646, "", new DecorationEntry[]
				{
					new(2694, 2201, 0, ""),
					new(2718, 2209, 0, ""),
				}),
				new("Bedroll", typeof(Static), 2647, "", new DecorationEntry[]
				{
					new(2718, 2209, 0, ""),
				}),
				new("Bedroll", typeof(Static), 2648, "", new DecorationEntry[]
				{
					new(2689, 2201, 0, ""),
					new(2715, 2209, 0, ""),
				}),
				new("Bed", typeof(Static), 2652, "", new DecorationEntry[]
				{
					new(2752, 2217, 0, ""),
				}),
				new("Bed", typeof(Static), 2659, "", new DecorationEntry[]
				{
					new(2752, 2216, 0, ""),
				}),
				new("Folded Sheet", typeof(Static), 2706, "", new DecorationEntry[]
				{
					new(2632, 2080, 12, ""),
					new(2704, 2146, 2, ""),
					new(2704, 2149, 2, ""),
					new(2709, 2132, 2, ""),
					new(2726, 2089, 2, ""),
					new(2729, 2260, -3, ""),
					new(2744, 2112, 2, ""),
				}),
				new("Display Case", typeof(Static), 2720, "", new DecorationEntry[]
				{
					new(2733, 2249, 4, ""),
					new(2734, 2249, 4, ""),
					new(2739, 2249, 4, ""),
				}),
				new("Display Case", typeof(Static), 2722, "", new DecorationEntry[]
				{
					new(2733, 2248, 4, ""),
					new(2734, 2248, 4, ""),
					new(2739, 2248, 4, ""),
				}),
				new("Display Case", typeof(Static), 2723, "", new DecorationEntry[]
				{
					new(2732, 2248, 4, ""),
					new(2738, 2248, 4, ""),
				}),
				new("Display Case", typeof(Static), 2724, "", new DecorationEntry[]
				{
					new(2735, 2248, 4, ""),
					new(2740, 2248, 4, ""),
				}),
				new("Display Case", typeof(Static), 2725, "", new DecorationEntry[]
				{
					new(2732, 2249, 4, ""),
					new(2738, 2249, 4, ""),
				}),
				new("Display Case", typeof(Static), 2832, "", new DecorationEntry[]
				{
					new(2732, 2248, 0, ""),
					new(2738, 2248, 0, ""),
				}),
				new("Display Case", typeof(Static), 2833, "", new DecorationEntry[]
				{
					new(2735, 2249, 0, ""),
					new(2740, 2249, 0, ""),
				}),
				new("Display Case", typeof(Static), 2834, "", new DecorationEntry[]
				{
					new(2732, 2249, 0, ""),
					new(2738, 2249, 0, ""),
				}),
				new("Display Case", typeof(Static), 2835, "", new DecorationEntry[]
				{
					new(2735, 2248, 0, ""),
					new(2740, 2248, 0, ""),
				}),
				new("Display Case", typeof(Static), 2837, "", new DecorationEntry[]
				{
					new(2733, 2249, 0, ""),
					new(2734, 2249, 0, ""),
					new(2739, 2249, 0, ""),
				}),
				new("Display Case", typeof(Static), 2839, "", new DecorationEntry[]
				{
					new(2733, 2248, 0, ""),
					new(2734, 2248, 0, ""),
					new(2739, 2248, 0, ""),
				}),
				new("Display Case", typeof(Static), 2840, "", new DecorationEntry[]
				{
					new(2735, 2249, 4, ""),
					new(2740, 2249, 4, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(2672, 2153, 8, ""),
					new(2672, 2156, 6, ""),
					new(2728, 2259, 8, ""),
				}),
				new("Candle", typeof(CandleLarge), 2843, "", new DecorationEntry[]
				{
					new(2634, 2080, 18, ""),
					new(2712, 2212, 7, ""),
					new(2732, 2185, 6, ""),
				}),
				new("Counter", typeof(Static), 2878, "", new DecorationEntry[]
				{
					new(2731, 2185, 0, ""),
				}),
				new("Counter", typeof(Static), 2879, "", new DecorationEntry[]
				{
					new(2728, 2258, 0, ""),
					new(2728, 2259, 0, ""),
					new(2730, 2184, 0, ""),
					new(2731, 2260, 0, ""),
					new(2731, 2261, 0, ""),
					new(2732, 2260, 0, ""),
					new(2732, 2261, 0, ""),
				}),
				new("Counter", typeof(Static), 2880, "", new DecorationEntry[]
				{
					new(2730, 2185, 0, ""),
					new(2732, 2185, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2894, "", new DecorationEntry[]
				{
					new(2658, 2187, 4, ""),
					new(2658, 2201, 4, ""),
					new(2658, 2203, 4, ""),
					new(2712, 2097, 0, ""),
					new(2712, 2101, 0, ""),
					new(2720, 2092, 0, ""),
					new(2720, 2093, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2895, "", new DecorationEntry[]
				{
					new(2660, 2185, 4, ""),
					new(2713, 2096, 0, ""),
					new(2715, 2080, 0, ""),
					new(2715, 2089, 0, ""),
					new(2715, 2096, 0, ""),
					new(2724, 2080, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(2660, 2189, 4, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2897, "", new DecorationEntry[]
				{
					new(2661, 2187, 4, ""),
					new(2661, 2201, 4, ""),
					new(2661, 2203, 4, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(2624, 2097, 10, ""),
					new(2728, 2251, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(2629, 2096, 10, ""),
					new(2730, 2248, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(2748, 2114, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(2665, 2235, 2, ""),
					new(2672, 2238, 4, ""),
					new(2756, 2219, 0, ""),
					new(2779, 2132, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2907, "", new DecorationEntry[]
				{
					new(2667, 2128, 0, ""),
					new(2667, 2233, 2, ""),
					new(2669, 2128, 0, ""),
					new(2674, 2232, 4, ""),
					new(2674, 2237, 2, ""),
					new(2679, 2232, 4, ""),
					new(2684, 2232, 4, ""),
					new(2712, 2210, 0, ""),
					new(2757, 2218, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(2667, 2237, 2, ""),
					new(2674, 2239, 4, ""),
					new(2712, 2213, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(2669, 2235, 2, ""),
					new(2781, 2131, 0, ""),
					new(2781, 2133, 0, ""),
				}),
				new("Foot Stool", typeof(FootStool), 2910, "", new DecorationEntry[]
				{
					new(2691, 2201, 0, ""),
					new(2692, 2201, 0, ""),
				}),
				new("Bench", typeof(Static), 2912, "", new DecorationEntry[]
				{
					new(2728, 2188, 0, ""),
				}),
				new("Bench", typeof(Static), 2917, "", new DecorationEntry[]
				{
					new(2755, 2216, 0, ""),
				}),
				new("Table", typeof(Static), 2928, "", new DecorationEntry[]
				{
					new(2659, 2188, 4, ""),
					new(2659, 2204, 4, ""),
				}),
				new("Table", typeof(Static), 2929, "", new DecorationEntry[]
				{
					new(2660, 2188, 4, ""),
					new(2660, 2204, 4, ""),
				}),
				new("Table", typeof(Static), 2930, "", new DecorationEntry[]
				{
					new(2660, 2186, 4, ""),
					new(2660, 2200, 4, ""),
				}),
				new("Table", typeof(Static), 2931, "", new DecorationEntry[]
				{
					new(2659, 2186, 4, ""),
					new(2659, 2187, 4, ""),
					new(2659, 2200, 4, ""),
					new(2659, 2201, 4, ""),
					new(2659, 2202, 4, ""),
					new(2659, 2203, 4, ""),
					new(2660, 2187, 4, ""),
					new(2660, 2201, 4, ""),
					new(2660, 2202, 4, ""),
					new(2660, 2203, 4, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2967, "", new DecorationEntry[]
				{
					new(2632, 2099, 10, ""),
					new(2632, 2102, 10, ""),
					new(2664, 2192, 4, ""),
					new(2688, 2234, 4, ""),
					new(2688, 2237, 4, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2968, "", new DecorationEntry[]
				{
					new(2732, 2192, 0, ""),
					new(2666, 2096, 5, ""),
				}),
				new("Broken Chair", typeof(Static), 3089, "", new DecorationEntry[]
				{
					new(2627, 2097, 16, ""),
				}),
				new("Bloody Bandage", typeof(Static), 3616, "", new DecorationEntry[]
				{
					new(2704, 2136, 6, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(2675, 2241, 2, ""),
					new(2676, 2241, 2, ""),
					new(2676, 2245, 2, ""),
					new(2677, 2241, 2, ""),
					new(2677, 2245, 2, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(2672, 2243, 2, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(2712, 2209, 0, ""),
					new(2752, 2221, 0, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3650, "", new DecorationEntry[]
				{
					new(2728, 2187, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(2677, 2158, 0, ""),
					new(2678, 2157, 0, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3651, "", new DecorationEntry[]
				{
					new(2733, 2184, 0, ""),
					new(2734, 2184, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(2675, 2245, -20, ""),
					new(2676, 2244, -20, ""),
					new(2676, 2245, -20, ""),
					new(2692, 2205, 0, ""),
					new(2693, 2204, 0, ""),
					new(2693, 2205, 0, ""),
					new(2746, 2112, 0, ""),
					new(2664, 2133, 0, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(2637, 2084, 10, ""),
					new(2637, 2085, 10, ""),
					new(2672, 2245, 2, ""),
					new(2673, 2245, 2, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(2664, 2134, 0, ""),
					new(2744, 2117, 0, ""),
				}),
				new("Clean Bandage", typeof(Static), 3817, "", new DecorationEntry[]
				{
					new(2704, 2145, 8, ""),
					new(2709, 2136, 6, ""),
					new(2710, 2145, 8, ""),
				}),
				new("Playing Cards", typeof(Static), 4002, "", new DecorationEntry[]
				{
					new(2660, 2202, 8, ""),
					new(2667, 2236, 8, ""),
				}),
				new("Playing Cards", typeof(Static), 4003, "", new DecorationEntry[]
				{
					new(2660, 2187, 8, ""),
					new(2668, 2235, 8, ""),
				}),
				new("Checkers", typeof(Static), 4004, "", new DecorationEntry[]
				{
					new(2674, 2233, 7, ""),
				}),
				new("Checkers", typeof(Static), 4005, "", new DecorationEntry[]
				{
					new(2674, 2233, 7, ""),
				}),
				new("Checker Board", typeof(CheckerBoard), 4006, "", new DecorationEntry[]
				{
					new(2674, 2233, 6, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(2678, 2233, 2, ""),
					new(2680, 2233, 4, ""),
				}),
				new("Backgammon Game", typeof(Backgammon), 4013, "", new DecorationEntry[]
				{
					new(2674, 2238, 6, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(2633, 2091, 10, ""),
					new(2749, 2164, -3, ""),
					new(2753, 2164, -3, ""),
					new(2753, 2169, -3, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(2634, 2091, 10, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(2634, 2089, 10, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(2634, 2090, 10, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4021, "", new DecorationEntry[]
				{
					new(2636, 2083, 10, ""),
				}),
				new("Tongs", typeof(Static), 4027, "", new DecorationEntry[]
				{
					new(2636, 2083, 11, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(2632, 2085, 14, ""),
					new(2665, 2090, 11, ""),
					new(2714, 2097, 1, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(2733, 2248, 2, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(2734, 2248, 4, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(2666, 2090, 11, ""),
					new(2709, 2177, 6, ""),
					new(2715, 2097, 4, ""),
				}),
				new("Chisels", typeof(Static), 4135, "", new DecorationEntry[]
				{
					new(2627, 2097, 16, ""),
				}),
				new("Moulding Planes", typeof(Static), 4141, "", new DecorationEntry[]
				{
					new(2627, 2096, 16, ""),
				}),
				new("Nails", typeof(Static), 4143, "", new DecorationEntry[]
				{
					new(2626, 2097, 16, ""),
				}),
				new("Jointing Plane", typeof(Static), 4144, "", new DecorationEntry[]
				{
					new(2626, 2097, 16, ""),
				}),
				new("Smoothing Plane", typeof(Static), 4147, "", new DecorationEntry[]
				{
					new(2627, 2097, 16, ""),
				}),
				new("Saw", typeof(Static), 4148, "", new DecorationEntry[]
				{
					new(2627, 2097, 16, ""),
				}),
				new("Globe", typeof(Static), 4167, "", new DecorationEntry[]
				{
					new(2728, 2260, 0, ""),
				}),
				new("Clock Frame", typeof(Static), 4173, "", new DecorationEntry[]
				{
					new(2627, 2096, 16, ""),
				}),
				new("Axle", typeof(Axle), 4187, "", new DecorationEntry[]
				{
					new(2626, 2096, 16, ""),
					new(2627, 2097, 16, ""),
				}),
				new("Cut Leather", typeof(Static), 4199, "", new DecorationEntry[]
				{
					new(2704, 2177, 0, ""),
					new(2705, 2176, 0, ""),
				}),
				new("Pile Of Hides", typeof(Static), 4216, "", new DecorationEntry[]
				{
					new(2706, 2177, 0, ""),
				}),
				new("Pile Of Hides", typeof(Static), 4217, "", new DecorationEntry[]
				{
					new(2705, 2178, 0, ""),
				}),
				new("Hanging Pole", typeof(Static), 4268, "", new DecorationEntry[]
				{
					new(2718, 2082, 0, ""),
				}),
				new("Hanging Pole", typeof(Static), 4269, "", new DecorationEntry[]
				{
					new(2718, 2081, 0, ""),
				}),
				new("Hanging Pole", typeof(Static), 4270, "", new DecorationEntry[]
				{
					new(2718, 2080, 0, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(2667, 2072, 11, ""),
				}),
				new("Log Table", typeof(Static), 4575, "", new DecorationEntry[]
				{
					new(2632, 2086, 10, ""),
					new(2672, 2157, 0, ""),
				}),
				new("Map", typeof(Static), 5356, "", new DecorationEntry[]
				{
					new(2728, 2258, 6, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(2744, 2169, -3, ""),
					new(2749, 2177, -3, ""),
					new(2752, 2160, -3, ""),
					new(2752, 2173, -3, ""),
					new(2758, 2166, -3, ""),
				}),
				new("Lockpick", typeof(Static), 5372, "", new DecorationEntry[]
				{
					new(2732, 2260, 6, ""),
					new(2732, 2261, 6, ""),
				}),
				new("Lockpicks", typeof(Static), 5374, "", new DecorationEntry[]
				{
					new(2731, 2261, 6, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(2672, 2244, 2, ""),
					new(2741, 2169, -3, ""),
					new(2749, 2171, -3, ""),
				}),
				new("Ore", typeof(Static), 6585, "", new DecorationEntry[]
				{
					new(2637, 2082, 16, ""),
				}),
				new("Glass", typeof(GlassMug), 8065, "", new DecorationEntry[]
				{
					new(2679, 2233, 4, ""),
				}),
				new("Glass Of Water", typeof(GlassMug), 8081, "Content=Water", new DecorationEntry[]
				{
					new(2679, 2233, 4, ""),
				}),
				
				#endregion
			});
		}
	}
}
