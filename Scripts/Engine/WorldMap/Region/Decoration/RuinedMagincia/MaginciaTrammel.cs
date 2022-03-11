using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class RuinedMagincia
		{
			public static DecorationList[] Trammel { get; } = Register(DecorationTarget.MaginciaTrammel, "Trammel Magincia", new DecorationList[]
			{
				#region Entries
				
				new("Wooden Chair", typeof(WoodenThrone), 2863, "", new DecorationEntry[]
				{
					new(3670, 2281, -2, ""),
				}),
				new("Mushrooms", typeof(Static), 3341, "Hue=0x497", new DecorationEntry[]
				{
					new(3574, 2168, 14, ""),
				}),
				new("Hatch", typeof(Static), 16046, "", new DecorationEntry[]
				{
					new(3680, 2277, -5, ""),
				}),
				new("Silverware", typeof(Static), 2493, "", new DecorationEntry[]
				{
					new(3682, 2203, 24, ""),
				}),
				new("Mushrooms", typeof(Static), 3340, "Hue=0x497", new DecorationEntry[]
				{
					new(3735, 2189, 20, ""),
				}),
				new("Jars", typeof(Static), 3663, "", new DecorationEntry[]
				{
					new(3666, 2261, 20, ""),
				}),
				new("Bench", typeof(Static), 2914, "", new DecorationEntry[]
				{
					new(3680, 2212, 20, ""),
				}),
				new("Bench", typeof(Static), 2916, "", new DecorationEntry[]
				{
					new(3680, 2211, 20, ""),
				}),
				new("Bench", typeof(Static), 2915, "", new DecorationEntry[]
				{
					new(3680, 2210, 20, ""),
				}),
				new("Grasses", typeof(Static), 3259, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3646, 2227, 20, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(3737, 2147, 20, ""),
					new(3739, 2146, 20, ""),
					new(3741, 2145, 20, ""),
				}),
				new("Plaster Wall", typeof(Static), 330, "", new DecorationEntry[]
				{
					new(3746, 2084, 18, ""),
					new(3735, 2082, 5, ""),
				}),
				new("Wooden Pole", typeof(Static), 499, "", new DecorationEntry[]
				{
					new(3737, 2083, 5, ""),
				}),
				new("Metal Signpost", typeof(Static), 2973, "", new DecorationEntry[]
				{
					new(3673, 2184, 30, ""),
				}),
				new("Blade Plant", typeof(Static), 3219, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3636, 2221, 23, ""),
					new(3704, 2121, 20, ""),
				}),
				new("Roast Pig%S%", typeof(Static), 2491, "", new DecorationEntry[]
				{
					new(3720, 2083, 9, ""),
				}),
				new("Sandstone Wall", typeof(Static), 361, "", new DecorationEntry[]
				{
					new(3751, 2054, 20, ""),
				}),
				new("Sandstone Column", typeof(Static), 404, "", new DecorationEntry[]
				{
					new(3740, 2050, 5, ""),
				}),
				new("Sandstone Wall", typeof(Static), 345, "", new DecorationEntry[]
				{
					new(3701, 2233, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3319, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3649, 2068, 20, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7775, "", new DecorationEntry[]
				{
					new(3688, 2161, 20, ""),
				}),
				new("Pitcher Of Liquor", typeof(Static), 8089, "", new DecorationEntry[]
				{
					new(3691, 2166, 24, ""),
				}),
				new("Fern", typeof(Static), 3231, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3661, 2222, 20, ""),
					new(3628, 2195, 20, ""),
				}),
				new("Grasses", typeof(Static), 3253, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3696, 2107, 20, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1711, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(3695, 2250, 20, ""),
				}),
				new("Sapling", typeof(Static), 3305, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3561, 2141, 27, ""),
					new(3630, 2196, 20, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(3667, 2237, 22, ""),
					new(3665, 2237, 24, ""),
				}),
				new("Sandstone Wall", typeof(Static), 358, "", new DecorationEntry[]
				{
					new(3782, 2106, 20, ""),
				}),
				new("Muffins", typeof(Static), 2539, "", new DecorationEntry[]
				{
					new(3682, 2168, 24, ""),
					new(3758, 2216, 24, ""),
					new(3757, 2216, 26, ""),
					new(3752, 2223, 24, ""),
					new(3752, 2222, 24, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(3737, 2146, 20, ""),
					new(3739, 2144, 20, ""),
					new(3739, 2147, 20, ""),
				}),
				new("Blade Plant", typeof(Static), 3219, "Hue=0x497", new DecorationEntry[]
				{
					new(3783, 2093, 26, ""),
				}),
				new("Wooden Bench", typeof(WoodenBench), 2860, "", new DecorationEntry[]
				{
					new(3688, 2189, 20, ""),
					new(3688, 2198, 20, ""),
					new(3779, 2101, 20, ""),
				}),
				new("Ship", typeof(Static), 16005, "", new DecorationEntry[]
				{
					new(3800, 2158, -5, ""),
				}),
				new("Wooden Post", typeof(Static), 169, "", new DecorationEntry[]
				{
					new(3623, 2207, -15, ""),
				}),
				new("Bench", typeof(Static), 2917, "", new DecorationEntry[]
				{
					new(3718, 2217, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3319, "Hue=0x497", new DecorationEntry[]
				{
					new(3625, 2204, 16, ""),
					new(3805, 2129, 20, ""),
				}),
				new("MissingName", typeof(Static), 4116, "", new DecorationEntry[]
				{
					new(3663, 2229, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3317, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3768, 2205, 20, ""),
					new(3809, 2132, 14, ""),
				}),
				new("Small Fish", typeof(Static), 3544, "", new DecorationEntry[]
				{
					new(3683, 2268, 21, ""),
				}),
				new("Upright Loom", typeof(Static), 4191, "", new DecorationEntry[]
				{
					new(3662, 2238, 20, ""),
					new(3662, 2235, 20, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(3662, 2237, 20, ""),
					new(3662, 2234, 20, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelEastAddon), 4121, "", new DecorationEntry[]
				{
					new(3662, 2231, 20, ""),
				}),
				new("Jeweler", typeof(LocalizedSign), 3009, "", new DecorationEntry[]
				{
					new(3673, 2184, 30, ""),
				}),
				new("Fallen Log", typeof(Static), 3317, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3800, 2129, 21, ""),
				}),
				new("Candelabra", typeof(Static), 2846, "", new DecorationEntry[]
				{
					new(3656, 2137, 26, ""),
				}),
				new("Book", typeof(Static), 4079, "", new DecorationEntry[]
				{
					new(3704, 2211, 44, ""),
				}),
				new("Amethyst%S%", typeof(Static), 3862, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
				}),
				new("Fan Plant", typeof(Static), 3224, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3803, 2143, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3226, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3677, 2026, -15, ""),
				}),
				new("Candle", typeof(Static), 2844, "", new DecorationEntry[]
				{
					new(3680, 2258, 28, ""),
					new(3772, 2108, 44, ""),
				}),
				new("Fallen Log", typeof(Static), 3315, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3774, 2133, 24, ""),
				}),
				new("Grasses", typeof(Static), 3379, "Hue=0x497", new DecorationEntry[]
				{
					new(3736, 2122, 20, ""),
				}),
				new("Mug Of Ale", typeof(GlassMug), 2542, "", new DecorationEntry[]
				{
					new(3722, 2222, 24, ""),
				}),
				new("Grasses", typeof(Static), 3244, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3750, 2142, 24, ""),
				}),
				new("Pampas Grass", typeof(Static), 3237, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3710, 2121, 20, ""),
					new(3647, 2078, 20, ""),
				}),
				new("Morning Glories", typeof(Static), 3380, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3650, 2100, 20, ""),
				}),
				new("Water Tub", typeof(Static), 3707, "", new DecorationEntry[]
				{
					new(3722, 2080, 5, ""),
				}),
				new("Pile%S% Of Wool", typeof(Static), 4127, "", new DecorationEntry[]
				{
					new(3663, 2228, 20, ""),
				}),
				new("Grasses", typeof(Static), 3259, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3637, 2220, 20, ""),
				}),
				new("Tile Roof", typeof(Static), 1472, "", new DecorationEntry[]
				{
					new(3744, 2152, 40, ""),
					new(3744, 2151, 20, ""),
					new(3744, 2150, 46, ""),
					new(3744, 2149, 49, ""),
				}),
				new("Tile Roof", typeof(Static), 1471, "", new DecorationEntry[]
				{
					new(3744, 2148, 52, ""),
				}),
				new("Peach%Es%", typeof(Static), 2514, "", new DecorationEntry[]
				{
					new(3661, 2116, 25, ""),
				}),
				new("Emerald%S%", typeof(Static), 3887, "", new DecorationEntry[]
				{
					new(3664, 2146, 24, ""),
					new(3664, 2148, 24, ""),
				}),
				new("Fallen Log", typeof(Static), 3317, "Hue=0x497", new DecorationEntry[]
				{
					new(3627, 2208, 20, ""),
					new(3647, 2065, 20, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(3737, 2145, 20, ""),
					new(3739, 2145, 20, ""),
					new(3741, 2147, 20, ""),
					new(3741, 2144, 20, ""),
					new(3741, 2146, 20, ""),
					new(3737, 2144, 20, ""),
				}),
				new("Rub%Ies/Y%", typeof(Static), 3882, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
				}),
				new("Sapphire%S%", typeof(Static), 3871, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
				}),
				new("Fish", typeof(Static), 2508, "", new DecorationEntry[]
				{
					new(3685, 2257, 24, ""),
					new(3685, 2255, 24, ""),
					new(3685, 2258, 24, ""),
					new(3685, 2256, 24, ""),
				}),
				new("Fish", typeof(Static), 2509, "", new DecorationEntry[]
				{
					new(3685, 2258, 24, ""),
					new(3685, 2257, 24, ""),
					new(3685, 2256, 24, ""),
					new(3685, 2255, 24, ""),
				}),
				new("Apple%S%", typeof(Static), 2512, "", new DecorationEntry[]
				{
					new(3661, 2116, 27, ""),
				}),
				new("Amethyst%S%", typeof(Static), 3874, "", new DecorationEntry[]
				{
					new(3664, 2148, 24, ""),
					new(3664, 2146, 24, ""),
				}),
				new("Grape Bunch%Es%", typeof(Static), 2513, "", new DecorationEntry[]
				{
					new(3661, 2116, 24, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(3690, 2152, 20, ""),
					new(3700, 2152, 20, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4338, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3549, 2154, 21, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2716, "", new DecorationEntry[]
				{
					new(3696, 2245, 20, ""),
				}),
				new("Dirt Patch", typeof(Static), 2321, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3618, 2145, 79, ""),
					new(3546, 2148, 20, ""),
				}),
				new("Rock", typeof(Static), 4965, "Hue=0x15E", new DecorationEntry[]
				{
					new(3672, 2164, 20, ""),
					new(3680, 2154, 20, ""),
				}),
				new("Candle", typeof(CandleLarge), 2598, "", new DecorationEntry[]
				{
					new(3699, 2061, 11, ""),
				}),
				new("Bottle", typeof(Static), 3844, "", new DecorationEntry[]
				{
					new(3696, 2226, 29, ""),
				}),
				new("Palisade", typeof(Static), 1060, "", new DecorationEntry[]
				{
					new(3653, 2224, 20, ""),
					new(3663, 2210, 20, ""),
				}),
				new("Boulder", typeof(Static), 4961, "Hue=0x15E", new DecorationEntry[]
				{
					new(3672, 2172, 20, ""),
					new(3664, 2166, 20, ""),
				}),
				new("Rock", typeof(Static), 4963, "Hue=0x15F", new DecorationEntry[]
				{
					new(3679, 2161, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3346, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3770, 2105, 20, ""),
				}),
				new("Cake", typeof(Static), 2537, "", new DecorationEntry[]
				{
					new(3759, 2216, 24, ""),
					new(3757, 2227, 24, ""),
					new(3757, 2226, 24, ""),
					new(3757, 2225, 24, ""),
					new(3683, 2168, 24, ""),
				}),
				new("Wooden Ladder", typeof(Static), 2208, "", new DecorationEntry[]
				{
					new(3672, 2117, 31, ""),
				}),
				new("Wooden Ladder", typeof(Static), 2209, "", new DecorationEntry[]
				{
					new(3673, 2117, 20, ""),
				}),
				new("Stone Wall", typeof(Static), 962, "", new DecorationEntry[]
				{
					new(3666, 2119, 20, ""),
				}),
				new("Wooden Wall", typeof(Static), 551, "", new DecorationEntry[]
				{
					new(3669, 2203, 20, ""),
					new(3650, 2193, 20, ""),
					new(3677, 2203, 20, ""),
					new(3661, 2203, 20, ""),
					new(3671, 2206, 20, ""),
				}),
				new("Rope Ladder", typeof(Static), 2214, "", new DecorationEntry[]
				{
					new(3667, 2213, 20, ""),
					new(3667, 2205, 20, ""),
					new(3667, 2221, 20, ""),
				}),
				new("Wooden Plank", typeof(Static), 1993, "", new DecorationEntry[]
				{
					new(3664, 2211, 20, ""),
					new(3642, 2214, 20, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(3696, 2228, 40, ""),
				}),
				new("Shell", typeof(Static), 4040, "", new DecorationEntry[]
				{
					new(3713, 2029, 4, ""),
				}),
				new("Blue Moongate", typeof(Static), 3948, "Hue=0x484", new DecorationEntry[]
				{
					new(3563, 2139, 34, ""),
				}),
				new("Clock Parts", typeof(Static), 4175, "", new DecorationEntry[]
				{
					new(3725, 2128, 24, ""),
				}),
				new("Sextant Parts", typeof(Static), 4186, "", new DecorationEntry[]
				{
					new(3720, 2131, 24, ""),
				}),
				new("Hinge%S%", typeof(Static), 4181, "", new DecorationEntry[]
				{
					new(3719, 2131, 24, ""),
					new(3718, 2131, 24, ""),
				}),
				new("Green Potion", typeof(Static), 3850, "", new DecorationEntry[]
				{
					new(3696, 2226, 24, ""),
				}),
				new("Tiller Man", typeof(Static), 15952, "", new DecorationEntry[]
				{
					new(3804, 2156, -5, ""),
				}),
				new("Bottle Of Wine", typeof(Static), 2503, "", new DecorationEntry[]
				{
					new(3725, 2218, 24, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(3768, 2112, 48, ""),
					new(3767, 2111, 60, ""),
					new(3699, 2072, 9, ""),
					new(3686, 2152, 28, ""),
					new(3656, 2099, 28, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2608, "", new DecorationEntry[]
				{
					new(3661, 2096, 20, ""),
				}),
				new("Sandstone Post", typeof(Static), 353, "", new DecorationEntry[]
				{
					new(3692, 2048, 5, ""),
				}),
				new("Anchor", typeof(Static), 5367, "", new DecorationEntry[]
				{
					new(3678, 2291, -3, ""),
				}),
				new("Fallen Log", typeof(Static), 3319, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3690, 2101, 20, ""),
				}),
				new("Spellbook", typeof(Static), 3834, "", new DecorationEntry[]
				{
					new(3696, 2217, 24, ""),
					new(3696, 2218, 24, ""),
					new(3696, 2219, 24, ""),
					new(3706, 2211, 44, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4338, "Hue=0x497", new DecorationEntry[]
				{
					new(3534, 2142, 20, ""),
				}),
				new("Bottle Of Liquor", typeof(Static), 2459, "", new DecorationEntry[]
				{
					new(3728, 2228, 29, ""),
					new(3730, 2218, 24, ""),
					new(3727, 2228, 29, ""),
				}),
				new("Bottle Of Ale", typeof(Static), 2463, "", new DecorationEntry[]
				{
					new(3729, 2228, 24, ""),
					new(3728, 2228, 26, ""),
					new(3727, 2228, 26, ""),
					new(3722, 2224, 24, ""),
					new(3722, 2216, 24, ""),
				}),
				new("Fallen Log", typeof(Static), 3318, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3694, 2090, 6, ""),
					new(3685, 2101, 20, ""),
				}),
				new("Bed", typeof(Static), 2651, "", new DecorationEntry[]
				{
					new(3676, 2235, 20, ""),
				}),
				new("Tavern", typeof(LocalizedSign), 3011, "", new DecorationEntry[]
				{
					new(3736, 2230, 20, ""),
				}),
				new("Brass Sign", typeof(LocalizedSign), 3026, "", new DecorationEntry[]
				{
					new(3778, 2256, 20, ""),
					new(3728, 2160, 20, ""),
					new(3720, 2184, 20, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(3678, 2288, -2, ""),
					new(3672, 2261, 21, ""),
					new(3670, 2282, -2, ""),
					new(3665, 2261, 21, ""),
					new(3664, 2291, -2, ""),
					new(3664, 2290, -2, ""),
					new(3664, 2261, 21, ""),
					new(3663, 2290, -2, ""),
					new(3680, 2256, 20, ""),
				}),
				new("Hanging Lantern", typeof(HangingLantern), 2586, "", new DecorationEntry[]
				{
					new(3696, 2155, 20, ""),
				}),
				new("Window", typeof(Static), 354, "", new DecorationEntry[]
				{
					new(3738, 2172, 20, ""),
				}),
				new("Mage", typeof(LocalizedSign), 2989, "", new DecorationEntry[]
				{
					new(3712, 2215, 20, ""),
				}),
				new("Tinker", typeof(LocalizedSign), 2984, "", new DecorationEntry[]
				{
					new(3712, 2136, 20, ""),
				}),
				new("Inn", typeof(LocalizedSign), 2995, "", new DecorationEntry[]
				{
					new(3704, 2167, 20, ""),
				}),
				new("Bottle", typeof(Static), 3839, "", new DecorationEntry[]
				{
					new(3696, 2222, 25, ""),
				}),
				new("Metal Signpost", typeof(Static), 2976, "", new DecorationEntry[]
				{
					new(3778, 2256, 20, ""),
				}),
				new("Grasses", typeof(Static), 3253, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3779, 2143, 20, ""),
				}),
				new("Dirt Patch", typeof(Static), 2322, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3709, 2224, 20, ""),
					new(3527, 2144, 11, ""),
				}),
				new("Sapling", typeof(Static), 3305, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3751, 2059, 24, ""),
					new(3625, 2196, 13, ""),
					new(3808, 2129, 20, ""),
				}),
				new("Healer", typeof(LocalizedSign), 2988, "", new DecorationEntry[]
				{
					new(3685, 2231, 20, ""),
				}),
				new("Candle", typeof(Static), 2577, "", new DecorationEntry[]
				{
					new(3707, 2225, 40, ""),
				}),
				new("Seaweed", typeof(Static), 3515, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3675, 2291, -2, ""),
				}),
				new("Water", typeof(Static), 6043, "", new DecorationEntry[]
				{
					new(3574, 2171, -5, ""),
				}),
				new("Miners' Guild", typeof(LocalizedSign), 3053, "", new DecorationEntry[]
				{
					new(3673, 2138, 24, ""),
				}),
				new("Log Post", typeof(Static), 147, "", new DecorationEntry[]
				{
					new(3675, 2270, 0, ""),
					new(3675, 2270, -15, ""),
				}),
				new("Tailor", typeof(LocalizedSign), 2981, "", new DecorationEntry[]
				{
					new(3672, 2232, 20, ""),
				}),
				new("Seaweed", typeof(Static), 3514, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3674, 2290, -2, ""),
				}),
				new("Shipwright", typeof(LocalizedSign), 2998, "", new DecorationEntry[]
				{
					new(3669, 2261, 20, ""),
				}),
				new("Sparkle", typeof(Static), 14186, "", new DecorationEntry[]
				{
					new(3675, 2257, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6149, "Hue=0x45B", new DecorationEntry[]
				{
					new(3674, 2256, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6151, "Hue=0x45B", new DecorationEntry[]
				{
					new(3675, 2256, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6154, "Hue=0x45B", new DecorationEntry[]
				{
					new(3676, 2256, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6150, "Hue=0x45B", new DecorationEntry[]
				{
					new(3674, 2257, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6153, "Hue=0x45B", new DecorationEntry[]
				{
					new(3675, 2257, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6156, "Hue=0x45B", new DecorationEntry[]
				{
					new(3676, 2257, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6152, "Hue=0x45B", new DecorationEntry[]
				{
					new(3674, 2258, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6155, "Hue=0x45B", new DecorationEntry[]
				{
					new(3675, 2258, 20, ""),
				}),
				new("Pear%S%", typeof(Static), 2452, "", new DecorationEntry[]
				{
					new(3661, 2116, 27, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(3670, 2280, 1, ""),
				}),
				new("Table", typeof(Static), 2934, "", new DecorationEntry[]
				{
					new(3666, 2146, 20, ""),
					new(3728, 2109, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3227, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3634, 2220, 20, ""),
					new(3656, 2073, 20, ""),
					new(3751, 2136, 23, ""),
				}),
				new("Rolling Pin", typeof(Static), 4163, "", new DecorationEntry[]
				{
					new(3763, 2216, 24, ""),
				}),
				new("Cannon", typeof(Static), 3732, "", new DecorationEntry[]
				{
					new(3697, 2257, 20, ""),
				}),
				new("Dirt Patch", typeof(Static), 2323, "", new DecorationEntry[]
				{
					new(3659, 2121, 20, ""),
					new(3666, 2120, 20, ""),
				}),
				new("Cookie Mix", typeof(Static), 4159, "", new DecorationEntry[]
				{
					new(3762, 2216, 24, ""),
				}),
				new("Dough", typeof(Static), 4157, "", new DecorationEntry[]
				{
					new(3680, 2170, 24, ""),
					new(3761, 2216, 24, ""),
				}),
				new("Bench", typeof(Static), 2911, "", new DecorationEntry[]
				{
					new(3727, 2130, 20, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(3697, 2055, 25, ""),
					new(3697, 2056, 5, ""),
					new(3703, 2208, 40, ""),
					new(3701, 2240, 20, ""),
					new(3701, 2208, 40, ""),
					new(3706, 2208, 40, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(3760, 2113, 20, ""),
					new(3760, 2110, 20, ""),
				}),
				new("Bench", typeof(Static), 2913, "", new DecorationEntry[]
				{
					new(3716, 2204, 20, ""),
					new(3725, 2218, 20, ""),
					new(3729, 2122, 20, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(3754, 2215, 20, ""),
				}),
				new("Oven", typeof(Static), 2353, "", new DecorationEntry[]
				{
					new(3753, 2215, 20, ""),
					new(3753, 2215, 20, ""),
				}),
				new("Palisade", typeof(Static), 1073, "", new DecorationEntry[]
				{
					new(3654, 2221, 20, ""),
				}),
				new("Spool%S% Of Thread", typeof(Static), 4000, "", new DecorationEntry[]
				{
					new(3668, 2237, 24, ""),
				}),
				new("Small Fish", typeof(Static), 3543, "", new DecorationEntry[]
				{
					new(3685, 2266, 20, ""),
					new(3670, 2297, -3, ""),
				}),
				new("Seaweed", typeof(Static), 3514, "Hue=0x497", new DecorationEntry[]
				{
					new(3670, 2294, -2, ""),
				}),
				new("Gears", typeof(Static), 4179, "", new DecorationEntry[]
				{
					new(3723, 2131, 24, ""),
					new(3724, 2131, 24, ""),
				}),
				new("Ponytail Palm", typeof(Static), 3238, "Hue=0x497", new DecorationEntry[]
				{
					new(3778, 2078, 22, ""),
				}),
				new("Oven", typeof(Static), 2347, "", new DecorationEntry[]
				{
					new(3751, 2218, 20, ""),
				}),
				new("Springs", typeof(Static), 4189, "", new DecorationEntry[]
				{
					new(3719, 2131, 24, ""),
					new(3718, 2131, 24, ""),
				}),
				new("Springs", typeof(Static), 4190, "", new DecorationEntry[]
				{
					new(3714, 2130, 24, ""),
					new(3714, 2129, 24, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(3656, 2138, 24, ""),
				}),
				new("Red Potion", typeof(Static), 3851, "", new DecorationEntry[]
				{
					new(3696, 2225, 28, ""),
					new(3705, 2224, 22, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(3691, 2075, 5, ""),
					new(3696, 2246, 20, ""),
					new(3664, 2251, 20, ""),
				}),
				new("Tile Roof", typeof(Static), 1460, "", new DecorationEntry[]
				{
					new(3688, 2261, 40, ""),
					new(3687, 2261, 43, ""),
					new(3685, 2261, 49, ""),
					new(3686, 2261, 46, ""),
					new(3672, 2261, 40, ""),
					new(3671, 2261, 43, ""),
					new(3670, 2261, 46, ""),
					new(3669, 2261, 49, ""),
				}),
				new("Tile Roof", typeof(Static), 1459, "", new DecorationEntry[]
				{
					new(3684, 2261, 52, ""),
					new(3668, 2261, 52, ""),
				}),
				new("Fallen Log", typeof(Static), 3316, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3591, 2172, 21, ""),
				}),
				new("Morning Glories", typeof(Static), 3380, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3578, 2153, 49, ""),
				}),
				new("Small Fish", typeof(Static), 3542, "", new DecorationEntry[]
				{
					new(3684, 2268, 20, ""),
					new(3667, 2269, 20, ""),
				}),
				new("Water", typeof(Static), 6057, "", new DecorationEntry[]
				{
					new(3670, 2302, -5, ""),
				}),
				new("Small Palm", typeof(Static), 3226, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3690, 2261, 20, ""),
					new(3647, 2208, 20, ""),
					new(3582, 2161, 43, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(3715, 2086, 5, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(3768, 2111, 40, ""),
				}),
				new("Small Palm", typeof(Static), 3226, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3743, 2150, 20, ""),
					new(3787, 2122, 23, ""),
					new(3585, 2166, 28, ""),
				}),
				new("Fallen Log", typeof(Static), 3315, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3584, 2161, 45, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(3691, 2292, -3, ""),
					new(3680, 2261, 21, ""),
					new(3679, 2270, 21, ""),
					new(3666, 2262, 20, ""),
					new(3678, 2298, -3, ""),
				}),
				new("Orange Potion", typeof(Static), 3847, "", new DecorationEntry[]
				{
					new(3705, 2224, 30, ""),
					new(3696, 2222, 24, ""),
				}),
				new("Rushes", typeof(Static), 3239, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3580, 2164, 30, ""),
				}),
				new("Coconut%S%", typeof(Static), 5926, "", new DecorationEntry[]
				{
					new(3684, 2196, 20, ""),
					new(3682, 2197, 20, ""),
					new(3681, 2198, 20, ""),
					new(3681, 2196, 20, ""),
				}),
				new("", typeof(Static), 16391, "", new DecorationEntry[]
				{
					new(3800, 2156, -5, ""),
				}),
				new("Small Palm", typeof(Static), 3226, "Hue=0x497", new DecorationEntry[]
				{
					new(3738, 2081, 5, ""),
					new(3662, 2075, 20, ""),
					new(3729, 2199, 20, ""),
					new(3680, 2125, 20, ""),
					new(3596, 2124, 53, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(3661, 2116, 24, ""),
				}),
				new("Tree", typeof(Static), 3396, "Hue=0x497", new DecorationEntry[]
				{
					new(3655, 2064, 20, ""),
				}),
				new("Tree", typeof(Static), 3394, "Hue=0x497", new DecorationEntry[]
				{
					new(3653, 2066, 20, ""),
				}),
				new("Tree", typeof(Static), 3393, "Hue=0x497", new DecorationEntry[]
				{
					new(3652, 2067, 20, ""),
				}),
				new("Tree", typeof(Static), 3395, "Hue=0x497", new DecorationEntry[]
				{
					new(3654, 2065, 20, ""),
				}),
				new("Anchor", typeof(Static), 5369, "", new DecorationEntry[]
				{
					new(3690, 2292, -3, ""),
					new(3665, 2262, 21, ""),
				}),
				new("Wooden Plank", typeof(Static), 2000, "", new DecorationEntry[]
				{
					new(3685, 2262, 20, ""),
					new(3684, 2267, 20, ""),
					new(3680, 2262, 20, ""),
					new(3677, 2263, 20, ""),
					new(3675, 2284, -3, ""),
					new(3675, 2274, -3, ""),
					new(3672, 2270, 20, ""),
					new(3671, 2269, 20, ""),
					new(3670, 2281, -3, ""),
					new(3668, 2262, 20, ""),
					new(3665, 2261, 20, ""),
				}),
				new("Fishing Pole", typeof(Static), 3520, "", new DecorationEntry[]
				{
					new(3682, 2268, 21, ""),
					new(3667, 2269, 21, ""),
				}),
				new("Bottle", typeof(Static), 3841, "", new DecorationEntry[]
				{
					new(3709, 2224, 24, ""),
				}),
				new("Diamond%S%", typeof(Static), 3888, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Amethyst%S%", typeof(Static), 3886, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Tourmaline%S%", typeof(Static), 3872, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
					new(3664, 2145, 24, ""),
					new(3664, 2134, 24, ""),
				}),
				new("Star Sapphire%S%", typeof(Static), 3867, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Rub%Ies/Y%", typeof(Static), 3883, "", new DecorationEntry[]
				{
					new(3664, 2133, 24, ""),
				}),
				new("Piece%S% Of Amber", typeof(Static), 3877, "", new DecorationEntry[]
				{
					new(3664, 2133, 24, ""),
				}),
				new("Citrine%S%", typeof(Static), 3876, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
				}),
				new("Citrine%S%", typeof(Static), 3875, "", new DecorationEntry[]
				{
					new(3664, 2148, 24, ""),
					new(3664, 2146, 24, ""),
					new(3664, 2132, 24, ""),
				}),
				new("Rub%Ies/Y%", typeof(Static), 3869, "", new DecorationEntry[]
				{
					new(3664, 2148, 24, ""),
					new(3664, 2146, 24, ""),
					new(3664, 2132, 24, ""),
				}),
				new("Rub%Ies/Y%", typeof(Static), 3868, "", new DecorationEntry[]
				{
					new(3664, 2147, 24, ""),
					new(3664, 2145, 24, ""),
					new(3664, 2132, 24, ""),
				}),
				new("Sapphire%S%", typeof(Static), 3857, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
				}),
				new("Star Sapphire%S%", typeof(Static), 3855, "", new DecorationEntry[]
				{
					new(3664, 2133, 24, ""),
					new(3664, 2132, 24, ""),
				}),
				new("Rub%Ies/Y%", typeof(Static), 3860, "", new DecorationEntry[]
				{
					new(3664, 2131, 24, ""),
				}),
				new("Emerald%S%", typeof(Static), 3856, "", new DecorationEntry[]
				{
					new(3664, 2131, 24, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(3691, 2076, 5, ""),
					new(3691, 2077, 5, ""),
					new(3696, 2247, 20, ""),
					new(3664, 2250, 20, ""),
				}),
				new("Fitting", typeof(Static), 4399, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3561, 2167, 20, ""),
				}),
				new("Wooden Stairs", typeof(Static), 1849, "", new DecorationEntry[]
				{
					new(3677, 2275, -3, ""),
					new(3677, 2274, 1, ""),
					new(3677, 2273, 6, ""),
					new(3677, 2272, 11, ""),
					new(3677, 2271, 16, ""),
					new(3676, 2275, -3, ""),
					new(3676, 2271, 16, ""),
					new(3675, 2275, -3, ""),
					new(3675, 2273, 6, ""),
					new(3675, 2272, 11, ""),
					new(3675, 2271, 16, ""),
					new(3674, 2275, -3, ""),
					new(3674, 2274, 1, ""),
					new(3674, 2273, 6, ""),
					new(3674, 2272, 11, ""),
					new(3674, 2271, 16, ""),
					new(3673, 2273, 6, ""),
					new(3673, 2272, 11, ""),
					new(3673, 2271, 16, ""),
					new(3672, 2275, -3, ""),
					new(3672, 2274, 1, ""),
					new(3672, 2273, 6, ""),
					new(3672, 2272, 11, ""),
					new(3672, 2271, 16, ""),
					new(3671, 2275, -3, ""),
					new(3671, 2274, 1, ""),
					new(3671, 2273, 6, ""),
					new(3671, 2272, 11, ""),
					new(3671, 2271, 16, ""),
					new(3676, 2274, 1, ""),
					new(3676, 2273, 6, ""),
					new(3670, 2275, -3, ""),
					new(3670, 2274, 1, ""),
					new(3670, 2273, 6, ""),
					new(3670, 2272, 11, ""),
					new(3670, 2271, 16, ""),
					new(3675, 2274, 1, ""),
					new(3673, 2275, -3, ""),
					new(3673, 2274, 1, ""),
					new(3676, 2272, 11, ""),
				}),
				new("Stone Step", typeof(Static), 2327, "Hue=0x497", new DecorationEntry[]
				{
					new(3564, 2146, 33, ""),
					new(3557, 2139, 23, ""),
					new(3568, 2144, 40, ""),
					new(3570, 2140, 38, ""),
					new(3568, 2136, 31, ""),
					new(3560, 2143, 26, ""),
					new(3559, 2135, 22, ""),
					new(3563, 2133, 25, ""),
				}),
				new("Ruined Wall", typeof(Static), 634, "Hue=0x497", new DecorationEntry[]
				{
					new(3563, 2146, 33, ""),
					new(3567, 2144, 40, ""),
					new(3569, 2140, 38, ""),
					new(3567, 2136, 31, ""),
					new(3559, 2143, 26, ""),
					new(3556, 2139, 23, ""),
					new(3558, 2135, 22, ""),
					new(3562, 2133, 25, ""),
				}),
				new("Ruined Wall", typeof(Static), 632, "Hue=0x497", new DecorationEntry[]
				{
					new(3564, 2145, 33, ""),
					new(3568, 2143, 40, ""),
					new(3568, 2135, 31, ""),
					new(3570, 2139, 38, ""),
					new(3560, 2142, 26, ""),
					new(3557, 2138, 23, ""),
					new(3559, 2134, 22, ""),
					new(3563, 2132, 25, ""),
				}),
				new("Stone Ruins", typeof(Static), 955, "Hue=0x497", new DecorationEntry[]
				{
					new(3562, 2145, 33, ""),
					new(3566, 2143, 40, ""),
					new(3566, 2135, 31, ""),
					new(3568, 2139, 38, ""),
					new(3558, 2142, 26, ""),
					new(3555, 2138, 23, ""),
					new(3557, 2134, 22, ""),
					new(3561, 2132, 25, ""),
				}),
				new("Stone Stairs", typeof(Static), 1931, "Hue=0x497", new DecorationEntry[]
				{
					new(3563, 2143, 33, ""),
					new(3567, 2141, 40, ""),
					new(3567, 2133, 31, ""),
					new(3569, 2137, 38, ""),
					new(3559, 2140, 26, ""),
					new(3556, 2136, 23, ""),
					new(3558, 2132, 22, ""),
					new(3562, 2130, 25, ""),
				}),
				new("Mug Of Ale", typeof(Static), 2543, "", new DecorationEntry[]
				{
					new(3731, 2221, 24, ""),
					new(3722, 2218, 24, ""),
				}),
				new("Rushes", typeof(Static), 3239, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3660, 2083, 20, ""),
				}),
				new("Grasses", typeof(Static), 3248, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3744, 2085, 15, ""),
					new(3757, 2143, 16, ""),
					new(3668, 2079, 20, ""),
				}),
				new("Bench", typeof(Static), 2918, "", new DecorationEntry[]
				{
					new(3718, 2134, 20, ""),
					new(3713, 2128, 20, ""),
					new(3728, 2137, 20, ""),
				}),
				new("Candlabra", typeof(Static), 2599, "", new DecorationEntry[]
				{
					new(3705, 2211, 48, ""),
				}),
				new("Snake Plant", typeof(Static), 3241, "Hue=0x497", new DecorationEntry[]
				{
					new(3659, 2253, 20, ""),
				}),
				new("Rushes", typeof(Static), 3239, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3660, 2249, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3349, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3674, 2083, 22, ""),
				}),
				new("Grasses", typeof(Static), 3379, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3656, 2248, 20, ""),
				}),
				new("Grasses", typeof(Static), 3247, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3656, 2247, 20, ""),
				}),
				new("Dirt", typeof(Static), 7679, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3558, 2165, 20, ""),
					new(3696, 2237, 20, ""),
					new(3728, 2242, 20, ""),
					new(3730, 2139, 20, ""),
				}),
				new("Grasses", typeof(Static), 3378, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3757, 2116, 20, ""),
					new(3654, 2248, 20, ""),
				}),
				new("Fishermens' Guild", typeof(LocalizedSign), 3060, "", new DecorationEntry[]
				{
					new(3682, 2261, 20, ""),
				}),
				new("Bakery", typeof(LocalizedSign), 2980, "", new DecorationEntry[]
				{
					new(3753, 2232, 20, ""),
					new(3681, 2176, 20, ""),
				}),
				new("Teleporter", typeof(Static), 6157, "Hue=0x45B", new DecorationEntry[]
				{
					new(3676, 2258, 20, ""),
				}),
				new("Stone Ruins", typeof(Static), 952, "Hue=0x497", new DecorationEntry[]
				{
					new(3566, 2148, 33, ""),
					new(3570, 2146, 40, ""),
					new(3570, 2138, 31, ""),
					new(3562, 2145, 26, ""),
					new(3559, 2141, 23, ""),
					new(3561, 2137, 22, ""),
					new(3565, 2135, 25, ""),
					new(3572, 2142, 38, ""),
				}),
				new("Stone Stairs", typeof(Static), 1929, "Hue=0x497", new DecorationEntry[]
				{
					new(3557, 2140, 23, ""),
					new(3564, 2147, 33, ""),
					new(3568, 2145, 40, ""),
					new(3568, 2137, 31, ""),
					new(3560, 2144, 26, ""),
					new(3559, 2136, 22, ""),
					new(3563, 2134, 25, ""),
					new(3570, 2141, 38, ""),
				}),
				new("Stone Ruins", typeof(Static), 953, "Hue=0x497", new DecorationEntry[]
				{
					new(3562, 2147, 33, ""),
					new(3555, 2140, 23, ""),
					new(3566, 2145, 40, ""),
					new(3566, 2137, 31, ""),
					new(3558, 2144, 26, ""),
					new(3557, 2136, 22, ""),
					new(3561, 2134, 25, ""),
					new(3568, 2141, 38, ""),
				}),
				new("Debris", typeof(Static), 3120, "", new DecorationEntry[]
				{
					new(3670, 2120, 20, ""),
				}),
				new("Stone Stairs", typeof(Static), 1940, "Hue=0x497", new DecorationEntry[]
				{
					new(3565, 2145, 33, ""),
					new(3569, 2143, 40, ""),
					new(3569, 2135, 31, ""),
					new(3561, 2142, 26, ""),
					new(3558, 2138, 23, ""),
					new(3560, 2134, 22, ""),
					new(3564, 2132, 25, ""),
					new(3571, 2139, 38, ""),
				}),
				new("Sewing Kit", typeof(Static), 3997, "", new DecorationEntry[]
				{
					new(3666, 2237, 22, ""),
				}),
				new("Grasses", typeof(Static), 3247, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3806, 2137, 20, ""),
				}),
				new("Snake Plant", typeof(Static), 3241, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3797, 2151, 21, ""),
				}),
				new("Fallen Log", typeof(Static), 3316, "Hue=0x497", new DecorationEntry[]
				{
					new(3652, 2247, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3343, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3650, 2247, 11, ""),
				}),
				new("Sapling", typeof(Static), 3305, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3650, 2246, 7, ""),
				}),
				new("Mushrooms", typeof(Static), 3348, "", new DecorationEntry[]
				{
					new(3773, 2216, 20, ""),
				}),
				new("Mushroom", typeof(Static), 3352, "Hue=0x497", new DecorationEntry[]
				{
					new(3661, 2063, 20, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "", new DecorationEntry[]
				{
					new(3716, 2120, 20, ""),
					new(3717, 2120, 20, ""),
					new(3720, 2080, 5, ""),
					new(3721, 2080, 5, ""),
					new(3721, 2120, 20, ""),
					new(3722, 2120, 20, ""),
				}),
				new("Sextant Parts", typeof(Static), 4185, "", new DecorationEntry[]
				{
					new(3723, 2123, 24, ""),
				}),
				new("Bunch%Es% Of Dates", typeof(Static), 5927, "", new DecorationEntry[]
				{
					new(3682, 2193, 20, ""),
					new(3684, 2195, 20, ""),
					new(3682, 2196, 20, ""),
					new(3686, 2196, 20, ""),
					new(3686, 2194, 20, ""),
				}),
				new("Roast Pig%S%", typeof(Static), 2492, "", new DecorationEntry[]
				{
					new(3660, 2117, 24, ""),
					new(3722, 2221, 24, ""),
					new(3690, 2165, 24, ""),
				}),
				new("Wheel%S% Of Cheese", typeof(Static), 2430, "", new DecorationEntry[]
				{
					new(3684, 2168, 24, ""),
				}),
				new("Bread Loa%Ves/F%", typeof(Static), 4156, "", new DecorationEntry[]
				{
					new(3757, 2216, 24, ""),
					new(3756, 2216, 24, ""),
					new(3681, 2168, 24, ""),
				}),
				new("Pizza%S%", typeof(Static), 4160, "", new DecorationEntry[]
				{
					new(3721, 2083, 9, ""),
					new(3752, 2228, 24, ""),
					new(3752, 2227, 24, ""),
					new(3752, 2226, 24, ""),
					new(3680, 2173, 24, ""),
				}),
				new("Baked Pie", typeof(Static), 4161, "", new DecorationEntry[]
				{
					new(3752, 2227, 24, ""),
					new(3752, 2225, 24, ""),
					new(3680, 2171, 24, ""),
					new(3680, 2169, 24, ""),
				}),
				new("Checkers", typeof(Static), 4005, "", new DecorationEntry[]
				{
					new(3697, 2061, 9, ""),
					new(3730, 2221, 24, ""),
				}),
				new("Checkers", typeof(Static), 4004, "", new DecorationEntry[]
				{
					new(3697, 2061, 9, ""),
					new(3730, 2221, 24, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2712, "", new DecorationEntry[]
				{
					new(3695, 2056, 5, ""),
					new(3758, 2120, 20, ""),
					new(3698, 2056, 5, ""),
					new(3700, 2240, 20, ""),
					new(3704, 2208, 40, ""),
					new(3669, 2248, 20, ""),
					new(3771, 2104, 40, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(3759, 2120, 20, ""),
					new(3696, 2056, 5, ""),
					new(3702, 2208, 40, ""),
					new(3699, 2240, 20, ""),
					new(3702, 2240, 20, ""),
					new(3705, 2208, 40, ""),
					new(3707, 2208, 40, ""),
					new(3666, 2248, 20, ""),
					new(3773, 2104, 40, ""),
				}),
				new("Dirt", typeof(Static), 7678, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3556, 2163, 20, ""),
					new(3767, 2215, 20, ""),
					new(3545, 2145, 20, ""),
					new(3581, 2150, 59, ""),
					new(3537, 2146, 20, ""),
				}),
				new("Dirt Patch", typeof(Static), 2321, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3551, 2166, 20, ""),
					new(3550, 2144, 21, ""),
					new(3542, 2142, 20, ""),
					new(3536, 2149, 20, ""),
				}),
				new("Fitting", typeof(Static), 4399, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3566, 2152, 31, ""),
					new(3736, 2145, 20, ""),
					new(3737, 2215, 20, ""),
				}),
				new("Hatch", typeof(Static), 16019, "", new DecorationEntry[]
				{
					new(3796, 2156, -5, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(3729, 2218, 24, ""),
				}),
				new("Counter", typeof(Static), 2878, "", new DecorationEntry[]
				{
					new(3731, 2147, 20, ""),
					new(3730, 2147, 20, ""),
					new(3729, 2147, 20, ""),
				}),
				new("Yellow Potion", typeof(Static), 3852, "", new DecorationEntry[]
				{
					new(3696, 2225, 24, ""),
				}),
				new("Wood", typeof(Static), 7041, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3556, 2164, 25, ""),
					new(3550, 2142, 21, ""),
					new(3687, 2248, 20, ""),
					new(3679, 2158, 20, ""),
					new(3661, 2237, 20, ""),
					new(3652, 2167, 33, ""),
					new(3532, 2142, 20, ""),
					new(3531, 2144, 20, ""),
				}),
				new("Counter", typeof(Static), 2880, "", new DecorationEntry[]
				{
					new(3732, 2147, 20, ""),
					new(3728, 2147, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3349, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3790, 2117, 25, ""),
				}),
				new("Sandstone Post", typeof(Static), 363, "", new DecorationEntry[]
				{
					new(3706, 2192, 20, ""),
				}),
				new("Fishing Pole", typeof(Static), 3519, "", new DecorationEntry[]
				{
					new(3667, 2299, -2, ""),
					new(3685, 2270, 21, ""),
				}),
				new("Water", typeof(Static), 6040, "", new DecorationEntry[]
				{
					new(3653, 2258, -5, ""),
				}),
				new("Elephant Ear Plant", typeof(Static), 3223, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3725, 2107, 20, ""),
				}),
				new("Pier", typeof(Static), 938, "", new DecorationEntry[]
				{
					new(3687, 2270, 21, ""),
					new(3687, 2268, 21, ""),
					new(3687, 2261, 21, ""),
					new(3684, 2270, 21, ""),
					new(3682, 2270, 21, ""),
					new(3679, 2261, 21, ""),
					new(3678, 2270, 21, ""),
					new(3680, 2270, 21, ""),
					new(3671, 2261, 21, ""),
					new(3669, 2270, 21, ""),
					new(3667, 2270, 21, ""),
					new(3665, 2270, 21, ""),
					new(3663, 2270, 21, ""),
					new(3663, 2266, 21, ""),
					new(3663, 2264, 21, ""),
					new(3663, 2262, 21, ""),
					new(3663, 2268, 21, ""),
				}),
				new("Rushes", typeof(Static), 3239, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3799, 2112, 22, ""),
					new(3661, 2077, 20, ""),
				}),
				new("Dirt Patch", typeof(Static), 2322, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3548, 2140, 20, ""),
					new(3550, 2159, 21, ""),
				}),
				new("Water", typeof(Static), 6042, "", new DecorationEntry[]
				{
					new(3784, 2276, -5, ""),
				}),
				new("Bench", typeof(Static), 2912, "", new DecorationEntry[]
				{
					new(3708, 2210, 20, ""),
					new(3696, 2124, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3229, "Hue=0x497", new DecorationEntry[]
				{
					new(3662, 2043, 20, ""),
					new(3636, 2200, 20, ""),
					new(3726, 2139, 20, ""),
					new(3775, 2144, 20, ""),
					new(3675, 2210, 20, ""),
				}),
				new("Rock", typeof(Static), 6012, "", new DecorationEntry[]
				{
					new(3730, 2209, 20, ""),
					new(3792, 2137, 28, ""),
					new(3652, 2250, 20, ""),
					new(3760, 2138, 23, ""),
				}),
				new("Dirt", typeof(Static), 7679, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3690, 2239, 20, ""),
					new(3567, 2162, 21, ""),
					new(3553, 2160, 21, ""),
					new(3546, 2149, 20, ""),
					new(3529, 2139, -15, ""),
					new(3555, 2157, 23, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4095, "", new DecorationEntry[]
				{
					new(3727, 2218, 24, ""),
				}),
				new("Dirt", typeof(Static), 7678, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3684, 2248, 20, ""),
					new(3551, 2166, 20, ""),
					new(3552, 2144, 22, ""),
					new(3535, 2136, 18, ""),
					new(3541, 2156, 19, ""),
					new(3531, 2143, 20, ""),
				}),
				new("Skull Mug", typeof(Static), 4093, "", new DecorationEntry[]
				{
					new(3728, 2228, 25, ""),
					new(3727, 2228, 25, ""),
					new(3726, 2228, 21, ""),
				}),
				new("Chess Pieces", typeof(Static), 4008, "", new DecorationEntry[]
				{
					new(3726, 2218, 24, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(3722, 2229, 24, ""),
				}),
				new("Playing Cards", typeof(Static), 4002, "", new DecorationEntry[]
				{
					new(3722, 2226, 24, ""),
				}),
				new("Mug", typeof(CeramicMug), 2456, "", new DecorationEntry[]
				{
					new(3722, 2225, 24, ""),
				}),
				new("Glass Of Water", typeof(Static), 8081, "", new DecorationEntry[]
				{
					new(3722, 2222, 24, ""),
				}),
				new("Throne", typeof(Throne), 2867, "", new DecorationEntry[]
				{
					new(3786, 2250, 20, ""),
					new(3786, 2247, 20, ""),
					new(3786, 2249, 20, ""),
					new(3786, 2246, 20, ""),
					new(3786, 2245, 20, ""),
					new(3786, 2244, 20, ""),
					new(3786, 2243, 20, ""),
					new(3786, 2242, 20, ""),
					new(3786, 2248, 20, ""),
				}),
				new("Water", typeof(Static), 6039, "", new DecorationEntry[]
				{
					new(3714, 2017, -5, ""),
					new(3649, 2259, -5, ""),
					new(3670, 2302, -5, ""),
					new(3711, 2016, -5, ""),
					new(3784, 2276, -5, ""),
				}),
				new("Pampas Grass", typeof(Static), 3268, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3787, 2087, 20, ""),
				}),
				new("Playing Cards", typeof(Static), 4003, "", new DecorationEntry[]
				{
					new(3722, 2217, 24, ""),
				}),
				new("Goblet", typeof(Static), 2458, "", new DecorationEntry[]
				{
					new(3722, 2217, 24, ""),
				}),
				new("Grasses", typeof(Static), 3248, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3782, 2103, 20, ""),
				}),
				new("Lamp Post", typeof(LampPost2), 2850, "", new DecorationEntry[]
				{
					new(3682, 2261, 20, ""),
					new(3669, 2261, 20, ""),
					new(3728, 2160, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3228, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3724, 2138, 20, ""),
					new(3653, 2247, 20, ""),
					new(3655, 2248, 20, ""),
				}),
				new("Unbaked Pie", typeof(Static), 4162, "", new DecorationEntry[]
				{
					new(3680, 2172, 24, ""),
					new(3752, 2226, 24, ""),
					new(3721, 2083, 9, ""),
				}),
				new("Spittoon", typeof(Static), 4099, "", new DecorationEntry[]
				{
					new(3720, 2216, 20, ""),
				}),
				new("Clock", typeof(Static), 4171, "", new DecorationEntry[]
				{
					new(3722, 2131, 24, ""),
					new(3720, 2123, 24, ""),
				}),
				new("Dirt", typeof(Static), 7678, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3550, 2147, 22, ""),
					new(3555, 2159, 22, ""),
					new(3669, 2182, 20, ""),
				}),
				new("Fern", typeof(Static), 3234, "Hue=0x497", new DecorationEntry[]
				{
					new(3653, 2047, 20, ""),
					new(3716, 2053, 5, ""),
					new(3565, 2137, 27, ""),
					new(3561, 2139, 30, ""),
					new(3653, 2250, 20, ""),
					new(3727, 2052, 5, ""),
				}),
				new("Garbage", typeof(Static), 4334, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3547, 2136, 20, ""),
					new(3711, 2136, 20, ""),
					new(3654, 2217, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3228, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3780, 2085, 21, ""),
				}),
				new("Mushrooms", typeof(Static), 3344, "Hue=0x497", new DecorationEntry[]
				{
					new(3780, 2084, 21, ""),
				}),
				new("Mushrooms", typeof(Static), 3345, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3766, 2144, 16, ""),
				}),
				new("Grasses", typeof(Static), 3379, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3757, 2187, -15, ""),
				}),
				new("Cattails", typeof(Static), 3255, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3646, 2212, 20, ""),
					new(3650, 2047, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3344, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3649, 2080, 20, ""),
				}),
				new("Metal Signpost", typeof(Static), 2977, "", new DecorationEntry[]
				{
					new(3719, 2195, 20, ""),
				}),
				new("Sextant", typeof(Static), 4183, "", new DecorationEntry[]
				{
					new(3722, 2123, 24, ""),
					new(3719, 2131, 24, ""),
				}),
				new("Gears", typeof(Static), 4180, "", new DecorationEntry[]
				{
					new(3725, 2126, 24, ""),
				}),
				new("Orfluer Flowers", typeof(Static), 3205, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3725, 2055, 5, ""),
				}),
				new("Axle%S% With Gears", typeof(Static), 4178, "", new DecorationEntry[]
				{
					new(3724, 2131, 24, ""),
					new(3723, 2131, 24, ""),
					new(3722, 2123, 24, ""),
					new(3719, 2123, 24, ""),
				}),
				new("Clock Frame%S%", typeof(Static), 4173, "", new DecorationEntry[]
				{
					new(3719, 2131, 24, ""),
					new(3718, 2123, 24, ""),
				}),
				new("Clock Frame%S%", typeof(Static), 4174, "", new DecorationEntry[]
				{
					new(3714, 2127, 24, ""),
					new(3725, 2128, 24, ""),
					new(3714, 2130, 24, ""),
				}),
				new("Axle%S%", typeof(Static), 4188, "", new DecorationEntry[]
				{
					new(3714, 2130, 24, ""),
					new(3714, 2129, 24, ""),
				}),
				new("Axle%S% With Gears", typeof(Static), 4177, "", new DecorationEntry[]
				{
					new(3725, 2127, 24, ""),
					new(3714, 2126, 24, ""),
				}),
				new("Goblet", typeof(Static), 2483, "", new DecorationEntry[]
				{
					new(3726, 2218, 24, ""),
					new(3721, 2084, 9, ""),
					new(3718, 2084, 9, ""),
					new(3718, 2083, 9, ""),
				}),
				new("Fallen Log", typeof(Static), 3315, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3597, 2171, 25, ""),
					new(3653, 2249, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "Hue=0x1E", new DecorationEntry[]
				{
					new(3688, 2197, 20, ""),
				}),
				new("Dirt Patch", typeof(Static), 2321, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3664, 2205, 23, ""),
					new(3556, 2159, 22, ""),
					new(3661, 2189, 20, ""),
				}),
				new("Rock", typeof(Static), 6007, "", new DecorationEntry[]
				{
					new(3659, 2266, -5, ""),
					new(3665, 2271, -5, ""),
					new(3654, 2254, 20, ""),
					new(3648, 2099, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3226, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3694, 2125, 20, ""),
					new(3766, 2204, 20, ""),
				}),
				new("Sandstone Wall", typeof(Static), 350, "", new DecorationEntry[]
				{
					new(3721, 2062, 5, ""),
					new(3766, 2225, 20, ""),
				}),
				new("Pampas Grass", typeof(Static), 3237, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3635, 2199, 20, ""),
					new(3773, 2274, 20, ""),
				}),
				new("Pampas Grass", typeof(Static), 3268, "Hue=0x497", new DecorationEntry[]
				{
					new(3752, 2196, 20, ""),
					new(3778, 2140, 21, ""),
					new(3595, 2167, 34, ""),
					new(3780, 2082, 22, ""),
				}),
				new("Grasses", typeof(Static), 3254, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3775, 2112, 20, ""),
					new(3669, 2212, 20, ""),
				}),
				new("Grasses", typeof(Static), 3257, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3652, 2053, 20, ""),
					new(3778, 2255, 20, ""),
				}),
				new("Tile Roof", typeof(Static), 1461, "", new DecorationEntry[]
				{
					new(3683, 2261, 49, ""),
					new(3682, 2261, 46, ""),
					new(3680, 2261, 40, ""),
					new(3681, 2261, 43, ""),
					new(3667, 2261, 49, ""),
					new(3666, 2261, 46, ""),
					new(3664, 2261, 40, ""),
					new(3665, 2261, 43, ""),
				}),
				new("Fern", typeof(Static), 3231, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3645, 2065, 20, ""),
					new(3625, 2198, 14, ""),
					new(3637, 2221, 20, ""),
					new(3766, 2269, 20, ""),
				}),
				new("Bulrushes", typeof(Static), 3220, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3631, 2200, 20, ""),
					new(3679, 2137, 20, ""),
					new(3764, 2270, 20, ""),
				}),
				new("Clock", typeof(Static), 4172, "", new DecorationEntry[]
				{
					new(3719, 2120, 29, ""),
					new(3714, 2125, 24, ""),
				}),
				new("Grasses", typeof(Static), 3254, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3680, 2086, 28, ""),
					new(3752, 2249, 7, ""),
				}),
				new("Table", typeof(Static), 2957, "", new DecorationEntry[]
				{
					new(3686, 2211, 20, ""),
					new(3697, 2204, 20, ""),
					new(3692, 2215, 20, ""),
					new(3768, 2223, 20, ""),
					new(3770, 2223, 19, ""),
				}),
				new("Small Palm", typeof(Static), 3229, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3760, 2077, 39, ""),
					new(3626, 2196, 20, ""),
					new(3772, 2138, 24, ""),
					new(3650, 2076, 20, ""),
				}),
				new("Bulrushes", typeof(Static), 3220, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3650, 2046, 20, ""),
					new(3671, 2076, 23, ""),
					new(3658, 2074, 20, ""),
				}),
				new("Grasses", typeof(Static), 3378, "Hue=0x497", new DecorationEntry[]
				{
					new(3752, 2248, 13, ""),
				}),
				new("Sapling", typeof(Static), 3306, "Hue=0x497", new DecorationEntry[]
				{
					new(3652, 2070, 20, ""),
					new(3748, 2248, 20, ""),
				}),
				new("Sapling", typeof(Static), 3306, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3730, 2253, 20, ""),
					new(3736, 2250, 20, ""),
				}),
				new("Merchants' Guild", typeof(LocalizedSign), 3081, "", new DecorationEntry[]
				{
					new(3712, 2242, 20, ""),
				}),
				new("Bulrushes", typeof(Static), 3220, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3726, 2238, 20, ""),
				}),
				new("Citrine%S%", typeof(Static), 3884, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(3735, 2147, 20, ""),
				}),
				new("Rushes", typeof(Static), 3239, "Hue=0x497", new DecorationEntry[]
				{
					new(3652, 2079, 20, ""),
				}),
				new("Clean Bandage%S%", typeof(Static), 3817, "", new DecorationEntry[]
				{
					new(3690, 2208, 24, ""),
					new(3689, 2208, 24, ""),
					new(3693, 2208, 24, ""),
					new(3692, 2208, 24, ""),
					new(3691, 2208, 24, ""),
					new(3683, 2224, 24, ""),
					new(3687, 2224, 24, ""),
					new(3686, 2224, 24, ""),
				}),
				new("Fallen Log", typeof(Static), 3319, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3777, 2080, 24, ""),
				}),
				new("Blade Plant", typeof(Static), 3219, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3776, 2075, 20, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4338, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3631, 2160, 67, ""),
					new(3724, 2225, 20, ""),
					new(3674, 2144, 20, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2897, "", new DecorationEntry[]
				{
					new(3682, 2254, 20, ""),
					new(3666, 2255, 20, ""),
					new(3666, 2253, 20, ""),
					new(3765, 2123, 20, ""),
					new(3709, 2246, 20, ""),
					new(3709, 2248, 20, ""),
				}),
				new("Fan Plant", typeof(Static), 3224, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3667, 2204, 20, ""),
				}),
				new("Scroll%S%", typeof(Static), 3833, "", new DecorationEntry[]
				{
					new(3709, 2224, 24, ""),
				}),
				new("Scroll%S%", typeof(Static), 3832, "", new DecorationEntry[]
				{
					new(3708, 2224, 24, ""),
				}),
				new("Grasses", typeof(Static), 3247, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3589, 2148, 62, ""),
					new(3715, 2243, 20, ""),
				}),
				new("Bottle", typeof(Static), 3842, "", new DecorationEntry[]
				{
					new(3708, 2224, 22, ""),
				}),
				new("Ponytail Palm", typeof(Static), 3238, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3719, 2250, 20, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(3680, 2214, 20, ""),
					new(3680, 2208, 20, ""),
					new(3708, 2222, 40, ""),
					new(3708, 2216, 40, ""),
				}),
				new("Scroll%S%", typeof(Static), 3831, "", new DecorationEntry[]
				{
					new(3707, 2224, 24, ""),
				}),
				new("Scroll%S%", typeof(Static), 3830, "", new DecorationEntry[]
				{
					new(3706, 2224, 24, ""),
				}),
				new("Statue", typeof(Static), 4644, "", new DecorationEntry[]
				{
					new(3704, 2046, 5, ""),
				}),
				new("Blank Scroll%S%", typeof(Static), 3827, "", new DecorationEntry[]
				{
					new(3705, 2224, 24, ""),
				}),
				new("Statue", typeof(Static), 5018, "", new DecorationEntry[]
				{
					new(3718, 2044, 5, ""),
				}),
				new("Book", typeof(RedBook), 4081, "", new DecorationEntry[]
				{
					new(3724, 2123, 21, ""),
					new(3705, 2211, 44, ""),
				}),
				new("Ginseng", typeof(Static), 3973, "", new DecorationEntry[]
				{
					new(3717, 2181, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3227, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3692, 2112, 20, ""),
					new(3779, 2142, 21, ""),
					new(3656, 2247, 20, ""),
					new(3772, 2278, 12, ""),
					new(3650, 2072, 20, ""),
				}),
				new("Fitting", typeof(Static), 4399, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3543, 2154, 20, ""),
				}),
				new("Diamond%S%", typeof(Static), 3881, "", new DecorationEntry[]
				{
					new(3665, 2148, 27, ""),
					new(3665, 2146, 27, ""),
				}),
				new("Fruit Basket", typeof(FruitBasket), 2451, "", new DecorationEntry[]
				{
					new(3719, 2084, 9, ""),
					new(3770, 2106, 24, ""),
					new(3676, 2100, 24, ""),
					new(3691, 2164, 24, ""),
					new(3683, 2204, 32, ""),
					new(3772, 2107, 44, ""),
				}),
				new("Garbage", typeof(Static), 4336, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3549, 2163, 20, ""),
					new(3703, 2137, 20, ""),
					new(3674, 2250, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3228, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3660, 2249, 20, ""),
					new(3654, 2082, 20, ""),
					new(3652, 2218, 20, ""),
					new(3651, 2068, 20, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(3704, 2216, 40, ""),
					new(3772, 2104, 20, ""),
					new(3704, 2221, 40, ""),
				}),
				new("Diamond%S%", typeof(Static), 3879, "", new DecorationEntry[]
				{
					new(3664, 2134, 24, ""),
					new(3664, 2147, 24, ""),
				}),
				new("Diamond%S%", typeof(Static), 3880, "", new DecorationEntry[]
				{
					new(3664, 2132, 24, ""),
					new(3664, 2147, 24, ""),
					new(3664, 2145, 24, ""),
				}),
				new("Book", typeof(BlueBook), 4082, "", new DecorationEntry[]
				{
					new(3702, 2211, 44, ""),
				}),
				new("Sandstone Wall", typeof(Static), 352, "", new DecorationEntry[]
				{
					new(3698, 2057, 5, ""),
					new(3740, 2154, 20, ""),
					new(3694, 2048, 5, ""),
					new(3727, 2174, 20, ""),
					new(3664, 2247, 20, ""),
					new(3766, 2227, 19, ""),
					new(3712, 2253, 20, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(3772, 2117, 20, ""),
					new(3769, 2117, 20, ""),
					new(3756, 2125, 20, ""),
					new(3754, 2125, 20, ""),
					new(3708, 2250, 20, ""),
					new(3698, 2253, 20, ""),
					new(3705, 2250, 20, ""),
					new(3700, 2253, 20, ""),
				}),
				new("Rock", typeof(Static), 6011, "", new DecorationEntry[]
				{
					new(3681, 2074, 5, ""),
					new(3640, 2067, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3316, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3667, 2140, 20, ""),
					new(3645, 2224, 20, ""),
				}),
				new("Mushroom", typeof(Static), 3353, "Hue=0x497", new DecorationEntry[]
				{
					new(3635, 2071, 20, ""),
				}),
				new("Sapling", typeof(Static), 3306, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3774, 2121, 20, ""),
					new(3654, 2218, 20, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(3680, 2253, 24, ""),
					new(3669, 2235, 24, ""),
					new(3787, 2245, 24, ""),
					new(3656, 2193, 24, ""),
					new(3787, 2244, 24, ""),
					new(3664, 2254, 27, ""),
					new(3787, 2249, 24, ""),
					new(3787, 2248, 24, ""),
					new(3787, 2247, 24, ""),
					new(3787, 2246, 24, ""),
					new(3787, 2243, 24, ""),
					new(3787, 2242, 24, ""),
					new(3787, 2241, 24, ""),
					new(3781, 2250, 24, ""),
					new(3752, 2220, 24, ""),
					new(3699, 2209, 24, ""),
				}),
				new("Fallen Log", typeof(Static), 3315, "Hue=0x497", new DecorationEntry[]
				{
					new(3645, 2212, 20, ""),
					new(3651, 2252, 20, ""),
					new(3634, 2079, 20, ""),
				}),
				new("Table", typeof(Static), 2876, "", new DecorationEntry[]
				{
					new(3674, 2260, 20, ""),
					new(3677, 2196, 20, ""),
					new(3680, 2165, 20, ""),
				}),
				new("Table", typeof(Static), 2950, "", new DecorationEntry[]
				{
					new(3709, 2064, 5, ""),
				}),
				new("Mushrooms", typeof(Static), 3349, "Hue=0x497", new DecorationEntry[]
				{
					new(3638, 2074, 20, ""),
				}),
				new("Chair", typeof(Static), 2895, "", new DecorationEntry[]
				{
					new(3773, 2104, 20, ""),
					new(3705, 2240, 20, ""),
					new(3698, 2240, 20, ""),
				}),
				new("Fern", typeof(Static), 3235, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3623, 2182, 23, ""),
					new(3674, 2132, 20, ""),
					new(3777, 2114, 20, ""),
					new(3667, 2035, 20, ""),
					new(3780, 2088, 24, ""),
					new(3744, 2190, 20, ""),
				}),
				new("Wooden Bench", typeof(WoodenBench), 2861, "", new DecorationEntry[]
				{
					new(3716, 2072, 5, ""),
					new(3684, 2196, 20, ""),
				}),
				new("Dirt", typeof(Static), 7680, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3540, 2147, 20, ""),
					new(3739, 2149, 20, ""),
					new(3626, 2194, 20, ""),
					new(3698, 2156, 20, ""),
					new(3563, 2154, 25, ""),
					new(3547, 2142, 20, ""),
					new(3700, 2177, 20, ""),
					new(3546, 2149, 20, ""),
					new(3557, 2169, -15, ""),
				}),
				new("Fallen Log", typeof(Static), 3318, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3638, 2080, 20, ""),
				}),
				new("Glass Pitcher", typeof(Static), 4086, "", new DecorationEntry[]
				{
					new(3722, 2228, 24, ""),
				}),
				new("Dirt Patch", typeof(Static), 2322, "", new DecorationEntry[]
				{
					new(3700, 2213, 20, ""),
					new(3540, 2136, 20, ""),
					new(3557, 2157, 23, ""),
					new(3557, 2163, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3317, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3635, 2071, 20, ""),
				}),
				new("Ponytail Palm", typeof(Static), 3238, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3638, 2075, 20, ""),
				}),
				new("Table", typeof(Static), 2931, "", new DecorationEntry[]
				{
					new(3689, 2166, 20, ""),
					new(3652, 2247, 20, ""),
					new(3666, 2259, 20, ""),
					new(3677, 2202, 20, ""),
				}),
				new("Wood", typeof(Static), 7041, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3541, 2140, 20, ""),
					new(3549, 2138, 20, ""),
					new(3755, 2205, 20, ""),
					new(3564, 2155, 25, ""),
				}),
				new("Mushrooms", typeof(Static), 3346, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3636, 2091, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3315, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3781, 2269, 20, ""),
					new(3639, 2078, 20, ""),
				}),
				new("Glass Of Water", typeof(Static), 8083, "", new DecorationEntry[]
				{
					new(3722, 2218, 24, ""),
					new(3731, 2221, 24, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(3728, 2216, 20, ""),
				}),
				new("Game Board", typeof(Chessboard), 4006, "", new DecorationEntry[]
				{
					new(3697, 2061, 9, ""),
					new(3730, 2221, 24, ""),
				}),
				new("Snake Plant", typeof(Static), 3241, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3625, 2200, 20, ""),
					new(3641, 2082, 20, ""),
				}),
				new("Garbage", typeof(Static), 4337, "Hue=0x497", new DecorationEntry[]
				{
					new(3674, 2171, 20, ""),
					new(3663, 2212, 20, ""),
					new(3664, 2205, 23, ""),
					new(3555, 2164, 20, ""),
					new(3556, 2159, 22, ""),
					new(3552, 2159, 21, ""),
					new(3547, 2145, 20, ""),
					new(3684, 2258, 20, ""),
					new(3558, 2164, 20, ""),
					new(3545, 2145, 20, ""),
					new(3554, 2136, 20, ""),
					new(3699, 2165, 20, ""),
					new(3533, 2146, 20, ""),
					new(3531, 2143, 20, ""),
					new(3564, 2160, 22, ""),
					new(3556, 2150, 26, ""),
				}),
				new("Garbage", typeof(Static), 4337, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3649, 2227, 20, ""),
					new(3564, 2164, 20, ""),
					new(3557, 2155, 24, ""),
					new(3537, 2137, 20, ""),
					new(3537, 2144, 20, ""),
					new(3567, 2153, 31, ""),
					new(3552, 2152, 23, ""),
					new(3566, 2160, 22, ""),
				}),
				new("Wood", typeof(Static), 7041, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3667, 2202, 20, ""),
					new(3565, 2158, 23, ""),
					new(3561, 2152, 27, ""),
					new(3557, 2151, 26, ""),
					new(3688, 2207, 20, ""),
					new(3534, 2141, 20, ""),
					new(3556, 2149, 26, ""),
				}),
				new("Bulrushes", typeof(Static), 3220, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3634, 2072, 11, ""),
				}),
				new("Small Palm", typeof(Static), 3227, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3641, 2225, 20, ""),
					new(3771, 2212, 20, ""),
					new(3780, 2091, 27, ""),
					new(3634, 2071, 8, ""),
				}),
				new("Candle", typeof(Static), 2576, "", new DecorationEntry[]
				{
					new(3704, 2228, 40, ""),
					new(3707, 2228, 40, ""),
					new(3680, 2153, 33, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(3680, 2153, 20, ""),
					new(3680, 2157, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3228, "Hue=0x497", new DecorationEntry[]
				{
					new(3639, 2073, 20, ""),
					new(3633, 2080, 8, ""),
				}),
				new("Small Palm", typeof(Static), 3225, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3593, 2150, 60, ""),
					new(3678, 2079, 26, ""),
					new(3781, 2095, 27, ""),
					new(3633, 2076, 8, ""),
				}),
				new("Table", typeof(Static), 2952, "", new DecorationEntry[]
				{
					new(3743, 2216, 20, ""),
					new(3773, 2211, 16, ""),
				}),
				new("Bottle", typeof(Static), 3837, "", new DecorationEntry[]
				{
					new(3696, 2227, 26, ""),
				}),
				new("Ship", typeof(Static), 16010, "", new DecorationEntry[]
				{
					new(3800, 2154, -5, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "", new DecorationEntry[]
				{
					new(3704, 2224, 24, ""),
					new(3696, 2227, 24, ""),
				}),
				new("Chair", typeof(Static), 2894, "", new DecorationEntry[]
				{
					new(3696, 2248, 20, ""),
					new(3779, 2266, 20, ""),
					new(3779, 2267, 20, ""),
				}),
				new("Shells", typeof(Static), 4041, "", new DecorationEntry[]
				{
					new(3780, 2268, 26, ""),
				}),
				new("Table", typeof(Static), 2923, "", new DecorationEntry[]
				{
					new(3780, 2268, 20, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(3689, 2185, 20, ""),
					new(3680, 2185, 20, ""),
					new(3656, 2096, 20, ""),
					new(3680, 2189, 20, ""),
				}),
				new("Table", typeof(Static), 2925, "", new DecorationEntry[]
				{
					new(3780, 2267, 20, ""),
					new(3780, 2266, 20, ""),
				}),
				new("Table", typeof(Static), 2924, "", new DecorationEntry[]
				{
					new(3780, 2265, 20, ""),
				}),
				new("Sandstone Post", typeof(Static), 359, "", new DecorationEntry[]
				{
					new(3682, 2205, 20, ""),
					new(3736, 2175, 20, ""),
					new(3697, 2174, 20, ""),
				}),
				new("Ship", typeof(Static), 16050, "", new DecorationEntry[]
				{
					new(3682, 2281, -5, ""),
				}),
				new("Scroll%S%", typeof(Static), 3828, "", new DecorationEntry[]
				{
					new(3696, 2223, 24, ""),
				}),
				new("Stone Wall", typeof(Static), 961, "", new DecorationEntry[]
				{
					new(3665, 2120, 20, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "", new DecorationEntry[]
				{
					new(3715, 2085, 5, ""),
					new(3712, 2124, 20, ""),
					new(3712, 2125, 20, ""),
					new(3712, 2129, 20, ""),
					new(3712, 2130, 20, ""),
					new(3664, 2257, 20, ""),
					new(3715, 2084, 5, ""),
					new(3680, 2249, 20, ""),
					new(3680, 2250, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3225, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3630, 2201, 20, ""),
					new(3645, 2084, 20, ""),
					new(3707, 2128, 20, ""),
				}),
				new("Scroll%S%", typeof(Static), 3829, "", new DecorationEntry[]
				{
					new(3696, 2221, 24, ""),
				}),
				new("Brazier", typeof(Brazier), 3634, "", new DecorationEntry[]
				{
					new(3704, 2221, 20, ""),
					new(3704, 2217, 20, ""),
					new(3696, 2224, 20, ""),
					new(3696, 2220, 20, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3746, 2070, 5, ""),
					new(3671, 2083, 21, ""),
					new(3729, 2107, 20, ""),
					new(3648, 2066, 20, ""),
					new(3649, 2066, 20, ""),
					new(3758, 2143, 16, ""),
				}),
				new("Dirt Patch", typeof(Static), 2322, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3537, 2150, 20, ""),
					new(3658, 2236, 20, ""),
				}),
				new("Pampas Grass", typeof(Static), 3268, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3603, 2100, 20, ""),
				}),
				new("Grasses", typeof(Static), 3247, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3773, 2072, 20, ""),
					new(3596, 2102, -15, ""),
				}),
				new("Fitting", typeof(Static), 4399, "Hue=0x497", new DecorationEntry[]
				{
					new(3551, 2159, 21, ""),
					new(3541, 2150, 20, ""),
					new(3724, 2141, 20, ""),
					new(3548, 2143, 21, ""),
					new(3567, 2169, -15, ""),
					new(3540, 2139, 20, ""),
					new(3553, 2158, 22, ""),
					new(3556, 2156, 23, ""),
					new(3567, 2153, 31, ""),
					new(3562, 2152, 26, ""),
					new(3671, 2234, 20, ""),
				}),
				new("Grasses", typeof(Static), 3259, "Hue=0x497", new DecorationEntry[]
				{
					new(3651, 2230, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3316, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3636, 2086, 20, ""),
					new(3602, 2100, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3227, "Hue=0x497", new DecorationEntry[]
				{
					new(3631, 2202, 20, ""),
					new(3666, 2081, 20, ""),
					new(3656, 2253, 20, ""),
					new(3663, 2209, 20, ""),
				}),
				new("Pampas Grass", typeof(Static), 3237, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3726, 2249, 20, ""),
				}),
				new("Stone Wall", typeof(Static), 960, "", new DecorationEntry[]
				{
					new(3663, 2120, 20, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1709, "Facing=SouthCW", new DecorationEntry[]
				{
					new(3695, 2251, 20, ""),
				}),
				new("Sandstone Wall", typeof(Static), 351, "", new DecorationEntry[]
				{
					new(3667, 2246, 20, ""),
					new(3698, 2062, 5, ""),
					new(3735, 2149, 20, ""),
					new(3761, 2141, 23, ""),
					new(3697, 2052, 5, ""),
					new(3709, 2159, 20, ""),
					new(3735, 2151, 20, ""),
					new(3735, 2150, 20, ""),
					new(3735, 2148, 20, ""),
					new(3735, 2146, 20, ""),
					new(3735, 2145, 20, ""),
					new(3735, 2144, 20, ""),
					new(3719, 2139, 20, ""),
					new(3758, 2239, 20, ""),
				}),
				new("Lamp Post", typeof(LampPost3), 2852, "", new DecorationEntry[]
				{
					new(3679, 2261, 21, ""),
					new(3679, 2215, 30, ""),
					new(3679, 2208, 30, ""),
					new(3679, 2137, 20, ""),
					new(3679, 2112, 20, ""),
					new(3672, 2240, 20, ""),
					new(3793, 2232, 20, ""),
					new(3773, 2233, 30, ""),
					new(3735, 2167, 20, ""),
					new(3758, 2256, 30, ""),
					new(3744, 2112, 20, ""),
					new(3743, 2232, 20, ""),
					new(3743, 2215, 20, ""),
					new(3742, 2076, 5, ""),
					new(3711, 2072, 5, ""),
					new(3737, 2076, 5, ""),
					new(3736, 2252, 20, ""),
					new(3736, 2191, 20, ""),
					new(3734, 2087, 5, ""),
					new(3727, 2112, 20, ""),
					new(3727, 2072, 5, ""),
					new(3727, 2055, 5, ""),
					new(3686, 2215, 30, ""),
					new(3719, 2232, 20, ""),
					new(3719, 2208, 20, ""),
					new(3711, 2184, 20, ""),
					new(3711, 2160, 20, ""),
					new(3704, 2136, 20, ""),
					new(3704, 2112, 20, ""),
					new(3704, 2097, 5, ""),
					new(3704, 2048, 5, ""),
					new(3696, 2176, 20, ""),
					new(3695, 2232, 20, ""),
				}),
				new("Elephant Ear Plant", typeof(Static), 3223, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3734, 2260, 20, ""),
					new(3760, 2143, 20, ""),
					new(3658, 2229, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3340, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3752, 2200, 20, ""),
				}),
				new("Ponytail Palm", typeof(Static), 3238, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3763, 2143, 21, ""),
					new(3791, 2087, 20, ""),
					new(3744, 2202, 20, ""),
				}),
				new("Fallen Log", typeof(Static), 3319, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3760, 2044, 20, ""),
				}),
				new("Cannon Ball", typeof(Static), 3699, "", new DecorationEntry[]
				{
					new(3676, 2261, 20, ""),
				}),
				new("Cannon Balls", typeof(Static), 3700, "", new DecorationEntry[]
				{
					new(3673, 2261, 20, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(3710, 2251, 20, ""),
					new(3736, 2067, 5, ""),
					new(3696, 2240, 20, ""),
					new(3670, 2112, 20, ""),
					new(3696, 2160, 20, ""),
					new(3799, 2264, 20, ""),
					new(3691, 2056, 5, ""),
					new(3686, 2254, 20, ""),
					new(3684, 2064, 5, ""),
					new(3680, 2168, 20, ""),
					new(3663, 2192, 20, ""),
					new(3752, 2120, 20, ""),
					new(3656, 2176, 20, ""),
					new(3656, 2118, 20, ""),
					new(3670, 2250, 20, ""),
					new(3800, 2240, 20, ""),
					new(3691, 2071, 5, ""),
					new(3678, 2096, 20, ""),
					new(3787, 2251, 20, ""),
					new(3770, 2104, 20, ""),
					new(3680, 2251, 20, ""),
					new(3779, 2264, 20, ""),
				}),
				new("Water", typeof(Static), 6041, "", new DecorationEntry[]
				{
					new(3696, 2266, -5, ""),
					new(3720, 2020, -5, ""),
					new(3670, 2302, -5, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(3781, 2252, 24, ""),
					new(3680, 2254, 24, ""),
					new(3670, 2236, 20, ""),
					new(3664, 2255, 24, ""),
					new(3656, 2194, 24, ""),
					new(3781, 2251, 24, ""),
					new(3752, 2221, 24, ""),
					new(3699, 2210, 24, ""),
					new(3780, 2267, 26, ""),
					new(3669, 2236, 24, ""),
				}),
				new("Cattails", typeof(Static), 3255, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3736, 2191, 20, ""),
				}),
				new("Fern", typeof(Static), 3235, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3685, 2039, -1, ""),
					new(3656, 2231, 20, ""),
				}),
				new("Tree", typeof(Static), 3419, "Hue=0x497", new DecorationEntry[]
				{
					new(3782, 2143, 21, ""),
					new(3764, 2138, 23, ""),
					new(3656, 2068, 20, ""),
					new(3656, 2243, 20, ""),
					new(3662, 2208, 20, ""),
				}),
				new("Tree", typeof(Static), 3418, "Hue=0x497", new DecorationEntry[]
				{
					new(3781, 2144, 21, ""),
					new(3763, 2139, 23, ""),
					new(3655, 2069, 20, ""),
					new(3655, 2244, 20, ""),
					new(3661, 2209, 20, ""),
				}),
				new("Tree", typeof(Static), 3416, "Hue=0x497", new DecorationEntry[]
				{
					new(3761, 2141, 23, ""),
					new(3779, 2146, 21, ""),
					new(3653, 2071, 20, ""),
					new(3653, 2246, 20, ""),
					new(3659, 2211, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3347, "Hue=0x497", new DecorationEntry[]
				{
					new(3760, 2055, 20, ""),
				}),
				new("Tree", typeof(Static), 3415, "Hue=0x497", new DecorationEntry[]
				{
					new(3778, 2147, 21, ""),
					new(3760, 2142, 21, ""),
					new(3652, 2072, 20, ""),
					new(3652, 2247, 20, ""),
					new(3658, 2212, 20, ""),
				}),
				new("Bulrushes", typeof(Static), 3220, "Hue=0x497", new DecorationEntry[]
				{
					new(3712, 2103, 20, ""),
					new(3750, 2214, 20, ""),
				}),
				new("Fern", typeof(Static), 3231, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3750, 2143, 16, ""),
					new(3680, 2039, 0, ""),
					new(3654, 2249, 20, ""),
					new(3770, 2207, 20, ""),
					new(3769, 2131, 20, ""),
					new(3642, 2091, 20, ""),
					new(3757, 2241, 15, ""),
					new(3777, 2086, 26, ""),
					new(3744, 2189, 20, ""),
					new(3749, 2195, 20, ""),
				}),
				new("Cattails", typeof(Static), 3256, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3626, 2209, 20, ""),
					new(3747, 2186, 9, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3752, 2201, 20, ""),
					new(3731, 2152, 20, ""),
					new(3657, 2255, 20, ""),
					new(3774, 2119, 20, ""),
					new(3754, 2037, 7, ""),
					new(3735, 2246, 20, ""),
				}),
				new("Fern", typeof(Static), 3234, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3779, 2138, 24, ""),
					new(3733, 2259, 20, ""),
					new(3633, 2079, 20, ""),
					new(3639, 2069, 20, ""),
					new(3747, 2201, 20, ""),
					new(3660, 2215, 20, ""),
				}),
				new("Fern", typeof(Static), 3234, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3747, 2064, 6, ""),
					new(3582, 2163, 40, ""),
					new(3728, 2116, 20, ""),
					new(3751, 2250, 14, ""),
					new(3742, 2256, 20, ""),
					new(3637, 2072, 20, ""),
					new(3757, 2040, 20, ""),
				}),
				new("Tree", typeof(Static), 3417, "Hue=0x497", new DecorationEntry[]
				{
					new(3780, 2145, 21, ""),
					new(3762, 2140, 23, ""),
					new(3654, 2070, 20, ""),
					new(3654, 2245, 20, ""),
					new(3660, 2210, 20, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(3671, 2279, -2, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(3662, 2117, 20, ""),
					new(3662, 2116, 20, ""),
					new(3773, 2106, 40, ""),
					new(3773, 2108, 40, ""),
					new(3723, 2084, 5, ""),
					new(3700, 2073, 5, ""),
					new(3692, 2166, 20, ""),
					new(3692, 2164, 20, ""),
				}),
				new("Blade Plant", typeof(Static), 3219, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3692, 2114, 20, ""),
					new(3581, 2158, 47, ""),
					new(3757, 2039, 20, ""),
				}),
				new("Tree", typeof(Static), 3442, "Hue=0x497", new DecorationEntry[]
				{
					new(3578, 2158, 35, ""),
					new(3656, 2053, 20, ""),
					new(3764, 2273, 20, ""),
					new(3668, 2033, 20, ""),
					new(3662, 2033, 20, ""),
					new(3656, 2228, 20, ""),
				}),
				new("Tree", typeof(Static), 3441, "Hue=0x497", new DecorationEntry[]
				{
					new(3577, 2159, 35, ""),
					new(3655, 2054, 20, ""),
					new(3667, 2034, 20, ""),
					new(3763, 2274, 20, ""),
					new(3661, 2034, 20, ""),
					new(3655, 2229, 20, ""),
				}),
				new("Grasses", typeof(Static), 3378, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3758, 2041, 20, ""),
				}),
				new("Tree", typeof(Static), 3440, "Hue=0x497", new DecorationEntry[]
				{
					new(3576, 2160, 35, ""),
					new(3654, 2055, 20, ""),
					new(3666, 2035, 20, ""),
					new(3762, 2275, 20, ""),
					new(3660, 2035, 20, ""),
					new(3654, 2230, 20, ""),
				}),
				new("Dirt", typeof(Static), 7678, "", new DecorationEntry[]
				{
					new(3739, 2145, 20, ""),
					new(3553, 2161, 20, ""),
					new(3545, 2150, 20, ""),
					new(3550, 2149, 22, ""),
					new(3721, 2227, 20, ""),
					new(3563, 2161, 21, ""),
					new(3666, 2183, 20, ""),
					new(3538, 2156, -15, ""),
					new(3564, 2154, 26, ""),
					new(3548, 2137, 20, ""),
					new(3559, 2160, 22, ""),
					new(3547, 2154, 20, ""),
					new(3554, 2146, 23, ""),
					new(3649, 2214, 20, ""),
					new(3554, 2140, 20, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(3680, 2256, 20, ""),
					new(3670, 2279, -2, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(3718, 2249, 20, ""),
					new(3670, 2280, -2, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(3676, 2101, 20, ""),
					new(3721, 2085, 5, ""),
					new(3719, 2085, 5, ""),
					new(3707, 2212, 40, ""),
					new(3705, 2212, 40, ""),
					new(3703, 2212, 40, ""),
					new(3698, 2062, 5, ""),
					new(3697, 2062, 5, ""),
					new(3691, 2167, 20, ""),
				}),
				new("Shell", typeof(Static), 4044, "", new DecorationEntry[]
				{
					new(3715, 2044, 5, ""),
				}),
				new("Pitcher Of Water", typeof(Static), 8093, "", new DecorationEntry[]
				{
					new(3683, 2203, 29, ""),
					new(3770, 2107, 24, ""),
					new(3722, 2228, 24, ""),
					new(3691, 2166, 24, ""),
				}),
				new("Shells", typeof(Static), 4038, "", new DecorationEntry[]
				{
					new(3710, 2021, 0, ""),
				}),
				new("Candelabra", typeof(Static), 2847, "", new DecorationEntry[]
				{
					new(3760, 2118, 24, ""),
					new(3691, 2165, 31, ""),
				}),
				new("Nautilus", typeof(Static), 4039, "", new DecorationEntry[]
				{
					new(3702, 2027, 1, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(3676, 2098, 20, ""),
					new(3719, 2082, 5, ""),
					new(3697, 2060, 5, ""),
					new(3721, 2082, 5, ""),
					new(3707, 2210, 40, ""),
					new(3705, 2210, 40, ""),
					new(3703, 2210, 40, ""),
					new(3701, 2152, 20, ""),
					new(3699, 2056, 5, ""),
					new(3698, 2060, 5, ""),
					new(3694, 2056, 5, ""),
					new(3691, 2162, 20, ""),
					new(3691, 2152, 20, ""),
				}),
				new("Conch Shell", typeof(Static), 4036, "", new DecorationEntry[]
				{
					new(3687, 2039, -1, ""),
				}),
				new("Fitting", typeof(Static), 4399, "", new DecorationEntry[]
				{
					new(3560, 2163, 20, ""),
					new(3550, 2166, 20, ""),
					new(3546, 2149, 20, ""),
					new(3659, 2219, 20, ""),
					new(3557, 2145, 23, ""),
					new(3556, 2141, 21, ""),
				}),
				new("Metal Box", typeof(MetalBox), 2472, "", new DecorationEntry[]
				{
					new(3671, 2280, 4, ""),
				}),
				new("Garbage", typeof(Static), 4335, "", new DecorationEntry[]
				{
					new(3662, 2288, 0, ""),
					new(3655, 2282, -2, ""),
					new(3680, 2029, -5, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4338, "", new DecorationEntry[]
				{
					new(3549, 2140, 20, ""),
					new(3656, 2280, -1, ""),
					new(3679, 2029, -3, ""),
				}),
				new("Fern", typeof(Static), 3231, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3778, 2119, 20, ""),
					new(3627, 2203, 20, ""),
					new(3777, 2144, 20, ""),
					new(3603, 2176, 22, ""),
					new(3747, 2200, 20, ""),
					new(3583, 2165, 30, ""),
				}),
				new("Fern", typeof(Static), 3236, "Hue=0x497", new DecorationEntry[]
				{
					new(3626, 2201, 20, ""),
					new(3581, 2163, 37, ""),
					new(3589, 2149, 61, ""),
					new(3656, 2059, 20, ""),
					new(3655, 2227, 20, ""),
					new(3762, 2207, 20, ""),
					new(3681, 2041, 0, ""),
				}),
				new("Grasses", typeof(Static), 3379, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3679, 2032, -3, ""),
				}),
				new("Grasses", typeof(Static), 3247, "Hue=0x497", new DecorationEntry[]
				{
					new(3780, 2140, 22, ""),
					new(3698, 2138, 20, ""),
					new(3673, 2042, 20, ""),
				}),
				new("Rock", typeof(Static), 6004, "", new DecorationEntry[]
				{
					new(3624, 2209, 20, ""),
					new(3618, 2182, 21, ""),
					new(3633, 2199, 20, ""),
					new(3735, 2125, 20, ""),
					new(3779, 2138, 24, ""),
					new(3772, 2144, 16, ""),
					new(3648, 2066, 20, ""),
					new(3733, 2251, 20, ""),
					new(3633, 2080, 8, ""),
					new(3765, 2058, 10, ""),
					new(3677, 2038, 20, ""),
					new(3681, 2040, 0, ""),
				}),
				new("Fern", typeof(Static), 3236, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3749, 2129, 20, ""),
					new(3666, 2072, 20, ""),
					new(3675, 2030, 20, ""),
				}),
				new("Milk", typeof(Static), 2544, "", new DecorationEntry[]
				{
					new(3770, 2107, 24, ""),
					new(3691, 2166, 24, ""),
					new(3722, 2228, 24, ""),
					new(3683, 2203, 29, ""),
					new(3671, 2282, 4, ""),
				}),
				new("Table", typeof(Static), 2937, "", new DecorationEntry[]
				{
					new(3671, 2280, -2, ""),
				}),
				new("Table", typeof(Static), 2938, "", new DecorationEntry[]
				{
					new(3734, 2119, 20, ""),
					new(3680, 2163, 20, ""),
					new(3679, 2044, 20, ""),
					new(3716, 2131, 20, ""),
					new(3748, 2221, 20, ""),
					new(3761, 2211, 20, ""),
					new(3754, 2231, 20, ""),
					new(3671, 2281, -2, ""),
				}),
				new("Table", typeof(Static), 2933, "", new DecorationEntry[]
				{
					new(3712, 2222, 20, ""),
					new(3682, 2237, 20, ""),
					new(3729, 2125, 20, ""),
					new(3671, 2282, -2, ""),
				}),
				new("Elephant Ear Plant", typeof(Static), 3223, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3578, 2165, 22, ""),
					new(3651, 2250, 20, ""),
					new(3757, 2201, 20, ""),
				}),
				new("Fern", typeof(Static), 3232, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3785, 2114, 20, ""),
					new(3654, 2254, 20, ""),
					new(3646, 2080, 20, ""),
					new(3639, 2217, 20, ""),
				}),
				new("Bed", typeof(Static), 2653, "", new DecorationEntry[]
				{
					new(3665, 2268, 21, ""),
					new(3665, 2266, 21, ""),
				}),
				new("Bed", typeof(Static), 2658, "", new DecorationEntry[]
				{
					new(3666, 2268, 21, ""),
					new(3666, 2266, 21, ""),
					new(3666, 2264, 21, ""),
				}),
				new("Bed", typeof(Static), 2665, "", new DecorationEntry[]
				{
					new(3665, 2264, 21, ""),
				}),
				new("Bed", typeof(Static), 2655, "", new DecorationEntry[]
				{
					new(3694, 2204, 20, ""),
					new(3669, 2263, 21, ""),
				}),
				new("Bed", typeof(Static), 2654, "", new DecorationEntry[]
				{
					new(3669, 2262, 21, ""),
				}),
				new("Small Palm", typeof(Static), 3225, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3731, 2256, 20, ""),
					new(3674, 2031, 20, ""),
				}),
				new("Dirt", typeof(Static), 7680, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3559, 2159, 22, ""),
					new(3672, 2236, 20, ""),
					new(3538, 2136, 20, ""),
					new(3539, 2148, 20, ""),
					new(3699, 2181, 20, ""),
					new(3551, 2137, 20, ""),
					new(3557, 2155, 24, ""),
					new(3551, 2162, 20, ""),
					new(3557, 2141, 24, ""),
				}),
				new("Leather Sleeves", typeof(Static), 5064, "", new DecorationEntry[]
				{
					new(3666, 2261, 20, ""),
				}),
				new("Grasses", typeof(Static), 3254, "Hue=0x497", new DecorationEntry[]
				{
					new(3679, 2074, 13, ""),
					new(3584, 2152, 60, ""),
					new(3663, 2036, 20, ""),
				}),
				new("Leather Leggings", typeof(Static), 5065, "", new DecorationEntry[]
				{
					new(3669, 2261, 20, ""),
				}),
				new("Leather Tunic", typeof(Static), 5066, "", new DecorationEntry[]
				{
					new(3670, 2261, 20, ""),
				}),
				new("Stone Ruins", typeof(Static), 951, "", new DecorationEntry[]
				{
					new(3712, 2229, 20, ""),
					new(3716, 2219, 20, ""),
					new(3674, 2211, 20, ""),
					new(3756, 2051, 12, ""),
					new(3700, 2052, 5, ""),
					new(3687, 2213, 20, ""),
					new(3676, 2163, 20, ""),
					new(3683, 2202, 20, ""),
					new(3687, 2207, 20, ""),
					new(3687, 2057, 5, ""),
					new(3734, 2154, 20, ""),
					new(3721, 2140, 20, ""),
					new(3728, 2115, 20, ""),
					new(3688, 2093, 20, ""),
					new(3675, 2089, 20, ""),
					new(3734, 2051, 5, ""),
					new(3657, 2168, 20, ""),
					new(3659, 2121, 20, ""),
					new(3670, 2197, 20, ""),
					new(3652, 2138, 24, ""),
					new(3669, 2232, 20, ""),
					new(3724, 2202, 20, ""),
					new(3759, 2232, 20, ""),
					new(3753, 2234, 20, ""),
					new(3699, 2224, 20, ""),
					new(3726, 2230, 20, ""),
					new(3753, 2204, 20, ""),
					new(3704, 2174, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3225, "Hue=0x497", new DecorationEntry[]
				{
					new(3689, 2115, 20, ""),
					new(3674, 2029, 20, ""),
					new(3671, 2034, 20, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3763, 2077, 38, ""),
					new(3770, 2071, 22, ""),
					new(3672, 2029, -15, ""),
				}),
				new("Cannon", typeof(Static), 3734, "", new DecorationEntry[]
				{
					new(3699, 2257, 20, ""),
				}),
				new("Bushel", typeof(Basket), 2476, "", new DecorationEntry[]
				{
					new(3684, 2269, 20, ""),
					new(3686, 2268, 20, ""),
				}),
				new("Cannon", typeof(Static), 3733, "", new DecorationEntry[]
				{
					new(3698, 2257, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3229, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3664, 2039, 20, ""),
				}),
				new("Cannon", typeof(Static), 3725, "", new DecorationEntry[]
				{
					new(3677, 2259, 20, ""),
					new(3673, 2259, 20, ""),
				}),
				new("Cannon", typeof(Static), 3724, "", new DecorationEntry[]
				{
					new(3677, 2260, 20, ""),
					new(3673, 2260, 20, ""),
				}),
				new("Fern", typeof(Static), 3232, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3656, 2082, 20, ""),
					new(3603, 2153, 56, ""),
				}),
				new("Cannon", typeof(Static), 3723, "", new DecorationEntry[]
				{
					new(3677, 2261, 20, ""),
					new(3673, 2261, 20, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "Hue=0x497", new DecorationEntry[]
				{
					new(3621, 2187, 8, ""),
					new(3559, 2138, 25, ""),
					new(3642, 2084, 20, ""),
					new(3664, 2037, 20, ""),
				}),
				new("Clock Parts", typeof(Static), 4176, "", new DecorationEntry[]
				{
					new(3723, 2131, 24, ""),
					new(3722, 2131, 24, ""),
					new(3718, 2123, 24, ""),
					new(3714, 2126, 24, ""),
				}),
				new("Fern", typeof(Static), 3235, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3688, 2121, 20, ""),
					new(3777, 2144, 20, ""),
					new(3678, 2062, 14, ""),
					new(3638, 2111, 31, ""),
					new(3654, 2251, 20, ""),
					new(3795, 2091, 20, ""),
					new(3772, 2257, 20, ""),
					new(3775, 2074, 20, ""),
					new(3633, 2079, 20, ""),
					new(3747, 2198, 20, ""),
					new(3630, 2200, 20, ""),
				}),
				new("Candle", typeof(Static), 2843, "", new DecorationEntry[]
				{
					new(3681, 2184, 28, ""),
					new(3664, 2253, 26, ""),
					new(3715, 2090, 13, ""),
					new(3696, 2152, 28, ""),
					new(3691, 2184, 28, ""),
					new(3690, 2248, 28, ""),
				}),
				new("Grasses", typeof(Static), 3244, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3796, 2150, 22, ""),
					new(3675, 2036, 20, ""),
				}),
				new("Globe", typeof(Static), 4167, "", new DecorationEntry[]
				{
					new(3664, 2256, 20, ""),
				}),
				new("Wooden Ladder", typeof(Static), 2211, "", new DecorationEntry[]
				{
					new(3682, 2231, 31, ""),
					new(3670, 2185, 31, ""),
					new(3676, 2229, 43, ""),
					new(3675, 2229, 43, ""),
				}),
				new("Fern", typeof(Static), 3234, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3758, 2213, 20, ""),
					new(3779, 2144, 20, ""),
					new(3646, 2075, 20, ""),
					new(3655, 2059, 20, ""),
					new(3659, 2212, 20, ""),
					new(3739, 2188, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3340, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3671, 2036, 20, ""),
				}),
				new("Book", typeof(Static), 4084, "", new DecorationEntry[]
				{
					new(3664, 2254, 24, ""),
					new(3703, 2211, 44, ""),
					new(3664, 2252, 24, ""),
				}),
				new("Fern", typeof(Static), 3232, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3735, 2076, 5, ""),
					new(3624, 2187, 21, ""),
					new(3747, 2147, -15, ""),
					new(3669, 2039, 20, ""),
					new(3655, 2067, 20, ""),
					new(3640, 2216, 20, ""),
					new(3667, 2038, 20, ""),
				}),
				new("", typeof(Static), 16384, "", new DecorationEntry[]
				{
					new(3680, 2281, -5, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3630, 2192, 20, ""),
					new(3651, 2063, 20, ""),
					new(3629, 2203, 20, ""),
					new(3626, 2200, 20, ""),
					new(3673, 2032, 20, ""),
				}),
				new("Wooden Ladder", typeof(Static), 2212, "", new DecorationEntry[]
				{
					new(3682, 2232, 20, ""),
					new(3670, 2186, 20, ""),
					new(3676, 2230, 31, ""),
					new(3676, 2231, 20, ""),
					new(3675, 2230, 20, ""),
					new(3675, 2231, 20, ""),
				}),
				new("Grasses", typeof(Static), 3378, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3732, 2170, 20, ""),
					new(3642, 2076, 20, ""),
					new(3578, 2170, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3348, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3671, 2033, 20, ""),
					new(3664, 2036, 20, ""),
				}),
				new("Fern", typeof(Static), 3232, "Hue=0x497", new DecorationEntry[]
				{
					new(3606, 2163, 43, ""),
					new(3656, 2057, 20, ""),
					new(3718, 2128, 20, ""),
					new(3676, 2036, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3346, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3663, 2037, 20, ""),
				}),
				new("Fan Plant", typeof(Static), 3224, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3653, 2080, 20, ""),
					new(3756, 2042, 20, ""),
					new(3663, 2036, 20, ""),
				}),
				new("Fern", typeof(Static), 3236, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3574, 2167, 20, ""),
					new(3655, 2247, 20, ""),
					new(3650, 2059, 20, ""),
					new(3749, 2197, 20, ""),
					new(3662, 2035, 20, ""),
				}),
				new("Fern", typeof(Static), 3232, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3693, 2093, 9, ""),
					new(3635, 2073, 20, ""),
					new(3755, 2233, 20, ""),
					new(3655, 2035, 20, ""),
				}),
				new("Fern", typeof(Static), 3234, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3762, 2076, 38, ""),
					new(3628, 2114, 36, ""),
					new(3651, 2246, 11, ""),
					new(3660, 2064, 20, ""),
					new(3757, 2042, 20, ""),
					new(3668, 2043, 20, ""),
					new(3670, 2035, 20, ""),
					new(3585, 2149, 61, ""),
				}),
				new("Pampas Grass", typeof(Static), 3268, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3656, 2039, 20, ""),
				}),
				new("Dirt", typeof(Static), 7680, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3656, 2137, 20, ""),
					new(3530, 2139, -15, ""),
					new(3662, 2149, 20, ""),
					new(3672, 2201, 20, ""),
					new(3544, 2143, 20, ""),
					new(3535, 2147, 20, ""),
					new(3691, 2170, 20, ""),
					new(3548, 2161, 20, ""),
				}),
				new("Blade Plant", typeof(Static), 3219, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3778, 2101, 20, ""),
					new(3656, 2037, 20, ""),
				}),
				new("Sapling", typeof(Static), 3305, "Hue=0x497", new DecorationEntry[]
				{
					new(3655, 2041, 20, ""),
				}),
				new("Rock", typeof(Static), 6003, "", new DecorationEntry[]
				{
					new(3628, 2199, 20, ""),
					new(3596, 2175, 21, ""),
					new(3663, 2167, 20, ""),
					new(3655, 2087, 20, ""),
					new(3655, 2255, 19, ""),
					new(3582, 2156, 51, ""),
					new(3652, 2043, 20, ""),
				}),
				new("Elephant Ear Plant", typeof(Static), 3223, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3757, 2045, 20, ""),
					new(3653, 2040, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3227, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3646, 2070, 20, ""),
					new(3780, 2270, 20, ""),
					new(3637, 2091, 20, ""),
					new(3712, 2147, 20, ""),
					new(3656, 2227, 20, ""),
					new(3639, 2196, 20, ""),
					new(3650, 2050, 20, ""),
				}),
				new("Fern", typeof(Static), 3236, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3664, 2164, 20, ""),
					new(3684, 2060, 5, ""),
					new(3770, 2069, 22, ""),
					new(3669, 2034, 20, ""),
					new(3663, 2035, 20, ""),
					new(3647, 2043, 20, ""),
				}),
				new("Mushroom", typeof(Static), 3350, "Hue=0x497", new DecorationEntry[]
				{
					new(3650, 2044, 20, ""),
				}),
				new("Stone Ruins", typeof(Static), 964, "", new DecorationEntry[]
				{
					new(3739, 2079, 5, ""),
					new(3734, 2082, 5, ""),
					new(3709, 2150, 20, ""),
					new(3684, 2254, 20, ""),
					new(3731, 2175, 20, ""),
					new(3706, 2237, 20, ""),
					new(3662, 2150, 20, ""),
					new(3673, 2174, 20, ""),
					new(3673, 2206, 20, ""),
					new(3686, 2062, 5, ""),
					new(3669, 2245, 20, ""),
					new(3681, 2237, 20, ""),
					new(3684, 2060, 5, ""),
					new(3724, 2125, 20, ""),
					new(3667, 2213, 31, ""),
					new(3775, 2125, 20, ""),
					new(3660, 2257, 20, ""),
					new(3662, 2247, 20, ""),
					new(3737, 2162, 20, ""),
					new(3665, 2119, 20, ""),
					new(3718, 2187, 20, ""),
					new(3696, 2199, 20, ""),
					new(3772, 2129, 20, ""),
					new(3733, 2121, 20, ""),
					new(3722, 2205, 20, ""),
					new(3717, 2075, 5, ""),
					new(3700, 2172, 20, ""),
					new(3708, 2195, 20, ""),
					new(3666, 2196, 20, ""),
					new(3684, 2138, 20, ""),
				}),
				new("Rock", typeof(Static), 6008, "", new DecorationEntry[]
				{
					new(3804, 2146, 13, ""),
					new(3627, 2193, 20, ""),
					new(3761, 2275, 15, ""),
					new(3802, 2113, 16, ""),
					new(3694, 2128, 20, ""),
					new(3743, 2069, 5, ""),
					new(3654, 2066, 20, ""),
					new(3768, 2262, 20, ""),
					new(3655, 2084, 20, ""),
					new(3756, 2195, 20, ""),
					new(3653, 2038, 20, ""),
				}),
				new("Fern", typeof(Static), 3231, "Hue=0x497", new DecorationEntry[]
				{
					new(3788, 2085, 20, ""),
					new(3781, 2270, 20, ""),
					new(3645, 2066, 20, ""),
					new(3643, 2074, 20, ""),
					new(3646, 2038, -15, ""),
				}),
				new("Dirt", typeof(Static), 7679, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3689, 2165, 20, ""),
					new(3558, 2164, 20, ""),
					new(3554, 2152, 24, ""),
					new(3538, 2147, 20, ""),
					new(3565, 2154, 27, ""),
				}),
				new("Garbage", typeof(Static), 4336, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3736, 2200, 20, ""),
					new(3540, 2144, 20, ""),
					new(3555, 2152, 24, ""),
				}),
				new("Stone Ruins", typeof(Static), 963, "", new DecorationEntry[]
				{
					new(3704, 2186, 20, ""),
					new(3771, 2129, 20, ""),
					new(3732, 2054, 5, ""),
					new(3681, 2161, 20, ""),
					new(3662, 2120, 20, ""),
					new(3701, 2171, 20, ""),
					new(3702, 2180, 20, ""),
					new(3704, 2185, 20, ""),
					new(3708, 2085, 5, ""),
					new(3666, 2212, 20, ""),
					new(3665, 2119, 20, ""),
					new(3693, 2174, 20, ""),
					new(3685, 2220, 20, ""),
					new(3715, 2134, 20, ""),
					new(3688, 2230, 20, ""),
					new(3730, 2132, 20, ""),
					new(3690, 2169, 20, ""),
					new(3706, 2188, 20, ""),
					new(3729, 2124, 20, ""),
					new(3728, 2071, 5, ""),
					new(3703, 2181, 20, ""),
					new(3667, 2123, 20, ""),
					new(3786, 2091, 21, ""),
					new(3649, 2229, 14, ""),
					new(3706, 2247, 20, ""),
					new(3713, 2043, 7, ""),
					new(3700, 2193, 20, ""),
				}),
				new("Garbage", typeof(Static), 4337, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3565, 2159, 22, ""),
					new(3556, 2155, 23, ""),
					new(3720, 2226, 20, ""),
					new(3699, 2223, 20, ""),
					new(3548, 2163, 20, ""),
				}),
				new("Sapling", typeof(Static), 3306, "Hue=0x3D8", new DecorationEntry[]
				{
					new(3707, 2119, 20, ""),
				}),
				new("Dirt", typeof(Static), 7679, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3560, 2152, 26, ""),
					new(3652, 2141, 29, ""),
					new(3560, 2157, 23, ""),
					new(3549, 2154, 21, ""),
					new(3555, 2143, 22, ""),
					new(3662, 2256, 20, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(3659, 2117, 20, ""),
					new(3659, 2116, 20, ""),
					new(3717, 2084, 5, ""),
					new(3701, 2211, 40, ""),
					new(3698, 2073, 5, ""),
					new(3689, 2166, 20, ""),
					new(3689, 2164, 20, ""),
				}),
				new("Tree", typeof(Static), 3439, "Hue=0x497", new DecorationEntry[]
				{
					new(3575, 2161, 26, ""),
					new(3653, 2056, 20, ""),
					new(3665, 2036, 20, ""),
					new(3761, 2276, 20, ""),
					new(3659, 2036, 20, ""),
					new(3653, 2231, 20, ""),
				}),
				new("Tree", typeof(Static), 3438, "Hue=0x497", new DecorationEntry[]
				{
					new(3574, 2162, 22, ""),
					new(3652, 2057, 20, ""),
					new(3664, 2037, 20, ""),
					new(3760, 2277, 20, ""),
					new(3658, 2037, 20, ""),
					new(3652, 2232, 20, ""),
				}),
				new("Garbage", typeof(Static), 4337, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3649, 2154, 39, ""),
					new(3637, 2181, 30, ""),
					new(3550, 2158, 21, ""),
					new(3567, 2151, 38, ""),
					new(3541, 2150, 20, ""),
					new(3695, 2220, 20, ""),
					new(3562, 2164, 20, ""),
				}),
				new("Small Palm", typeof(Static), 3229, "Hue=0x3D9", new DecorationEntry[]
				{
					new(3749, 2202, 20, ""),
					new(3657, 2057, 20, ""),
					new(3582, 2160, 44, ""),
					new(3570, 2147, 46, ""),
					new(3641, 2064, 10, ""),
					new(3748, 2195, 20, ""),
					new(3642, 2209, 20, ""),
					new(3722, 2145, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(3681, 2204, 20, ""),
					new(3681, 2202, 20, ""),
					new(3688, 2193, 20, ""),
					new(3688, 2197, 20, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4338, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3555, 2163, 20, ""),
					new(3553, 2143, 21, ""),
					new(3550, 2159, 21, ""),
				}),
				new("Wooden Ramp", typeof(Static), 2173, "", new DecorationEntry[]
				{
					new(3677, 2229, 20, ""),
					new(3674, 2229, 20, ""),
				}),
				new("Dirt Patch", typeof(Static), 2321, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3601, 2165, 39, ""),
					new(3552, 2154, 23, ""),
					new(3554, 2159, 22, ""),
					new(3554, 2154, 24, ""),
					new(3560, 2167, 20, ""),
				}),
				new("Garbage", typeof(Static), 4336, "Hue=0x497", new DecorationEntry[]
				{
					new(3550, 2148, 22, ""),
					new(3529, 2145, -15, ""),
					new(3653, 2245, 20, ""),
					new(3552, 2143, 21, ""),
					new(3549, 2140, 20, ""),
					new(3537, 2141, 20, ""),
					new(3671, 2154, 20, ""),
					new(3550, 2144, 21, ""),
					new(3565, 2154, 27, ""),
					new(3564, 2153, 27, ""),
					new(3559, 2167, 14, ""),
					new(3561, 2157, 23, ""),
					new(3541, 2141, 20, ""),
					new(3672, 2194, 20, ""),
					new(3560, 2156, 23, ""),
					new(3553, 2155, 23, ""),
					new(3566, 2160, 22, ""),
					new(3553, 2142, 21, ""),
					new(3557, 2142, 24, ""),
					new(3547, 2159, 20, ""),
				}),
				new("Wooden Ladder", typeof(Static), 2210, "", new DecorationEntry[]
				{
					new(3656, 2234, 31, ""),
					new(3656, 2235, 20, ""),
				}),
				new("Rope", typeof(Static), 5368, "", new DecorationEntry[]
				{
					new(3663, 2269, 20, ""),
					new(3686, 2261, 21, ""),
					new(3678, 2292, -3, ""),
				}),
				new("Tree", typeof(Static), 3462, "Hue=0x497", new DecorationEntry[]
				{
					new(3655, 2049, 20, ""),
					new(3649, 2074, 20, ""),
					new(3625, 2204, 7, ""),
				}),
				new("Tree", typeof(Static), 3460, "Hue=0x497", new DecorationEntry[]
				{
					new(3653, 2051, 20, ""),
					new(3647, 2076, 20, ""),
					new(3623, 2206, -5, ""),
				}),
				new("Tree", typeof(Static), 3461, "Hue=0x497", new DecorationEntry[]
				{
					new(3654, 2050, 20, ""),
					new(3648, 2075, 20, ""),
					new(3624, 2205, 7, ""),
				}),
				new("Stone Ruins", typeof(Static), 965, "", new DecorationEntry[]
				{
					new(3739, 2057, 5, ""),
					new(3747, 2069, 5, ""),
					new(3745, 2208, 20, ""),
					new(3710, 2055, 5, ""),
					new(3728, 2204, 20, ""),
					new(3737, 2110, 20, ""),
					new(3674, 2142, 20, ""),
					new(3669, 2119, 20, ""),
					new(3660, 2235, 20, ""),
					new(3692, 2194, 20, ""),
					new(3683, 2195, 20, ""),
					new(3689, 2209, 20, ""),
					new(3682, 2122, 20, ""),
					new(3722, 2077, 5, ""),
					new(3716, 2165, 20, ""),
					new(3703, 2185, 20, ""),
					new(3714, 2225, 20, ""),
					new(3708, 2254, 20, ""),
					new(3700, 2171, 20, ""),
					new(3680, 2183, 20, ""),
					new(3768, 2211, 20, ""),
					new(3685, 2252, 20, ""),
					new(3693, 2159, 20, ""),
				}),
				new("Mushrooms", typeof(Static), 3343, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3736, 2204, 20, ""),
				}),
				new("Palisade", typeof(Static), 1059, "", new DecorationEntry[]
				{
					new(3681, 2199, 20, ""),
					new(3644, 2184, 21, ""),
					new(3657, 2228, 20, ""),
					new(3653, 2225, 20, ""),
				}),
				new("Garbage", typeof(Static), 4337, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3537, 2145, 20, ""),
					new(3698, 2181, 20, ""),
					new(3561, 2153, 26, ""),
					new(3683, 2215, 20, ""),
					new(3546, 2143, 20, ""),
					new(3555, 2154, 24, ""),
					new(3557, 2145, 23, ""),
					new(3535, 2139, 20, ""),
					new(3547, 2142, 20, ""),
					new(3759, 2213, 20, ""),
					new(3562, 2153, 26, ""),
				}),
				new("Garbage", typeof(Static), 4336, "", new DecorationEntry[]
				{
					new(3555, 2161, 21, ""),
					new(3552, 2159, 21, ""),
					new(3539, 2151, 20, ""),
					new(3563, 2168, 20, ""),
					new(3546, 2135, 20, ""),
					new(3646, 2221, 20, ""),
					new(3655, 2195, 20, ""),
					new(3537, 2144, 20, ""),
					new(3545, 2145, 20, ""),
					new(3691, 2140, 20, ""),
					new(3555, 2157, 23, ""),
					new(3557, 2143, 23, ""),
					new(3722, 2151, 20, ""),
					new(3535, 2142, 20, ""),
					new(3538, 2136, 20, ""),
					new(3560, 2157, 23, ""),
					new(3548, 2165, 11, ""),
					new(3549, 2164, 20, ""),
					new(3552, 2154, 23, ""),
				}),
				new("Grasses", typeof(Static), 3253, "Hue=0x497", new DecorationEntry[]
				{
					new(3793, 2122, 26, ""),
					new(3696, 2051, 5, ""),
				}),
				new("Dirt Patch", typeof(Static), 2322, "Hue=0x497", new DecorationEntry[]
				{
					new(3547, 2141, 20, ""),
					new(3559, 2160, 22, ""),
					new(3637, 2149, 51, ""),
					new(3712, 2226, 20, ""),
					new(3687, 2186, 20, ""),
					new(3535, 2148, 20, ""),
					new(3560, 2158, 23, ""),
				}),
				new("Bench", typeof(Static), 2919, "", new DecorationEntry[]
				{
					new(3727, 2217, 20, ""),
				}),
				new("Stone Ruins", typeof(Static), 953, "", new DecorationEntry[]
				{
					new(3668, 2121, 20, ""),
					new(3690, 2060, 5, ""),
					new(3786, 2107, 20, ""),
					new(3708, 2238, 20, ""),
					new(3729, 2177, 20, ""),
					new(3726, 2165, 20, ""),
					new(3732, 2134, 20, ""),
					new(3723, 2165, 20, ""),
					new(3730, 2125, 20, ""),
					new(3706, 2051, 5, ""),
					new(3722, 2162, 20, ""),
					new(3661, 2253, 20, ""),
					new(3660, 2122, 20, ""),
					new(3734, 2050, 5, ""),
					new(3657, 2254, 20, ""),
					new(3711, 2231, 20, ""),
					new(3765, 2223, 20, ""),
					new(3725, 2167, 20, ""),
					new(3663, 2239, 20, ""),
					new(3703, 2070, 5, ""),
					new(3779, 2102, 20, ""),
					new(3773, 2217, 20, ""),
					new(3694, 2174, 20, ""),
					new(3752, 2246, 20, ""),
				}),
				new("Garbage", typeof(Static), 4336, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3536, 2142, 20, ""),
					new(3549, 2141, 20, ""),
					new(3557, 2163, 20, ""),
					new(3632, 2183, 23, ""),
					new(3551, 2141, 21, ""),
					new(3545, 2144, 20, ""),
					new(3555, 2153, 24, ""),
					new(3734, 2228, 20, ""),
					new(3686, 2180, 20, ""),
					new(3700, 2229, 20, ""),
					new(3689, 2216, 20, ""),
					new(3567, 2113, 20, ""),
				}),
				new("Stretched Hide", typeof(Static), 4203, "", new DecorationEntry[]
				{
					new(3718, 2228, 20, ""),
				}),
				new("Dirt", typeof(Static), 7680, "", new DecorationEntry[]
				{
					new(3607, 2158, 57, ""),
					new(3554, 2162, 20, ""),
					new(3634, 2150, 58, ""),
					new(3606, 2168, 36, ""),
					new(3563, 2168, 20, ""),
					new(3566, 2146, 37, ""),
					new(3540, 2141, 20, ""),
					new(3662, 2147, 20, ""),
					new(3543, 2138, 20, ""),
					new(3566, 2163, 21, ""),
					new(3549, 2166, 20, ""),
					new(3540, 2138, 24, ""),
					new(3721, 2147, 20, ""),
					new(3567, 2154, 28, ""),
					new(3567, 2148, 37, ""),
					new(3701, 2254, 20, ""),
					new(3531, 2145, 7, ""),
					new(3709, 2190, 20, ""),
					new(3554, 2136, 20, ""),
					new(3559, 2152, 26, ""),
					new(3547, 2141, 20, ""),
					new(3555, 2156, 23, ""),
					new(3557, 2159, 22, ""),
					new(3562, 2154, 26, ""),
					new(3536, 2140, 20, ""),
					new(3693, 2225, 20, ""),
					new(3563, 2136, 27, ""),
					new(3536, 2141, 20, ""),
					new(3549, 2158, 21, ""),
					new(3553, 2160, 21, ""),
					new(3612, 2148, 67, ""),
					new(3567, 2162, 21, ""),
					new(3552, 2141, 21, ""),
					new(3554, 2149, 25, ""),
					new(3679, 2141, 20, ""),
				}),
				new("Rocks", typeof(Static), 4967, "", new DecorationEntry[]
				{
					new(3710, 2254, 20, ""),
				}),
				new("Table", typeof(Static), 2953, "", new DecorationEntry[]
				{
					new(3703, 2233, 20, ""),
					new(3703, 2124, 20, ""),
				}),
				new("Gang Plank", typeof(Static), 16085, "", new DecorationEntry[]
				{
					new(3678, 2281, -5, ""),
				}),
				new("Stone Ruins", typeof(Static), 959, "", new DecorationEntry[]
				{
					new(3681, 2165, 20, ""),
					new(3707, 2188, 20, ""),
					new(3669, 2219, 20, ""),
					new(3682, 2251, 20, ""),
					new(3704, 2191, 20, ""),
					new(3674, 2137, 20, ""),
					new(3701, 2166, 20, ""),
					new(3715, 2227, 20, ""),
					new(3714, 2180, 20, ""),
					new(3686, 2169, 20, ""),
					new(3699, 2189, 18, ""),
					new(3686, 2208, 20, ""),
					new(3670, 2153, 20, ""),
					new(3684, 2213, 20, ""),
					new(3738, 2163, 20, ""),
					new(3679, 2207, 20, ""),
					new(3666, 2205, 20, ""),
					new(3788, 2109, 25, ""),
					new(3695, 2201, 20, ""),
					new(3735, 2122, 20, ""),
					new(3739, 2081, 5, ""),
					new(3732, 2121, 20, ""),
					new(3760, 2228, 20, ""),
					new(3671, 2120, 20, ""),
					new(3763, 2229, 20, ""),
					new(3722, 2073, 5, ""),
					new(3767, 2223, 20, ""),
					new(3707, 2180, 20, ""),
				}),
				new("Tiller Man", typeof(Static), 15950, "", new DecorationEntry[]
				{
					new(3681, 2285, -5, ""),
				}),
				new("Fern", typeof(Static), 3236, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3655, 2251, 20, ""),
					new(3662, 2077, 20, ""),
					new(3658, 2048, 20, ""),
					new(3666, 2215, 20, ""),
					new(3647, 2228, 15, ""),
				}),
				new("Dirt Patch", typeof(Static), 2321, "Hue=0x497", new DecorationEntry[]
				{
					new(3735, 2153, 20, ""),
					new(3543, 2142, 20, ""),
					new(3704, 2220, 20, ""),
					new(3547, 2141, 20, ""),
					new(3547, 2162, 8, ""),
					new(3549, 2158, 21, ""),
					new(3662, 2239, 20, ""),
					new(3552, 2137, 20, ""),
					new(3720, 2242, 20, ""),
					new(3534, 2145, 20, ""),
					new(3561, 2158, 23, ""),
					new(3597, 2163, 43, ""),
					new(3554, 2149, 25, ""),
					new(3706, 2246, 20, ""),
					new(3553, 2157, 22, ""),
				}),
				new("Garbage", typeof(Static), 4336, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3753, 2137, 21, ""),
					new(3547, 2164, -15, ""),
					new(3708, 2223, 20, ""),
					new(3593, 2151, 56, ""),
					new(3545, 2141, 20, ""),
					new(3550, 2158, 21, ""),
				}),
				new("Stone Ruins", typeof(Static), 955, "", new DecorationEntry[]
				{
					new(3657, 2120, 20, ""),
					new(3705, 2149, 20, ""),
					new(3691, 2261, 20, ""),
					new(3645, 2178, 31, ""),
					new(3680, 2248, 20, ""),
					new(3721, 2224, 20, ""),
					new(3658, 2142, 20, ""),
					new(3668, 2222, 20, ""),
					new(3769, 2083, 29, ""),
					new(3669, 2120, 20, ""),
					new(3727, 2167, 20, ""),
					new(3662, 2123, 20, ""),
					new(3679, 2235, 20, ""),
					new(3682, 2254, 20, ""),
					new(3731, 2078, 5, ""),
					new(3677, 2100, 20, ""),
					new(3714, 2228, 20, ""),
					new(3734, 2053, 5, ""),
					new(3658, 2255, 20, ""),
					new(3771, 2120, 20, ""),
					new(3726, 2095, 5, ""),
					new(3734, 2098, 20, ""),
					new(3711, 2196, 20, ""),
					new(3722, 2166, 20, ""),
					new(3761, 2227, 20, ""),
					new(3726, 2173, 20, ""),
					new(3700, 2223, 20, ""),
					new(3763, 2233, 20, ""),
					new(3723, 2076, 5, ""),
					new(3766, 2221, 20, ""),
					new(3691, 2248, 20, ""),
					new(3696, 2171, 20, ""),
				}),
				new("Stretched Hide", typeof(Static), 4205, "", new DecorationEntry[]
				{
					new(3692, 2142, 20, ""),
					new(3649, 2158, 45, ""),
					new(3649, 2154, 37, ""),
				}),
				new("Stone Ruins", typeof(Static), 954, "", new DecorationEntry[]
				{
					new(3752, 2069, 24, ""),
					new(3714, 2169, 20, ""),
					new(3787, 2105, 26, ""),
					new(3699, 2048, 5, ""),
					new(3674, 2161, 20, ""),
					new(3728, 2160, 20, ""),
					new(3678, 2248, 20, ""),
					new(3687, 2218, 20, ""),
					new(3679, 2209, 20, ""),
					new(3733, 2171, 20, ""),
					new(3685, 2105, 20, ""),
					new(3670, 2260, 20, ""),
					new(3674, 2091, 20, ""),
					new(3728, 2162, 20, ""),
					new(3674, 2207, 20, ""),
					new(3714, 2153, 20, ""),
					new(3768, 2136, 23, ""),
					new(3720, 2067, 5, ""),
					new(3700, 2115, 20, ""),
					new(3758, 2231, 20, ""),
					new(3721, 2250, 16, ""),
					new(3701, 2176, 20, ""),
					new(3707, 2254, 20, ""),
				}),
				new("Dirt", typeof(Static), 7680, "Hue=0x3E1", new DecorationEntry[]
				{
					new(3552, 2150, 23, ""),
					new(3601, 2138, 66, ""),
					new(3552, 2156, 22, ""),
					new(3548, 2146, 21, ""),
					new(3542, 2143, 20, ""),
					new(3537, 2152, 20, ""),
					new(3697, 2213, 20, ""),
					new(3533, 2142, 20, ""),
					new(3691, 2174, 20, ""),
					new(3541, 2140, 20, ""),
					new(3683, 2204, 20, ""),
					new(3657, 2158, 29, ""),
					new(3559, 2161, 21, ""),
					new(3558, 2161, 21, ""),
					new(3559, 2166, 20, ""),
					new(3551, 2141, 21, ""),
					new(3550, 2157, 22, ""),
				}),
				new("Wood", typeof(Static), 7041, "Hue=0x497", new DecorationEntry[]
				{
					new(3670, 2245, 20, ""),
					new(3621, 2175, 32, ""),
					new(3535, 2144, 20, ""),
					new(3547, 2141, 20, ""),
					new(3564, 2160, 22, ""),
					new(3548, 2144, 21, ""),
					new(3541, 2145, 20, ""),
					new(3634, 2140, 57, ""),
					new(3713, 2202, 20, ""),
					new(3546, 2147, 20, ""),
					new(3554, 2155, 23, ""),
					new(3550, 2155, 22, ""),
					new(3558, 2150, 27, ""),
					new(3564, 2157, 23, ""),
					new(3556, 2153, 24, ""),
					new(3701, 2238, 20, ""),
					new(3656, 2192, 20, ""),
					new(3561, 2159, 22, ""),
					new(3553, 2164, 20, ""),
					new(3560, 2157, 23, ""),
					new(3552, 2155, 23, ""),
					new(3597, 2165, 39, ""),
					new(3550, 2163, 20, ""),
					new(3548, 2164, 20, ""),
					new(3555, 2158, 22, ""),
					new(3543, 2155, 20, ""),
				}),
				new("Garbage", typeof(Static), 4334, "Hue=0x3E2", new DecorationEntry[]
				{
					new(3553, 2155, 23, ""),
					new(3651, 2220, 20, ""),
					new(3556, 2156, 23, ""),
					new(3566, 2158, 23, ""),
					new(3556, 2158, 22, ""),
					new(3543, 2154, 20, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(3696, 2208, 20, ""),
					new(3532, 2140, 20, ""),
					new(3646, 2116, 22, ""),
					new(3547, 2145, 20, ""),
					new(3567, 2161, 22, ""),
					new(3712, 2231, 20, ""),
					new(3551, 2166, 20, ""),
					new(3622, 2186, 21, ""),
					new(3721, 2217, 20, ""),
					new(3533, 2146, 20, ""),
					new(3547, 2150, 20, ""),
					new(3566, 2149, 37, ""),
					new(3666, 2202, 20, ""),
					new(3689, 2154, 20, ""),
					new(3553, 2154, 23, ""),
					new(3564, 2161, 21, ""),
					new(3656, 2298, -1, ""),
					new(3546, 2145, 20, ""),
					new(3534, 2145, 20, ""),
					new(3563, 2162, 21, ""),
					new(3567, 2169, -15, ""),
					new(3559, 2156, 23, ""),
					new(3566, 2160, 22, ""),
					new(3660, 2237, 20, ""),
					new(3680, 2030, -5, ""),
					new(3562, 2154, 26, ""),
					new(3550, 2158, 21, ""),
					new(3545, 2155, 20, ""),
					new(3545, 2156, 20, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(3729, 2228, 24, ""),
					new(3780, 2266, 26, ""),
					new(3685, 2224, 24, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(3730, 2228, 24, ""),
					new(3685, 2224, 24, ""),
				}),
				new("Candlabra", typeof(CandelabraStand), 2601, "", new DecorationEntry[]
				{
					new(3663, 2192, 20, ""),
					new(3670, 2112, 20, ""),
					new(3736, 2067, 5, ""),
					new(3696, 2160, 20, ""),
					new(3680, 2251, 20, ""),
					new(3678, 2096, 20, ""),
					new(3680, 2168, 20, ""),
					new(3670, 2250, 20, ""),
					new(3656, 2118, 20, ""),
					new(3787, 2251, 20, ""),
					new(3710, 2251, 20, ""),
					new(3779, 2264, 20, ""),
					new(3770, 2104, 20, ""),
					new(3696, 2240, 20, ""),
					new(3656, 2176, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(3685, 2204, 20, ""),
					new(3685, 2202, 20, ""),
				}),
				new("Bulrushes", typeof(Static), 3220, "", new DecorationEntry[]
				{
					new(3682, 2196, 20, ""),
					new(3685, 2195, 20, ""),
				}),
				new("Fern", typeof(Static), 3236, "", new DecorationEntry[]
				{
					new(3685, 2197, 20, ""),
					new(3685, 2194, 20, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(3670, 2262, 20, ""),
					new(3684, 2224, 24, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "", new DecorationEntry[]
				{
					new(3657, 2256, 18, ""),
					new(3684, 2197, 20, ""),
				}),
				new("Fern", typeof(Static), 3235, "Hue=0x3DA", new DecorationEntry[]
				{
					new(3803, 2148, 16, ""),
					new(3724, 2140, 20, ""),
					new(3653, 2061, 20, ""),
					new(3645, 2209, 20, ""),
					new(3722, 2051, 5, ""),
					new(3705, 2134, 20, ""),
					new(3641, 2225, 20, ""),
					new(3658, 2041, 20, ""),
					new(3658, 2043, 20, ""),
					new(3650, 2076, 20, ""),
				}),
				new("Garbage", typeof(Static), 4334, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3555, 2157, 23, ""),
					new(3553, 2142, 21, ""),
					new(3664, 2210, 20, ""),
					new(3681, 2228, 20, ""),
					new(3737, 2150, 20, ""),
					new(3554, 2140, 20, ""),
					new(3702, 2186, 20, ""),
					new(3547, 2148, 20, ""),
					new(3559, 2149, 26, ""),
					new(3801, 2148, 20, ""),
				}),
				new("Wood", typeof(Static), 7041, "", new DecorationEntry[]
				{
					new(3562, 2167, 20, ""),
					new(3542, 2144, 20, ""),
					new(3772, 2140, 27, ""),
					new(3551, 2141, 21, ""),
					new(3554, 2168, 20, ""),
					new(3566, 2151, 33, ""),
					new(3540, 2143, 20, ""),
					new(3538, 2150, 20, ""),
					new(3540, 2148, 20, ""),
					new(3656, 2183, 20, ""),
					new(3714, 2193, 20, ""),
					new(3564, 2162, 21, ""),
					new(3712, 2211, 20, ""),
					new(3546, 2144, 20, ""),
					new(3554, 2154, 24, ""),
					new(3565, 2136, 27, ""),
					new(3533, 2143, 20, ""),
					new(3533, 2141, 20, ""),
					new(3548, 2152, 21, ""),
					new(3704, 2177, 20, ""),
					new(3559, 2161, 21, ""),
					new(3668, 2214, 20, ""),
					new(3550, 2158, 21, ""),
					new(3564, 2151, 32, ""),
				}),
				new("Garbage", typeof(Static), 4334, "Hue=0x3E4", new DecorationEntry[]
				{
					new(3537, 2141, 20, ""),
					new(3555, 2155, 23, ""),
					new(3607, 2157, 58, ""),
					new(3634, 2196, 20, ""),
					new(3567, 2153, 31, ""),
				}),
				new("Stone Ruins", typeof(Static), 952, "", new DecorationEntry[]
				{
					new(3732, 2226, 20, ""),
					new(3734, 2187, 20, ""),
					new(3744, 2064, 5, ""),
					new(3688, 2192, 20, ""),
					new(3697, 2201, 20, ""),
					new(3753, 2136, 22, ""),
					new(3708, 2143, 20, ""),
					new(3728, 2077, 5, ""),
					new(3744, 2053, 5, ""),
					new(3739, 2050, 5, ""),
					new(3723, 2168, 20, ""),
					new(3677, 2212, 20, ""),
					new(3694, 2222, 20, ""),
					new(3719, 2224, 20, ""),
					new(3738, 2156, 20, ""),
					new(3682, 2141, 20, ""),
					new(3722, 2143, 20, ""),
					new(3736, 2145, 20, ""),
					new(3735, 2164, 20, ""),
					new(3737, 2205, 20, ""),
					new(3695, 2169, 20, ""),
					new(3724, 2217, 20, ""),
					new(3740, 2254, 20, ""),
				}),
				new("Wood", typeof(Static), 7041, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3551, 2149, 22, ""),
					new(3545, 2149, 20, ""),
					new(3533, 2137, 20, ""),
					new(3531, 2140, 23, ""),
					new(3640, 2200, 20, ""),
					new(3559, 2159, 22, ""),
				}),
				new("Dirt", typeof(Static), 7679, "Hue=0x497", new DecorationEntry[]
				{
					new(3563, 2147, 31, ""),
					new(3567, 2154, 28, ""),
					new(3735, 2156, 20, ""),
					new(3694, 2173, 20, ""),
					new(3699, 2225, 20, ""),
					new(3712, 2221, 20, ""),
					new(3608, 2168, 35, ""),
					new(3545, 2149, 20, ""),
					new(3536, 2149, 20, ""),
					new(3540, 2149, 20, ""),
					new(3533, 2142, 20, ""),
					new(3551, 2147, 22, ""),
					new(3550, 2141, 20, ""),
					new(3551, 2142, 21, ""),
					new(3560, 2165, 20, ""),
					new(3648, 2152, 36, ""),
					new(3527, 2141, -15, ""),
					new(3701, 2219, 20, ""),
					new(3697, 2156, 20, ""),
					new(3562, 2149, 31, ""),
					new(3584, 2153, 59, ""),
					new(3542, 2139, 20, ""),
					new(3676, 2144, 20, ""),
					new(3545, 2158, 20, ""),
					new(3567, 2159, 23, ""),
					new(3669, 2221, 20, ""),
					new(3556, 2151, 25, ""),
					new(3549, 2141, 20, ""),
					new(3551, 2158, 21, ""),
					new(3556, 2150, 26, ""),
				}),
				new("Dirt Patch", typeof(Static), 2321, "", new DecorationEntry[]
				{
					new(3534, 2146, 20, ""),
					new(3663, 2199, 20, ""),
					new(3548, 2136, 20, ""),
					new(3545, 2144, 20, ""),
					new(3549, 2140, 20, ""),
					new(3719, 2225, 20, ""),
					new(3543, 2144, 20, ""),
					new(3687, 2206, 20, ""),
					new(3686, 2169, 20, ""),
					new(3664, 2119, 20, ""),
					new(3561, 2167, 20, ""),
					new(3661, 2120, 20, ""),
					new(3548, 2145, 21, ""),
					new(3663, 2119, 20, ""),
					new(3559, 2157, 23, ""),
					new(3559, 2159, 22, ""),
					new(3547, 2152, 20, ""),
					new(3531, 2144, 20, ""),
					new(3557, 2158, 23, ""),
					new(3767, 2206, 20, ""),
					new(3541, 2153, 20, ""),
					new(3591, 2164, 40, ""),
					new(3566, 2159, 23, ""),
					new(3566, 2154, 29, ""),
					new(3557, 2154, 24, ""),
				}),
				new("Dirt", typeof(Static), 7678, "Hue=0x3E3", new DecorationEntry[]
				{
					new(3543, 2145, 20, ""),
					new(3545, 2158, 20, ""),
					new(3558, 2159, 22, ""),
					new(3554, 2153, 24, ""),
					new(3555, 2156, 23, ""),
				}),
				new("Fern", typeof(Static), 3231, "", new DecorationEntry[]
				{
					new(3684, 2196, 20, ""),
				}),
				new("Dirt", typeof(Static), 7680, "Hue=0x497", new DecorationEntry[]
				{
					new(3552, 2148, 23, ""),
					new(3633, 2159, 63, ""),
					new(3695, 2212, 20, ""),
					new(3553, 2156, 23, ""),
					new(3561, 2136, 25, ""),
					new(3540, 2151, 20, ""),
					new(3561, 2166, 20, ""),
					new(3704, 2235, 20, ""),
					new(3556, 2162, 20, ""),
					new(3554, 2169, 12, ""),
					new(3711, 2223, 20, ""),
					new(3675, 2167, 20, ""),
					new(3554, 2167, 20, ""),
					new(3536, 2154, -15, ""),
					new(3710, 2169, 20, ""),
					new(3707, 2230, 20, ""),
					new(3536, 2137, 20, ""),
					new(3546, 2136, 20, ""),
					new(3543, 2135, 20, ""),
					new(3563, 2153, 25, ""),
					new(3563, 2152, 28, ""),
					new(3756, 2189, 20, ""),
					new(3539, 2136, 20, ""),
					new(3686, 2197, 20, ""),
					new(3544, 2149, 20, ""),
					new(3746, 2212, 20, ""),
					new(3542, 2141, 20, ""),
					new(3535, 2140, 20, ""),
					new(3549, 2153, 21, ""),
					new(3551, 2145, 22, ""),
					new(3656, 2195, 20, ""),
					new(3681, 2259, 20, ""),
					new(3641, 2216, 20, ""),
					new(3667, 2164, 20, ""),
					new(3556, 2161, 27, ""),
					new(3566, 2159, 23, ""),
					new(3673, 2177, 20, ""),
					new(3757, 2189, 20, ""),
					new(3550, 2156, 22, ""),
					new(3560, 2149, 27, ""),
				}),
				new("Dirt", typeof(Static), 7678, "Hue=0x497", new DecorationEntry[]
				{
					new(3560, 2143, 26, ""),
					new(3526, 2143, -15, ""),
					new(3563, 2167, 20, ""),
					new(3565, 2137, 27, ""),
					new(3549, 2141, 20, ""),
					new(3551, 2160, 21, ""),
					new(3547, 2147, 20, ""),
					new(3544, 2159, -15, ""),
					new(3542, 2151, 20, ""),
					new(3542, 2152, 20, ""),
					new(3654, 2228, 20, ""),
					new(3608, 2150, 63, ""),
					new(3563, 2153, 25, ""),
					new(3545, 2142, 20, ""),
					new(3608, 2161, 48, ""),
					new(3661, 2192, 20, ""),
					new(3549, 2146, 21, ""),
					new(3696, 2169, 20, ""),
					new(3566, 2159, 23, ""),
					new(3555, 2148, 25, ""),
					new(3673, 2262, 20, ""),
					new(3553, 2142, 21, ""),
					new(3557, 2140, 23, ""),
					new(3549, 2164, 20, ""),
					new(3550, 2156, 22, ""),
					new(3560, 2154, 24, ""),
				}),
				new("Garbage", typeof(Static), 4334, "Hue=0x497", new DecorationEntry[]
				{
					new(3667, 2214, 20, ""),
					new(3553, 2160, 21, ""),
					new(3546, 2138, 20, ""),
					new(3663, 2211, 20, ""),
					new(3557, 2143, 23, ""),
					new(3564, 2137, 27, ""),
					new(3547, 2146, 20, ""),
					new(3552, 2143, 21, ""),
					new(3547, 2159, 20, ""),
					new(3731, 2219, 20, ""),
					new(3545, 2157, 20, ""),
					new(3540, 2151, 20, ""),
					new(3701, 2164, 20, ""),
					new(3697, 2164, 20, ""),
					new(3584, 2142, 62, ""),
					new(3539, 2156, 20, ""),
					new(3545, 2144, 20, ""),
					new(3545, 2147, 20, ""),
					new(3720, 2204, 20, ""),
					new(3546, 2139, 20, ""),
					new(3554, 2155, 23, ""),
					new(3564, 2151, 32, ""),
					new(3535, 2148, 20, ""),
					new(3531, 2142, 20, ""),
					new(3562, 2150, 32, ""),
					new(3552, 2165, 20, ""),
					new(3560, 2152, 26, ""),
				}),
				new("Dirt", typeof(Static), 7679, "", new DecorationEntry[]
				{
					new(3562, 2148, 32, ""),
					new(3554, 2151, 24, ""),
					new(3555, 2163, 20, ""),
					new(3660, 2201, 20, ""),
					new(3557, 2145, 23, ""),
					new(3559, 2144, 24, ""),
					new(3533, 2143, 20, ""),
					new(3760, 2228, 20, ""),
					new(3541, 2140, 20, ""),
					new(3707, 2231, 20, ""),
					new(3550, 2159, 21, ""),
					new(3687, 2209, 20, ""),
					new(3773, 2138, 24, ""),
					new(3720, 2174, 20, ""),
					new(3556, 2162, 20, ""),
					new(3565, 2149, 36, ""),
					new(3671, 2219, 20, ""),
					new(3542, 2138, 20, ""),
					new(3544, 2141, 20, ""),
					new(3554, 2153, 24, ""),
					new(3554, 2148, 24, ""),
					new(3555, 2148, 25, ""),
					new(3547, 2146, 20, ""),
					new(3545, 2150, 20, ""),
					new(3560, 2169, -15, ""),
					new(3559, 2166, 20, ""),
					new(3557, 2142, 24, ""),
					new(3547, 2164, -15, ""),
					new(3558, 2151, 26, ""),
					new(3560, 2150, 27, ""),
				}),
				new("Date Palm", typeof(Static), 3222, "", new DecorationEntry[]
				{
					new(3684, 2195, 20, ""),
				}),
				new("Sapling", typeof(Static), 3306, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3702, 2194, 20, ""),
				}),
				new("Wood", typeof(Static), 1848, "", new DecorationEntry[]
				{
					new(3690, 2299, -15, ""),
					new(3694, 2291, -15, ""),
					new(3681, 2299, -15, ""),
					new(3681, 2291, -15, ""),
					new(3679, 2290, -14, ""),
					new(3677, 2299, -15, ""),
					new(3677, 2274, -4, ""),
					new(3677, 2273, 1, ""),
					new(3677, 2273, -4, ""),
					new(3677, 2272, 1, ""),
					new(3677, 2272, -4, ""),
					new(3677, 2271, 11, ""),
					new(3677, 2271, 6, ""),
					new(3677, 2271, 1, ""),
					new(3676, 2272, 8, ""),
					new(3676, 2271, 11, ""),
					new(3675, 2290, -14, ""),
					new(3675, 2281, -14, ""),
					new(3675, 2273, 2, ""),
					new(3675, 2272, 8, ""),
					new(3675, 2271, 11, ""),
					new(3675, 2270, -5, ""),
					new(3674, 2274, -2, ""),
					new(3674, 2273, 2, ""),
					new(3674, 2272, 8, ""),
					new(3674, 2271, 11, ""),
					new(3674, 2270, -5, ""),
					new(3673, 2274, -2, ""),
					new(3673, 2273, 2, ""),
					new(3673, 2271, 11, ""),
					new(3673, 2270, -5, ""),
					new(3672, 2274, -2, ""),
					new(3672, 2273, 2, ""),
					new(3672, 2272, 8, ""),
					new(3672, 2271, 11, ""),
					new(3672, 2270, -5, ""),
					new(3671, 2274, -2, ""),
					new(3671, 2273, 2, ""),
					new(3671, 2272, 8, ""),
					new(3671, 2271, 11, ""),
					new(3671, 2270, -5, ""),
					new(3677, 2272, 6, ""),
					new(3677, 2271, -4, ""),
					new(3670, 2299, -14, ""),
					new(3670, 2291, -13, ""),
					new(3676, 2273, 2, ""),
					new(3670, 2274, -2, ""),
					new(3670, 2273, 2, ""),
					new(3670, 2272, 8, ""),
					new(3670, 2270, -5, ""),
					new(3669, 2270, 0, ""),
					new(3666, 2299, -14, ""),
					new(3676, 2274, -2, ""),
					new(3657, 2299, -14, ""),
					new(3673, 2272, 8, ""),
					new(3653, 2299, -14, ""),
					new(3675, 2274, -2, ""),
					new(3669, 2270, -5, ""),
					new(3694, 2299, -15, ""),
					new(3694, 2291, -14, ""),
					new(3694, 2287, -14, ""),
					new(3694, 2287, -15, ""),
				}),
				new("Stool", typeof(Static), 2603, "", new DecorationEntry[]
				{
					new(3682, 2172, 20, ""),
					new(3682, 2170, 20, ""),
					new(3684, 2170, 20, ""),
				}),
				new("Empty Tile", typeof(Static), 4120, "", new DecorationEntry[]
				{
					new(3662, 2230, 20, ""),
				}),
				new("Candelabra", typeof(Candelabra), 2845, "", new DecorationEntry[]
				{
					new(3656, 2141, 26, ""),
					new(3760, 2115, 24, ""),
				}),
				new("Candelabra", typeof(Static), 2855, "", new DecorationEntry[]
				{
					new(3678, 2110, 20, ""),
					new(3670, 2229, 20, ""),
					new(3670, 2176, 20, ""),
					new(3670, 2118, 20, ""),
					new(3664, 2248, 20, ""),
					new(3664, 2096, 20, ""),
					new(3656, 2198, 20, ""),
					new(3656, 2190, 20, ""),
					new(3656, 2111, 20, ""),
					new(3806, 2240, 20, ""),
					new(3787, 2240, 20, ""),
					new(3784, 2245, 20, ""),
					new(3779, 2270, 20, ""),
					new(3779, 2254, 20, ""),
					new(3767, 2118, 20, ""),
					new(3766, 2126, 20, ""),
					new(3766, 2096, 20, ""),
					new(3736, 2062, 5, ""),
					new(3704, 2240, 20, ""),
					new(3702, 2056, 5, ""),
					new(3701, 2165, 20, ""),
					new(3694, 2170, 20, ""),
					new(3691, 2078, 5, ""),
					new(3684, 2070, 5, ""),
				}),
				new("Garbage", typeof(Static), 4337, "", new DecorationEntry[]
				{
					new(3550, 2148, 22, ""),
					new(3551, 2151, 22, ""),
					new(3548, 2140, 20, ""),
					new(3711, 2217, 20, ""),
					new(3557, 2144, 24, ""),
					new(3537, 2149, 20, ""),
					new(3534, 2142, 20, ""),
					new(3562, 2166, 20, ""),
					new(3552, 2143, 21, ""),
					new(3629, 2187, 20, ""),
					new(3550, 2155, 22, ""),
					new(3551, 2160, 21, ""),
					new(3551, 2144, 22, ""),
					new(3547, 2158, 20, ""),
					new(3547, 2157, 20, ""),
					new(3682, 2258, 20, ""),
					new(3628, 2139, 73, ""),
					new(3549, 2157, 21, ""),
					new(3545, 2147, 20, ""),
					new(3657, 2232, 20, ""),
					new(3562, 2157, 23, ""),
					new(3654, 2179, 20, ""),
					new(3737, 2214, 20, ""),
					new(3547, 2163, 8, ""),
					new(3559, 2158, 22, ""),
					new(3549, 2160, 20, ""),
					new(3567, 2149, 38, ""),
					new(3548, 2153, 21, ""),
					new(3686, 2214, 20, ""),
					new(3557, 2148, 26, ""),
					new(3673, 2183, 20, ""),
					new(3711, 2241, 20, ""),
					new(3696, 2169, 20, ""),
				}),
				new("Pier", typeof(Static), 933, "", new DecorationEntry[]
				{
					new(3687, 2271, -5, ""),
					new(3690, 2299, -3, ""),
					new(3690, 2291, -3, ""),
					new(3690, 2287, -3, ""),
					new(3690, 2279, -3, ""),
					new(3687, 2270, 0, ""),
					new(3687, 2270, 5, ""),
					new(3687, 2270, 15, ""),
					new(3687, 2268, -5, ""),
					new(3687, 2268, 0, ""),
					new(3687, 2268, 15, ""),
					new(3694, 2299, -3, ""),
					new(3694, 2291, -3, ""),
					new(3685, 2271, -5, ""),
					new(3687, 2270, 10, ""),
					new(3688, 2270, -5, ""),
					new(3688, 2267, -5, ""),
					new(3688, 2268, -5, ""),
					new(3688, 2269, -5, ""),
					new(3684, 2270, 0, ""),
					new(3684, 2270, 5, ""),
					new(3684, 2270, 10, ""),
					new(3684, 2270, 15, ""),
					new(3687, 2268, 10, ""),
					new(3684, 2270, -5, ""),
					new(3682, 2270, -5, ""),
					new(3682, 2270, 0, ""),
					new(3682, 2270, 5, ""),
					new(3687, 2268, 5, ""),
					new(3681, 2299, -3, ""),
					new(3681, 2291, -3, ""),
					new(3681, 2287, -3, ""),
					new(3680, 2270, -5, ""),
					new(3680, 2270, 0, ""),
					new(3680, 2270, 5, ""),
					new(3680, 2270, 10, ""),
					new(3680, 2270, 15, ""),
					new(3682, 2270, 10, ""),
					new(3682, 2270, 15, ""),
					new(3678, 2270, -5, ""),
					new(3678, 2270, 0, ""),
					new(3678, 2270, 5, ""),
					new(3678, 2270, 10, ""),
					new(3678, 2270, 15, ""),
					new(3677, 2299, -3, ""),
					new(3677, 2291, -3, ""),
					new(3677, 2287, -3, ""),
					new(3670, 2299, -3, ""),
					new(3670, 2291, -3, ""),
					new(3670, 2287, -3, ""),
					new(3669, 2270, 15, ""),
					new(3669, 2270, 10, ""),
					new(3666, 2299, -3, ""),
					new(3666, 2291, -3, ""),
					new(3663, 2270, 15, ""),
					new(3663, 2270, 10, ""),
					new(3663, 2270, 5, ""),
					new(3663, 2270, 0, ""),
					new(3663, 2268, 0, ""),
					new(3663, 2268, -5, ""),
					new(3663, 2266, -5, ""),
					new(3663, 2266, 0, ""),
					new(3657, 2299, -3, ""),
					new(3657, 2291, -3, ""),
					new(3657, 2287, -3, ""),
					new(3653, 2299, -3, ""),
					new(3653, 2291, -3, ""),
					new(3653, 2287, -3, ""),
					new(3653, 2279, -3, ""),
					new(3678, 2271, -5, ""),
					new(3679, 2271, -5, ""),
					new(3657, 2279, -3, ""),
					new(3682, 2271, -5, ""),
					new(3686, 2271, -6, ""),
					new(3681, 2271, -5, ""),
					new(3680, 2265, 21, ""),
					new(3680, 2271, -5, ""),
					new(3694, 2287, -3, ""),
					new(3694, 2279, -3, ""),
				}),
				new("Candelabra", typeof(Static), 2856, "", new DecorationEntry[]
				{
					new(3672, 2110, 20, ""),
					new(3670, 2259, 20, ""),
					new(3670, 2198, 20, ""),
					new(3666, 2238, 20, ""),
					new(3664, 2102, 20, ""),
					new(3663, 2182, 20, ""),
					new(3662, 2104, 20, ""),
					new(3806, 2259, 20, ""),
					new(3800, 2263, 20, ""),
					new(3796, 2270, 20, ""),
					new(3760, 2104, 20, ""),
					new(3742, 2067, 5, ""),
					new(3742, 2062, 5, ""),
					new(3710, 2240, 20, ""),
					new(3703, 2250, 20, ""),
					new(3702, 2078, 5, ""),
					new(3701, 2160, 20, ""),
					new(3691, 2063, 5, ""),
					new(3688, 2160, 20, ""),
					new(3661, 2232, 20, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(3661, 2229, 20, ""),
				}),
				new("Bloody Bandage%S%", typeof(Static), 3616, "", new DecorationEntry[]
				{
					new(3683, 2224, 24, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "", new DecorationEntry[]
				{
					new(3683, 2205, 20, ""),
				}),
				new("Silverware", typeof(Static), 2516, "", new DecorationEntry[]
				{
					new(3682, 2204, 24, ""),
					new(3720, 2084, 9, ""),
					new(3683, 2204, 24, ""),
				}),
				new("Goblet", typeof(Static), 2507, "", new DecorationEntry[]
				{
					new(3682, 2204, 24, ""),
					new(3682, 2203, 24, ""),
					new(3770, 2108, 24, ""),
					new(3770, 2107, 24, ""),
					new(3683, 2203, 24, ""),
					new(3683, 2204, 24, ""),
				}),
				new("Small Palm", typeof(Static), 3229, "Hue=0x3DB", new DecorationEntry[]
				{
					new(3625, 2202, 20, ""),
					new(3652, 2252, 20, ""),
					new(3647, 2216, 20, ""),
				}),
				new("Silverware", typeof(Static), 2517, "", new DecorationEntry[]
				{
					new(3722, 2084, 9, ""),
					new(3683, 2203, 24, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(3682, 2204, 24, ""),
					new(3682, 2203, 24, ""),
					new(3682, 2202, 24, ""),
					new(3722, 2084, 9, ""),
					new(3720, 2084, 9, ""),
					new(3683, 2204, 24, ""),
					new(3683, 2203, 24, ""),
					new(3683, 2202, 24, ""),
				}),
				new("Silverware", typeof(Static), 2494, "", new DecorationEntry[]
				{
					new(3682, 2202, 24, ""),
					new(3683, 2202, 24, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(3690, 2184, 20, ""),
					new(3686, 2184, 20, ""),
					new(3683, 2201, 20, ""),
				}),
				new("Coconut Palm", typeof(Static), 3221, "", new DecorationEntry[]
				{
					new(3683, 2196, 20, ""),
				}),
				new("Fern", typeof(Static), 3232, "", new DecorationEntry[]
				{
					new(3683, 2195, 20, ""),
				}),
				new("Wooden Plank", typeof(Static), 1998, "", new DecorationEntry[]
				{
					new(3692, 2298, -3, ""),
					new(3692, 2286, -3, ""),
					new(3692, 2279, -3, ""),
					new(3691, 2299, -3, ""),
					new(3691, 2279, -3, ""),
					new(3690, 2288, -3, ""),
					new(3689, 2288, -3, ""),
					new(3688, 2291, -3, ""),
					new(3687, 2287, -3, ""),
					new(3686, 2288, -3, ""),
					new(3692, 2288, -3, ""),
					new(3684, 2291, -3, ""),
					new(3691, 2291, -3, ""),
					new(3684, 2270, 20, ""),
					new(3684, 2261, 20, ""),
					new(3683, 2288, -3, ""),
					new(3683, 2265, 20, ""),
					new(3682, 2291, -3, ""),
					new(3683, 2269, 20, ""),
					new(3683, 2264, 20, ""),
					new(3683, 2261, 20, ""),
					new(3680, 2298, -3, ""),
					new(3680, 2263, 20, ""),
					new(3680, 2261, 20, ""),
					new(3679, 2298, -3, ""),
					new(3679, 2291, -3, ""),
					new(3679, 2269, 20, ""),
					new(3679, 2266, 20, ""),
					new(3679, 2262, 20, ""),
					new(3679, 2261, 20, ""),
					new(3678, 2287, -3, ""),
					new(3678, 2267, 20, ""),
					new(3678, 2262, 20, ""),
					new(3681, 2288, -3, ""),
					new(3678, 2261, 20, ""),
					new(3677, 2288, -3, ""),
					new(3677, 2283, -3, ""),
					new(3677, 2280, -3, ""),
					new(3677, 2270, 20, ""),
					new(3677, 2268, 20, ""),
					new(3677, 2266, 20, ""),
					new(3677, 2262, 20, ""),
					new(3676, 2288, -3, ""),
					new(3676, 2283, -3, ""),
					new(3676, 2282, -3, ""),
					new(3676, 2272, 7, ""),
					new(3676, 2261, 20, ""),
					new(3675, 2289, -3, ""),
					new(3675, 2287, -3, ""),
					new(3675, 2282, -3, ""),
					new(3675, 2281, -3, ""),
					new(3675, 2279, -3, ""),
					new(3675, 2272, 7, ""),
					new(3675, 2270, 20, ""),
					new(3675, 2268, 20, ""),
					new(3675, 2262, 20, ""),
					new(3675, 2261, 20, ""),
					new(3674, 2283, -3, ""),
					new(3674, 2282, -3, ""),
					new(3674, 2272, 7, ""),
					new(3674, 2262, 20, ""),
					new(3674, 2261, 20, ""),
					new(3673, 2289, -3, ""),
					new(3673, 2283, -3, ""),
					new(3673, 2282, -3, ""),
					new(3673, 2281, -3, ""),
					new(3673, 2272, 7, ""),
					new(3673, 2262, 20, ""),
					new(3673, 2261, 20, ""),
					new(3672, 2283, -3, ""),
					new(3672, 2282, -3, ""),
					new(3672, 2272, 7, ""),
					new(3672, 2263, 20, ""),
					new(3672, 2262, 20, ""),
					new(3672, 2261, 20, ""),
					new(3678, 2299, -3, ""),
					new(3671, 2283, -3, ""),
					new(3671, 2282, -3, ""),
					new(3671, 2272, 7, ""),
					new(3677, 2282, -3, ""),
					new(3677, 2261, 20, ""),
					new(3680, 2288, -3, ""),
					new(3676, 2278, -3, ""),
					new(3670, 2283, -3, ""),
					new(3670, 2282, -3, ""),
					new(3670, 2274, -3, ""),
					new(3676, 2262, 20, ""),
					new(3670, 2272, 7, ""),
					new(3675, 2277, -3, ""),
					new(3669, 2298, -3, ""),
					new(3669, 2291, -3, ""),
					new(3668, 2298, -3, ""),
					new(3668, 2288, -3, ""),
					new(3673, 2279, -3, ""),
					new(3667, 2299, -3, ""),
					new(3667, 2291, -3, ""),
					new(3667, 2269, 20, ""),
					new(3666, 2288, -3, ""),
					new(3665, 2270, 20, ""),
					new(3670, 2284, -3, ""),
					new(3675, 2291, -3, ""),
					new(3663, 2287, -3, ""),
					new(3662, 2288, -3, ""),
					new(3660, 2291, -3, ""),
					new(3673, 2291, -3, ""),
					new(3659, 2290, -3, ""),
					new(3659, 2288, -3, ""),
					new(3656, 2288, -3, ""),
					new(3656, 2286, -3, ""),
					new(3655, 2298, -3, ""),
					new(3655, 2286, -3, ""),
					new(3655, 2279, -3, ""),
					new(3654, 2299, -3, ""),
					new(3654, 2287, -3, ""),
					new(3654, 2279, -3, ""),
					new(3653, 2288, -3, ""),
					new(3675, 2283, -3, ""),
					new(3664, 2291, -3, ""),
					new(3664, 2262, 20, ""),
					new(3656, 2298, -3, ""),
					new(3655, 2291, -3, ""),
					new(3665, 2288, -3, ""),
					new(3693, 2298, -3, ""),
					new(3693, 2291, -3, ""),
					new(3693, 2286, -3, ""),
				}),
				new("Nodraw", typeof(Static), 8600, "", new DecorationEntry[]
				{
					new(3546, 2149, 20, ""),
					new(3561, 2152, 33, ""),
					new(3539, 2152, 20, ""),
					new(3546, 2143, 20, ""),
					new(3553, 2138, 20, ""),
					new(3541, 2147, 20, ""),
					new(3541, 2136, 20, ""),
					new(3546, 2144, 20, ""),
					new(3551, 2144, 22, ""),
					new(3554, 2151, 24, ""),
					new(3547, 2136, 20, ""),
					new(3534, 2142, 20, ""),
					new(3540, 2139, 20, ""),
					new(3543, 2154, 20, ""),
					new(3678, 2297, 3, ""),
					new(3680, 2144, 20, ""),
					new(3553, 2151, 23, ""),
					new(3563, 2163, 20, ""),
					new(3552, 2150, 23, ""),
					new(3536, 2141, 25, ""),
					new(3555, 2152, 24, ""),
					new(3543, 2156, 19, ""),
					new(3538, 2147, 20, ""),
					new(3547, 2144, 20, ""),
					new(3542, 2140, 20, ""),
					new(3549, 2163, 20, ""),
					new(3541, 2142, 20, ""),
					new(3539, 2148, 20, ""),
					new(3544, 2138, 20, ""),
					new(3561, 2152, 27, ""),
					new(3534, 2147, 20, ""),
					new(3530, 2141, 20, ""),
					new(3552, 2149, 23, ""),
					new(3534, 2141, 20, ""),
					new(3553, 2156, 23, ""),
					new(3539, 2149, 20, ""),
					new(3536, 2150, 20, ""),
					new(3566, 2161, 21, ""),
					new(3541, 2146, 20, ""),
					new(3544, 2152, 20, ""),
					new(3540, 2150, 20, ""),
					new(3538, 2152, 20, ""),
					new(3533, 2143, 20, ""),
					new(3554, 2150, 24, ""),
					new(3561, 2150, 29, ""),
					new(3538, 2136, 20, ""),
					new(3535, 2136, 20, ""),
					new(3543, 2149, 20, ""),
					new(3553, 2152, 23, ""),
					new(3540, 2151, 20, ""),
					new(3545, 2153, 20, ""),
					new(3557, 2165, 20, ""),
					new(3552, 2152, 23, ""),
					new(3534, 2145, 20, ""),
					new(3552, 2157, 22, ""),
					new(3534, 2148, 20, ""),
					new(3541, 2152, 20, ""),
					new(3558, 2152, 30, ""),
					new(3535, 2151, 20, ""),
					new(3677, 2230, 24, ""),
					new(3674, 2230, 24, ""),
					new(3553, 2150, 23, ""),
					new(3558, 2154, 24, ""),
					new(3536, 2151, 25, ""),
					new(3530, 2142, 20, ""),
					new(3557, 2154, 24, ""),
				}),
				new("Wooden Plank", typeof(Static), 1999, "", new DecorationEntry[]
				{
					new(3692, 2295, -3, ""),
					new(3691, 2294, -3, ""),
					new(3691, 2287, -3, ""),
					new(3691, 2282, -3, ""),
					new(3690, 2295, -3, ""),
					new(3690, 2283, -3, ""),
					new(3688, 2287, -3, ""),
					new(3687, 2291, -3, ""),
					new(3686, 2265, 20, ""),
					new(3685, 2291, -3, ""),
					new(3692, 2283, -3, ""),
					new(3685, 2261, 20, ""),
					new(3685, 2287, -3, ""),
					new(3684, 2287, -3, ""),
					new(3683, 2262, 20, ""),
					new(3682, 2287, -3, ""),
					new(3682, 2263, 20, ""),
					new(3681, 2294, -3, ""),
					new(3680, 2294, -3, ""),
					new(3680, 2266, 20, ""),
					new(3680, 2265, 20, ""),
					new(3679, 2295, -3, ""),
					new(3679, 2287, -3, ""),
					new(3679, 2268, 20, ""),
					new(3682, 2268, 20, ""),
					new(3682, 2266, 20, ""),
					new(3678, 2291, -3, ""),
					new(3678, 2266, 20, ""),
					new(3677, 2295, -3, ""),
					new(3677, 2279, -3, ""),
					new(3676, 2287, -3, ""),
					new(3676, 2277, -3, ""),
					new(3675, 2264, 20, ""),
					new(3674, 2291, -3, ""),
					new(3674, 2281, -3, ""),
					new(3674, 2266, 20, ""),
					new(3673, 2275, -3, ""),
					new(3673, 2267, 20, ""),
					new(3673, 2264, 20, ""),
					new(3673, 2263, 20, ""),
					new(3672, 2287, -3, ""),
					new(3672, 2277, -3, ""),
					new(3678, 2294, -3, ""),
					new(3671, 2288, -3, ""),
					new(3671, 2285, -3, ""),
					new(3671, 2284, -3, ""),
					new(3671, 2278, -3, ""),
					new(3671, 2275, -3, ""),
					new(3671, 2274, -3, ""),
					new(3671, 2268, 20, ""),
					new(3671, 2266, 20, ""),
					new(3671, 2262, 20, ""),
					new(3670, 2294, -3, ""),
					new(3676, 2270, 20, ""),
					new(3670, 2269, 20, ""),
					new(3669, 2294, -3, ""),
					new(3669, 2287, -3, ""),
					new(3669, 2262, 20, ""),
					new(3668, 2295, -3, ""),
					new(3668, 2269, 20, ""),
					new(3673, 2285, -3, ""),
					new(3667, 2294, -3, ""),
					new(3667, 2287, -3, ""),
					new(3666, 2295, -3, ""),
					new(3666, 2266, 20, ""),
					new(3666, 2261, 20, ""),
					new(3664, 2287, -3, ""),
					new(3663, 2291, -3, ""),
					new(3663, 2263, 20, ""),
					new(3661, 2291, -3, ""),
					new(3661, 2287, -3, ""),
					new(3660, 2287, -3, ""),
					new(3668, 2270, 20, ""),
					new(3658, 2287, -3, ""),
					new(3657, 2294, -3, ""),
					new(3657, 2282, -3, ""),
					new(3656, 2294, -3, ""),
					new(3656, 2282, -3, ""),
					new(3655, 2295, -3, ""),
					new(3655, 2287, -3, ""),
					new(3655, 2283, -3, ""),
					new(3654, 2294, -3, ""),
					new(3654, 2291, -3, ""),
					new(3654, 2282, -3, ""),
					new(3653, 2295, -3, ""),
					new(3653, 2283, -3, ""),
					new(3694, 2294, -3, ""),
					new(3694, 2282, -3, ""),
					new(3693, 2294, -3, ""),
					new(3693, 2287, -3, ""),
					new(3693, 2282, -3, ""),
				}),
				new("Wooden Plank", typeof(Static), 1997, "", new DecorationEntry[]
				{
					new(3692, 2299, -3, ""),
					new(3692, 2297, -3, ""),
					new(3692, 2294, -3, ""),
					new(3692, 2293, -3, ""),
					new(3692, 2292, -3, ""),
					new(3692, 2291, -3, ""),
					new(3692, 2290, -3, ""),
					new(3692, 2289, -3, ""),
					new(3692, 2287, -3, ""),
					new(3692, 2285, -3, ""),
					new(3692, 2284, -3, ""),
					new(3692, 2282, -3, ""),
					new(3692, 2281, -3, ""),
					new(3692, 2280, -3, ""),
					new(3691, 2298, -3, ""),
					new(3691, 2297, -3, ""),
					new(3691, 2296, -3, ""),
					new(3691, 2295, -3, ""),
					new(3691, 2292, -3, ""),
					new(3691, 2290, -3, ""),
					new(3691, 2289, -3, ""),
					new(3691, 2288, -3, ""),
					new(3691, 2286, -3, ""),
					new(3691, 2285, -3, ""),
					new(3691, 2284, -3, ""),
					new(3691, 2283, -3, ""),
					new(3691, 2281, -3, ""),
					new(3691, 2280, -3, ""),
					new(3690, 2299, -3, ""),
					new(3690, 2298, -3, ""),
					new(3690, 2297, -3, ""),
					new(3690, 2296, -3, ""),
					new(3690, 2294, -3, ""),
					new(3690, 2293, -3, ""),
					new(3690, 2292, -3, ""),
					new(3690, 2291, -3, ""),
					new(3690, 2290, -3, ""),
					new(3690, 2289, -3, ""),
					new(3690, 2287, -3, ""),
					new(3690, 2286, -3, ""),
					new(3690, 2285, -3, ""),
					new(3690, 2284, -3, ""),
					new(3690, 2282, -3, ""),
					new(3690, 2281, -3, ""),
					new(3690, 2280, -3, ""),
					new(3690, 2279, -3, ""),
					new(3689, 2291, -3, ""),
					new(3689, 2290, -3, ""),
					new(3689, 2289, -3, ""),
					new(3689, 2287, -3, ""),
					new(3688, 2290, -3, ""),
					new(3688, 2289, -3, ""),
					new(3688, 2288, -3, ""),
					new(3687, 2290, -3, ""),
					new(3687, 2289, -3, ""),
					new(3687, 2288, -3, ""),
					new(3687, 2270, 20, ""),
					new(3687, 2268, 20, ""),
					new(3687, 2267, 20, ""),
					new(3687, 2266, 20, ""),
					new(3687, 2265, 20, ""),
					new(3687, 2264, 20, ""),
					new(3687, 2263, 20, ""),
					new(3687, 2262, 20, ""),
					new(3687, 2261, 20, ""),
					new(3686, 2291, -3, ""),
					new(3686, 2289, -3, ""),
					new(3686, 2287, -3, ""),
					new(3686, 2270, 20, ""),
					new(3686, 2269, 20, ""),
					new(3686, 2268, 20, ""),
					new(3686, 2267, 20, ""),
					new(3686, 2266, 20, ""),
					new(3686, 2264, 20, ""),
					new(3694, 2298, -3, ""),
					new(3694, 2288, -3, ""),
					new(3694, 2279, -3, ""),
					new(3693, 2299, -3, ""),
					new(3693, 2297, -3, ""),
					new(3693, 2296, -3, ""),
					new(3686, 2263, 20, ""),
					new(3686, 2262, 20, ""),
					new(3693, 2292, -3, ""),
					new(3686, 2261, 20, ""),
					new(3693, 2284, -3, ""),
					new(3693, 2279, -3, ""),
					new(3685, 2290, -3, ""),
					new(3685, 2289, -3, ""),
					new(3685, 2288, -3, ""),
					new(3685, 2270, 20, ""),
					new(3685, 2269, 20, ""),
					new(3685, 2268, 20, ""),
					new(3685, 2267, 20, ""),
					new(3685, 2266, 20, ""),
					new(3685, 2265, 20, ""),
					new(3685, 2264, 20, ""),
					new(3685, 2263, 20, ""),
					new(3691, 2293, -3, ""),
					new(3687, 2269, 20, ""),
					new(3686, 2290, -3, ""),
					new(3692, 2296, -3, ""),
					new(3684, 2290, -3, ""),
					new(3684, 2289, -3, ""),
					new(3684, 2288, -3, ""),
					new(3684, 2269, 20, ""),
					new(3684, 2268, 20, ""),
					new(3684, 2266, 20, ""),
					new(3684, 2265, 20, ""),
					new(3684, 2264, 20, ""),
					new(3684, 2263, 20, ""),
					new(3684, 2262, 20, ""),
					new(3683, 2291, -3, ""),
					new(3683, 2290, -3, ""),
					new(3683, 2289, -3, ""),
					new(3683, 2287, -3, ""),
					new(3683, 2270, 20, ""),
					new(3683, 2268, 20, ""),
					new(3683, 2267, 20, ""),
					new(3683, 2266, 20, ""),
					new(3683, 2263, 20, ""),
					new(3682, 2290, -3, ""),
					new(3682, 2289, -3, ""),
					new(3682, 2288, -3, ""),
					new(3682, 2270, 20, ""),
					new(3682, 2269, 20, ""),
					new(3682, 2267, 20, ""),
					new(3682, 2265, 20, ""),
					new(3681, 2299, -3, ""),
					new(3681, 2298, -3, ""),
					new(3681, 2297, -3, ""),
					new(3681, 2296, -3, ""),
					new(3681, 2295, -3, ""),
					new(3681, 2293, -3, ""),
					new(3681, 2292, -3, ""),
					new(3681, 2291, -3, ""),
					new(3681, 2290, -3, ""),
					new(3681, 2289, -3, ""),
					new(3681, 2287, -3, ""),
					new(3681, 2270, 20, ""),
					new(3681, 2269, 20, ""),
					new(3681, 2268, 20, ""),
					new(3681, 2266, 20, ""),
					new(3681, 2265, 20, ""),
					new(3681, 2264, 20, ""),
					new(3681, 2263, 20, ""),
					new(3681, 2262, 20, ""),
					new(3680, 2299, -3, ""),
					new(3680, 2297, -3, ""),
					new(3680, 2296, -3, ""),
					new(3680, 2295, -3, ""),
					new(3680, 2293, -3, ""),
					new(3680, 2292, -3, ""),
					new(3680, 2291, -3, ""),
					new(3680, 2290, -3, ""),
					new(3680, 2289, -3, ""),
					new(3680, 2287, -3, ""),
					new(3680, 2270, 20, ""),
					new(3680, 2269, 20, ""),
					new(3680, 2268, 20, ""),
					new(3680, 2267, 20, ""),
					new(3680, 2264, 20, ""),
					new(3679, 2299, -3, ""),
					new(3679, 2297, -3, ""),
					new(3679, 2296, -3, ""),
					new(3679, 2294, -3, ""),
					new(3679, 2293, -3, ""),
					new(3679, 2290, -3, ""),
					new(3679, 2289, -3, ""),
					new(3679, 2288, -3, ""),
					new(3679, 2270, 20, ""),
					new(3679, 2267, 20, ""),
					new(3679, 2266, 20, ""),
					new(3679, 2265, 20, ""),
					new(3679, 2264, 20, ""),
					new(3682, 2264, 20, ""),
					new(3682, 2262, 20, ""),
					new(3682, 2261, 20, ""),
					new(3678, 2298, -3, ""),
					new(3678, 2297, -3, ""),
					new(3678, 2296, -3, ""),
					new(3678, 2295, -3, ""),
					new(3678, 2293, -3, ""),
					new(3678, 2292, -3, ""),
					new(3678, 2290, -3, ""),
					new(3678, 2288, -3, ""),
					new(3678, 2270, 20, ""),
					new(3678, 2269, 20, ""),
					new(3678, 2268, 20, ""),
					new(3678, 2265, 20, ""),
					new(3678, 2264, 20, ""),
					new(3678, 2263, 20, ""),
					new(3677, 2298, -3, ""),
					new(3677, 2297, -3, ""),
					new(3677, 2296, -3, ""),
					new(3677, 2293, -3, ""),
					new(3677, 2292, -3, ""),
					new(3677, 2291, -3, ""),
					new(3681, 2267, 20, ""),
					new(3677, 2289, -3, ""),
					new(3677, 2287, -3, ""),
					new(3677, 2286, -3, ""),
					new(3677, 2285, -3, ""),
					new(3677, 2284, -3, ""),
					new(3677, 2281, -3, ""),
					new(3681, 2261, 20, ""),
					new(3677, 2278, -3, ""),
					new(3677, 2277, -3, ""),
					new(3677, 2276, -3, ""),
					new(3677, 2275, -3, ""),
					new(3677, 2269, 20, ""),
					new(3677, 2267, 20, ""),
					new(3676, 2291, -3, ""),
					new(3676, 2290, -3, ""),
					new(3676, 2286, -3, ""),
					new(3676, 2284, -3, ""),
					new(3676, 2281, -3, ""),
					new(3676, 2280, -3, ""),
					new(3676, 2279, -3, ""),
					new(3676, 2276, -3, ""),
					new(3676, 2275, -3, ""),
					new(3676, 2269, 20, ""),
					new(3676, 2268, 20, ""),
					new(3676, 2267, 20, ""),
					new(3676, 2266, 20, ""),
					new(3676, 2265, 20, ""),
					new(3676, 2264, 20, ""),
					new(3676, 2263, 20, ""),
					new(3675, 2290, -3, ""),
					new(3675, 2288, -3, ""),
					new(3675, 2286, -3, ""),
					new(3675, 2285, -3, ""),
					new(3675, 2280, -3, ""),
					new(3675, 2278, -3, ""),
					new(3675, 2276, -3, ""),
					new(3675, 2275, -3, ""),
					new(3675, 2269, 20, ""),
					new(3675, 2263, 20, ""),
					new(3674, 2290, -3, ""),
					new(3674, 2289, -3, ""),
					new(3674, 2288, -3, ""),
					new(3674, 2287, -3, ""),
					new(3674, 2286, -3, ""),
					new(3674, 2285, -3, ""),
					new(3674, 2280, -3, ""),
					new(3674, 2279, -3, ""),
					new(3674, 2278, -3, ""),
					new(3674, 2277, -3, ""),
					new(3674, 2276, -3, ""),
					new(3674, 2275, -3, ""),
					new(3674, 2270, 20, ""),
					new(3674, 2268, 20, ""),
					new(3674, 2267, 20, ""),
					new(3679, 2292, -3, ""),
					new(3674, 2265, 20, ""),
					new(3674, 2264, 20, ""),
					new(3674, 2263, 20, ""),
					new(3673, 2278, -3, ""),
					new(3673, 2277, -3, ""),
					new(3673, 2274, -3, ""),
					new(3679, 2263, 20, ""),
					new(3673, 2270, 20, ""),
					new(3673, 2268, 20, ""),
					new(3673, 2266, 20, ""),
					new(3673, 2265, 20, ""),
					new(3672, 2291, -3, ""),
					new(3672, 2290, -3, ""),
					new(3672, 2289, -3, ""),
					new(3672, 2288, -3, ""),
					new(3672, 2286, -3, ""),
					new(3672, 2285, -3, ""),
					new(3672, 2284, -3, ""),
					new(3672, 2281, -3, ""),
					new(3672, 2279, -3, ""),
					new(3672, 2278, -3, ""),
					new(3672, 2276, -3, ""),
					new(3672, 2275, -3, ""),
					new(3672, 2274, -3, ""),
					new(3672, 2269, 20, ""),
					new(3672, 2268, 20, ""),
					new(3672, 2267, 20, ""),
					new(3672, 2266, 20, ""),
					new(3672, 2265, 20, ""),
					new(3672, 2264, 20, ""),
					new(3678, 2289, -3, ""),
					new(3671, 2291, -3, ""),
					new(3671, 2290, -3, ""),
					new(3671, 2289, -3, ""),
					new(3671, 2287, -3, ""),
					new(3671, 2286, -3, ""),
					new(3671, 2281, -3, ""),
					new(3671, 2280, -3, ""),
					new(3671, 2279, -3, ""),
					new(3677, 2294, -3, ""),
					new(3671, 2277, -3, ""),
					new(3671, 2276, -3, ""),
					new(3671, 2270, 20, ""),
					new(3671, 2267, 20, ""),
					new(3671, 2265, 20, ""),
					new(3671, 2264, 20, ""),
					new(3671, 2263, 20, ""),
					new(3671, 2261, 20, ""),
					new(3677, 2265, 20, ""),
					new(3677, 2264, 20, ""),
					new(3676, 2289, -3, ""),
					new(3676, 2285, -3, ""),
					new(3670, 2299, -3, ""),
					new(3670, 2298, -3, ""),
					new(3670, 2297, -3, ""),
					new(3670, 2296, -3, ""),
					new(3670, 2295, -3, ""),
					new(3670, 2293, -3, ""),
					new(3670, 2292, -3, ""),
					new(3670, 2291, -3, ""),
					new(3670, 2290, -3, ""),
					new(3670, 2289, -3, ""),
					new(3670, 2288, -3, ""),
					new(3670, 2287, -3, ""),
					new(3670, 2286, -3, ""),
					new(3670, 2285, -3, ""),
					new(3670, 2280, -3, ""),
					new(3670, 2279, -3, ""),
					new(3670, 2278, -3, ""),
					new(3670, 2277, -3, ""),
					new(3670, 2276, -3, ""),
					new(3670, 2275, -3, ""),
					new(3670, 2270, 20, ""),
					new(3670, 2268, 20, ""),
					new(3670, 2267, 20, ""),
					new(3670, 2266, 20, ""),
					new(3670, 2265, 20, ""),
					new(3670, 2264, 20, ""),
					new(3670, 2263, 20, ""),
					new(3670, 2262, 20, ""),
					new(3670, 2261, 20, ""),
					new(3675, 2267, 20, ""),
					new(3675, 2266, 20, ""),
					new(3675, 2265, 20, ""),
					new(3669, 2299, -3, ""),
					new(3669, 2297, -3, ""),
					new(3669, 2296, -3, ""),
					new(3669, 2295, -3, ""),
					new(3669, 2293, -3, ""),
					new(3669, 2292, -3, ""),
					new(3669, 2290, -3, ""),
					new(3669, 2289, -3, ""),
					new(3669, 2288, -3, ""),
					new(3669, 2270, 20, ""),
					new(3669, 2269, 20, ""),
					new(3669, 2268, 20, ""),
					new(3669, 2267, 20, ""),
					new(3674, 2284, -3, ""),
					new(3669, 2266, 20, ""),
					new(3669, 2265, 20, ""),
					new(3669, 2264, 20, ""),
					new(3669, 2263, 20, ""),
					new(3669, 2261, 20, ""),
					new(3674, 2274, -3, ""),
					new(3668, 2299, -3, ""),
					new(3668, 2297, -3, ""),
					new(3668, 2296, -3, ""),
					new(3668, 2294, -3, ""),
					new(3668, 2293, -3, ""),
					new(3668, 2292, -3, ""),
					new(3668, 2291, -3, ""),
					new(3668, 2290, -3, ""),
					new(3668, 2289, -3, ""),
					new(3668, 2287, -3, ""),
					new(3668, 2268, 20, ""),
					new(3668, 2267, 20, ""),
					new(3668, 2266, 20, ""),
					new(3668, 2265, 20, ""),
					new(3668, 2264, 20, ""),
					new(3668, 2263, 20, ""),
					new(3673, 2288, -3, ""),
					new(3668, 2261, 20, ""),
					new(3673, 2284, -3, ""),
					new(3673, 2276, -3, ""),
					new(3667, 2298, -3, ""),
					new(3667, 2297, -3, ""),
					new(3667, 2296, -3, ""),
					new(3667, 2295, -3, ""),
					new(3667, 2293, -3, ""),
					new(3667, 2292, -3, ""),
					new(3667, 2290, -3, ""),
					new(3667, 2289, -3, ""),
					new(3667, 2288, -3, ""),
					new(3667, 2270, 20, ""),
					new(3667, 2268, 20, ""),
					new(3667, 2267, 20, ""),
					new(3667, 2266, 20, ""),
					new(3667, 2265, 20, ""),
					new(3667, 2264, 20, ""),
					new(3667, 2263, 20, ""),
					new(3667, 2262, 20, ""),
					new(3667, 2261, 20, ""),
					new(3666, 2299, -3, ""),
					new(3666, 2298, -3, ""),
					new(3666, 2297, -3, ""),
					new(3666, 2296, -3, ""),
					new(3666, 2290, -3, ""),
					new(3666, 2289, -3, ""),
					new(3666, 2287, -3, ""),
					new(3666, 2270, 20, ""),
					new(3666, 2269, 20, ""),
					new(3666, 2268, 20, ""),
					new(3666, 2267, 20, ""),
					new(3666, 2265, 20, ""),
					new(3666, 2263, 20, ""),
					new(3666, 2262, 20, ""),
					new(3677, 2299, -3, ""),
					new(3665, 2291, -3, ""),
					new(3665, 2290, -3, ""),
					new(3665, 2289, -3, ""),
					new(3665, 2287, -3, ""),
					new(3665, 2268, 20, ""),
					new(3665, 2267, 20, ""),
					new(3665, 2266, 20, ""),
					new(3665, 2265, 20, ""),
					new(3665, 2264, 20, ""),
					new(3665, 2263, 20, ""),
					new(3665, 2262, 20, ""),
					new(3676, 2274, -3, ""),
					new(3664, 2290, -3, ""),
					new(3664, 2289, -3, ""),
					new(3664, 2288, -3, ""),
					new(3664, 2270, 20, ""),
					new(3664, 2269, 20, ""),
					new(3664, 2268, 20, ""),
					new(3664, 2264, 20, ""),
					new(3664, 2263, 20, ""),
					new(3664, 2261, 20, ""),
					new(3663, 2289, -3, ""),
					new(3663, 2288, -3, ""),
					new(3663, 2270, 20, ""),
					new(3663, 2269, 20, ""),
					new(3663, 2268, 20, ""),
					new(3663, 2267, 20, ""),
					new(3663, 2266, 20, ""),
					new(3663, 2265, 20, ""),
					new(3663, 2264, 20, ""),
					new(3663, 2261, 20, ""),
					new(3662, 2291, -3, ""),
					new(3662, 2290, -3, ""),
					new(3662, 2289, -3, ""),
					new(3662, 2287, -3, ""),
					new(3661, 2290, -3, ""),
					new(3661, 2289, -3, ""),
					new(3661, 2288, -3, ""),
					new(3660, 2290, -3, ""),
					new(3660, 2289, -3, ""),
					new(3660, 2288, -3, ""),
					new(3659, 2291, -3, ""),
					new(3659, 2290, -7, ""),
					new(3673, 2280, -3, ""),
					new(3659, 2289, -3, ""),
					new(3659, 2287, -3, ""),
					new(3658, 2291, -3, ""),
					new(3658, 2290, -3, ""),
					new(3658, 2290, -7, ""),
					new(3658, 2289, -3, ""),
					new(3658, 2288, -3, ""),
					new(3657, 2299, -3, ""),
					new(3657, 2298, -3, ""),
					new(3657, 2297, -3, ""),
					new(3657, 2296, -3, ""),
					new(3657, 2295, -3, ""),
					new(3657, 2293, -3, ""),
					new(3657, 2292, -3, ""),
					new(3657, 2291, -3, ""),
					new(3673, 2269, 20, ""),
					new(3657, 2290, -3, ""),
					new(3657, 2289, -3, ""),
					new(3657, 2288, -3, ""),
					new(3657, 2287, -3, ""),
					new(3657, 2286, -3, ""),
					new(3657, 2285, -3, ""),
					new(3657, 2284, -3, ""),
					new(3657, 2283, -3, ""),
					new(3657, 2281, -3, ""),
					new(3657, 2280, -3, ""),
					new(3657, 2279, -3, ""),
					new(3656, 2299, -3, ""),
					new(3656, 2297, -3, ""),
					new(3656, 2296, -3, ""),
					new(3656, 2295, -3, ""),
					new(3656, 2293, -3, ""),
					new(3656, 2292, -3, ""),
					new(3656, 2291, -3, ""),
					new(3672, 2280, -3, ""),
					new(3656, 2290, -3, ""),
					new(3656, 2289, -3, ""),
					new(3656, 2287, -3, ""),
					new(3656, 2285, -3, ""),
					new(3656, 2284, -3, ""),
					new(3656, 2283, -3, ""),
					new(3656, 2281, -3, ""),
					new(3656, 2280, -3, ""),
					new(3656, 2279, -3, ""),
					new(3655, 2299, -3, ""),
					new(3655, 2297, -3, ""),
					new(3655, 2296, -3, ""),
					new(3655, 2294, -3, ""),
					new(3655, 2293, -3, ""),
					new(3655, 2292, -3, ""),
					new(3655, 2289, -3, ""),
					new(3655, 2288, -3, ""),
					new(3655, 2285, -3, ""),
					new(3655, 2284, -3, ""),
					new(3655, 2282, -3, ""),
					new(3655, 2281, -3, ""),
					new(3666, 2294, -3, ""),
					new(3655, 2280, -3, ""),
					new(3666, 2293, -3, ""),
					new(3666, 2292, -3, ""),
					new(3666, 2291, -3, ""),
					new(3654, 2298, -3, ""),
					new(3654, 2297, -3, ""),
					new(3654, 2296, -3, ""),
					new(3654, 2295, -3, ""),
					new(3654, 2293, -3, ""),
					new(3654, 2292, -3, ""),
					new(3654, 2290, -3, ""),
					new(3654, 2289, -3, ""),
					new(3654, 2288, -3, ""),
					new(3654, 2286, -3, ""),
					new(3654, 2285, -3, ""),
					new(3654, 2284, -3, ""),
					new(3654, 2283, -3, ""),
					new(3654, 2281, -3, ""),
					new(3654, 2280, -3, ""),
					new(3677, 2290, -3, ""),
					new(3653, 2299, -3, ""),
					new(3653, 2298, -3, ""),
					new(3653, 2297, -3, ""),
					new(3653, 2296, -3, ""),
					new(3653, 2293, -3, ""),
					new(3653, 2292, -3, ""),
					new(3653, 2291, -3, ""),
					new(3653, 2290, -3, ""),
					new(3653, 2289, -3, ""),
					new(3653, 2287, -3, ""),
					new(3653, 2282, -3, ""),
					new(3653, 2281, -3, ""),
					new(3653, 2280, -3, ""),
					new(3653, 2279, -3, ""),
					new(3664, 2267, 20, ""),
					new(3664, 2265, 20, ""),
					new(3663, 2290, -3, ""),
					new(3663, 2262, 20, ""),
					new(3674, 2269, 20, ""),
					new(3673, 2290, -3, ""),
					new(3673, 2286, -3, ""),
					new(3655, 2290, -3, ""),
					new(3666, 2264, 20, ""),
					new(3653, 2285, -3, ""),
					new(3653, 2284, -3, ""),
					new(3665, 2269, 20, ""),
					new(3664, 2266, 20, ""),
					new(3673, 2287, -3, ""),
					new(3653, 2294, -3, ""),
					new(3653, 2286, -3, ""),
					new(3694, 2299, -3, ""),
					new(3694, 2297, -3, ""),
					new(3694, 2296, -3, ""),
					new(3694, 2295, -3, ""),
					new(3694, 2293, -3, ""),
					new(3694, 2292, -3, ""),
					new(3694, 2291, -3, ""),
					new(3694, 2290, -3, ""),
					new(3694, 2289, -3, ""),
					new(3694, 2287, -3, ""),
					new(3694, 2286, -3, ""),
					new(3694, 2285, -3, ""),
					new(3694, 2284, -3, ""),
					new(3694, 2283, -3, ""),
					new(3694, 2281, -3, ""),
					new(3694, 2280, -3, ""),
					new(3693, 2295, -3, ""),
					new(3693, 2293, -3, ""),
					new(3693, 2290, -3, ""),
					new(3693, 2289, -3, ""),
					new(3693, 2288, -3, ""),
					new(3693, 2285, -3, ""),
					new(3693, 2283, -3, ""),
					new(3693, 2281, -3, ""),
					new(3693, 2280, -3, ""),
				}),
				new("Stone Ruins", typeof(Static), 966, "", new DecorationEntry[]
				{
					new(3735, 2186, 20, ""),
					new(3665, 2239, 20, ""),
					new(3736, 2060, 5, ""),
					new(3730, 2039, 5, ""),
					new(3741, 2154, 20, ""),
					new(3680, 2186, 20, ""),
					new(3722, 2161, 20, ""),
					new(3745, 2067, 5, ""),
					new(3673, 2083, 21, ""),
					new(3674, 2134, 20, ""),
					new(3721, 2165, 20, ""),
					new(3716, 2121, 20, ""),
					new(3656, 2251, 20, ""),
					new(3769, 2223, 20, ""),
					new(3774, 2218, 13, ""),
					new(3718, 2216, 20, ""),
					new(3724, 2224, 20, ""),
					new(3721, 2207, 20, ""),
					new(3653, 2089, 20, ""),
					new(3764, 2231, 20, ""),
					new(3706, 2172, 20, ""),
					new(3701, 2139, 20, ""),
					new(3756, 2230, 20, ""),
					new(3728, 2161, 20, ""),
					new(3691, 2193, 20, ""),
					new(3697, 2170, 20, ""),
				}),
				new("Stone Ruins", typeof(Static), 956, "", new DecorationEntry[]
				{
					new(3730, 2176, 20, ""),
					new(3728, 2047, 5, ""),
					new(3694, 2168, 20, ""),
					new(3740, 2077, 5, ""),
					new(3744, 2070, 5, ""),
					new(3713, 2050, 5, ""),
					new(3699, 2053, 5, ""),
					new(3700, 2238, 20, ""),
					new(3732, 2160, 20, ""),
					new(3668, 2114, 20, ""),
					new(3730, 2112, 20, ""),
					new(3758, 2136, 23, ""),
					new(3693, 2251, 20, ""),
					new(3675, 2197, 20, ""),
					new(3688, 2113, 20, ""),
					new(3732, 2172, 20, ""),
					new(3677, 2105, 20, ""),
					new(3673, 2209, 20, ""),
					new(3682, 2099, 20, ""),
					new(3731, 2117, 20, ""),
					new(3668, 2253, 20, ""),
					new(3715, 2201, 20, ""),
					new(3730, 2124, 20, ""),
					new(3711, 2127, 20, ""),
					new(3783, 2102, 20, ""),
					new(3785, 2108, 20, ""),
					new(3707, 2120, 20, ""),
					new(3779, 2097, 20, ""),
					new(3702, 2158, 20, ""),
					new(3711, 2180, 20, ""),
					new(3781, 2103, 20, ""),
					new(3724, 2050, 5, ""),
					new(3692, 2223, 20, ""),
					new(3660, 2163, 20, ""),
					new(3701, 2177, 20, ""),
					new(3674, 2180, 20, ""),
				}),
				new("Stone Ruins", typeof(Static), 957, "", new DecorationEntry[]
				{
					new(3662, 2121, 20, ""),
					new(3745, 2064, 5, ""),
					new(3753, 2051, 13, ""),
					new(3711, 2203, 20, ""),
					new(3687, 2212, 20, ""),
					new(3689, 2168, 20, ""),
					new(3679, 2201, 20, ""),
					new(3698, 2061, 5, ""),
					new(3672, 2120, 20, ""),
					new(3730, 2152, 20, ""),
					new(3659, 2238, 20, ""),
					new(3696, 2055, 5, ""),
					new(3673, 2255, 20, ""),
					new(3664, 2120, 20, ""),
					new(3744, 2051, 5, ""),
					new(3710, 2108, 20, ""),
					new(3715, 2152, 20, ""),
					new(3707, 2116, 20, ""),
					new(3671, 2179, 20, ""),
					new(3719, 2124, 20, ""),
					new(3697, 2177, 20, ""),
					new(3675, 2175, 20, ""),
					new(3757, 2226, 20, ""),
					new(3715, 2061, 5, ""),
					new(3707, 2146, 20, ""),
					new(3762, 2228, 20, ""),
					new(3685, 2152, 20, ""),
					new(3701, 2185, 20, ""),
					new(3737, 2043, 5, ""),
				}),
				new("Fern", typeof(Static), 3235, "Hue=0x497", new DecorationEntry[]
				{
					new(3669, 2043, 20, ""),
					new(3753, 2187, -15, ""),
					new(3634, 2073, 8, ""),
					new(3806, 2136, 20, ""),
					new(3732, 2083, 5, ""),
					new(3653, 2250, 20, ""),
					new(3765, 2277, 19, ""),
					new(3640, 2067, 20, ""),
					new(3637, 2077, 20, ""),
					new(3748, 2200, 20, ""),
					new(3650, 2201, 20, ""),
				}),
				
				#endregion
			});
		}
	}
}
