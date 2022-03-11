using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Gwenno { get; } = Register(DecorationTarget.Ilshenar, "Gwenno", new DecorationList[]
			{
				#region Entries
				
				new("No Draw", typeof(Static), 8612, "", new DecorationEntry[]
				{
					new(752, 492, -64, ""),
					new(757, 493, -64, ""),
					new(753, 492, -64, ""),
					new(755, 492, -64, ""),
					new(756, 492, -64, ""),
					new(757, 492, -64, ""),
					new(752, 493, -64, ""),
					new(757, 490, -64, ""),
					new(753, 493, -64, ""),
					new(754, 493, -64, ""),
					new(755, 493, -64, ""),
					new(752, 491, -64, ""),
					new(754, 491, -64, ""),
					new(755, 490, -64, ""),
					new(753, 491, -64, ""),
					new(756, 490, -64, ""),
					new(752, 489, -64, ""),
					new(753, 489, -64, ""),
					new(756, 493, -64, ""),
					new(755, 489, -64, ""),
					new(756, 489, -64, ""),
					new(757, 489, -64, ""),
					new(754, 489, -64, ""),
					new(755, 491, -64, ""),
					new(752, 490, -64, ""),
					new(754, 490, -64, ""),
					new(756, 491, -64, ""),
					new(753, 490, -64, ""),
					new(757, 491, -64, ""),
					new(754, 492, -64, ""),
				}),
				new("Memorial To Gwenno", typeof(Static), 4485, "Name=In loving memory of Gwenno - You were my muse: I am your legacy.", new DecorationEntry[]
				{
					new(753, 493, -64, ""),
				}),
				new("Memorial To Gwenno", typeof(Static), 4486, "Name=In loving memory of Gwenno - You were my muse: I am your legacy.", new DecorationEntry[]
				{
					new(755, 493, -64, ""),
				}),
				new("Memorial To Gwenno", typeof(Static), 4487, "Name=In loving memory of Gwenno - You were my muse: I am your legacy.", new DecorationEntry[]
				{
					new(756, 492, -64, ""),
				}),
				new("Rock", typeof(Static), 6002, "", new DecorationEntry[]
				{
					new(745, 488, -66, ""),
					new(746, 488, -66, ""),
				}),
				new("Rock", typeof(Static), 6001, "", new DecorationEntry[]
				{
					new(745, 489, -66, ""),
					new(746, 489, -66, ""),
				}),
				new("Memorial To Gwenno", typeof(Static), 4489, "Name=In loving memory of Gwenno - You were my muse: I am your legacy.", new DecorationEntry[]
				{
					new(757, 489, -64, ""),
				}),
				new("Memorial To Gwenno", typeof(Static), 4488, "Name=In loving memory of Gwenno - You were my muse: I am your legacy.", new DecorationEntry[]
				{
					new(757, 491, -64, ""),
				}),
				
				#endregion
			});
		}
	}
}
