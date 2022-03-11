using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Magincia { get; } = Register(DecorationTarget.Britannia, "Magincia", new DecorationList[]
			{
				#region Entries
				
				new("Ankh", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(3685, 2066, 9, ""),
				}),
				new("Sandstone Wall", typeof(Static), 351, "", new DecorationEntry[]
				{
					new(3735, 2144, 20, ""),
					new(3735, 2146, 20, ""),
					new(3735, 2149, 20, ""),
					new(3735, 2145, 20, ""),
					new(3735, 2151, 20, ""),
					new(3735, 2148, 20, ""),
					new(3735, 2150, 20, ""),
				}),
				new("Pier", typeof(Static), 933, "", new DecorationEntry[]
				{
					new(3686, 2270, 10, ""),
					new(3687, 2269, 5, ""),
					new(3663, 2267, 5, ""),
					new(3687, 2269, -5, ""),
					new(3687, 2269, 0, ""),
					new(3681, 2270, 10, ""),
					new(3682, 2270, 10, ""),
					new(3662, 2270, 0, ""),
					new(3680, 2270, 10, ""),
					new(3662, 2270, 10, ""),
					new(3662, 2270, 5, ""),
					new(3684, 2270, 10, ""),
					new(3685, 2270, 10, ""),
					new(3668, 2270, 15, ""),
					new(3681, 2270, -5, ""),
					new(3661, 2270, 0, ""),
					new(3683, 2270, 10, ""),
					new(3661, 2270, 15, ""),
					new(3661, 2270, 10, ""),
					new(3661, 2268, 10, ""),
					new(3661, 2268, 20, ""),
					new(3661, 2268, 15, ""),
					new(3661, 2268, -5, ""),
					new(3661, 2270, 20, ""),
					new(3662, 2270, -5, ""),
					new(3661, 2270, -5, ""),
					new(3663, 2266, 0, ""),
					new(3661, 2267, 20, ""),
					new(3687, 2269, 10, ""),
					new(3663, 2266, -5, ""),
					new(3687, 2268, 5, ""),
					new(3687, 2268, -5, ""),
					new(3687, 2268, 0, ""),
					new(3661, 2267, 0, ""),
					new(3661, 2267, 5, ""),
					new(3661, 2267, -5, ""),
					new(3661, 2270, 5, ""),
					new(3661, 2266, 5, ""),
					new(3686, 2270, 5, ""),
					new(3661, 2266, -5, ""),
					new(3680, 2270, -5, ""),
					new(3661, 2266, 0, ""),
					new(3661, 2266, 20, ""),
					new(3687, 2268, 10, ""),
					new(3666, 2270, 15, ""),
					new(3665, 2270, 15, ""),
					new(3667, 2270, 15, ""),
					new(3668, 2270, 5, ""),
					new(3668, 2270, 10, ""),
					new(3661, 2265, 10, ""),
					new(3661, 2269, -5, ""),
					new(3668, 2270, 0, ""),
					new(3661, 2269, 0, ""),
					new(3668, 2270, -5, ""),
					new(3661, 2269, 5, ""),
					new(3661, 2265, 5, ""),
					new(3664, 2270, 0, ""),
					new(3661, 2265, 0, ""),
					new(3661, 2269, 10, ""),
					new(3661, 2265, -5, ""),
					new(3682, 2270, 5, ""),
					new(3683, 2270, 5, ""),
					new(3681, 2270, 5, ""),
					new(3686, 2270, 0, ""),
					new(3680, 2270, 5, ""),
					new(3685, 2270, 5, ""),
					new(3662, 2270, 15, ""),
					new(3662, 2270, 20, ""),
					new(3664, 2270, 15, ""),
					new(3684, 2270, 5, ""),
					new(3685, 2270, 0, ""),
					new(3664, 2270, 10, ""),
					new(3685, 2270, -5, ""),
					new(3684, 2270, -5, ""),
					new(3682, 2270, -5, ""),
					new(3683, 2270, -5, ""),
					new(3683, 2270, 0, ""),
					new(3684, 2270, 0, ""),
					new(3681, 2270, 0, ""),
					new(3686, 2270, -5, ""),
					new(3680, 2270, 0, ""),
					new(3663, 2267, 0, ""),
					new(3665, 2270, 0, ""),
					new(3665, 2270, 5, ""),
					new(3665, 2270, 10, ""),
					new(3663, 2269, -5, ""),
					new(3679, 2270, 5, ""),
					new(3663, 2266, 5, ""),
					new(3664, 2270, 5, ""),
					new(3666, 2270, 0, ""),
					new(3667, 2270, 10, ""),
					new(3663, 2269, 0, ""),
					new(3663, 2269, 5, ""),
					new(3667, 2270, 5, ""),
					new(3666, 2270, 10, ""),
					new(3667, 2270, -5, ""),
					new(3667, 2270, 0, ""),
					new(3661, 2266, 10, ""),
					new(3663, 2267, -5, ""),
					new(3661, 2266, 15, ""),
					new(3665, 2270, -5, ""),
					new(3682, 2270, 0, ""),
					new(3666, 2270, 5, ""),
					new(3666, 2270, -5, ""),
					new(3679, 2270, -5, ""),
					new(3661, 2267, 15, ""),
					new(3679, 2270, 0, ""),
					new(3661, 2268, 5, ""),
					new(3661, 2267, 10, ""),
					new(3661, 2265, 20, ""),
					new(3661, 2265, 15, ""),
					new(3664, 2270, -5, ""),
					new(3679, 2270, 10, ""),
					new(3661, 2269, 20, ""),
					new(3661, 2269, 15, ""),
					new(3663, 2268, -5, ""),
					new(3663, 2268, 5, ""),
					new(3663, 2268, 0, ""),
					new(3661, 2268, 0, ""),
				}),
				new("Pier", typeof(Static), 942, "", new DecorationEntry[]
				{
					new(3680, 2270, -5, ""),
					new(3679, 2270, -5, ""),
					new(3687, 2269, -5, ""),
					new(3686, 2270, -5, ""),
					new(3685, 2270, -5, ""),
					new(3684, 2270, -5, ""),
					new(3687, 2268, -5, ""),
					new(3681, 2270, -5, ""),
					new(3682, 2270, -5, ""),
					new(3683, 2270, -5, ""),
				}),
				new("Pier", typeof(Static), 943, "", new DecorationEntry[]
				{
					new(3661, 2269, -5, ""),
					new(3666, 2270, -5, ""),
					new(3667, 2270, -5, ""),
					new(3665, 2270, -5, ""),
					new(3664, 2270, -5, ""),
					new(3662, 2270, -5, ""),
					new(3661, 2270, -5, ""),
					new(3668, 2270, -5, ""),
				}),
				new("Carpeted Rostrum", typeof(Static), 1978, "", new DecorationEntry[]
				{
					new(3689, 2067, 3, ""),
					new(3689, 2068, 3, ""),
					new(3685, 2065, 3, ""),
					new(3687, 2067, 3, ""),
					new(3685, 2070, 3, ""),
					new(3690, 2068, 3, ""),
					new(3689, 2070, 3, ""),
					new(3686, 2066, 3, ""),
					new(3687, 2066, 3, ""),
					new(3689, 2064, 3, ""),
					new(3690, 2069, 3, ""),
					new(3687, 2069, 3, ""),
					new(3687, 2068, 3, ""),
					new(3688, 2069, 3, ""),
					new(3686, 2070, 3, ""),
					new(3688, 2067, 3, ""),
					new(3688, 2068, 3, ""),
					new(3690, 2066, 3, ""),
					new(3688, 2064, 3, ""),
					new(3685, 2066, 3, ""),
					new(3686, 2065, 3, ""),
					new(3690, 2067, 3, ""),
					new(3686, 2064, 3, ""),
					new(3687, 2064, 3, ""),
					new(3686, 2067, 3, ""),
					new(3690, 2065, 3, ""),
					new(3688, 2066, 3, ""),
					new(3685, 2064, 3, ""),
					new(3687, 2065, 3, ""),
					new(3685, 2068, 3, ""),
					new(3688, 2065, 3, ""),
					new(3687, 2070, 3, ""),
					new(3689, 2069, 3, ""),
					new(3685, 2069, 3, ""),
					new(3686, 2069, 3, ""),
					new(3686, 2068, 3, ""),
					new(3689, 2065, 3, ""),
					new(3685, 2067, 3, ""),
					new(3688, 2070, 3, ""),
					new(3689, 2066, 3, ""),
				}),
				new("Carpeted Stair", typeof(Static), 1980, "", new DecorationEntry[]
				{
					new(3691, 2068, 3, ""),
					new(3691, 2066, 3, ""),
					new(3691, 2067, 3, ""),
				}),
				new("Carpeted Stair", typeof(Static), 1991, "", new DecorationEntry[]
				{
					new(3691, 2069, 3, ""),
				}),
				new("Carpeted Stair", typeof(Static), 1992, "", new DecorationEntry[]
				{
					new(3691, 2065, 3, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(3751, 2217, 20, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(3754, 2215, 20, ""),
				}),
				new("Wheel Of Cheese", typeof(CheeseWheel), 2430, "", new DecorationEntry[]
				{
					new(3684, 2168, 24, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(3661, 2116, 24, ""),
				}),
				new("Fruit Basket", typeof(FruitBasket), 2451, "", new DecorationEntry[]
				{
					new(3676, 2100, 24, ""),
					new(3683, 2204, 32, ""),
					new(3719, 2084, 9, ""),
					new(3772, 2107, 44, ""),
					new(3691, 2164, 24, ""),
					new(3770, 2106, 24, ""),
				}),
				new("Pear", typeof(Pear), 2452, "", new DecorationEntry[]
				{
					new(3661, 2116, 27, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(3729, 2218, 24, ""),
				}),
				new("Mug", typeof(CeramicMug), 2456, "", new DecorationEntry[]
				{
					new(3722, 2225, 24, ""),
				}),
				new("Goblet", typeof(Goblet), 2458, "", new DecorationEntry[]
				{
					new(3722, 2217, 24, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(3728, 2228, 29, ""),
					new(3727, 2228, 29, ""),
					new(3730, 2218, 24, ""),
				}),
				new("Bottle Of Ale", typeof(BeverageBottle), 2463, "Content=Ale", new DecorationEntry[]
				{
					new(3722, 2216, 24, ""),
					new(3728, 2228, 26, ""),
					new(3727, 2228, 26, ""),
					new(3729, 2228, 24, ""),
					new(3722, 2224, 24, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(3737, 2147, 20, ""),
					new(3739, 2146, 20, ""),
					new(3741, 2145, 20, ""),
				}),
				new("Bushel", typeof(Basket), 2476, "", new DecorationEntry[]
				{
					new(3684, 2269, 20, ""),
					new(3686, 2268, 20, ""),
				}),
				new("Goblet", typeof(Goblet), 2483, "", new DecorationEntry[]
				{
					new(3718, 2084, 9, ""),
					new(3718, 2083, 9, ""),
					new(3726, 2218, 24, ""),
					new(3721, 2084, 9, ""),
				}),
				new("Roast Pig", typeof(RoastPig), 2491, "", new DecorationEntry[]
				{
					new(3720, 2083, 9, ""),
				}),
				new("Roast Pig", typeof(RoastPig), 2492, "", new DecorationEntry[]
				{
					new(3722, 2221, 24, ""),
					new(3660, 2117, 24, ""),
					new(3690, 2165, 24, ""),
				}),
				new("Silverware", typeof(Static), 2493, "", new DecorationEntry[]
				{
					new(3682, 2203, 24, ""),
				}),
				new("Silverware", typeof(Static), 2494, "", new DecorationEntry[]
				{
					new(3682, 2202, 24, ""),
					new(3683, 2202, 24, ""),
				}),
				new("Bottle Of Wine", typeof(BeverageBottle), 2503, "Content=Wine", new DecorationEntry[]
				{
					new(3725, 2218, 24, ""),
				}),
				new("Goblet", typeof(Goblet), 2507, "", new DecorationEntry[]
				{
					new(3770, 2107, 24, ""),
					new(3770, 2108, 24, ""),
					new(3683, 2204, 24, ""),
					new(3683, 2203, 24, ""),
					new(3682, 2204, 24, ""),
					new(3682, 2203, 24, ""),
				}),
				new("Fish", typeof(Static), 2508, "", new DecorationEntry[]
				{
					new(3685, 2257, 24, ""),
					new(3685, 2256, 24, ""),
					new(3685, 2255, 24, ""),
					new(3685, 2258, 24, ""),
				}),
				new("Fish", typeof(Static), 2509, "", new DecorationEntry[]
				{
					new(3685, 2255, 24, ""),
					new(3685, 2257, 24, ""),
					new(3685, 2258, 24, ""),
					new(3685, 2256, 24, ""),
				}),
				new("Apple", typeof(Apple), 2512, "", new DecorationEntry[]
				{
					new(3661, 2116, 27, ""),
				}),
				new("Grape Bunch", typeof(Grapes), 2513, "", new DecorationEntry[]
				{
					new(3661, 2116, 24, ""),
				}),
				new("Peach", typeof(Peach), 2514, "", new DecorationEntry[]
				{
					new(3661, 2116, 25, ""),
				}),
				new("Silverware", typeof(Static), 2516, "", new DecorationEntry[]
				{
					new(3682, 2204, 24, ""),
					new(3720, 2084, 9, ""),
					new(3683, 2204, 24, ""),
				}),
				new("Silverware", typeof(Static), 2517, "", new DecorationEntry[]
				{
					new(3722, 2084, 9, ""),
					new(3683, 2203, 24, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(3682, 2202, 24, ""),
					new(3720, 2084, 9, ""),
					new(3682, 2204, 24, ""),
					new(3683, 2204, 24, ""),
					new(3683, 2203, 24, ""),
					new(3683, 2202, 24, ""),
					new(3722, 2084, 9, ""),
					new(3682, 2203, 24, ""),
				}),
				new("Cake", typeof(Cake), 2537, "", new DecorationEntry[]
				{
					new(3759, 2216, 24, ""),
					new(3757, 2227, 24, ""),
					new(3683, 2168, 24, ""),
					new(3757, 2225, 24, ""),
					new(3757, 2226, 24, ""),
				}),
				new("Muffins", typeof(Muffins), 2539, "", new DecorationEntry[]
				{
					new(3682, 2168, 24, ""),
					new(3757, 2216, 26, ""),
					new(3752, 2222, 24, ""),
					new(3752, 2223, 24, ""),
					new(3758, 2216, 24, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2542, "Content=Ale", new DecorationEntry[]
				{
					new(3722, 2222, 24, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2543, "Content=Ale", new DecorationEntry[]
				{
					new(3722, 2218, 24, ""),
					new(3731, 2221, 24, ""),
				}),
				new("Milk", typeof(Pitcher), 2544, "Content=Milk", new DecorationEntry[]
				{
					new(3722, 2228, 24, ""),
					new(3683, 2203, 29, ""),
					new(3691, 2166, 24, ""),
					new(3770, 2107, 24, ""),
				}),
				new("Candle", typeof(Candle), 2575, "", new DecorationEntry[]
				{
					new(3680, 2153, 33, ""),
					new(3707, 2225, 40, ""),
					new(3707, 2228, 40, ""),
					new(3704, 2228, 40, ""),
				}),
				new("Stool", typeof(Stool), 2603, "", new DecorationEntry[]
				{
					new(3684, 2170, 20, ""),
					new(3682, 2170, 20, ""),
					new(3682, 2172, 20, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2608, "", new DecorationEntry[]
				{
					new(3661, 2096, 20, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(3680, 2157, 20, ""),
					new(3680, 2153, 20, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(3700, 2152, 20, ""),
					new(3690, 2152, 20, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(3656, 2096, 20, ""),
					new(3689, 2185, 20, ""),
					new(3680, 2185, 20, ""),
					new(3680, 2189, 20, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(3768, 2111, 40, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(3696, 2056, 5, ""),
					new(3702, 2208, 40, ""),
					new(3699, 2240, 20, ""),
					new(3759, 2120, 20, ""),
					new(3702, 2240, 20, ""),
					new(3773, 2104, 40, ""),
					new(3666, 2248, 20, ""),
					new(3707, 2208, 40, ""),
					new(3705, 2208, 40, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(3669, 2248, 20, ""),
					new(3771, 2104, 40, ""),
					new(3758, 2120, 20, ""),
					new(3695, 2056, 5, ""),
					new(3704, 2208, 40, ""),
					new(3698, 2056, 5, ""),
					new(3700, 2240, 20, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(3696, 2247, 20, ""),
					new(3691, 2076, 5, ""),
					new(3691, 2077, 5, ""),
					new(3664, 2250, 20, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(3691, 2075, 5, ""),
					new(3696, 2246, 20, ""),
					new(3664, 2251, 20, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(3701, 2208, 40, ""),
					new(3697, 2056, 5, ""),
					new(3703, 2208, 40, ""),
					new(3701, 2240, 20, ""),
					new(3706, 2208, 40, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(3696, 2245, 20, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "", new DecorationEntry[]
				{
					new(3716, 2120, 20, ""),
					new(3722, 2120, 20, ""),
					new(3721, 2120, 20, ""),
					new(3717, 2120, 20, ""),
					new(3721, 2080, 5, ""),
					new(3720, 2080, 5, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "", new DecorationEntry[]
				{
					new(3712, 2130, 20, ""),
					new(3680, 2250, 20, ""),
					new(3680, 2249, 20, ""),
					new(3715, 2084, 5, ""),
					new(3712, 2124, 20, ""),
					new(3712, 2129, 20, ""),
					new(3715, 2085, 5, ""),
					new(3712, 2125, 20, ""),
					new(3664, 2257, 20, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(3699, 2072, 9, ""),
					new(3656, 2099, 28, ""),
					new(3768, 2112, 48, ""),
					new(3699, 2061, 11, ""),
					new(3767, 2111, 60, ""),
					new(3686, 2152, 28, ""),
					new(3696, 2152, 28, ""),
					new(3715, 2090, 13, ""),
					new(3681, 2184, 28, ""),
					new(3691, 2184, 28, ""),
					new(3690, 2248, 28, ""),
					new(3664, 2253, 26, ""),
					new(3680, 2258, 28, ""),
					new(3772, 2108, 44, ""),
				}),
				new("Candelabra", typeof(Candelabra), 2845, "", new DecorationEntry[]
				{
					new(3705, 2211, 48, ""),
					new(3760, 2115, 24, ""),
					new(3656, 2141, 26, ""),
					new(3656, 2137, 26, ""),
					new(3691, 2165, 31, ""),
					new(3760, 2118, 24, ""),
				}),
				new("Lamp Post", typeof(LampPost3), 2852, "", new DecorationEntry[]
				{
					new(3711, 2184, 20, ""),
					new(3719, 2232, 20, ""),
					new(3719, 2208, 20, ""),
					new(3744, 2112, 20, ""),
					new(3679, 2215, 30, ""),
					new(3679, 2261, 21, ""),
					new(3679, 2137, 20, ""),
					new(3711, 2160, 20, ""),
					new(3679, 2112, 20, ""),
					new(3711, 2072, 5, ""),
					new(3679, 2208, 30, ""),
					new(3735, 2167, 20, ""),
					new(3727, 2055, 5, ""),
					new(3686, 2215, 30, ""),
					new(3727, 2072, 5, ""),
					new(3743, 2215, 20, ""),
					new(3734, 2087, 5, ""),
					new(3736, 2252, 20, ""),
					new(3727, 2112, 20, ""),
					new(3742, 2076, 5, ""),
					new(3743, 2232, 20, ""),
					new(3696, 2176, 20, ""),
					new(3736, 2191, 20, ""),
					new(3695, 2232, 20, ""),
					new(3672, 2240, 20, ""),
					new(3704, 2136, 20, ""),
					new(3704, 2048, 5, ""),
					new(3737, 2076, 5, ""),
					new(3704, 2112, 20, ""),
					new(3704, 2097, 5, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(3779, 2264, 20, ""),
					new(3656, 2176, 20, ""),
					new(3678, 2096, 20, ""),
					new(3691, 2071, 5, ""),
					new(3696, 2240, 20, ""),
					new(3787, 2251, 20, ""),
					new(3684, 2064, 5, ""),
					new(3736, 2067, 5, ""),
					new(3656, 2118, 20, ""),
					new(3770, 2104, 20, ""),
					new(3696, 2160, 20, ""),
					new(3680, 2251, 20, ""),
					new(3670, 2112, 20, ""),
					new(3800, 2240, 20, ""),
					new(3680, 2168, 20, ""),
					new(3663, 2192, 20, ""),
					new(3752, 2120, 20, ""),
					new(3686, 2254, 20, ""),
					new(3710, 2251, 20, ""),
					new(3799, 2264, 20, ""),
					new(3670, 2250, 20, ""),
					new(3691, 2056, 5, ""),
					new(3787, 2240, 20, ""),
					new(3704, 2240, 20, ""),
					new(3684, 2070, 5, ""),
					new(3670, 2118, 20, ""),
					new(3670, 2176, 20, ""),
					new(3701, 2165, 20, ""),
					new(3702, 2056, 5, ""),
					new(3670, 2229, 20, ""),
					new(3656, 2111, 20, ""),
					new(3664, 2248, 20, ""),
					new(3784, 2245, 20, ""),
					new(3766, 2096, 20, ""),
					new(3766, 2126, 20, ""),
					new(3779, 2254, 20, ""),
					new(3664, 2096, 20, ""),
					new(3806, 2240, 20, ""),
					new(3779, 2270, 20, ""),
					new(3678, 2110, 20, ""),
					new(3694, 2170, 20, ""),
					new(3736, 2062, 5, ""),
					new(3767, 2118, 20, ""),
					new(3691, 2078, 5, ""),
					new(3656, 2198, 20, ""),
					new(3656, 2190, 20, ""),
					new(3691, 2063, 5, ""),
					new(3661, 2232, 20, ""),
					new(3662, 2104, 20, ""),
					new(3701, 2160, 20, ""),
					new(3688, 2160, 20, ""),
					new(3666, 2238, 20, ""),
					new(3800, 2263, 20, ""),
					new(3664, 2102, 20, ""),
					new(3796, 2270, 20, ""),
					new(3742, 2067, 5, ""),
					new(3742, 2062, 5, ""),
					new(3670, 2198, 20, ""),
					new(3703, 2250, 20, ""),
					new(3670, 2259, 20, ""),
					new(3760, 2104, 20, ""),
					new(3672, 2110, 20, ""),
					new(3663, 2182, 20, ""),
					new(3702, 2078, 5, ""),
					new(3806, 2259, 20, ""),
					new(3710, 2240, 20, ""),
				}),
				new("Throne", typeof(Throne), 2867, "", new DecorationEntry[]
				{
					new(3786, 2248, 20, ""),
					new(3786, 2247, 20, ""),
					new(3786, 2246, 20, ""),
					new(3786, 2249, 20, ""),
					new(3786, 2243, 20, ""),
					new(3786, 2242, 20, ""),
					new(3786, 2250, 20, ""),
					new(3786, 2245, 20, ""),
					new(3786, 2244, 20, ""),
				}),
				new("Counter", typeof(Static), 2878, "", new DecorationEntry[]
				{
					new(3730, 2147, 20, ""),
					new(3731, 2147, 20, ""),
					new(3729, 2147, 20, ""),
				}),
				new("Counter", typeof(Static), 2880, "", new DecorationEntry[]
				{
					new(3728, 2147, 20, ""),
					new(3732, 2147, 20, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2894, "", new DecorationEntry[]
				{
					new(3696, 2248, 20, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2895, "", new DecorationEntry[]
				{
					new(3773, 2104, 20, ""),
					new(3705, 2240, 20, ""),
					new(3698, 2240, 20, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(3754, 2125, 20, ""),
					new(3756, 2125, 20, ""),
					new(3705, 2250, 20, ""),
					new(3708, 2250, 20, ""),
					new(3769, 2117, 20, ""),
					new(3698, 2253, 20, ""),
					new(3700, 2253, 20, ""),
					new(3772, 2117, 20, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2897, "", new DecorationEntry[]
				{
					new(3709, 2246, 20, ""),
					new(3682, 2254, 20, ""),
					new(3765, 2123, 20, ""),
					new(3709, 2248, 20, ""),
					new(3666, 2253, 20, ""),
					new(3666, 2255, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(3688, 2193, 20, ""),
					new(3688, 2197, 20, ""),
					new(3681, 2202, 20, ""),
					new(3681, 2204, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(3683, 2201, 20, ""),
					new(3690, 2184, 20, ""),
					new(3686, 2184, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "", new DecorationEntry[]
				{
					new(3683, 2205, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(3685, 2204, 20, ""),
					new(3685, 2202, 20, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(3659, 2117, 20, ""),
					new(3701, 2211, 40, ""),
					new(3689, 2164, 20, ""),
					new(3698, 2073, 5, ""),
					new(3659, 2116, 20, ""),
					new(3717, 2084, 5, ""),
					new(3689, 2166, 20, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(3694, 2056, 5, ""),
					new(3705, 2210, 40, ""),
					new(3701, 2152, 20, ""),
					new(3707, 2210, 40, ""),
					new(3703, 2210, 40, ""),
					new(3691, 2152, 20, ""),
					new(3691, 2162, 20, ""),
					new(3698, 2060, 5, ""),
					new(3699, 2056, 5, ""),
					new(3676, 2098, 20, ""),
					new(3721, 2082, 5, ""),
					new(3697, 2060, 5, ""),
					new(3719, 2082, 5, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(3692, 2166, 20, ""),
					new(3662, 2116, 20, ""),
					new(3692, 2164, 20, ""),
					new(3723, 2084, 5, ""),
					new(3662, 2117, 20, ""),
					new(3773, 2108, 40, ""),
					new(3773, 2106, 40, ""),
					new(3700, 2073, 5, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(3698, 2062, 5, ""),
					new(3697, 2062, 5, ""),
					new(3676, 2101, 20, ""),
					new(3707, 2212, 40, ""),
					new(3721, 2085, 5, ""),
					new(3691, 2167, 20, ""),
					new(3705, 2212, 40, ""),
					new(3703, 2212, 40, ""),
					new(3719, 2085, 5, ""),
				}),
				new("Bench", typeof(Static), 2914, "", new DecorationEntry[]
				{
					new(3680, 2212, 20, ""),
				}),
				new("Bench", typeof(Static), 2915, "", new DecorationEntry[]
				{
					new(3680, 2210, 20, ""),
				}),
				new("Bench", typeof(Static), 2916, "", new DecorationEntry[]
				{
					new(3680, 2211, 20, ""),
				}),
				new("Table", typeof(Static), 2923, "", new DecorationEntry[]
				{
					new(3688, 2068, 8, ""),
				}),
				new("Table", typeof(Static), 2924, "", new DecorationEntry[]
				{
					new(3688, 2066, 8, ""),
				}),
				new("Table", typeof(Static), 2925, "", new DecorationEntry[]
				{
					new(3688, 2067, 8, ""),
				}),
				new("Metal Signpost", typeof(Static), 2973, "", new DecorationEntry[]
				{
					new(3673, 2184, 30, ""),
				}),
				new("Metal Signpost", typeof(Static), 2978, "", new DecorationEntry[]
				{
					new(3728, 2160, 20, ""),
				}),
				new("Flowers", typeof(Static), 3127, "", new DecorationEntry[]
				{
					new(3689, 2065, 10, ""),
				}),
				new("Flowers", typeof(Static), 3128, "", new DecorationEntry[]
				{
					new(3689, 2068, 10, ""),
				}),
				new("Flowers", typeof(Static), 3144, "", new DecorationEntry[]
				{
					new(3685, 2064, 10, ""),
					new(3691, 2066, 5, ""),
					new(3685, 2069, 10, ""),
				}),
				new("Flowers", typeof(Static), 3146, "", new DecorationEntry[]
				{
					new(3686, 2068, 10, ""),
					new(3685, 2068, 10, ""),
					new(3685, 2065, 10, ""),
					new(3686, 2064, 9, ""),
					new(3691, 2067, 7, ""),
					new(3686, 2070, 10, ""),
				}),
				new("Flowers", typeof(Static), 3148, "", new DecorationEntry[]
				{
					new(3692, 2067, 5, ""),
					new(3686, 2066, 9, ""),
					new(3685, 2070, 10, ""),
				}),
				new("Flowers", typeof(Static), 3149, "", new DecorationEntry[]
				{
					new(3686, 2069, 10, ""),
					new(3692, 2066, 5, ""),
					new(3686, 2065, 8, ""),
					new(3686, 2067, 10, ""),
				}),
				new("Bulrushes", typeof(Static), 3220, "", new DecorationEntry[]
				{
					new(3682, 2196, 20, ""),
					new(3685, 2195, 20, ""),
				}),
				new("Coconut Palm", typeof(Static), 3221, "", new DecorationEntry[]
				{
					new(3683, 2196, 20, ""),
				}),
				new("Date Palm", typeof(Static), 3222, "", new DecorationEntry[]
				{
					new(3684, 2195, 20, ""),
				}),
				new("Fern", typeof(Static), 3231, "", new DecorationEntry[]
				{
					new(3684, 2196, 20, ""),
				}),
				new("Fern", typeof(Static), 3232, "", new DecorationEntry[]
				{
					new(3683, 2195, 20, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "", new DecorationEntry[]
				{
					new(3684, 2197, 20, ""),
				}),
				new("Fern", typeof(Static), 3236, "", new DecorationEntry[]
				{
					new(3685, 2197, 20, ""),
					new(3685, 2194, 20, ""),
				}),
				new("Fishing Pole", typeof(Static), 3519, "", new DecorationEntry[]
				{
					new(3685, 2270, 21, ""),
					new(3667, 2299, -2, ""),
				}),
				new("Fishing Pole", typeof(Static), 3520, "", new DecorationEntry[]
				{
					new(3682, 2268, 21, ""),
					new(3667, 2269, 21, ""),
				}),
				new("Bloody Bandage", typeof(Static), 3616, "", new DecorationEntry[]
				{
					new(3683, 2224, 24, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(3684, 2224, 24, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "Light=Circle150", new DecorationEntry[]
				{
					new(3696, 2227, 24, ""),
					new(3704, 2224, 24, ""),
				}),
				new("Brazier", typeof(Brazier), 3633, "", new DecorationEntry[]
				{
					new(3696, 2224, 20, ""),
					new(3696, 2220, 20, ""),
					new(3704, 2221, 20, ""),
					new(3704, 2217, 20, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(3741, 2147, 20, ""),
					new(3741, 2146, 20, ""),
					new(3737, 2145, 20, ""),
					new(3737, 2144, 20, ""),
					new(3739, 2145, 20, ""),
					new(3741, 2144, 20, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3650, "ContentType=Mage", new DecorationEntry[]
				{
					new(3696, 2228, 40, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(3739, 2147, 20, ""),
					new(3737, 2146, 20, ""),
					new(3739, 2144, 20, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(3680, 2256, 20, ""),
				}),
				new("Water Tub", typeof(Static), 3707, "", new DecorationEntry[]
				{
					new(3722, 2080, 5, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(3715, 2086, 5, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(3656, 2138, 24, ""),
				}),
				new("Clean Bandage", typeof(Static), 3817, "", new DecorationEntry[]
				{
					new(3686, 2224, 24, ""),
					new(3690, 2208, 24, ""),
					new(3687, 2224, 24, ""),
					new(3683, 2224, 24, ""),
					new(3692, 2208, 24, ""),
					new(3689, 2208, 24, ""),
					new(3691, 2208, 24, ""),
					new(3693, 2208, 24, ""),
				}),
				new("Blank Scroll", typeof(Static), 3827, "", new DecorationEntry[]
				{
					new(3705, 2224, 24, ""),
				}),
				new("Scroll", typeof(Static), 3828, "", new DecorationEntry[]
				{
					new(3696, 2223, 24, ""),
				}),
				new("Scroll", typeof(Static), 3829, "", new DecorationEntry[]
				{
					new(3696, 2221, 24, ""),
				}),
				new("Scroll", typeof(Static), 3830, "", new DecorationEntry[]
				{
					new(3706, 2224, 24, ""),
				}),
				new("Scroll", typeof(Static), 3831, "", new DecorationEntry[]
				{
					new(3707, 2224, 24, ""),
				}),
				new("Scroll", typeof(Static), 3832, "", new DecorationEntry[]
				{
					new(3708, 2224, 24, ""),
				}),
				new("Scroll", typeof(Static), 3833, "", new DecorationEntry[]
				{
					new(3709, 2224, 24, ""),
				}),
				new("Spellbook", typeof(Static), 3834, "", new DecorationEntry[]
				{
					new(3696, 2219, 24, ""),
					new(3696, 2217, 24, ""),
					new(3696, 2218, 24, ""),
					new(3706, 2211, 44, ""),
				}),
				new("Bottle", typeof(Static), 3837, "", new DecorationEntry[]
				{
					new(3696, 2227, 26, ""),
				}),
				new("Bottle", typeof(Static), 3839, "", new DecorationEntry[]
				{
					new(3696, 2222, 25, ""),
				}),
				new("Bottle", typeof(Static), 3841, "", new DecorationEntry[]
				{
					new(3709, 2224, 24, ""),
				}),
				new("Bottle", typeof(Static), 3842, "", new DecorationEntry[]
				{
					new(3708, 2224, 22, ""),
				}),
				new("Bottle", typeof(Static), 3844, "", new DecorationEntry[]
				{
					new(3696, 2226, 29, ""),
				}),
				new("Orange Potion", typeof(Static), 3847, "", new DecorationEntry[]
				{
					new(3705, 2224, 30, ""),
					new(3696, 2222, 24, ""),
				}),
				new("Green Potion", typeof(Static), 3850, "", new DecorationEntry[]
				{
					new(3696, 2226, 24, ""),
				}),
				new("Red Potion", typeof(Static), 3851, "", new DecorationEntry[]
				{
					new(3696, 2225, 28, ""),
					new(3705, 2224, 22, ""),
				}),
				new("Yellow Potion", typeof(Static), 3852, "", new DecorationEntry[]
				{
					new(3696, 2225, 24, ""),
				}),
				new("Star Sapphire", typeof(Static), 3855, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
					new(3664, 2133, 24, ""),
				}),
				new("Emerald", typeof(Static), 3856, "", new DecorationEntry[]
				{
					new(3664, 2131, 24, ""),
				}),
				new("Sapphire", typeof(Static), 3857, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
				}),
				new("Ruby", typeof(Static), 3860, "", new DecorationEntry[]
				{
					new(3664, 2131, 24, ""),
				}),
				new("Amethyst", typeof(Static), 3862, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
				}),
				new("Star Sapphire", typeof(Static), 3867, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Ruby", typeof(Static), 3868, "", new DecorationEntry[]
				{
					new(3664, 2145, 24, ""),
					new(3664, 2132, 24, ""),
					new(3664, 2147, 24, ""),
				}),
				new("Ruby", typeof(Static), 3869, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
					new(3664, 2146, 24, ""),
					new(3664, 2148, 24, ""),
				}),
				new("Sapphire", typeof(Static), 3871, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
				}),
				new("Tourmaline", typeof(Static), 3872, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
					new(3664, 2134, 24, ""),
					new(3664, 2145, 24, ""),
				}),
				new("Amethyst", typeof(Static), 3874, "", new DecorationEntry[]
				{
					new(3664, 2148, 24, ""),
					new(3664, 2146, 24, ""),
				}),
				new("Citrine", typeof(Static), 3875, "", new DecorationEntry[]
				{
					new(3664, 2146, 24, ""),
					new(3664, 2132, 24, ""),
					new(3664, 2148, 24, ""),
				}),
				new("Citrine", typeof(Static), 3876, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
				}),
				new("Piece Of Amber", typeof(Static), 3877, "", new DecorationEntry[]
				{
					new(3664, 2133, 24, ""),
				}),
				new("Diamond", typeof(Static), 3879, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
					new(3664, 2134, 24, ""),
				}),
				new("Diamond", typeof(Static), 3880, "", new DecorationEntry[]
				{
					new(3664, 2145, 24, ""),
					new(3664, 2132, 24, ""),
					new(3664, 2147, 24, ""),
				}),
				new("Diamond", typeof(Static), 3881, "", new DecorationEntry[]
				{
					new(3665, 2146, 27, ""),
					new(3665, 2148, 27, ""),
				}),
				new("Ruby", typeof(Static), 3882, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
				}),
				new("Ruby", typeof(Static), 3883, "", new DecorationEntry[]
				{
					new(3664, 2133, 24, ""),
				}),
				new("Citrine", typeof(Static), 3884, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Amethyst", typeof(Static), 3886, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Emerald", typeof(Static), 3887, "", new DecorationEntry[]
				{
					new(3664, 2146, 24, ""),
					new(3664, 2148, 24, ""),
				}),
				new("Diamond", typeof(Static), 3888, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Sewing Kit", typeof(Static), 3997, "", new DecorationEntry[]
				{
					new(3666, 2237, 22, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(3665, 2237, 24, ""),
					new(3667, 2237, 22, ""),
				}),
				new("Spool Of Thread", typeof(Static), 4000, "Hue=0x1E6", new DecorationEntry[]
				{
					new(3668, 2237, 24, ""),
				}),
				new("Playing Cards", typeof(Static), 4002, "", new DecorationEntry[]
				{
					new(3722, 2226, 24, ""),
				}),
				new("Playing Cards", typeof(Static), 4003, "", new DecorationEntry[]
				{
					new(3722, 2217, 24, ""),
				}),
				new("Checkers", typeof(Static), 4004, "", new DecorationEntry[]
				{
					new(3730, 2221, 24, ""),
					new(3697, 2061, 9, ""),
				}),
				new("Checkers", typeof(Static), 4005, "", new DecorationEntry[]
				{
					new(3730, 2221, 24, ""),
					new(3697, 2061, 9, ""),
				}),
				new("Game Board", typeof(CheckerBoard), 4006, "", new DecorationEntry[]
				{
					new(3697, 2061, 9, ""),
					new(3730, 2221, 24, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(3722, 2229, 24, ""),
				}),
				new("Chess Pieces", typeof(Static), 4008, "", new DecorationEntry[]
				{
					new(3726, 2218, 24, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(3669, 2236, 24, ""),
					new(3670, 2236, 20, ""),
					new(3664, 2255, 24, ""),
					new(3699, 2210, 24, ""),
					new(3656, 2194, 24, ""),
					new(3752, 2221, 24, ""),
					new(3781, 2251, 24, ""),
					new(3680, 2254, 24, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(3730, 2228, 24, ""),
					new(3685, 2224, 24, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(3787, 2244, 24, ""),
					new(3787, 2248, 24, ""),
					new(3787, 2242, 24, ""),
					new(3787, 2243, 24, ""),
					new(3787, 2241, 24, ""),
					new(3787, 2249, 24, ""),
					new(3752, 2220, 24, ""),
					new(3699, 2209, 24, ""),
					new(3669, 2235, 24, ""),
					new(3787, 2246, 24, ""),
					new(3787, 2245, 24, ""),
					new(3664, 2254, 27, ""),
					new(3787, 2247, 24, ""),
					new(3656, 2193, 24, ""),
					new(3680, 2253, 24, ""),
					new(3781, 2250, 24, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(3685, 2224, 24, ""),
					new(3729, 2228, 24, ""),
				}),
				new("Book", typeof(MajorTradeAssociation), 4079, "", new DecorationEntry[]
				{
					new(3704, 2211, 44, ""),
				}),
				new("Book", typeof(RedBook), 4081, "", new DecorationEntry[]
				{
					new(3705, 2211, 44, ""),
				}),
				new("Book", typeof(BlueBook), 4082, "", new DecorationEntry[]
				{
					new(3702, 2211, 44, ""),
				}),
				new("Book", typeof(TamingDragons), 4084, "", new DecorationEntry[]
				{
					new(3664, 2254, 24, ""),
				}),
				new("Book", typeof(DeceitDungeonOfHorror), 4084, "", new DecorationEntry[]
				{
					new(3703, 2211, 44, ""),
				}),
				new("Book", typeof(BoldStranger), 4084, "", new DecorationEntry[]
				{
					new(3664, 2252, 24, ""),
				}),
				new("Glass Pitcher", typeof(Pitcher), 4086, "", new DecorationEntry[]
				{
					new(3722, 2228, 24, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4095, "", new DecorationEntry[]
				{
					new(3727, 2218, 24, ""),
				}),
				new("Spittoon", typeof(Static), 4099, "", new DecorationEntry[]
				{
					new(3720, 2216, 20, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(3661, 2229, 20, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelEastAddon), 4121, "", new DecorationEntry[]
				{
					new(3662, 2231, 20, ""),
				}),
				new("Pile Of Wool", typeof(Static), 4127, "Hue=0x1E6", new DecorationEntry[]
				{
					new(3663, 2228, 20, ""),
				}),
				new("Bread Loaf", typeof(BreadLoaf), 4156, "", new DecorationEntry[]
				{
					new(3756, 2216, 24, ""),
					new(3681, 2168, 24, ""),
					new(3757, 2216, 24, ""),
				}),
				new("Dough", typeof(Dough), 4157, "", new DecorationEntry[]
				{
					new(3761, 2216, 24, ""),
					new(3680, 2170, 24, ""),
				}),
				new("Cookie Mix", typeof(CookieMix), 4159, "", new DecorationEntry[]
				{
					new(3762, 2216, 24, ""),
				}),
				new("Pizza", typeof(Static), 4160, "", new DecorationEntry[]
				{
					new(3752, 2226, 24, ""),
					new(3680, 2173, 24, ""),
					new(3721, 2083, 9, ""),
					new(3752, 2227, 24, ""),
					new(3752, 2228, 24, ""),
				}),
				new("Baked Pie", typeof(Static), 4161, "", new DecorationEntry[]
				{
					new(3680, 2171, 24, ""),
					new(3752, 2227, 24, ""),
					new(3680, 2169, 24, ""),
					new(3752, 2225, 24, ""),
				}),
				new("Unbaked Pie", typeof(Static), 4162, "", new DecorationEntry[]
				{
					new(3680, 2172, 24, ""),
					new(3721, 2083, 9, ""),
					new(3752, 2226, 24, ""),
				}),
				new("Rolling Pin", typeof(Static), 4163, "", new DecorationEntry[]
				{
					new(3763, 2216, 24, ""),
				}),
				new("Globe", typeof(Static), 4167, "", new DecorationEntry[]
				{
					new(3664, 2256, 20, ""),
				}),
				new("Clock", typeof(Clock), 4171, "", new DecorationEntry[]
				{
					new(3720, 2123, 24, ""),
					new(3722, 2131, 24, ""),
				}),
				new("Clock", typeof(Clock), 4172, "", new DecorationEntry[]
				{
					new(3714, 2125, 24, ""),
					new(3719, 2120, 29, ""),
				}),
				new("Clock Frame", typeof(ClockFrame), 4173, "", new DecorationEntry[]
				{
					new(3719, 2131, 24, ""),
					new(3718, 2123, 24, ""),
				}),
				new("Clock Frame", typeof(ClockFrame), 4174, "", new DecorationEntry[]
				{
					new(3725, 2128, 24, ""),
					new(3714, 2130, 24, ""),
					new(3714, 2127, 24, ""),
				}),
				new("Clock Parts", typeof(ClockParts), 4175, "", new DecorationEntry[]
				{
					new(3725, 2128, 24, ""),
				}),
				new("Clock Parts", typeof(ClockParts), 4176, "", new DecorationEntry[]
				{
					new(3718, 2123, 24, ""),
					new(3722, 2131, 24, ""),
					new(3714, 2126, 24, ""),
					new(3723, 2131, 24, ""),
				}),
				new("Axle With Gears", typeof(AxleGears), 4177, "", new DecorationEntry[]
				{
					new(3725, 2127, 24, ""),
					new(3714, 2126, 24, ""),
				}),
				new("Axle With Gears", typeof(AxleGears), 4178, "", new DecorationEntry[]
				{
					new(3722, 2123, 24, ""),
					new(3723, 2131, 24, ""),
					new(3719, 2123, 24, ""),
					new(3724, 2131, 24, ""),
				}),
				new("Gears", typeof(Gears), 4179, "", new DecorationEntry[]
				{
					new(3724, 2131, 24, ""),
					new(3723, 2131, 24, ""),
				}),
				new("Gears", typeof(Gears), 4180, "", new DecorationEntry[]
				{
					new(3725, 2126, 24, ""),
				}),
				new("Hinge", typeof(Hinge), 4181, "", new DecorationEntry[]
				{
					new(3718, 2131, 24, ""),
					new(3719, 2131, 24, ""),
				}),
				new("Sextant", typeof(Static), 4183, "", new DecorationEntry[]
				{
					new(3722, 2123, 24, ""),
					new(3719, 2131, 24, ""),
				}),
				new("Sextant Parts", typeof(SextantParts), 4185, "", new DecorationEntry[]
				{
					new(3723, 2123, 24, ""),
				}),
				new("Sextant Parts", typeof(SextantParts), 4186, "", new DecorationEntry[]
				{
					new(3720, 2131, 24, ""),
				}),
				new("Axle", typeof(Axle), 4188, "", new DecorationEntry[]
				{
					new(3714, 2129, 24, ""),
					new(3714, 2130, 24, ""),
				}),
				new("Springs", typeof(Springs), 4189, "", new DecorationEntry[]
				{
					new(3719, 2131, 24, ""),
					new(3718, 2131, 24, ""),
				}),
				new("Springs", typeof(Springs), 4190, "", new DecorationEntry[]
				{
					new(3714, 2130, 24, ""),
					new(3714, 2129, 24, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(3662, 2237, 20, ""),
					new(3662, 2234, 20, ""),
				}),
				new("Magical Sparkles", typeof(Static), 4436, "", new DecorationEntry[]
				{
					new(3690, 2066, 8, ""),
					new(3690, 2067, 8, ""),
					new(3690, 2068, 8, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(3680, 2214, 20, ""),
					new(3690, 2064, 5, ""),
					new(3708, 2222, 40, ""),
					new(3680, 2208, 20, ""),
					new(3708, 2216, 40, ""),
					new(3690, 2070, 5, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(3704, 2216, 40, ""),
					new(3772, 2104, 20, ""),
					new(3704, 2221, 40, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(3760, 2110, 20, ""),
					new(3760, 2113, 20, ""),
				}),
				new("Curtain", typeof(Static), 4827, "Hue=0x5F", new DecorationEntry[]
				{
					new(3684, 2069, 7, ""),
					new(3684, 2065, 7, ""),
				}),
				new("Curtain Sash", typeof(Static), 4834, "Hue=0x5F", new DecorationEntry[]
				{
					new(3684, 2068, 7, ""),
				}),
				new("Rope", typeof(Static), 5368, "", new DecorationEntry[]
				{
					new(3663, 2269, 20, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(3678, 2298, -3, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(3663, 2290, -2, ""),
					new(3664, 2261, 21, ""),
					new(3664, 2291, -2, ""),
					new(3670, 2282, -2, ""),
					new(3672, 2261, 21, ""),
					new(3678, 2288, -2, ""),
					new(3664, 2290, -2, ""),
					new(3665, 2261, 21, ""),
				}),
				new("Coconut", typeof(Coconut), 5926, "", new DecorationEntry[]
				{
					new(3681, 2198, 20, ""),
					new(3684, 2196, 20, ""),
					new(3681, 2196, 20, ""),
					new(3682, 2197, 20, ""),
				}),
				new("Bunch Of Dates", typeof(Dates), 5927, "", new DecorationEntry[]
				{
					new(3686, 2196, 20, ""),
					new(3684, 2195, 20, ""),
					new(3682, 2196, 20, ""),
					new(3682, 2193, 20, ""),
					new(3686, 2194, 20, ""),
				}),
				new("Rock", typeof(Static), 6008, "", new DecorationEntry[]
				{
					new(3743, 2069, 5, ""),
					new(3761, 2275, 15, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(3690, 2065, 8, ""),
					new(3690, 2069, 8, ""),
				}),
				new("Book Of Truth", typeof(Static), 7187, "", new DecorationEntry[]
				{
					new(3688, 2067, 14, ""),
				}),
				new("Candle Of Love", typeof(Static), 7188, "Light=Circle150", new DecorationEntry[]
				{
					new(3688, 2066, 12, ""),
					new(3688, 2068, 12, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(3728, 2216, 20, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7775, "", new DecorationEntry[]
				{
					new(3688, 2161, 20, ""),
				}),
				new("Sparkle", typeof(Static), 14170, "", new DecorationEntry[]
				{
					new(3691, 2062, 5, ""),
					new(3691, 2072, 5, ""),
				}),
				
				#endregion
			});
		}
	}
}
