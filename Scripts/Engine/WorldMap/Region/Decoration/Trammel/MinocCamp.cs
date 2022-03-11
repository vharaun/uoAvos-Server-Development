using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Trammel
		{
			public static DecorationList[] MinocCamp { get; } = Register(DecorationTarget.Trammel, "Minoc Camp", new DecorationList[]
			{
				#region Entries
				
				new("Gruesome Standard", typeof(Static), 1055, "", new DecorationEntry[]
				{
					new(2635, 701, 0, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(2629, 701, 0, ""),
					new(2622, 703, 0, ""),
					new(2626, 700, 0, ""),
					new(2625, 706, 0, ""),
					new(2625, 708, 0, ""),
					new(2629, 703, 0, ""),
				}),
				new("Tent Wall", typeof(Static), 747, "Hue=0x33", new DecorationEntry[]
				{
					new(2620, 702, 0, ""),
					new(2622, 707, 0, ""),
					new(2627, 698, 0, ""),
					new(2627, 708, 0, ""),
					new(2620, 702, 1, ""),
				}),
				new("Tent Wall", typeof(Static), 748, "Hue=0x33", new DecorationEntry[]
				{
					new(2621, 701, 0, ""),
					new(2623, 706, 0, ""),
					new(2628, 697, 0, ""),
					new(2628, 707, 0, ""),
					new(2621, 701, 1, ""),
				}),
				new("Skinned Goat", typeof(Static), 7816, "", new DecorationEntry[]
				{
					new(2624, 705, 0, ""),
				}),
				new("Fire Pit", typeof(Static), 4012, "", new DecorationEntry[]
				{
					new(2625, 703, 0, ""),
				}),
				new("Campfire", typeof(Static), 3555, "", new DecorationEntry[]
				{
					new(2625, 703, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(2625, 703, 0, ""),
				}),
				new("Stump", typeof(Static), 3673, "", new DecorationEntry[]
				{
					new(2624, 709, 0, ""),
				}),
				new("Executioner's Axe", typeof(Static), 3910, "", new DecorationEntry[]
				{
					new(2625, 708, 0, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1064, "", new DecorationEntry[]
				{
					new(2626, 711, 0, ""),
				}),
				new("Gruesome Standard", typeof(Static), 1056, "", new DecorationEntry[]
				{
					new(2627, 694, 0, ""),
				}),
				new("Skinned Goat", typeof(Static), 7817, "", new DecorationEntry[]
				{
					new(2631, 696, 0, ""),
				}),
				new("Skinned Deer", typeof(Static), 7824, "", new DecorationEntry[]
				{
					new(2627, 701, 0, ""),
					new(2627, 701, 1, ""),
				}),
				new("Stump", typeof(Static), 3672, "", new DecorationEntry[]
				{
					new(2627, 703, 0, ""),
				}),
				new("Skinned Deer", typeof(Static), 7825, "", new DecorationEntry[]
				{
					new(2627, 705, 0, ""),
				}),
				
				#endregion
			});
		}
	}
}
