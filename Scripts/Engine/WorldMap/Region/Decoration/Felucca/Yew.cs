using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Felucca
		{
			public static DecorationList[] Yew { get; } = Register(DecorationTarget.Felucca, "Yew", new DecorationList[]
			{
				#region Entries
				
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(319, 791, 20, ""),
					new(299, 764, 20, ""),
					new(312, 783, 20, ""),
					new(313, 791, 20, ""),
					new(356, 839, 20, ""),
					new(369, 903, 0, ""),
					new(369, 867, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW", new DecorationEntry[]
				{
					new(313, 783, 20, ""),
					new(357, 839, 20, ""),
					new(370, 903, 0, ""),
					new(370, 867, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW", new DecorationEntry[]
				{
					new(289, 771, 0, ""),
					new(289, 771, 20, ""),
					new(343, 884, 20, ""),
					new(367, 878, 0, ""),
					new(371, 871, 0, ""),
					new(327, 793, 20, ""),
					new(343, 885, 0, ""),
					new(351, 835, 20, ""),
					new(367, 878, 20, ""),
					new(343, 873, 0, ""),
					new(367, 873, 0, ""),
					new(367, 873, 20, ""),
					new(343, 873, 20, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(327, 792, 20, ""),
					new(351, 834, 20, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1669, "Facing=WestCW", new DecorationEntry[]
				{
					new(262, 769, -2, ""),
					new(262, 769, 20, ""),
					new(268, 769, -2, ""),
					new(268, 769, 20, ""),
					new(274, 769, -2, ""),
					new(274, 769, 20, ""),
					new(280, 769, -2, ""),
					new(280, 769, 20, ""),
					new(286, 769, -2, ""),
					new(286, 769, 20, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1673, "Facing=WestCCW", new DecorationEntry[]
				{
					new(262, 773, -2, ""),
					new(262, 773, 20, ""),
					new(268, 773, -2, ""),
					new(268, 773, 20, ""),
					new(274, 773, -2, ""),
					new(274, 773, 20, ""),
					new(280, 773, -2, ""),
					new(280, 773, 20, ""),
					new(286, 773, -2, ""),
					new(286, 773, 20, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2150, "Facing=WestCW", new DecorationEntry[]
				{
					new(355, 891, 0, ""),
					new(666, 951, 0, ""),
					new(666, 1191, 0, ""),
					new(355, 890, 20, ""),
					new(562, 1111, 0, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2152, "Facing=EastCCW", new DecorationEntry[]
				{
					new(356, 891, 0, ""),
					new(667, 951, 0, ""),
					new(667, 1191, 0, ""),
					new(356, 890, 20, ""),
					new(563, 1111, 0, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor1), 232, "Facing=WestCW", new DecorationEntry[]
				{
					new(308, 791, 0, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor1), 234, "Facing=EastCCW", new DecorationEntry[]
				{
					new(261, 763, 0, ""),
					new(262, 779, 0, ""),
					new(262, 779, 20, ""),
					new(267, 763, 0, ""),
					new(268, 779, 0, ""),
					new(268, 779, 20, ""),
					new(273, 763, 0, ""),
					new(274, 779, 0, ""),
					new(274, 779, 20, ""),
					new(279, 763, 0, ""),
					new(280, 779, 0, ""),
					new(280, 779, 20, ""),
					new(285, 763, 0, ""),
					new(286, 779, 0, ""),
					new(286, 779, 20, ""),
					new(291, 777, 20, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor1), 236, "Facing=WestCCW", new DecorationEntry[]
				{
					new(261, 763, 20, ""),
					new(267, 763, 20, ""),
					new(273, 763, 20, ""),
					new(279, 763, 20, ""),
					new(285, 763, 20, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor1), 240, "Facing=SouthCW", new DecorationEntry[]
				{
					new(296, 761, 20, ""),
					new(301, 762, 0, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor1), 242, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(301, 761, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 200, "", new DecorationEntry[]
				{
					new(309, 791, 0, ""),
				}),
				new("Stone Wall", typeof(Static), 201, "", new DecorationEntry[]
				{
					new(564, 1307, 0, ""),
				}),
				new("Patch", typeof(Static), 753, "", new DecorationEntry[]
				{
					new(597, 837, 0, ""),
				}),
				new("Patch", typeof(Static), 754, "", new DecorationEntry[]
				{
					new(597, 837, 0, ""),
				}),
				new("Cobblestones", typeof(Static), 1301, "", new DecorationEntry[]
				{
					new(383, 917, 0, ""),
				}),
				new("Cobblestones", typeof(Static), 1302, "", new DecorationEntry[]
				{
					new(309, 786, 0, ""),
					new(309, 787, 0, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "", new DecorationEntry[]
				{
					new(552, 1217, 0, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(394, 1216, 0, ""),
					new(553, 984, -2, ""),
					new(682, 1200, 0, ""),
					new(665, 1000, 0, ""),
				}),
				new("Slab Of Bacon", typeof(Static), 2422, "", new DecorationEntry[]
				{
					new(457, 1141, 6, ""),
					new(603, 1187, 6, ""),
				}),
				new("Slab Of Bacon", typeof(Static), 2423, "", new DecorationEntry[]
				{
					new(392, 1218, 6, ""),
					new(602, 1184, 10, ""),
					new(603, 1184, 6, ""),
				}),
				new("Wheel Of Cheese", typeof(CheeseWheel), 2430, "", new DecorationEntry[]
				{
					new(452, 1110, 6, ""),
				}),
				new("Basket", typeof(Basket), 2448, "", new DecorationEntry[]
				{
					new(416, 1035, 4, ""),
					new(656, 1005, 6, ""),
				}),
				new("Tray", typeof(Static), 2449, "", new DecorationEntry[]
				{
					new(392, 1218, 6, ""),
					new(539, 1009, 6, ""),
					new(603, 1184, 6, ""),
					new(642, 844, 4, ""),
					new(643, 834, 4, ""),
					new(654, 938, 6, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(416, 1037, 4, ""),
					new(450, 1117, 6, ""),
					new(459, 1141, 6, ""),
					new(555, 1221, 6, ""),
					new(574, 1123, 6, ""),
					new(679, 1202, 6, ""),
				}),
				new("Fruit Basket", typeof(FruitBasket), 2451, "", new DecorationEntry[]
				{
					new(284, 986, 4, ""),
					new(421, 1035, 6, ""),
					new(642, 833, 4, ""),
					new(656, 1004, 6, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2453, "", new DecorationEntry[]
				{
					new(642, 834, 4, ""),
					new(642, 837, 4, ""),
					new(642, 838, 4, ""),
					new(642, 840, 4, ""),
					new(642, 842, 4, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2455, "", new DecorationEntry[]
				{
					new(400, 1219, 6, ""),
					new(452, 1112, 6, ""),
					new(555, 1210, 6, ""),
					new(574, 1122, 6, ""),
					new(599, 1187, 6, ""),
					new(624, 1149, 6, ""),
					new(643, 836, 4, ""),
					new(643, 838, 4, ""),
					new(643, 840, 4, ""),
					new(643, 842, 4, ""),
					new(643, 844, 4, ""),
					new(648, 938, 6, ""),
					new(648, 1084, 6, ""),
					new(677, 1202, 6, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(261, 774, 0, ""),
					new(261, 774, 20, ""),
					new(262, 766, 0, ""),
					new(262, 766, 20, ""),
					new(267, 774, 0, ""),
					new(267, 774, 20, ""),
					new(268, 766, 0, ""),
					new(268, 766, 20, ""),
					new(273, 774, 0, ""),
					new(274, 766, 0, ""),
					new(274, 766, 20, ""),
					new(274, 774, 20, ""),
					new(279, 774, 0, ""),
					new(279, 774, 20, ""),
					new(280, 766, 0, ""),
					new(280, 766, 20, ""),
					new(285, 774, 0, ""),
					new(285, 774, 20, ""),
					new(286, 766, 0, ""),
					new(286, 766, 20, ""),
					new(324, 1240, 6, ""),
					new(398, 1220, 6, ""),
					new(400, 1219, 6, ""),
					new(420, 1034, 6, ""),
					new(450, 963, 6, ""),
					new(451, 1112, 6, ""),
					new(452, 1112, 6, ""),
					new(458, 1135, 6, ""),
					new(459, 1133, 6, ""),
					new(554, 1212, 6, ""),
					new(555, 1210, 6, ""),
					new(572, 1123, 6, ""),
					new(574, 1122, 6, ""),
					new(597, 1188, 6, ""),
					new(599, 1187, 6, ""),
					new(624, 1147, 6, ""),
					new(634, 1040, 6, ""),
					new(646, 939, 6, ""),
					new(648, 938, 6, ""),
					new(648, 1084, 6, ""),
					new(660, 1003, 6, ""),
					new(662, 1002, 6, ""),
					new(677, 1202, 6, ""),
					new(677, 1203, 6, ""),
					new(734, 883, 6, ""),
					new(736, 882, 6, ""),
				}),
				new("Bottles Of Liquor", typeof(Static), 2462, "", new DecorationEntry[]
				{
					new(608, 873, 5, ""),
					new(608, 876, 0, ""),
					new(609, 872, 10, ""),
					new(611, 872, 0, ""),
					new(611, 875, 0, ""),
					new(613, 875, 5, ""),
					new(613, 877, 0, ""),
					new(615, 872, 0, ""),
					new(615, 873, 5, ""),
					new(615, 875, 0, ""),
					new(617, 873, 0, ""),
					new(617, 874, 0, ""),
					new(617, 877, 0, ""),
					new(619, 876, 0, ""),
					new(620, 874, 10, ""),
					new(621, 874, 0, ""),
				}),
				new("Fork", typeof(Fork), 2467, "", new DecorationEntry[]
				{
					new(451, 1111, 6, ""),
					new(458, 1134, 6, ""),
					new(554, 1211, 6, ""),
					new(642, 835, 4, ""),
					new(642, 837, 4, ""),
					new(642, 839, 4, ""),
					new(642, 841, 4, ""),
					new(642, 843, 4, ""),
				}),
				new("Fork", typeof(Fork), 2468, "", new DecorationEntry[]
				{
					new(399, 1219, 6, ""),
					new(573, 1122, 6, ""),
					new(598, 1187, 6, ""),
					new(647, 938, 6, ""),
					new(678, 1202, 6, ""),
				}),
				new("Knife", typeof(Knife), 2469, "", new DecorationEntry[]
				{
					new(451, 1111, 6, ""),
					new(458, 1134, 6, ""),
					new(554, 1211, 6, ""),
					new(642, 835, 4, ""),
					new(642, 837, 4, ""),
					new(642, 839, 4, ""),
					new(642, 841, 4, ""),
					new(642, 843, 4, ""),
				}),
				new("Knife", typeof(Knife), 2470, "", new DecorationEntry[]
				{
					new(399, 1219, 6, ""),
					new(535, 1011, 6, ""),
					new(573, 1122, 6, ""),
					new(598, 1187, 6, ""),
					new(647, 938, 6, ""),
					new(678, 1202, 6, ""),
				}),
				new("Metal Box", typeof(FillableMetalBox), 2472, "", new DecorationEntry[]
				{
					new(565, 1307, 0, ""),
				}),
				new("Metal Box", typeof(MetalBox), 2472, "", new DecorationEntry[]
				{
					new(555, 988, 6, ""),
					new(562, 1008, 6, ""),
					new(565, 960, 6, ""),
				}),
				new("Wooden Box", typeof(WoodenBox), 2474, "", new DecorationEntry[]
				{
					new(731, 880, 0, ""),
					new(739, 880, 0, ""),
				}),
				new("Metal Chest", typeof(FillableMetalChest), 2475, "ContentType=Inn", new DecorationEntry[]
				{
					new(603, 808, 0, ""),
					new(603, 816, 0, ""),
					new(604, 826, 0, ""),
					new(607, 826, 0, ""),
					new(617, 824, 0, ""),
					new(619, 808, 0, ""),
					new(649, 808, 0, ""),
					new(653, 824, 0, ""),
					new(668, 808, 0, ""),
					new(668, 816, 0, ""),
				}),
				new("Bushel", typeof(Basket), 2476, "", new DecorationEntry[]
				{
					new(656, 1006, 6, ""),
				}),
				new("Cooked Bird", typeof(CookedBird), 2487, "", new DecorationEntry[]
				{
					new(642, 844, 4, ""),
					new(643, 834, 4, ""),
				}),
				new("Cooked Bird", typeof(CookedBird), 2488, "", new DecorationEntry[]
				{
					new(459, 1141, 6, ""),
					new(555, 1221, 6, ""),
					new(574, 1123, 6, ""),
					new(679, 1202, 6, ""),
				}),
				new("Roast Pig", typeof(RoastPig), 2491, "", new DecorationEntry[]
				{
					new(281, 984, 4, ""),
				}),
				new("Roast Pig", typeof(RoastPig), 2492, "", new DecorationEntry[]
				{
					new(392, 1220, 9, ""),
				}),
				new("Silverware", typeof(Static), 2493, "", new DecorationEntry[]
				{
					new(283, 986, 4, ""),
				}),
				new("Silverware", typeof(Static), 2494, "", new DecorationEntry[]
				{
					new(421, 1034, 6, ""),
					new(481, 850, 4, ""),
					new(483, 850, 4, ""),
					new(661, 1002, 6, ""),
					new(735, 882, 6, ""),
				}),
				new("Sausage", typeof(Sausage), 2496, "", new DecorationEntry[]
				{
					new(603, 1188, 6, ""),
				}),
				new("Sausage", typeof(Sausage), 2497, "", new DecorationEntry[]
				{
					new(392, 1221, 6, ""),
				}),
				new("Ham", typeof(Ham), 2505, "", new DecorationEntry[]
				{
					new(604, 1184, 11, ""),
				}),
				new("Ceramic Mug", typeof(CeramicMug), 2506, "", new DecorationEntry[]
				{
					new(324, 1240, 6, ""),
					new(398, 1220, 6, ""),
					new(451, 1112, 6, ""),
					new(554, 1212, 6, ""),
					new(572, 1123, 6, ""),
					new(597, 1188, 6, ""),
					new(634, 1040, 6, ""),
					new(646, 939, 6, ""),
					new(677, 1203, 6, ""),
				}),
				new("Grape Bunch", typeof(Grapes), 2513, "", new DecorationEntry[]
				{
					new(594, 846, 0, ""),
					new(594, 858, 0, ""),
					new(597, 853, 0, ""),
					new(600, 841, 0, ""),
					new(600, 846, 0, ""),
					new(600, 857, 0, ""),
					new(603, 848, 0, ""),
					new(603, 860, 0, ""),
					new(606, 845, 0, ""),
					new(606, 858, 0, ""),
					new(609, 854, 0, ""),
					new(610, 883, 6, ""),
					new(610, 884, 6, ""),
					new(610, 885, 6, ""),
					new(610, 886, 6, ""),
					new(610, 887, 6, ""),
					new(610, 892, 6, ""),
					new(611, 892, 6, ""),
					new(612, 846, 0, ""),
					new(612, 856, 0, ""),
					new(612, 892, 6, ""),
					new(613, 892, 6, ""),
					new(614, 883, 6, ""),
					new(614, 884, 6, ""),
					new(614, 885, 6, ""),
					new(614, 886, 6, ""),
					new(614, 887, 6, ""),
					new(615, 842, 0, ""),
					new(615, 850, 0, ""),
					new(615, 858, 0, ""),
					new(615, 892, 6, ""),
					new(616, 892, 6, ""),
					new(617, 892, 6, ""),
					new(618, 883, 6, ""),
					new(618, 884, 6, ""),
					new(618, 885, 6, ""),
					new(618, 886, 6, ""),
					new(618, 887, 6, ""),
					new(618, 892, 6, ""),
				}),
				new("Ham", typeof(Ham), 2515, "", new DecorationEntry[]
				{
					new(603, 1189, 6, ""),
				}),
				new("Silverware", typeof(Static), 2516, "", new DecorationEntry[]
				{
					new(284, 987, 4, ""),
					new(286, 987, 4, ""),
					new(420, 1035, 6, ""),
					new(451, 963, 6, ""),
					new(480, 851, 4, ""),
					new(482, 851, 4, ""),
					new(661, 1003, 6, ""),
					new(735, 883, 6, ""),
				}),
				new("Silverware", typeof(Static), 2517, "", new DecorationEntry[]
				{
					new(287, 986, 4, ""),
					new(328, 1061, 4, ""),
				}),
				new("Pitcher", typeof(Static), 2518, "", new DecorationEntry[]
				{
					new(480, 851, 4, ""),
					new(481, 850, 4, ""),
					new(482, 851, 4, ""),
					new(483, 850, 4, ""),
				}),
				new("Plate", typeof(Plate), 2519, "", new DecorationEntry[]
				{
					new(283, 986, 4, ""),
					new(284, 987, 4, ""),
					new(286, 987, 4, ""),
					new(287, 986, 4, ""),
					new(323, 1240, 6, ""),
					new(328, 1061, 4, ""),
					new(399, 1219, 6, ""),
					new(399, 1220, 6, ""),
					new(420, 1035, 6, ""),
					new(421, 1034, 6, ""),
					new(451, 963, 6, ""),
					new(451, 1111, 6, ""),
					new(452, 1111, 6, ""),
					new(458, 1134, 6, ""),
					new(459, 1134, 6, ""),
					new(480, 851, 4, ""),
					new(481, 850, 4, ""),
					new(482, 851, 4, ""),
					new(483, 850, 4, ""),
					new(554, 1211, 6, ""),
					new(555, 1211, 6, ""),
					new(573, 1122, 6, ""),
					new(573, 1123, 6, ""),
					new(598, 1187, 6, ""),
					new(598, 1188, 6, ""),
					new(624, 1148, 6, ""),
					new(633, 1040, 6, ""),
					new(642, 835, 4, ""),
					new(642, 837, 4, ""),
					new(642, 839, 4, ""),
					new(642, 841, 4, ""),
					new(642, 843, 4, ""),
					new(643, 835, 4, ""),
					new(643, 837, 4, ""),
					new(643, 839, 4, ""),
					new(643, 841, 4, ""),
					new(643, 843, 4, ""),
					new(647, 938, 6, ""),
					new(647, 939, 6, ""),
					new(648, 1085, 6, ""),
					new(661, 1002, 6, ""),
					new(661, 1003, 6, ""),
					new(678, 1202, 6, ""),
					new(678, 1203, 6, ""),
					new(735, 882, 6, ""),
					new(735, 883, 6, ""),
				}),
				new("Cake", typeof(Cake), 2537, "", new DecorationEntry[]
				{
					new(451, 1117, 6, ""),
					new(555, 1212, 6, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(397, 1216, 0, ""),
					new(449, 1117, 6, ""),
					new(458, 1141, 6, ""),
					new(553, 1221, 6, ""),
					new(555, 986, 6, ""),
					new(654, 936, 6, ""),
					new(685, 1201, 6, ""),
				}),
				new("Milk", typeof(Pitcher), 2544, "Content=Milk", new DecorationEntry[]
				{
					new(642, 836, 4, ""),
					new(643, 842, 4, ""),
				}),
				new("Cut Of Raw Ribs", typeof(RawRibs), 2545, "", new DecorationEntry[]
				{
					new(460, 1141, 6, ""),
					new(528, 1011, 3, ""),
				}),
				new("Fork", typeof(Fork), 2548, "", new DecorationEntry[]
				{
					new(323, 1240, 6, ""),
					new(399, 1220, 6, ""),
					new(573, 1123, 6, ""),
					new(598, 1188, 6, ""),
					new(633, 1040, 6, ""),
					new(647, 939, 6, ""),
					new(678, 1203, 6, ""),
				}),
				new("Fork", typeof(Fork), 2549, "", new DecorationEntry[]
				{
					new(452, 1111, 6, ""),
					new(459, 1134, 6, ""),
					new(555, 1211, 6, ""),
					new(624, 1148, 6, ""),
					new(643, 835, 4, ""),
					new(643, 837, 4, ""),
					new(643, 839, 4, ""),
					new(643, 841, 4, ""),
					new(643, 843, 4, ""),
					new(648, 1085, 6, ""),
				}),
				new("Knife", typeof(Knife), 2550, "", new DecorationEntry[]
				{
					new(323, 1240, 6, ""),
					new(399, 1220, 6, ""),
					new(573, 1123, 6, ""),
					new(598, 1188, 6, ""),
					new(633, 1040, 6, ""),
					new(647, 939, 6, ""),
					new(678, 1203, 6, ""),
				}),
				new("Knife", typeof(Knife), 2551, "", new DecorationEntry[]
				{
					new(452, 1111, 6, ""),
					new(459, 1134, 6, ""),
					new(555, 1211, 6, ""),
					new(603, 1188, 6, ""),
					new(624, 1148, 6, ""),
					new(643, 835, 4, ""),
					new(643, 837, 4, ""),
					new(643, 839, 4, ""),
					new(643, 841, 4, ""),
					new(643, 843, 4, ""),
					new(648, 1085, 6, ""),
				}),
				new("Spoon", typeof(Spoon), 2552, "", new DecorationEntry[]
				{
					new(323, 1240, 6, ""),
					new(399, 1220, 6, ""),
					new(573, 1123, 6, ""),
					new(598, 1188, 6, ""),
					new(633, 1040, 6, ""),
					new(647, 939, 6, ""),
					new(678, 1203, 6, ""),
				}),
				new("Spoon", typeof(Spoon), 2553, "", new DecorationEntry[]
				{
					new(452, 1111, 6, ""),
					new(459, 1134, 6, ""),
					new(555, 1211, 6, ""),
					new(624, 1148, 6, ""),
					new(643, 835, 4, ""),
					new(643, 837, 4, ""),
					new(643, 839, 4, ""),
					new(643, 841, 4, ""),
					new(643, 843, 4, ""),
					new(648, 1085, 6, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(331, 1056, 0, ""),
					new(333, 1056, 0, ""),
					new(392, 1224, 0, ""),
					new(426, 1040, 0, ""),
					new(449, 1128, 0, ""),
					new(457, 960, 0, ""),
					new(457, 1112, 0, ""),
					new(486, 840, 0, ""),
					new(578, 1120, 0, ""),
					new(595, 1184, 0, ""),
					new(625, 1144, 0, ""),
					new(637, 1040, 0, ""),
					new(648, 944, 0, ""),
					new(649, 1080, 0, ""),
					new(666, 1008, 0, ""),
					new(682, 1208, 0, ""),
					new(732, 880, 0, ""),
					new(738, 880, 0, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2608, "", new DecorationEntry[]
				{
					new(613, 824, 0, ""),
					new(665, 808, 0, ""),
					new(665, 816, 0, ""),
					new(669, 824, 0, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(320, 1245, 0, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(336, 883, 20, ""),
					new(336, 884, 0, ""),
					new(480, 841, 0, ""),
					new(600, 812, 0, ""),
					new(600, 820, 0, ""),
					new(600, 828, 0, ""),
					new(616, 811, 0, ""),
					new(616, 828, 0, ""),
					new(648, 811, 0, ""),
					new(648, 826, 0, ""),
					new(656, 828, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(609, 824, 0, ""),
					new(670, 824, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(280, 976, 0, ""),
					new(285, 976, 0, ""),
					new(394, 1224, 0, ""),
					new(453, 1128, 0, ""),
					new(461, 960, 0, ""),
					new(576, 1120, 0, ""),
					new(597, 1184, 0, ""),
					new(629, 1144, 0, ""),
					new(650, 944, 0, ""),
					new(653, 1080, 0, ""),
					new(670, 1008, 0, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(336, 882, 0, ""),
					new(336, 882, 20, ""),
					new(480, 842, 0, ""),
					new(600, 811, 0, ""),
					new(600, 819, 0, ""),
					new(600, 827, 0, ""),
					new(616, 810, 0, ""),
					new(616, 829, 0, ""),
					new(648, 810, 0, ""),
					new(648, 827, 0, ""),
					new(656, 829, 0, ""),
					new(664, 813, 0, ""),
					new(664, 821, 0, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(320, 1241, 0, ""),
					new(328, 1057, 0, ""),
					new(456, 1117, 0, ""),
					new(560, 1221, 0, ""),
					new(632, 1045, 0, ""),
					new(680, 1209, 0, ""),
				}),
				new("Folded Sheet", typeof(Static), 2706, "", new DecorationEntry[]
				{
					new(529, 960, 2, ""),
					new(532, 960, 2, ""),
					new(535, 960, 2, ""),
					new(538, 960, 2, ""),
					new(541, 960, 2, ""),
				}),
				new("Folded Sheet", typeof(Static), 2707, "", new DecorationEntry[]
				{
					new(424, 1043, 2, ""),
					new(424, 1045, 2, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(291, 976, 0, ""),
					new(330, 1240, 0, ""),
					new(339, 872, 0, ""),
					new(339, 872, 20, ""),
					new(401, 1216, 0, ""),
					new(406, 1216, 0, ""),
					new(450, 1104, 0, ""),
					new(461, 1128, 0, ""),
					new(473, 840, 0, ""),
					new(556, 1208, 0, ""),
					new(568, 960, 0, ""),
					new(598, 1184, 0, ""),
					new(601, 1184, 0, ""),
					new(626, 842, 20, ""),
					new(628, 1032, 0, ""),
					new(630, 816, 20, ""),
					new(638, 816, 20, ""),
					new(641, 936, 0, ""),
					new(642, 816, 20, ""),
					new(642, 1080, 0, ""),
					new(644, 1080, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(290, 976, 0, ""),
					new(292, 976, 0, ""),
					new(329, 1240, 0, ""),
					new(333, 1240, 0, ""),
					new(338, 872, 0, ""),
					new(338, 872, 20, ""),
					new(340, 872, 0, ""),
					new(340, 872, 20, ""),
					new(400, 1216, 0, ""),
					new(449, 1104, 0, ""),
					new(457, 1128, 0, ""),
					new(476, 840, 0, ""),
					new(477, 840, 0, ""),
					new(553, 1208, 0, ""),
					new(557, 1208, 0, ""),
					new(565, 808, 0, ""),
					new(569, 960, 0, ""),
					new(599, 1184, 0, ""),
					new(625, 842, 20, ""),
					new(625, 1032, 0, ""),
					new(631, 816, 20, ""),
					new(639, 816, 20, ""),
					new(641, 848, 0, ""),
					new(641, 1080, 0, ""),
					new(642, 848, 0, ""),
					new(642, 936, 0, ""),
					new(643, 848, 0, ""),
					new(643, 1080, 0, ""),
					new(644, 848, 0, ""),
					new(644, 936, 0, ""),
					new(645, 848, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(320, 1061, 0, ""),
					new(448, 1109, 0, ""),
					new(456, 1134, 0, ""),
					new(528, 968, 0, ""),
					new(528, 973, 0, ""),
					new(560, 968, 0, ""),
					new(568, 1124, 0, ""),
					new(616, 1146, 0, ""),
					new(616, 1148, 0, ""),
					new(624, 825, 20, ""),
					new(624, 838, 0, ""),
					new(624, 839, 0, ""),
					new(624, 840, 0, ""),
					new(624, 849, 0, ""),
					new(624, 850, 0, ""),
					new(624, 851, 0, ""),
					new(624, 851, 20, ""),
					new(624, 852, 0, ""),
					new(624, 852, 20, ""),
					new(624, 853, 0, ""),
					new(624, 853, 20, ""),
					new(624, 1033, 0, ""),
					new(640, 937, 0, ""),
					new(640, 941, 0, ""),
					new(642, 843, 20, ""),
					new(642, 844, 20, ""),
					new(642, 845, 20, ""),
					new(642, 846, 20, ""),
					new(672, 1201, 0, ""),
					new(728, 881, 0, ""),
					new(728, 882, 0, ""),
					new(728, 884, 0, ""),
					new(728, 885, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(320, 1058, 0, ""),
					new(320, 1060, 0, ""),
					new(336, 884, 20, ""),
					new(448, 1110, 0, ""),
					new(456, 1129, 0, ""),
					new(528, 969, 0, ""),
					new(528, 972, 0, ""),
					new(568, 1122, 0, ""),
					new(616, 1147, 0, ""),
					new(624, 826, 20, ""),
					new(624, 843, 0, ""),
					new(624, 844, 0, ""),
					new(624, 845, 0, ""),
					new(672, 1202, 0, ""),
					new(672, 1204, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(289, 976, 0, ""),
					new(293, 976, 0, ""),
					new(332, 1240, 0, ""),
					new(337, 872, 0, ""),
					new(337, 872, 20, ""),
					new(341, 872, 0, ""),
					new(341, 872, 20, ""),
					new(405, 1216, 0, ""),
					new(452, 1104, 0, ""),
					new(453, 1104, 0, ""),
					new(474, 840, 0, ""),
					new(554, 1208, 0, ""),
					new(561, 808, 0, ""),
					new(563, 808, 0, ""),
					new(600, 1184, 0, ""),
					new(629, 1032, 0, ""),
					new(632, 816, 20, ""),
					new(640, 816, 20, ""),
					new(640, 1080, 0, ""),
					new(641, 816, 20, ""),
					new(643, 842, 20, ""),
					new(644, 842, 20, ""),
					new(645, 842, 20, ""),
					new(645, 936, 0, ""),
					new(645, 1080, 0, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(320, 1057, 0, ""),
					new(336, 874, 20, ""),
					new(448, 1111, 0, ""),
					new(456, 1133, 0, ""),
					new(560, 969, 0, ""),
					new(568, 1121, 0, ""),
					new(568, 1125, 0, ""),
					new(624, 827, 20, ""),
					new(624, 833, 0, ""),
					new(624, 834, 0, ""),
					new(624, 835, 0, ""),
					new(672, 1205, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(280, 981, 4, ""),
					new(320, 787, 26, ""),
					new(322, 1240, 6, ""),
					new(328, 1060, 4, ""),
					new(328, 1247, 6, ""),
					new(356, 834, 26, ""),
					new(398, 1219, 6, ""),
					new(419, 1034, 6, ""),
					new(424, 1040, 6, ""),
					new(448, 1106, 6, ""),
					new(448, 1128, 6, ""),
					new(452, 963, 6, ""),
					new(456, 1112, 6, ""),
					new(458, 1133, 6, ""),
					new(474, 844, 6, ""),
					new(480, 840, 5, ""),
					new(515, 988, 6, ""),
					new(539, 1008, 6, ""),
					new(554, 1210, 6, ""),
					new(555, 984, 6, ""),
					new(560, 1216, 6, ""),
					new(562, 1012, 6, ""),
					new(565, 966, 6, ""),
					new(572, 1122, 6, ""),
					new(597, 1187, 6, ""),
					new(606, 814, 6, ""),
					new(606, 816, 6, ""),
					new(614, 824, 6, ""),
					new(616, 814, 6, ""),
					new(616, 824, 6, ""),
					new(621, 1146, 6, ""),
					new(627, 845, 6, ""),
					new(632, 1040, 6, ""),
					new(634, 1032, 6, ""),
					new(640, 1087, 6, ""),
					new(646, 938, 6, ""),
					new(648, 808, 6, ""),
					new(648, 824, 6, ""),
					new(648, 1086, 6, ""),
					new(656, 824, 6, ""),
					new(660, 1002, 6, ""),
					new(664, 808, 6, ""),
					new(664, 816, 6, ""),
					new(664, 1008, 6, ""),
					new(679, 1203, 6, ""),
					new(728, 880, 6, ""),
					new(742, 880, 6, ""),
					new(460, 965, 2, ""),
					new(632, 816, 6, ""),
					new(635, 816, 26, ""),
					new(638, 816, 6, ""),
				}),
				new("Candelabra", typeof(Candelabra), 2845, "", new DecorationEntry[]
				{
					new(292, 980, 4, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(282, 989, 0, ""),
					new(320, 1048, 0, ""),
					new(332, 816, 20, ""),
					new(336, 872, 0, ""),
					new(336, 872, 20, ""),
					new(344, 816, 20, ""),
					new(344, 876, 0, ""),
					new(344, 876, 20, ""),
					new(344, 902, 0, ""),
					new(344, 902, 20, ""),
					new(365, 876, 0, ""),
					new(365, 876, 20, ""),
					new(366, 902, 0, ""),
					new(366, 902, 20, ""),
					new(486, 848, 0, ""),
					new(528, 960, 0, ""),
					new(528, 967, 0, ""),
					new(542, 960, 0, ""),
					new(542, 974, 0, ""),
					new(624, 842, 20, ""),
					new(624, 1032, 0, ""),
					new(640, 846, 0, ""),
					new(642, 842, 20, ""),
				}),
				new("Wooden Bench", typeof(WoodenBench), 2860, "", new DecorationEntry[]
				{
					new(312, 794, 20, ""),
					new(312, 795, 20, ""),
					new(312, 796, 20, ""),
					new(312, 797, 20, ""),
				}),
				new("Wooden Bench", typeof(WoodenBench), 2861, "", new DecorationEntry[]
				{
					new(315, 792, 20, ""),
					new(316, 792, 20, ""),
					new(317, 792, 20, ""),
					new(348, 880, 0, ""),
					new(348, 881, 20, ""),
					new(348, 882, 0, ""),
					new(348, 883, 20, ""),
					new(348, 884, 0, ""),
					new(348, 885, 20, ""),
					new(348, 886, 0, ""),
					new(348, 887, 20, ""),
					new(348, 888, 0, ""),
					new(348, 889, 20, ""),
					new(348, 890, 0, ""),
					new(349, 880, 0, ""),
					new(349, 881, 20, ""),
					new(349, 882, 0, ""),
					new(349, 883, 20, ""),
					new(349, 884, 0, ""),
					new(349, 885, 20, ""),
					new(349, 886, 0, ""),
					new(349, 887, 20, ""),
					new(349, 888, 0, ""),
					new(349, 889, 20, ""),
					new(349, 890, 0, ""),
					new(350, 880, 0, ""),
					new(350, 881, 20, ""),
					new(350, 882, 0, ""),
					new(350, 883, 20, ""),
					new(350, 884, 0, ""),
					new(350, 885, 20, ""),
					new(350, 886, 0, ""),
					new(350, 887, 20, ""),
					new(350, 888, 0, ""),
					new(350, 889, 20, ""),
					new(350, 890, 0, ""),
					new(351, 880, 0, ""),
					new(351, 881, 20, ""),
					new(351, 882, 0, ""),
					new(351, 883, 20, ""),
					new(351, 884, 0, ""),
					new(351, 885, 20, ""),
					new(351, 886, 0, ""),
					new(351, 887, 20, ""),
					new(351, 888, 0, ""),
					new(351, 889, 20, ""),
					new(351, 890, 0, ""),
					new(352, 880, 0, ""),
					new(352, 881, 20, ""),
					new(352, 882, 0, ""),
					new(352, 883, 20, ""),
					new(352, 884, 0, ""),
					new(352, 885, 20, ""),
					new(352, 886, 0, ""),
					new(352, 887, 20, ""),
					new(352, 888, 0, ""),
					new(352, 889, 20, ""),
					new(352, 890, 0, ""),
					new(353, 880, 0, ""),
					new(353, 881, 20, ""),
					new(353, 882, 0, ""),
					new(353, 883, 20, ""),
					new(353, 884, 0, ""),
					new(353, 885, 20, ""),
					new(353, 887, 20, ""),
					new(353, 888, 0, ""),
					new(353, 889, 20, ""),
					new(353, 890, 0, ""),
					new(358, 880, 0, ""),
					new(358, 881, 20, ""),
					new(358, 882, 0, ""),
					new(358, 883, 20, ""),
					new(358, 884, 0, ""),
					new(358, 885, 20, ""),
					new(358, 886, 0, ""),
					new(358, 887, 20, ""),
					new(358, 888, 0, ""),
					new(358, 889, 20, ""),
					new(358, 890, 0, ""),
					new(359, 880, 0, ""),
					new(359, 881, 20, ""),
					new(359, 882, 0, ""),
					new(359, 883, 20, ""),
					new(359, 884, 0, ""),
					new(359, 885, 20, ""),
					new(359, 886, 0, ""),
					new(359, 887, 20, ""),
					new(359, 888, 0, ""),
					new(359, 889, 20, ""),
					new(359, 890, 0, ""),
					new(360, 880, 0, ""),
					new(360, 881, 20, ""),
					new(360, 882, 0, ""),
					new(360, 883, 20, ""),
					new(360, 884, 0, ""),
					new(360, 885, 20, ""),
					new(360, 886, 0, ""),
					new(360, 887, 20, ""),
					new(360, 888, 0, ""),
					new(360, 889, 20, ""),
					new(360, 890, 0, ""),
					new(361, 880, 0, ""),
					new(361, 881, 20, ""),
					new(361, 882, 0, ""),
					new(361, 883, 20, ""),
					new(361, 884, 0, ""),
					new(361, 885, 20, ""),
					new(361, 886, 0, ""),
					new(361, 887, 20, ""),
					new(361, 888, 0, ""),
					new(361, 889, 20, ""),
					new(361, 890, 0, ""),
					new(362, 880, 0, ""),
					new(362, 881, 20, ""),
					new(362, 882, 0, ""),
					new(362, 883, 20, ""),
					new(362, 884, 0, ""),
					new(362, 885, 20, ""),
					new(362, 886, 0, ""),
					new(362, 887, 20, ""),
					new(362, 888, 0, ""),
					new(362, 889, 20, ""),
					new(362, 890, 0, ""),
					new(363, 880, 0, ""),
					new(363, 881, 20, ""),
					new(363, 882, 0, ""),
					new(363, 883, 20, ""),
					new(363, 884, 0, ""),
					new(363, 885, 20, ""),
					new(363, 886, 0, ""),
					new(363, 887, 20, ""),
					new(363, 888, 0, ""),
					new(363, 889, 20, ""),
					new(363, 890, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2894, "", new DecorationEntry[]
				{
					new(282, 986, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2895, "", new DecorationEntry[]
				{
					new(475, 849, 0, ""),
					new(481, 849, 0, ""),
					new(483, 849, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2896, "", new DecorationEntry[]
				{
					new(284, 988, 0, ""),
					new(286, 988, 0, ""),
					new(480, 852, 0, ""),
					new(482, 852, 0, ""),
				}),
				new("Chair", typeof(FancyWoodenChairCushion), 2897, "", new DecorationEntry[]
				{
					new(288, 986, 0, ""),
					new(644, 851, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2898, "", new DecorationEntry[]
				{
					new(473, 843, 0, ""),
					new(529, 970, 0, ""),
					new(625, 831, 20, ""),
					new(625, 836, 20, ""),
					new(626, 834, 0, ""),
					new(626, 839, 0, ""),
					new(626, 844, 0, ""),
					new(626, 851, 0, ""),
					new(641, 835, 0, ""),
					new(641, 837, 0, ""),
					new(641, 839, 0, ""),
					new(641, 841, 0, ""),
					new(641, 843, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(291, 978, 0, ""),
					new(319, 786, 20, ""),
					new(355, 833, 20, ""),
					new(631, 818, 20, ""),
					new(640, 818, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2900, "", new DecorationEntry[]
				{
					new(355, 900, 20, ""),
					new(355, 901, 0, ""),
					new(475, 853, 0, ""),
					new(636, 817, 20, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2901, "", new DecorationEntry[]
				{
					new(337, 879, 0, ""),
					new(337, 879, 20, ""),
					new(635, 1034, 0, ""),
					new(645, 831, 20, ""),
					new(645, 835, 0, ""),
					new(645, 836, 20, ""),
					new(645, 837, 0, ""),
					new(645, 839, 0, ""),
					new(645, 841, 0, ""),
					new(645, 843, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2902, "", new DecorationEntry[]
				{
					new(450, 1111, 0, ""),
					new(457, 1134, 0, ""),
					new(514, 990, 0, ""),
					new(553, 1211, 0, ""),
					new(561, 1010, 0, ""),
					new(563, 963, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(329, 1246, 0, ""),
					new(350, 892, 20, ""),
					new(350, 893, 0, ""),
					new(352, 892, 20, ""),
					new(352, 893, 0, ""),
					new(359, 892, 20, ""),
					new(359, 893, 0, ""),
					new(361, 892, 20, ""),
					new(361, 893, 0, ""),
					new(399, 1218, 0, ""),
					new(421, 1033, 0, ""),
					new(534, 972, 0, ""),
					new(536, 972, 0, ""),
					new(537, 1010, 0, ""),
					new(563, 810, 0, ""),
					new(568, 1011, 6, ""),
					new(573, 1121, 0, ""),
					new(598, 1186, 0, ""),
					new(620, 1145, 0, ""),
					new(641, 1086, 0, ""),
					new(647, 937, 0, ""),
					new(661, 1001, 0, ""),
					new(678, 1201, 0, ""),
					new(735, 881, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2904, "", new DecorationEntry[]
				{
					new(449, 1107, 0, ""),
					new(453, 1111, 0, ""),
					new(460, 1134, 0, ""),
					new(556, 1211, 0, ""),
					new(571, 964, 0, ""),
					new(625, 1148, 0, ""),
					new(641, 939, 0, ""),
					new(641, 1083, 0, ""),
					new(649, 1085, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(321, 1056, 0, ""),
					new(323, 1241, 0, ""),
					new(350, 900, 0, ""),
					new(350, 900, 20, ""),
					new(399, 1221, 0, ""),
					new(403, 1217, 0, ""),
					new(420, 1036, 0, ""),
					new(459, 1129, 0, ""),
					new(562, 812, 0, ""),
					new(564, 812, 0, ""),
					new(573, 1124, 0, ""),
					new(598, 1189, 0, ""),
					new(633, 1041, 0, ""),
					new(647, 940, 0, ""),
					new(661, 1004, 0, ""),
					new(678, 1204, 0, ""),
					new(735, 884, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2906, "", new DecorationEntry[]
				{
					new(571, 1011, 6, ""),
					new(664, 1003, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2907, "", new DecorationEntry[]
				{
					new(459, 964, 0, ""),
					new(567, 1008, 6, ""),
				}),
				new("Chair", typeof(BambooChair), 2908, "", new DecorationEntry[]
				{
					new(451, 964, 0, ""),
					new(534, 968, 0, ""),
					new(536, 968, 0, ""),
				}),
				new("Chair", typeof(BambooChair), 2909, "", new DecorationEntry[]
				{
					new(281, 980, 0, ""),
					new(329, 1061, 0, ""),
					new(541, 962, 0, ""),
					new(541, 963, 0, ""),
					new(669, 1003, 0, ""),
				}),
				new("Foot Stool", typeof(FootStool), 2910, "", new DecorationEntry[]
				{
					new(458, 960, 0, ""),
					new(531, 960, 0, ""),
					new(534, 960, 0, ""),
					new(537, 960, 0, ""),
					new(540, 960, 0, ""),
				}),
				new("Bench", typeof(Static), 2911, "", new DecorationEntry[]
				{
					new(425, 1035, 0, ""),
					new(428, 1035, 0, ""),
				}),
				new("Bench", typeof(Static), 2912, "", new DecorationEntry[]
				{
					new(425, 1034, 0, ""),
					new(428, 1034, 0, ""),
				}),
				new("Bench", typeof(Static), 2917, "", new DecorationEntry[]
				{
					new(427, 1036, 0, ""),
					new(667, 1004, 0, ""),
				}),
				new("Bench", typeof(Static), 2918, "", new DecorationEntry[]
				{
					new(426, 1036, 0, ""),
					new(666, 1004, 0, ""),
				}),
				new("Wooden Signpost", typeof(Static), 2968, "", new DecorationEntry[]
				{
					new(618, 1152, 0, ""),
					new(626, 1040, 0, ""),
				}),
				new("Broken Chair", typeof(Static), 3088, "", new DecorationEntry[]
				{
					new(562, 1010, 6, ""),
				}),
				new("Pile Of Wool", typeof(Static), 3576, "", new DecorationEntry[]
				{
					new(566, 1122, 0, ""),
					new(685, 1198, 0, ""),
				}),
				new("Barber Scissors", typeof(Static), 3580, "", new DecorationEntry[]
				{
					new(322, 1048, 6, ""),
				}),
				new("Bloody Bandage", typeof(Static), 3616, "", new DecorationEntry[]
				{
					new(539, 960, 0, ""),
				}),
				new("Clean Bandage", typeof(Static), 3617, "", new DecorationEntry[]
				{
					new(330, 1247, 6, ""),
				}),
				new("Bloody Bandage", typeof(Static), 3618, "", new DecorationEntry[]
				{
					new(329, 1251, 0, ""),
					new(531, 960, 0, ""),
					new(641, 1089, 0, ""),
				}),
				new("Bloody Water", typeof(Static), 3619, "", new DecorationEntry[]
				{
					new(320, 1051, 0, ""),
					new(330, 1250, 0, ""),
					new(533, 960, 0, ""),
					new(539, 961, 0, ""),
				}),
				new("Crystal Ball", typeof(Static), 3630, "Light=Circle150", new DecorationEntry[]
				{
					new(627, 834, 6, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(308, 784, 0, ""),
					new(308, 784, 3, ""),
					new(308, 785, 0, ""),
					new(308, 786, 0, ""),
					new(309, 784, 0, ""),
					new(309, 784, 3, ""),
					new(309, 788, 1, ""),
					new(309, 788, 4, ""),
					new(310, 784, 0, ""),
					new(310, 787, 0, ""),
					new(310, 787, 3, ""),
					new(310, 787, 6, ""),
					new(310, 788, 0, ""),
					new(310, 788, 3, ""),
					new(310, 789, 0, ""),
					new(310, 789, 3, ""),
					new(310, 789, 6, ""),
					new(311, 789, 0, ""),
					new(311, 789, 3, ""),
					new(317, 784, 0, ""),
					new(317, 784, 3, ""),
					new(317, 784, 6, ""),
					new(317, 784, 9, ""),
					new(317, 785, 0, ""),
					new(317, 785, 3, ""),
					new(317, 794, 0, ""),
					new(317, 794, 3, ""),
					new(317, 794, 6, ""),
					new(317, 795, 0, ""),
					new(317, 795, 3, ""),
					new(317, 795, 6, ""),
					new(318, 784, 0, ""),
					new(318, 784, 3, ""),
					new(318, 785, 0, ""),
					new(318, 794, 0, ""),
					new(318, 794, 3, ""),
					new(318, 794, 6, ""),
					new(318, 795, 0, ""),
					new(318, 795, 3, ""),
					new(318, 795, 6, ""),
					new(656, 1002, 0, ""),
					new(656, 1003, 0, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(311, 788, -23, ""),
					new(312, 790, -23, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "ContentType=Mill", new DecorationEntry[]
				{
					new(546, 810, 0, ""),
					new(546, 810, 3, ""),
					new(546, 811, 0, ""),
					new(547, 810, 0, ""),
					new(547, 810, 3, ""),
					new(547, 811, 0, ""),
					new(547, 811, 3, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(323, 795, 0, ""),
					new(323, 795, 3, ""),
					new(323, 796, 0, ""),
					new(324, 795, 0, ""),
					new(324, 796, 0, ""),
					new(324, 796, 3, ""),
					new(416, 1033, 0, ""),
					new(416, 1033, 3, ""),
					new(416, 1034, 0, ""),
					new(448, 961, 0, ""),
					new(448, 961, 3, ""),
					new(448, 962, 0, ""),
					new(544, 812, 0, ""),
					new(544, 812, 3, ""),
					new(544, 813, 0, ""),
					new(544, 813, 3, ""),
					new(544, 813, 6, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(417, 1032, 0, ""),
					new(417, 1032, 3, ""),
					new(449, 960, 0, ""),
					new(449, 960, 3, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(424, 1042, 0, ""),
					new(461, 966, 0, ""),
					new(664, 1014, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(311, 784, 0, ""),
					new(324, 1061, 0, ""),
					new(482, 840, 0, ""),
				}),
				new("Empty Jars", typeof(Static), 3654, "", new DecorationEntry[]
				{
					new(324, 1048, 6, ""),
				}),
				new("Full Jars", typeof(Static), 3659, "", new DecorationEntry[]
				{
					new(536, 973, 6, ""),
				}),
				new("Stump", typeof(Static), 3673, "", new DecorationEntry[]
				{
					new(637, 1155, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(312, 792, 0, ""),
					new(312, 792, 5, ""),
					new(312, 792, 10, ""),
					new(312, 793, 0, ""),
					new(312, 793, 5, ""),
					new(312, 794, 0, ""),
					new(313, 792, 0, ""),
					new(313, 792, 5, ""),
					new(313, 793, 0, ""),
					new(314, 785, 6, ""),
					new(314, 792, 0, ""),
					new(323, 790, 0, ""),
					new(323, 790, 5, ""),
					new(323, 790, 10, ""),
					new(323, 791, 0, ""),
					new(324, 790, 5, ""),
					new(324, 790, 10, ""),
					new(324, 791, 0, ""),
					new(325, 790, 0, ""),
					new(325, 790, 5, ""),
					new(325, 790, 10, ""),
					new(325, 791, 0, ""),
					new(416, 1032, 0, ""),
					new(448, 960, 0, ""),
					new(448, 960, 5, ""),
					new(544, 808, 0, ""),
					new(544, 808, 5, ""),
					new(544, 808, 10, ""),
					new(544, 809, 0, ""),
					new(544, 809, 5, ""),
					new(545, 808, 0, ""),
					new(545, 808, 5, ""),
					new(549, 808, 0, ""),
					new(549, 809, 0, ""),
					new(549, 812, 0, ""),
					new(549, 812, 5, ""),
					new(549, 813, 0, ""),
					new(549, 813, 5, ""),
					new(550, 808, 0, ""),
					new(550, 808, 5, ""),
					new(550, 809, 0, ""),
					new(550, 809, 5, ""),
					new(550, 812, 0, ""),
					new(550, 812, 5, ""),
					new(550, 813, 0, ""),
					new(550, 813, 5, ""),
					new(608, 872, 0, ""),
					new(608, 872, 5, ""),
					new(608, 872, 10, ""),
					new(608, 873, 0, ""),
					new(609, 872, 0, ""),
					new(609, 872, 5, ""),
					new(609, 873, 0, ""),
					new(609, 892, 0, ""),
					new(610, 882, 0, ""),
					new(610, 888, 0, ""),
					new(612, 874, 0, ""),
					new(612, 874, 5, ""),
					new(612, 874, 10, ""),
					new(613, 873, 5, ""),
					new(613, 873, 10, ""),
					new(613, 874, 5, ""),
					new(614, 873, 5, ""),
					new(614, 874, 5, ""),
					new(614, 882, 0, ""),
					new(614, 888, 0, ""),
					new(614, 892, 0, ""),
					new(618, 882, 0, ""),
					new(618, 888, 0, ""),
					new(619, 873, 0, ""),
					new(619, 892, 0, ""),
					new(620, 873, 0, ""),
					new(620, 873, 5, ""),
					new(620, 873, 10, ""),
					new(620, 874, 0, ""),
					new(620, 874, 5, ""),
					new(621, 873, 0, ""),
					new(661, 1008, 0, ""),
					new(730, 888, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(260, 766, 0, ""),
					new(260, 766, 20, ""),
					new(260, 774, 20, ""),
					new(260, 775, 0, ""),
					new(266, 766, 0, ""),
					new(266, 766, 20, ""),
					new(266, 774, 20, ""),
					new(266, 775, 0, ""),
					new(272, 766, 0, ""),
					new(272, 766, 20, ""),
					new(272, 774, 20, ""),
					new(272, 775, 0, ""),
					new(278, 766, 0, ""),
					new(278, 766, 20, ""),
					new(278, 774, 20, ""),
					new(278, 775, 0, ""),
					new(283, 774, 40, ""),
					new(284, 766, 0, ""),
					new(284, 766, 20, ""),
					new(284, 774, 20, ""),
					new(284, 775, 0, ""),
				}),
				new("Metal Chest", typeof(FillableMetalChest), 3708, "ContentType=Inn", new DecorationEntry[]
				{
					new(656, 826, 0, ""),
					new(656, 827, 0, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(448, 962, 3, ""),
				}),
				new("Strong Box", typeof(FillableMetalBox), 3712, "", new DecorationEntry[]
				{
					new(512, 988, 6, ""),
				}),
				new("Drum", typeof(Static), 3740, "", new DecorationEntry[]
				{
					new(627, 821, 20, ""),
				}),
				new("Tambourine", typeof(Static), 3741, "", new DecorationEntry[]
				{
					new(627, 823, 20, ""),
				}),
				new("Standing Harp", typeof(Static), 3761, "", new DecorationEntry[]
				{
					new(625, 818, 20, ""),
				}),
				new("Lap Harp", typeof(Static), 3762, "", new DecorationEntry[]
				{
					new(627, 818, 20, ""),
				}),
				new("Lute", typeof(Static), 3764, "", new DecorationEntry[]
				{
					new(625, 821, 20, ""),
					new(625, 823, 20, ""),
				}),
				new("Music Stand", typeof(Static), 3769, "", new DecorationEntry[]
				{
					new(625, 819, 20, ""),
					new(627, 819, 20, ""),
				}),
				new("Music Stand", typeof(Static), 3772, "", new DecorationEntry[]
				{
					new(624, 821, 20, ""),
					new(624, 823, 20, ""),
				}),
				new("Sheet Music", typeof(Static), 3776, "", new DecorationEntry[]
				{
					new(624, 821, 20, ""),
					new(624, 823, 20, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(281, 984, 4, ""),
					new(604, 1184, 11, ""),
				}),
				new("Skinning Knife", typeof(Static), 3780, "", new DecorationEntry[]
				{
					new(602, 1184, 10, ""),
				}),
				new("Clean Bandage", typeof(Static), 3817, "", new DecorationEntry[]
				{
					new(322, 1048, 6, ""),
					new(323, 1048, 6, ""),
					new(533, 967, 6, ""),
					new(535, 967, 6, ""),
					new(535, 973, 6, ""),
					new(536, 967, 6, ""),
					new(640, 1084, 6, ""),
					new(642, 1087, 6, ""),
					new(642, 1092, 0, ""),
				}),
				new("Bottle", typeof(Static), 3838, "", new DecorationEntry[]
				{
					new(642, 851, 26, ""),
				}),
				new("Bottle", typeof(Static), 3839, "", new DecorationEntry[]
				{
					new(642, 852, 26, ""),
				}),
				new("Bottle", typeof(Static), 3840, "", new DecorationEntry[]
				{
					new(644, 830, 26, ""),
				}),
				new("Bottle", typeof(Static), 3841, "", new DecorationEntry[]
				{
					new(642, 850, 26, ""),
				}),
				new("Bottle", typeof(Static), 3843, "", new DecorationEntry[]
				{
					new(644, 830, 26, ""),
				}),
				new("Black Potion", typeof(Static), 3846, "", new DecorationEntry[]
				{
					new(644, 835, 26, ""),
					new(645, 850, 26, ""),
				}),
				new("Blue Potion", typeof(Static), 3848, "", new DecorationEntry[]
				{
					new(644, 844, 26, ""),
				}),
				new("Green Potion", typeof(Static), 3850, "", new DecorationEntry[]
				{
					new(642, 853, 26, ""),
				}),
				new("Red Potion", typeof(Static), 3851, "", new DecorationEntry[]
				{
					new(329, 1254, 6, ""),
					new(332, 1254, 6, ""),
					new(533, 973, 10, ""),
					new(534, 973, 9, ""),
					new(537, 973, 10, ""),
					new(640, 1083, 6, ""),
					new(640, 1094, 6, ""),
					new(644, 846, 26, ""),
				}),
				new("Yellow Potion", typeof(Static), 3852, "", new DecorationEntry[]
				{
					new(330, 1254, 6, ""),
					new(331, 1254, 6, ""),
					new(640, 1082, 6, ""),
					new(641, 1094, 6, ""),
					new(644, 845, 26, ""),
				}),
				new("Purple Potion", typeof(Static), 3853, "", new DecorationEntry[]
				{
					new(645, 851, 26, ""),
				}),
				new("Empty Bottle", typeof(Static), 3854, "", new DecorationEntry[]
				{
					new(644, 837, 26, ""),
					new(645, 852, 26, ""),
				}),
				new("Arrows", typeof(Static), 3905, "", new DecorationEntry[]
				{
					new(616, 1145, 6, ""),
				}),
				new("Crossbow", typeof(Static), 3919, "", new DecorationEntry[]
				{
					new(620, 1146, 6, ""),
				}),
				new("Crossbow", typeof(Static), 3920, "", new DecorationEntry[]
				{
					new(616, 1149, 6, ""),
				}),
				new("Easel With Canvas", typeof(Static), 3944, "", new DecorationEntry[]
				{
					new(643, 822, 20, ""),
					new(643, 825, 20, ""),
					new(643, 828, 20, ""),
				}),
				new("Batwing", typeof(Static), 3960, "", new DecorationEntry[]
				{
					new(626, 853, 26, ""),
				}),
				new("Daemon Bone", typeof(Static), 3968, "", new DecorationEntry[]
				{
					new(624, 845, 26, ""),
				}),
				new("Ginseng", typeof(Static), 3973, "", new DecorationEntry[]
				{
					new(624, 848, 26, ""),
				}),
				new("Pig Iron", typeof(Static), 3978, "", new DecorationEntry[]
				{
					new(624, 846, 26, ""),
					new(626, 835, 26, ""),
				}),
				new("Nox Crystal", typeof(Static), 3982, "", new DecorationEntry[]
				{
					new(626, 830, 26, ""),
					new(626, 852, 26, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(534, 967, 6, ""),
					new(535, 973, 6, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(313, 784, 0, ""),
					new(313, 784, 7, ""),
					new(313, 785, 0, ""),
					new(313, 785, 7, ""),
					new(314, 784, 0, ""),
					new(314, 784, 7, ""),
					new(314, 785, 0, ""),
					new(314, 786, 0, ""),
					new(314, 787, 0, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(280, 980, 4, ""),
					new(336, 879, 6, ""),
					new(336, 879, 26, ""),
					new(448, 1107, 6, ""),
					new(515, 990, 6, ""),
					new(530, 970, 6, ""),
					new(565, 963, 6, ""),
					new(626, 831, 26, ""),
					new(626, 836, 26, ""),
					new(627, 844, 6, ""),
					new(627, 851, 6, ""),
					new(640, 939, 6, ""),
					new(643, 851, 6, ""),
					new(644, 831, 26, ""),
					new(644, 836, 26, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(291, 979, 4, ""),
					new(319, 787, 26, ""),
					new(321, 1055, 6, ""),
					new(329, 1247, 6, ""),
					new(352, 893, 24, ""),
					new(352, 894, 4, ""),
					new(355, 834, 26, ""),
					new(355, 898, 26, ""),
					new(355, 899, 6, ""),
					new(359, 893, 24, ""),
					new(359, 894, 4, ""),
					new(403, 1216, 6, ""),
					new(459, 1128, 6, ""),
					new(474, 842, 6, ""),
					new(537, 1011, 6, ""),
					new(563, 811, 4, ""),
					new(636, 816, 26, ""),
					new(641, 1087, 6, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(280, 979, 4, ""),
					new(290, 979, 4, ""),
					new(336, 879, 6, ""),
					new(336, 879, 26, ""),
					new(351, 893, 24, ""),
					new(351, 894, 4, ""),
					new(358, 893, 24, ""),
					new(358, 894, 4, ""),
					new(448, 1107, 6, ""),
					new(474, 843, 6, ""),
					new(515, 990, 6, ""),
					new(530, 970, 6, ""),
					new(536, 1011, 6, ""),
					new(564, 810, 4, ""),
					new(565, 963, 6, ""),
					new(626, 831, 26, ""),
					new(626, 836, 26, ""),
					new(627, 844, 6, ""),
					new(627, 851, 6, ""),
					new(640, 939, 6, ""),
					new(643, 851, 6, ""),
					new(644, 831, 26, ""),
					new(644, 836, 26, ""),
				}),
				new("Pen And Ink", typeof(Static), 4032, "", new DecorationEntry[]
				{
					new(318, 787, 26, ""),
					new(320, 1055, 6, ""),
					new(329, 1247, 6, ""),
					new(354, 834, 26, ""),
					new(354, 898, 26, ""),
					new(355, 899, 6, ""),
					new(403, 1216, 6, ""),
					new(458, 965, 2, ""),
					new(459, 1128, 6, ""),
					new(636, 816, 26, ""),
					new(641, 1087, 6, ""),
				}),
				new("Paints And Brush", typeof(Static), 4033, "", new DecorationEntry[]
				{
					new(643, 826, 20, ""),
					new(644, 822, 20, ""),
					new(644, 827, 20, ""),
				}),
				new("Glass Pitcher", typeof(Pitcher), 4086, "", new DecorationEntry[]
				{
					new(643, 842, 4, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4095, "", new DecorationEntry[]
				{
					new(419, 1035, 6, ""),
					new(450, 963, 6, ""),
					new(458, 1135, 6, ""),
				}),
				new("Pewter Mug", typeof(PewterMug), 4096, "", new DecorationEntry[]
				{
					new(336, 878, 26, ""),
					new(336, 880, 6, ""),
					new(420, 1034, 6, ""),
					new(459, 1133, 6, ""),
					new(660, 1003, 6, ""),
					new(662, 1002, 6, ""),
					new(734, 882, 6, ""),
					new(736, 883, 6, ""),
				}),
				new("Wash Basin", typeof(Static), 4104, "", new DecorationEntry[]
				{
					new(534, 967, 6, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4106, "", new DecorationEntry[]
				{
					new(560, 972, 0, ""),
				}),
				new("Archery Butte", typeof(ArcheryButte), 4107, "", new DecorationEntry[]
				{
					new(573, 960, 0, ""),
				}),
				new("Dovetail Saw", typeof(Static), 4136, "", new DecorationEntry[]
				{
					new(561, 966, 6, ""),
				}),
				new("Hammer", typeof(Static), 4138, "", new DecorationEntry[]
				{
					new(563, 966, 6, ""),
				}),
				new("Hammer", typeof(Static), 4139, "", new DecorationEntry[]
				{
					new(562, 1009, 6, ""),
					new(570, 963, 6, ""),
					new(619, 1146, 6, ""),
				}),
				new("Nails", typeof(Static), 4142, "", new DecorationEntry[]
				{
					new(562, 1011, 6, ""),
					new(570, 963, 6, ""),
				}),
				new("Nails", typeof(Static), 4143, "", new DecorationEntry[]
				{
					new(563, 966, 6, ""),
				}),
				new("Saw", typeof(Static), 4148, "", new DecorationEntry[]
				{
					new(570, 965, 6, ""),
					new(622, 1153, 0, ""),
				}),
				new("Saw", typeof(Static), 4149, "", new DecorationEntry[]
				{
					new(616, 1144, 6, ""),
				}),
				new("Sack Of Flour", typeof(Static), 4153, "", new DecorationEntry[]
				{
					new(544, 810, 0, ""),
					new(544, 817, 0, ""),
					new(544, 818, 6, ""),
					new(544, 819, 6, ""),
					new(544, 824, 0, ""),
					new(544, 827, 6, ""),
					new(545, 821, 0, ""),
					new(545, 824, 0, ""),
					new(545, 828, 0, ""),
					new(546, 808, 0, ""),
					new(548, 808, 0, ""),
					new(549, 824, 0, ""),
					new(550, 816, 0, ""),
					new(551, 816, 0, ""),
					new(552, 815, 0, ""),
					new(554, 814, 6, ""),
					new(554, 828, 0, ""),
					new(555, 827, 6, ""),
					new(556, 824, 0, ""),
					new(556, 825, 0, ""),
					new(556, 984, 0, ""),
					new(557, 814, 6, ""),
					new(557, 815, 0, ""),
					new(557, 984, 0, ""),
					new(558, 814, 0, ""),
					new(558, 815, 0, ""),
					new(560, 816, 0, ""),
					new(560, 822, 6, ""),
					new(562, 821, 0, ""),
					new(563, 821, 0, ""),
					new(565, 816, 0, ""),
				}),
				new("Open Sack Of Flour", typeof(Static), 4154, "", new DecorationEntry[]
				{
					new(544, 811, 0, ""),
					new(544, 820, 6, ""),
					new(544, 823, 0, ""),
					new(544, 826, 6, ""),
					new(545, 829, 0, ""),
					new(547, 808, 0, ""),
					new(552, 814, 0, ""),
					new(554, 827, 6, ""),
					new(555, 814, 6, ""),
					new(557, 828, 0, ""),
					new(562, 822, 6, ""),
					new(563, 822, 6, ""),
				}),
				new("Bread Loaf", typeof(Static), 4156, "", new DecorationEntry[]
				{
					new(261, 766, 0, ""),
					new(261, 766, 20, ""),
					new(262, 775, 0, ""),
					new(262, 775, 20, ""),
					new(267, 766, 0, ""),
					new(267, 766, 20, ""),
					new(268, 774, 20, ""),
					new(268, 775, 0, ""),
					new(273, 766, 0, ""),
					new(273, 766, 20, ""),
					new(274, 774, 0, ""),
					new(274, 775, 20, ""),
					new(279, 766, 0, ""),
					new(279, 766, 20, ""),
					new(280, 774, 20, ""),
					new(280, 775, 0, ""),
					new(285, 766, 0, ""),
					new(285, 766, 20, ""),
					new(286, 774, 0, ""),
					new(286, 774, 20, ""),
				}),
				new("Dough", typeof(Static), 4157, "", new DecorationEntry[]
				{
					new(554, 988, 6, ""),
					new(554, 1221, 6, ""),
					new(685, 1202, 6, ""),
				}),
				new("Cookie Mix", typeof(Static), 4159, "", new DecorationEntry[]
				{
					new(555, 987, 6, ""),
					new(556, 1221, 6, ""),
					new(685, 1204, 6, ""),
				}),
				new("Rolling Pin", typeof(Static), 4163, "", new DecorationEntry[]
				{
					new(448, 1117, 6, ""),
					new(552, 1221, 6, ""),
					new(553, 988, 6, ""),
					new(685, 1203, 6, ""),
				}),
				new("Clock", typeof(Clock), 4172, "", new DecorationEntry[]
				{
					new(631, 1032, 6, ""),
					new(632, 1032, 6, ""),
				}),
				new("Clock Frame", typeof(ClockFrame), 4174, "", new DecorationEntry[]
				{
					new(569, 1008, 6, ""),
					new(636, 1032, 6, ""),
				}),
				new("Clock Parts", typeof(ClockParts), 4175, "", new DecorationEntry[]
				{
					new(628, 1035, 8, ""),
				}),
				new("Axle With Gears", typeof(AxleGears), 4177, "", new DecorationEntry[]
				{
					new(627, 1035, 6, ""),
				}),
				new("Axle With Gears", typeof(AxleGears), 4178, "", new DecorationEntry[]
				{
					new(636, 1032, 8, ""),
				}),
				new("Gears", typeof(Gears), 4179, "", new DecorationEntry[]
				{
					new(626, 1035, 6, ""),
					new(637, 1032, 6, ""),
				}),
				new("Sextant", typeof(Static), 4183, "", new DecorationEntry[]
				{
					new(634, 1034, 7, ""),
				}),
				new("Sextant", typeof(Static), 4184, "", new DecorationEntry[]
				{
					new(629, 1035, 6, ""),
				}),
				new("Sextant Parts", typeof(SextantParts), 4185, "", new DecorationEntry[]
				{
					new(625, 1035, 7, ""),
				}),
				new("Sextant Parts", typeof(SextantParts), 4186, "", new DecorationEntry[]
				{
					new(634, 1033, 6, ""),
				}),
				new("Springs", typeof(Springs), 4189, "", new DecorationEntry[]
				{
					new(627, 1035, 8, ""),
					new(635, 1032, 8, ""),
				}),
				new("Potted Tree", typeof(PottedTree), 4552, "", new DecorationEntry[]
				{
					new(532, 967, 0, ""),
					new(532, 973, 0, ""),
				}),
				new("Flowerpot", typeof(PottedPlant), 4554, "", new DecorationEntry[]
				{
					new(328, 1240, 0, ""),
					new(448, 1104, 0, ""),
					new(534, 1008, 0, ""),
					new(538, 967, 0, ""),
					new(538, 973, 0, ""),
					new(552, 1208, 0, ""),
					new(568, 1120, 0, ""),
					new(640, 936, 0, ""),
					new(648, 1080, 0, ""),
					new(665, 1008, 0, ""),
					new(672, 1200, 0, ""),
					new(733, 880, 0, ""),
					new(737, 880, 0, ""),
				}),
				new("Flowerpot", typeof(PottedPlant1), 4555, "", new DecorationEntry[]
				{
					new(451, 1110, 6, ""),
					new(459, 1135, 9, ""),
					new(514, 992, 10, ""),
					new(530, 972, 6, ""),
					new(539, 1011, 9, ""),
					new(648, 939, 10, ""),
				}),
				new("Flowerpot", typeof(PottedPlant2), 4556, "", new DecorationEntry[]
				{
					new(562, 966, 9, ""),
					new(565, 965, 9, ""),
				}),
				new("Bed", typeof(Static), 4562, "", new DecorationEntry[]
				{
					new(485, 840, 0, ""),
				}),
				new("Bed", typeof(Static), 4563, "", new DecorationEntry[]
				{
					new(485, 842, 0, ""),
				}),
				new("Bed", typeof(Static), 4564, "", new DecorationEntry[]
				{
					new(483, 842, 0, ""),
				}),
				new("Bed", typeof(Static), 4565, "", new DecorationEntry[]
				{
					new(483, 840, 0, ""),
				}),
				new("Altar", typeof(AbbatoirAddon), 4630, "", new DecorationEntry[]
				{
					new(311, 786, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5750, 350, 5)", new DecorationEntry[]
				{
					new(311, 786, 0, ""),
				}),
				new("Rock", typeof(Static), 4963, "", new DecorationEntry[]
				{
					new(573, 1307, 0, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(324, 790, 0, ""),
					new(609, 873, 5, ""),
					new(613, 873, 0, ""),
					new(613, 874, 0, ""),
					new(613, 875, 0, ""),
					new(614, 873, 0, ""),
					new(614, 874, 0, ""),
					new(615, 873, 0, ""),
					new(641, 850, 40, ""),
					new(648, 828, 20, ""),
					new(651, 811, 20, ""),
				}),
				new("Water", typeof(Static), 6039, "", new DecorationEntry[]
				{
					new(443, 1043, -5, ""),
					new(463, 1280, -5, ""),
					new(464, 1280, -5, ""),
					new(465, 1280, -5, ""),
					new(466, 1280, -5, ""),
					new(467, 1280, -5, ""),
					new(468, 1280, -5, ""),
					new(469, 1280, 15, ""),
				}),
				new("Water", typeof(Static), 6040, "", new DecorationEntry[]
				{
					new(443, 1044, -5, ""),
				}),
				new("Water", typeof(Static), 6042, "", new DecorationEntry[]
				{
					new(469, 1281, -5, ""),
					new(470, 1281, -5, ""),
				}),
				new("Alchemical Symbol", typeof(Static), 6178, "", new DecorationEntry[]
				{
					new(311, 786, -24, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(314, 784, 0)", new DecorationEntry[]
				{
					new(311, 786, -24, ""),
				}),
				new("Flour Mill", typeof(FlourMillSouthAddon), 6444, "", new DecorationEntry[]
				{
					new(550, 820, -2, ""),
					new(552, 820, -2, ""),
					new(554, 820, -2, ""),
				}),
				new("Feather", typeof(Static), 7121, "", new DecorationEntry[]
				{
					new(565, 961, 6, ""),
					new(570, 962, 6, ""),
				}),
				new("Shaft", typeof(Static), 7124, "", new DecorationEntry[]
				{
					new(564, 966, 6, ""),
					new(570, 964, 6, ""),
				}),
				new("Boards", typeof(Static), 7128, "", new DecorationEntry[]
				{
					new(623, 1155, 0, ""),
				}),
				new("Logs", typeof(Static), 7138, "", new DecorationEntry[]
				{
					new(616, 1152, 0, ""),
					new(617, 1152, 0, ""),
				}),
				new("Quarantine Area: No Pets Permitted Beyond This Point!", typeof(LocalizedSign), 7977, "LabelNumber=1016226", new DecorationEntry[]
				{
					new(315, 786, -18, ""),
				}),
				new("Reactive Armor", typeof(Static), 7981, "", new DecorationEntry[]
				{
					new(624, 841, 0, ""),
					new(640, 848, 0, ""),
				}),
				new("Create Food", typeof(Static), 7983, "", new DecorationEntry[]
				{
					new(627, 839, 6, ""),
				}),
				new("Heal", typeof(Static), 7985, "", new DecorationEntry[]
				{
					new(624, 837, 0, ""),
					new(627, 843, 6, ""),
				}),
				new("Magic Untrap", typeof(Static), 7994, "", new DecorationEntry[]
				{
					new(624, 832, 0, ""),
				}),
				new("Protection", typeof(Static), 7995, "", new DecorationEntry[]
				{
					new(645, 849, 0, ""),
				}),
				new("Strength", typeof(Static), 7996, "", new DecorationEntry[]
				{
					new(625, 848, 0, ""),
				}),
				new("Arch Cure", typeof(Static), 8005, "", new DecorationEntry[]
				{
					new(627, 852, 6, ""),
				}),
				new("Curse", typeof(Static), 8007, "", new DecorationEntry[]
				{
					new(624, 848, 0, ""),
					new(643, 853, 0, ""),
				}),
				new("Dispel Field", typeof(Static), 8014, "", new DecorationEntry[]
				{
					new(627, 850, 6, ""),
				}),
				new("Mark", typeof(Static), 8025, "", new DecorationEntry[]
				{
					new(627, 838, 6, ""),
				}),
				new("Mass Dispel", typeof(Static), 8034, "", new DecorationEntry[]
				{
					new(627, 835, 6, ""),
				}),
				new("Rock", typeof(Static), 13350, "", new DecorationEntry[]
				{
					new(469, 1280, -4, ""),
					new(470, 1281, -4, ""),
				}),
				new("Rock", typeof(Static), 13351, "", new DecorationEntry[]
				{
					new(470, 1280, -5, ""),
				}),
				new("Rock", typeof(Static), 13353, "", new DecorationEntry[]
				{
					new(469, 1281, -4, ""),
				}),
				
				#endregion
			});
		}
	}
}
