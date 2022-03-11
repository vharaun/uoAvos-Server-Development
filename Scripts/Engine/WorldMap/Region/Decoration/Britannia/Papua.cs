using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Papua { get; } = Register(DecorationTarget.Britannia, "Papua", new DecorationList[]
			{
				#region Entries
				
				new("Stone Pavers", typeof(Static), 1313, "", new DecorationEntry[]
				{
					new(5736, 3196, 10, ""),
				}),
				new("Thatch Roof", typeof(Static), 1446, "", new DecorationEntry[]
				{
					new(5720, 3262, 35, ""),
					new(5720, 3263, 35, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1685, "Facing=WestCW", new DecorationEntry[]
				{
					new(5675, 3138, 12, ""),
					new(5698, 3279, 14, ""),
					new(5726, 3248, 15, ""),
					new(5730, 3202, 8, ""),
					new(5745, 3206, 15, ""),
					new(5764, 3154, 14, ""),
					new(5769, 3168, 14, ""),
					new(5770, 3154, 14, ""),
					new(5774, 3168, 14, ""),
					new(5776, 3154, 14, ""),
					new(5779, 3168, 14, ""),
					new(5800, 3276, 11, ""),
					new(5805, 3274, 32, ""),
					new(5698, 3287, 14, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1687, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5662, 3129, 13, ""),
					new(5676, 3138, 12, ""),
					new(5727, 3248, 15, ""),
					new(5770, 3168, 14, ""),
					new(5775, 3168, 14, ""),
					new(5780, 3168, 14, ""),
					new(5801, 3276, 11, ""),
					new(5806, 3274, 32, ""),
					new(5812, 3294, 10, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1691, "Facing=EastCW", new DecorationEntry[]
				{
					new(5691, 3212, 10, ""),
					new(5708, 3203, 11, ""),
					new(5731, 3187, 8, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1693, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5677, 3285, 11, ""),
					new(5702, 3211, 10, ""),
					new(5739, 3218, 10, ""),
					new(5761, 3156, 14, ""),
					new(5761, 3160, 14, ""),
					new(5761, 3165, 14, ""),
					new(5803, 3273, 11, ""),
					new(5815, 3268, 11, ""),
					new(5669, 3149, 12, ""),
					new(5694, 3286, 14, ""),
					new(5797, 3290, 10, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1695, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5677, 3284, 11, ""),
					new(5739, 3217, 10, ""),
					new(5739, 3268, 14, ""),
					new(5755, 3270, 15, ""),
					new(5803, 3272, 11, ""),
					new(5815, 3267, 11, ""),
					new(5669, 3148, 12, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1697, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(5718, 3206, 11, ""),
					new(5783, 3162, 15, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1699, "Facing=NorthCW", new DecorationEntry[]
				{
					new(5718, 3205, 11, ""),
					new(5783, 3161, 15, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(5698, 3287, -6, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2154, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5681, 3286, -1, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2156, "Facing=EastCW", new DecorationEntry[]
				{
					new(5682, 3286, -1, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(5747, 3189, 18, ""),
					new(5781, 3150, 14, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(5708, 3214, -2, ""),
				}),
				new("Bottle Of Ale", typeof(BeverageBottle), 2463, "Content=Ale", new DecorationEntry[]
				{
					new(5785, 3168, 22, ""),
				}),
				new("Candle", typeof(Candle), 2575, "", new DecorationEntry[]
				{
					new(5753, 3194, 21, ""),
				}),
				new("Hanging Lantern", typeof(HangingLantern), 2586, "", new DecorationEntry[]
				{
					new(5779, 3171, 14, ""),
					new(5781, 3171, 14, ""),
				}),
				new("Hanging Lantern", typeof(HangingLantern), 2589, "Unlit", new DecorationEntry[]
				{
					new(5759, 3165, 14, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(5809, 3291, 11, ""),
				}),
				new("Dresser", typeof(Static), 2628, "", new DecorationEntry[]
				{
					new(5799, 3268, 33, ""),
				}),
				new("Dresser", typeof(Static), 2629, "", new DecorationEntry[]
				{
					new(5799, 3267, 33, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2641, "", new DecorationEntry[]
				{
					new(5757, 3151, 16, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(5723, 3240, 16, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2711, "", new DecorationEntry[]
				{
					new(5727, 3188, 9, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2712, "", new DecorationEntry[]
				{
					new(5717, 3196, 12, ""),
					new(5726, 3188, 9, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2713, "", new DecorationEntry[]
				{
					new(5711, 3203, 12, ""),
					new(5724, 3190, 9, ""),
					new(5732, 3216, 11, ""),
					new(5804, 3269, 14, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2714, "", new DecorationEntry[]
				{
					new(5711, 3202, 12, ""),
					new(5724, 3191, 9, ""),
					new(5733, 3262, 15, ""),
					new(5742, 3195, 16, ""),
					new(5804, 3270, 14, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2715, "", new DecorationEntry[]
				{
					new(5669, 3283, 12, ""),
					new(5725, 3188, 9, ""),
					new(5809, 3265, 33, ""),
					new(5812, 3287, 11, ""),
				}),
				new("Bookcase", typeof(LibraryBookcase), 2716, "", new DecorationEntry[]
				{
					new(5724, 3189, 9, ""),
					new(5742, 3194, 16, ""),
					new(5796, 3265, 11, ""),
					new(5796, 3266, 11, ""),
				}),
				new("Ruined Bookcase", typeof(Static), 3092, "", new DecorationEntry[]
				{
					new(5754, 3268, 16, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5690, 3204, 11, ""),
					new(5824, 3261, 3, ""),
					new(5824, 3261, 6, ""),
					new(5824, 3262, 3, ""),
					new(5824, 3262, 6, ""),
					new(5824, 3262, 9, ""),
					new(5824, 3263, 3, ""),
					new(5825, 3261, 3, ""),
					new(5825, 3261, 6, ""),
					new(5825, 3261, 9, ""),
					new(5825, 3262, 3, ""),
					new(5825, 3262, 6, ""),
					new(5825, 3262, 9, ""),
					new(5825, 3263, 3, ""),
					new(5825, 3263, 6, ""),
					new(5826, 3261, 3, ""),
					new(5826, 3261, 6, ""),
					new(5826, 3261, 9, ""),
					new(5826, 3262, 3, ""),
					new(5826, 3262, 6, ""),
				}),
				new("Crate", typeof(FillableLargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5741, 3259, 15, ""),
					new(5741, 3259, 18, ""),
					new(5809, 3274, 12, ""),
					new(5809, 3275, 12, ""),
					new(5809, 3275, 15, ""),
					new(5809, 3275, 18, ""),
					new(5810, 3274, 12, ""),
					new(5810, 3275, 14, ""),
					new(5810, 3275, 17, ""),
					new(5811, 3275, 12, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(5740, 3258, 15, ""),
					new(5740, 3258, 18, ""),
					new(5741, 3258, 15, ""),
					new(5741, 3258, 18, ""),
					new(5741, 3258, 21, ""),
				}),
				new("Metal Chest", typeof(FillableMetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5723, 3242, 16, ""),
					new(5723, 3246, 16, ""),
					new(5757, 3156, 16, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5662, 3123, 15, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5660, 3124, 15, ""),
					new(5660, 3128, 15, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5762, 3153, 16, ""),
					new(5768, 3153, 16, ""),
					new(5774, 3153, 16, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5665, 3123, 15, ""),
				}),
				new("Wooden Chest", typeof(FillableWoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5760, 3158, 16, ""),
					new(5760, 3164, 16, ""),
				}),
				new("Barrel", typeof(FillableBarrel), 3703, "", new DecorationEntry[]
				{
					new(5666, 3289, 12, ""),
					new(5690, 3284, 15, ""),
					new(5690, 3285, 15, ""),
					new(5690, 3286, 15, ""),
					new(5691, 3284, 15, ""),
					new(5810, 3265, -1, ""),
				}),
				new("Basin", typeof(Static), 3704, "", new DecorationEntry[]
				{
					new(5757, 3160, 16, ""),
					new(5757, 3166, 16, ""),
					new(5759, 3150, 16, ""),
					new(5771, 3150, 16, ""),
				}),
				new("Water Tub", typeof(Static), 3707, "", new DecorationEntry[]
				{
					new(5666, 3287, 12, ""),
				}),
				new("Metal Chest", typeof(FillableMetalChest), 3708, "", new DecorationEntry[]
				{
					new(5733, 3269, 15, ""),
					new(5804, 3271, 11, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(5811, 3303, 12, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(5737, 3261, 18, ""),
				}),
				new("Chess Board", typeof(Chessboard), 4006, "", new DecorationEntry[]
				{
					new(5808, 3269, 39, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "Light=Circle225", new DecorationEntry[]
				{
					new(5708, 3214, -2, ""),
				}),
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(5666, 3283, 12, ""),
					new(5667, 3283, 12, ""),
					new(5691, 3288, -3, ""),
					new(5691, 3289, -3, ""),
					new(5692, 3287, -2, ""),
					new(5692, 3288, -3, ""),
					new(5692, 3289, -1, ""),
					new(5693, 3287, -3, ""),
					new(5693, 3288, -4, ""),
					new(5693, 3289, -3, ""),
					new(5701, 3204, 16, ""),
					new(5804, 3274, 11, ""),
					new(5804, 3275, 11, ""),
					new(5805, 3274, 11, ""),
					new(5805, 3275, 11, ""),
					new(5806, 3268, -15, ""),
					new(5806, 3269, -15, ""),
					new(5806, 3270, -15, ""),
					new(5806, 3271, -15, ""),
					new(5806, 3274, 11, ""),
					new(5806, 3275, 11, ""),
					new(5807, 3271, -15, ""),
					new(5807, 3274, 11, ""),
					new(5807, 3275, 11, ""),
					new(5808, 3265, -5, ""),
					new(5808, 3271, -15, ""),
					new(5808, 3275, 11, ""),
					new(5809, 3264, -7, ""),
					new(5809, 3265, -5, ""),
					new(5809, 3268, -15, ""),
					new(5809, 3269, -15, ""),
					new(5809, 3270, -15, ""),
					new(5809, 3271, -15, ""),
					new(5810, 3267, -15, ""),
					new(5810, 3268, -15, ""),
					new(5810, 3269, -15, ""),
					new(5810, 3270, -15, ""),
					new(5810, 3271, -15, ""),
					new(5810, 3275, 11, ""),
					new(5811, 3266, -8, ""),
					new(5812, 3266, -3, ""),
					new(5812, 3267, -2, ""),
					new(5823, 3238, 3, ""),
					new(5824, 3238, 3, ""),
					new(5824, 3239, 3, ""),
					new(5824, 3259, 3, ""),
					new(5824, 3260, 3, ""),
					new(5825, 3259, 5, ""),
					new(5825, 3260, 3, ""),
					new(5826, 3260, 3, ""),
					new(5826, 3263, 3, ""),
					new(5827, 3262, 3, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4021, "", new DecorationEntry[]
				{
					new(5738, 3261, 18, ""),
				}),
				new("Pentagram", typeof(Static), 4074, "", new DecorationEntry[]
				{
					new(5736, 3196, 10, ""),
				}),
				new("Teleporter: Recsu", typeof(KeywordTeleporter), 7107, "Substring=recsu;Range=4;PointDest=(4544, 850, 30)", new DecorationEntry[]
				{
					new(5736, 3196, 10, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelSouthAddon), 4117, "", new DecorationEntry[]
				{
					new(5753, 3269, 15, ""),
				}),
				new("Hammer", typeof(Static), 4139, "", new DecorationEntry[]
				{
					new(5687, 3206, 17, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(5751, 3271, 15, ""),
				}),
				new("Earrings", typeof(Static), 4231, "", new DecorationEntry[]
				{
					new(5662, 3152, 16, ""),
				}),
				new("Necklace", typeof(Static), 4232, "", new DecorationEntry[]
				{
					new(5660, 3145, 16, ""),
				}),
				new("An Obelisk", typeof(Obelisk), 4484, "", new DecorationEntry[]
				{
					new(5741, 3313, 3, ""),
					new(5742, 3313, 8, ""),
					new(5748, 3313, 8, ""),
					new(5749, 3313, 3, ""),
				}),
				new("Leather Tunic", typeof(Static), 5066, "", new DecorationEntry[]
				{
					new(5809, 3295, 11, ""),
				}),
				new("Studded Tunic", typeof(Static), 5081, "", new DecorationEntry[]
				{
					new(5810, 3295, 11, ""),
				}),
				new("Ringmail Armor", typeof(Static), 5095, "", new DecorationEntry[]
				{
					new(5808, 3295, 11, ""),
				}),
				new("Close Helmet", typeof(Static), 5128, "", new DecorationEntry[]
				{
					new(5804, 3295, 13, ""),
				}),
				new("Plate Helm", typeof(Static), 5138, "", new DecorationEntry[]
				{
					new(5803, 3295, 13, ""),
				}),
				new("Platemail Gorget", typeof(Static), 5139, "", new DecorationEntry[]
				{
					new(5802, 3305, 13, ""),
				}),
				new("Map", typeof(Static), 5356, "", new DecorationEntry[]
				{
					new(5797, 3270, 18, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(5808, 3264, -7, ""),
				}),
				new("Flour Mill", typeof(FlourMillEastAddon), 6432, "", new DecorationEntry[]
				{
					new(5755, 3190, 15, ""),
				}),
				new("Bellows", typeof(Static), 6534, "", new DecorationEntry[]
				{
					new(5813, 3301, 12, ""),
				}),
				new("Forge", typeof(Static), 6538, "Light=Circle300", new DecorationEntry[]
				{
					new(5813, 3302, 12, ""),
				}),
				new("Forge", typeof(Static), 6542, "", new DecorationEntry[]
				{
					new(5813, 3303, 12, ""),
				}),
				new("Cooper's Bench", typeof(Static), 6652, "", new DecorationEntry[]
				{
					new(5694, 3211, 12, ""),
				}),
				new("Earrings", typeof(Static), 7943, "", new DecorationEntry[]
				{
					new(5654, 3145, 19, ""),
					new(5663, 3152, 16, ""),
				}),
				new("Necklace", typeof(Static), 7944, "", new DecorationEntry[]
				{
					new(5659, 3145, 16, ""),
					new(5661, 3145, 16, ""),
				}),
				new("Ring", typeof(Static), 7945, "", new DecorationEntry[]
				{
					new(5662, 3152, 16, ""),
				}),
				new("Hatch", typeof(Static), 16019, "", new DecorationEntry[]
				{
					new(5834, 3260, 2, ""),
				}),
				
				#endregion
			});
		}
	}
}
