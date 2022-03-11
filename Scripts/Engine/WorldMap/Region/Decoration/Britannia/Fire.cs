using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Fire { get; } = Register(DecorationTarget.Britannia, "Fire", new DecorationList[]
			{
				#region Entries
				
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5690, 1352, -26)", new DecorationEntry[]
				{
					new(5691, 1348, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5691, 1348, 0)", new DecorationEntry[]
				{
					new(5690, 1352, -26, ""),
				}),
				new("Bellows", typeof(Static), 6534, "Light=Circle300", new DecorationEntry[]
				{
					new(5640, 1410, 0, ""),
				}),
				new("Forge", typeof(Static), 6538, "Light=Circle300", new DecorationEntry[]
				{
					new(5640, 1411, 0, ""),
				}),
				new("Forge", typeof(Static), 6550, "Light=Circle300", new DecorationEntry[]
				{
					new(5640, 1412, 0, ""),
				}),
				new("Bellows", typeof(Static), 6546, "Light=Circle300", new DecorationEntry[]
				{
					new(5640, 1413, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5675, 1433, 0, ""),
					new(5647, 1434, 0, ""),
					new(5640, 1433, 0, ""),
					new(5640, 1435, 0, ""),
					new(5640, 1437, 0, ""),
					new(5650, 1438, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2272, "", new DecorationEntry[]
				{
					new(5690, 1328, -1, ""),
					new(5717, 1410, 42, ""),
					new(5718, 1409, 42, ""),
					new(5718, 1410, 40, ""),
				}),
				new("Fire Column", typeof(FlameSpurtTrap), 1, "", new DecorationEntry[]
				{
					new(5688, 1353, -26, ""),
					new(5689, 1354, -26, ""),
					new(5690, 1354, -26, ""),
					new(5691, 1354, -26, ""),
					new(5692, 1353, -26, ""),
					new(5692, 1352, -26, ""),
					new(5689, 1350, -26, ""),
					new(5691, 1350, -26, ""),
					new(5692, 1351, -26, ""),
					new(5688, 1351, -26, ""),
					new(5688, 1352, -26, ""),
					new(5690, 1350, -26, ""),
				}),
				new("Pentagram", typeof(PentagramAddon), 4074, "", new DecorationEntry[]
				{
					new(5690, 1352, -26, ""),
					new(5691, 1348, 0, ""),
				}),
				new("Glowing Rune", typeof(Static), 3688, "", new DecorationEntry[]
				{
					new(5686, 1432, 22, ""),
				}),
				new("Boulder", typeof(Static), 4962, "", new DecorationEntry[]
				{
					new(5696, 1388, -1, ""),
					new(5694, 1388, 4, ""),
					new(5695, 1388, 4, ""),
					new(5695, 1387, 0, ""),
					new(5694, 1387, 2, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(5645, 1400, 22, ""),
					new(5653, 1400, 22, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(5648, 1400, 0, ""),
				}),
				new("Keg", typeof(Keg), 3711, "", new DecorationEntry[]
				{
					new(5720, 1386, 2, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5675, 1436, 0, ""),
					new(5728, 1391, -1, ""),
					new(5673, 1434, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1733, "Facing=WestCW", new DecorationEntry[]
				{
					new(5835, 1487, -1, ""),
					new(5835, 1431, 0, ""),
					new(5643, 1408, 0, ""),
					new(5651, 1412, 0, ""),
					new(5643, 1416, 22, ""),
					new(5851, 1431, 0, ""),
					new(5723, 1295, 0, ""),
					new(5731, 1383, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5672, 1434, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5723, 1384, -2, ""),
					new(5673, 1433, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1958, "", new DecorationEntry[]
				{
					new(5786, 1337, -5, ""),
					new(5787, 1337, -5, ""),
					new(5788, 1337, -5, ""),
				}),
				new("Stone", typeof(Static), 1955, "", new DecorationEntry[]
				{
					new(5786, 1338, -5, ""),
					new(5787, 1338, -5, ""),
					new(5788, 1338, -5, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1741, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5647, 1443, 0, ""),
					new(5642, 1401, 22, ""),
					new(5655, 1402, 0, ""),
					new(5647, 1420, 0, ""),
					new(5644, 1409, 22, ""),
					new(5655, 1363, -1, ""),
					new(5679, 1434, 0, ""),
					new(5679, 1444, 0, ""),
					new(5687, 1441, -1, ""),
					new(5855, 1475, 0, ""),
					new(5855, 1427, 0, ""),
					new(5671, 1315, 0, ""),
				}),
				new("Rock", typeof(Static), 6003, "", new DecorationEntry[]
				{
					new(5711, 1337, 1, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5642, 1432, 0, ""),
				}),
				new("Vines", typeof(Static), 3313, "", new DecorationEntry[]
				{
					new(5854, 1457, 0, ""),
				}),
				new("Rock", typeof(Static), 6002, "", new DecorationEntry[]
				{
					new(5688, 1328, 1, ""),
					new(5712, 1337, -3, ""),
				}),
				new("Rock", typeof(Static), 6008, "", new DecorationEntry[]
				{
					new(5710, 1336, 2, ""),
				}),
				new("Rock", typeof(Static), 6005, "", new DecorationEntry[]
				{
					new(5711, 1336, -1, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1745, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(5647, 1410, 0, ""),
					new(5647, 1402, 0, ""),
				}),
				new("Rock", typeof(Static), 6004, "", new DecorationEntry[]
				{
					new(5712, 1338, -2, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1737, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5691, 1343, 0, ""),
					new(5651, 1439, 0, ""),
					new(5650, 1416, 22, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(5645, 1413, 22, ""),
					new(5643, 1415, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5640, 1403, 0, ""),
					new(5640, 1404, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1739, "Facing=EastCW", new DecorationEntry[]
				{
					new(5651, 1416, 22, ""),
				}),
				new("Forge", typeof(Static), 6538, "Light=Circle300", new DecorationEntry[]
				{
					new(5640, 1411, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
