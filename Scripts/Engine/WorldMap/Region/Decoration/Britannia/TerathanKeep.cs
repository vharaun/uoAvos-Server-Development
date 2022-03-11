using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Terathankeep { get; } = Register(DecorationTarget.Britannia, "Terathan Keep", new DecorationList[]
			{
				#region Entries
				
				new("Tightrope", typeof(Static), 10000, "", new DecorationEntry[]
				{
					new(5158, 1708, 0, ""),
					new(5153, 1708, 0, ""),
					new(5151, 1708, 0, ""),
					new(5156, 1708, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(5349, 1560, 0, ""),
					new(5337, 1560, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5363, 1708, -75, ""),
				}),
				new("Iron Fence", typeof(Static), 2081, "", new DecorationEntry[]
				{
					new(5432, 3152, -55, ""),
					new(5432, 3153, -55, ""),
					new(5432, 3154, -55, ""),
					new(5432, 3155, -55, ""),
					new(5437, 3153, -55, ""),
					new(5437, 3154, -55, ""),
					new(5437, 3152, -55, ""),
				}),
				new("Iron Fence", typeof(Static), 2083, "", new DecorationEntry[]
				{
					new(5433, 3155, -55, ""),
					new(5434, 3155, -55, ""),
					new(5435, 3155, -55, ""),
					new(5436, 3155, -55, ""),
				}),
				new("Iron Fence", typeof(Static), 2121, "", new DecorationEntry[]
				{
					new(5454, 3155, -53, ""),
					new(5454, 3153, -55, ""),
					new(5454, 3152, -55, ""),
					new(5458, 3153, -55, ""),
					new(5458, 3154, -55, ""),
					new(5458, 3152, -55, ""),
					new(5454, 3154, -53, ""),
					new(5477, 3136, -60, ""),
				}),
				new("Iron Fence", typeof(Static), 2123, "", new DecorationEntry[]
				{
					new(5455, 3151, -55, ""),
					new(5456, 3151, -55, ""),
					new(5458, 3151, -55, ""),
					new(5457, 3155, -55, ""),
					new(5456, 3155, -55, ""),
					new(5455, 3155, -55, ""),
					new(5434, 3151, -55, ""),
					new(5433, 3151, -55, ""),
					new(5472, 3141, -60, ""),
					new(5437, 3151, -55, ""),
					new(5436, 3151, -55, ""),
					new(5435, 3151, -55, ""),
					new(5457, 3151, -55, ""),
				}),
				new("Iron Fence", typeof(Static), 2082, "", new DecorationEntry[]
				{
					new(5437, 3155, -55, ""),
				}),
				new("Iron Fence", typeof(Static), 2122, "", new DecorationEntry[]
				{
					new(5476, 3138, -60, ""),
					new(5475, 3139, -60, ""),
					new(5474, 3140, -60, ""),
					new(5473, 3141, -60, ""),
					new(5458, 3155, -55, ""),
					new(5477, 3137, -60, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5337, 1549, 0, ""),
					new(5349, 1551, 0, ""),
				}),
				new("Brambles", typeof(Static), 3391, "", new DecorationEntry[]
				{
					new(5484, 3146, -45, ""),
					new(5484, 3146, -51, ""),
					new(5478, 3148, -45, ""),
				}),
				new("Small Palm", typeof(Static), 3229, "", new DecorationEntry[]
				{
					new(5460, 3162, -45, ""),
				}),
				new("Stalagmites", typeof(Static), 2273, "", new DecorationEntry[]
				{
					new(5367, 1774, -118, ""),
				}),
				new("Lever", typeof(Static), 4243, "", new DecorationEntry[]
				{
					new(5143, 1703, 10, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1659, "Facing=EastCW", new DecorationEntry[]
				{
					new(5343, 1571, 0, ""),
					new(5343, 1557, 0, ""),
					new(5335, 1543, 0, ""),
					new(5355, 1544, 0, ""),
					new(5344, 1577, 0, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1771, "Facing=EastCW", new DecorationEntry[]
				{
					new(5303, 1568, 0, ""),
					new(5300, 1556, 0, ""),
					new(5309, 1556, 0, ""),
					new(5294, 1564, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1667, "Facing=NorthCW", new DecorationEntry[]
				{
					new(5333, 1556, 0, ""),
					new(5333, 1547, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5353, 1715, -85, ""),
					new(5242, 1602, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5356, 1556, 0, ""),
					new(5356, 1548, 0, ""),
					new(5242, 1603, 0, ""),
				}),
				new("Lever", typeof(Static), 4236, "", new DecorationEntry[]
				{
					new(5251, 1603, 7, ""),
				}),
				new("Egg Case Web", typeof(Static), 4312, "", new DecorationEntry[]
				{
					new(5302, 1552, 0, ""),
					new(5300, 1548, 0, ""),
				}),
				new("Lever", typeof(Static), 4245, "", new DecorationEntry[]
				{
					new(5143, 1703, 10, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5360, 1715, -89, ""),
					new(5351, 1551, 0, ""),
				}),
				new("Fire", typeof(Static), 6571, "", new DecorationEntry[]
				{
					new(5169, 1586, 15, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5360, 1705, -67, ""),
					new(5362, 1718, -125, ""),
					new(5349, 1739, -125, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1657, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5343, 1577, 0, ""),
				}),
				new("Cave Wall", typeof(Static), 628, "", new DecorationEntry[]
				{
					new(5342, 1658, 22, ""),
				}),
				new("Cocoon", typeof(Static), 4314, "", new DecorationEntry[]
				{
					new(5296, 1547, 0, ""),
				}),
				new("Web", typeof(Static), 4317, "", new DecorationEntry[]
				{
					new(5296, 1547, 0, ""),
				}),
				new("Lever", typeof(Static), 4238, "", new DecorationEntry[]
				{
					new(5251, 1603, 7, ""),
				}),
				new("Egg Case", typeof(Static), 4313, "", new DecorationEntry[]
				{
					new(5300, 1548, 0, ""),
					new(5302, 1552, 0, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(5292, 1560, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
