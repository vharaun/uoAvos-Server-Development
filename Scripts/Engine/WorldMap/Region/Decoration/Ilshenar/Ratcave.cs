using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Ratcave { get; } = Register(DecorationTarget.Ilshenar, "Ratcave", new DecorationList[]
			{
				#region Entries
				
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(1307, 1568, 0, ""),
					new(1307, 1528, -25, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(1307, 1568, -3, ""),
					new(1308, 1569, -3, ""),
					new(1307, 1527, -28, ""),
					new(1307, 1528, -28, ""),
					new(1308, 1528, -28, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(1308, 1568, -3, ""),
					new(1308, 1528, -25, ""),
				}),
				new("Small Crate", typeof(SmallCrate), 2473, "", new DecorationEntry[]
				{
					new(1308, 1569, 0, ""),
				}),
				new("Iron Ore", typeof(Static), 6583, "", new DecorationEntry[]
				{
					new(1284, 1538, -3, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(1165, 1513, -68, ""),
					new(1170, 1508, -68, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(1173, 1504, -68, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(1169, 1516, -68, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(1171, 1518, -68, ""),
				}),
				new("Crumbling Floor", typeof(Static), 4549, "", new DecorationEntry[]
				{
					new(1183, 1477, -36, ""),
					new(1188, 1504, -62, ""),
					new(1198, 1473, -23, ""),
					new(1199, 1513, -44, ""),
					new(1197, 1546, -26, ""),
					new(1200, 1530, -25, ""),
					new(1208, 1502, -28, ""),
					new(1219, 1517, -25, ""),
					new(1231, 1529, -25, ""),
					new(1232, 1472, -22, ""),
					new(1244, 1474, -22, ""),
					new(1241, 1504, -25, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(1281, 1494, 15, ""),
					new(1307, 1527, -25, ""),
					new(1309, 1528, -28, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(1281, 1494, 12, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(1283, 1492, 12, ""),
				}),
				
				#endregion
			});
		}
	}
}
