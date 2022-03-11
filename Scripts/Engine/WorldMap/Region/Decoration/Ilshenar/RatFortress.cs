using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Ratfortress { get; } = Register(DecorationTarget.Ilshenar, "Rat Fortress", new DecorationList[]
			{
				#region Entries
				
				new("Metal Door", typeof(MetalDoor), 1653, "Facing=WestCW", new DecorationEntry[]
				{
					new(642, 843, -54, ""),
					new(645, 830, -44, ""),
				}),
				new("Metal Door", typeof(MetalDoor), 1655, "Facing=EastCCW", new DecorationEntry[]
				{
					new(637, 816, -44, ""),
					new(643, 843, -54, ""),
				}),
				new("Rattan Door", typeof(RattanDoor), 1687, "Facing=EastCCW", new DecorationEntry[]
				{
					new(646, 830, -44, ""),
				}),
				new("Wooden Door", typeof(StrongWoodDoor), 1767, "Facing=EastCCW", new DecorationEntry[]
				{
					new(646, 816, -44, ""),
				}),
				
				#endregion
			});
		}
	}
}
