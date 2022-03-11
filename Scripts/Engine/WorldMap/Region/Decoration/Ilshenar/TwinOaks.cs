using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] TwinOaks { get; } = Register(DecorationTarget.Ilshenar, "Twin Oaks", new DecorationList[]
			{
				#region Entries
				
				new("Fireplace", typeof(StoneFireplaceEastAddon), 2393, "", new DecorationEntry[]
				{
					new(1547, 1050, -7, ""),
					new(1547, 1050, 13, ""),
				}),
				new("Fireplace", typeof(StoneFireplaceSouthAddon), 2401, "", new DecorationEntry[]
				{
					new(1556, 1038, 13, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(1549, 1040, -1, ""),
				}),
				new("Clock", typeof(Static), 4171, "", new DecorationEntry[]
				{
					new(1548, 1051, 8, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1703, "Facing=EastCCW", new DecorationEntry[]
				{
					new(1549, 1048, 13, ""),
					new(1556, 1048, 13, ""),
					new(1562, 1048, 13, ""),
				}),
				new("Wooden Door", typeof(DarkWoodDoor), 1707, "Facing=EastCW", new DecorationEntry[]
				{
					new(1556, 1043, 13, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1775, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(1565, 1046, -7, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1773, "Facing=SouthCW", new DecorationEntry[]
				{
					new(1565, 1047, -7, ""),
				}),
				new("Dartboard", typeof(DartBoard), 7727, "", new DecorationEntry[]
				{
					new(1547, 1046, -7, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(1549, 1040, -4, ""),
					new(1549, 1040, -7, ""),
					new(1549, 1051, -27, ""),
					new(1549, 1052, -27, ""),
					new(1549, 1052, -24, ""),
				}),
				new("Dartboard W/Knives", typeof(Static), 7731, "", new DecorationEntry[]
				{
					new(1547, 1048, -7, ""),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(1549, 1049, -27, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2612, "", new DecorationEntry[]
				{
					new(1553, 1049, 13, ""),
				}),
				new("Armoire", typeof(Armoire), 2643, "", new DecorationEntry[]
				{
					new(1553, 1052, 13, ""),
					new(1560, 1054, 13, ""),
				}),
				new("Dresser", typeof(Static), 2621, "", new DecorationEntry[]
				{
					new(1558, 1038, 13, ""),
				}),
				new("Dresser", typeof(Static), 2620, "", new DecorationEntry[]
				{
					new(1559, 1038, 13, ""),
				}),
				new("Armoire", typeof(FancyArmoire), 2637, "", new DecorationEntry[]
				{
					new(1561, 1038, 13, ""),
				}),
				new("Bottle Of Liquor", typeof(BeverageBottle), 2459, "Content=Liquor", new DecorationEntry[]
				{
					new(1555, 1052, -21, ""),
				}),
				new("Chest Of Drawers", typeof(Drawer), 2604, "", new DecorationEntry[]
				{
					new(1564, 1049, 13, ""),
				}),
				new("Tavern", typeof(LocalizedSign), 3011, "LabelNumber=1016410", new DecorationEntry[]
				{
					new(1566, 1049, -6, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(1555, 1041, -7, ""),
				}),
				new("Fireplace", typeof(Static), 2400, "", new DecorationEntry[]
				{
					new(1555, 1038, 13, ""),
				}),
				new("Fireplace", typeof(Static), 2399, "", new DecorationEntry[]
				{
					new(1556, 1038, 13, ""),
				}),
				
				#endregion
			});
		}
	}
}
