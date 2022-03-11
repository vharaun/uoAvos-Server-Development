using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Skara { get; } = Register(DecorationTarget.Britannia, "Skara", new DecorationList[]
			{
				#region Entries
				
				new("", typeof(KeywordTeleporter), 7107, "PointDest=(709, 2236, -2);Range=3;Substring=cross", new DecorationEntry[]
				{
					new(683, 2233, -2, ""),
				}),
				new("", typeof(KeywordTeleporter), 7107, "PointDest=(683, 2233, -2);Range=3;Substring=cross", new DecorationEntry[]
				{
					new(709, 2236, -2, ""),
				}),
				new("", typeof(KeywordTeleporter), 7107, "PointDest=(709, 2238, -2);Range=3;Substring=cross", new DecorationEntry[]
				{
					new(683, 2242, -2, ""),
				}),
				new("", typeof(KeywordTeleporter), 7107, "PointDest=(683, 2242, -2);Range=3;Substring=cross", new DecorationEntry[]
				{
					new(709, 2238, -2, ""),
				}),
				new("Fireplace", typeof(Static), 2266, "", new DecorationEntry[]
				{
					new(552, 2171, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2267, "", new DecorationEntry[]
				{
					new(552, 2170, 0, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(552, 2168, 0, ""),
				}),
				new("Basket", typeof(Basket), 2448, "", new DecorationEntry[]
				{
					new(609, 2152, 0, ""),
				}),
				new("Fruit Basket", typeof(FruitBasket), 2451, "", new DecorationEntry[]
				{
					new(611, 2154, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2455, "", new DecorationEntry[]
				{
					new(592, 2276, 4, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(616, 2195, 4, ""),
					new(643, 2176, 4, ""),
					new(627, 2173, 4, ""),
					new(669, 2146, 4, ""),
					new(562, 2188, 4, ""),
					new(562, 2170, 4, ""),
					new(600, 2187, 4, ""),
					new(558, 2175, 6, ""),
					new(556, 2175, 6, ""),
					new(552, 2175, 6, ""),
					new(568, 2114, 4, ""),
					new(592, 2164, 4, ""),
					new(611, 2216, 4, ""),
					new(558, 2181, 4, ""),
					new(576, 2234, 4, ""),
					new(648, 2154, 4, ""),
					new(562, 2181, 4, ""),
					new(558, 2186, 4, ""),
					new(584, 2138, 4, ""),
					new(562, 2174, 4, ""),
					new(602, 2200, 4, ""),
				}),
				new("Fork", typeof(Fork), 2467, "", new DecorationEntry[]
				{
					new(669, 2147, 4, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(628, 2173, 4, ""),
				}),
				new("Knife", typeof(Knife), 2469, "", new DecorationEntry[]
				{
					new(669, 2147, 4, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(628, 2173, 4, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(581, 2230, 6, ""),
					new(595, 2200, 6, ""),
					new(589, 2144, 6, ""),
					new(652, 2160, 6, ""),
					new(604, 2178, 6, ""),
					new(620, 2215, 6, ""),
					new(603, 2272, 6, ""),
					new(603, 2232, 6, ""),
				}),
				new("Small Crate", typeof(FillableSmallCrate), 2473, "", new DecorationEntry[]
				{
					new(636, 2161, 0, ""),
					new(634, 2163, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(595, 2147, 3, ""),
					new(596, 2147, 3, ""),
					new(593, 2147, 3, ""),
				}),
				new("Spoon", typeof(Spoon), 2498, "", new DecorationEntry[]
				{
					new(669, 2147, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(628, 2173, 4, ""),
				}),
				new("Bottle Of Wine", typeof(BeverageBottle), 2503, "Content=Wine", new DecorationEntry[]
				{
					new(558, 2172, 6, ""),
					new(562, 2176, 4, ""),
					new(558, 2182, 4, ""),
					new(554, 2182, 4, ""),
					new(554, 2187, 4, ""),
					new(562, 2187, 4, ""),
					new(554, 2188, 4, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(554, 2175, 6, ""),
					new(592, 2275, 4, ""),
					new(584, 2139, 4, ""),
					new(592, 2165, 4, ""),
					new(628, 2173, 4, ""),
					new(669, 2147, 4, ""),
					new(558, 2174, 6, ""),
					new(603, 2200, 4, ""),
					new(616, 2196, 4, ""),
					new(600, 2186, 4, ""),
					new(568, 2115, 4, ""),
					new(576, 2235, 4, ""),
					new(648, 2155, 4, ""),
					new(644, 2176, 4, ""),
					new(612, 2216, 4, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(603, 2200, 4, ""),
					new(612, 2216, 4, ""),
					new(644, 2176, 4, ""),
					new(554, 2175, 6, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(568, 2115, 4, ""),
					new(558, 2174, 6, ""),
					new(616, 2196, 4, ""),
					new(600, 2186, 4, ""),
					new(584, 2139, 4, ""),
					new(592, 2275, 4, ""),
					new(592, 2165, 4, ""),
					new(576, 2235, 4, ""),
					new(648, 2155, 4, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(644, 2176, 4, ""),
					new(612, 2216, 4, ""),
					new(554, 2175, 6, ""),
					new(603, 2200, 4, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(616, 2196, 4, ""),
					new(576, 2235, 4, ""),
					new(648, 2155, 4, ""),
					new(558, 2174, 6, ""),
					new(568, 2115, 4, ""),
					new(600, 2186, 4, ""),
					new(584, 2139, 4, ""),
					new(592, 2275, 4, ""),
					new(592, 2165, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(603, 2200, 4, ""),
					new(644, 2176, 4, ""),
					new(612, 2216, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(568, 2115, 4, ""),
					new(592, 2165, 4, ""),
					new(648, 2155, 4, ""),
					new(616, 2196, 4, ""),
					new(584, 2139, 4, ""),
					new(592, 2275, 4, ""),
					new(600, 2186, 4, ""),
					new(576, 2235, 4, ""),
				}),
				new("Lantern Post", typeof(Static), 2592, "", new DecorationEntry[]
				{
					new(678, 2238, -3, ""),
				}),
				new("Candle", typeof(CandleLarge), 2598, "Unlit", new DecorationEntry[]
				{
					new(651, 2181, 6, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(569, 2168, 0, ""),
					new(649, 2152, 0, ""),
					new(617, 2250, 0, ""),
					new(597, 2272, 0, ""),
					new(573, 2112, 0, ""),
					new(593, 2250, 0, ""),
					new(580, 2232, 0, ""),
					new(585, 2136, 0, ""),
					new(617, 2192, 0, ""),
					new(605, 2250, 0, ""),
					new(593, 2160, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Static), 2608, "", new DecorationEntry[]
				{
					new(601, 2200, 0, ""),
					new(605, 2184, 0, ""),
					new(610, 2216, 0, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2612, "", new DecorationEntry[]
				{
					new(598, 2241, 0, ""),
					new(610, 2241, 0, ""),
					new(610, 2252, 0, ""),
					new(640, 2178, 0, ""),
					new(664, 2145, 0, ""),
					new(624, 2173, 0, ""),
					new(598, 2252, 0, ""),
					new(616, 2241, 0, ""),
					new(592, 2241, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(605, 2200, 0, ""),
					new(604, 2184, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(621, 2250, 0, ""),
					new(569, 2112, 0, ""),
					new(642, 2176, 0, ""),
					new(589, 2136, 0, ""),
					new(653, 2152, 0, ""),
					new(597, 2160, 0, ""),
					new(596, 2272, 0, ""),
					new(621, 2192, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(608, 2221, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(616, 2243, 0, ""),
					new(568, 2173, 0, ""),
					new(664, 2149, 0, ""),
					new(624, 2169, 0, ""),
					new(576, 2237, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(578, 2120, 0, ""),
					new(561, 2216, 0, ""),
					new(562, 2136, 0, ""),
					new(597, 2144, 0, ""),
					new(670, 2144, 0, ""),
					new(585, 2160, 0, ""),
					new(545, 2208, 0, ""),
					new(582, 2120, 0, ""),
					new(617, 2215, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(593, 2144, 0, ""),
					new(618, 2215, 0, ""),
					new(579, 2120, 0, ""),
					new(581, 2120, 0, ""),
					new(548, 2208, 0, ""),
					new(546, 2208, 0, ""),
					new(563, 2136, 0, ""),
					new(666, 2144, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(600, 2283, 0, ""),
					new(648, 2157, 0, ""),
					new(560, 2217, 0, ""),
					new(600, 2276, 0, ""),
					new(624, 2192, 0, ""),
					new(552, 2220, 0, ""),
					new(560, 2221, 0, ""),
					new(616, 2217, 0, ""),
					new(656, 2140, 0, ""),
					new(600, 2177, 0, ""),
					new(624, 2164, 0, ""),
					new(592, 2277, 0, ""),
					new(592, 2273, 0, ""),
					new(576, 2233, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(552, 2218, 0, ""),
					new(560, 2219, 0, ""),
					new(648, 2158, 0, ""),
					new(656, 2141, 0, ""),
					new(600, 2181, 0, ""),
					new(624, 2197, 0, ""),
					new(600, 2277, 0, ""),
					new(600, 2284, 0, ""),
					new(624, 2193, 0, ""),
					new(616, 2221, 0, ""),
					new(624, 2165, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(589, 2160, 0, ""),
					new(549, 2208, 0, ""),
					new(594, 2144, 0, ""),
					new(619, 2215, 0, ""),
					new(596, 2144, 0, ""),
					new(665, 2144, 0, ""),
					new(574, 2120, 0, ""),
					new(564, 2136, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(624, 2198, 0, ""),
					new(600, 2178, 0, ""),
					new(560, 2220, 0, ""),
					new(552, 2217, 0, ""),
					new(560, 2218, 0, ""),
					new(552, 2221, 0, ""),
					new(600, 2180, 0, ""),
					new(600, 2285, 0, ""),
					new(600, 2278, 0, ""),
					new(624, 2166, 0, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "", new DecorationEntry[]
				{
					new(565, 2216, 0, ""),
					new(557, 2216, 0, ""),
					new(553, 2216, 0, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "", new DecorationEntry[]
				{
					new(600, 2236, 0, ""),
					new(600, 2235, 0, ""),
					new(544, 2209, 0, ""),
					new(544, 2213, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(620, 2219, 6, ""),
					new(584, 2140, 4, ""),
					new(556, 2202, 4, ""),
					new(645, 2176, 4, ""),
					new(556, 2220, 4, ""),
					new(595, 2205, 6, ""),
					new(592, 2274, 4, ""),
					new(648, 2156, 4, ""),
					new(630, 2161, 6, ""),
					new(609, 2157, 6, ""),
					new(564, 2220, 4, ""),
					new(652, 2163, 6, ""),
					new(613, 2216, 4, ""),
					new(669, 2148, 4, ""),
					new(616, 2197, 4, ""),
					new(554, 2139, 4, ""),
					new(572, 2123, 6, ""),
					new(589, 2148, 6, ""),
					new(563, 2154, 6, ""),
					new(581, 2188, 6, ""),
					new(576, 2236, 4, ""),
					new(564, 2138, 4, ""),
					new(581, 2226, 6, ""),
					new(546, 2212, 4, ""),
					new(568, 2116, 4, ""),
					new(554, 2145, 4, ""),
					new(592, 2166, 4, ""),
					new(589, 2200, 6, ""),
					new(626, 2191, 6, ""),
					new(586, 2164, 6, ""),
					new(604, 2200, 4, ""),
					new(629, 2173, 4, ""),
					new(562, 2202, 4, ""),
				}),
				new("Lamp Post", typeof(LampPost1), 2848, "", new DecorationEntry[]
				{
					new(584, 2127, 0, ""),
					new(624, 2143, 0, ""),
					new(624, 2237, 0, ""),
					new(655, 2150, 0, ""),
					new(592, 2191, 0, ""),
					new(632, 2224, 0, ""),
					new(600, 2167, 0, ""),
					new(591, 2232, 0, ""),
					new(599, 2142, 0, ""),
					new(607, 2208, 0, ""),
					new(591, 2257, 0, ""),
					new(575, 2177, 0, ""),
					new(575, 2152, 0, ""),
					new(608, 2279, 0, ""),
					new(616, 2183, 0, ""),
					new(640, 2167, 0, ""),
					new(639, 2190, 0, ""),
					new(575, 2206, 0, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(552, 2189, 0, ""),
					new(630, 2120, 0, ""),
					new(592, 2248, 0, ""),
					new(609, 2133, 0, ""),
					new(629, 2133, 0, ""),
					new(608, 2120, 0, ""),
					new(565, 2188, 0, ""),
				}),
				new("Water Trough", typeof(WaterTroughEastAddon), 2881, "", new DecorationEntry[]
				{
					new(544, 2124, 0, ""),
					new(544, 2120, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2897, "", new DecorationEntry[]
				{
					new(565, 2139, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(602, 2234, 0, ""),
					new(603, 2180, 0, ""),
					new(553, 2142, 0, ""),
					new(545, 2211, 0, ""),
					new(619, 2217, 0, ""),
					new(571, 2121, 0, ""),
					new(636, 2156, 0, ""),
					new(636, 2155, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(637, 2152, 0, ""),
					new(636, 2152, 0, ""),
					new(559, 2201, 0, ""),
					new(588, 2163, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(596, 2203, 0, ""),
					new(565, 2219, 0, ""),
					new(557, 2219, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(563, 2138, 0, ""),
					new(588, 2146, 0, ""),
					new(580, 2228, 0, ""),
					new(563, 2220, 0, ""),
					new(563, 2218, 0, ""),
					new(563, 2140, 0, ""),
					new(609, 2155, 0, ""),
					new(555, 2218, 0, ""),
					new(555, 2220, 0, ""),
					new(553, 2146, 0, ""),
					new(627, 2193, 0, ""),
					new(553, 2138, 0, ""),
					new(553, 2140, 0, ""),
					new(590, 2203, 0, ""),
					new(668, 2147, 0, ""),
					new(553, 2144, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(634, 2152, 0, ""),
					new(566, 2208, 0, ""),
					new(562, 2208, 0, ""),
					new(628, 2172, 0, ""),
					new(557, 2208, 0, ""),
					new(633, 2152, 0, ""),
					new(650, 2162, 0, ""),
					new(557, 2201, 0, ""),
					new(635, 2153, 6, ""),
					new(553, 2208, 0, ""),
					new(650, 2180, 0, ""),
					new(561, 2201, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(585, 2139, 0, ""),
					new(569, 2115, 0, ""),
					new(588, 2202, 0, ""),
					new(617, 2196, 0, ""),
					new(593, 2275, 0, ""),
					new(556, 2142, 0, ""),
					new(556, 2138, 0, ""),
					new(556, 2144, 0, ""),
					new(547, 2210, 0, ""),
					new(547, 2212, 0, ""),
					new(666, 2138, 0, ""),
					new(556, 2140, 0, ""),
					new(649, 2155, 0, ""),
					new(556, 2146, 0, ""),
					new(577, 2235, 0, ""),
					new(601, 2186, 0, ""),
					new(593, 2165, 0, ""),
					new(605, 2180, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(644, 2177, 0, ""),
					new(560, 2204, 0, ""),
					new(612, 2217, 0, ""),
					new(562, 2204, 0, ""),
					new(603, 2201, 0, ""),
					new(627, 2162, 0, ""),
					new(558, 2204, 0, ""),
					new(556, 2204, 0, ""),
					new(628, 2158, 0, ""),
					new(628, 2155, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(635, 2155, 6, ""),
					new(602, 2274, 0, ""),
				}),
				new("Foot Stool", typeof(FootStool), 2910, "", new DecorationEntry[]
				{
					new(554, 2176, 0, ""),
					new(558, 2176, 0, ""),
					new(552, 2176, 0, ""),
					new(556, 2176, 0, ""),
					new(559, 2174, 0, ""),
					new(559, 2172, 0, ""),
					new(559, 2170, 0, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2968, "", new DecorationEntry[]
				{
					new(678, 2239, -3, ""),
				}),
				new("Sign", typeof(Static), 2994, "Name=Skara Brae Ferry :    Step onto the boat and say \"I would like to cross", new DecorationEntry[]
				{
					new(679, 2240, 7, ""),
				}),
				new("Broken Chair", typeof(Static), 3088, "", new DecorationEntry[]
				{
					new(630, 2157, 6, ""),
				}),
				new("Broken Chair", typeof(Static), 3089, "", new DecorationEntry[]
				{
					new(627, 2157, 6, ""),
					new(630, 2154, 6, ""),
				}),
				new("Broken Chair", typeof(Static), 3097, "", new DecorationEntry[]
				{
					new(626, 2154, 6, ""),
				}),
				new("Small Fish", typeof(Static), 3542, "", new DecorationEntry[]
				{
					new(669, 2237, -2, ""),
					new(661, 2234, -2, ""),
					new(642, 2245, -2, ""),
					new(678, 2234, -3, ""),
					new(638, 2228, -3, ""),
				}),
				new("Small Fish", typeof(Static), 3544, "", new DecorationEntry[]
				{
					new(661, 2228, -2, ""),
					new(660, 2243, -2, ""),
					new(641, 2227, -2, ""),
					new(642, 2234, -2, ""),
					new(676, 2246, -2, ""),
					new(642, 2233, -2, ""),
					new(676, 2226, -2, ""),
				}),
				new("Small Fish", typeof(Static), 3545, "", new DecorationEntry[]
				{
					new(644, 2243, -2, ""),
					new(644, 2234, -2, ""),
					new(661, 2244, -2, ""),
					new(672, 2234, -2, ""),
					new(679, 2225, -2, ""),
				}),
				new("Chessmen", typeof(Static), 3603, "", new DecorationEntry[]
				{
					new(554, 2181, 4, ""),
				}),
				new("Chessmen", typeof(Static), 3604, "", new DecorationEntry[]
				{
					new(554, 2181, 4, ""),
				}),
				new("Cards", typeof(Static), 3607, "", new DecorationEntry[]
				{
					new(562, 2182, 4, ""),
				}),
				new("Cards", typeof(Static), 3608, "", new DecorationEntry[]
				{
					new(562, 2183, 4, ""),
				}),
				new("Cards", typeof(Static), 3609, "", new DecorationEntry[]
				{
					new(562, 2183, 4, ""),
				}),
				new("Checkers", typeof(Static), 3610, "", new DecorationEntry[]
				{
					new(562, 2169, 4, ""),
				}),
				new("Checkers", typeof(Static), 3611, "", new DecorationEntry[]
				{
					new(562, 2169, 4, ""),
				}),
				new("Clean Bandage", typeof(Static), 3617, "", new DecorationEntry[]
				{
					new(651, 2180, 0, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(623, 2211, 0, ""),
					new(616, 2209, 0, ""),
					new(624, 2208, 0, ""),
				}),
				new("Crystal Ball", typeof(Static), 3631, "Light=Circle150", new DecorationEntry[]
				{
					new(604, 2179, 6, ""),
				}),
				new("Brazier", typeof(Brazier), 3633, "", new DecorationEntry[]
				{
					new(600, 2176, 0, ""),
					new(600, 2184, 0, ""),
				}),
				new("Brazier", typeof(Brazier), 3634, "", new DecorationEntry[]
				{
					new(656, 2136, 0, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3644, "", new DecorationEntry[]
				{
					new(635, 2160, 7, ""),
					new(634, 2160, 3, ""),
					new(634, 2161, 3, ""),
					new(634, 2160, 0, ""),
					new(634, 2161, 0, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(585, 2224, 0, ""),
					new(584, 2225, 3, ""),
					new(585, 2224, 3, ""),
					new(584, 2225, 0, ""),
					new(585, 2224, 6, ""),
					new(584, 2224, 6, ""),
					new(586, 2224, 3, ""),
					new(584, 2224, 3, ""),
					new(586, 2224, 0, ""),
					new(584, 2224, 0, ""),
					new(586, 2224, 6, ""),
					new(586, 2225, 3, ""),
					new(585, 2224, 9, ""),
					new(585, 2225, 0, ""),
					new(586, 2225, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(635, 2162, 7, ""),
					new(636, 2159, 3, ""),
					new(636, 2159, 0, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(592, 2243, 0, ""),
					new(610, 2251, 0, ""),
					new(610, 2243, 0, ""),
					new(584, 2148, 6, ""),
					new(604, 2251, 0, ""),
					new(616, 2251, 0, ""),
					new(592, 2251, 0, ""),
					new(598, 2251, 0, ""),
					new(598, 2243, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(594, 2147, 3, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(617, 2240, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(584, 2146, 6, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(583, 2230, 5, ""),
					new(639, 2246, 2, ""),
					new(582, 2230, 0, ""),
					new(583, 2229, 5, ""),
					new(608, 2152, 0, ""),
					new(582, 2230, 10, ""),
					new(582, 2229, 5, ""),
					new(639, 2245, -2, ""),
					new(583, 2229, 0, ""),
					new(641, 2235, -2, ""),
					new(640, 2245, -2, ""),
					new(659, 2224, -2, ""),
					new(677, 2244, -2, ""),
					new(642, 2236, -2, ""),
					new(552, 2174, 5, ""),
					new(576, 2230, 0, ""),
					new(552, 2173, 0, ""),
					new(641, 2236, -2, ""),
					new(608, 2153, 0, ""),
					new(642, 2235, -2, ""),
					new(583, 2230, 10, ""),
					new(608, 2152, 5, ""),
					new(582, 2229, 0, ""),
					new(555, 2168, 5, ""),
					new(552, 2173, 5, ""),
					new(658, 2224, -2, ""),
					new(552, 2174, 0, ""),
					new(555, 2168, 0, ""),
					new(556, 2168, 0, ""),
					new(639, 2246, -3, ""),
					new(676, 2243, -2, ""),
					new(583, 2230, 0, ""),
					new(676, 2244, -2, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(584, 2145, 6, ""),
					new(584, 2149, 6, ""),
					new(584, 2147, 6, ""),
				}),
				new("Crate", typeof(FillableSmallCrate), 3710, "", new DecorationEntry[]
				{
					new(635, 2163, 6, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(608, 2157, 6, ""),
					new(625, 2161, 6, ""),
					new(590, 2164, 6, ""),
					new(624, 2191, 6, ""),
					new(577, 2188, 6, ""),
					new(648, 2181, 6, ""),
					new(570, 2123, 6, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(576, 2185, 6, ""),
				}),
				new("Dress Form", typeof(Dressform), 3782, "", new DecorationEntry[]
				{
					new(648, 2180, 0, ""),
				}),
				new("Dress Form", typeof(Dressform), 3783, "", new DecorationEntry[]
				{
					new(648, 2183, 0, ""),
				}),
				new("Saddle", typeof(Static), 3895, "", new DecorationEntry[]
				{
					new(562, 2129, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3993, "", new DecorationEntry[]
				{
					new(653, 2181, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3994, "Hue=0x1F2", new DecorationEntry[]
				{
					new(648, 2179, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3994, "Hue=0x31E", new DecorationEntry[]
				{
					new(653, 2181, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3995, "Hue=0x1ED", new DecorationEntry[]
				{
					new(651, 2176, 0, ""),
				}),
				new("Bolt Of Cloth", typeof(Static), 3996, "Hue=0x58", new DecorationEntry[]
				{
					new(651, 2176, 0, ""),
				}),
				new("Sewing Kit", typeof(Static), 3997, "", new DecorationEntry[]
				{
					new(649, 2181, 6, ""),
				}),
				new("Scissors", typeof(Scissors), 3999, "", new DecorationEntry[]
				{
					new(652, 2181, 6, ""),
				}),
				new("Checker Board", typeof(CheckerBoard), 4006, "", new DecorationEntry[]
				{
					new(562, 2169, 4, ""),
				}),
				new("Chess Board", typeof(Chessboard), 4006, "", new DecorationEntry[]
				{
					new(554, 2181, 4, ""),
				}),
				new("Dice And Cup", typeof(Dice), 4007, "", new DecorationEntry[]
				{
					new(558, 2187, 4, ""),
				}),
				new("Backgammon Game", typeof(Backgammon), 4013, "", new DecorationEntry[]
				{
					new(558, 2188, 4, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(633, 2195, 0, ""),
					new(632, 2195, 0, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(632, 2196, 0, ""),
					new(634, 2198, 6, ""),
				}),
				new("Horse Shoes", typeof(Static), 4022, "", new DecorationEntry[]
				{
					new(628, 2195, 6, ""),
					new(635, 2196, 0, ""),
				}),
				new("Forged Metal", typeof(Static), 4024, "", new DecorationEntry[]
				{
					new(633, 2195, 0, ""),
				}),
				new("Tongs", typeof(Static), 4027, "", new DecorationEntry[]
				{
					new(634, 2194, 0, ""),
					new(636, 2198, 6, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(564, 2219, 4, ""),
					new(603, 2234, 6, ""),
					new(628, 2193, 6, ""),
					new(665, 2138, 6, ""),
					new(581, 2228, 6, ""),
					new(564, 2139, 4, ""),
					new(611, 2155, 6, ""),
					new(589, 2146, 6, ""),
					new(546, 2211, 4, ""),
					new(620, 2217, 6, ""),
					new(572, 2121, 6, ""),
					new(556, 2219, 4, ""),
					new(554, 2142, 4, ""),
					new(603, 2274, 6, ""),
					new(595, 2203, 6, ""),
					new(604, 2180, 6, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(650, 2181, 6, ""),
					new(627, 2161, 6, ""),
					new(650, 2163, 6, ""),
					new(559, 2202, 4, ""),
					new(588, 2164, 6, ""),
					new(579, 2188, 6, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(589, 2146, 6, ""),
					new(564, 2219, 4, ""),
					new(556, 2219, 4, ""),
					new(546, 2211, 4, ""),
					new(554, 2142, 4, ""),
					new(581, 2228, 6, ""),
					new(665, 2138, 6, ""),
					new(620, 2217, 6, ""),
					new(603, 2274, 6, ""),
					new(603, 2234, 6, ""),
					new(604, 2180, 6, ""),
					new(611, 2155, 6, ""),
					new(572, 2121, 6, ""),
					new(564, 2139, 4, ""),
					new(595, 2202, 6, ""),
					new(628, 2193, 6, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(559, 2202, 4, ""),
					new(588, 2164, 6, ""),
					new(650, 2163, 6, ""),
					new(650, 2181, 6, ""),
					new(579, 2188, 6, ""),
					new(627, 2161, 6, ""),
				}),
				new("Book", typeof(TamingDragons), 4079, "", new DecorationEntry[]
				{
					new(564, 2208, 4, ""),
				}),
				new("Book", typeof(RedBook), 4081, "", new DecorationEntry[]
				{
					new(554, 2208, 4, ""),
					new(576, 2120, 4, ""),
				}),
				new("Book", typeof(BlueBook), 4082, "", new DecorationEntry[]
				{
					new(565, 2208, 4, ""),
				}),
				new("Book", typeof(DeceitDungeonOfHorror), 4083, "", new DecorationEntry[]
				{
					new(563, 2208, 4, ""),
				}),
				new("Book", typeof(CallToAnarchy), 4084, "", new DecorationEntry[]
				{
					new(575, 2120, 4, ""),
				}),
				new("Book", typeof(TalkingToWisps), 4084, "", new DecorationEntry[]
				{
					new(556, 2208, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4095, "", new DecorationEntry[]
				{
					new(558, 2189, 4, ""),
					new(562, 2176, 4, ""),
					new(562, 2189, 4, ""),
					new(562, 2183, 4, ""),
					new(554, 2189, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4097, "", new DecorationEntry[]
				{
					new(600, 2185, 4, ""),
					new(562, 2180, 4, ""),
					new(558, 2183, 4, ""),
					new(562, 2189, 4, ""),
					new(554, 2183, 4, ""),
				}),
				new("Spittoon", typeof(Static), 4099, "", new DecorationEntry[]
				{
					new(561, 2173, 0, ""),
					new(558, 2179, 0, ""),
					new(552, 2184, 0, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelEastAddon), 4121, "", new DecorationEntry[]
				{
					new(648, 2176, 0, ""),
				}),
				new("Pile Of Wool", typeof(Static), 4127, "Hue=0x1ED", new DecorationEntry[]
				{
					new(652, 2178, 0, ""),
				}),
				new("Pile Of Wool", typeof(Static), 4127, "Hue=0x31E", new DecorationEntry[]
				{
					new(649, 2177, 0, ""),
				}),
				new("Dovetail Saw", typeof(Static), 4137, "", new DecorationEntry[]
				{
					new(629, 2157, 6, ""),
				}),
				new("Hammer", typeof(Static), 4138, "", new DecorationEntry[]
				{
					new(629, 2154, 6, ""),
					new(591, 2203, 6, ""),
					new(630, 2164, 6, ""),
					new(628, 2157, 6, ""),
				}),
				new("Hammer", typeof(Static), 4139, "", new DecorationEntry[]
				{
					new(587, 2203, 6, ""),
				}),
				new("Nails", typeof(Static), 4142, "", new DecorationEntry[]
				{
					new(628, 2157, 6, ""),
					new(628, 2154, 6, ""),
				}),
				new("Nails", typeof(Static), 4143, "", new DecorationEntry[]
				{
					new(587, 2201, 6, ""),
					new(630, 2163, 6, ""),
					new(590, 2200, 6, ""),
				}),
				new("Saw", typeof(Static), 4148, "", new DecorationEntry[]
				{
					new(591, 2200, 6, ""),
				}),
				new("Saw", typeof(Static), 4149, "", new DecorationEntry[]
				{
					new(627, 2154, 6, ""),
				}),
				new("Wood Curls", typeof(Static), 4152, "", new DecorationEntry[]
				{
					new(627, 2156, 0, ""),
					new(626, 2159, 0, ""),
					new(628, 2153, 0, ""),
					new(629, 2156, 0, ""),
					new(628, 2159, 0, ""),
					new(626, 2153, 0, ""),
					new(625, 2155, 0, ""),
					new(625, 2153, 0, ""),
					new(625, 2156, 0, ""),
					new(625, 2158, 0, ""),
					new(625, 2157, 0, ""),
					new(632, 2158, 0, ""),
					new(630, 2159, 0, ""),
					new(631, 2159, 0, ""),
					new(632, 2157, 0, ""),
					new(632, 2155, 0, ""),
					new(632, 2154, 0, ""),
					new(630, 2156, 0, ""),
					new(630, 2153, 0, ""),
					new(631, 2153, 0, ""),
					new(631, 2156, 0, ""),
				}),
				new("Globe", typeof(Static), 4167, "", new DecorationEntry[]
				{
					new(601, 2272, 0, ""),
				}),
				new("Loom Bench", typeof(Static), 4169, "", new DecorationEntry[]
				{
					new(650, 2176, 0, ""),
				}),
				new("Loom Bench", typeof(Static), 4170, "", new DecorationEntry[]
				{
					new(653, 2178, 0, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4193, "", new DecorationEntry[]
				{
					new(652, 2177, 0, ""),
				}),
				new("Potted Tree", typeof(PottedTree), 4552, "", new DecorationEntry[]
				{
					new(616, 2192, 0, ""),
					new(552, 2216, 0, ""),
					new(576, 2232, 0, ""),
					new(648, 2152, 0, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(584, 2136, 0, ""),
					new(568, 2112, 0, ""),
					new(544, 2208, 0, ""),
					new(584, 2200, 0, ""),
					new(592, 2272, 0, ""),
					new(600, 2200, 0, ""),
					new(640, 2176, 0, ""),
					new(600, 2232, 0, ""),
					new(624, 2184, 0, ""),
					new(552, 2200, 0, ""),
					new(600, 2272, 0, ""),
					new(566, 2200, 0, ""),
					new(560, 2136, 0, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(568, 2168, 0, ""),
					new(568, 2120, 0, ""),
					new(560, 2216, 0, ""),
					new(584, 2160, 0, ""),
					new(567, 2208, 0, ""),
					new(664, 2144, 0, ""),
					new(616, 2215, 0, ""),
					new(592, 2160, 0, ""),
					new(552, 2208, 0, ""),
					new(592, 2246, 0, ""),
					new(608, 2216, 0, ""),
					new(624, 2168, 0, ""),
					new(648, 2160, 0, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(630, 2162, 9, ""),
					new(603, 2236, 9, ""),
					new(595, 2206, 9, ""),
					new(600, 2279, 9, ""),
					new(600, 2282, 9, ""),
					new(652, 2162, 9, ""),
					new(576, 2188, 8, ""),
				}),
				new("Flowerpot", typeof(PottedPlant2), 4556, "", new DecorationEntry[]
				{
					new(603, 2276, 9, ""),
					new(611, 2157, 8, ""),
					new(620, 2216, 9, ""),
					new(628, 2191, 10, ""),
					new(581, 2186, 8, ""),
					new(624, 2161, 9, ""),
				}),
				new("Statue", typeof(Static), 4648, "", new DecorationEntry[]
				{
					new(563, 2152, 8, ""),
				}),
				new("Tarot", typeof(Static), 4774, "", new DecorationEntry[]
				{
					new(604, 2181, 6, ""),
				}),
				new("Brush", typeof(Static), 4976, "", new DecorationEntry[]
				{
					new(578, 2123, 6, ""),
				}),
				new("Brush", typeof(Static), 4978, "", new DecorationEntry[]
				{
					new(579, 2123, 6, ""),
				}),
				new("Bridle", typeof(Static), 4980, "", new DecorationEntry[]
				{
					new(577, 2123, 6, ""),
				}),
				new("Bridle", typeof(Static), 4981, "", new DecorationEntry[]
				{
					new(576, 2123, 6, ""),
				}),
				new("Statue", typeof(Static), 5019, "", new DecorationEntry[]
				{
					new(563, 2156, 9, ""),
				}),
				new("Ship Model", typeof(Static), 5363, "", new DecorationEntry[]
				{
					new(600, 2280, 6, ""),
				}),
				new("Ship Model", typeof(Static), 5364, "", new DecorationEntry[]
				{
					new(600, 2281, 6, ""),
				}),
				new("Rope", typeof(Static), 5368, "", new DecorationEntry[]
				{
					new(620, 2274, -3, ""),
					new(658, 2245, -3, ""),
					new(679, 2234, -3, ""),
				}),
				new("Rope", typeof(Static), 5370, "", new DecorationEntry[]
				{
					new(645, 2229, -3, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(677, 2224, -2, ""),
					new(640, 2225, -2, ""),
					new(639, 2226, -2, ""),
					new(657, 2224, -2, ""),
					new(657, 2239, -2, ""),
					new(633, 2193, 0, ""),
					new(673, 2233, -3, ""),
					new(582, 2230, 5, ""),
					new(639, 2225, -2, ""),
				}),
				new("Folded Cloth", typeof(Static), 5981, "", new DecorationEntry[]
				{
					new(648, 2187, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5982, "Hue=0x31E", new DecorationEntry[]
				{
					new(648, 2185, 6, ""),
				}),
				new("Folded Cloth", typeof(Static), 5986, "", new DecorationEntry[]
				{
					new(649, 2182, 0, ""),
				}),
				new("Folded Cloth", typeof(Static), 5988, "Hue=0x31E", new DecorationEntry[]
				{
					new(648, 2182, 0, ""),
				}),
				new("Cloth", typeof(Static), 5991, "", new DecorationEntry[]
				{
					new(648, 2182, 0, ""),
				}),
				new("Cut Cloth", typeof(Static), 5992, "Hue=0x58", new DecorationEntry[]
				{
					new(648, 2186, 6, ""),
				}),
				new("Hourglass", typeof(Static), 6161, "", new DecorationEntry[]
				{
					new(669, 2136, 6, ""),
				}),
				new("Scales", typeof(Scales), 6225, "", new DecorationEntry[]
				{
					new(668, 2136, 6, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(665, 2140, 6, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6232, "", new DecorationEntry[]
				{
					new(665, 2136, 6, ""),
				}),
				new("Empty Vials", typeof(Static), 6235, "", new DecorationEntry[]
				{
					new(670, 2136, 6, ""),
				}),
				new("Full Vials", typeof(Static), 6237, "", new DecorationEntry[]
				{
					new(667, 2136, 6, ""),
				}),
				new("Bellows", typeof(Static), 6534, "", new DecorationEntry[]
				{
					new(636, 2193, 0, ""),
				}),
				new("Forge", typeof(Static), 6538, "Light=Circle300", new DecorationEntry[]
				{
					new(636, 2194, 0, ""),
				}),
				new("Forge", typeof(Static), 6542, "", new DecorationEntry[]
				{
					new(636, 2195, 0, ""),
				}),
				new("Feather", typeof(Static), 7121, "", new DecorationEntry[]
				{
					new(587, 2204, 6, ""),
				}),
				new("Shaft", typeof(Static), 7124, "", new DecorationEntry[]
				{
					new(591, 2204, 6, ""),
					new(588, 2200, 6, ""),
					new(587, 2202, 6, ""),
					new(591, 2202, 6, ""),
				}),
				new("Boards", typeof(Static), 7128, "", new DecorationEntry[]
				{
					new(613, 2273, 0, ""),
				}),
				new("Boards", typeof(Static), 7129, "", new DecorationEntry[]
				{
					new(608, 2277, 0, ""),
					new(608, 2278, 0, ""),
				}),
				new("Boards", typeof(Static), 7131, "", new DecorationEntry[]
				{
					new(615, 2278, 0, ""),
				}),
				new("Bulletin Board", typeof(BulletinBoard), 7774, "", new DecorationEntry[]
				{
					new(559, 2168, 0, ""),
				}),
				new("Prow", typeof(Static), 16026, "", new DecorationEntry[]
				{
					new(683, 2238, -5, ""),
					new(683, 2230, -5, ""),
				}),
				new("Ship", typeof(Static), 16027, "", new DecorationEntry[]
				{
					new(682, 2231, -5, ""),
					new(682, 2239, -5, ""),
				}),
				new("Ship", typeof(Static), 16028, "", new DecorationEntry[]
				{
					new(684, 2239, -5, ""),
					new(684, 2231, -5, ""),
				}),
				new("Ship", typeof(Static), 16029, "", new DecorationEntry[]
				{
					new(682, 2240, -5, ""),
					new(682, 2232, -5, ""),
				}),
				new("Ship", typeof(Static), 16030, "", new DecorationEntry[]
				{
					new(684, 2232, -5, ""),
					new(684, 2240, -5, ""),
				}),
				new("Ship", typeof(Static), 16031, "", new DecorationEntry[]
				{
					new(682, 2241, -5, ""),
					new(682, 2233, -5, ""),
				}),
				new("Ship", typeof(Static), 16032, "", new DecorationEntry[]
				{
					new(684, 2241, -5, ""),
					new(684, 2233, -5, ""),
				}),
				new("Deck", typeof(Static), 16033, "", new DecorationEntry[]
				{
					new(682, 2242, -5, ""),
					new(682, 2234, -5, ""),
				}),
				new("Ship", typeof(Static), 16038, "", new DecorationEntry[]
				{
					new(684, 2234, -5, ""),
					new(684, 2242, -5, ""),
				}),
				new("Ship", typeof(Static), 16039, "", new DecorationEntry[]
				{
					new(682, 2235, -5, ""),
					new(682, 2243, -5, ""),
				}),
				new("Ship", typeof(Static), 16040, "", new DecorationEntry[]
				{
					new(684, 2235, -5, ""),
					new(684, 2243, -5, ""),
				}),
				new("Ship", typeof(Static), 16043, "", new DecorationEntry[]
				{
					new(684, 2236, -5, ""),
					new(684, 2244, -5, ""),
				}),
				new("Deck", typeof(Static), 16044, "", new DecorationEntry[]
				{
					new(683, 2235, -5, ""),
					new(683, 2234, -5, ""),
					new(683, 2243, -5, ""),
					new(683, 2242, -5, ""),
				}),
				new("Deck", typeof(Static), 16045, "", new DecorationEntry[]
				{
					new(683, 2232, -5, ""),
					new(683, 2240, -5, ""),
				}),
				new("Hatch", typeof(Static), 16046, "", new DecorationEntry[]
				{
					new(683, 2231, -5, ""),
					new(683, 2239, -5, ""),
				}),
				new("Deck", typeof(Static), 16048, "", new DecorationEntry[]
				{
					new(683, 2233, -5, ""),
					new(683, 2241, -5, ""),
				}),
				new("Ship", typeof(Static), 16054, "", new DecorationEntry[]
				{
					new(682, 2244, -5, ""),
					new(682, 2236, -5, ""),
				}),
				new("Rudder", typeof(Static), 16060, "", new DecorationEntry[]
				{
					new(683, 2237, -5, ""),
					new(683, 2245, -5, ""),
				}),
				new("Deck", typeof(Static), 16064, "", new DecorationEntry[]
				{
					new(683, 2244, -5, ""),
					new(683, 2236, -5, ""),
				}),
				new("Gang Plank", typeof(Static), 16085, "", new DecorationEntry[]
				{
					new(681, 2242, -5, ""),
					new(681, 2234, -5, ""),
				}),
				new("Tent Wall", typeof(Static), 747, "Hue=0x33", new DecorationEntry[]
				{
					new(752, 2210, 4, ""),
					new(747, 2208, 9, ""),
					new(762, 2200, 0, ""),
					new(753, 2197, 6, ""),
				}),
				new("Tent Wall", typeof(Static), 748, "Hue=0x33", new DecorationEntry[]
				{
					new(753, 2209, 4, ""),
					new(754, 2196, 6, ""),
					new(763, 2199, 0, ""),
					new(748, 2207, 9, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1055, "", new DecorationEntry[]
				{
					new(757, 2193, 12, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1056, "", new DecorationEntry[]
				{
					new(765, 2201, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2266, "", new DecorationEntry[]
				{
					new(808, 2333, 0, ""),
					new(888, 2396, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2267, "", new DecorationEntry[]
				{
					new(888, 2395, 0, ""),
					new(808, 2332, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2270, "", new DecorationEntry[]
				{
					new(821, 2192, 0, ""),
					new(804, 2264, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2271, "", new DecorationEntry[]
				{
					new(803, 2264, 0, ""),
					new(820, 2192, 0, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(887, 2393, 0, ""),
					new(807, 2330, 0, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(818, 2191, 0, ""),
					new(802, 2264, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(756, 2267, 0, ""),
					new(748, 2350, 0, ""),
					new(755, 2203, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2421, "", new DecorationEntry[]
				{
					new(870, 2324, 0, ""),
					new(786, 2233, 0, ""),
				}),
				new("Slab Of Bacon", typeof(Static), 2422, "", new DecorationEntry[]
				{
					new(790, 2232, 6, ""),
				}),
				new("Slab Of Bacon", typeof(Static), 2423, "", new DecorationEntry[]
				{
					new(866, 2320, 6, ""),
				}),
				new("Basket", typeof(Basket), 2448, "", new DecorationEntry[]
				{
					new(892, 2396, 6, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(810, 2334, 6, ""),
					new(890, 2398, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(813, 2196, 4, ""),
					new(796, 2267, 4, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2454, "", new DecorationEntry[]
				{
					new(796, 2266, 4, ""),
					new(813, 2195, 4, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(891, 2387, 4, ""),
					new(748, 2264, 6, ""),
					new(784, 2220, 16, ""),
					new(810, 2322, 4, ""),
					new(740, 2344, 6, ""),
					new(864, 2316, 6, ""),
				}),
				new("Fork", typeof(Fork), 2467, "", new DecorationEntry[]
				{
					new(890, 2385, 4, ""),
					new(890, 2387, 4, ""),
					new(810, 2321, 4, ""),
					new(810, 2323, 4, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(814, 2195, 4, ""),
					new(797, 2266, 4, ""),
				}),
				new("Knife", typeof(Knife), 2469, "", new DecorationEntry[]
				{
					new(890, 2385, 4, ""),
					new(810, 2323, 4, ""),
					new(890, 2387, 4, ""),
					new(810, 2321, 4, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(797, 2266, 4, ""),
					new(814, 2195, 4, ""),
				}),
				new("Bushel", typeof(Basket), 2476, "", new DecorationEntry[]
				{
					new(803, 2268, 6, ""),
					new(822, 2192, 6, ""),
					new(819, 2195, 0, ""),
					new(810, 2332, 0, ""),
				}),
				new("Spoon", typeof(Spoon), 2498, "", new DecorationEntry[]
				{
					new(810, 2323, 4, ""),
					new(890, 2385, 4, ""),
					new(890, 2386, 4, ""),
					new(810, 2321, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2499, "", new DecorationEntry[]
				{
					new(797, 2266, 4, ""),
					new(814, 2195, 4, ""),
				}),
				new("Ham", typeof(Static), 2515, "", new DecorationEntry[]
				{
					new(754, 2263, 6, ""),
					new(866, 2321, 6, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(810, 2321, 4, ""),
					new(739, 2344, 6, ""),
					new(890, 2385, 4, ""),
					new(797, 2266, 4, ""),
					new(811, 2322, 4, ""),
					new(810, 2323, 4, ""),
					new(891, 2386, 4, ""),
					new(797, 2267, 4, ""),
					new(890, 2387, 4, ""),
					new(814, 2195, 4, ""),
					new(747, 2264, 6, ""),
					new(814, 2196, 4, ""),
					new(864, 2315, 6, ""),
					new(784, 2219, 16, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(809, 2334, 6, ""),
					new(889, 2398, 6, ""),
					new(819, 2192, 0, ""),
					new(806, 2265, 6, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(747, 2264, 6, ""),
					new(814, 2196, 4, ""),
					new(797, 2267, 4, ""),
					new(739, 2344, 6, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(784, 2219, 16, ""),
					new(891, 2386, 4, ""),
					new(864, 2315, 6, ""),
					new(811, 2322, 4, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(739, 2344, 6, ""),
					new(747, 2264, 6, ""),
					new(814, 2196, 4, ""),
					new(797, 2267, 4, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(864, 2315, 6, ""),
					new(811, 2322, 4, ""),
					new(784, 2219, 16, ""),
					new(891, 2386, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(797, 2267, 4, ""),
					new(739, 2344, 6, ""),
					new(747, 2264, 6, ""),
					new(814, 2196, 4, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(864, 2315, 6, ""),
					new(784, 2219, 16, ""),
					new(811, 2322, 4, ""),
					new(891, 2386, 4, ""),
				}),
				new("Lantern Post", typeof(Static), 2592, "", new DecorationEntry[]
				{
					new(712, 2234, -3, ""),
				}),
				new("Lantern", typeof(Lantern), 2594, "", new DecorationEntry[]
				{
					new(738, 2344, 6, ""),
					new(746, 2264, 6, ""),
					new(784, 2218, 16, ""),
					new(793, 2272, 12, ""),
					new(814, 2200, 12, ""),
					new(816, 2320, 12, ""),
					new(864, 2314, 6, ""),
					new(896, 2384, 13, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(818, 2328, 0, ""),
					new(897, 2392, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(808, 2186, 0, ""),
					new(800, 2273, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(810, 2184, 0, ""),
					new(802, 2272, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(816, 2330, 0, ""),
					new(896, 2394, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(809, 2192, 0, ""),
					new(814, 2320, 0, ""),
					new(737, 2136, 0, ""),
					new(893, 2384, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(894, 2384, 0, ""),
					new(813, 2192, 0, ""),
					new(741, 2136, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(736, 2137, 0, ""),
					new(736, 2141, 0, ""),
					new(792, 2269, 0, ""),
					new(888, 2391, 0, ""),
					new(888, 2386, 0, ""),
					new(808, 2327, 0, ""),
					new(808, 2324, 0, ""),
					new(808, 2193, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(808, 2197, 0, ""),
					new(792, 2270, 0, ""),
					new(888, 2390, 0, ""),
					new(808, 2326, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(813, 2320, 0, ""),
					new(814, 2192, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(888, 2387, 0, ""),
					new(792, 2265, 0, ""),
					new(808, 2325, 0, ""),
					new(888, 2389, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(893, 2390, 4, ""),
					new(753, 2145, 4, ""),
					new(753, 2141, 4, ""),
					new(738, 2139, 4, ""),
					new(798, 2267, 4, ""),
					new(815, 2196, 4, ""),
					new(812, 2334, 6, ""),
					new(811, 2321, 4, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(757, 2149, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(739, 2138, 0, ""),
					new(753, 2138, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(751, 2140, 0, ""),
					new(751, 2146, 0, ""),
					new(751, 2144, 0, ""),
					new(751, 2142, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(797, 2265, 0, ""),
					new(814, 2194, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(793, 2267, 0, ""),
					new(755, 2144, 0, ""),
					new(755, 2146, 0, ""),
					new(755, 2142, 0, ""),
					new(809, 2195, 0, ""),
					new(755, 2140, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(740, 2140, 0, ""),
					new(738, 2140, 0, ""),
					new(814, 2197, 0, ""),
					new(797, 2268, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(809, 2323, 0, ""),
					new(809, 2321, 0, ""),
					new(889, 2387, 0, ""),
					new(892, 2391, 0, ""),
					new(812, 2327, 0, ""),
					new(889, 2385, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(739, 2345, 0, ""),
					new(747, 2265, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(865, 2315, 0, ""),
					new(812, 2322, 0, ""),
					new(892, 2386, 0, ""),
					new(785, 2219, 10, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2968, "", new DecorationEntry[]
				{
					new(712, 2235, -3, ""),
				}),
				new("Sign", typeof(Static), 2994, "Name=Skara Brae Ferry :    Step onto the boat and say \"I would like to cross", new DecorationEntry[]
				{
					new(713, 2236, 7, ""),
				}),
				new("Small Fish", typeof(Static), 3542, "", new DecorationEntry[]
				{
					new(716, 2236, -2, ""),
				}),
				new("Small Fish", typeof(Static), 3544, "", new DecorationEntry[]
				{
					new(724, 2239, -1, ""),
					new(715, 2234, -3, ""),
				}),
				new("Small Fish", typeof(Static), 3545, "", new DecorationEntry[]
				{
					new(724, 2238, -3, ""),
					new(713, 2238, -1, ""),
				}),
				new("Campfire", typeof(Static), 3555, "Light=Circle225", new DecorationEntry[]
				{
					new(755, 2203, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(864, 2313, 0, ""),
					new(736, 2346, 0, ""),
					new(744, 2269, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(785, 2216, 10, ""),
				}),
				new("Stump", typeof(Static), 3672, "", new DecorationEntry[]
				{
					new(756, 2201, 0, ""),
				}),
				new("Stump", typeof(Static), 3673, "", new DecorationEntry[]
				{
					new(753, 2202, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(744, 2264, 5, ""),
					new(784, 2222, 15, ""),
					new(718, 2232, -2, ""),
					new(745, 2264, 5, ""),
					new(784, 2221, 10, ""),
					new(784, 2222, 10, ""),
					new(784, 2221, 15, ""),
					new(720, 2232, -2, ""),
					new(729, 2232, -2, ""),
					new(729, 2233, -2, ""),
					new(744, 2264, 0, ""),
					new(744, 2265, 0, ""),
					new(745, 2264, 0, ""),
					new(728, 2232, -2, ""),
				}),
				new("Sheaf Of Hay", typeof(Static), 3894, "", new DecorationEntry[]
				{
					new(755, 2153, 0, ""),
					new(752, 2153, 0, ""),
				}),
				new("Executioner's Axe", typeof(Static), 3910, "", new DecorationEntry[]
				{
					new(754, 2201, 0, ""),
				}),
				new("Dying Tub", typeof(DyeTub), 4011, "Hue=0x8A", new DecorationEntry[]
				{
					new(864, 2317, 0, ""),
				}),
				new("Dying Tub", typeof(DyeTub), 4011, "Hue=0x2DD", new DecorationEntry[]
				{
					new(741, 2344, 0, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "Light=Circle225", new DecorationEntry[]
				{
					new(755, 2203, 0, ""),
					new(870, 2324, 0, ""),
					new(756, 2267, 0, ""),
					new(786, 2233, 0, ""),
					new(748, 2350, 0, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(792, 2267, 4, ""),
					new(813, 2327, 4, ""),
					new(893, 2391, 4, ""),
					new(808, 2195, 4, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(739, 2139, 4, ""),
					new(753, 2139, 4, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(893, 2391, 4, ""),
					new(813, 2327, 4, ""),
					new(792, 2267, 4, ""),
					new(808, 2195, 4, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(739, 2139, 4, ""),
					new(753, 2139, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4095, "", new DecorationEntry[]
				{
					new(740, 2344, 6, ""),
					new(748, 2264, 6, ""),
					new(891, 2385, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4096, "", new DecorationEntry[]
				{
					new(864, 2316, 6, ""),
					new(784, 2220, 16, ""),
					new(811, 2323, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4097, "", new DecorationEntry[]
				{
					new(891, 2385, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4098, "", new DecorationEntry[]
				{
					new(810, 2323, 4, ""),
					new(890, 2386, 4, ""),
					new(810, 2321, 4, ""),
				}),
				new("Wash Basin", typeof(Static), 4104, "", new DecorationEntry[]
				{
					new(785, 2217, 10, ""),
					new(745, 2265, 0, ""),
					new(745, 2346, 6, ""),
					new(866, 2322, 6, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4107, "", new DecorationEntry[]
				{
					new(756, 2153, 0, ""),
					new(753, 2153, 0, ""),
				}),
				new("Hay Sheave", typeof(Static), 4109, "", new DecorationEntry[]
				{
					new(757, 2153, 0, ""),
					new(754, 2153, 0, ""),
				}),
				new("Hay", typeof(Static), 4150, "", new DecorationEntry[]
				{
					new(755, 2159, 0, ""),
					new(752, 2161, 0, ""),
					new(866, 2317, 0, ""),
					new(759, 2153, 0, ""),
					new(748, 2268, 0, ""),
					new(748, 2269, 0, ""),
					new(786, 2222, 10, ""),
					new(786, 2218, 10, ""),
					new(749, 2267, 0, ""),
					new(749, 2269, 0, ""),
					new(755, 2153, 0, ""),
					new(754, 2155, 0, ""),
					new(867, 2315, 0, ""),
					new(869, 2316, 0, ""),
					new(869, 2317, 0, ""),
					new(869, 2315, 0, ""),
					new(867, 2316, 0, ""),
					new(867, 2318, 0, ""),
					new(868, 2318, 0, ""),
					new(753, 2156, 0, ""),
					new(756, 2155, 0, ""),
					new(865, 2318, 0, ""),
					new(756, 2157, 0, ""),
					new(870, 2313, 0, ""),
					new(758, 2156, 2, ""),
					new(758, 2154, 0, ""),
					new(742, 2350, 0, ""),
					new(787, 2221, 10, ""),
					new(741, 2350, 0, ""),
					new(738, 2346, 0, ""),
					new(737, 2350, 0, ""),
					new(787, 2218, 10, ""),
					new(787, 2220, 10, ""),
					new(739, 2349, 0, ""),
					new(740, 2350, 0, ""),
					new(788, 2220, 10, ""),
					new(788, 2221, 10, ""),
					new(746, 2269, 0, ""),
					new(739, 2347, 0, ""),
					new(741, 2348, 0, ""),
					new(742, 2349, 0, ""),
					new(787, 2217, 10, ""),
					new(747, 2268, 0, ""),
					new(754, 2159, 0, ""),
					new(789, 2222, 10, ""),
					new(789, 2221, 10, ""),
					new(742, 2347, 0, ""),
					new(747, 2267, 0, ""),
				}),
				new("Dough", typeof(Static), 4157, "", new DecorationEntry[]
				{
					new(806, 2266, 9, ""),
					new(822, 2194, 9, ""),
				}),
				new("Cookie Mix", typeof(Static), 4159, "", new DecorationEntry[]
				{
					new(806, 2264, 9, ""),
					new(822, 2195, 9, ""),
				}),
				new("Rolling Pin", typeof(Static), 4163, "", new DecorationEntry[]
				{
					new(820, 2196, 0, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(754, 2200, 0, ""),
					new(757, 2194, 13, ""),
					new(761, 2199, 0, ""),
					new(754, 2209, 5, ""),
					new(761, 2200, 0, ""),
					new(753, 2204, 5, ""),
					new(754, 2210, 1, ""),
					new(756, 2201, 0, ""),
					new(755, 2205, 1, ""),
					new(757, 2203, 0, ""),
					new(762, 2201, 0, ""),
				}),
				new("Potted Tree", typeof(PottedTree), 4552, "", new DecorationEntry[]
				{
					new(902, 2392, 0, ""),
					new(808, 2184, 0, ""),
				}),
				new("Potted Tree", typeof(PottedTree1), 4553, "", new DecorationEntry[]
				{
					new(888, 2384, 0, ""),
					new(736, 2144, 0, ""),
					new(800, 2272, 0, ""),
					new(816, 2328, 0, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(808, 2320, 0, ""),
					new(896, 2392, 0, ""),
					new(792, 2264, 0, ""),
					new(808, 2192, 0, ""),
				}),
				new("Archer's Guild", typeof(LocalizedSign), 4761, "LabelNumber=1016044", new DecorationEntry[]
				{
					new(742, 2232, 14, ""),
				}),
				new("Docks To Skara Brae", typeof(LocalizedSign), 4762, "LabelNumber=1016103", new DecorationEntry[]
				{
					new(742, 2232, 17, ""),
					new(772, 2240, 16, ""),
					new(813, 2240, 10, ""),
				}),
				new("Britain", typeof(LocalizedSign), 4764, "LabelNumber=1016070", new DecorationEntry[]
				{
					new(742, 2232, 10, ""),
					new(772, 2240, 13, ""),
					new(813, 2240, 15, ""),
				}),
				new("Ferry Out Of Service", typeof(LocalizedSign), 4765, "LabelNumber=1016113", new DecorationEntry[]
				{
					new(712, 2232, 13, ""),
				}),
				new("Plough", typeof(Static), 5376, "", new DecorationEntry[]
				{
					new(899, 2405, 0, ""),
				}),
				new("Plough", typeof(Static), 5377, "", new DecorationEntry[]
				{
					new(898, 2405, 0, ""),
				}),
				new("Plough", typeof(Static), 5378, "", new DecorationEntry[]
				{
					new(810, 2281, 0, ""),
					new(833, 2341, 0, ""),
				}),
				new("Plough", typeof(Static), 5379, "", new DecorationEntry[]
				{
					new(833, 2342, 0, ""),
					new(810, 2282, 0, ""),
				}),
				new("Harrow", typeof(Static), 5381, "", new DecorationEntry[]
				{
					new(828, 2338, 0, ""),
					new(814, 2276, 0, ""),
				}),
				new("Harrow", typeof(Static), 5383, "", new DecorationEntry[]
				{
					new(895, 2406, 0, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(728, 2233, -2, ""),
					new(752, 2268, 0, ""),
					new(871, 2321, 0, ""),
					new(719, 2232, -2, ""),
					new(722, 2238, -2, ""),
					new(784, 2230, 0, ""),
					new(748, 2345, 0, ""),
				}),
				new("Bowl Of Carrots", typeof(Static), 5625, "", new DecorationEntry[]
				{
					new(806, 2267, 6, ""),
				}),
				new("Bowl Of Lettuce", typeof(Static), 5627, "", new DecorationEntry[]
				{
					new(805, 2268, 6, ""),
				}),
				new("Pewter Bowl", typeof(Static), 5629, "", new DecorationEntry[]
				{
					new(813, 2328, 4, ""),
				}),
				new("Large Pewter Bowl", typeof(Static), 5635, "", new DecorationEntry[]
				{
					new(811, 2334, 6, ""),
				}),
				new("Leaves", typeof(Static), 6947, "Hue=0x970", new DecorationEntry[]
				{
					new(875, 2326, 0, ""),
					new(887, 2424, 0, ""),
					new(861, 2280, 0, ""),
					new(789, 2220, 10, ""),
					new(804, 2198, 0, ""),
					new(795, 2289, 0, ""),
					new(803, 2197, 0, ""),
					new(831, 2223, 13, ""),
					new(794, 2304, 0, ""),
					new(855, 2363, 0, ""),
					new(894, 2382, 0, ""),
					new(859, 2342, 0, ""),
					new(842, 2356, 0, ""),
					new(805, 2189, 0, ""),
					new(890, 2365, 0, ""),
					new(863, 2391, 0, ""),
					new(806, 2303, 0, ""),
					new(835, 2296, 8, ""),
					new(839, 2231, 0, ""),
					new(879, 2395, 0, ""),
					new(892, 2245, 0, ""),
					new(872, 2374, 0, ""),
					new(831, 2269, 0, ""),
					new(878, 2395, 0, ""),
				}),
				new("Leaves", typeof(Static), 6948, "Hue=0x970", new DecorationEntry[]
				{
					new(890, 2363, 0, ""),
					new(879, 2393, 0, ""),
					new(859, 2340, 0, ""),
					new(842, 2354, 0, ""),
					new(861, 2278, 0, ""),
					new(806, 2301, 0, ""),
					new(878, 2393, 0, ""),
					new(789, 2218, 10, ""),
					new(875, 2324, 0, ""),
					new(863, 2389, 0, ""),
					new(894, 2380, 0, ""),
					new(872, 2372, 0, ""),
					new(805, 2187, 0, ""),
					new(794, 2302, 0, ""),
					new(831, 2221, 13, ""),
					new(855, 2361, 0, ""),
					new(803, 2195, 0, ""),
					new(892, 2243, 0, ""),
					new(887, 2422, 0, ""),
					new(831, 2267, 0, ""),
					new(835, 2294, 6, ""),
					new(804, 2196, 0, ""),
					new(839, 2229, 0, ""),
				}),
				new("Leaves", typeof(Static), 6949, "Hue=0x970", new DecorationEntry[]
				{
					new(853, 2361, 0, ""),
					new(837, 2229, 0, ""),
					new(803, 2187, 0, ""),
					new(890, 2243, 0, ""),
					new(804, 2301, 0, ""),
					new(833, 2294, 10, ""),
					new(792, 2302, 0, ""),
					new(888, 2363, 0, ""),
					new(859, 2278, 0, ""),
					new(877, 2393, 0, ""),
					new(787, 2218, 10, ""),
					new(876, 2393, 0, ""),
					new(873, 2324, 0, ""),
					new(829, 2267, 0, ""),
					new(861, 2389, 0, ""),
					new(885, 2422, 0, ""),
					new(870, 2372, 0, ""),
					new(840, 2354, 0, ""),
					new(857, 2340, 0, ""),
					new(829, 2221, 13, ""),
					new(801, 2195, 0, ""),
					new(802, 2196, 0, ""),
					new(904, 2235, 0, ""),
					new(892, 2380, 0, ""),
					new(793, 2287, 0, ""),
				}),
				new("Leaves", typeof(Static), 6950, "Hue=0x970", new DecorationEntry[]
				{
					new(802, 2198, 0, ""),
					new(829, 2223, 13, ""),
					new(792, 2304, 0, ""),
					new(787, 2220, 10, ""),
					new(870, 2374, 0, ""),
					new(793, 2289, 0, ""),
					new(840, 2356, 0, ""),
					new(892, 2382, 0, ""),
					new(801, 2197, 0, ""),
					new(885, 2424, 0, ""),
					new(859, 2280, 0, ""),
					new(888, 2365, 0, ""),
					new(837, 2231, 0, ""),
					new(904, 2237, 0, ""),
					new(857, 2342, 0, ""),
					new(873, 2326, 0, ""),
					new(876, 2395, 0, ""),
					new(890, 2245, 0, ""),
					new(853, 2363, 0, ""),
					new(833, 2296, 10, ""),
					new(861, 2391, 0, ""),
					new(877, 2395, 0, ""),
					new(803, 2189, 0, ""),
					new(829, 2269, 0, ""),
					new(804, 2303, 0, ""),
				}),
				new("Tightrope", typeof(Static), 10000, "", new DecorationEntry[]
				{
					new(710, 2236, -3, ""),
					new(711, 2236, -3, ""),
				}),
				new("Prow", typeof(Static), 16026, "", new DecorationEntry[]
				{
					new(709, 2234, -5, ""),
				}),
				new("Ship", typeof(Static), 16027, "", new DecorationEntry[]
				{
					new(708, 2235, -5, ""),
				}),
				new("Ship", typeof(Static), 16028, "", new DecorationEntry[]
				{
					new(710, 2235, -5, ""),
				}),
				new("Ship", typeof(Static), 16029, "", new DecorationEntry[]
				{
					new(708, 2236, -5, ""),
				}),
				new("Ship", typeof(Static), 16030, "", new DecorationEntry[]
				{
					new(710, 2236, -5, ""),
				}),
				new("Ship", typeof(Static), 16031, "", new DecorationEntry[]
				{
					new(708, 2237, -5, ""),
				}),
				new("Ship", typeof(Static), 16032, "", new DecorationEntry[]
				{
					new(710, 2237, -5, ""),
				}),
				new("Deck", typeof(Static), 16033, "", new DecorationEntry[]
				{
					new(708, 2238, -5, ""),
				}),
				new("Ship", typeof(Static), 16039, "", new DecorationEntry[]
				{
					new(708, 2239, -5, ""),
				}),
				new("Ship", typeof(Static), 16040, "", new DecorationEntry[]
				{
					new(710, 2239, -5, ""),
				}),
				new("Ship", typeof(Static), 16043, "", new DecorationEntry[]
				{
					new(710, 2240, -5, ""),
				}),
				new("Deck", typeof(Static), 16044, "", new DecorationEntry[]
				{
					new(709, 2238, -5, ""),
					new(709, 2239, -5, ""),
					new(710, 2238, -5, ""),
				}),
				new("Deck", typeof(Static), 16045, "", new DecorationEntry[]
				{
					new(709, 2236, -5, ""),
				}),
				new("Hatch", typeof(Static), 16046, "", new DecorationEntry[]
				{
					new(709, 2235, -5, ""),
				}),
				new("Deck", typeof(Static), 16048, "", new DecorationEntry[]
				{
					new(709, 2237, -5, ""),
				}),
				new("Ship", typeof(Static), 16049, "", new DecorationEntry[]
				{
					new(707, 2238, -5, ""),
				}),
				new("Ship", typeof(Static), 16054, "", new DecorationEntry[]
				{
					new(708, 2240, -5, ""),
				}),
				new("Rudder", typeof(Static), 16060, "", new DecorationEntry[]
				{
					new(709, 2241, -5, ""),
				}),
				new("Deck", typeof(Static), 16064, "", new DecorationEntry[]
				{
					new(709, 2240, -5, ""),
				}),
				new("Gang Plank", typeof(Static), 16084, "", new DecorationEntry[]
				{
					new(711, 2238, -5, ""),
				}),
				
				#endregion
			});
		}
	}
}
