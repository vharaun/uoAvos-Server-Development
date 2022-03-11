using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] Markcontainers { get; } = Register(DecorationTarget.Malas, "Mark Containers", new DecorationList[]
			{
				#region Entries
				
				new("Standard Pouches", typeof(MarkContainer), 3705, "TargetMap=Malas", new DecorationEntry[]
				{
					new(951, 546, -70, "(1006, 994, -70)"),
					new(914, 192, -79, "(1019, 1062, -70)"),
					new(1614, 143, -90, "(1214, 1313, -90)"),
					new(2176, 324, -90, "(1554, 172, -90)"),
					new(864, 812, -90, "(1061, 1161, -70)"),
					new(1326, 523, -87, "(1201, 1554, -70)"),
					new(1313, 1115, -85, "(1183, 462, -45)"),
				}),
				new("Auto-Lock Pouch", typeof(MarkContainer), 3705, "TargetMap=Malas;Locked", new DecorationEntry[]
				{
					new(1051, 1434, -85, "(1076, 1244, -70)"),
				}),
				new("Bone Container", typeof(MarkContainer), 3786, "TargetMap=Malas;Bone", new DecorationEntry[]
				{
					new(424, 189, -1, "(2333, 1501, -90)"),
				}),
				
				#endregion
			});
		}
	}
}
