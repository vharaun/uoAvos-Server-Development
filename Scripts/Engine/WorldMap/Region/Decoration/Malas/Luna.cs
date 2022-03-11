using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] Luna { get; } = Register(DecorationTarget.Malas, "Luna", new DecorationList[]
			{
				#region Entries
				
				new("Wooden Door", typeof(DarkWoodDoor), 1709, "Facing=SouthCW", new DecorationEntry[]
				{
					new(989, 519, -30, ""),
					new(999, 527, -50, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1711, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(999, 512, -50, ""),
					new(989, 518, -30, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1703, "Facing=EastCCW", new DecorationEntry[]
				{
					new(991, 522, -30, ""),
					new(978, 522, -50, ""),
					new(1002, 522, -50, ""),
					new(1002, 522, -30, ""),
				}),
				new("Backpack", typeof(Backpack), 3701, "", new DecorationEntry[]
				{
					new(992, 509, -47, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(950, 493, -30, ""),
					new(951, 498, -30, ""),
					new(953, 493, -30, ""),
					new(952, 496, -30, ""),
					new(952, 498, -30, ""),
					new(953, 496, -30, ""),
					new(986, 525, -30, ""),
					new(1004, 523, -50, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2718, "Hue=0x47E", new DecorationEntry[]
				{
					new(947, 496, -70, ""),
					new(947, 498, -70, ""),
					new(947, 499, -70, ""),
					new(947, 540, -70, ""),
					new(947, 542, -70, ""),
					new(948, 543, -30, ""),
					new(949, 541, -50, ""),
					new(947, 544, -70, ""),
					new(1022, 494, -50, ""),
					new(1022, 495, -50, ""),
					new(1022, 543, -70, ""),
					new(1022, 544, -70, ""),
					new(1024, 499, -50, ""),
					new(949, 543, -50, ""),
					new(1024, 500, -50, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "Hue=0x47E", new DecorationEntry[]
				{
					new(947, 497, -70, ""),
				}),
				new("Barrel", typeof(Barrel), 4014, "Hue=0x47E", new DecorationEntry[]
				{
					new(947, 538, -70, ""),
					new(948, 538, -70, ""),
					new(1028, 541, -70, ""),
					new(1028, 542, -64, ""),
					new(1028, 542, -70, ""),
				}),
				new("Wooden Shelf", typeof(EmptyBookcase), 2717, "Hue=0x47E", new DecorationEntry[]
				{
					new(954, 538, -30, ""),
					new(1025, 493, -30, ""),
					new(1028, 493, -30, ""),
					new(1026, 538, -30, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(974, 509, -50, ""),
					new(977, 509, -50, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(975, 509, -50, ""),
					new(976, 509, -50, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(973, 513, -50, ""),
				}),
				new("Bellows", typeof(Static), 6534, "", new DecorationEntry[]
				{
					new(973, 514, -50, ""),
				}),
				new("Forge", typeof(Static), 6538, "", new DecorationEntry[]
				{
					new(973, 515, -50, ""),
				}),
				new("Forge", typeof(Static), 6542, "", new DecorationEntry[]
				{
					new(973, 516, -50, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "Hue=0x47E", new DecorationEntry[]
				{
					new(987, 516, -44, ""),
					new(993, 516, -44, ""),
					new(994, 516, -44, ""),
					new(1004, 509, -30, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "Hue=0x47E", new DecorationEntry[]
				{
					new(985, 523, -40, ""),
					new(985, 523, -45, ""),
					new(985, 523, -50, ""),
				}),
				new("Dresser", typeof(Static), 2621, "", new DecorationEntry[]
				{
					new(987, 525, -30, ""),
				}),
				new("Dresser", typeof(Static), 2620, "", new DecorationEntry[]
				{
					new(988, 525, -30, ""),
				}),
				new("Armoire", typeof(Armoire), 2639, "", new DecorationEntry[]
				{
					new(999, 523, -30, ""),
					new(1001, 523, -30, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(996, 530, -30, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(1000, 524, -50, ""),
					new(1000, 525, -50, ""),
					new(1000, 529, -50, ""),
					new(1000, 530, -50, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "Hue=0x47E", new DecorationEntry[]
				{
					new(1022, 538, -70, ""),
					new(1022, 538, -64, ""),
					new(1022, 539, -70, ""),
					new(1022, 540, -70, ""),
					new(1023, 538, -70, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(973, 530, -50, ""),
				}),
				new("Upright Loom", typeof(LoomSouthAddon), 4197, "", new DecorationEntry[]
				{
					new(975, 523, -50, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1707, "Facing=EastCW", new DecorationEntry[]
				{
					new(978, 517, -50, ""),
					new(994, 516, -30, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1715, "Facing=NorthCW", new DecorationEntry[]
				{
					new(980, 527, -50, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1713, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(980, 512, -50, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1749, "Facing=WestCW", new DecorationEntry[]
				{
					new(926, 642, -90, ""),
				}),
				new("Bakery", typeof(LocalizedSign), 2979, "LabelNumber=1061836", new DecorationEntry[]
				{
					new(962, 633, -90, ""),
				}),
				new("Tavern", typeof(LocalizedSign), 3011, "LabelNumber=1061835", new DecorationEntry[]
				{
					new(962, 641, -90, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1751, "Facing=EastCCW", new DecorationEntry[]
				{
					new(927, 642, -90, ""),
				}),
				new("Wooden Gate", typeof(LightWoodGate), 2115, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(952, 637, -90, ""),
				}),
				new("Wooden Door", typeof(LightWoodDoor), 1757, "Facing=SouthCW", new DecorationEntry[]
				{
					new(928, 637, -90, ""),
				}),
				
				#endregion
			});
		}
	}
}
