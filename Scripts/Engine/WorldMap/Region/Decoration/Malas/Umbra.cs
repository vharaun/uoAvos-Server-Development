using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] Umbra { get; } = Register(DecorationTarget.Malas, "Umbra", new DecorationList[]
			{
				#region Entries
				
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(2088, 1318, -80, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(2088, 1326, -80, ""),
					new(2088, 1329, -80, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1771, "Hue=0x497;Facing=EastCW", new DecorationEntry[]
				{
					new(2038, 1320, -85, ""),
					new(2041, 1321, -85, ""),
				}),
				new("Oven", typeof(StoneOvenEastAddon), 2348, "Hue=0x44E", new DecorationEntry[]
				{
					new(2015, 1360, -90, ""),
				}),
				new("Training Dummy", typeof(TrainingDummy), 4212, "Hue=0x44F", new DecorationEntry[]
				{
					new(1961, 1339, -75, ""),
					new(1977, 1307, -75, ""),
				}),
				new("Wooden Bench", typeof(WoodenBench), 2861, "Hue=0x1A", new DecorationEntry[]
				{
					new(2040, 1326, -65, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1775, "Hue=0x497;Facing=NorthCCW", new DecorationEntry[]
				{
					new(2036, 1317, -85, ""),
					new(2036, 1323, -65, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "Hue=0x497", new DecorationEntry[]
				{
					new(2059, 1281, -80, ""),
					new(2059, 1280, -80, ""),
					new(2061, 1290, -80, ""),
					new(2062, 1291, -80, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "Hue=0x497", new DecorationEntry[]
				{
					new(1975, 1365, -74, ""),
					new(1975, 1366, -74, ""),
					new(2034, 1321, -65, ""),
				}),
				new("Barrel", typeof(Static), 4014, "Hue=0x497", new DecorationEntry[]
				{
					new(1975, 1369, -80, ""),
					new(1975, 1370, -80, ""),
					new(1975, 1370, -73, ""),
					new(1991, 1315, -90, ""),
					new(2013, 1365, -90, ""),
					new(2013, 1366, -90, ""),
					new(2014, 1366, -90, ""),
				}),
				new("Stone Wall", typeof(Static), 90, "Hue=0x451", new DecorationEntry[]
				{
					new(1994, 1325, -90, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "Hue=0x497", new DecorationEntry[]
				{
					new(2035, 1311, -65, ""),
					new(2041, 1311, -65, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "Hue=0x497", new DecorationEntry[]
				{
					new(2033, 1313, -65, ""),
					new(2039, 1313, -65, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Hue=0x497;Facing=WestCW", new DecorationEntry[]
				{
					new(2035, 1315, -65, ""),
					new(2040, 1315, -65, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "Hue=0x497", new DecorationEntry[]
				{
					new(2032, 1323, -65, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "Hue=0x455", new DecorationEntry[]
				{
					new(2042, 1339, -80, ""),
					new(2043, 1339, -80, ""),
					new(2048, 1344, -80, ""),
					new(2048, 1344, -76, ""),
				}),
				new("Cleaver", typeof(Static), 3779, "", new DecorationEntry[]
				{
					new(2066, 1372, -74, ""),
				}),
				new("Bottles Of Liquor", typeof(Static), 2462, "", new DecorationEntry[]
				{
					new(2028, 1354, -81, ""),
				}),
				new("Butcher Knife", typeof(Static), 5111, "", new DecorationEntry[]
				{
					new(2070, 1370, -74, ""),
				}),
				
				#endregion
			});
		}
	}
}
