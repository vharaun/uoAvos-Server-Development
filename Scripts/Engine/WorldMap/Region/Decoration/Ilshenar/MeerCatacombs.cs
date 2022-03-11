using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] MeerCatacombs { get; } = Register(DecorationTarget.Ilshenar, "Meer Catacombs", new DecorationList[]
			{
				#region Entries
				
				new("", typeof(Teleporter), 7107, "PointDest=(1790, 66, -26)", new DecorationEntry[]
				{
					new(1037, 579, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1790, 67, -26)", new DecorationEntry[]
				{
					new(1037, 580, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1790, 68, -26)", new DecorationEntry[]
				{
					new(1037, 581, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1786, 70, -26)", new DecorationEntry[]
				{
					new(1038, 578, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1786, 70, -26)", new DecorationEntry[]
				{
					new(1038, 579, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1786, 65, -26)", new DecorationEntry[]
				{
					new(1038, 581, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1786, 65, -26)", new DecorationEntry[]
				{
					new(1038, 582, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1787, 70, -26)", new DecorationEntry[]
				{
					new(1039, 578, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1787, 65, -26)", new DecorationEntry[]
				{
					new(1039, 582, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1788, 70, -26)", new DecorationEntry[]
				{
					new(1040, 578, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1788, 70, -26)", new DecorationEntry[]
				{
					new(1040, 579, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1788, 65, -26)", new DecorationEntry[]
				{
					new(1040, 581, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1788, 65, -26)", new DecorationEntry[]
				{
					new(1040, 582, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1785, 68, -26)", new DecorationEntry[]
				{
					new(1041, 581, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1785, 67, -26)", new DecorationEntry[]
				{
					new(1041, 580, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1785, 66, -26)", new DecorationEntry[]
				{
					new(1041, 579, -73, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1038, 583, -78)", new DecorationEntry[]
				{
					new(1786, 66, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1042, 579, -78)", new DecorationEntry[]
				{
					new(1786, 67, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1042, 580, -78)", new DecorationEntry[]
				{
					new(1786, 68, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1042, 581, -78)", new DecorationEntry[]
				{
					new(1786, 69, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1039, 583, -78)", new DecorationEntry[]
				{
					new(1787, 66, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1040, 583, -78)", new DecorationEntry[]
				{
					new(1788, 66, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1041, 583, -78)", new DecorationEntry[]
				{
					new(1789, 66, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1038, 577, -78)", new DecorationEntry[]
				{
					new(1787, 69, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1039, 577, -78)", new DecorationEntry[]
				{
					new(1788, 69, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1036, 579, -78)", new DecorationEntry[]
				{
					new(1789, 67, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1036, 578, -78)", new DecorationEntry[]
				{
					new(1789, 68, -26, ""),
				}),
				new("", typeof(Teleporter), 7107, "PointDest=(1036, 581, -78)", new DecorationEntry[]
				{
					new(1789, 69, -26, ""),
				}),
				new("Stone", typeof(Static), 1955, "Hue=0x58F", new DecorationEntry[]
				{
					new(1037, 578, -80, ""),
					new(1037, 579, -80, ""),
					new(1037, 580, -80, ""),
					new(1037, 581, -80, ""),
					new(1037, 582, -80, ""),
					new(1038, 578, -80, ""),
					new(1038, 579, -80, ""),
					new(1038, 580, -80, ""),
					new(1038, 581, -80, ""),
					new(1038, 582, -80, ""),
					new(1039, 578, -80, ""),
					new(1039, 579, -80, ""),
					new(1039, 580, -80, ""),
					new(1039, 581, -80, ""),
					new(1039, 582, -80, ""),
					new(1040, 578, -80, ""),
					new(1040, 579, -80, ""),
					new(1040, 580, -80, ""),
					new(1040, 581, -80, ""),
					new(1040, 582, -80, ""),
					new(1041, 578, -80, ""),
					new(1041, 579, -80, ""),
					new(1041, 580, -80, ""),
					new(1041, 581, -80, ""),
					new(1041, 582, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1956, "Hue=0x58F", new DecorationEntry[]
				{
					new(1037, 583, -80, ""),
					new(1038, 583, -80, ""),
					new(1039, 583, -80, ""),
					new(1040, 583, -80, ""),
					new(1041, 583, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1957, "Hue=0x58F", new DecorationEntry[]
				{
					new(1042, 578, -80, ""),
					new(1042, 579, -80, ""),
					new(1042, 580, -80, ""),
					new(1042, 581, -80, ""),
					new(1042, 582, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1958, "Hue=0x58F", new DecorationEntry[]
				{
					new(1037, 577, -80, ""),
					new(1038, 577, -80, ""),
					new(1039, 577, -80, ""),
					new(1040, 577, -80, ""),
					new(1041, 577, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1959, "Hue=0x58F", new DecorationEntry[]
				{
					new(1036, 578, -80, ""),
					new(1036, 579, -80, ""),
					new(1036, 580, -80, ""),
					new(1036, 581, -80, ""),
					new(1036, 582, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1960, "Hue=0x58F", new DecorationEntry[]
				{
					new(1036, 577, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1961, "Hue=0x58F", new DecorationEntry[]
				{
					new(1042, 583, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1962, "Hue=0x58F", new DecorationEntry[]
				{
					new(1042, 577, -80, ""),
				}),
				new("Stone Stairs", typeof(Static), 1963, "Hue=0x58F", new DecorationEntry[]
				{
					new(1036, 583, -80, ""),
				}),
				new("Platform", typeof(Static), 1981, "Hue=0x40C", new DecorationEntry[]
				{
					new(1037, 580, -75, ""),
					new(1038, 579, -75, ""),
					new(1038, 581, -75, ""),
					new(1039, 578, -75, ""),
					new(1039, 580, -75, ""),
					new(1039, 582, -75, ""),
					new(1040, 579, -75, ""),
					new(1040, 581, -75, ""),
					new(1041, 580, -75, ""),
				}),
				new("Platform", typeof(Static), 1982, "Hue=0x40C", new DecorationEntry[]
				{
					new(1037, 579, -75, ""),
					new(1037, 581, -75, ""),
					new(1038, 578, -75, ""),
					new(1038, 580, -75, ""),
					new(1038, 582, -75, ""),
					new(1039, 579, -75, ""),
					new(1039, 581, -75, ""),
					new(1040, 578, -75, ""),
					new(1040, 580, -75, ""),
					new(1040, 582, -75, ""),
					new(1041, 579, -75, ""),
					new(1041, 581, -75, ""),
				}),
				new("Platform", typeof(Static), 1983, "Hue=0x40C", new DecorationEntry[]
				{
					new(1037, 578, -75, ""),
				}),
				new("Platform", typeof(Static), 1984, "Hue=0x40C", new DecorationEntry[]
				{
					new(1041, 578, -75, ""),
				}),
				new("Platform", typeof(Static), 1985, "Hue=0x40C", new DecorationEntry[]
				{
					new(1037, 582, -75, ""),
				}),
				new("Platform", typeof(Static), 1986, "Hue=0x40C", new DecorationEntry[]
				{
					new(1041, 582, -75, ""),
				}),
				new("Glowing Rune", typeof(Static), 3677, "Hue=0x40C", new DecorationEntry[]
				{
					new(1040, 578, -73, ""),
				}),
				new("Rune", typeof(Static), 3678, "Hue=0x40C", new DecorationEntry[]
				{
					new(1037, 580, -73, ""),
					new(1040, 580, -73, ""),
				}),
				new("Glowing Rune", typeof(Static), 3680, "Hue=0x40C", new DecorationEntry[]
				{
					new(1037, 579, -73, ""),
					new(1038, 581, -73, ""),
					new(1039, 578, -73, ""),
					new(1041, 581, -73, ""),
				}),
				new("Rune", typeof(Static), 3681, "Hue=0x40C", new DecorationEntry[]
				{
					new(1039, 580, -73, ""),
				}),
				new("Glowing Rune", typeof(Static), 3683, "Hue=0x40C", new DecorationEntry[]
				{
					new(1038, 578, -73, ""),
					new(1038, 580, -73, ""),
					new(1039, 582, -73, ""),
					new(1040, 581, -73, ""),
				}),
				new("Rune", typeof(Static), 3684, "Hue=0x40C", new DecorationEntry[]
				{
					new(1041, 579, -73, ""),
				}),
				new("Glowing Rune", typeof(Static), 3686, "Hue=0x40C", new DecorationEntry[]
				{
					new(1040, 582, -73, ""),
				}),
				new("Rune", typeof(Static), 3687, "Hue=0x40C", new DecorationEntry[]
				{
					new(1037, 581, -73, ""),
					new(1039, 579, -73, ""),
					new(1039, 581, -73, ""),
				}),
				new("Glowing Rune", typeof(Static), 3689, "Hue=0x40C", new DecorationEntry[]
				{
					new(1038, 579, -73, ""),
					new(1038, 582, -73, ""),
					new(1040, 579, -73, ""),
					new(1041, 580, -73, ""),
				}),
				new("Glowing Rune", typeof(Static), 3677, "Hue=0x40C", new DecorationEntry[]
				{
					new(1789, 69, -26, ""),
				}),
				new("Rune", typeof(Static), 3678, "Hue=0x40C", new DecorationEntry[]
				{
					new(1788, 67, -26, ""),
				}),
				new("Glowing Rune", typeof(Static), 3680, "Hue=0x40C", new DecorationEntry[]
				{
					new(1786, 68, -26, ""),
					new(1789, 68, -26, ""),
				}),
				new("Rune", typeof(Static), 3681, "Hue=0x40C", new DecorationEntry[]
				{
					new(1787, 67, -26, ""),
				}),
				new("Glowing Rune", typeof(Static), 3683, "Hue=0x40C", new DecorationEntry[]
				{
					new(1786, 67, -26, ""),
					new(1787, 69, -26, ""),
					new(1788, 68, -26, ""),
				}),
				new("Rune", typeof(Static), 3684, "Hue=0x40C", new DecorationEntry[]
				{
					new(1789, 66, -26, ""),
				}),
				new("Glowing Rune", typeof(Static), 3686, "Hue=0x40C", new DecorationEntry[]
				{
					new(1788, 69, -26, ""),
				}),
				new("Rune", typeof(Static), 3687, "Hue=0x40C", new DecorationEntry[]
				{
					new(1787, 66, -26, ""),
					new(1787, 68, -26, ""),
				}),
				new("Glowing Rune", typeof(Static), 3689, "Hue=0x40C", new DecorationEntry[]
				{
					new(1786, 66, -26, ""),
					new(1786, 69, -26, ""),
					new(1788, 66, -26, ""),
					new(1789, 67, -26, ""),
				}),
				
				#endregion
			});
		}
	}
}
