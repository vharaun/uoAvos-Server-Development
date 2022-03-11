using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Serpentine { get; } = Register(DecorationTarget.Ilshenar, "Serpentine", new DecorationList[]
			{
				#region Entries
				
				new("Lute", typeof(Static), 3763, "", new DecorationEntry[]
				{
					new(426, 1557, -23, ""),
				}),
				new("Lap Harp", typeof(Static), 3762, "", new DecorationEntry[]
				{
					new(426, 1558, -23, ""),
				}),
				new("Tambourine", typeof(Static), 3742, "", new DecorationEntry[]
				{
					new(427, 1560, -23, ""),
				}),
				new("Standing Harp", typeof(Static), 3761, "", new DecorationEntry[]
				{
					new(434, 1557, -22, ""),
					new(436, 1557, -22, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Hue=0x8AB;Facing=WestCW", new DecorationEntry[]
				{
					new(478, 1527, -27, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Hue=0x8AB;Facing=EastCCW", new DecorationEntry[]
				{
					new(479, 1527, -27, ""),
				}),
				new("Drum", typeof(Static), 3740, "", new DecorationEntry[]
				{
					new(427, 1557, -23, ""),
				}),
				
				#endregion
			});
		}
	}
}
