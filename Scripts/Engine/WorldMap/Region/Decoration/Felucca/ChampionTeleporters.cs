using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Felucca
		{
			public static DecorationList[] ChampionTeleporters { get; } = Register(DecorationTarget.Felucca, "Champion Teleporters", new DecorationList[]
			{
				#region Entries
				
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5814, 3548, 0)", new DecorationEntry[]
				{
					new(5443, 2325, 35, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5522, 3921, 37)", new DecorationEntry[]
				{
					new(5996, 2367, 45, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5958, 2345, 25)", new DecorationEntry[]
				{
					new(6053, 2407, 27, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(6089, 2400, 24)", new DecorationEntry[]
				{
					new(6080, 2340, 26, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5972, 2418, 26)", new DecorationEntry[]
				{
					new(5503, 3971, 40, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5490, 2348, 20)", new DecorationEntry[]
				{
					new(5731, 3420, 14, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5606, 802, 60)", new DecorationEntry[]
				{
					new(5265, 683, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5876, 1378, 0)", new DecorationEntry[]
				{
					new(5265, 669, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5164, 1009, 0)", new DecorationEntry[]
				{
					new(5506, 814, 60, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5201, 1564, 0)", new DecorationEntry[]
				{
					new(5506, 817, 60, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5201, 1564, 0)", new DecorationEntry[]
				{
					new(5145, 973, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5331, 707, 0)", new DecorationEntry[]
				{
					new(5140, 973, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5606, 802, 60)", new DecorationEntry[]
				{
					new(5682, 1440, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5164, 1009, 0)", new DecorationEntry[]
				{
					new(5682, 1437, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5977, 169, 0)", new DecorationEntry[]
				{
					new(5905, 97, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5876, 1378, 0)", new DecorationEntry[]
				{
					new(5360, 1540, 0, ""),
				}),
				new("Teleporter", typeof(Teleporter), 7107, "PointDest=(5331, 707, 0)", new DecorationEntry[]
				{
					new(5356, 1540, 0, ""),
				}),
				new("Sparkle", typeof(Static), 14170, "", new DecorationEntry[]
				{
					new(5443, 2325, 34, ""),
					new(5996, 2367, 45, ""),
					new(6053, 2407, 27, ""),
					new(6080, 2340, 26, ""),
					new(5503, 3971, 40, ""),
					new(5731, 3420, 14, ""),
					new(5265, 683, 0, ""),
					new(5265, 669, 0, ""),
					new(5506, 814, 60, ""),
					new(5506, 817, 60, ""),
					new(5145, 973, 0, ""),
					new(5140, 973, 0, ""),
					new(5682, 1440, 0, ""),
					new(5682, 1437, 0, ""),
					new(5905, 97, 0, ""),
					new(5360, 1540, 0, ""),
					new(5356, 1540, 0, ""),
				}),
				new("Sparkle", typeof(Static), 14154, "", new DecorationEntry[]
				{
					new(5682, 1437, 5, ""),
				}),
				
				#endregion
			});
		}
	}
}
