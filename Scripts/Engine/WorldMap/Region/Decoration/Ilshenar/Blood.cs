using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Blood { get; } = Register(DecorationTarget.Ilshenar, "Blood", new DecorationList[]
			{
				#region Entries
				
				new("Stone Pavers", typeof(Static), 1313, "Hue=0x1", new DecorationEntry[]
				{
					new(1745, 1236, -30, ""),
					new(1746, 1236, -30, ""),
					new(1747, 1236, -30, ""),
					new(1748, 1236, -30, ""),
				}),
				new("Studded Gloves", typeof(Static), 5077, "", new DecorationEntry[]
				{
					new(2057, 937, -28, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(2051, 932, -23, ""),
					new(2051, 933, -23, ""),
					new(2153, 907, -23, ""),
					new(2153, 917, -23, ""),
					new(2177, 932, -23, ""),
					new(2051, 931, -23, ""),
					new(2075, 906, -23, ""),
					new(2075, 907, -23, ""),
					new(2075, 908, -23, ""),
					new(2075, 917, -23, ""),
					new(2075, 918, -23, ""),
					new(2075, 919, -23, ""),
					new(2153, 906, -23, ""),
					new(2153, 908, -23, ""),
					new(2153, 918, -23, ""),
					new(2153, 919, -23, ""),
					new(2177, 931, -23, ""),
					new(2177, 933, -23, ""),
				}),
				new("Bones", typeof(Static), 3794, "", new DecorationEntry[]
				{
					new(2110, 903, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8183, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(2046, 835, -28, ""),
					new(2046, 841, -28, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor2), 8175, "Facing=EastCCW", new DecorationEntry[]
				{
					new(2048, 832, -28, ""),
					new(2052, 832, -28, ""),
					new(2056, 832, -28, ""),
					new(2172, 832, -28, ""),
					new(2176, 832, -28, ""),
					new(2180, 832, -28, ""),
					new(2184, 832, -28, ""),
				}),
				new("Stone Stairs", typeof(Static), 1929, "Hue=0x96C", new DecorationEntry[]
				{
					new(2112, 829, -13, ""),
					new(2113, 829, -13, ""),
					new(2114, 829, -13, ""),
					new(2115, 829, -13, ""),
					new(2116, 829, -13, ""),
				}),
				
				#endregion
			});
		}
	}
}
