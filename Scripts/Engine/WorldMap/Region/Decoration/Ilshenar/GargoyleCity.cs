using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Gargoylecity { get; } = Register(DecorationTarget.Ilshenar, "Gargoylecity", new DecorationList[]
			{
				#region Entries
				
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW;Hue=0x835", new DecorationEntry[]
				{
					new(856, 677, -40, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW;Hue=0x835", new DecorationEntry[]
				{
					new(853, 672, -40, ""),
				}),
				new("Metal Door", typeof(Static), 1659, "Facing=EastCW;Hue=0x835", new DecorationEntry[]
				{
					new(856, 606, -40, ""),
					new(859, 611, -40, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8173, "Facing=WestCW;Hue=0x835", new DecorationEntry[]
				{
					new(892, 674, -40, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8181, "Facing=SouthCW;Hue=0x835", new DecorationEntry[]
				{
					new(896, 657, -40, ""),
					new(896, 662, -40, ""),
					new(896, 667, -40, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(848, 719, 0, ""),
					new(850, 719, 0, ""),
					new(854, 607, -40, ""),
					new(854, 607, -35, ""),
					new(857, 670, -40, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(828, 725, 0, ""),
					new(844, 717, 0, ""),
					new(852, 608, -40, ""),
					new(852, 609, -40, ""),
					new(852, 609, -36, ""),
					new(852, 609, -32, ""),
					new(852, 611, -40, ""),
					new(852, 611, -36, ""),
					new(852, 613, -40, ""),
					new(852, 613, -36, ""),
					new(852, 675, -40, ""),
					new(852, 675, -36, ""),
					new(852, 676, -40, ""),
					new(852, 676, -36, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(832, 712, 0, ""),
					new(856, 670, -40, ""),
					new(856, 670, -36, ""),
					new(856, 670, -32, ""),
					new(858, 670, -40, ""),
					new(858, 670, -36, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(852, 612, -40, ""),
					new(852, 675, -32, ""),
				}),
				new("Skinning Knife", typeof(Static), 3781, "", new DecorationEntry[]
				{
					new(864, 583, -34, ""),
				}),
				new("Anvil", typeof(AnvilSouthAddon), 4016, "", new DecorationEntry[]
				{
					new(786, 662, 0, ""),
					new(786, 671, 0, ""),
					new(791, 662, 0, ""),
					new(791, 671, 0, ""),
					new(796, 662, 0, ""),
					new(796, 671, 0, ""),
				}),
				new("Spinning Wheel", typeof(SpinningwheelEastAddon), 4121, "", new DecorationEntry[]
				{
					new(893, 620, -40, ""),
					new(893, 622, -40, ""),
					new(893, 624, -40, ""),
				}),
				new("Upright Loom", typeof(LoomEastAddon), 4192, "", new DecorationEntry[]
				{
					new(893, 617, -40, ""),
					new(893, 626, -40, ""),
				}),
				new("Lever", typeof(Static), 4243, "", new DecorationEntry[]
				{
					new(760, 645, 10, ""),
				}),
				new("Butcher Knife", typeof(Static), 5111, "", new DecorationEntry[]
				{
					new(864, 582, -34, ""),
				}),
				new("Platemail Arms", typeof(Static), 5143, "Hue=0x44E", new DecorationEntry[]
				{
					new(768, 631, 5, ""),
				}),
				new("Map", typeof(Static), 5355, "", new DecorationEntry[]
				{
					new(876, 661, -34, ""),
				}),
				new("Bellows", typeof(Static), 6534, "", new DecorationEntry[]
				{
					new(786, 659, 0, ""),
					new(786, 668, 0, ""),
					new(791, 659, 0, ""),
					new(791, 668, 0, ""),
					new(796, 659, 0, ""),
					new(796, 668, 0, ""),
				}),
				new("Forge", typeof(Static), 6538, "Light=Circle300", new DecorationEntry[]
				{
					new(786, 660, 0, ""),
					new(786, 669, 0, ""),
					new(791, 660, 0, ""),
					new(791, 669, 0, ""),
					new(796, 660, 0, ""),
					new(796, 669, 0, ""),
				}),
				new("Forge", typeof(Static), 6542, "", new DecorationEntry[]
				{
					new(786, 661, 0, ""),
					new(786, 670, 0, ""),
					new(791, 661, 0, ""),
					new(791, 670, 0, ""),
					new(796, 661, 0, ""),
					new(796, 670, 0, ""),
				}),
				new("Bellows", typeof(Static), 6546, "", new DecorationEntry[]
				{
					new(786, 665, 0, ""),
					new(786, 674, 0, ""),
					new(791, 665, 0, ""),
					new(791, 674, 0, ""),
					new(796, 665, 0, ""),
					new(796, 674, 0, ""),
				}),
				new("Forge", typeof(Static), 6550, "", new DecorationEntry[]
				{
					new(786, 664, 0, ""),
					new(786, 673, 0, ""),
					new(791, 664, 0, ""),
					new(791, 673, 0, ""),
					new(796, 664, 0, ""),
					new(796, 673, 0, ""),
				}),
				new("Forge", typeof(Static), 6554, "", new DecorationEntry[]
				{
					new(786, 663, 0, ""),
					new(786, 672, 0, ""),
					new(791, 663, 0, ""),
					new(791, 672, 0, ""),
					new(796, 663, 0, ""),
					new(796, 672, 0, ""),
				}),
				new("Heater Shield", typeof(Static), 7030, "Hue=0x44E", new DecorationEntry[]
				{
					new(766, 630, 6, ""),
				}),
				new("Heater Shield", typeof(Static), 7031, "Hue=0x44E", new DecorationEntry[]
				{
					new(768, 630, 5, ""),
				}),
				new("Bell Of Courage", typeof(Static), 7186, "", new DecorationEntry[]
				{
					new(846, 601, -34, ""),
					new(846, 682, -34, ""),
				}),
				new("Brain", typeof(Static), 7408, "Hue=0x96E", new DecorationEntry[]
				{
					new(771, 631, 11, ""),
				}),
				new("Table Leg", typeof(Static), 7805, "Hue=0x451", new DecorationEntry[]
				{
					new(766, 631, 6, ""),
				}),
				new("Barrel Staves", typeof(Static), 7857, "Hue=0x44E", new DecorationEntry[]
				{
					new(775, 632, -1, ""),
				}),
				new("Barrel Staves", typeof(Static), 7858, "Hue=0x44E", new DecorationEntry[]
				{
					new(773, 632, -1, ""),
				}),
				new("Barrel Staves", typeof(Static), 7859, "Hue=0x44E", new DecorationEntry[]
				{
					new(767, 631, 2, ""),
				}),
				new("Statue", typeof(Static), 7960, "Hue=0x451", new DecorationEntry[]
				{
					new(767, 630, 6, ""),
				}),
				
				#endregion
			});
		}
	}
}
