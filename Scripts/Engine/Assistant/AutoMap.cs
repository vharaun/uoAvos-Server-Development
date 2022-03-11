using Server.Commands;
using Server.Mobiles;

using System;

// Version 0.8

namespace Server
{
	public class UOAMVendorGenerator
	{
		private static int m_Count;

		//configuration
		private const int NPCCount = 2;//2 npcs per type (so a mage spawner will spawn 2 npcs, a alchemist and herbalist spawner will spawn 4 npcs total)
		private const int HomeRange = 5;//How far should they wander?
		private const bool TotalRespawn = true;//Should we spawn them up right away?
		private static readonly TimeSpan MinTime = TimeSpan.FromMinutes(2.5);//min spawn time
		private static readonly TimeSpan MaxTime = TimeSpan.FromMinutes(10.0);//max spawn time
		private const int Team = 0;//"team" the npcs are on

		public enum Category
		{
			ArchersGuild,
			Arms,
			Baker,
			Bank,
			Bard,
			BardicGuild,
			Beekeeper,
			Blacksmith,
			BlacksmithsGuild,
			Bowyer,
			Butcher,
			Carpenter,
			ChivalryKeeper,
			Fisherman,
			FishermansGuild,
			FortuneTeller,
			GypsyBank,
			GypsyMaiden,
			GypsyStable,
			Healer,
			HolyMage,
			Inn,
			Jeweler,
			Library,
			Mage,
			MagesGuild,
			Market,
			MerchantsGuild,
			MinersGuild,
			Provisioner,
			Reagents,
			Shipwright,
			Stable,
			Tailor,
			Tanner,
			Tavern,
			ThievesGuild,
			Tinker,
			TinkersGuild,
			Vet,
			WarriorsGuild,
		}

		[Flags]
		public enum MapFlags
		{
			Felucca = 1 << 0,
			Trammel = 1 << 1,
			Ilshenar = 1 << 2,
			Malas = 1 << 3,
			Tokuno = 1 << 4,
			TerMur = 1 << 5,

			FeluccaTrammel = Felucca | Trammel
		}

