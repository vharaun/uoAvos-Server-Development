using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] BucsPortal { get; } = Register(DecorationTarget.Britannia, "Bucs Portal", new DecorationList[]
			{
				#region Entries
				
				new("", typeof(Teleporter), 7107, "PointDest=(2727, 2133, 5)", new DecorationEntry[]
				{
					new(2618, 977, 5, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(2618, 977, 5)", new DecorationEntry[]
				{
					new(2727, 2133, 5, ""),
				}),
				new("Sign", typeof(Static), 3024, "Name=to the Mainland", new DecorationEntry[]
				{
					new(2728, 2133, 25, ""),
				}),
				new("Stone", typeof(Static), 1822, "", new DecorationEntry[]
				{
					new(2726, 2133, 0, ""),
					new(2727, 2131, 0, ""),
					new(2727, 2131, 5, ""),
					new(2727, 2131, 10, ""),
					new(2727, 2131, 15, ""),
					new(2727, 2131, 20, ""),
					new(2727, 2131, 25, ""),
					new(2727, 2132, 0, ""),
					new(2727, 2132, 30, ""),
					new(2727, 2133, 0, ""),
					new(2727, 2133, 30, ""),
					new(2727, 2133, 35, ""),
					new(2727, 2134, 0, ""),
					new(2727, 2134, 30, ""),
					new(2727, 2135, 0, ""),
					new(2727, 2135, 5, ""),
					new(2727, 2135, 10, ""),
					new(2727, 2135, 15, ""),
					new(2727, 2135, 20, ""),
					new(2727, 2135, 25, ""),
					new(2728, 2133, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1823, "", new DecorationEntry[]
				{
					new(2727, 2134, 35, ""),
					new(2727, 2135, 30, ""),
				}),
				new("Stone Stairs", typeof(Static), 1847, "", new DecorationEntry[]
				{
					new(2727, 2131, 30, ""),
					new(2727, 2132, 35, ""),
				}),
				new("Stone Stairs", typeof(Static), 1952, "", new DecorationEntry[]
				{
					new(2726, 2132, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1953, "", new DecorationEntry[]
				{
					new(2728, 2134, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1954, "", new DecorationEntry[]
				{
					new(2728, 2132, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 2010, "", new DecorationEntry[]
				{
					new(2726, 2134, 0, ""),
				}),
				new("Sign", typeof(Static), 3023, "Name=to Buccaneer's Den", new DecorationEntry[]
				{
					new(2618, 978, 25, ""),
				}),
				new("Stone", typeof(Static), 1955, "", new DecorationEntry[]
				{
					new(2616, 977, 0, ""),
					new(2616, 977, 5, ""),
					new(2616, 977, 10, ""),
					new(2616, 977, 15, ""),
					new(2616, 977, 20, ""),
					new(2616, 977, 25, ""),
					new(2617, 977, 0, ""),
					new(2617, 977, 30, ""),
					new(2618, 977, 0, ""),
					new(2618, 977, 30, ""),
					new(2618, 977, 35, ""),
					new(2619, 977, 0, ""),
					new(2619, 977, 30, ""),
					new(2620, 977, 0, ""),
					new(2620, 977, 5, ""),
					new(2620, 977, 10, ""),
					new(2620, 977, 15, ""),
					new(2620, 977, 20, ""),
					new(2620, 977, 25, ""),
				}),
				new("Stone Stairs", typeof(Static), 1956, "", new DecorationEntry[]
				{
					new(2617, 978, 0, ""),
					new(2618, 978, 0, ""),
					new(2619, 978, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1957, "", new DecorationEntry[]
				{
					new(2619, 977, 35, ""),
					new(2620, 977, 30, ""),
				}),
				new("Stone Stairs", typeof(Static), 1958, "", new DecorationEntry[]
				{
					new(2617, 976, 0, ""),
					new(2618, 976, 0, ""),
					new(2619, 976, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1959, "", new DecorationEntry[]
				{
					new(2616, 977, 30, ""),
					new(2617, 977, 35, ""),
				}),
				new("Stone Stairs", typeof(Static), 1960, "", new DecorationEntry[]
				{
					new(2616, 976, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1961, "", new DecorationEntry[]
				{
					new(2620, 978, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1962, "", new DecorationEntry[]
				{
					new(2620, 976, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1963, "", new DecorationEntry[]
				{
					new(2616, 978, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
