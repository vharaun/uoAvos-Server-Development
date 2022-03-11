using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Regvolom { get; } = Register(DecorationTarget.Ilshenar, "Reg Volom", new DecorationList[]
			{
				#region Entries
				
				new("Metal Box", typeof(MetalBox), 2472, "Hue=0x96E", new DecorationEntry[]
				{
					new(1349, 1030, -5, ""),
				}),
				new("Marble Floor", typeof(Static), 1297, "Hue=0x1", new DecorationEntry[]
				{
					new(1362, 1031, -13, ""),
					new(1363, 1031, -13, ""),
					new(1364, 1031, -13, ""),
				}),
				new("Bottle", typeof(Static), 3840, "", new DecorationEntry[]
				{
					new(1378, 1049, -12, ""),
				}),
				new("Sandstone Stairs", typeof(Static), 1903, "Hue=0x961", new DecorationEntry[]
				{
					new(1980, 1107, -18, ""),
					new(1981, 1107, -18, ""),
					new(1982, 1107, -18, ""),
					new(1983, 1107, -18, ""),
					new(1984, 1107, -18, ""),
				}),
				
				#endregion
			});
		}
	}
}
