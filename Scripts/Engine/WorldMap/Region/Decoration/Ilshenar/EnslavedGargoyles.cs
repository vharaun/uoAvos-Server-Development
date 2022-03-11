using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Enslavedgargs { get; } = Register(DecorationTarget.Ilshenar, "Enslaved Gargoyles", new DecorationList[]
			{
				#region Entries
				
				new("Stalagmites", typeof(Static), 2273, "", new DecorationEntry[]
				{
					new(707, 667, -37, ""),
					new(709, 667, -16, ""),
				}),
				new("Flowstone", typeof(Static), 2274, "", new DecorationEntry[]
				{
					new(708, 667, -38, ""),
				}),
				new("Stalagmites", typeof(Static), 2276, "", new DecorationEntry[]
				{
					new(710, 667, -10, ""),
					new(714, 668, -29, ""),
				}),
				new("Stalagmites", typeof(Static), 2277, "", new DecorationEntry[]
				{
					new(712, 667, -9, ""),
				}),
				new("Flowstone", typeof(Static), 2278, "", new DecorationEntry[]
				{
					new(710, 667, -17, ""),
					new(712, 667, -15, ""),
				}),
				new("Flowstone", typeof(Static), 2280, "", new DecorationEntry[]
				{
					new(712, 667, -38, ""),
					new(713, 667, -37, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(947, 413, -80, ""),
					new(958, 421, -80, ""),
					new(958, 422, -80, ""),
				}),
				new("Forge", typeof(SmallForgeAddon), 4017, "", new DecorationEntry[]
				{
					new(946, 413, -80, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4020, "", new DecorationEntry[]
				{
					new(957, 427, -74, ""),
				}),
				new("Sledge Hammer", typeof(Static), 4021, "", new DecorationEntry[]
				{
					new(955, 415, -74, ""),
				}),
				new("Tapestry", typeof(Static), 4065, "Hue=0x1;Name=a cave entrance", new DecorationEntry[]
				{
					new(709, 667, -42, ""),
				}),
				new("Tapestry", typeof(Static), 4066, "Hue=0x1;Name=a cave entrance", new DecorationEntry[]
				{
					new(710, 667, -42, ""),
					new(711, 667, -42, ""),
				}),
				new("Butcher Knife", typeof(Static), 5110, "", new DecorationEntry[]
				{
					new(864, 468, 7, ""),
				}),
				new("Rock", typeof(Static), 6004, "", new DecorationEntry[]
				{
					new(706, 668, -36, ""),
				}),
				new("Rock", typeof(Static), 6006, "", new DecorationEntry[]
				{
					new(711, 667, -16, ""),
				}),
				new("Bellows", typeof(Static), 6546, "", new DecorationEntry[]
				{
					new(958, 420, -80, ""),
					new(958, 425, -80, ""),
				}),
				new("Forge", typeof(Static), 6550, "", new DecorationEntry[]
				{
					new(958, 419, -80, ""),
					new(958, 424, -80, ""),
				}),
				new("Forge", typeof(Static), 6554, "", new DecorationEntry[]
				{
					new(958, 418, -80, ""),
					new(958, 423, -80, ""),
				}),
				new("Nodraw", typeof(Static), 8600, "", new DecorationEntry[]
				{
					new(911, 451, -80, ""),
					new(911, 452, -80, ""),
					new(911, 453, -80, ""),
				}),
				
				#endregion
			});
		}
	}
}
