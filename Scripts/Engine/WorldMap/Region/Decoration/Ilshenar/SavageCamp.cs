using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] SavageCamp { get; } = Register(DecorationTarget.Ilshenar, "Savage Camp", new DecorationList[]
			{
				#region Entries
				
				new("Tribal Berry", typeof(TribalBerry), 2512, "", new DecorationEntry[]
				{
					new(1258, 752, -74, ""),
					new(1259, 752, -72, ""),
					new(1264, 752, -74, ""),
					new(1267, 752, -73, ""),
				}),
				new("Tribal Paint", typeof(TribalPaint), 2540, "", new DecorationEntry[]
				{
					new(1259, 765, -74, ""),
				}),
				new("Horse Dung", typeof(Static), 3899, "", new DecorationEntry[]
				{
					new(1276, 785, -80, ""),
				}),
				new("Horse Dung", typeof(Static), 3900, "", new DecorationEntry[]
				{
					new(1287, 777, -80, ""),
				}),
				new("Spear", typeof(Static), 3938, "", new DecorationEntry[]
				{
					new(1270, 756, -71, ""),
					new(1270, 756, -70, ""),
				}),
				new("Mask Of Orcish Kin", typeof(OrcishKinMask), 5147, "", new DecorationEntry[]
				{
					new(1255, 755, -74, ""),
					new(1255, 760, -74, ""),
					new(1255, 761, -74, ""),
				}),
				new("Tribal Mask", typeof(SavageMask), 5451, "Hue=0x84C", new DecorationEntry[]
				{
					new(1248, 702, -74, ""),
					new(1258, 765, -74, ""),
				}),
				new("Tribal Mask", typeof(SavageMask), 5451, "Hue=0x84E", new DecorationEntry[]
				{
					new(1260, 765, -74, ""),
				}),
				new("Tribal Mask", typeof(SavageMask), 5452, "Hue=0x845", new DecorationEntry[]
				{
					new(1266, 765, -74, ""),
				}),
				new("Tribal Mask", typeof(SavageMask), 5452, "Hue=0x851", new DecorationEntry[]
				{
					new(1257, 765, -74, ""),
				}),
				new("Bolas", typeof(Bola), 9900, "", new DecorationEntry[]
				{
					new(1211, 742, -74, ""),
					new(1217, 740, -74, ""),
					new(1270, 762, -74, ""),
				}),
				
				#endregion
			});
		}
	}
}
