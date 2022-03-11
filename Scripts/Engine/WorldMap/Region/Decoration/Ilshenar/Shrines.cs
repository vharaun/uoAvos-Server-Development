using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Shrines { get; } = Register(DecorationTarget.Ilshenar, "Shrines", new DecorationList[]
			{
				#region Entries
				
				new("Compassion", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(1209, 476, -14, ""),
				}),
				new("Honesty", typeof(AnkhNorth), 4, "", new DecorationEntry[]
				{
					new(718, 1350, -55, ""),
				}),
				new("Humility", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(286, 1013, 5, ""),
				}),
				new("Justice", typeof(AnkhNorth), 4, "", new DecorationEntry[]
				{
					new(986, 996, -22, ""),
				}),
				new("Sacrifice", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(1170, 1287, -30, ""),
				}),
				new("Spirituality", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(1525, 1340, 4, ""),
				}),
				new("Valor", typeof(AnkhNorth), 4, "", new DecorationEntry[]
				{
					new(524, 211, -49, ""),
					new(532, 211, -44, ""),
				}),
				
				#endregion
			});
		}
	}
}
