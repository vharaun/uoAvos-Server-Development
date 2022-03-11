using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Delucia { get; } = Register(DecorationTarget.Britannia, "Delucia", new DecorationList[]
			{
				#region Entries
				
				new("Oven", typeof(Static), 1121, "", new DecorationEntry[]
				{
					new(5195, 4058, 37, ""),
				}),
				new("Oven", typeof(Static), 1122, "Light=WestBig", new DecorationEntry[]
				{
					new(5195, 4057, 37, ""),
				}),
				new("Fireplace", typeof(SandstoneFireplaceSouthAddon), 1147, "", new DecorationEntry[]
				{
					new(5198, 4054, 37, ""),
					new(5234, 4014, 37, ""),
					new(5265, 3977, 41, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(5233, 4027, 37, ""),
					new(5293, 4003, 40, ""),
					new(5272, 3987, 37, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1767, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5273, 3987, 37, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1773, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5295, 3998, 40, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1775, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5295, 3997, 40, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1777, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(5290, 4008, 40, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1779, "Facing=NorthCW", new DecorationEntry[]
				{
					new(5290, 4007, 40, ""),
				}),
				new("Wooden Fence", typeof(Static), 2147, "", new DecorationEntry[]
				{
					new(5251, 4021, 39, ""),
					new(5252, 4021, 40, ""),
					new(5253, 4002, 46, ""),
					new(5253, 4021, 40, ""),
					new(5254, 4002, 46, ""),
					new(5254, 4021, 40, ""),
					new(5255, 4021, 38, ""),
				}),
				new("Wooden Fence", typeof(Static), 2148, "", new DecorationEntry[]
				{
					new(5250, 4015, 40, ""),
					new(5250, 4016, 39, ""),
					new(5250, 4017, 40, ""),
					new(5250, 4018, 41, ""),
					new(5250, 4019, 39, ""),
					new(5250, 4020, 39, ""),
					new(5250, 4021, 39, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2150, "Facing=WestCW", new DecorationEntry[]
				{
					new(5287, 4015, 40, ""),
					new(5297, 4003, 40, ""),
					new(5301, 4003, 40, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2152, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5288, 4015, 40, ""),
					new(5298, 4003, 40, ""),
					new(5302, 4003, 40, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2154, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5292, 4012, 40, ""),
					new(5297, 4006, 40, ""),
					new(5297, 4012, 40, ""),
					new(5301, 4006, 40, ""),
					new(5301, 4012, 40, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2156, "Facing=EastCW", new DecorationEntry[]
				{
					new(5293, 4012, 40, ""),
					new(5298, 4006, 40, ""),
					new(5298, 4012, 40, ""),
					new(5302, 4006, 40, ""),
					new(5302, 4012, 40, ""),
				}),
				new("Wooden Fence", typeof(Static), 2186, "", new DecorationEntry[]
				{
					new(5251, 4014, 39, ""),
					new(5256, 4021, 38, ""),
					new(5257, 4021, 38, ""),
				}),
				new("Wooden Fence", typeof(Static), 2187, "", new DecorationEntry[]
				{
					new(5251, 4006, 45, ""),
					new(5251, 4007, 45, ""),
					new(5279, 4009, 38, ""),
					new(5279, 4010, 39, ""),
				}),
				new("Cauldron", typeof(Static), 2421, "", new DecorationEntry[]
				{
					new(5195, 3996, 37, ""),
					new(5293, 3986, 37, ""),
				}),
				new("Hanging Lantern", typeof(HangingLantern), 2586, "", new DecorationEntry[]
				{
					new(5179, 4070, 40, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2608, "", new DecorationEntry[]
				{
					new(5199, 4061, 57, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(5195, 4066, 57, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(5202, 4061, 57, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(5195, 4067, 57, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(5215, 4007, 37, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5236, 4021, 37, ""),
					new(5236, 4021, 40, ""),
					new(5236, 4022, 37, ""),
					new(5236, 4022, 40, ""),
					new(5236, 4023, 37, ""),
					new(5237, 4020, 57, ""),
					new(5237, 4021, 57, ""),
					new(5237, 4022, 57, ""),
					new(5237, 4023, 57, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5262, 3980, 38, ""),
					new(5262, 3982, 38, ""),
					new(5269, 3977, 37, ""),
					new(5269, 3986, 36, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5270, 3971, 37, ""),
					new(5276, 3971, 37, ""),
				}),
				new("Pouch", typeof(Static), 3705, "", new DecorationEntry[]
				{
					new(5262, 3984, 42, ""),
				}),
				new("Water Tub", typeof(Static), 3707, "", new DecorationEntry[]
				{
					new(5296, 4013, 40, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(5291, 4009, 40, ""),
					new(5291, 4010, 40, ""),
					new(5296, 4007, 40, ""),
				}),
				new("Pickaxe", typeof(Static), 3717, "", new DecorationEntry[]
				{
					new(5230, 4021, 43, ""),
					new(5288, 3979, 37, ""),
				}),
				new("Pitchfork", typeof(Static), 3719, "", new DecorationEntry[]
				{
					new(5287, 3979, 37, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "Light=Circle225", new DecorationEntry[]
				{
					new(5195, 3996, 37, ""),
					new(5285, 3980, 37, ""),
					new(5293, 3986, 37, ""),
					new(5295, 3977, 37, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(5230, 4024, 37, ""),
					new(5230, 4025, 37, ""),
					new(5291, 4004, 40, ""),
					new(5291, 4005, 40, ""),
					new(5291, 4006, 40, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(5228, 4003, 37, ""),
					new(5228, 4005, 37, ""),
					new(5235, 4004, 38, ""),
					new(5235, 4006, 37, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(5235, 4016, 37, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(5231, 4015, 37, ""),
				}),
				new("Bellows", typeof(Static), 6523, "", new DecorationEntry[]
				{
					new(5226, 4004, 37, ""),
					new(5234, 4005, 37, ""),
				}),
				new("Forge", typeof(Static), 6526, "Light=Circle300", new DecorationEntry[]
				{
					new(5227, 4004, 37, ""),
					new(5235, 4005, 37, ""),
				}),
				new("Bellows", typeof(Static), 6558, "", new DecorationEntry[]
				{
					new(5229, 4004, 37, ""),
					new(5237, 4005, 37, ""),
				}),
				new("Forge", typeof(Static), 6563, "", new DecorationEntry[]
				{
					new(5236, 4005, 37, ""),
				}),
				new("Forge", typeof(Static), 6564, "", new DecorationEntry[]
				{
					new(5228, 4004, 37, ""),
				}),
				
				#endregion
			});
		}
	}
}