		// Format: (category, x, y, maps)
		public static (Category, int, int, MapFlags)[] Entries { get; } =
		{
			#region Entries

			#region ArchersGuild

			(Category.ArchersGuild, 554, 2145, MapFlags.FeluccaTrammel),

			#endregion

			#region Arms

			(Category.Arms, 1637, 1693, MapFlags.FeluccaTrammel),
			(Category.Arms, 1475, 3865, MapFlags.FeluccaTrammel),
			(Category.Arms, 1359, 3763, MapFlags.FeluccaTrammel),
			(Category.Arms, 654, 2163, MapFlags.FeluccaTrammel),
			(Category.Arms, 1443, 1650, MapFlags.FeluccaTrammel),
			(Category.Arms, 2865, 852, MapFlags.FeluccaTrammel),
			(Category.Arms, 1456, 3850, MapFlags.FeluccaTrammel),
			(Category.Arms, 1365, 1575, MapFlags.FeluccaTrammel),
			(Category.Arms, 4392, 1117, MapFlags.FeluccaTrammel),
			(Category.Arms, 586, 2170, MapFlags.FeluccaTrammel),
			(Category.Arms, 5805, 3300, MapFlags.FeluccaTrammel),
			(Category.Arms, 4440, 1162, MapFlags.FeluccaTrammel),
			(Category.Arms, 1441, 3719, MapFlags.FeluccaTrammel),
			(Category.Arms, 3018, 3433, MapFlags.FeluccaTrammel),
			(Category.Arms, 1895, 2653, MapFlags.FeluccaTrammel),
			(Category.Arms, 1481, 1584, MapFlags.FeluccaTrammel),
			(Category.Arms, 2533, 576, MapFlags.FeluccaTrammel),
			(Category.Arms, 2835, 805, MapFlags.FeluccaTrammel),
			(Category.Arms, 2217, 1170, MapFlags.FeluccaTrammel),
			(Category.Arms, 3632, 2595, MapFlags.Felucca),
			(Category.Arms, 808, 697, MapFlags.Ilshenar),
			(Category.Arms, 808, 586, MapFlags.Ilshenar),
			(Category.Arms, 1497, 614, MapFlags.Ilshenar),

			#endregion

			#region Baker

			(Category.Baker, 554, 991, MapFlags.FeluccaTrammel),
			(Category.Baker, 1880, 2802, MapFlags.FeluccaTrammel),
			(Category.Baker, 3755, 2227, MapFlags.FeluccaTrammel),
			(Category.Baker, 1364, 3732, MapFlags.FeluccaTrammel),
			(Category.Baker, 3683, 2171, MapFlags.FeluccaTrammel),
			(Category.Baker, 1450, 1617, MapFlags.FeluccaTrammel),
			(Category.Baker, 5351, 56, MapFlags.FeluccaTrammel),
			(Category.Baker, 4392, 1068, MapFlags.FeluccaTrammel),
			(Category.Baker, 5746, 3200, MapFlags.FeluccaTrammel),
			(Category.Baker, 2975, 3358, MapFlags.FeluccaTrammel),
			(Category.Baker, 2998, 760, MapFlags.FeluccaTrammel),
			(Category.Baker, 3610, 2572, MapFlags.Felucca),
			(Category.Baker, 3628, 2540, MapFlags.Trammel),
			(Category.Baker, 1514, 611, MapFlags.Ilshenar),
			(Category.Baker, 2017, 1356, MapFlags.Malas),

			#endregion

			#region Bank

			(Category.Bank, 652, 820, MapFlags.FeluccaTrammel),
			(Category.Bank, 1813, 2825, MapFlags.FeluccaTrammel),
			(Category.Bank, 3734, 2149, MapFlags.FeluccaTrammel),
			(Category.Bank, 2503, 552, MapFlags.FeluccaTrammel),
			(Category.Bank, 3764, 1317, MapFlags.FeluccaTrammel),
			(Category.Bank, 587, 2146, MapFlags.FeluccaTrammel),
			(Category.Bank, 1897, 2684, MapFlags.FeluccaTrammel),
			(Category.Bank, 2880, 3472, MapFlags.FeluccaTrammel),
			(Category.Bank, 2731, 2188, MapFlags.FeluccaTrammel),
			(Category.Bank, 2881, 684, MapFlags.FeluccaTrammel),
			(Category.Bank, 1317, 3773, MapFlags.FeluccaTrammel),
			(Category.Bank, 1655, 1606, MapFlags.FeluccaTrammel),
			(Category.Bank, 1425, 1690, MapFlags.FeluccaTrammel),
			(Category.Bank, 4471, 1156, MapFlags.FeluccaTrammel),
			(Category.Bank, 5346, 74, MapFlags.FeluccaTrammel),
			(Category.Bank, 5275, 3977, MapFlags.FeluccaTrammel),
			(Category.Bank, 5669, 3131, MapFlags.FeluccaTrammel),
			(Category.Bank, 3695, 2511, MapFlags.Felucca),
			(Category.Bank, 3620, 2617, MapFlags.Trammel),
			(Category.Bank, 854, 680, MapFlags.Ilshenar),
			(Category.Bank, 855, 603, MapFlags.Ilshenar),
			(Category.Bank, 1610, 556, MapFlags.Ilshenar),
			(Category.Bank, 989, 520, MapFlags.Malas),
			(Category.Bank, 2048, 1343, MapFlags.Malas),

			#endregion

			#region Bard

			(Category.Bard, 1455, 1557, MapFlags.FeluccaTrammel),
			(Category.Bard, 2424, 555, MapFlags.FeluccaTrammel),

			#endregion

			#region BardicGuild

			(Category.BardicGuild, 3740, 1197, MapFlags.FeluccaTrammel),
			(Category.BardicGuild, 3665, 2531, MapFlags.Felucca),
			(Category.BardicGuild, 3666, 2531, MapFlags.Trammel),

			#endregion

			#region Beekeeper

			(Category.Beekeeper, 2959, 707, MapFlags.FeluccaTrammel),

			#endregion

			#region Blacksmith

			(Category.Blacksmith, 3007, 3408, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 2637, 2090, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 1395, 3705, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 2471, 564, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 1418, 1547, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 1937, 2771, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 3546, 1185, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 630, 2194, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 3554, 1202, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 1419, 3859, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 5225, 4000, MapFlags.FeluccaTrammel),
			(Category.Blacksmith, 3594, 2595, MapFlags.Trammel),
			(Category.Blacksmith, 3645, 2617, MapFlags.Trammel),
			(Category.Blacksmith, 1261, 582, MapFlags.Ilshenar),
			(Category.Blacksmith, 792, 665, MapFlags.Ilshenar),
			(Category.Blacksmith, 976, 512, MapFlags.Malas),
			(Category.Blacksmith, 1977, 1365, MapFlags.Malas),

			#endregion

			#region BlacksmithsGuild

			(Category.BlacksmithsGuild, 1348, 1778, MapFlags.FeluccaTrammel),

			#endregion

			#region Bowyer

			(Category.Bowyer, 590, 2205, MapFlags.FeluccaTrammel),
			(Category.Bowyer, 624, 1147, MapFlags.FeluccaTrammel),
			(Category.Bowyer, 3054, 3369, MapFlags.FeluccaTrammel),
			(Category.Bowyer, 564, 968, MapFlags.FeluccaTrammel),
			(Category.Bowyer, 3546, 1194, MapFlags.FeluccaTrammel),
			(Category.Bowyer, 1470, 1578, MapFlags.FeluccaTrammel),
			(Category.Bowyer, 2861, 812, MapFlags.FeluccaTrammel),
			(Category.Bowyer, 3745, 2585, MapFlags.Trammel),

			#endregion

			#region Butcher

			(Category.Butcher, 582, 2186, MapFlags.FeluccaTrammel),
			(Category.Butcher, 2991, 779, MapFlags.FeluccaTrammel),
			(Category.Butcher, 1449, 1723, MapFlags.FeluccaTrammel),
			(Category.Butcher, 4395, 1137, MapFlags.FeluccaTrammel),
			(Category.Butcher, 1455, 4026, MapFlags.FeluccaTrammel),
			(Category.Butcher, 3555, 1171, MapFlags.FeluccaTrammel),
			(Category.Butcher, 2912, 3485, MapFlags.FeluccaTrammel),
			(Category.Butcher, 2438, 410, MapFlags.FeluccaTrammel),
			(Category.Butcher, 5700, 3279, MapFlags.FeluccaTrammel),
			(Category.Butcher, 1991, 2887, MapFlags.FeluccaTrammel),
			(Category.Butcher, 529, 1008, MapFlags.FeluccaTrammel),
			(Category.Butcher, 3708, 2649, MapFlags.Felucca),
			(Category.Butcher, 3714, 2651, MapFlags.Trammel),

			#endregion

			#region Carpenter

			(Category.Carpenter, 565, 1011, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 628, 2160, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 5691, 3209, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 1435, 3820, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 2917, 798, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 4416, 1085, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 2513, 477, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 1430, 1597, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 2627, 2100, MapFlags.FeluccaTrammel),
			(Category.Carpenter, 3642, 2504, MapFlags.Trammel),
			(Category.Carpenter, 1004, 514, MapFlags.Malas),
			(Category.Carpenter, 2060, 1283, MapFlags.Malas),

			#endregion

			#region ChivalryKeeper

			(Category.ChivalryKeeper, 1016, 514, MapFlags.Malas),
			(Category.ChivalryKeeper, 961, 517, MapFlags.Malas),

			#endregion

			#region Docks

			(Category.Fisherman, 1470, 1765, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 1437, 1761, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 1484, 1755, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 2752, 2155, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 2256, 1181, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 1512, 3989, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 1372, 3908, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 1504, 3693, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 1125, 3687, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 3674, 2293, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 4406, 1038, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 2940, 3410, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 5827, 3256, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 648, 2235, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 672, 2235, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 3006, 3465, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 2072, 2856, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 3017, 827, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 3034, 827, MapFlags.FeluccaTrammel),
			(Category.Fisherman, 3633, 2654, MapFlags.Felucca),
			(Category.Fisherman, 3654, 2664, MapFlags.Felucca),
			(Category.Fisherman, 3655, 2665, MapFlags.Trammel),

			#endregion

			#region FishermansGuild

			(Category.FishermansGuild, 2963, 813, MapFlags.FeluccaTrammel),
			(Category.FishermansGuild, 3685, 2256, MapFlags.FeluccaTrammel),
			(Category.FishermansGuild, 1437, 3750, MapFlags.FeluccaTrammel),

			#endregion

			#region FortuneTeller

			(Category.FortuneTeller, 1235, 543, MapFlags.Ilshenar),
			(Category.FortuneTeller, 1407, 428, MapFlags.Ilshenar),
			(Category.FortuneTeller, 1394, 441, MapFlags.Ilshenar),

			#endregion

			#region GypsyBank

			(Category.GypsyBank, 1226, 554, MapFlags.Ilshenar),
			(Category.GypsyBank, 1405, 439, MapFlags.Ilshenar),

			#endregion

			#region GypsyMaiden

			(Category.GypsyMaiden, 1400, 434, MapFlags.Ilshenar),

			#endregion

			#region GypsyStable

			(Category.GypsyStable, 1225, 563, MapFlags.Ilshenar),
			(Category.GypsyStable, 1388, 428, MapFlags.Ilshenar),

			#endregion

			#region Healer

			(Category.Healer, 647, 1087, MapFlags.FeluccaTrammel),
			(Category.Healer, 5191, 3989, MapFlags.FeluccaTrammel),
			(Category.Healer, 1472, 1607, MapFlags.FeluccaTrammel),
			(Category.Healer, 2709, 2130, MapFlags.FeluccaTrammel),
			(Category.Healer, 3687, 2227, MapFlags.FeluccaTrammel),
			(Category.Healer, 623, 2218, MapFlags.FeluccaTrammel),
			(Category.Healer, 2920, 856, MapFlags.FeluccaTrammel),
			(Category.Healer, 532, 958, MapFlags.FeluccaTrammel),
			(Category.Healer, 2577, 599, MapFlags.FeluccaTrammel),
			(Category.Healer, 2245, 1231, MapFlags.FeluccaTrammel),
			(Category.Healer, 5737, 3222, MapFlags.FeluccaTrammel),
			(Category.Healer, 1416, 3779, MapFlags.FeluccaTrammel),
			(Category.Healer, 4388, 1082, MapFlags.FeluccaTrammel),
			(Category.Healer, 2997, 3428, MapFlags.FeluccaTrammel),
			(Category.Healer, 1911, 2805, MapFlags.FeluccaTrammel),
			(Category.Healer, 5263, 129, MapFlags.FeluccaTrammel),
			(Category.Healer, 3629, 2608, MapFlags.Felucca),
			(Category.Healer, 3665, 2581, MapFlags.Trammel),
			(Category.Healer, 575, 537, MapFlags.Ilshenar),
			(Category.Healer, 682, 297, MapFlags.Ilshenar),
			(Category.Healer, 284, 536, MapFlags.Ilshenar),
			(Category.Healer, 1628, 548, MapFlags.Ilshenar),
			(Category.Healer, 1518, 619, MapFlags.Ilshenar),
			(Category.Healer, 1093, 955, MapFlags.Ilshenar),
			(Category.Healer, 872, 586, MapFlags.Ilshenar),
			(Category.Healer, 369, 1432, MapFlags.Ilshenar),
			(Category.Healer, 1364, 1051, MapFlags.Ilshenar),
			(Category.Healer, 1029, 520, MapFlags.Malas),
			(Category.Healer, 950, 520, MapFlags.Malas),
			(Category.Healer, 2068, 1372, MapFlags.Malas),

			#endregion

			#region HolyMage

			(Category.HolyMage, 1004, 528, MapFlags.Malas),

			#endregion

			#region Inn

			(Category.Inn, 610, 810, MapFlags.FeluccaTrammel),
			(Category.Inn, 5197, 4060, MapFlags.FeluccaTrammel),
			(Category.Inn, 2967, 3408, MapFlags.FeluccaTrammel),
			(Category.Inn, 5310, 34, MapFlags.FeluccaTrammel),
			(Category.Inn, 606, 2243, MapFlags.FeluccaTrammel),
			(Category.Inn, 2778, 966, MapFlags.FeluccaTrammel),
			(Category.Inn, 5775, 3161, MapFlags.FeluccaTrammel),
			(Category.Inn, 4484, 1064, MapFlags.FeluccaTrammel),
			(Category.Inn, 1360, 3815, MapFlags.FeluccaTrammel),
			(Category.Inn, 1458, 1525, MapFlags.FeluccaTrammel),
			(Category.Inn, 2715, 2098, MapFlags.FeluccaTrammel),
			(Category.Inn, 3732, 1306, MapFlags.FeluccaTrammel),
			(Category.Inn, 2033, 2801, MapFlags.FeluccaTrammel),
			(Category.Inn, 4401, 1165, MapFlags.FeluccaTrammel),
			(Category.Inn, 5165, 30, MapFlags.FeluccaTrammel),
			(Category.Inn, 554, 2178, MapFlags.FeluccaTrammel),
			(Category.Inn, 3695, 2160, MapFlags.FeluccaTrammel),
			(Category.Inn, 1493, 1619, MapFlags.FeluccaTrammel),
			(Category.Inn, 1844, 2735, MapFlags.FeluccaTrammel),
			(Category.Inn, 2962, 885, MapFlags.FeluccaTrammel),
			(Category.Inn, 1585, 1591, MapFlags.FeluccaTrammel),
			(Category.Inn, 5218, 175, MapFlags.FeluccaTrammel),
			(Category.Inn, 3672, 2654, MapFlags.Felucca),
			(Category.Inn, 3673, 2614, MapFlags.Felucca),
			(Category.Inn, 3671, 2615, MapFlags.Trammel),
			(Category.Inn, 665, 665, MapFlags.Ilshenar),
			(Category.Inn, 1620, 554, MapFlags.Ilshenar),
			(Category.Inn, 774, 1144, MapFlags.Ilshenar),
			(Category.Inn, 840, 707, MapFlags.Ilshenar),
			(Category.Inn, 1566, 1049, MapFlags.Ilshenar),
			(Category.Inn, 989, 527, MapFlags.Malas),
			(Category.Inn, 2037, 1311, MapFlags.Malas),
			(Category.Inn, 1056, 1434, MapFlags.Malas),

			#endregion

			#region Jeweler

			(Category.Jeweler, 3661, 2183, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 1655, 1642, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 3778, 1172, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 1447, 3981, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 1895, 2809, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 1451, 1679, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 2882, 723, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 5662, 3150, MapFlags.FeluccaTrammel),
			(Category.Jeweler, 1605, 541, MapFlags.Ilshenar),
			(Category.Jeweler, 859, 698, MapFlags.Ilshenar),
			(Category.Jeweler, 995, 510, MapFlags.Malas),
			(Category.Jeweler, 2045, 1397, MapFlags.Malas),

			#endregion

			#region Library

			(Category.Library, 1409, 1590, MapFlags.FeluccaTrammel),
			(Category.Library, 1494, 1715, MapFlags.FeluccaTrammel),
			(Category.Library, 1387, 3771, MapFlags.FeluccaTrammel),
			(Category.Library, 5238, 144, MapFlags.FeluccaTrammel),
			(Category.Library, 2003, 2726, MapFlags.FeluccaTrammel),
			(Category.Library, 5243, 179, MapFlags.FeluccaTrammel),
			(Category.Library, 3612, 2466, MapFlags.Felucca),
			(Category.Library, 3615, 2476, MapFlags.Trammel),
			(Category.Library, 868, 657, MapFlags.Ilshenar),
			(Category.Library, 869, 625, MapFlags.Ilshenar),

			#endregion

			#region Mage

			(Category.Mage, 5301, 88, MapFlags.FeluccaTrammel),
			(Category.Mage, 2885, 651, MapFlags.FeluccaTrammel),
			(Category.Mage, 1843, 2711, MapFlags.FeluccaTrammel),
			(Category.Mage, 5296, 3978, MapFlags.FeluccaTrammel),
			(Category.Mage, 1590, 1654, MapFlags.FeluccaTrammel),
			(Category.Mage, 1425, 3980, MapFlags.FeluccaTrammel),
			(Category.Mage, 602, 2180, MapFlags.FeluccaTrammel),
			(Category.Mage, 2918, 672, MapFlags.FeluccaTrammel),
			(Category.Mage, 3704, 2222, MapFlags.FeluccaTrammel),
			(Category.Mage, 4448, 1090, MapFlags.FeluccaTrammel),
			(Category.Mage, 659, 2141, MapFlags.FeluccaTrammel),
			(Category.Mage, 3002, 3350, MapFlags.FeluccaTrammel),
			(Category.Mage, 1485, 1550, MapFlags.FeluccaTrammel),
			(Category.Mage, 5731, 3183, MapFlags.FeluccaTrammel),
			(Category.Mage, 5148, 60, MapFlags.FeluccaTrammel),
			(Category.Mage, 3628, 2541, MapFlags.Felucca),
			(Category.Mage, 3632, 2573, MapFlags.Trammel),
			(Category.Mage, 1505, 611, MapFlags.Ilshenar),
			(Category.Mage, 840, 571, MapFlags.Ilshenar),
			(Category.Mage, 2023, 1379, MapFlags.Malas),

			#endregion

			#region MagesGuild

			(Category.MagesGuild, 4545, 860, MapFlags.FeluccaTrammel),
			(Category.MagesGuild, 4684, 1412, MapFlags.FeluccaTrammel),

			#endregion

			#region Market

			(Category.Market, 4481, 1085, MapFlags.FeluccaTrammel),
			(Category.Market, 1392, 3824, MapFlags.FeluccaTrammel),
			(Category.Market, 611, 2157, MapFlags.FeluccaTrammel),
			(Category.Market, 3019, 766, MapFlags.FeluccaTrammel),
			(Category.Market, 3013, 781, MapFlags.FeluccaTrammel),

			#endregion

			#region MerchantsGuild

			(Category.MerchantsGuild, 1474, 1597, MapFlags.FeluccaTrammel),
			(Category.MerchantsGuild, 3703, 2249, MapFlags.FeluccaTrammel),

			#endregion

			#region MinersGuild

			(Category.MinersGuild, 2505, 432, MapFlags.FeluccaTrammel),
			(Category.MinersGuild, 3665, 2140, MapFlags.FeluccaTrammel),
			(Category.MinersGuild, 2455, 487, MapFlags.FeluccaTrammel),
			(Category.MinersGuild, 1417, 1578, MapFlags.FeluccaTrammel),
			(Category.MinersGuild, 2855, 734, MapFlags.FeluccaTrammel),
			(Category.MinersGuild, 3754, 2704, MapFlags.Trammel),

			#endregion

			#region Provisioner

			(Category.Provisioner, 5737, 3262, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 535, 867, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 2992, 638, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 1469, 1668, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 1850, 2796, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 2838, 868, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 2216, 1192, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 5154, 97, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 1441, 3796, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 2456, 428, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 2735, 2254, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 1602, 1712, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 1852, 2831, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 4417, 1064, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 578, 2227, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 3008, 3389, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 5219, 4012, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 2530, 551, MapFlags.FeluccaTrammel),
			(Category.Provisioner, 3635, 2573, MapFlags.Felucca),
			(Category.Provisioner, 3673, 2595, MapFlags.Trammel),
			(Category.Provisioner, 826, 679, MapFlags.Ilshenar),
			(Category.Provisioner, 824, 602, MapFlags.Ilshenar),
			(Category.Provisioner, 1598, 539, MapFlags.Ilshenar),
			(Category.Provisioner, 1318, 1328, MapFlags.Ilshenar),
			(Category.Provisioner, 991, 510, MapFlags.Malas),
			(Category.Provisioner, 2011, 1326, MapFlags.Malas),

			#endregion

			#region Reagents

			(Category.Reagents, 3013, 3353, MapFlags.FeluccaTrammel),
			(Category.Reagents, 1498, 1659, MapFlags.FeluccaTrammel),
			(Category.Reagents, 4416, 1133, MapFlags.FeluccaTrammel),
			(Category.Reagents, 5215, 117, MapFlags.FeluccaTrammel),
			(Category.Reagents, 2992, 844, MapFlags.FeluccaTrammel),
			(Category.Reagents, 4412, 1111, MapFlags.FeluccaTrammel),
			(Category.Reagents, 5714, 3202, MapFlags.FeluccaTrammel),
			(Category.Reagents, 1004, 526, MapFlags.Malas),
			(Category.Reagents, 2025, 1387, MapFlags.Malas),

			#endregion

			#region Shipwright

			(Category.Shipwright, 3667, 2252, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 634, 1038, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 2994, 815, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 1416, 1754, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 5805, 3270, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 1452, 3747, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 3700, 1214, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 2026, 2845, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 592, 2277, MapFlags.FeluccaTrammel),
			(Category.Shipwright, 3632, 2640, MapFlags.Felucca),
			(Category.Shipwright, 3636, 2642, MapFlags.Trammel),

			#endregion

			#region Stable

			(Category.Stable, 571, 2119, MapFlags.FeluccaTrammel),
			(Category.Stable, 1510, 1543, MapFlags.FeluccaTrammel),
			(Category.Stable, 5297, 4007, MapFlags.FeluccaTrammel),
			(Category.Stable, 2010, 2807, MapFlags.FeluccaTrammel),
			(Category.Stable, 3036, 3464, MapFlags.FeluccaTrammel),
			(Category.Stable, 2905, 3517, MapFlags.FeluccaTrammel),
			(Category.Stable, 1296, 1759, MapFlags.FeluccaTrammel),
			(Category.Stable, 5671, 3287, MapFlags.FeluccaTrammel),
			(Category.Stable, 2526, 375, MapFlags.FeluccaTrammel),
			(Category.Stable, 1385, 1658, MapFlags.FeluccaTrammel),
			(Category.Stable, 1822, 2739, MapFlags.FeluccaTrammel),
			(Category.Stable, 1499, 619, MapFlags.Ilshenar),
			(Category.Stable, 1027, 494, MapFlags.Malas),
			(Category.Stable, 1992, 1315, MapFlags.Malas),

			#endregion

			#region Tailor

			(Category.Tailor, 1981, 2838, MapFlags.FeluccaTrammel),
			(Category.Tailor, 1355, 3779, MapFlags.FeluccaTrammel),
			(Category.Tailor, 5234, 4025, MapFlags.FeluccaTrammel),
			(Category.Tailor, 1455, 4006, MapFlags.FeluccaTrammel),
			(Category.Tailor, 1385, 1593, MapFlags.FeluccaTrammel),
			(Category.Tailor, 1467, 1686, MapFlags.FeluccaTrammel),
			(Category.Tailor, 5754, 3273, MapFlags.FeluccaTrammel),
			(Category.Tailor, 1547, 1659, MapFlags.FeluccaTrammel),
			(Category.Tailor, 4458, 1060, MapFlags.FeluccaTrammel),
			(Category.Tailor, 650, 2180, MapFlags.FeluccaTrammel),
			(Category.Tailor, 2881, 3503, MapFlags.FeluccaTrammel),
			(Category.Tailor, 2961, 621, MapFlags.FeluccaTrammel),
			(Category.Tailor, 2840, 885, MapFlags.FeluccaTrammel),
			(Category.Tailor, 3666, 2235, MapFlags.FeluccaTrammel),
			(Category.Tailor, 3774, 1265, MapFlags.FeluccaTrammel),
			(Category.Tailor, 5203, 86, MapFlags.FeluccaTrammel),
			(Category.Tailor, 3667, 2586, MapFlags.Felucca),
			(Category.Tailor, 3687, 2477, MapFlags.Trammel),
			(Category.Tailor, 896, 610, MapFlags.Ilshenar),
			(Category.Tailor, 1600, 552, MapFlags.Ilshenar),
			(Category.Tailor, 976, 527, MapFlags.Malas),
			(Category.Tailor, 2083, 1322, MapFlags.Malas),

			#endregion

			#region Tanner

			(Category.Tanner, 1431, 1612, MapFlags.FeluccaTrammel),
			(Category.Tanner, 2707, 2178, MapFlags.FeluccaTrammel),
			(Category.Tanner, 3545, 1178, MapFlags.FeluccaTrammel),
			(Category.Tanner, 2524, 524, MapFlags.FeluccaTrammel),
			(Category.Tanner, 517, 986, MapFlags.FeluccaTrammel),
			(Category.Tanner, 2860, 999, MapFlags.FeluccaTrammel),
			(Category.Tanner, 1991, 2867, MapFlags.FeluccaTrammel),
			(Category.Tanner, 3602, 2615, MapFlags.Felucca),
			(Category.Tanner, 978, 528, MapFlags.Malas),
			(Category.Tanner, 2078, 1327, MapFlags.Malas),

			#endregion

			#region Tavern

			(Category.Tavern, 2475, 397, MapFlags.FeluccaTrammel),
			(Category.Tavern, 1498, 1691, MapFlags.FeluccaTrammel),
			(Category.Tavern, 1427, 1716, MapFlags.FeluccaTrammel),
			(Category.Tavern, 2972, 3425, MapFlags.FeluccaTrammel),
			(Category.Tavern, 3012, 3457, MapFlags.FeluccaTrammel),
			(Category.Tavern, 3730, 2218, MapFlags.FeluccaTrammel),
			(Category.Tavern, 1452, 3770, MapFlags.FeluccaTrammel),
			(Category.Tavern, 1935, 2796, MapFlags.FeluccaTrammel),
			(Category.Tavern, 2901, 908, MapFlags.FeluccaTrammel),
			(Category.Tavern, 3769, 1218, MapFlags.FeluccaTrammel),
			(Category.Tavern, 2680, 2238, MapFlags.FeluccaTrammel),
			(Category.Tavern, 1620, 1586, MapFlags.FeluccaTrammel),
			(Category.Tavern, 3736, 1255, MapFlags.FeluccaTrammel),
			(Category.Tavern, 1547, 1768, MapFlags.FeluccaTrammel),
			(Category.Tavern, 3668, 2652, MapFlags.Trammel),
			(Category.Tavern, 2027, 1353, MapFlags.Malas),
			(Category.Tavern, 1051, 1434, MapFlags.Malas),

			#endregion

			#region ThievesGuild

			(Category.ThievesGuild, 2659, 2194, MapFlags.FeluccaTrammel),
			(Category.ThievesGuild, 3693, 2509, MapFlags.Trammel),

			#endregion

			#region Tinker

			(Category.Tinker, 2899, 790, MapFlags.FeluccaTrammel),
			(Category.Tinker, 1404, 3805, MapFlags.FeluccaTrammel),
			(Category.Tinker, 2461, 457, MapFlags.FeluccaTrammel),
			(Category.Tinker, 3720, 2126, MapFlags.FeluccaTrammel),
			(Category.Tinker, 2940, 3500, MapFlags.FeluccaTrammel),
			(Category.Tinker, 5726, 3243, MapFlags.FeluccaTrammel),
			(Category.Tinker, 3667, 2506, MapFlags.Trammel),
			(Category.Tinker, 766, 641, MapFlags.Ilshenar),
			(Category.Tinker, 1253, 588, MapFlags.Ilshenar),
			(Category.Tinker, 1003, 512, MapFlags.Malas),
			(Category.Tinker, 2066, 1282, MapFlags.Malas),

			#endregion

			#region TinkersGuild

			(Category.TinkersGuild, 1422, 1654, MapFlags.FeluccaTrammel),
			(Category.TinkersGuild, 1848, 2680, MapFlags.FeluccaTrammel),

			#endregion

			#region Vet

			(Category.Vet, 1509, 1571, MapFlags.FeluccaTrammel),

			#endregion

			#region WarriorsGuild

			(Category.WarriorsGuild, 1939, 2739, MapFlags.FeluccaTrammel),
			(Category.WarriorsGuild, 2841, 907, MapFlags.FeluccaTrammel),
			(Category.WarriorsGuild, 2482, 428, MapFlags.FeluccaTrammel),
			(Category.WarriorsGuild, 3031, 3350, MapFlags.FeluccaTrammel),
			(Category.WarriorsGuild, 2019, 2748, MapFlags.FeluccaTrammel),
			(Category.WarriorsGuild, 3058, 3400, MapFlags.FeluccaTrammel),
			(Category.WarriorsGuild, 1341, 1733, MapFlags.FeluccaTrammel),
			(Category.WarriorsGuild, 3740, 2692, MapFlags.Trammel),

			#endregion

			#endregion
		};

