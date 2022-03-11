using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] SerpentPillars { get; } = Register(DecorationTarget.Britannia, "Serpent Pillars", new DecorationList[]
			{
				#region Entries
				
				new("Serpent Pillars", typeof(SerpentPillar), 9023, "Word=doracron;DestStart=(5922, 2645);DestEnd=(6022, 2745)", new DecorationEntry[]
				{
					new(2983, 2888, -5, ""),
				}),
				new("", typeof(SerpentPillar), 9023, "Word=sueacron;DestStart=(2933, 2838);DestEnd=(3033, 2938)", new DecorationEntry[]
				{
					new(5972, 2695, -5, ""),
				}),
				new("", typeof(SerpentPillar), 9023, "Word=doracron;DestStart=(5215, 2705);DestEnd=(5315, 2805)", new DecorationEntry[]
				{
					new(422, 3281, -5, ""),
				}),
				new("", typeof(SerpentPillar), 9023, "Word=sueacron;DestStart=(372, 3231);DestEnd=(472, 3331)", new DecorationEntry[]
				{
					new(5265, 2755, -5, ""),
				}),
				
				#endregion
			});
		}
	}
}
