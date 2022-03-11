using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Vinculuminn { get; } = Register(DecorationTarget.Ilshenar, "Vinculuminn", new DecorationList[]
			{
				#region Entries
				
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(658, 662, -15, ""),
				}),
				new("The Deuce's Vinculum Inn", typeof(LocalizedSign), 3012, "LabelNumber=1016297", new DecorationEntry[]
				{
					new(667, 680, -24, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6227, "Unlit", new DecorationEntry[]
				{
					new(658, 675, -29, ""),
					new(663, 672, -30, ""),
					new(664, 670, -29, ""),
					new(666, 676, -29, ""),
					new(668, 672, -30, ""),
					new(670, 675, -29, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6228, "", new DecorationEntry[]
				{
					new(660, 661, -29, ""),
				}),
				new("Skull With Candle", typeof(CandleSkull), 6231, "Unlit", new DecorationEntry[]
				{
					new(659, 670, -29, ""),
					new(662, 676, -29, ""),
					new(666, 661, -29, ""),
					new(669, 670, -29, ""),
				}),
				
				#endregion
			});
		}
	}
}
