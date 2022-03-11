using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Shrines { get; } = Register(DecorationTarget.Britannia, "Shrines", new DecorationList[]
			{
				#region Entries
				
				new("Chaos", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(1456, 843, 5, ""),
				}),
				new("", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(1457, 841, 0, ""),
					new(1457, 846, 0, ""),
				}),
				new("", typeof(Static), 1928, "", new DecorationEntry[]
				{
					new(1456, 843, 0, ""),
					new(1456, 844, 0, ""),
					new(1457, 843, 0, ""),
					new(1457, 844, 0, ""),
					new(1458, 843, 0, ""),
					new(1458, 844, 0, ""),
				}),
				new("", typeof(Static), 1929, "", new DecorationEntry[]
				{
					new(1456, 845, 0, ""),
					new(1457, 845, 0, ""),
					new(1458, 845, 0, ""),
				}),
				new("", typeof(Static), 1930, "", new DecorationEntry[]
				{
					new(1459, 843, 0, ""),
					new(1459, 844, 0, ""),
				}),
				new("", typeof(Static), 1931, "", new DecorationEntry[]
				{
					new(1456, 842, 0, ""),
					new(1457, 842, 0, ""),
					new(1458, 842, 0, ""),
				}),
				new("", typeof(Static), 1934, "", new DecorationEntry[]
				{
					new(1459, 845, 0, ""),
				}),
				new("", typeof(Static), 1935, "", new DecorationEntry[]
				{
					new(1459, 842, 0, ""),
				}),
				new("", typeof(Static), 5347, "", new DecorationEntry[]
				{
					new(1457, 843, 5, ""),
				}),
				new("", typeof(Static), 5348, "", new DecorationEntry[]
				{
					new(1457, 844, 5, ""),
				}),
				new("", typeof(Static), 5349, "", new DecorationEntry[]
				{
					new(1458, 844, 5, ""),
				}),
				new("", typeof(Static), 5350, "", new DecorationEntry[]
				{
					new(1458, 843, 5, ""),
				}),
				new("Compassion", typeof(AnkhNorth), 4, "", new DecorationEntry[]
				{
					new(1857, 877, -1, ""),
				}),
				new("Honesty (Locations Unconfirmed)", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(4208, 561, 42, ""),
					new(4208, 565, 42, ""),
				}),
				new("Humility (Location Unconfirmed)", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(4272, 3696, 0, ""),
				}),
				new("Honor", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(1723, 3527, 8, ""),
				}),
				new("Justice", typeof(AnkhNorth), 4, "", new DecorationEntry[]
				{
					new(1300, 629, 21, ""),
				}),
				new("Valor (Location Unconfirmed)", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(2489, 3930, 2, ""),
				}),
				new("Sacrifice", typeof(AnkhNorth), 7773, "Bloodied", new DecorationEntry[]
				{
					new(3354, 287, 4, ""),
				}),
				new("Spirituality", typeof(AnkhWest), 3, "", new DecorationEntry[]
				{
					new(1592, 2489, 20, ""),
				}),
				new("", typeof(Static), 219, "", new DecorationEntry[]
				{
					new(1588, 2488, 5, ""),
				}),
				new("", typeof(Static), 1802, "", new DecorationEntry[]
				{
					new(1594, 2491, 15, ""),
					new(1595, 2491, 15, ""),
				}),
				new("", typeof(Static), 1803, "", new DecorationEntry[]
				{
					new(1600, 2489, 10, ""),
					new(1600, 2490, 10, ""),
					new(1596, 2489, 15, ""),
					new(1596, 2490, 15, ""),
				}),
				new("", typeof(Static), 1804, "", new DecorationEntry[]
				{
					new(1594, 2488, 15, ""),
					new(1595, 2488, 15, ""),
				}),
				new("", typeof(Static), 1806, "", new DecorationEntry[]
				{
					new(1593, 2488, 15, ""),
				}),
				new("", typeof(Static), 1807, "", new DecorationEntry[]
				{
					new(1596, 2491, 15, ""),
				}),
				new("", typeof(Static), 1808, "", new DecorationEntry[]
				{
					new(1596, 2488, 15, ""),
				}),
				new("", typeof(Static), 1809, "", new DecorationEntry[]
				{
					new(1593, 2491, 15, ""),
				}),
				new("", typeof(KeywordTeleporter), 7107, "Substring=om om om;Range=0;PointDest=(1595, 2489, 20);SourceEffect=true;DestEffect=true;SoundID=0x1FE;Delay=0:0:1", new DecorationEntry[]
				{
					new(1600, 2489, 12, ""),
				}),
				new("", typeof(KeywordTeleporter), 7107, "Substring=om om om;Range=0;PointDest=(1595, 2490, 20);SourceEffect=true;DestEffect=true;SoundID=0x1FE;Delay=0:0:1", new DecorationEntry[]
				{
					new(1600, 2490, 12, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1600, 2489, 12)", new DecorationEntry[]
				{
					new(1593, 2488, 17, ""),
					new(1594, 2488, 17, ""),
					new(1595, 2488, 17, ""),
				}),
				
				#endregion
			});
		}
	}
}
