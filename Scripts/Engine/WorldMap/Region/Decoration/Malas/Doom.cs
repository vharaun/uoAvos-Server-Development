using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Malas
		{
			public static DecorationList[] Doom { get; } = Register(DecorationTarget.Malas, "Doom", new DecorationList[]
			{
				#region Entries
				
				new("Pedestal", typeof(Static), 7978, "", new DecorationEntry[]
				{
					new(467, 92, -1, ""),
				}),
				new("Alchemical Symbol", typeof(Static), 6173, "Hue=0x482", new DecorationEntry[]
				{
					new(468, 92, -1, ""),
				}),
				new("Alchemical Symbol", typeof(Static), 6177, "Hue=0x3FD", new DecorationEntry[]
				{
					new(469, 92, -1, ""),
				}),
				new("Alchemical Symbol", typeof(Static), 6181, "Hue=0x66D", new DecorationEntry[]
				{
					new(470, 92, -1, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1661, "Facing=SouthCW", new DecorationEntry[]
				{
					new(269, 74, -1, ""),
					new(278, 96, -1, ""),
					new(334, 15, -1, ""),
					new(344, 15, -1, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(269, 73, -1, ""),
					new(278, 95, -1, ""),
					new(334, 14, -1, ""),
					new(344, 14, -1, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(308, 88, -1, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW", new DecorationEntry[]
				{
					new(309, 88, -1, ""),
				}),
				new("Lever", typeof(Static), 4236, "Hue=0x83E", new DecorationEntry[]
				{
					new(307, 143, 5, ""),
				}),
				new("Lever", typeof(Static), 4245, "Hue=0x83F", new DecorationEntry[]
				{
					new(308, 143, 5, ""),
				}),
				new("Lever", typeof(Static), 4245, "Hue=0x843", new DecorationEntry[]
				{
					new(309, 143, 5, ""),
					new(308, 146, 8, ""),
				}),
				new("Lever", typeof(Static), 4243, "Hue=0x845", new DecorationEntry[]
				{
					new(310, 143, 5, ""),
				}),
				new("Lever", typeof(Static), 4236, "Hue=0x83D", new DecorationEntry[]
				{
					new(307, 144, 5, ""),
				}),
				new("Lever", typeof(Static), 4238, "Hue=0x83E", new DecorationEntry[]
				{
					new(307, 145, 5, ""),
					new(311, 144, 9, ""),
				}),
				new("Lever", typeof(Static), 4243, "Hue=0x835", new DecorationEntry[]
				{
					new(309, 146, 8, ""),
				}),
				new("Lever", typeof(Static), 4243, "Hue=0x83B", new DecorationEntry[]
				{
					new(310, 146, 8, ""),
				}),
				new("Lever", typeof(Static), 4236, "Hue=0x845", new DecorationEntry[]
				{
					new(311, 145, 9, ""),
				}),
				new("Crumbling Floor", typeof(FireColumnTrap), 4549, "Hue=0x455", new DecorationEntry[]
				{
					new(2347, 1264, -110, ""),
					new(2347, 1271, -110, ""),
					new(2340, 1272, -110, ""),
					new(2340, 1264, -110, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1665, "Hue=0x455;Facing=SouthCCW", new DecorationEntry[]
				{
					new(2333, 1269, -110, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1663, "Hue=0x455;Facing=NorthCW", new DecorationEntry[]
				{
					new(2333, 1268, -110, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4512, "", new DecorationEntry[]
				{
					new(378, 140, 1, ""),
					new(378, 139, 2, ""),
					new(379, 140, -1, ""),
					new(384, 138, 4, ""),
					new(385, 138, -2, ""),
				}),
				new("Iron Gate", typeof(IronGate), 2092, "Facing=SouthCW", new DecorationEntry[]
				{
					new(351, 40, -1, ""),
				}),
				new("Switch", typeof(Static), 4239, "", new DecorationEntry[]
				{
					new(351, 47, 10, ""),
				}),
				new("Skinning Knife", typeof(Static), 3780, "", new DecorationEntry[]
				{
					new(445, 15, 5, ""),
					new(445, 15, 6, ""),
					new(453, 15, 5, ""),
					new(452, 16, 5, ""),
				}),
				new("Skinning Knife", typeof(Static), 3781, "", new DecorationEntry[]
				{
					new(444, 16, 5, ""),
					new(449, 16, 5, ""),
					new(449, 16, 6, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4506, "", new DecorationEntry[]
				{
					new(379, 139, 0, ""),
					new(383, 138, 3, ""),
					new(383, 140, -2, ""),
					new(386, 144, -1, ""),
				}),
				new("Empty Tub", typeof(Static), 3715, "", new DecorationEntry[]
				{
					new(385, 28, -1, ""),
					new(387, 28, -1, ""),
				}),
				new("Iron Gate", typeof(IronGateShort), 2124, "Facing=WestCW", new DecorationEntry[]
				{
					new(391, 29, -1, ""),
				}),
				
				#endregion
			});
		}
	}
}
