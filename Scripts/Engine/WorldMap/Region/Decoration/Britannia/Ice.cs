using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Ice { get; } = Register(DecorationTarget.Britannia, "Ice", new DecorationList[]
			{
				#region Entries
				
				new("Flag Stones", typeof(Static), 1278, "", new DecorationEntry[]
				{
					new(5837, 330, 40, ""),
					new(5838, 329, 40, ""),
				}),
				new("Wooden Wall", typeof(SecretWoodenDoor), 822, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5831, 367, 0, ""),
				}),
				new("Wooden Fence", typeof(Static), 2148, "", new DecorationEntry[]
				{
					new(5820, 357, 1, ""),
					new(5836, 360, 6, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5832, 240, -3, ""),
					new(5750, 147, 9, ""),
					new(5682, 181, -3, ""),
					new(5763, 145, -3, ""),
					new(5822, 359, -1, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5682, 332, 0, ""),
					new(5681, 329, 0, ""),
					new(5681, 330, 0, ""),
					new(5681, 330, 3, ""),
					new(5681, 331, 0, ""),
					new(5681, 331, 3, ""),
					new(5681, 332, 0, ""),
					new(5681, 332, 3, ""),
					new(5681, 333, 0, ""),
					new(5682, 330, 0, ""),
					new(5682, 331, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(5686, 321, 0, ""),
					new(5686, 322, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(5658, 320, 0, ""),
					new(5657, 320, 0, ""),
					new(5659, 320, 0, ""),
					new(5660, 320, 0, ""),
					new(5661, 320, 0, ""),
					new(5662, 320, 0, ""),
				}),
				new("Wooden Fence", typeof(Static), 2147, "", new DecorationEntry[]
				{
					new(5839, 349, 1, ""),
					new(5823, 349, 1, ""),
					new(5834, 345, 6, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5717, 144, -16, ""),
					new(5851, 227, 0, ""),
					new(5701, 305, 0, ""),
					new(5659, 302, 0, ""),
					new(5661, 302, 0, ""),
					new(5852, 231, -9, ""),
					new(5687, 311, 0, ""),
					new(5833, 247, -2, ""),
					new(5688, 311, 0, ""),
					new(5689, 311, 0, ""),
				}),
				new("Palisade", typeof(Static), 547, "", new DecorationEntry[]
				{
					new(5843, 367, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5702, 306, 0, ""),
					new(5727, 147, -2, ""),
					new(5759, 144, -4, ""),
					new(5753, 211, -7, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5828, 364, 0, ""),
					new(5832, 242, -4, ""),
					new(5760, 187, -4, ""),
					new(5656, 305, 0, ""),
					new(5656, 307, 0, ""),
					new(5768, 189, -5, ""),
				}),
				new("Death Vortex", typeof(Static), 14232, "", new DecorationEntry[]
				{
					new(5673, 325, -3, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5840, 357, 0, ""),
					new(5770, 185, -1, ""),
					new(5849, 233, -16, ""),
					new(5840, 358, 1, ""),
					new(5683, 188, -2, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(5831, 346, 15, ""),
				}),
				new("Wooden Wall", typeof(SecretWoodenDoor), 820, "Facing=WestCW", new DecorationEntry[]
				{
					new(5830, 367, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(5656, 332, 0, ""),
					new(5656, 329, 0, ""),
					new(5656, 321, 0, ""),
					new(5656, 323, 0, ""),
					new(5656, 325, 0, ""),
					new(5656, 327, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(5656, 328, 0, ""),
					new(5656, 330, 0, ""),
					new(5656, 331, 0, ""),
					new(5656, 333, 0, ""),
					new(5656, 322, 0, ""),
					new(5656, 324, 0, ""),
					new(5656, 326, 0, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1767, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5832, 346, 15, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2150, "Facing=WestCW", new DecorationEntry[]
				{
					new(5839, 363, 0, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2152, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5840, 363, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5686, 312, 0, ""),
					new(5686, 313, 0, ""),
					new(5686, 314, 0, ""),
					new(5756, 203, -2, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor3), 852, "Facing=WestCW;Hue=1109", new DecorationEntry[]
				{
					new(5687, 319, 0, ""),
				}),
				new("Stone Wall", typeof(SecretStoneDoor3), 854, "Facing=EastCCW;Hue=1109", new DecorationEntry[]
				{
					new(5688, 319, 0, ""),
				}),
				new("Palisade", typeof(Static), 1060, "", new DecorationEntry[]
				{
					new(5819, 361, 20, ""),
				}),
				new("Wood", typeof(Static), 1848, "", new DecorationEntry[]
				{
					new(5851, 233, -13, ""),
				}),
				
				#endregion
			});
		}
	}
}
