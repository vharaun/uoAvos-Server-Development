using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Central { get; } = Register(DecorationTarget.Ilshenar, "Central", new DecorationList[]
			{
				#region Entries
				
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(85, 1464, -28, ""),
					new(86, 1464, -28, ""),
					new(89, 1464, -28, ""),
					new(90, 1464, -28, ""),
					new(93, 1464, -28, ""),
					new(56, 1440, -28, ""),
					new(56, 1464, -28, ""),
					new(58, 1467, -28, ""),
					new(58, 1470, -28, ""),
					new(59, 1464, -28, ""),
					new(61, 1464, -28, ""),
					new(61, 1467, -28, ""),
					new(61, 1470, -28, ""),
					new(64, 1464, -28, ""),
					new(65, 1470, -28, ""),
					new(66, 1464, -28, ""),
					new(68, 1467, -28, ""),
					new(68, 1470, -28, ""),
					new(69, 1464, -28, ""),
					new(80, 1464, -28, ""),
					new(81, 1464, -28, ""),
					new(84, 1464, -28, ""),
				}),
				new("Whip", typeof(Static), 5742, "", new DecorationEntry[]
				{
					new(98, 1528, -22, ""),
					new(103, 1530, -22, ""),
				}),
				new("Bushel", typeof(Basket), 2476, "", new DecorationEntry[]
				{
					new(98, 1532, -28, ""),
				}),
				new("Whip", typeof(Static), 5743, "", new DecorationEntry[]
				{
					new(100, 1528, -22, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(101, 1528, -22, ""),
				}),
				new("Butcher Knife", typeof(Static), 5110, "", new DecorationEntry[]
				{
					new(102, 1528, -23, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(56, 1447, -28, ""),
					new(56, 1467, -28, ""),
					new(56, 1470, -28, ""),
					new(56, 1473, -28, ""),
					new(56, 1476, -28, ""),
					new(65, 1473, -28, ""),
					new(65, 1476, -28, ""),
					new(68, 1473, -28, ""),
					new(68, 1476, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2716, "", new DecorationEntry[]
				{
					new(56, 1448, -28, ""),
					new(56, 1469, -28, ""),
					new(56, 1471, -28, ""),
					new(56, 1475, -28, ""),
					new(56, 1477, -28, ""),
					new(56, 1479, -28, ""),
					new(56, 1481, -28, ""),
					new(65, 1475, -28, ""),
					new(65, 1477, -28, ""),
					new(68, 1475, -28, ""),
					new(68, 1477, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1683, "Facing=NorthCW", new DecorationEntry[]
				{
					new(15, 1315, -28, ""),
					new(15, 1291, -28, ""),
					new(15, 1299, -28, ""),
					new(15, 1307, -28, ""),
					new(55, 1331, -28, ""),
					new(55, 1339, -28, ""),
					new(127, 1523, -28, ""),
					new(127, 1531, -28, ""),
					new(127, 1539, -28, ""),
					new(127, 1547, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1673, "Facing=WestCCW", new DecorationEntry[]
				{
					new(35, 1311, -28, ""),
					new(67, 1311, -28, ""),
					new(67, 1527, -28, ""),
					new(67, 1551, -28, ""),
					new(75, 1311, -28, ""),
					new(75, 1527, -28, ""),
					new(75, 1551, -28, ""),
					new(139, 1527, -28, ""),
					new(147, 1527, -28, ""),
					new(155, 1527, -28, ""),
					new(163, 1527, -28, ""),
					new(171, 1527, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1669, "Facing=WestCW", new DecorationEntry[]
				{
					new(43, 1303, -28, ""),
					new(59, 1263, -28, ""),
					new(67, 1263, -28, ""),
					new(67, 1303, -28, ""),
					new(67, 1543, -28, ""),
					new(75, 1263, -28, ""),
					new(75, 1303, -28, ""),
					new(75, 1543, -28, ""),
					new(147, 1519, -28, ""),
					new(155, 1519, -28, ""),
					new(163, 1519, -28, ""),
					new(171, 1519, -28, ""),
					new(35, 1303, -28, ""),
				}),
				new("Bucket", typeof(Static), 5344, "", new DecorationEntry[]
				{
					new(139, 1563, -23, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1773, "Facing=SouthCW", new DecorationEntry[]
				{
					new(41, 1412, -28, ""),
					new(39, 1356, -28, ""),
					new(51, 1492, -28, ""),
					new(111, 1522, -28, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(24, 1406, -20, ""),
					new(24, 1411, -22, ""),
				}),
				new("Large Battle Axe", typeof(Static), 5115, "", new DecorationEntry[]
				{
					new(25, 1406, -28, ""),
				}),
				new("Candle", typeof(Static), 2575, "", new DecorationEntry[]
				{
					new(31, 1404, -28, ""),
					new(29, 1421, -22, ""),
					new(32, 1406, -28, ""),
					new(32, 1416, -22, ""),
				}),
				new("Plate Helm", typeof(Static), 5138, "", new DecorationEntry[]
				{
					new(24, 1412, -22, ""),
				}),
				new("Platemail Gloves", typeof(Static), 5144, "", new DecorationEntry[]
				{
					new(24, 1413, -22, ""),
				}),
				new("Heavy Crossbow", typeof(Static), 5116, "", new DecorationEntry[]
				{
					new(28, 1417, -22, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(32, 1352, -28, ""),
					new(32, 1352, -22, ""),
					new(32, 1353, -28, ""),
					new(32, 1354, -22, ""),
					new(32, 1357, -28, ""),
					new(33, 1352, -28, ""),
					new(34, 1352, -28, ""),
					new(35, 1352, -28, ""),
					new(36, 1357, -28, ""),
					new(37, 1357, -28, ""),
					new(37, 1357, -22, ""),
					new(32, 1353, -22, ""),
					new(32, 1355, -28, ""),
					new(65, 1352, -28, ""),
					new(67, 1352, -28, ""),
					new(68, 1352, -28, ""),
					new(69, 1352, -28, ""),
					new(32, 1354, -28, ""),
					new(34, 1355, -28, ""),
					new(64, 1352, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1775, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(39, 1355, -28, ""),
					new(41, 1411, -28, ""),
					new(51, 1491, -28, ""),
					new(111, 1521, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1769, "Facing=WestCCW", new DecorationEntry[]
				{
					new(35, 1451, -28, ""),
					new(59, 1499, -28, ""),
					new(115, 1499, -28, ""),
					new(51, 1349, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1771, "Facing=EastCW", new DecorationEntry[]
				{
					new(36, 1451, -28, ""),
					new(60, 1499, -28, ""),
					new(116, 1499, -28, ""),
					new(52, 1349, -28, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(36, 1352, -27, ""),
					new(36, 1352, -30, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(36, 1353, -30, ""),
					new(32, 1356, -30, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(51, 1385, -28, ""),
					new(59, 1483, -28, ""),
					new(83, 1483, -28, ""),
					new(107, 1487, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1767, "Facing=EastCCW", new DecorationEntry[]
				{
					new(52, 1385, -28, ""),
					new(60, 1483, -28, ""),
					new(84, 1483, -28, ""),
					new(108, 1487, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1677, "Facing=SouthCW", new DecorationEntry[]
				{
					new(55, 1515, -28, ""),
					new(55, 1523, -28, ""),
					new(95, 1291, -28, ""),
					new(95, 1299, -28, ""),
					new(95, 1307, -28, ""),
					new(95, 1315, -28, ""),
					new(111, 1539, -28, ""),
					new(111, 1547, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1779, "Facing=NorthCW", new DecorationEntry[]
				{
					new(63, 1292, -28, ""),
					new(63, 1355, -28, ""),
					new(57, 1411, -28, ""),
					new(127, 1563, -28, ""),
					new(55, 1443, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1777, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(63, 1293, -28, ""),
					new(63, 1356, -28, ""),
					new(57, 1412, -28, ""),
					new(127, 1564, -28, ""),
					new(55, 1444, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Hue=0x8AB;Facing=WestCW", new DecorationEntry[]
				{
					new(83, 1384, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Hue=0x8AB;Facing=EastCCW", new DecorationEntry[]
				{
					new(84, 1384, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1657, "Hue=0x58B;Facing=WestCCW", new DecorationEntry[]
				{
					new(83, 1436, -28, ""),
					new(99, 1421, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1659, "Hue=0x58B;Facing=EastCW", new DecorationEntry[]
				{
					new(84, 1436, -28, ""),
					new(100, 1421, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1667, "Hue=0x58B;Facing=NorthCW", new DecorationEntry[]
				{
					new(89, 1411, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1665, "Hue=0x58B;Facing=SouthCCW", new DecorationEntry[]
				{
					new(89, 1412, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(56, 1446, -28, ""),
					new(56, 1468, -28, ""),
					new(56, 1472, -28, ""),
					new(56, 1474, -28, ""),
					new(56, 1478, -28, ""),
					new(56, 1480, -28, ""),
					new(56, 1482, -28, ""),
					new(65, 1474, -28, ""),
					new(68, 1474, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2712, "", new DecorationEntry[]
				{
					new(57, 1440, -28, ""),
					new(57, 1464, -28, ""),
					new(59, 1467, -28, ""),
					new(59, 1470, -28, ""),
					new(60, 1464, -28, ""),
					new(62, 1464, -28, ""),
					new(62, 1467, -28, ""),
					new(65, 1464, -28, ""),
					new(66, 1467, -28, ""),
					new(66, 1470, -28, ""),
					new(67, 1464, -28, ""),
					new(69, 1467, -28, ""),
					new(69, 1470, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(58, 1440, -28, ""),
					new(58, 1464, -28, ""),
					new(60, 1467, -28, ""),
					new(60, 1470, -28, ""),
					new(63, 1464, -28, ""),
					new(70, 1440, -28, ""),
					new(67, 1467, -28, ""),
					new(67, 1470, -28, ""),
					new(68, 1464, -28, ""),
				}),
				new("Cleaver", typeof(Static), 3778, "", new DecorationEntry[]
				{
					new(10, 1368, -22, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(64, 1353, -28, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(64, 1354, -28, ""),
					new(64, 1354, -25, ""),
					new(64, 1354, -22, ""),
				}),
				
				#endregion
			});
		}
	}
}
