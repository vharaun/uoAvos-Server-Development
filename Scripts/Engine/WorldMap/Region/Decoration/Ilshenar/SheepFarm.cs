using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] SheepFarm { get; } = Register(DecorationTarget.Ilshenar, "Sheep Farm", new DecorationList[]
			{
				#region Entries
				
				new("Wooden Gate", typeof(DarkWoodGate), 2158, "Facing=SouthCW", new DecorationEntry[]
				{
					new(1311, 1325, -14, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2156, "Facing=EastCW", new DecorationEntry[]
				{
					new(1328, 1321, -14, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(1305, 1319, -14, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(1306, 1316, -14, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(1308, 1314, 6, ""),
				}),
				new("Scissors", typeof(Scissors), 3998, "", new DecorationEntry[]
				{
					new(1309, 1319, -10, ""),
				}),
				new("Dyeing Tub", typeof(DyeTub), 4011, "Hue=0x15C", new DecorationEntry[]
				{
					new(1311, 1319, -14, ""),
				}),
				new("Upright Loom", typeof(Static), 4191, "", new DecorationEntry[]
				{
					new(1305, 1320, -14, ""),
				}),
				
				#endregion
			});
		}
	}
}
