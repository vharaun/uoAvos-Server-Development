using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] HedgeMaze { get; } = Register(DecorationTarget.Britannia, "Hedge Maze", new DecorationList[]
			{
				#region Entries
				
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(1163, 2205, 0)", new DecorationEntry[]
				{
					new(1166, 2237, 60, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(1163, 2211, 60)", new DecorationEntry[]
				{
					new(1165, 2204, 40, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(1165, 2214, 19)", new DecorationEntry[]
				{
					new(1163, 2208, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(1171, 2202, 0)", new DecorationEntry[]
				{
					new(1163, 2204, 60, ""),
				}),
				new("Lantern", typeof(Lantern), 2594, "", new DecorationEntry[]
				{
					new(1132, 2227, 46, ""),
				}),
				new("Grasses", typeof(Static), 3244, "", new DecorationEntry[]
				{
					new(1186, 2216, 0, ""),
				}),
				new("Century Plant", typeof(Static), 3376, "", new DecorationEntry[]
				{
					new(1194, 2217, 0, ""),
				}),
				new("Peach Tree", typeof(Static), 3486, "", new DecorationEntry[]
				{
					new(1195, 2269, 0, ""),
				}),
				new("Pear Tree", typeof(Static), 3498, "", new DecorationEntry[]
				{
					new(1205, 2269, 0, ""),
				}),
				new("Pear Tree", typeof(Static), 3494, "", new DecorationEntry[]
				{
					new(1206, 2184, 0, ""),
				}),
				new("Cactus", typeof(Static), 3367, "", new DecorationEntry[]
				{
					new(1206, 2225, 0, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "", new DecorationEntry[]
				{
					new(1213, 2191, 13, ""),
				}),
				new("Stone Wall", typeof(Static), 489, "", new DecorationEntry[]
				{
					new(1214, 2258, 25, ""),
				}),
				new("Fountain", typeof(StoneFountainAddon), 5946, "", new DecorationEntry[]
				{
					new(1233, 2219, 0, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(1128, 2218, 43, ""),
				}),
				new("Pillow", typeof(Static), 5036, "", new DecorationEntry[]
				{
					new(1129, 2217, 62, ""),
				}),
				new("Cypress Tree", typeof(Static), 3326, "", new DecorationEntry[]
				{
					new(1246, 2200, 0, ""),
				}),
				new("Vines", typeof(Static), 3167, "", new DecorationEntry[]
				{
					new(1249, 2173, 0, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016380", new DecorationEntry[]
				{
					new(1252, 2145, 9, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016196", new DecorationEntry[]
				{
					new(1260, 2316, 9, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016385", new DecorationEntry[]
				{
					new(1260, 2313, 11, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016231", new DecorationEntry[]
				{
					new(1268, 2190, 7, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016412", new DecorationEntry[]
				{
					new(1284, 2256, 6, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016379", new DecorationEntry[]
				{
					new(1072, 2322, 7, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016382", new DecorationEntry[]
				{
					new(1128, 2313, 6, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016389", new DecorationEntry[]
				{
					new(1184, 2316, 6, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016378", new DecorationEntry[]
				{
					new(1212, 2133, 6, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016195", new DecorationEntry[]
				{
					new(1132, 2145, 8, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016125", new DecorationEntry[]
				{
					new(1024, 2157, 5, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016388", new DecorationEntry[]
				{
					new(1028, 2238, 7, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016109", new DecorationEntry[]
				{
					new(1028, 2307, 2, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2150, "Facing=WestCW", new DecorationEntry[]
				{
					new(1131, 2237, 40, ""),
					new(1131, 2237, 50, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(1132, 2216, 40, ""),
					new(1138, 2231, 40, ""),
					new(1166, 2232, 60, ""),
					new(1160, 2209, 40, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(1132, 2231, 40, ""),
					new(1132, 2230, 40, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2152, "Facing=EastCCW", new DecorationEntry[]
				{
					new(1132, 2237, 40, ""),
					new(1132, 2237, 50, ""),
				}),
				new("Book", typeof(Static), 7712, "", new DecorationEntry[]
				{
					new(1133, 2235, 24, ""),
					new(1137, 2221, 64, ""),
					new(1164, 2206, 62, ""),
					new(1164, 2236, 60, ""),
				}),
				new("Books", typeof(Static), 7713, "", new DecorationEntry[]
				{
					new(1135, 2235, 24, ""),
					new(1136, 2230, 44, ""),
					new(1163, 2234, 60, ""),
					new(1132, 2227, 46, ""),
					new(1162, 2206, 62, ""),
					new(1164, 2208, 41, ""),
					new(1164, 2243, 46, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(1136, 2219, 44, ""),
					new(1134, 2219, 44, ""),
					new(1129, 2218, 43, ""),
					new(1129, 2218, 44, ""),
					new(1133, 2220, 44, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(1135, 2225, 40, ""),
				}),
				new("Garbage", typeof(Static), 4335, "", new DecorationEntry[]
				{
					new(1136, 2220, 44, ""),
					new(1163, 2236, 61, ""),
					new(1161, 2209, 41, ""),
					new(1129, 2235, 40, ""),
					new(1130, 2217, 40, ""),
					new(1165, 2206, 0, ""),
					new(1166, 2235, 40, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(1133, 2221, 40, ""),
					new(1136, 2221, 40, ""),
					new(1134, 2221, 40, ""),
					new(1135, 2221, 40, ""),
				}),
				new("Books", typeof(Static), 7714, "", new DecorationEntry[]
				{
					new(1138, 2222, 64, ""),
					new(1165, 2243, 46, ""),
				}),
				new("Glass", typeof(Static), 8067, "", new DecorationEntry[]
				{
					new(1132, 2221, 64, ""),
				}),
				new("Pitcher Of Wine", typeof(Static), 8091, "", new DecorationEntry[]
				{
					new(1133, 2221, 64, ""),
				}),
				new("Garbage", typeof(Static), 4337, "", new DecorationEntry[]
				{
					new(1134, 2220, 44, ""),
					new(1137, 2234, 40, ""),
					new(1163, 2209, 0, ""),
					new(1164, 2207, 41, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4338, "", new DecorationEntry[]
				{
					new(1159, 2234, 21, ""),
				}),
				new("Wall Torch", typeof(Static), 2565, "", new DecorationEntry[]
				{
					new(1160, 2206, 54, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(1161, 2235, 21, ""),
					new(1138, 2217, 40, ""),
					new(1166, 2237, 40, ""),
				}),
				new("Skull With Candle", typeof(Static), 6227, "", new DecorationEntry[]
				{
					new(1163, 2207, 41, ""),
				}),
				new("Debris", typeof(Static), 3118, "", new DecorationEntry[]
				{
					new(1163, 2236, 61, ""),
					new(1165, 2245, 40, ""),
				}),
				new("Dirt", typeof(Static), 7677, "", new DecorationEntry[]
				{
					new(1163, 2240, 40, ""),
				}),
				new("Garbage", typeof(Static), 4336, "", new DecorationEntry[]
				{
					new(1164, 2234, 61, ""),
					new(1130, 2217, 40, ""),
					new(1161, 2205, 0, ""),
				}),
				new("Sparkle", typeof(Static), 14170, "", new DecorationEntry[]
				{
					new(1165, 2204, 40, ""),
					new(1166, 2237, 62, ""),
					new(1163, 2204, 60, ""),
				}),
				new("Broken Chair", typeof(Static), 3099, "", new DecorationEntry[]
				{
					new(1165, 2241, 40, ""),
				}),
				new("Red Potion", typeof(Static), 3851, "", new DecorationEntry[]
				{
					new(1138, 2223, 64, ""),
				}),
				new("Lilypad", typeof(Static), 3337, "", new DecorationEntry[]
				{
					new(1248, 2200, 1, ""),
				}),
				new("Pear%S%", typeof(Static), 5933, "", new DecorationEntry[]
				{
					new(1207, 2270, 0, ""),
					new(1207, 2269, 0, ""),
					new(1205, 2268, 0, ""),
					new(1206, 2270, 0, ""),
				}),
				new("Open Sack Of Flour", typeof(Static), 4166, "", new DecorationEntry[]
				{
					new(1130, 2219, 40, ""),
				}),
				new("Dirt Patch", typeof(Static), 2324, "", new DecorationEntry[]
				{
					new(1083, 2266, 0, ""),
					new(1041, 2248, 0, ""),
				}),
				new("Grave", typeof(Static), 3809, "", new DecorationEntry[]
				{
					new(1083, 2265, 0, ""),
					new(1041, 2247, 0, ""),
				}),
				new("Leaves", typeof(Static), 6948, "Hue=0x970", new DecorationEntry[]
				{
					new(1084, 2265, 0, ""),
					new(1042, 2247, 0, ""),
				}),
				new("Grave", typeof(Static), 3808, "", new DecorationEntry[]
				{
					new(1084, 2266, 0, ""),
					new(1042, 2248, 0, ""),
				}),
				new("Leaves", typeof(Static), 6947, "Hue=0x970", new DecorationEntry[]
				{
					new(1084, 2267, 0, ""),
					new(1042, 2249, 0, ""),
				}),
				new("Grave", typeof(Static), 3795, "", new DecorationEntry[]
				{
					new(1083, 2267, 0, ""),
					new(1041, 2249, 0, ""),
				}),
				new("Leaves", typeof(Static), 6950, "Hue=0x970", new DecorationEntry[]
				{
					new(1082, 2267, 0, ""),
					new(1040, 2249, 0, ""),
				}),
				new("Bucket", typeof(Static), 5344, "", new DecorationEntry[]
				{
					new(1129, 2238, 40, ""),
					new(1138, 2238, 40, ""),
				}),
				new("Coconut%S%", typeof(Static), 5926, "", new DecorationEntry[]
				{
					new(1097, 2193, 0, ""),
					new(1092, 2188, 0, ""),
					new(1100, 2191, 0, ""),
					new(1101, 2193, 0, ""),
					new(1100, 2193, 0, ""),
					new(1090, 2192, 0, ""),
					new(1092, 2192, 0, ""),
					new(1090, 2189, 0, ""),
					new(1099, 2191, 0, ""),
				}),
				new("Leaves", typeof(Static), 6949, "Hue=0x970", new DecorationEntry[]
				{
					new(1082, 2265, 0, ""),
					new(1040, 2247, 0, ""),
				}),
				new("Bottle Of Ale", typeof(BeverageBottle), 2463, "Content=Ale", new DecorationEntry[]
				{
					new(1162, 2233, 40, ""),
				}),
				new("Apple%S%", typeof(Static), 2512, "", new DecorationEntry[]
				{
					new(1053, 2228, 0, ""),
					new(1052, 2231, 0, ""),
					new(1201, 2263, 0, ""),
					new(1202, 2265, 0, ""),
					new(1204, 2265, 0, ""),
					new(1204, 2266, 0, ""),
					new(1054, 2228, 0, ""),
					new(1054, 2227, 0, ""),
					new(1200, 2265, 0, ""),
					new(1052, 2228, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(1213, 2259, 5, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(1064, 2202, 10, ""),
				}),
				new("Fireplace", typeof(StoneFireplaceEastAddon), 2393, "", new DecorationEntry[]
				{
					new(1128, 2216, 40, ""),
					new(1128, 2216, 60, ""),
				}),
				new("Blood", typeof(Static), 4651, "", new DecorationEntry[]
				{
					new(1115, 2231, 4, ""),
				}),
				new("Blood", typeof(Static), 4650, "Hue=0x1", new DecorationEntry[]
				{
					new(1041, 2248, 0, ""),
				}),
				new("Grave", typeof(Static), 3810, "", new DecorationEntry[]
				{
					new(1040, 2248, 0, ""),
					new(1082, 2266, 0, ""),
				}),
				new("Wedge%S% Of Cheese", typeof(Static), 2428, "", new DecorationEntry[]
				{
					new(1132, 2221, 64, ""),
				}),
				new("Banana%S%", typeof(Static), 5920, "", new DecorationEntry[]
				{
					new(1133, 2222, 64, ""),
				}),
				new("Bunch%Es% Of Dates", typeof(Static), 5927, "", new DecorationEntry[]
				{
					new(1166, 2280, 0, ""),
					new(1165, 2279, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(1067, 2268, 5, ""),
					new(1134, 2226, 40, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(1073, 2195, 5, ""),
				}),
				new("Peach%Es%", typeof(Static), 2514, "", new DecorationEntry[]
				{
					new(1193, 2271, 0, ""),
					new(1196, 2271, 0, ""),
					new(1197, 2268, 0, ""),
					new(1195, 2269, 0, ""),
				}),
				new("Pizza%S%", typeof(Static), 4160, "", new DecorationEntry[]
				{
					new(1136, 2216, 46, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(1160, 2204, 0, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(1164, 2205, 0, ""),
				}),
				new("Glass Of Water", typeof(Static), 8081, "", new DecorationEntry[]
				{
					new(1133, 2221, 64, ""),
				}),
				new("Empty Bottle%S%", typeof(Static), 3854, "", new DecorationEntry[]
				{
					new(1165, 2234, 63, ""),
					new(1132, 2235, 26, ""),
				}),
				new("Heating Stand", typeof(Static), 6222, "", new DecorationEntry[]
				{
					new(1161, 2208, 41, ""),
				}),
				new("Glass", typeof(Static), 8065, "", new DecorationEntry[]
				{
					new(1133, 2221, 64, ""),
				}),
				new("Dagger", typeof(Static), 3922, "", new DecorationEntry[]
				{
					new(1134, 2235, 23, ""),
				}),
				new("Dagger", typeof(Static), 3921, "", new DecorationEntry[]
				{
					new(1129, 2232, 20, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1713, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(1131, 2228, 40, ""),
					new(1135, 2219, 60, ""),
					new(1139, 2236, 40, ""),
				}),
				new("Glass Of Water", typeof(Static), 8083, "", new DecorationEntry[]
				{
					new(1132, 2221, 64, ""),
					new(1133, 2222, 64, ""),
				}),
				new("Pitcher Of Water", typeof(Static), 8093, "", new DecorationEntry[]
				{
					new(1133, 2221, 64, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(1131, 2216, 60, ""),
				}),
				new("Iron Ore", typeof(Static), 6584, "", new DecorationEntry[]
				{
					new(1129, 2223, 20, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(1141, 2234, 40, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1715, "Facing=NorthCW", new DecorationEntry[]
				{
					new(1139, 2235, 40, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1667, "Facing=NorthCW", new DecorationEntry[]
				{
					new(1140, 2228, 20, ""),
				}),
				new("Wand", typeof(Static), 3570, "", new DecorationEntry[]
				{
					new(1137, 2221, 66, ""),
				}),
				new("Bottle Of Wine", typeof(BeverageBottle), 2503, "Content=Wine", new DecorationEntry[]
				{
					new(1135, 2230, 44, ""),
				}),
				new("Book", typeof(RedBook), 4081, "", new DecorationEntry[]
				{
					new(1161, 2207, 41, ""),
					new(1164, 2232, 60, ""),
				}),
				new("Books", typeof(Static), 7715, "", new DecorationEntry[]
				{
					new(1136, 2229, 44, ""),
				}),
				new("Bucket Of Water", typeof(Static), 4090, "", new DecorationEntry[]
				{
					new(1129, 2238, 40, ""),
					new(1138, 2238, 40, ""),
				}),
				new("Apple Tree", typeof(Static), 3478, "", new DecorationEntry[]
				{
					new(1202, 2265, 0, ""),
					new(1054, 2229, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(1064, 2206, 5, ""),
					new(1064, 2206, 17, ""),
					new(1064, 2205, 5, ""),
					new(1064, 2204, 17, ""),
					new(1064, 2203, 5, ""),
				}),
				new("Alchemical Symbol", typeof(Static), 6178, "", new DecorationEntry[]
				{
					new(1163, 2208, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(1064, 2205, 17, ""),
					new(1064, 2204, 5, ""),
					new(1064, 2203, 17, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(1132, 2222, 64, ""),
				}),
				new("Cut%S% Of Raw Ribs", typeof(Static), 2545, "", new DecorationEntry[]
				{
					new(1134, 2216, 46, ""),
				}),
				new("Yellow Potion", typeof(Static), 3852, "", new DecorationEntry[]
				{
					new(1163, 2210, 3, ""),
				}),
				new("Black Potion", typeof(Static), 3846, "", new DecorationEntry[]
				{
					new(1165, 2233, 63, ""),
				}),
				new("Blue Potion", typeof(Static), 3848, "", new DecorationEntry[]
				{
					new(1165, 2235, 63, ""),
				}),
				new("Bed", typeof(LargeBedSouthAddon), 2691, "", new DecorationEntry[]
				{
					new(1133, 2216, 60, ""),
				}),
				new("Chair", typeof(Static), 2895, "", new DecorationEntry[]
				{
					new(1136, 2218, 40, ""),
					new(1133, 2218, 40, ""),
					new(1134, 2218, 40, ""),
					new(1135, 2218, 40, ""),
				}),
				new("Ham%S%", typeof(Static), 2515, "", new DecorationEntry[]
				{
					new(1133, 2216, 46, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(1138, 2233, 40, ""),
				}),
				new("Pan Of Cookies", typeof(Static), 5643, "", new DecorationEntry[]
				{
					new(1135, 2216, 46, ""),
				}),
				new("Broken Chair", typeof(Static), 3098, "", new DecorationEntry[]
				{
					new(1163, 2243, 40, ""),
					new(1161, 2240, 40, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4096, "", new DecorationEntry[]
				{
					new(1164, 2235, 46, ""),
				}),
				new("Debris", typeof(Static), 3119, "", new DecorationEntry[]
				{
					new(1164, 2235, 60, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4097, "", new DecorationEntry[]
				{
					new(1164, 2236, 46, ""),
				}),
				new("A Daemon Summoning Scroll", typeof(LocalizedStatic), 8041, "LabelNumber=1016017", new DecorationEntry[]
				{
					new(1165, 2204, 60, ""),
				}),
				new("Pillow", typeof(Static), 5691, "", new DecorationEntry[]
				{
					new(1130, 2216, 62, ""),
					new(1129, 2217, 62, ""),
				}),
				new("Wand", typeof(Static), 3573, "", new DecorationEntry[]
				{
					new(1134, 2218, 65, ""),
				}),
				new("Silverware", typeof(Static), 2494, "", new DecorationEntry[]
				{
					new(1136, 2219, 44, ""),
					new(1134, 2219, 44, ""),
				}),
				new("Small Palm", typeof(Static), 3225, "", new DecorationEntry[]
				{
					new(1061, 2248, 0, ""),
				}),
				new("Grasses", typeof(Static), 3246, "", new DecorationEntry[]
				{
					new(1063, 2209, 0, ""),
				}),
				new("Clock", typeof(Static), 4171, "", new DecorationEntry[]
				{
					new(1064, 2202, 19, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(1065, 2202, 5, ""),
					new(1065, 2207, 5, ""),
				}),
				new("Globe", typeof(Static), 4167, "", new DecorationEntry[]
				{
					new(1068, 2199, 16, ""),
				}),
				new("Tile Roof", typeof(Static), 1460, "", new DecorationEntry[]
				{
					new(1070, 2197, 47, ""),
				}),
				new("Hedge", typeof(Static), 3512, "", new DecorationEntry[]
				{
					new(1082, 2219, 0, ""),
				}),
				new("Coconut Palm", typeof(Static), 3221, "", new DecorationEntry[]
				{
					new(1091, 2190, 0, ""),
					new(1099, 2191, 0, ""),
				}),
				new("Orfluer Flowers", typeof(Static), 3205, "", new DecorationEntry[]
				{
					new(1123, 2165, 0, ""),
				}),
				new("Wedge%S% Of Cheese", typeof(Static), 2429, "", new DecorationEntry[]
				{
					new(1131, 2216, 46, ""),
				}),
				new("Fork", typeof(Fork), 2467, "", new DecorationEntry[]
				{
					new(1128, 2218, 43, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(1128, 2236, 40, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(1129, 2216, 40, ""),
				}),
				new("Pillow", typeof(Static), 5038, "Hue=0xE8", new DecorationEntry[]
				{
					new(1129, 2216, 61, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(1129, 2218, 44, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(1129, 2218, 44, ""),
				}),
				new("Stone Pavers", typeof(Static), 1309, "", new DecorationEntry[]
				{
					new(1129, 2230, 20, ""),
					new(1132, 2228, 20, ""),
				}),
				new("Pilllow", typeof(Static), 5690, "", new DecorationEntry[]
				{
					new(1130, 2217, 61, ""),
				}),
				new("Tray", typeof(Static), 2449, "", new DecorationEntry[]
				{
					new(1131, 2216, 46, ""),
				}),
				new("Frypan", typeof(Static), 2530, "", new DecorationEntry[]
				{
					new(1131, 2217, 46, ""),
				}),
				new("Spilled Flour", typeof(Static), 6273, "", new DecorationEntry[]
				{
					new(1131, 2219, 40, ""),
				}),
				new("Candelabra", typeof(Static), 2847, "", new DecorationEntry[]
				{
					new(1132, 2216, 66, ""),
				}),
				new("Pitcher", typeof(Static), 2518, "", new DecorationEntry[]
				{
					new(1132, 2219, 44, ""),
				}),
				new("Glass Of Wine", typeof(Static), 8079, "", new DecorationEntry[]
				{
					new(1132, 2221, 64, ""),
					new(1133, 2222, 64, ""),
				}),
				new("Brazier", typeof(Brazier), 3633, "", new DecorationEntry[]
				{
					new(1132, 2223, 23, ""),
				}),
				new("Bed", typeof(Static), 2687, "", new DecorationEntry[]
				{
					new(1133, 2217, 60, ""),
				}),
				new("Silverware", typeof(Static), 2516, "", new DecorationEntry[]
				{
					new(1133, 2220, 44, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(1133, 2220, 64, ""),
				}),
				new("Glass Pitcher", typeof(Static), 4086, "", new DecorationEntry[]
				{
					new(1133, 2221, 64, ""),
				}),
				new("Stone", typeof(Static), 1822, "", new DecorationEntry[]
				{
					new(1133, 2223, 18, ""),
				}),
				new("Bed", typeof(Static), 2690, "", new DecorationEntry[]
				{
					new(1134, 2216, 60, ""),
				}),
				new("Bed", typeof(Static), 2686, "", new DecorationEntry[]
				{
					new(1134, 2217, 60, ""),
				}),
				new("Folded Sheet", typeof(Static), 2707, "", new DecorationEntry[]
				{
					new(1134, 2218, 64, ""),
				}),
				new("Folded Blanket", typeof(Static), 2671, "", new DecorationEntry[]
				{
					new(1134, 2225, 40, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(1134, 2229, 40, ""),
					new(1134, 2230, 40, ""),
					new(1136, 2221, 60, ""),
					new(1136, 2223, 60, ""),
				}),
				new("Books", typeof(Static), 7716, "", new DecorationEntry[]
				{
					new(1135, 2229, 44, ""),
				}),
				new("Goblet", typeof(Static), 2495, "", new DecorationEntry[]
				{
					new(1135, 2230, 44, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(1136, 2228, 40, ""),
				}),
				new("Goblet", typeof(Static), 2483, "", new DecorationEntry[]
				{
					new(1136, 2229, 44, ""),
				}),
				new("Lantern", typeof(Static), 2597, "", new DecorationEntry[]
				{
					new(1132, 2227, 46, ""),
				}),
				new("Candelabra", typeof(Static), 2855, "", new DecorationEntry[]
				{
					new(1137, 2216, 40, ""),
					new(1138, 2223, 40, ""),
				}),
				new("Crystal Ball", typeof(Static), 3629, "", new DecorationEntry[]
				{
					new(1137, 2222, 66, ""),
				}),
				new("Pile Of Garbage", typeof(Static), 4339, "", new DecorationEntry[]
				{
					new(1138, 2216, 40, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(1138, 2224, 65, ""),
				}),
				new("Books", typeof(Static), 7717, "", new DecorationEntry[]
				{
					new(1138, 2225, 46, ""),
				}),
				new("Candelabra", typeof(Static), 2856, "", new DecorationEntry[]
				{
					new(1138, 2226, 40, ""),
				}),
				new("Water Trough", typeof(WaterTroughSouthAddon), 2883, "", new DecorationEntry[]
				{
					new(1140, 2238, 40, ""),
				}),
				new("Swamp", typeof(Static), 12911, "", new DecorationEntry[]
				{
					new(1150, 2276, -1, ""),
				}),
				new("Empty Vials", typeof(Static), 6235, "", new DecorationEntry[]
				{
					new(1160, 2207, 40, ""),
					new(1164, 2210, 46, ""),
				}),
				new("Broken Clock", typeof(Static), 3103, "", new DecorationEntry[]
				{
					new(1160, 2240, 48, ""),
				}),
				new("Ruined Painting", typeof(Static), 3116, "", new DecorationEntry[]
				{
					new(1161, 2232, 60, ""),
				}),
				new("Dirt", typeof(Static), 7678, "", new DecorationEntry[]
				{
					new(1161, 2239, 40, ""),
				}),
				new("Scales", typeof(Scales), 6225, "", new DecorationEntry[]
				{
					new(1162, 2210, 46, ""),
				}),
				new("Broken Chair", typeof(Static), 3097, "", new DecorationEntry[]
				{
					new(1162, 2234, 40, ""),
				}),
				new("Mud", typeof(Static), 7682, "", new DecorationEntry[]
				{
					new(1162, 2239, 40, ""),
					new(1162, 2240, 40, ""),
				}),
				new("Book", typeof(BurningOfTrinsic), 4084, "", new DecorationEntry[]
				{
					new(1163, 2206, 62, ""),
				}),
				new("Mortar And Pestle", typeof(Static), 3739, "", new DecorationEntry[]
				{
					new(1163, 2208, 41, ""),
				}),
				new("Full Vials", typeof(Static), 6237, "", new DecorationEntry[]
				{
					new(1163, 2210, 46, ""),
				}),
				new("Ruined Bookcase", typeof(Static), 3092, "", new DecorationEntry[]
				{
					new(1163, 2232, 40, ""),
				}),
				new("Switch", typeof(Static), 4239, "", new DecorationEntry[]
				{
					new(1129, 2230, 30, ""),
				}),
				new("Broken Chair", typeof(Static), 3100, "", new DecorationEntry[]
				{
					new(1163, 2236, 40, ""),
				}),
				new("Dirt", typeof(Static), 7679, "", new DecorationEntry[]
				{
					new(1163, 2239, 40, ""),
				}),
				new("Goblet", typeof(Static), 2507, "", new DecorationEntry[]
				{
					new(1164, 2234, 46, ""),
				}),
				new("Broken Chair", typeof(Static), 3102, "", new DecorationEntry[]
				{
					new(1164, 2237, 40, ""),
				}),
				new("Debris", typeof(Static), 3117, "", new DecorationEntry[]
				{
					new(1164, 2241, 40, ""),
				}),
				new("Flask Stand", typeof(Static), 6185, "", new DecorationEntry[]
				{
					new(1165, 2210, 46, ""),
				}),
				new("Broken Furniture", typeof(Static), 3108, "", new DecorationEntry[]
				{
					new(1165, 2232, 40, ""),
				}),
				new("Banner", typeof(Static), 5546, "", new DecorationEntry[]
				{
					new(1165, 2232, 60, ""),
				}),
				new("Damaged Books", typeof(Static), 3094, "", new DecorationEntry[]
				{
					new(1165, 2233, 40, ""),
					new(1165, 2244, 46, ""),
				}),
				new("Broken Chair", typeof(Static), 3101, "", new DecorationEntry[]
				{
					new(1165, 2234, 40, ""),
					new(1166, 2243, 40, ""),
				}),
				new("Banner", typeof(Static), 5547, "", new DecorationEntry[]
				{
					new(1166, 2232, 60, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2716, "", new DecorationEntry[]
				{
					new(1160, 2208, 40, ""),
				}),
				
				#endregion
			});
		}
	}
}
