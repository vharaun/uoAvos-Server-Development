using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Sorcerers { get; } = Register(DecorationTarget.Ilshenar, "Sorcerers", new DecorationList[]
			{
				#region Entries
				
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(250, 88, -28, ""),
					new(253, 88, -28, ""),
					new(259, 69, -28, ""),
					new(265, 69, -28, ""),
					new(267, 69, -28, ""),
					new(269, 69, -28, ""),
					new(273, 69, -28, ""),
					new(444, 9, -28, ""),
					new(448, 9, -28, ""),
					new(99, 36, -28, ""),
					new(101, 36, -28, ""),
					new(108, 36, -28, ""),
					new(110, 36, -28, ""),
					new(114, 36, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(251, 88, -28, ""),
					new(260, 69, -28, ""),
					new(263, 69, -28, ""),
					new(268, 69, -28, ""),
					new(272, 69, -28, ""),
					new(449, 9, -28, ""),
					new(442, 9, -28, ""),
					new(106, 36, -28, ""),
					new(113, 36, -28, ""),
					new(109, 36, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2716, "", new DecorationEntry[]
				{
					new(257, 70, -28, ""),
					new(257, 78, -28, ""),
					new(261, 76, -28, ""),
					new(269, 56, -28, ""),
					new(270, 96, -28, ""),
					new(261, 78, -28, ""),
					new(261, 74, -28, ""),
					new(270, 98, -28, ""),
					new(247, 92, -28, ""),
					new(247, 94, -28, ""),
					new(247, 98, -28, ""),
					new(247, 99, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(257, 71, -28, ""),
					new(261, 73, -28, ""),
					new(261, 75, -28, ""),
					new(270, 95, -28, ""),
					new(247, 93, -28, ""),
					new(247, 97, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2712, "", new DecorationEntry[]
				{
					new(258, 69, -28, ""),
					new(261, 69, -28, ""),
					new(264, 69, -28, ""),
					new(266, 69, -28, ""),
					new(271, 69, -28, ""),
					new(274, 69, -28, ""),
					new(450, 9, -28, ""),
					new(443, 9, -28, ""),
					new(100, 36, -28, ""),
					new(447, 9, -28, ""),
					new(107, 36, -28, ""),
					new(248, 88, -28, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(257, 77, -28, ""),
					new(261, 72, -28, ""),
					new(261, 77, -28, ""),
					new(261, 79, -28, ""),
					new(269, 57, -28, ""),
					new(442, 15, -28, ""),
					new(270, 94, -28, ""),
					new(270, 97, -28, ""),
					new(442, 12, -28, ""),
					new(442, 13, -28, ""),
					new(442, 14, -28, ""),
					new(247, 89, -28, ""),
					new(247, 90, -28, ""),
					new(247, 95, -28, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "Hue=0x835", new DecorationEntry[]
				{
					new(266, 129, -38, ""),
					new(267, 129, -38, ""),
					new(268, 129, -38, ""),
					new(284, 66, -38, ""),
					new(285, 66, -38, ""),
					new(287, 66, -38, ""),
					new(285, 73, -18, ""),
					new(287, 73, -18, ""),
					new(132, 129, -18, ""),
					new(134, 129, -18, ""),
					new(265, 129, -38, ""),
					new(286, 66, -38, ""),
					new(284, 73, -18, ""),
					new(286, 73, -18, ""),
					new(131, 129, -18, ""),
					new(133, 129, -18, ""),
				}),
				new("Magical Crystal", typeof(Static), 7961, "", new DecorationEntry[]
				{
					new(279, 6, -22, ""),
					new(279, 34, -22, ""),
					new(248, 70, -22, ""),
					new(249, 70, -22, ""),
					new(250, 70, -22, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "Hue=0x848", new DecorationEntry[]
				{
					new(273, 141, -18, ""),
				}),
				new("Magical Crystal", typeof(Static), 7964, "", new DecorationEntry[]
				{
					new(284, 6, -22, ""),
					new(283, 34, -22, ""),
				}),
				new("Platemail Gloves", typeof(Static), 5140, "", new DecorationEntry[]
				{
					new(217, 49, -28, ""),
				}),
				new("Bellows", typeof(LargeForgeEastAddon), 6534, "", new DecorationEntry[]
				{
					new(299, 23, -28, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(301, 24, -28, ""),
					new(301, 25, -28, ""),
				}),
				new("Wooden Stairs", typeof(Static), 1850, "", new DecorationEntry[]
				{
					new(359, 40, -43, ""),
					new(359, 41, -43, ""),
					new(359, 42, -43, ""),
					new(155, 88, -18, ""),
					new(155, 89, -18, ""),
					new(155, 90, -18, ""),
				}),
				new("Stone Stairs", typeof(Static), 1876, "", new DecorationEntry[]
				{
					new(370, 29, -43, ""),
					new(370, 30, -43, ""),
					new(370, 31, -43, ""),
					new(242, 25, -18, ""),
					new(242, 26, -18, ""),
					new(242, 27, -18, ""),
				}),
				new("Bone Armor", typeof(Static), 5204, "", new DecorationEntry[]
				{
					new(130, 109, -28, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(394, 59, -28, ""),
					new(394, 68, -28, ""),
					new(394, 74, -28, ""),
					new(400, 67, -28, ""),
					new(400, 79, -28, ""),
					new(461, 82, -28, ""),
				}),
				new("Strong Box", typeof(MetalBox), 3712, "", new DecorationEntry[]
				{
					new(394, 62, -28, ""),
					new(394, 65, -28, ""),
					new(394, 80, -28, ""),
					new(400, 58, -28, ""),
					new(400, 64, -28, ""),
					new(400, 73, -28, ""),
					new(400, 76, -28, ""),
					new(433, 96, -22, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(399, 62, -28, ""),
					new(399, 71, -28, ""),
					new(393, 72, -28, ""),
					new(393, 78, -28, ""),
				}),
				new("Pen And Ink", typeof(Static), 4031, "", new DecorationEntry[]
				{
					new(423, 95, -22, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(272, 87, -28, ""),
					new(266, 87, -28, ""),
				}),
				new("Book", typeof(Static), 4029, "", new DecorationEntry[]
				{
					new(423, 96, -22, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8181, "Facing=SouthCW", new DecorationEntry[]
				{
					new(418, 28, -28, ""),
					new(474, 29, -28, ""),
					new(106, 31, -28, ""),
					new(231, 139, -28, ""),
					new(231, 132, -28, ""),
					new(231, 123, -28, ""),
					new(231, 117, -28, ""),
				}),
				new("Stone Pavers", typeof(Static), 1307, "", new DecorationEntry[]
				{
					new(427, 113, -28, ""),
				}),
				new("Stone Pavers", typeof(Static), 1305, "", new DecorationEntry[]
				{
					new(429, 113, -28, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(433, 92, -28, ""),
					new(435, 92, -28, ""),
					new(434, 92, -28, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(462, 82, -28, ""),
					new(462, 82, -25, ""),
					new(139, 52, -25, ""),
					new(139, 52, -28, ""),
					new(140, 53, -28, ""),
					new(140, 52, -28, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(462, 82, -22, ""),
					new(140, 52, -25, ""),
					new(140, 53, -25, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(129, 118, -28, ""),
					new(136, 117, -28, ""),
					new(129, 117, -28, ""),
					new(136, 118, -28, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(140, 52, -22, ""),
					new(140, 53, -22, ""),
					new(139, 52, -22, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1767, "Facing=EastCCW", new DecorationEntry[]
				{
					new(267, 87, -28, ""),
					new(273, 87, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW", new DecorationEntry[]
				{
					new(104, 35, -28, ""),
					new(249, 80, -28, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(248, 80, -28, ""),
					new(103, 35, -28, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "Hue=0x849", new DecorationEntry[]
				{
					new(274, 141, -18, ""),
				}),
				new("Ring", typeof(Static), 7945, "", new DecorationEntry[]
				{
					new(136, 108, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8173, "Facing=WestCW", new DecorationEntry[]
				{
					new(100, 29, -28, ""),
					new(161, 14, -27, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "Hue=0x847", new DecorationEntry[]
				{
					new(272, 141, -18, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8175, "Facing=EastCCW", new DecorationEntry[]
				{
					new(162, 14, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8183, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(231, 138, -28, ""),
					new(231, 131, -28, ""),
					new(231, 122, -28, ""),
					new(231, 116, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8187, "Facing=NorthCW", new DecorationEntry[]
				{
					new(240, 138, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8185, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(240, 139, -28, ""),
				}),
				new("Stone Pavers", typeof(Static), 1308, "", new DecorationEntry[]
				{
					new(426, 113, -28, ""),
					new(428, 113, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1775, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(264, 95, -28, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1773, "Facing=SouthCW", new DecorationEntry[]
				{
					new(264, 96, -28, ""),
				}),
				new("Skinning Knife", typeof(Static), 3781, "", new DecorationEntry[]
				{
					new(174, 41, -28, ""),
				}),
				new("Iron Maiden", typeof(Static), 4683, "", new DecorationEntry[]
				{
					new(146, 7, -28, ""),
				}),
				new("Death Vortex", typeof(Static), 14232, "Hue=0x455", new DecorationEntry[]
				{
					new(232, 45, -28, ""),
				}),
				new("Bottle", typeof(Static), 3844, "", new DecorationEntry[]
				{
					new(238, 42, -22, ""),
				}),
				new("Bottle", typeof(Static), 3837, "", new DecorationEntry[]
				{
					new(239, 42, -22, ""),
				}),
				new("Death Vortex", typeof(Static), 14232, "Hue=0x59B", new DecorationEntry[]
				{
					new(232, 54, -28, ""),
				}),
				new("Death Vortex", typeof(Static), 14232, "Hue=0x84A", new DecorationEntry[]
				{
					new(246, 45, -28, ""),
				}),
				new("Death Vortex", typeof(Static), 14232, "Hue=0x66D", new DecorationEntry[]
				{
					new(246, 54, -28, ""),
				}),
				
				#endregion
			});
		}
	}
}
