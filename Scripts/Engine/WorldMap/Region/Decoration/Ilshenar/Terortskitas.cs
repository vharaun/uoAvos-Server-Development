using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Terortskitas { get; } = Register(DecorationTarget.Ilshenar, "Terortskitas", new DecorationList[]
			{
				#region Entries
				
				new("Fire", typeof(Static), 6571, "", new DecorationEntry[]
				{
					new(579, 408, 33, ""),
					new(580, 408, 33, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "Hue=0x849", new DecorationEntry[]
				{
					new(555, 425, -13, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "Hue=0x84A", new DecorationEntry[]
				{
					new(556, 425, -13, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "Hue=0x847", new DecorationEntry[]
				{
					new(557, 425, -13, ""),
				}),
				new("Magical Crystal", typeof(Static), 7961, "", new DecorationEntry[]
				{
					new(570, 414, 47, ""),
					new(570, 415, 47, ""),
					new(578, 409, 67, ""),
					new(578, 410, 67, ""),
				}),
				new("Chest Of Drawers", typeof(FancyDrawer), 2616, "", new DecorationEntry[]
				{
					new(572, 412, 41, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2714, "", new DecorationEntry[]
				{
					new(576, 423, 41, ""),
					new(576, 426, 41, ""),
					new(576, 429, 41, ""),
					new(579, 421, 61, ""),
					new(579, 425, 61, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2716, "", new DecorationEntry[]
				{
					new(576, 424, 41, ""),
					new(576, 428, 41, ""),
					new(579, 422, 61, ""),
					new(579, 424, 61, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(576, 425, 41, ""),
					new(576, 427, 41, ""),
					new(576, 430, 41, ""),
					new(579, 423, 61, ""),
					new(579, 426, 61, ""),
				}),
				new("Dresser", typeof(Static), 2621, "", new DecorationEntry[]
				{
					new(577, 408, 41, ""),
				}),
				new("Dresser", typeof(Static), 2620, "", new DecorationEntry[]
				{
					new(578, 408, 41, ""),
				}),
				new("Cactus", typeof(Static), 3366, "Hue=0x847", new DecorationEntry[]
				{
					new(579, 408, 26, ""),
					new(580, 408, 26, ""),
				}),
				new("Book", typeof(Static), 4030, "", new DecorationEntry[]
				{
					new(579, 409, 26, ""),
					new(580, 409, 26, ""),
				}),
				new("Magical Crystal", typeof(Static), 7964, "", new DecorationEntry[]
				{
					new(579, 428, 67, ""),
					new(579, 429, 67, ""),
					new(585, 416, 47, ""),
					new(586, 416, 47, ""),
				}),
				
				#endregion
			});
		}
	}
}
