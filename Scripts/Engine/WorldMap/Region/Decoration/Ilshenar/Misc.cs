using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Misc { get; } = Register(DecorationTarget.Ilshenar, "Misc", new DecorationList[]
			{
				#region Entries
				
				new("Barrel", typeof(Static), 4014, "", new DecorationEntry[]
				{
					new(387, 1255, -41, ""),
					new(388, 1255, -42, ""),
				}),
				new("A Swarm Of Flies", typeof(SwarmOfFlies), 2331, "", new DecorationEntry[]
				{
					new(1052, 736, -80, ""),
					new(1082, 750, -75, ""),
					new(1088, 759, -80, ""),
					new(1107, 735, -80, ""),
					new(1138, 736, -80, ""),
					new(1156, 767, -80, ""),
					new(1166, 690, -80, ""),
					new(1183, 661, -80, ""),
				}),
				new("Tribal Berry", typeof(TribalBerry), 2512, "", new DecorationEntry[]
				{
					new(1029, 679, -65, ""),
					new(1029, 680, -48, ""),
					new(1029, 681, -60, ""),
					new(1029, 700, -72, ""),
					new(1030, 679, -63, ""),
					new(1030, 700, -50, ""),
					new(1030, 702, -50, ""),
					new(1031, 705, -60, ""),
					new(1032, 712, -39, ""),
					new(1033, 706, -30, ""),
					new(1033, 711, -43, ""),
					new(1033, 712, -40, ""),
					new(1036, 715, -51, ""),
					new(1037, 714, -61, ""),
					new(1037, 715, -62, ""),
					new(1038, 689, -70, ""),
					new(1038, 689, -60, ""),
					new(1038, 709, -56, ""),
					new(1038, 711, -58, ""),
					new(1040, 679, -58, ""),
					new(1040, 680, -66, ""),
					new(1040, 680, -43, ""),
					new(1041, 714, -54, ""),
					new(1041, 715, -60, ""),
					new(1042, 680, -38, ""),
					new(1043, 686, -51, ""),
					new(1043, 687, -63, ""),
					new(1043, 688, -50, ""),
					new(1043, 699, -60, ""),
					new(1043, 701, -60, ""),
					new(1043, 714, -58, ""),
					new(1044, 686, -60, ""),
					new(1044, 686, -57, ""),
					new(1044, 699, -60, ""),
					new(1051, 704, -50, ""),
					new(1051, 705, -22, ""),
					new(1051, 706, -20, ""),
				}),
				new("Fern", typeof(Static), 3231, "", new DecorationEntry[]
				{
					new(1028, 713, -80, ""),
					new(1034, 704, -79, ""),
				}),
				new("Fern", typeof(Static), 3232, "", new DecorationEntry[]
				{
					new(1028, 695, -80, ""),
					new(1045, 678, -80, ""),
				}),
				new("Large Fern", typeof(Static), 3233, "", new DecorationEntry[]
				{
					new(1030, 718, -80, ""),
					new(1046, 696, -80, ""),
				}),
				new("Fern", typeof(Static), 3234, "", new DecorationEntry[]
				{
					new(1031, 708, -80, ""),
					new(1033, 676, -80, ""),
					new(1036, 692, -80, ""),
					new(1044, 718, -80, ""),
				}),
				new("Fern", typeof(Static), 3235, "", new DecorationEntry[]
				{
					new(1029, 691, -80, ""),
					new(1047, 684, -80, ""),
					new(1051, 707, -80, ""),
				}),
				new("Fern", typeof(Static), 3236, "", new DecorationEntry[]
				{
					new(1038, 680, -80, ""),
				}),
				
				#endregion
			});
		}
	}
}
