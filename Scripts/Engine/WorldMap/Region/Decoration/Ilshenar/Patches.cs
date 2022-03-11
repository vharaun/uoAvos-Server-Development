using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Patches { get; } = Register(DecorationTarget.Ilshenar, "Patches", new DecorationList[]
			{
				#region Entries
				
				new("Invisible Tile, Can Walk Over", typeof(Static), 8600, "", new DecorationEntry[]
				{
					new(827, 777, -80, ""),
					new(828, 777, -80, ""),
					new(829, 777, -80, ""),
					new(827, 778, -80, ""),
					new(828, 778, -80, ""),
					new(829, 778, -80, ""),
					new(827, 779, -80, ""),
					new(828, 779, -80, ""),
					new(829, 779, -80, ""),
					new(1978, 114, -28, ""),
					new(1979, 114, -28, ""),
					new(1980, 114, -28, ""),
					new(1981, 114, -28, ""),
					new(1978, 115, -28, ""),
					new(1979, 115, -28, ""),
					new(1980, 115, -28, ""),
					new(1981, 115, -28, ""),
					new(1978, 116, -28, ""),
					new(1979, 116, -28, ""),
					new(1980, 116, -28, ""),
					new(1981, 116, -28, ""),
					new(1978, 117, -28, ""),
					new(1979, 117, -28, ""),
					new(1980, 117, -28, ""),
					new(1981, 117, -28, ""),
				}),
				
				#endregion
			});
		}
	}
}
