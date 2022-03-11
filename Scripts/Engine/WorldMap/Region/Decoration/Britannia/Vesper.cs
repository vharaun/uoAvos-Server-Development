using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Vesper { get; } = Register(DecorationTarget.Britannia, "Vesper", new DecorationList[]
			{
				#region Entries
				
				new("Pier", typeof(Static), 942, "", new DecorationEntry[]
				{
					new(3008, 794, -5, ""),
					new(3010, 794, -5, ""),
					new(3009, 798, -5, ""),
					new(3008, 798, -5, ""),
					new(3009, 794, -5, ""),
					new(3007, 795, -5, ""),
					new(3010, 798, -5, ""),
					new(3007, 797, -5, ""),
					new(3007, 796, -5, ""),
				}),
				new("Pier", typeof(Static), 943, "", new DecorationEntry[]
				{
					new(3019, 794, -5, ""),
					new(3019, 798, -5, ""),
					new(3020, 797, -5, ""),
					new(3017, 794, -5, ""),
					new(3018, 798, -5, ""),
					new(3018, 794, -5, ""),
					new(3020, 796, -5, ""),
					new(3020, 795, -5, ""),
					new(3017, 798, -5, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(2992, 760, 0, ""),
				}),
				new("Slab Of Bacon", typeof(Static), 2423, "", new DecorationEntry[]
				{
					new(2987, 781, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(2987, 832, 4, ""),
					new(2890, 784, 4, ""),
				}),
				new("Mug", typeof(CeramicMug), 2456, "", new DecorationEntry[]
				{
					new(2852, 1000, -17, ""),
					new(2902, 909, 2, ""),
					new(2852, 998, -17, ""),
					new(2852, 997, -17, ""),
					new(2746, 988, 4, ""),
					new(2744, 988, 4, ""),
				}),
				new("Mug", typeof(CeramicMug), 2457, "", new DecorationEntry[]
				{
					new(2744, 987, 4, ""),
					new(2903, 914, 4, ""),
				}),
				new("Bottle Of Ale", typeof(BeverageBottle), 2463, "Content=Ale", new DecorationEntry[]
				{
					new(2952, 699, 4, ""),
					new(2872, 715, 4, ""),
					new(2864, 857, 4, ""),
					new(2920, 796, 4, ""),
				}),
				new("Bottles Of Ale", typeof(Static), 2466, "", new DecorationEntry[]
				{
					new(2855, 988, -15, ""),
					new(2861, 992, -15, ""),
				}),
				new("Fork", typeof(Fork), 2467, "", new DecorationEntry[]
				{
					new(3006, 812, 6, ""),
					new(2894, 659, 6, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(2745, 987, 4, ""),
					new(2747, 987, 4, ""),
				}),
				new("Knife", typeof(Knife), 2469, "", new DecorationEntry[]
				{
					new(2894, 659, 6, ""),
					new(3006, 812, 6, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(2747, 987, 4, ""),
					new(2745, 987, 4, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(2992, 640, 6, ""),
					new(2997, 760, 6, ""),
					new(2990, 776, 6, ""),
					new(2864, 848, 6, ""),
					new(2995, 832, 6, ""),
					new(2898, 916, 6, ""),
					new(2839, 880, 6, ""),
					new(2863, 808, 6, ""),
					new(2842, 864, 6, ""),
					new(2888, 654, 6, ""),
					new(2877, 720, 6, ""),
					new(2842, 792, 6, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(2873, 674, 0, ""),
					new(2877, 688, 0, ""),
					new(2872, 672, 0, ""),
					new(2876, 676, 0, ""),
					new(2875, 675, 0, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(2745, 987, 4, ""),
					new(2747, 987, 4, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2500, "", new DecorationEntry[]
				{
					new(2896, 912, 6, ""),
					new(2892, 912, 6, ""),
					new(2856, 988, -15, ""),
					new(2861, 991, -15, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2501, "", new DecorationEntry[]
				{
					new(2899, 905, 4, ""),
				}),
				new("Bottles Of Wine", typeof(Static), 2502, "", new DecorationEntry[]
				{
					new(2898, 915, 6, ""),
				}),
				new("Bottle Of Wine", typeof(Static), 2503, "", new DecorationEntry[]
				{
					new(2903, 909, 2, ""),
					new(2994, 632, 4, ""),
					new(3006, 811, 6, ""),
					new(2894, 912, 6, ""),
					new(2952, 627, 4, ""),
					new(2894, 658, 6, ""),
					new(2904, 904, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2506, "", new DecorationEntry[]
				{
					new(3006, 811, 6, ""),
					new(2894, 658, 6, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(2995, 632, 4, ""),
					new(2952, 700, 4, ""),
					new(2747, 987, 4, ""),
					new(2864, 858, 4, ""),
					new(2894, 659, 6, ""),
					new(2747, 988, 4, ""),
					new(2896, 708, 4, ""),
					new(2920, 797, 4, ""),
					new(2745, 988, 4, ""),
					new(2988, 832, 4, ""),
					new(2745, 987, 4, ""),
					new(2872, 716, 4, ""),
					new(2891, 784, 4, ""),
					new(2952, 628, 4, ""),
					new(3006, 812, 6, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(2992, 766, 6, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2542, "Content=Ale", new DecorationEntry[]
				{
					new(2861, 990, -15, ""),
					new(2858, 988, -15, ""),
					new(2859, 988, -15, ""),
					new(2861, 996, -15, ""),
					new(2861, 995, -15, ""),
					new(2861, 994, -15, ""),
					new(2899, 904, 4, ""),
					new(2895, 908, 2, ""),
					new(2854, 988, -15, ""),
					new(2853, 988, -15, ""),
					new(2861, 989, -15, ""),
					new(2898, 913, 6, ""),
				}),
				new("Mug Of Ale", typeof(Static), 2543, "Content=Ale", new DecorationEntry[]
				{
					new(2904, 903, 4, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(2747, 988, 4, ""),
					new(2988, 832, 4, ""),
					new(2995, 632, 4, ""),
					new(2891, 784, 4, ""),
					new(2745, 988, 4, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(2952, 628, 4, ""),
					new(2872, 716, 4, ""),
					new(2952, 700, 4, ""),
					new(2864, 858, 4, ""),
					new(2920, 797, 4, ""),
					new(2896, 708, 4, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(2747, 988, 4, ""),
					new(2891, 784, 4, ""),
					new(2988, 832, 4, ""),
					new(2995, 632, 4, ""),
					new(2745, 988, 4, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(2864, 858, 4, ""),
					new(2872, 716, 4, ""),
					new(2952, 700, 4, ""),
					new(2896, 708, 4, ""),
					new(2952, 628, 4, ""),
					new(2920, 797, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(2988, 832, 4, ""),
					new(2747, 988, 4, ""),
					new(2995, 632, 4, ""),
					new(2745, 988, 4, ""),
					new(2891, 784, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(2864, 858, 4, ""),
					new(2872, 716, 4, ""),
					new(2952, 700, 4, ""),
					new(2920, 797, 4, ""),
					new(2896, 708, 4, ""),
					new(2952, 628, 4, ""),
				}),
				new("Hanging Lantern", typeof(HangingLantern), 2586, "", new DecorationEntry[]
				{
					new(2768, 970, 6, ""),
				}),
				new("Lantern", typeof(Lantern), 2594, "", new DecorationEntry[]
				{
					new(2742, 979, 26, ""),
				}),
				new("Stool", typeof(Stool), 2602, "", new DecorationEntry[]
				{
					new(2899, 706, 0, ""),
					new(2858, 989, -21, ""),
					new(2860, 994, -21, ""),
					new(2860, 995, -21, ""),
					new(2860, 996, -21, ""),
					new(2860, 993, -21, ""),
					new(2859, 989, -21, ""),
					new(2860, 990, -21, ""),
					new(2860, 991, -21, ""),
					new(2857, 989, -21, ""),
					new(2855, 989, -21, ""),
					new(2860, 989, -21, ""),
					new(2854, 989, -21, ""),
					new(2853, 989, -21, ""),
					new(2852, 989, -21, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(2789, 958, 0, ""),
					new(2789, 964, 0, ""),
					new(2789, 952, 0, ""),
					new(2779, 970, 0, ""),
					new(2789, 970, 0, ""),
					new(2778, 952, 0, ""),
					new(2779, 958, 0, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2608, "", new DecorationEntry[]
				{
					new(2955, 870, 0, ""),
					new(2963, 882, 0, ""),
					new(2954, 882, 0, ""),
					new(2955, 876, 0, ""),
					new(2787, 976, 0, ""),
					new(2923, 792, 0, ""),
					new(2913, 857, 0, ""),
					new(2963, 864, 0, ""),
					new(2953, 696, 0, ""),
					new(2963, 870, 0, ""),
					new(2955, 864, 0, ""),
					new(2865, 856, 0, ""),
					new(2997, 632, 0, ""),
					new(2777, 976, 0, ""),
					new(2889, 784, 0, ""),
					new(2955, 888, 0, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(2872, 714, 0, ""),
					new(2962, 889, 0, ""),
					new(2984, 834, 0, ""),
					new(2952, 626, 0, ""),
					new(2896, 706, 0, ""),
					new(2888, 661, 0, ""),
					new(3000, 813, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(2954, 624, 0, ""),
					new(3005, 808, 0, ""),
					new(2874, 712, 0, ""),
					new(2986, 832, 0, ""),
					new(2957, 696, 0, ""),
					new(2779, 976, 0, ""),
					new(2993, 632, 0, ""),
					new(2915, 857, 0, ""),
					new(2898, 704, 0, ""),
					new(2893, 656, 0, ""),
					new(2869, 856, 0, ""),
					new(2921, 792, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(2888, 786, 0, ""),
					new(2952, 893, 0, ""),
					new(2962, 893, 0, ""),
					new(2786, 978, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(2918, 664, 20, ""),
					new(2737, 976, 0, ""),
					new(2886, 648, 0, ""),
					new(2993, 832, 0, ""),
					new(2861, 728, 0, ""),
					new(2966, 816, 0, ""),
					new(2847, 904, 0, ""),
					new(2965, 808, 0, ""),
					new(2882, 744, 0, ""),
					new(2937, 928, 0, ""),
					new(2865, 808, 0, ""),
					new(2940, 936, 0, ""),
					new(2915, 664, 0, ""),
					new(2915, 664, 20, ""),
					new(2961, 816, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(2866, 808, 0, ""),
					new(2851, 728, 0, ""),
					new(2937, 936, 0, ""),
					new(2962, 808, 0, ""),
					new(2993, 640, 0, ""),
					new(2887, 648, 0, ""),
					new(2994, 832, 0, ""),
					new(2997, 640, 0, ""),
					new(2913, 664, 0, ""),
					new(2884, 744, 0, ""),
					new(2848, 904, 0, ""),
					new(2996, 832, 0, ""),
					new(2941, 928, 0, ""),
					new(2741, 976, 0, ""),
					new(2917, 664, 0, ""),
					new(2967, 816, 0, ""),
					new(2916, 664, 20, ""),
					new(2960, 816, 0, ""),
					new(2860, 728, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(2992, 817, 0, ""),
					new(2992, 833, 0, ""),
					new(2880, 745, 0, ""),
					new(2992, 812, 0, ""),
					new(2768, 966, 0, ""),
					new(2872, 722, 0, ""),
					new(2840, 947, 0, ""),
					new(2840, 952, 0, ""),
					new(2872, 725, 0, ""),
					new(2944, 941, 0, ""),
					new(2920, 667, 20, ""),
					new(2736, 981, 0, ""),
					new(2944, 936, 0, ""),
					new(2960, 810, 0, ""),
					new(2912, 676, 20, ""),
					new(2918, 857, 0, ""),
					new(2840, 898, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(2944, 930, 0, ""),
					new(2840, 899, 0, ""),
					new(2840, 950, 0, ""),
					new(2912, 665, 0, ""),
					new(2736, 977, 0, ""),
					new(2960, 813, 0, ""),
					new(2920, 668, 20, ""),
					new(2736, 980, 0, ""),
					new(2918, 858, 0, ""),
					new(2840, 953, 0, ""),
					new(2872, 721, 0, ""),
					new(2768, 967, 0, ""),
					new(2840, 946, 0, ""),
					new(2992, 810, 0, ""),
					new(2880, 749, 0, ""),
					new(2944, 935, 0, ""),
					new(2992, 816, 0, ""),
					new(2936, 937, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(2938, 936, 0, ""),
					new(2888, 648, 0, ""),
					new(2917, 664, 20, ""),
					new(2997, 832, 0, ""),
					new(2914, 664, 0, ""),
					new(2968, 816, 0, ""),
					new(2962, 816, 0, ""),
					new(2849, 904, 0, ""),
					new(2852, 728, 0, ""),
					new(2889, 648, 0, ""),
					new(2941, 936, 0, ""),
					new(2916, 664, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(2936, 941, 0, ""),
					new(2872, 724, 0, ""),
					new(2840, 948, 0, ""),
					new(2912, 674, 20, ""),
					new(2768, 968, 0, ""),
					new(2912, 675, 20, ""),
					new(2920, 669, 20, ""),
					new(2840, 900, 0, ""),
					new(2918, 862, 0, ""),
					new(2840, 949, 0, ""),
					new(2912, 666, 0, ""),
					new(2880, 746, 0, ""),
					new(2912, 677, 20, ""),
					new(2992, 821, 0, ""),
					new(2880, 748, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(2971, 875, 4, ""),
					new(2900, 789, 6, ""),
					new(3006, 813, 6, ""),
					new(2888, 739, 4, ""),
					new(2939, 940, 4, ""),
					new(2990, 780, 6, ""),
					new(2923, 859, 6, ""),
					new(2989, 832, 4, ""),
					new(2952, 701, 4, ""),
					new(3015, 779, 6, ""),
					new(2918, 852, 6, ""),
					new(2907, 706, 6, ""),
					new(2997, 763, 6, ""),
					new(2992, 644, 6, ""),
					new(2996, 632, 4, ""),
					new(2952, 629, 4, ""),
					new(2996, 813, 6, ""),
					new(2939, 932, 4, ""),
					new(2894, 660, 6, ""),
					new(2995, 838, 6, ""),
					new(2920, 798, 4, ""),
					new(2896, 709, 4, ""),
					new(2863, 812, 6, ""),
					new(2955, 811, 4, ""),
					new(2788, 963, 20, ""),
					new(2882, 674, 6, ""),
					new(2864, 849, 6, ""),
					new(2842, 868, 6, ""),
					new(2860, 988, -15, ""),
					new(2884, 739, 4, ""),
					new(2883, 746, 4, ""),
					new(2861, 998, 6, ""),
					new(2864, 859, 4, ""),
					new(2872, 717, 4, ""),
					new(2916, 801, 6, ""),
					new(2842, 810, 6, ""),
					new(2837, 912, 4, ""),
					new(2957, 707, 6, ""),
					new(2892, 784, 4, ""),
					new(2841, 912, 4, ""),
					new(2964, 624, 6, ""),
					new(2877, 721, 6, ""),
					new(2964, 811, 4, ""),
					new(2959, 616, 6, ""),
					new(2844, 899, 4, ""),
					new(2887, 675, 6, ""),
					new(2850, 740, 4, ""),
					new(2856, 728, 6, ""),
					new(2746, 987, 4, ""),
					new(2850, 730, 4, ""),
					new(2955, 817, 4, ""),
					new(2856, 993, -15, ""),
					new(3020, 763, 6, ""),
					new(2842, 793, 6, ""),
				}),
				new("Candelabra", typeof(Candelabra), 2845, "", new DecorationEntry[]
				{
					new(2790, 973, 6, ""),
					new(2790, 955, 6, ""),
					new(2790, 979, 6, ""),
					new(2776, 978, 6, ""),
					new(2778, 956, 6, ""),
					new(2790, 961, 6, ""),
					new(2778, 962, 6, ""),
					new(2736, 988, 6, ""),
					new(2778, 974, 6, ""),
					new(2788, 968, 6, ""),
				}),
				new("Lamp Post", typeof(LampPost2), 2850, "", new DecorationEntry[]
				{
					new(2976, 623, 0, ""),
					new(2943, 624, 0, ""),
					new(2943, 617, 0, ""),
					new(2982, 640, 0, ""),
				}),
				new("Lamp Post", typeof(LampPost3), 2852, "", new DecorationEntry[]
				{
					new(3003, 782, 0, ""),
					new(2950, 918, 0, ""),
					new(2904, 858, 0, ""),
					new(2848, 867, 0, ""),
					new(2903, 692, 0, ""),
					new(2946, 705, 0, ""),
					new(2969, 776, 0, ""),
					new(2902, 712, 0, ""),
					new(3006, 840, 0, ""),
					new(3007, 817, 0, ""),
					new(2886, 780, 0, ""),
					new(2848, 799, 0, ""),
					new(2862, 919, 1, ""),
					new(2950, 898, 0, ""),
					new(2848, 927, 0, ""),
					new(2848, 883, 0, ""),
					new(2827, 906, 0, ""),
					new(2847, 817, 0, ""),
					new(2823, 706, 0, ""),
					new(2774, 982, 0, ""),
					new(2766, 974, 0, ""),
					new(2752, 976, 0, ""),
					new(2752, 991, 0, ""),
					new(2861, 795, 0, ""),
					new(2847, 850, 0, ""),
					new(2919, 711, 2, ""),
					new(2982, 737, 20, ""),
					new(2984, 765, 0, ""),
					new(2977, 804, 0, ""),
					new(2980, 878, 0, ""),
					new(2921, 839, 0, ""),
					new(2933, 851, 0, ""),
					new(2919, 902, 0, ""),
					new(2959, 740, 20, ""),
					new(2823, 700, 0, ""),
					new(2791, 984, 0, ""),
					new(2825, 958, -1, ""),
					new(2907, 786, 0, ""),
					new(2807, 996, 0, ""),
					new(2825, 952, 0, ""),
					new(2828, 889, 2, ""),
					new(2905, 924, 0, ""),
					new(2836, 996, 0, ""),
					new(2828, 927, 0, ""),
					new(2905, 988, 0, ""),
					new(2807, 990, 0, ""),
					new(2929, 936, -1, ""),
					new(2929, 963, 0, ""),
					new(2914, 686, 2, ""),
					new(2974, 838, 0, ""),
					new(2836, 990, 0, ""),
					new(2801, 952, 0, ""),
					new(2801, 958, 0, ""),
					new(2902, 663, 1, ""),
					new(2911, 956, 0, ""),
					new(3010, 762, 0, ""),
					new(2953, 857, 0, ""),
					new(2964, 718, 3, ""),
					new(2863, 876, 0, ""),
					new(2872, 983, -1, ""),
					new(2879, 663, 0, ""),
					new(2880, 790, 0, ""),
					new(2866, 700, 1, ""),
					new(2952, 837, -1, ""),
					new(2880, 850, 0, ""),
					new(2721, 984, 0, ""),
					new(2952, 943, 0, ""),
					new(3031, 773, 0, ""),
					new(2880, 712, 0, ""),
					new(2862, 856, 0, ""),
					new(2886, 755, 0, ""),
					new(2856, 904, 0, ""),
					new(2868, 727, 0, ""),
					new(2913, 813, 0, ""),
					new(2721, 990, 0, ""),
					new(2886, 912, 0, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(2892, 918, 0, ""),
					new(2886, 680, 0, ""),
					new(2832, 872, 0, ""),
					new(2960, 864, 0, ""),
					new(2886, 686, 0, ""),
					new(2960, 894, 0, ""),
					new(2784, 952, 0, ""),
					new(2784, 982, 0, ""),
					new(2914, 910, 0, ""),
					new(2914, 904, 0, ""),
					new(2872, 686, 0, ""),
					new(2892, 901, 0, ""),
					new(2832, 879, 0, ""),
					new(2736, 982, 0, ""),
					new(2872, 680, 0, ""),
					new(2742, 976, 0, ""),
				}),
				new("Counter", typeof(Static), 2878, "", new DecorationEntry[]
				{
					new(2907, 706, 0, ""),
					new(2995, 813, 0, ""),
					new(2996, 808, 0, ""),
					new(2971, 882, 0, ""),
					new(2899, 789, 0, ""),
					new(2895, 912, 0, ""),
					new(2915, 668, 0, ""),
					new(2954, 707, 0, ""),
					new(2884, 648, 0, ""),
					new(2922, 859, 0, ""),
					new(3019, 763, 0, ""),
					new(3017, 763, 0, ""),
					new(2915, 801, 0, ""),
					new(2771, 963, 0, ""),
					new(2769, 963, 0, ""),
					new(2893, 912, 0, ""),
					new(2994, 838, 0, ""),
					new(2909, 706, 0, ""),
					new(2995, 808, 0, ""),
					new(3014, 779, 0, ""),
					new(2993, 813, 0, ""),
					new(2913, 801, 0, ""),
					new(2913, 668, 0, ""),
					new(2898, 784, 0, ""),
					new(2883, 674, 0, ""),
					new(2858, 998, 0, ""),
					new(2858, 989, 0, ""),
					new(2963, 624, 0, ""),
					new(2859, 989, 0, ""),
					new(2900, 784, 0, ""),
					new(2860, 998, 0, ""),
					new(2956, 707, 0, ""),
					new(2858, 988, -21, ""),
					new(2897, 912, 0, ""),
					new(2855, 728, 0, ""),
					new(2958, 616, 0, ""),
					new(2855, 993, -21, ""),
					new(2897, 789, 0, ""),
					new(2961, 624, 0, ""),
					new(2857, 728, 0, ""),
					new(2969, 882, 0, ""),
					new(3012, 779, 0, ""),
				}),
				new("Writing Table", typeof(WritingTable), 2889, "", new DecorationEntry[]
				{
					new(2908, 709, 0, ""),
					new(2908, 715, 0, ""),
					new(2908, 712, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(2914, 971, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(2989, 778, 0, ""),
					new(2849, 735, 0, ""),
					new(2938, 931, 0, ""),
					new(2996, 762, 0, ""),
					new(3005, 812, 0, ""),
					new(2834, 912, 0, ""),
					new(2873, 683, 0, ""),
					new(2921, 668, 0, ""),
					new(2876, 722, 0, ""),
					new(2938, 939, 0, ""),
					new(2994, 835, 0, ""),
					new(2881, 739, 0, ""),
					new(2882, 747, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(2914, 667, 0, ""),
					new(2994, 812, 0, ""),
					new(2858, 998, -21, ""),
					new(2739, 978, 0, ""),
					new(2843, 898, 0, ""),
					new(2908, 705, 0, ""),
					new(3018, 762, 0, ""),
					new(2963, 810, 0, ""),
					new(2955, 809, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "", new DecorationEntry[]
				{
					new(2922, 861, 0, ""),
					new(2970, 883, 0, ""),
					new(3013, 780, 0, ""),
					new(2962, 625, 0, ""),
					new(2859, 999, 0, ""),
					new(2919, 676, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(2865, 850, 0, ""),
					new(2918, 804, 0, ""),
					new(2918, 805, 0, ""),
					new(2993, 642, 0, ""),
					new(2889, 652, 0, ""),
					new(2843, 866, 0, ""),
					new(2843, 812, 0, ""),
					new(2843, 794, 0, ""),
					new(2864, 810, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(2886, 676, 0, ""),
					new(2768, 973, 0, ""),
					new(2768, 969, 0, ""),
					new(2953, 818, 0, ""),
					new(2849, 731, 0, ""),
					new(2953, 816, 0, ""),
					new(2924, 668, 20, ""),
					new(2849, 733, 0, ""),
					new(2840, 937, 0, ""),
					new(2849, 739, 0, ""),
					new(2953, 810, 0, ""),
					new(2916, 667, 20, ""),
					new(2953, 814, 0, ""),
					new(2849, 737, 0, ""),
					new(2912, 805, 0, ""),
					new(2893, 659, 0, ""),
					new(2944, 934, 0, ""),
					new(2832, 873, 0, ""),
					new(2851, 1000, -21, ""),
					new(2832, 878, 0, ""),
					new(2840, 941, 0, ""),
					new(2912, 804, 0, ""),
					new(2832, 801, 0, ""),
					new(2969, 875, 0, ""),
					new(2953, 812, 0, ""),
					new(2944, 937, 0, ""),
					new(2832, 806, 0, ""),
					new(2851, 998, -21, ""),
					new(2851, 996, -21, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(2842, 910, 0, ""),
					new(2923, 673, 20, ""),
					new(2889, 737, 0, ""),
					new(2971, 873, 0, ""),
					new(2919, 673, 20, ""),
					new(2917, 673, 20, ""),
					new(2776, 964, 0, ""),
					new(2841, 904, 0, ""),
					new(2780, 964, 0, ""),
					new(2887, 737, 0, ""),
					new(2885, 737, 0, ""),
					new(2921, 673, 20, ""),
					new(2893, 672, 0, ""),
					new(2838, 910, 0, ""),
					new(2914, 800, 0, ""),
					new(2770, 962, 0, ""),
					new(2898, 788, 0, ""),
					new(2883, 737, 0, ""),
					new(2955, 706, 0, ""),
					new(2845, 904, 0, ""),
					new(2889, 672, 0, ""),
					new(2836, 910, 0, ""),
					new(2915, 673, 20, ""),
					new(2840, 910, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(2852, 739, 0, ""),
					new(2888, 676, 0, ""),
					new(2852, 733, 0, ""),
					new(2921, 797, 0, ""),
					new(2854, 996, -21, ""),
					new(2973, 875, 0, ""),
					new(2923, 667, 0, ""),
					new(2923, 669, 0, ""),
					new(2852, 735, 0, ""),
					new(2852, 737, 0, ""),
					new(2909, 712, 0, ""),
					new(2909, 709, 0, ""),
					new(2884, 748, 0, ""),
					new(2897, 708, 0, ""),
					new(2865, 858, 0, ""),
					new(2909, 715, 0, ""),
					new(2940, 940, 0, ""),
					new(2873, 716, 0, ""),
					new(2940, 932, 0, ""),
					new(2957, 810, 0, ""),
					new(2940, 938, 0, ""),
					new(2940, 930, 0, ""),
					new(2957, 812, 0, ""),
					new(2913, 795, 0, ""),
					new(2957, 818, 0, ""),
					new(2854, 998, -21, ""),
					new(2884, 746, 0, ""),
					new(2953, 700, 0, ""),
					new(2953, 628, 0, ""),
					new(2891, 739, 0, ""),
					new(2854, 1000, -21, ""),
					new(2852, 731, 0, ""),
					new(2957, 814, 0, ""),
					new(2916, 794, 0, ""),
					new(2957, 816, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(2962, 812, 0, ""),
					new(2971, 877, 0, ""),
					new(2955, 819, 0, ""),
					new(2964, 812, 0, ""),
					new(2844, 900, 0, ""),
					new(2842, 914, 0, ""),
					new(2857, 729, 0, ""),
					new(2855, 729, 0, ""),
					new(2836, 914, 0, ""),
					new(2838, 914, 0, ""),
					new(2842, 900, 0, ""),
					new(2840, 914, 0, ""),
					new(2887, 741, 0, ""),
					new(2883, 741, 0, ""),
					new(2891, 785, 0, ""),
					new(2885, 741, 0, ""),
					new(2899, 785, 0, ""),
					new(2858, 1000, -21, ""),
					new(2883, 675, 0, ""),
					new(2889, 741, 0, ""),
					new(2917, 676, 20, ""),
					new(2921, 676, 20, ""),
					new(2988, 833, 0, ""),
					new(2914, 669, 0, ""),
					new(2915, 676, 20, ""),
					new(2923, 676, 20, ""),
					new(2995, 633, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(2912, 798, 0, ""),
					new(2912, 799, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2907, "", new DecorationEntry[]
				{
					new(2745, 986, 0, ""),
					new(2747, 986, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(2745, 989, 0, ""),
					new(2739, 980, 0, ""),
					new(2747, 989, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(2737, 987, 0, ""),
				}),
				new("Foot Stool", typeof(FootStool), 2910, "", new DecorationEntry[]
				{
					new(2899, 915, 0, ""),
					new(2912, 803, 0, ""),
					new(2899, 913, 0, ""),
					new(2893, 911, 0, ""),
					new(2895, 911, 0, ""),
					new(2897, 911, 0, ""),
					new(2912, 802, 0, ""),
				}),
				new("Bench", typeof(Static), 2911, "", new DecorationEntry[]
				{
					new(2904, 916, 0, ""),
					new(2900, 905, 0, ""),
					new(2895, 905, 0, ""),
					new(2898, 905, 0, ""),
					new(2902, 916, 0, ""),
					new(2893, 905, 0, ""),
					new(2905, 905, 0, ""),
					new(2903, 905, 0, ""),
				}),
				new("Bench", typeof(Static), 2912, "", new DecorationEntry[]
				{
					new(2900, 902, 0, ""),
					new(2905, 902, 0, ""),
					new(2904, 913, 0, ""),
					new(2893, 902, 0, ""),
					new(2902, 913, 0, ""),
					new(2895, 902, 0, ""),
					new(2898, 902, 0, ""),
					new(2903, 902, 0, ""),
				}),
				new("Bench", typeof(Static), 2913, "", new DecorationEntry[]
				{
					new(2893, 903, 0, ""),
					new(2900, 904, 0, ""),
					new(2900, 903, 0, ""),
					new(2904, 914, 0, ""),
					new(2902, 914, 0, ""),
					new(2904, 915, 0, ""),
					new(2893, 904, 0, ""),
					new(2903, 903, 0, ""),
					new(2905, 904, 0, ""),
					new(2905, 903, 0, ""),
					new(2898, 903, 0, ""),
					new(2902, 915, 0, ""),
					new(2903, 904, 0, ""),
					new(2895, 904, 0, ""),
					new(2898, 904, 0, ""),
					new(2895, 903, 0, ""),
				}),
				new("Bench", typeof(Static), 2917, "", new DecorationEntry[]
				{
					new(2904, 910, 0, ""),
					new(2897, 907, 0, ""),
					new(2904, 908, 0, ""),
					new(2897, 909, 0, ""),
				}),
				new("Bench", typeof(Static), 2918, "", new DecorationEntry[]
				{
					new(2901, 908, 0, ""),
					new(2901, 910, 0, ""),
					new(2894, 907, 0, ""),
					new(2894, 909, 0, ""),
				}),
				new("Bench", typeof(Static), 2919, "", new DecorationEntry[]
				{
					new(2896, 909, 0, ""),
					new(2896, 907, 0, ""),
					new(2902, 908, 0, ""),
					new(2903, 910, 0, ""),
					new(2902, 910, 0, ""),
					new(2903, 908, 0, ""),
					new(2895, 909, 0, ""),
					new(2895, 907, 0, ""),
				}),
				new("Table", typeof(Static), 2943, "", new DecorationEntry[]
				{
					new(2857, 999, 24, ""),
				}),
				new("Broken Chair", typeof(Static), 3088, "", new DecorationEntry[]
				{
					new(2915, 793, 6, ""),
				}),
				new("Broken Chair", typeof(Static), 3089, "", new DecorationEntry[]
				{
					new(2912, 796, 6, ""),
				}),
				new("Tree", typeof(Static), 3274, "", new DecorationEntry[]
				{
					new(2888, 642, 1, ""),
				}),
				new("Tree", typeof(Static), 3275, "", new DecorationEntry[]
				{
					new(2884, 641, 1, ""),
				}),
				new("Leaves", typeof(Static), 3278, "", new DecorationEntry[]
				{
					new(2888, 642, 1, ""),
					new(2884, 641, 1, ""),
				}),
				new("Tree", typeof(Static), 3280, "", new DecorationEntry[]
				{
					new(2793, 938, 0, ""),
				}),
				new("Leaves", typeof(Static), 3281, "", new DecorationEntry[]
				{
					new(2793, 938, 0, ""),
				}),
				new("Knitting", typeof(Static), 3575, "", new DecorationEntry[]
				{
					new(2839, 881, 6, ""),
				}),
				new("Pile Of Wool", typeof(Static), 3576, "Hue=0x58", new DecorationEntry[]
				{
					new(2956, 616, 0, ""),
				}),
				new("Pile Of Wool", typeof(Static), 3576, "", new DecorationEntry[]
				{
					new(2843, 881, 0, ""),
				}),
				new("Pile Of Wool", typeof(Static), 3576, "Hue=0x25", new DecorationEntry[]
				{
					new(2965, 627, 0, ""),
				}),
				new("Bale Of Cotton", typeof(Static), 3577, "", new DecorationEntry[]
				{
					new(2840, 880, 0, ""),
				}),
				new("Bale Of Cotton", typeof(Static), 3577, "Hue=0x25", new DecorationEntry[]
				{
					new(2965, 628, 0, ""),
				}),
				new("Chessmen", typeof(Static), 3603, "", new DecorationEntry[]
				{
					new(2894, 903, 4, ""),
				}),
				new("Chessmen", typeof(Static), 3604, "", new DecorationEntry[]
				{
					new(2894, 903, 4, ""),
				}),
				new("Cards", typeof(Static), 3605, "", new DecorationEntry[]
				{
					new(2971, 876, 4, ""),
				}),
				new("Cards", typeof(Static), 3606, "", new DecorationEntry[]
				{
					new(2971, 874, 4, ""),
				}),
				new("Cards", typeof(Static), 3607, "", new DecorationEntry[]
				{
					new(2970, 874, 4, ""),
				}),
				new("Cards", typeof(Static), 3608, "", new DecorationEntry[]
				{
					new(2970, 875, 4, ""),
				}),
				new("Cards", typeof(Static), 3609, "", new DecorationEntry[]
				{
					new(2972, 875, 4, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "Light=Circle150", new DecorationEntry[]
				{
					new(2913, 668, 6, ""),
					new(2917, 667, 26, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3644, "", new DecorationEntry[]
				{
					new(2835, 864, 6, ""),
					new(2835, 864, 0, ""),
					new(2835, 864, 3, ""),
					new(2989, 776, 9, ""),
					new(2989, 776, 6, ""),
					new(2989, 776, 3, ""),
					new(2989, 776, 0, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(2876, 673, 0, ""),
					new(2874, 672, 0, ""),
					new(2876, 672, 0, ""),
					new(2874, 676, 0, ""),
					new(2872, 676, 0, ""),
					new(2874, 674, 0, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(2918, 806, 0, ""),
					new(3016, 766, 6, ""),
					new(2833, 864, 0, ""),
					new(3016, 766, 3, ""),
					new(2984, 640, 3, ""),
					new(2984, 639, 0, ""),
					new(3016, 766, 0, ""),
					new(2918, 806, 3, ""),
					new(3016, 764, 3, ""),
					new(3016, 764, 0, ""),
					new(2918, 806, 9, ""),
					new(3016, 765, 3, ""),
					new(3016, 765, 0, ""),
					new(3016, 764, 6, ""),
					new(2985, 640, 3, ""),
					new(2985, 640, 0, ""),
					new(2985, 639, 0, ""),
					new(2917, 806, 0, ""),
					new(2833, 864, 6, ""),
					new(2834, 864, 3, ""),
					new(2834, 864, 0, ""),
					new(2984, 639, 3, ""),
					new(2984, 640, 9, ""),
					new(2984, 640, 6, ""),
					new(2984, 640, 0, ""),
					new(2918, 806, 6, ""),
					new(2833, 864, 3, ""),
					new(2917, 806, 6, ""),
					new(2917, 806, 3, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(2989, 640, 0, ""),
					new(2872, 673, 0, ""),
					new(2989, 639, 0, ""),
					new(2989, 639, 3, ""),
					new(2990, 638, 0, ""),
					new(2989, 639, 6, ""),
					new(2877, 674, 0, ""),
					new(2991, 640, 0, ""),
					new(2874, 689, 0, ""),
					new(2886, 689, 0, ""),
					new(2991, 640, 3, ""),
					new(2990, 639, 0, ""),
					new(2990, 638, 6, ""),
					new(2876, 674, 0, ""),
					new(2990, 639, 3, ""),
					new(2990, 639, 6, ""),
					new(2990, 640, 0, ""),
					new(2990, 640, 3, ""),
					new(2990, 638, 3, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(2876, 692, 0, ""),
					new(2877, 672, 0, ""),
					new(2873, 688, 0, ""),
					new(2876, 675, 0, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3648, "ContentType=Guard", new DecorationEntry[]
				{
					new(2736, 985, 0, ""),
					new(2736, 989, 0, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(2952, 892, 0, ""),
					new(2786, 971, 0, ""),
					new(2776, 955, 0, ""),
					new(2962, 868, 0, ""),
					new(2962, 874, 0, ""),
					new(2776, 973, 0, ""),
					new(2786, 954, 0, ""),
					new(2952, 874, 0, ""),
					new(2952, 865, 0, ""),
					new(2952, 877, 0, ""),
					new(2786, 960, 0, ""),
					new(2952, 883, 0, ""),
					new(2786, 965, 0, ""),
					new(2776, 961, 0, ""),
					new(2962, 886, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(2885, 692, 0, ""),
					new(2884, 691, 0, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(2963, 888, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(2880, 688, 0, ""),
					new(2884, 690, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(2881, 690, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(2744, 985, 25, ""),
					new(2739, 978, 20, ""),
					new(2738, 979, 25, ""),
					new(2745, 986, 25, ""),
					new(2738, 979, 20, ""),
					new(2745, 986, 20, ""),
					new(2744, 986, 20, ""),
					new(2738, 978, 25, ""),
					new(2745, 985, 20, ""),
					new(2744, 986, 25, ""),
					new(2745, 985, 25, ""),
					new(2744, 985, 20, ""),
					new(2738, 978, 20, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(2958, 704, 0, ""),
					new(2953, 704, 5, ""),
					new(2892, 917, 0, ""),
					new(2892, 914, 0, ""),
					new(2958, 705, 5, ""),
					new(2958, 705, 0, ""),
					new(2958, 704, 5, ""),
					new(3011, 832, 2, ""),
					new(3016, 760, 0, ""),
					new(2952, 704, 5, ""),
					new(2953, 704, 0, ""),
					new(2952, 704, 0, ""),
					new(2892, 913, 5, ""),
					new(3044, 836, -3, ""),
					new(3035, 830, 2, ""),
					new(2984, 633, 5, ""),
					new(3036, 830, 2, ""),
					new(3028, 835, -3, ""),
					new(3043, 836, 2, ""),
					new(3016, 776, 0, ""),
					new(2959, 704, 5, ""),
					new(2892, 913, 0, ""),
					new(2959, 704, 0, ""),
					new(3028, 835, 2, ""),
					new(3012, 833, -3, ""),
					new(3026, 824, -3, ""),
					new(3012, 832, 2, ""),
					new(3036, 830, -3, ""),
					new(3012, 833, 2, ""),
					new(3016, 760, 5, ""),
					new(3011, 833, -3, ""),
					new(3011, 833, 2, ""),
					new(3011, 776, 0, ""),
					new(3016, 761, 0, ""),
					new(3012, 820, 2, ""),
					new(3010, 776, 5, ""),
					new(3041, 816, 2, ""),
					new(2983, 632, 0, ""),
					new(2893, 913, 0, ""),
					new(3011, 819, -3, ""),
					new(3009, 776, 5, ""),
					new(3010, 776, 0, ""),
					new(3009, 776, 0, ""),
					new(3016, 761, 5, ""),
					new(3004, 826, 0, ""),
					new(3004, 826, 5, ""),
					new(3011, 819, 2, ""),
					new(3004, 827, 5, ""),
					new(3005, 826, 0, ""),
					new(3004, 827, 0, ""),
					new(2845, 864, 5, ""),
					new(2846, 870, 5, ""),
					new(3014, 776, 0, ""),
					new(2892, 914, 5, ""),
					new(2844, 864, 0, ""),
					new(3015, 776, 0, ""),
					new(3015, 776, 5, ""),
					new(3037, 830, -3, ""),
					new(3044, 836, 2, ""),
					new(3016, 779, 0, ""),
					new(3043, 816, -3, ""),
					new(2845, 870, 5, ""),
					new(3011, 832, -3, ""),
					new(2845, 865, 0, ""),
					new(3029, 835, 2, ""),
					new(3037, 830, 2, ""),
					new(3025, 825, 2, ""),
					new(3025, 825, -3, ""),
					new(3029, 836, -3, ""),
					new(3029, 836, 2, ""),
					new(2846, 870, 0, ""),
					new(2983, 632, 10, ""),
					new(2983, 633, 5, ""),
					new(3012, 819, 2, ""),
					new(3044, 837, 2, ""),
					new(3011, 820, 2, ""),
					new(3044, 837, -3, ""),
					new(3043, 836, -3, ""),
					new(3005, 826, 5, ""),
					new(3026, 825, -3, ""),
					new(3016, 760, 10, ""),
					new(2983, 632, 5, ""),
					new(3016, 762, 0, ""),
					new(3016, 762, 5, ""),
					new(3026, 824, 2, ""),
					new(3026, 825, 2, ""),
					new(3017, 760, 0, ""),
					new(2984, 632, 5, ""),
					new(2846, 864, 10, ""),
					new(3016, 776, 10, ""),
					new(2846, 864, 5, ""),
					new(3029, 835, -3, ""),
					new(2984, 632, 10, ""),
					new(2844, 869, 0, ""),
					new(3012, 832, -3, ""),
					new(3012, 819, -3, ""),
					new(2846, 870, 10, ""),
					new(2846, 869, 5, ""),
					new(3043, 837, -3, ""),
					new(3012, 820, -3, ""),
					new(3041, 816, -3, ""),
					new(3042, 816, -3, ""),
					new(3016, 776, 5, ""),
					new(2845, 868, 0, ""),
					new(3043, 837, 2, ""),
					new(2984, 632, 0, ""),
					new(2845, 869, 0, ""),
					new(3035, 830, -3, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(2880, 692, 0, ""),
					new(2874, 694, 0, ""),
					new(2884, 694, 0, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(2884, 688, 0, ""),
					new(2875, 676, 0, ""),
				}),
				new("Keg", typeof(Keg), 3711, "", new DecorationEntry[]
				{
					new(2736, 989, 20, ""),
					new(2736, 990, 20, ""),
					new(2748, 976, 20, ""),
					new(2750, 976, 20, ""),
					new(2736, 988, 20, ""),
					new(2749, 976, 20, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(2921, 859, 6, ""),
					new(2768, 963, 6, ""),
					new(2896, 789, 6, ""),
					new(2992, 813, 6, ""),
					new(3016, 763, 6, ""),
					new(2953, 707, 6, ""),
					new(2910, 706, 6, ""),
					new(2960, 624, 6, ""),
					new(2968, 882, 6, ""),
					new(3011, 779, 6, ""),
					new(2860, 998, 6, ""),
					new(2912, 668, 6, ""),
					new(2912, 801, 6, ""),
				}),
				new("Pickaxe", typeof(Static), 3717, "", new DecorationEntry[]
				{
					new(2985, 642, 3, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(2857, 740, 5, ""),
				}),
				new("Pitchfork", typeof(Static), 3719, "", new DecorationEntry[]
				{
					new(2984, 644, 4, ""),
				}),
				new("Drum", typeof(Static), 3740, "", new DecorationEntry[]
				{
					new(2885, 740, 4, ""),
				}),
				new("Tambourine", typeof(Static), 3741, "", new DecorationEntry[]
				{
					new(2889, 740, 4, ""),
				}),
				new("Tambourine", typeof(Static), 3742, "", new DecorationEntry[]
				{
					new(2887, 740, 4, ""),
				}),
				new("Standing Harp", typeof(Static), 3761, "", new DecorationEntry[]
				{
					new(2880, 736, 0, ""),
					new(2919, 983, 0, ""),
				}),
				new("Lap Harp", typeof(Static), 3762, "", new DecorationEntry[]
				{
					new(2887, 738, 4, ""),
					new(2889, 738, 4, ""),
				}),
				new("Lute", typeof(Static), 3763, "", new DecorationEntry[]
				{
					new(2885, 738, 4, ""),
					new(2883, 740, 4, ""),
				}),
				new("Music Stand", typeof(Static), 3766, "", new DecorationEntry[]
				{
					new(2896, 736, 0, ""),
					new(2895, 736, 0, ""),
					new(2894, 736, 0, ""),
				}),
				new("Music Stand", typeof(Static), 3771, "", new DecorationEntry[]
				{
					new(2898, 736, 0, ""),
					new(2899, 736, 0, ""),
					new(2900, 736, 0, ""),
				}),
				new("Cleaver", typeof(Static), 3778, "", new DecorationEntry[]
				{
					new(2987, 780, 6, ""),
				}),
				new("Dress Form", typeof(Static), 3782, "", new DecorationEntry[]
				{
					new(2841, 880, 0, ""),
					new(2959, 622, 0, ""),
				}),
				new("Dress Form", typeof(Static), 3783, "", new DecorationEntry[]
				{
					new(2960, 617, 0, ""),
				}),
				new("Easel With Canvas", typeof(Static), 3942, "", new DecorationEntry[]
				{
					new(2899, 708, 0, ""),
				}),
				new("Easel With Canvas", typeof(Static), 3944, "", new DecorationEntry[]
				{
					new(2905, 715, 0, ""),
					new(2905, 712, 0, ""),
					new(2905, 709, 0, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(2839, 883, 6, ""),
				}),
				new("Scissors", typeof(Scissors), 3999, "", new DecorationEntry[]
				{
					new(2952, 620, 6, ""),
				}),
				new("Spool Of Thread", typeof(Static), 4001, "", new DecorationEntry[]
				{
					new(2839, 882, 6, ""),
				}),
				new("Playing Cards", typeof(Static), 4003, "", new DecorationEntry[]
				{
					new(2904, 905, 4, ""),
				}),
				new("Checkers", typeof(Static), 4004, "", new DecorationEntry[]
				{
					new(2895, 908, 2, ""),
				}),
				new("Checkers", typeof(Static), 4005, "", new DecorationEntry[]
				{
					new(2897, 908, 4, ""),
				}),
				new("Game Board", typeof(CheckerBoard), 4006, "", new DecorationEntry[]
				{
					new(2896, 908, 2, ""),
				}),
				new("Chess Board", typeof(Chessboard), 4006, "", new DecorationEntry[]
				{
					new(2894, 903, 4, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(2903, 915, 4, ""),
				}),
				new("Backgammon Game", typeof(Backgammon), 4013, "", new DecorationEntry[]
				{
					new(2903, 916, 4, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(2995, 760, 0, ""),
					new(3010, 838, -3, ""),
					new(3046, 816, -3, ""),
					new(3012, 792, 0, ""),
					new(3015, 820, -3, ""),
					new(3028, 818, -3, ""),
					new(3019, 797, 0, ""),
					new(3016, 781, 0, ""),
					new(3016, 780, 0, ""),
					new(3008, 795, 0, ""),
					new(3040, 825, -3, ""),
					new(3015, 792, 0, ""),
					new(3008, 797, 0, ""),
					new(3019, 795, 0, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(2869, 849, 0, ""),
					new(2845, 812, 0, ""),
					new(2845, 796, 0, ""),
					new(2869, 853, 0, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(2845, 797, 0, ""),
					new(2869, 848, 0, ""),
					new(2869, 852, 0, ""),
					new(2845, 813, 0, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4021, "", new DecorationEntry[]
				{
					new(2843, 792, 0, ""),
					new(2864, 851, 6, ""),
					new(2842, 811, 6, ""),
					new(2868, 850, 0, ""),
				}),
				new("Tongs", typeof(Static), 4027, "", new DecorationEntry[]
				{
					new(2842, 795, 6, ""),
					new(2842, 813, 6, ""),
					new(2865, 848, 0, ""),
					new(2869, 850, 0, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(2842, 794, 6, ""),
					new(2850, 735, 4, ""),
					new(2922, 668, 4, ""),
					new(2842, 866, 6, ""),
					new(2835, 912, 4, ""),
					new(2842, 812, 6, ""),
					new(2990, 778, 6, ""),
					new(2992, 642, 6, ""),
					new(2864, 850, 6, ""),
					new(2939, 939, 4, ""),
					new(2908, 709, 5, ""),
					new(2997, 762, 6, ""),
					new(2908, 712, 5, ""),
					new(2908, 715, 5, ""),
					new(2995, 835, 6, ""),
					new(2939, 931, 4, ""),
					new(2877, 722, 6, ""),
					new(2883, 747, 4, ""),
					new(2887, 676, 6, ""),
					new(2888, 652, 6, ""),
					new(2863, 810, 6, ""),
					new(2882, 739, 4, ""),
					new(2874, 683, 4, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(2914, 801, 6, ""),
					new(2955, 810, 4, ""),
					new(2955, 707, 6, ""),
					new(2855, 728, 6, ""),
					new(2970, 882, 6, ""),
					new(2914, 970, 4, ""),
					new(2898, 789, 6, ""),
					new(2739, 979, 4, ""),
					new(2908, 706, 6, ""),
					new(3018, 763, 6, ""),
					new(2859, 998, 6, ""),
					new(2994, 813, 6, ""),
					new(2883, 674, 6, ""),
					new(2766, 963, 0, ""),
					new(2919, 675, 24, ""),
					new(2922, 859, 6, ""),
					new(2858, 999, -17, ""),
					new(2962, 624, 6, ""),
					new(2963, 811, 4, ""),
					new(2770, 963, 6, ""),
					new(2857, 728, 6, ""),
					new(2843, 899, 4, ""),
					new(3013, 779, 6, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(2842, 866, 6, ""),
					new(2908, 712, 5, ""),
					new(2922, 668, 4, ""),
					new(2835, 912, 4, ""),
					new(2995, 835, 6, ""),
					new(2842, 812, 6, ""),
					new(2864, 850, 6, ""),
					new(2908, 709, 5, ""),
					new(2997, 762, 6, ""),
					new(2769, 963, 6, ""),
					new(2887, 676, 6, ""),
					new(2939, 931, 4, ""),
					new(2992, 642, 6, ""),
					new(2882, 739, 4, ""),
					new(2990, 778, 6, ""),
					new(2842, 794, 6, ""),
					new(2883, 747, 4, ""),
					new(2908, 715, 5, ""),
					new(2888, 652, 6, ""),
					new(2874, 683, 4, ""),
					new(2939, 939, 4, ""),
					new(2863, 810, 6, ""),
					new(2877, 722, 6, ""),
					new(2850, 735, 4, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(3018, 763, 6, ""),
					new(2994, 813, 6, ""),
					new(2739, 979, 4, ""),
					new(2913, 970, 4, ""),
					new(2955, 707, 6, ""),
					new(3013, 779, 6, ""),
					new(2922, 859, 6, ""),
					new(2883, 674, 6, ""),
					new(2859, 998, 6, ""),
					new(2857, 728, 6, ""),
					new(2962, 624, 6, ""),
					new(2908, 706, 6, ""),
					new(2855, 728, 6, ""),
					new(2955, 810, 4, ""),
					new(2914, 801, 6, ""),
					new(2858, 999, -17, ""),
					new(2919, 675, 24, ""),
					new(2963, 811, 4, ""),
					new(2898, 789, 6, ""),
					new(2843, 899, 4, ""),
				}),
				new("Paints And Brush", typeof(Static), 4033, "", new DecorationEntry[]
				{
					new(2905, 710, 0, ""),
					new(2905, 713, 0, ""),
					new(2905, 716, 0, ""),
				}),
				new("Book", typeof(TalkingToWisps), 4084, "", new DecorationEntry[]
				{
					new(2736, 987, 6, ""),
				}),
				new("Skull Mug", typeof(Static), 4092, "", new DecorationEntry[]
				{
					new(2903, 913, 4, ""),
				}),
				new("Skull Mug", typeof(Static), 4093, "", new DecorationEntry[]
				{
					new(2903, 915, 4, ""),
				}),
				new("Skull Mug", typeof(Static), 4094, "", new DecorationEntry[]
				{
					new(2902, 909, 2, ""),
					new(2904, 909, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4097, "", new DecorationEntry[]
				{
					new(2896, 707, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4098, "", new DecorationEntry[]
				{
					new(2897, 912, 8, ""),
					new(2899, 903, 6, ""),
					new(2893, 912, 9, ""),
					new(2894, 904, 6, ""),
				}),
				new("Spittoon", typeof(Static), 4099, "", new DecorationEntry[]
				{
					new(2904, 901, 0, ""),
					new(2893, 908, 0, ""),
					new(2899, 911, 0, ""),
					new(2905, 909, 0, ""),
				}),
				new("Wash Basin", typeof(Static), 4104, "", new DecorationEntry[]
				{
					new(2913, 850, 0, ""),
					new(2918, 854, 6, ""),
					new(2992, 764, 6, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelEastAddon), 4121, "", new DecorationEntry[]
				{
					new(2955, 620, 0, ""),
					new(2843, 884, 0, ""),
					new(2961, 629, 0, ""),
				}),
				new("Chisels", typeof(Static), 4135, "", new DecorationEntry[]
				{
					new(2912, 793, 6, ""),
				}),
				new("Dovetail Saw", typeof(Static), 4137, "", new DecorationEntry[]
				{
					new(2912, 795, 6, ""),
				}),
				new("Hammer", typeof(Static), 4138, "", new DecorationEntry[]
				{
					new(2899, 789, 6, ""),
				}),
				new("Hammer", typeof(Static), 4139, "", new DecorationEntry[]
				{
					new(2915, 794, 6, ""),
				}),
				new("Nails", typeof(Static), 4142, "", new DecorationEntry[]
				{
					new(2915, 795, 6, ""),
				}),
				new("Jointing Plane", typeof(Static), 4144, "", new DecorationEntry[]
				{
					new(2915, 801, 6, ""),
				}),
				new("Smoothing Plane", typeof(Static), 4146, "", new DecorationEntry[]
				{
					new(2913, 801, 6, ""),
				}),
				new("Saw", typeof(Static), 4148, "", new DecorationEntry[]
				{
					new(2912, 794, 6, ""),
				}),
				new("Sack Of Flour", typeof(Static), 4153, "", new DecorationEntry[]
				{
					new(2999, 760, 0, ""),
					new(2998, 761, 0, ""),
					new(2992, 765, 6, ""),
				}),
				new("Open Sack Of Flour", typeof(Static), 4154, "", new DecorationEntry[]
				{
					new(2998, 760, 0, ""),
					new(2993, 765, 0, ""),
				}),
				new("Dough", typeof(Static), 4157, "", new DecorationEntry[]
				{
					new(2992, 763, 6, ""),
				}),
				new("Rolling Pin", typeof(Static), 4163, "", new DecorationEntry[]
				{
					new(2992, 762, 6, ""),
				}),
				new("Globe", typeof(Static), 4167, "", new DecorationEntry[]
				{
					new(2964, 810, 0, ""),
				}),
				new("Loom Bench", typeof(Static), 4169, "", new DecorationEntry[]
				{
					new(2845, 884, 0, ""),
					new(2963, 629, 0, ""),
					new(2957, 620, 0, ""),
				}),
				new("Loom Bench", typeof(Static), 4170, "", new DecorationEntry[]
				{
					new(2954, 618, 0, ""),
					new(2845, 882, 0, ""),
				}),
				new("Clock Frame", typeof(Static), 4174, "", new DecorationEntry[]
				{
					new(2898, 784, 6, ""),
				}),
				new("Clock Parts", typeof(Static), 4176, "", new DecorationEntry[]
				{
					new(2900, 784, 6, ""),
				}),
				new("Axle With Gears", typeof(Static), 4177, "", new DecorationEntry[]
				{
					new(2899, 784, 6, ""),
				}),
				new("Gears", typeof(Static), 4179, "", new DecorationEntry[]
				{
					new(2899, 784, 6, ""),
				}),
				new("Hinge", typeof(Static), 4182, "", new DecorationEntry[]
				{
					new(2901, 784, 6, ""),
				}),
				new("Sextant", typeof(Static), 4183, "", new DecorationEntry[]
				{
					new(2897, 784, 6, ""),
				}),
				new("Sextant Parts", typeof(Static), 4186, "", new DecorationEntry[]
				{
					new(2901, 784, 6, ""),
				}),
				new("Axle", typeof(Static), 4188, "", new DecorationEntry[]
				{
					new(2899, 784, 6, ""),
				}),
				new("Springs", typeof(Static), 4190, "", new DecorationEntry[]
				{
					new(2897, 784, 6, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4193, "", new DecorationEntry[]
				{
					new(2844, 881, 0, ""),
					new(2953, 617, 0, ""),
				}),
				new("Training Dummy", typeof(TrainingDummy), 4208, "", new DecorationEntry[]
				{
					new(2838, 898, 0, ""),
					new(2838, 903, 0, ""),
					new(2834, 903, 0, ""),
					new(2834, 898, 0, ""),
				}),
				new("Pile Of Hides", typeof(Static), 4217, "", new DecorationEntry[]
				{
					new(2868, 1002, -21, ""),
					new(2867, 1003, -21, ""),
					new(2869, 1003, -21, ""),
					new(2868, 1003, -21, ""),
					new(2868, 1001, -21, ""),
					new(2869, 1002, -21, ""),
				}),
				new("Post", typeof(Static), 4758, "", new DecorationEntry[]
				{
					new(2909, 597, 0, ""),
				}),
				new("Sign", typeof(LocalizedSign), 4762, "LabelNumber=1016180", new DecorationEntry[]
				{
					new(2909, 597, 15, ""),
				}),
				new("Tarot", typeof(Static), 4773, "", new DecorationEntry[]
				{
					new(2917, 675, 24, ""),
					new(2915, 668, 6, ""),
				}),
				new("Statue", typeof(Static), 5018, "", new DecorationEntry[]
				{
					new(2952, 622, 0, ""),
					new(2960, 620, 0, ""),
				}),
				new("Pot Of Wax", typeof(Static), 5162, "", new DecorationEntry[]
				{
					new(2957, 705, 6, ""),
				}),
				new("Pot Of Wax", typeof(Static), 5163, "", new DecorationEntry[]
				{
					new(2957, 704, 6, ""),
				}),
				new("Candle", typeof(Static), 5171, "", new DecorationEntry[]
				{
					new(2957, 706, 6, ""),
				}),
				new("Moulding Board", typeof(Static), 5353, "", new DecorationEntry[]
				{
					new(2992, 762, 6, ""),
				}),
				new("Moulding Board", typeof(Static), 5354, "", new DecorationEntry[]
				{
					new(2997, 764, 6, ""),
				}),
				new("Map", typeof(Static), 5355, "", new DecorationEntry[]
				{
					new(2995, 808, 6, ""),
					new(2947, 928, 4, ""),
				}),
				new("Rolled Map", typeof(Static), 5357, "", new DecorationEntry[]
				{
					new(2962, 811, 4, ""),
				}),
				new("Ship Model", typeof(Static), 5363, "", new DecorationEntry[]
				{
					new(2994, 808, 6, ""),
					new(2997, 808, 6, ""),
				}),
				new("Spyglass", typeof(Static), 5366, "", new DecorationEntry[]
				{
					new(2742, 980, 26, ""),
				}),
				new("Rope", typeof(Static), 5368, "", new DecorationEntry[]
				{
					new(3015, 822, -3, ""),
					new(3015, 836, -3, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(3037, 825, -3, ""),
					new(3030, 819, -3, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(2983, 633, 0, ""),
					new(2845, 864, 0, ""),
					new(2846, 864, 0, ""),
					new(2984, 633, 0, ""),
					new(2846, 865, 5, ""),
					new(2845, 870, 0, ""),
					new(2846, 865, 0, ""),
					new(3011, 820, -3, ""),
					new(2846, 869, 0, ""),
				}),
				new("Water", typeof(Static), 6039, "", new DecorationEntry[]
				{
					new(2958, 731, -5, ""),
				}),
				new("Water", typeof(Static), 6043, "", new DecorationEntry[]
				{
					new(2964, 763, -5, ""),
				}),
				new("Water", typeof(Static), 6044, "", new DecorationEntry[]
				{
					new(2964, 764, -5, ""),
					new(2964, 762, -5, ""),
				}),
				new("Hourglass", typeof(Static), 6163, "", new DecorationEntry[]
				{
					new(2925, 669, 26, ""),
					new(2885, 648, 6, ""),
				}),
				new("Scales", typeof(Scales), 6225, "", new DecorationEntry[]
				{
					new(2883, 648, 6, ""),
					new(2925, 667, 26, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(2922, 667, 40, ""),
					new(2922, 674, 40, ""),
					new(2922, 665, 40, ""),
					new(2922, 676, 40, ""),
					new(2916, 674, 24, ""),
					new(2913, 674, 40, ""),
					new(2913, 676, 40, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6232, "", new DecorationEntry[]
				{
					new(2924, 676, 40, ""),
					new(2915, 674, 40, ""),
					new(2922, 674, 24, ""),
					new(2915, 676, 40, ""),
					new(2924, 665, 40, ""),
					new(2924, 667, 40, ""),
					new(2924, 674, 40, ""),
					new(2888, 650, 6, ""),
				}),
				new("Empty Vials", typeof(Static), 6235, "", new DecorationEntry[]
				{
					new(2884, 648, 6, ""),
				}),
				new("Full Vials", typeof(Static), 6238, "", new DecorationEntry[]
				{
					new(2888, 653, 6, ""),
				}),
				new("Ore", typeof(Static), 6584, "", new DecorationEntry[]
				{
					new(2856, 740, 3, ""),
				}),
				new("Ore", typeof(Static), 6585, "", new DecorationEntry[]
				{
					new(2851, 732, 4, ""),
				}),
				new("Ore", typeof(Static), 6586, "", new DecorationEntry[]
				{
					new(2851, 738, 4, ""),
				}),
				new("Board", typeof(Static), 7127, "", new DecorationEntry[]
				{
					new(2917, 805, 0, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(2909, 904, 0, ""),
					new(2778, 964, 0, ""),
				}),
				new("Glass Of Cider", typeof(GlassMug), 8061, "Content=Cider", new DecorationEntry[]
				{
					new(2895, 908, 2, ""),
				}),
				new("Glass Of Milk", typeof(GlassMug), 8073, "Content=Milk", new DecorationEntry[]
				{
					new(2898, 913, 6, ""),
				}),
				
				#endregion
			});
		}
	}
}
