using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] WispDungeon { get; } = Register(DecorationTarget.Ilshenar, "WispDungeon", new DecorationList[]
			{
				#region Entries
				
				new("Ankh", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(286, 1013, 5, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW;Hue=0x451", new DecorationEntry[]
				{
					new(659, 1535, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW;Hue=0x451", new DecorationEntry[]
				{
					new(660, 1535, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1657, "Facing=WestCCW;Hue=0x482", new DecorationEntry[]
				{
					new(699, 1527, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1659, "Facing=EastCW;Hue=0x482", new DecorationEntry[]
				{
					new(700, 1527, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1665, "Facing=SouthCCW;Hue=0x482", new DecorationEntry[]
				{
					new(703, 1572, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1667, "Facing=NorthCW;Hue=0x482", new DecorationEntry[]
				{
					new(703, 1571, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(659, 1521, -28, ""),
					new(661, 1521, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2712, "", new DecorationEntry[]
				{
					new(660, 1521, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(657, 1525, -28, ""),
					new(657, 1527, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(657, 1524, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(658, 1521, -28, ""),
					new(662, 1521, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2716, "", new DecorationEntry[]
				{
					new(657, 1523, -28, ""),
					new(657, 1526, -28, ""),
				}),
				new("Wisp", typeof(LocalizedStatic), 8448, "LabelNumber=1016453", new DecorationEntry[]
				{
					new(689, 1566, -15, ""),
					new(689, 1570, -15, ""),
					new(691, 1513, -15, ""),
					new(694, 1513, -15, ""),
					new(697, 1513, -15, ""),
					new(700, 1513, -15, ""),
					new(657, 1501, -15, ""),
					new(657, 1506, -15, ""),
					new(661, 1497, -15, ""),
					new(649, 1297, -14, ""),
					new(649, 1300, -19, ""),
					new(654, 1297, -14, ""),
					new(654, 1300, -21, ""),
				}),
				new("Wisp", typeof(LocalizedStatic), 8448, "LabelNumber=1016454", new DecorationEntry[]
				{
					new(718, 1553, -18, ""),
					new(719, 1553, -10, ""),
					new(720, 1553, -18, ""),
				}),
				new("Wisp", typeof(LocalizedStatic), 8448, "Hue=0x8AB;LabelNumber=1016453", new DecorationEntry[]
				{
					new(641, 1531, -16, ""),
					new(666, 1497, -15, ""),
				}),
				new("Stone Wall", typeof(Static), 200, "Hue=0x964", new DecorationEntry[]
				{
					new(836, 1471, -28, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor1), 246, "Facing=NorthCW;Hue=0x96F", new DecorationEntry[]
				{
					new(752, 1549, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW;Hue=0x89D", new DecorationEntry[]
				{
					new(851, 1559, -28, ""),
					new(907, 1464, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW;Hue=0x89D", new DecorationEntry[]
				{
					new(908, 1464, -28, ""),
					new(852, 1559, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW;Hue=0x89D", new DecorationEntry[]
				{
					new(824, 1475, -28, ""),
					new(872, 1476, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW;Hue=0x901", new DecorationEntry[]
				{
					new(872, 1508, 2, ""),
					new(879, 1532, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW;Hue=0x89E", new DecorationEntry[]
				{
					new(848, 1476, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW;Hue=0x89D", new DecorationEntry[]
				{
					new(872, 1475, -28, ""),
					new(824, 1474, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW;Hue=0x901", new DecorationEntry[]
				{
					new(872, 1507, 2, ""),
					new(879, 1531, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW;Hue=0x89E", new DecorationEntry[]
				{
					new(848, 1475, -28, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(817, 1467, -28, ""),
					new(818, 1468, -25, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(858, 1561, -28, ""),
					new(859, 1561, -28, ""),
					new(893, 1497, 2, ""),
					new(898, 1553, -28, ""),
					new(899, 1465, -28, ""),
					new(901, 1553, -28, ""),
					new(905, 1497, 2, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "Hue=0x454", new DecorationEntry[]
				{
					new(776, 1476, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "Hue=0x455", new DecorationEntry[]
				{
					new(837, 1465, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "Hue=0x4E4", new DecorationEntry[]
				{
					new(761, 1537, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "Hue=0x66D", new DecorationEntry[]
				{
					new(760, 1537, -28, ""),
					new(762, 1537, -28, ""),
					new(776, 1483, -28, ""),
					new(836, 1465, -28, ""),
				}),
				new("Eggs", typeof(EasterEggs), 2485, "", new DecorationEntry[]
				{
					new(964, 1547, -29, ""),
				}),
				new("Wall Torch", typeof(Static), 2565, "", new DecorationEntry[]
				{
					new(817, 1478, -14, ""),
					new(834, 1467, -14, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "Hue=0x717", new DecorationEntry[]
				{
					new(958, 1496, -28, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "Hue=0x718", new DecorationEntry[]
				{
					new(923, 1553, -28, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "Hue=0x717", new DecorationEntry[]
				{
					new(953, 1502, -28, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "Hue=0x718", new DecorationEntry[]
				{
					new(920, 1558, -28, ""),
					new(920, 1562, -28, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(817, 1470, -25, ""),
					new(817, 1473, -25, ""),
					new(817, 1474, -22, ""),
					new(817, 1475, -25, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(873, 1521, -30, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "Hue=0x4E4", new DecorationEntry[]
				{
					new(777, 1575, -28, ""),
					new(784, 1517, -28, ""),
					new(784, 1578, -28, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "Hue=0x66D", new DecorationEntry[]
				{
					new(777, 1574, -28, ""),
					new(777, 1576, -28, ""),
					new(784, 1521, -28, ""),
					new(784, 1574, -28, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(827, 1465, -28, ""),
					new(828, 1465, -28, ""),
					new(829, 1465, -28, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(817, 1476, -28, ""),
					new(817, 1477, -28, ""),
					new(920, 1565, -28, ""),
					new(929, 1571, -28, ""),
					new(953, 1478, -28, ""),
					new(953, 1508, -28, ""),
					new(953, 1532, -28, ""),
					new(953, 1539, -28, ""),
					new(961, 1549, -29, ""),
					new(961, 1558, -28, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(926, 1553, -27, ""),
					new(955, 1496, -28, ""),
					new(955, 1527, -27, ""),
					new(958, 1552, -28, ""),
					new(961, 1464, -28, ""),
					new(972, 1480, -30, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(865, 1539, -28, ""),
					new(873, 1469, -28, ""),
					new(873, 1577, -28, ""),
					new(873, 1579, -28, ""),
					new(889, 1500, 2, ""),
					new(889, 1517, 2, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "Hue=0x454", new DecorationEntry[]
				{
					new(772, 1482, -28, ""),
					new(779, 1482, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "Hue=0x466", new DecorationEntry[]
				{
					new(834, 1468, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "Hue=0x4E4", new DecorationEntry[]
				{
					new(753, 1544, -28, ""),
					new(777, 1520, -28, ""),
					new(777, 1522, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "Hue=0x66D", new DecorationEntry[]
				{
					new(753, 1545, -28, ""),
					new(772, 1478, -28, ""),
					new(777, 1519, -28, ""),
					new(777, 1521, -28, ""),
					new(777, 1523, -28, ""),
					new(779, 1478, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "Hue=0x89F", new DecorationEntry[]
				{
					new(834, 1467, -28, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "Hue=0x8AB", new DecorationEntry[]
				{
					new(834, 1469, -28, ""),
				}),
				new("Keg", typeof(Static), 3711, "", new DecorationEntry[]
				{
					new(974, 1484, -28, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(874, 1524, -22, ""),
				}),
				new("Gravestone", typeof(LocalizedStatic), 3796, "LabelNumber=1016086;Hue=0x835", new DecorationEntry[]
				{
					new(877, 1561, -23, ""),
				}),
				new("Gravestone", typeof(LocalizedStatic), 3796, "LabelNumber=1016423;Hue=0x835", new DecorationEntry[]
				{
					new(883, 1555, -23, ""),
				}),
				new("Gravestone", typeof(LocalizedStatic), 3797, "LabelNumber=1016150;Hue=0x835", new DecorationEntry[]
				{
					new(875, 1563, -23, ""),
				}),
				new("Gravestone", typeof(LocalizedStatic), 3797, "LabelNumber=1016381;Hue=0x835", new DecorationEntry[]
				{
					new(879, 1559, -23, ""),
				}),
				new("Gravestone", typeof(LocalizedStatic), 3797, "LabelNumber=1016210;Hue=0x835", new DecorationEntry[]
				{
					new(881, 1557, -23, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(821, 1475, -28, ""),
					new(821, 1475, -22, ""),
					new(821, 1475, -16, ""),
					new(821, 1476, -22, ""),
					new(822, 1475, -22, ""),
					new(822, 1475, -16, ""),
					new(822, 1476, -22, ""),
					new(968, 1484, -28, ""),
				}),
				new("Tapestry", typeof(Static), 4067, "", new DecorationEntry[]
				{
					new(825, 1488, -28, ""),
				}),
				new("Tapestry", typeof(Static), 4068, "", new DecorationEntry[]
				{
					new(825, 1486, -28, ""),
				}),
				new("Gravestone", typeof(LocalizedStatic), 4468, "LabelNumber=1016508;Hue=0x963", new DecorationEntry[]
				{
					new(898, 1508, 2, ""),
					new(901, 1508, 2, ""),
				}),
				new("Statue", typeof(LocalizedStatic), 4647, "LabelNumber=1016466", new DecorationEntry[]
				{
					new(874, 1558, -8, ""),
				}),
				new("Statue", typeof(LocalizedStatic), 4647, "LabelNumber=1016467", new DecorationEntry[]
				{
					new(878, 1554, -8, ""),
				}),
				new("Melted Wax", typeof(MeltedWax), 4650, "", new DecorationEntry[]
				{
					new(873, 1570, -17, ""),
					new(879, 1570, -23, ""),
					new(890, 1570, -28, ""),
				}),
				new("Melted Wax", typeof(MeltedWax), 4651, "", new DecorationEntry[]
				{
					new(893, 1573, -28, ""),
				}),
				new("Melted Wax", typeof(MeltedWax), 4652, "", new DecorationEntry[]
				{
					new(875, 1570, -24, ""),
					new(879, 1573, -26, ""),
					new(880, 1572, -23, ""),
					new(893, 1570, -28, ""),
				}),
				new("Melted Wax", typeof(MeltedWax), 4653, "", new DecorationEntry[]
				{
					new(878, 1572, -23, ""),
				}),
				new("Melted Wax", typeof(MeltedWax), 4654, "", new DecorationEntry[]
				{
					new(873, 1572, -17, ""),
					new(874, 1570, -24, ""),
					new(878, 1570, -24, ""),
					new(880, 1571, -24, ""),
					new(890, 1573, -28, ""),
				}),
				new("Bust", typeof(Static), 4810, "", new DecorationEntry[]
				{
					new(874, 1554, -2, ""),
				}),
				new("Statue", typeof(LocalizedStatic), 5018, "LabelNumber=1016468", new DecorationEntry[]
				{
					new(876, 1556, -6, ""),
				}),
				new("Earrings", typeof(Static), 7943, "", new DecorationEntry[]
				{
					new(858, 1572, -22, ""),
				}),
				new("Necklace", typeof(Static), 7944, "", new DecorationEntry[]
				{
					new(849, 1566, -22, ""),
					new(849, 1566, -21, ""),
					new(849, 1567, -22, ""),
					new(849, 1568, -22, ""),
				}),
				new("Necklace", typeof(Static), 7944, "Hue=0x455", new DecorationEntry[]
				{
					new(850, 1570, -22, ""),
					new(860, 1570, -28, ""),
				}),
				new("Silver Necklace", typeof(Static), 7946, "", new DecorationEntry[]
				{
					new(850, 1565, -21, ""),
					new(855, 1572, -22, ""),
					new(858, 1573, -22, ""),
				}),
				new("Wisp", typeof(LocalizedStatic), 8448, "LabelNumber=1016452;Hue=0x964", new DecorationEntry[]
				{
					new(890, 1498, 14, ""),
					new(890, 1515, 14, ""),
					new(896, 1504, 14, ""),
					new(896, 1511, 14, ""),
					new(903, 1504, 14, ""),
					new(903, 1511, 14, ""),
					new(907, 1498, 14, ""),
					new(907, 1515, 14, ""),
				}),
				new("Wisp", typeof(LocalizedStatic), 8448, "LabelNumber=1016452;Hue=0x966", new DecorationEntry[]
				{
					new(849, 1562, -16, ""),
					new(849, 1572, -16, ""),
					new(861, 1562, -16, ""),
					new(861, 1572, -16, ""),
					new(873, 1567, -16, ""),
					new(873, 1575, -16, ""),
					new(873, 1582, -16, ""),
					new(880, 1582, -16, ""),
					new(888, 1553, -16, ""),
					new(888, 1582, -16, ""),
					new(889, 1555, -16, ""),
					new(889, 1557, -16, ""),
					new(889, 1559, -16, ""),
					new(894, 1554, -16, ""),
					new(894, 1556, -16, ""),
					new(894, 1558, -16, ""),
					new(895, 1553, -16, ""),
					new(896, 1582, -16, ""),
					new(902, 1559, -16, ""),
					new(902, 1567, -16, ""),
					new(902, 1575, -16, ""),
				}),
				new("No Draw", typeof(Blocker), 8612, "", new DecorationEntry[]
				{
					new(777, 1546, -28, ""),
					new(777, 1549, -28, ""),
					new(778, 1540, -28, ""),
					new(778, 1542, -28, ""),
					new(778, 1553, -28, ""),
					new(778, 1555, -28, ""),
					new(780, 1540, -28, ""),
					new(780, 1542, -28, ""),
					new(780, 1545, -28, ""),
					new(780, 1547, -28, ""),
					new(780, 1549, -28, ""),
					new(780, 1551, -28, ""),
					new(780, 1553, -28, ""),
					new(780, 1555, -28, ""),
					new(782, 1537, -28, ""),
					new(782, 1539, -28, ""),
					new(782, 1541, -28, ""),
					new(782, 1543, -28, ""),
					new(782, 1545, -28, ""),
					new(782, 1547, -28, ""),
					new(782, 1549, -28, ""),
					new(782, 1551, -28, ""),
					new(782, 1553, -28, ""),
					new(782, 1555, -28, ""),
					new(784, 1537, -28, ""),
					new(784, 1539, -28, ""),
					new(784, 1541, -28, ""),
					new(784, 1543, -28, ""),
					new(784, 1545, -28, ""),
					new(784, 1547, -28, ""),
					new(784, 1549, -28, ""),
					new(784, 1551, -28, ""),
					new(784, 1553, -28, ""),
					new(784, 1555, -28, ""),
					new(786, 1537, -28, ""),
					new(786, 1539, -28, ""),
					new(786, 1541, -28, ""),
					new(786, 1543, -28, ""),
					new(786, 1545, -28, ""),
					new(786, 1547, -28, ""),
					new(786, 1549, -28, ""),
					new(786, 1551, -28, ""),
					new(786, 1553, -28, ""),
					new(786, 1555, -28, ""),
					new(788, 1537, -28, ""),
					new(788, 1539, -28, ""),
					new(788, 1541, -28, ""),
					new(788, 1543, -28, ""),
					new(788, 1545, -28, ""),
					new(788, 1547, -28, ""),
					new(788, 1551, -28, ""),
					new(788, 1553, -28, ""),
					new(788, 1555, -28, ""),
					new(788, 1557, -28, ""),
					new(790, 1545, -28, ""),
					new(790, 1547, -28, ""),
					new(790, 1551, -28, ""),
					new(790, 1553, -28, ""),
					new(790, 1555, -28, ""),
					new(790, 1557, -28, ""),
					new(791, 1551, -28, ""),
					new(844, 1433, -28, ""),
					new(844, 1438, -28, ""),
					new(845, 1433, -28, ""),
					new(845, 1438, -28, ""),
					new(846, 1433, -28, ""),
					new(846, 1438, -28, ""),
					new(847, 1433, -28, ""),
					new(847, 1438, -28, ""),
					new(848, 1432, -28, ""),
					new(848, 1433, -28, ""),
					new(848, 1438, -28, ""),
					new(848, 1439, -28, ""),
				}),
				
				#endregion
			});
		}
	}
}
