using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Camps { get; } = Register(DecorationTarget.Ilshenar, "Camps", new DecorationList[]
			{
				#region Entries
				
				new("Wooden Gate", typeof(LightWoodGate), 2105, "Facing=WestCW", new DecorationEntry[]
				{
					new(1234, 543, -6, ""),
					new(1253, 588, -11, ""),
					new(1400, 433, -6, ""),
				}),
				new("Wooden Gate", typeof(LightWoodGate), 2107, "Facing=EastCCW", new DecorationEntry[]
				{
					new(1235, 543, -6, ""),
					new(1254, 588, -11, ""),
					new(1401, 433, -6, ""),
				}),
				new("Wooden Gate", typeof(LightWoodGate), 2113, "Facing=SouthCW", new DecorationEntry[]
				{
					new(1227, 555, -11, ""),
					new(1395, 441, 13, ""),
				}),
				new("Wooden Gate", typeof(LightWoodGate), 2115, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(1227, 554, -11, ""),
					new(1395, 440, 13, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2162, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(1229, 563, -19, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2150, "Facing=WestCW", new DecorationEntry[]
				{
					new(1390, 432, -16, ""),
				}),
				new("Bag", typeof(Bag), 3702, "Hue=0x10", new DecorationEntry[]
				{
					new(1391, 439, 19, ""),
				}),
				new("Flowstone", typeof(Static), 2274, "", new DecorationEntry[]
				{
					new(1237, 582, -19, ""),
					new(1237, 586, -19, ""),
				}),
				new("Pickaxe", typeof(Static), 3717, "", new DecorationEntry[]
				{
					new(1238, 580, -19, ""),
				}),
				new("Pickaxe", typeof(Static), 3718, "", new DecorationEntry[]
				{
					new(1239, 586, -19, ""),
				}),
				new("Anvil", typeof(AnvilEastAddon), 4015, "", new DecorationEntry[]
				{
					new(1260, 583, -19, ""),
				}),
				new("Tapestry", typeof(Static), 4067, "Hue=0x1;Name=a cave entrance", new DecorationEntry[]
				{
					new(1237, 585, -22, ""),
				}),
				new("Tapestry", typeof(Static), 4068, "Hue=0x1;Name=a cave entrance", new DecorationEntry[]
				{
					new(1237, 583, -22, ""),
				}),
				new("Boulder", typeof(Static), 4949, "", new DecorationEntry[]
				{
					new(1237, 585, 5, ""),
				}),
				new("Boulder", typeof(Static), 4950, "", new DecorationEntry[]
				{
					new(1237, 584, 5, ""),
				}),
				new("Boulder", typeof(Static), 4961, "", new DecorationEntry[]
				{
					new(1236, 586, -6, ""),
				}),
				new("Boulder", typeof(Static), 4962, "", new DecorationEntry[]
				{
					new(1237, 586, -6, ""),
				}),
				new("Rock", typeof(Static), 4963, "", new DecorationEntry[]
				{
					new(1237, 582, -1, ""),
				}),
				new("Rock", typeof(Static), 4964, "", new DecorationEntry[]
				{
					new(1237, 583, 4, ""),
				}),
				new("Rock", typeof(Static), 4971, "", new DecorationEntry[]
				{
					new(1237, 583, 1, ""),
				}),
				new("Rocks", typeof(Static), 4973, "", new DecorationEntry[]
				{
					new(1237, 586, 1, ""),
				}),
				new("Rock", typeof(Static), 6002, "", new DecorationEntry[]
				{
					new(1237, 583, 1, ""),
				}),
				new("Rock", typeof(Static), 6003, "", new DecorationEntry[]
				{
					new(1237, 585, 0, ""),
				}),
				new("Rock", typeof(Static), 6005, "", new DecorationEntry[]
				{
					new(1237, 585, 4, ""),
					new(1237, 586, 3, ""),
				}),
				new("Rock", typeof(Static), 6007, "", new DecorationEntry[]
				{
					new(1236, 584, -1, ""),
				}),
				new("Bellows", typeof(Static), 6522, "", new DecorationEntry[]
				{
					new(1258, 585, -19, ""),
				}),
				new("Forge", typeof(Static), 6526, "Light=Circle300", new DecorationEntry[]
				{
					new(1259, 585, -19, ""),
				}),
				new("Forge", typeof(Static), 6530, "", new DecorationEntry[]
				{
					new(1260, 585, -19, ""),
				}),
				new("Nodraw--Surface", typeof(Static), 8600, "", new DecorationEntry[]
				{
					new(1139, 592, -80, ""),
					new(1140, 592, -80, ""),
					new(1141, 592, -80, ""),
					new(1142, 592, -80, ""),
				}),
				
				#endregion
			});
		}
	}
}