		public static void Initialize()
		{
			CommandSystem.Register("UOAMVendors", AccessLevel.Administrator, new CommandEventHandler(Generate_OnCommand));
		}

		[Usage("UOAMVendors")]
		[Description("Generates vendor spawners from Data/Common.MAP (taken from UOAutoMap)")]
		private static void Generate_OnCommand(CommandEventArgs e)
		{
			Generate(e.Mobile);
		}

		public static void Generate(Mobile from)
		{
			m_Count = 0;

			from?.SendMessage("Generating Vendors...");

			foreach (var (type, x, y, map) in Entries)
			{
				switch (type)
				{
					case Category.ArchersGuild: PlaceNPC(x, y, map, typeof(RangerGuildmaster)); break;
					case Category.Arms: PlaceNPC(x, y, map, typeof(Armorer), typeof(Weaponsmith)); break;
					case Category.Baker: PlaceNPC(x, y, map, typeof(Baker)); break;
					case Category.Bank: PlaceNPC(x, y, map, typeof(Banker), typeof(Minter)); break;
					case Category.Bard: PlaceNPC(x, y, map, typeof(Bard), typeof(BardGuildmaster)); break;
					case Category.BardicGuild: PlaceNPC(x, y, map, typeof(BardGuildmaster)); break;
					case Category.Beekeeper: PlaceNPC(x, y, map, typeof(Beekeeper)); break;
					case Category.Blacksmith: PlaceNPC(x, y, map, typeof(Blacksmith), typeof(BlacksmithGuildmaster)); break;
					case Category.BlacksmithsGuild: PlaceNPC(x, y, map, typeof(BlacksmithGuildmaster)); break;
					case Category.Bowyer: PlaceNPC(x, y, map, typeof(Bowyer)); break;
					case Category.Butcher: PlaceNPC(x, y, map, typeof(Butcher)); break;
					case Category.Carpenter: PlaceNPC(x, y, map, typeof(Carpenter), typeof(Architect), typeof(RealEstateBroker)); break;
					case Category.ChivalryKeeper: PlaceNPC(x, y, map, typeof(KeeperOfChivalry)); break;
					case Category.Fisherman: PlaceNPC(x, y, map, typeof(Fisherman)); break;
					case Category.FishermansGuild: PlaceNPC(x, y, map, typeof(FisherGuildmaster)); break;
					case Category.FortuneTeller: PlaceNPC(x, y, map, typeof(FortuneTeller)); break;
					case Category.GypsyBank: PlaceNPC(x, y, map, typeof(GypsyBanker)); break;
					case Category.GypsyMaiden: PlaceNPC(x, y, map, typeof(GypsyMaiden)); break;
					case Category.GypsyStable: PlaceNPC(x, y, map, typeof(GypsyAnimalTrainer)); break;
					case Category.Healer: PlaceNPC(x, y, map, typeof(Healer), typeof(HealerGuildmaster)); break;
					case Category.HolyMage: PlaceNPC(x, y, map, typeof(HolyMage)); break;
					case Category.Inn: PlaceNPC(x, y, map, typeof(InnKeeper)); break;
					case Category.Jeweler: PlaceNPC(x, y, map, typeof(Jeweler)); break;
					case Category.Library: PlaceNPC(x, y, map, typeof(Scribe)); break;
					case Category.Mage: PlaceNPC(x, y, map, typeof(Mage), typeof(Alchemist), typeof(MageGuildmaster)); break;
					case Category.MagesGuild: PlaceNPC(x, y, map, typeof(MageGuildmaster)); break;
					case Category.Market: PlaceNPC(x, y, map, typeof(Butcher), typeof(Farmer)); break;
					case Category.MerchantsGuild: PlaceNPC(x, y, map, typeof(MerchantGuildmaster)); break;
					case Category.MinersGuild: PlaceNPC(x, y, map, typeof(MinerGuildmaster)); break;
					case Category.Provisioner: PlaceNPC(x, y, map, typeof(Provisioner), typeof(Cobbler)); break;
					case Category.Reagents: PlaceNPC(x, y, map, typeof(Herbalist), typeof(Alchemist), typeof(CustomHairstylist)); break;
					case Category.Shipwright: PlaceNPC(x, y, map, typeof(Shipwright), typeof(Mapmaker)); break;
					case Category.Stable: PlaceNPC(x, y, map, typeof(AnimalTrainer)); break;
					case Category.Tailor: PlaceNPC(x, y, map, typeof(Tailor), typeof(Weaver), typeof(TailorGuildmaster)); break;
					case Category.Tanner: PlaceNPC(x, y, map, typeof(Tanner), typeof(Furtrader)); break;
					case Category.Tavern: PlaceNPC(x, y, map, typeof(TavernKeeper), typeof(Waiter), typeof(Cook), typeof(Barkeeper)); break;
					case Category.Tinker: PlaceNPC(x, y, map, typeof(Tinker), typeof(TinkerGuildmaster)); break;
					case Category.TinkersGuild: PlaceNPC(x, y, map, typeof(TinkerGuildmaster)); break;
					case Category.ThievesGuild: PlaceNPC(x, y, map, typeof(ThiefGuildmaster)); break;
					case Category.Vet: PlaceNPC(x, y, map, typeof(Veterinarian)); break;
					case Category.WarriorsGuild: PlaceNPC(x, y, map, typeof(WarriorGuildmaster)); break;
				}
			}

			from.SendMessage("Done, added {0} spawners", m_Count);
		}

