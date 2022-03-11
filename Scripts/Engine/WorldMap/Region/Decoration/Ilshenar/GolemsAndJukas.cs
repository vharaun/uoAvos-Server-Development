using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Golemsandjukas { get; } = Register(DecorationTarget.Ilshenar, "Golems And Jukas", new DecorationList[]
			{
				#region Entries
				
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW", new DecorationEntry[]
				{
					new(1089, 707, -80, ""),
					new(1094, 699, -60, ""),
					new(1094, 708, -60, ""),
					new(1103, 704, -80, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(1089, 706, -80, ""),
					new(1094, 707, -60, ""),
					new(1094, 698, -60, ""),
					new(1103, 703, -80, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1741, "Facing=SouthCW", new DecorationEntry[]
				{
					new(1103, 652, -80, ""),
					new(1111, 652, -80, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1743, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(1103, 651, -80, ""),
					new(1111, 651, -80, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1765, "Facing=WestCW", new DecorationEntry[]
				{
					new(1071, 671, -80, ""),
					new(1083, 632, -60, ""),
					new(1083, 658, -80, ""),
					new(1083, 671, -80, ""),
					new(1083, 671, -60, ""),
					new(1096, 671, -80, ""),
					new(1097, 658, -80, ""),
					new(1098, 632, -60, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1767, "Facing=EastCCW", new DecorationEntry[]
				{
					new(1062, 635, -80, ""),
					new(1062, 635, -60, ""),
					new(1062, 635, -40, ""),
					new(1062, 667, -80, ""),
					new(1062, 667, -60, ""),
					new(1062, 667, -40, ""),
					new(1083, 632, -80, ""),
					new(1083, 645, -80, ""),
					new(1096, 632, -80, ""),
					new(1097, 645, -80, ""),
					new(1105, 635, -60, ""),
					new(1105, 668, -80, ""),
					new(1105, 668, -60, ""),
					new(1105, 668, -40, ""),
					new(1105, 635, -80, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1769, "Facing=WestCCW", new DecorationEntry[]
				{
					new(1071, 634, -40, ""),
					new(1074, 669, -40, ""),
					new(1090, 634, -40, ""),
					new(1092, 669, -40, ""),
					new(1092, 679, -40, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1771, "Facing=EastCW", new DecorationEntry[]
				{
					new(1105, 635, -40, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1773, "Facing=SouthCW", new DecorationEntry[]
				{
					new(1064, 651, -80, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1777, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(1067, 630, -80, ""),
					new(1067, 630, -60, ""),
					new(1067, 673, -80, ""),
					new(1067, 673, -60, ""),
					new(1100, 630, -80, ""),
					new(1100, 630, -60, ""),
					new(1100, 673, -80, ""),
					new(1100, 673, -60, ""),
					new(1100, 673, -40, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1779, "Facing=NorthCW", new DecorationEntry[]
				{
					new(1103, 643, -60, ""),
					new(1103, 660, -60, ""),
				}),
				new("Iron Gate", typeof(IronGate), 2092, "Facing=SouthCW", new DecorationEntry[]
				{
					new(1064, 644, -40, ""),
					new(1064, 659, -40, ""),
					new(1081, 644, -40, ""),
					new(1081, 659, -40, ""),
					new(1086, 644, -40, ""),
					new(1086, 659, -40, ""),
					new(1103, 644, -40, ""),
					new(1103, 659, -40, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(1092, 696, -60, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2712, "", new DecorationEntry[]
				{
					new(1086, 703, -80, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(1081, 707, -60, ""),
					new(1081, 708, -80, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(1081, 699, -60, ""),
					new(1081, 704, -80, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(1082, 703, -80, ""),
					new(1088, 696, -60, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2716, "", new DecorationEntry[]
				{
					new(1081, 706, -60, ""),
				}),
				new("Khabur's Journal", typeof(KaburJournal), 4081, "", new DecorationEntry[]
				{
					new(1073, 633, -74, ""),
				}),
				new("Fropoz's Journal", typeof(FropozJournal), 4081, "", new DecorationEntry[]
				{
					new(1084, 707, -74, ""),
				}),
				new("Translated Gargoyle Journal", typeof(TranslatedGargoyleJournal), 4082, "", new DecorationEntry[]
				{
					new(1089, 708, -54, ""),
				}),
				
				#endregion
			});
		}
	}
}