		public static void PlaceNPC(int x, int y, MapFlags maps, params Type[] types)
		{
			if (types.Length == 0)
			{
				return;
			}

			if (maps.HasFlag(MapFlags.Felucca))
			{
				MakeSpawner(types, x, y, Map.Felucca);
			}

			if (maps.HasFlag(MapFlags.Trammel))
			{
				MakeSpawner(types, x, y, Map.Trammel);
			}

			if (maps.HasFlag(MapFlags.Ilshenar))
			{
				MakeSpawner(types, x, y, Map.Ilshenar);
			}

			if (maps.HasFlag(MapFlags.Ilshenar))
			{
				MakeSpawner(types, x, y, Map.Ilshenar);
			}

			if (maps.HasFlag(MapFlags.Malas))
			{
				MakeSpawner(types, x, y, Map.Malas);
			}

			if (maps.HasFlag(MapFlags.Tokuno))
			{
				MakeSpawner(types, x, y, Map.Tokuno);
			}

			if (maps.HasFlag(MapFlags.TerMur))
			{
				MakeSpawner(types, x, y, Map.TerMur);
			}
		}

		public static int GetSpawnerZ(int x, int y, Map map)
		{
			var z = map.GetAverageZ(x, y);

			if (map.CanFit(x, y, z, 16, false, false, true))
			{
				return z;
			}

			for (var i = 1; i <= 20; ++i)
			{
				if (map.CanFit(x, y, z + i, 16, false, false, true))
				{
					return z + i;
				}

				if (map.CanFit(x, y, z - i, 16, false, false, true))
				{
					return z - i;
				}
			}

			return z;
		}

		public static void ClearSpawners(int x, int y, int z, Map map)
		{
			var eable = map.GetItemsInRange(new Point3D(x, y, z), 0);

			foreach (var item in eable)
			{
				if (item is Spawner s && s.Z == z)
				{
					s.Delete();
				}
			}

			eable.Free();
		}

		private static void MakeSpawner(Type[] types, int x, int y, Map map)
		{
			if (types.Length == 0)
			{
				return;
			}

			var z = GetSpawnerZ(x, y, map);

			ClearSpawners(x, y, z, map);

			for (var i = 0; i < types.Length; ++i)
			{
				var isGuildmaster = types[i].FullName.EndsWith("Guildmaster");
				var sp = new Spawner(types[i].Name);

				if (isGuildmaster)
				{
					sp.Count = 1;
				}
				else
				{
					sp.Count = NPCCount;
				}

				sp.MinDelay = MinTime;
				sp.MaxDelay = MaxTime;
				sp.Team = Team;
				sp.HomeRange = HomeRange;

				sp.MoveToWorld(new Point3D(x, y, z), map);

				if (TotalRespawn)
				{
					sp.Respawn();
					sp.BringToHome();
				}

				++m_Count;
			}
		}
	}
}