using Server.Multis;

#region Developer Notations

/// The Default System Requires You To Register ALL Custom Foundations And Structures
/// To Both Of These Entities: 'HousePlacementTool' And The 'HouseSystemEntries'

/// These Two 'HousePlacementEntry' Methods Are IDENTICAL So Editing Them Isn't Too
/// Difficult. Please Look At Both Before Adding Your Own Customs...

/// Should You Decide To Use 'HouseDeeds' Rather Than The 'HousePlacementTool':
/// Delete The ENTIRE 'Server.Items' Namespace Below And Delete The 'HousePlacementTool'

/// *** [WARNING] ***
/// You Will Lose Access To The Preset '2-Story And 3-Story Foundations' And Any Newer 
/// Custom Foundations Added To The 'HousePlacementEntry' Methods Below By Doing This.

#endregion

namespace Server.Items
{
	public partial class HousePlacementEntry
	{
		/// HousePlacementTool: Classic Houses
		private static readonly HousePlacementEntry[] m_ClassicHouses = new HousePlacementEntry[]
		{
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011303,    425,    212,    489,    244,    10, 37000,      0,  4,  0,  0x0064  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011304,    425,    212,    489,    244,    10, 37000,      0,  4,  0,  0x0066  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011305,    425,    212,    489,    244,    10, 36750,      0,  4,  0,  0x0068  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011306,    425,    212,    489,    244,    10, 35250,      0,  4,  0,  0x006A  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011307,    425,    212,    489,    244,    10, 36750,      0,  4,  0,  0x006C  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011308,    425,    212,    489,    244,    10, 36750,      0,  4,  0,  0x006E  ),
			new HousePlacementEntry( typeof( SmallShop ),           1011321,    425,    212,    489,    244,    10, 50500,     -1,  4,  0,  0x00A0  ),
			new HousePlacementEntry( typeof( SmallShop ),           1011322,    425,    212,    489,    244,    10, 52500,      0,  4,  0,  0x00A2  ),
			new HousePlacementEntry( typeof( SmallTower ),          1011317,    580,    290,    667,    333,    14, 73500,      3,  4,  0,  0x0098  ),
			new HousePlacementEntry( typeof( TwoStoryVilla ),       1011319,    1100,   550,    1265,   632,    24, 113750,     3,  6,  0,  0x009E  ),
			new HousePlacementEntry( typeof( SandStonePatio ),      1011320,    850,    425,    1265,   632,    24, 76500,     -1,  4,  0,  0x009C  ),
			new HousePlacementEntry( typeof( LogCabin ),            1011318,    1100,   550,    1265,   632,    24, 81750,      1,  6,  0,  0x009A  ),
			new HousePlacementEntry( typeof( GuildHouse ),          1011309,    1370,   685,    1576,   788,    28, 131500,    -1,  7,  0,  0x0074  ),
			new HousePlacementEntry( typeof( TwoStoryHouse ),       1011310,    1370,   685,    1576,   788,    28, 162750,    -3,  7,  0,  0x0076  ),
			new HousePlacementEntry( typeof( TwoStoryHouse ),       1011311,    1370,   685,    1576,   788,    28, 162000,    -3,  7,  0,  0x0078  ),
			new HousePlacementEntry( typeof( LargePatioHouse ),     1011315,    1370,   685,    1576,   788,    28, 129250,    -4,  7,  0,  0x008C  ),
			new HousePlacementEntry( typeof( LargeMarbleHouse ),    1011316,    1370,   685,    1576,   788,    28, 160500,    -4,  7,  0,  0x0096  ),
			new HousePlacementEntry( typeof( Tower ),               1011312,    2119,   1059,   2437,   1218,   42, 366500,     0,  7,  0,  0x007A  ),
			new HousePlacementEntry( typeof( Keep ),                1011313,    2625,   1312,   3019,   1509,   52, 572750,     0, 11,  0,  0x007C  ),
			new HousePlacementEntry( typeof( Castle ),              1011314,    4076,   2038,   4688,   2344,   78, 865250,     0, 16,  0,  0x007E  )
		};

		public static HousePlacementEntry[] ClassicHouses => m_ClassicHouses;


		/// HousePlacementTool: 2-Story Foundations
		private static readonly HousePlacementEntry[] m_TwoStoryFoundations = new HousePlacementEntry[]
		{
			new HousePlacementEntry( typeof( HouseFoundation ),     1060241,    425,    212,    489,    244,    10, 30500,      0,  4,  0,  0x13EC  ), // 7x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060242,    580,    290,    667,    333,    14, 34500,      0,  5,  0,  0x13ED  ), // 7x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060243,    650,    325,    748,    374,    16, 38500,      0,  5,  0,  0x13EE  ), // 7x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060244,    700,    350,    805,    402,    16, 42500,      0,  6,  0,  0x13EF  ), // 7x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060245,    750,    375,    863,    431,    16, 46500,      0,  6,  0,  0x13F0  ), // 7x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060246,    800,    400,    920,    460,    18, 50500,      0,  7,  0,  0x13F1  ), // 7x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060253,    580,    290,    667,    333,    14, 34500,      0,  4,  0,  0x13F8  ), // 8x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060254,    650,    325,    748,    374,    16, 39000,      0,  5,  0,  0x13F9  ), // 8x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060255,    700,    350,    805,    402,    16, 43500,      0,  5,  0,  0x13FA  ), // 8x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060256,    750,    375,    863,    431,    16, 48000,      0,  6,  0,  0x13FB  ), // 8x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060257,    800,    400,    920,    460,    18, 52500,      0,  6,  0,  0x13FC  ), // 8x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060258,    850,    425,    1265,   632,    24, 57000,      0,  7,  0,  0x13FD  ), // 8x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060259,    1100,   550,    1265,   632,    24, 61500,      0,  7,  0,  0x13FE  ), // 8x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060265,    650,    325,    748,    374,    16, 38500,      0,  4,  0,  0x1404  ), // 9x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060266,    700,    350,    805,    402,    16, 43500,      0,  5,  0,  0x1405  ), // 9x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060267,    750,    375,    863,    431,    16, 48500,      0,  5,  0,  0x1406  ), // 9x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060268,    800,    400,    920,    460,    18, 53500,      0,  6,  0,  0x1407  ), // 9x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060269,    850,    425,    1265,   632,    24, 58500,      0,  6,  0,  0x1408  ), // 9x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060270,    1100,   550,    1265,   632,    24, 63500,      0,  7,  0,  0x1409  ), // 9x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060271,    1100,   550,    1265,   632,    24, 68500,      0,  7,  0,  0x140A  ), // 9x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060277,    700,    350,    805,    402,    16, 42500,      0,  4,  0,  0x1410  ), // 10x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060278,    750,    375,    863,    431,    16, 48000,      0,  5,  0,  0x1411  ), // 10x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060279,    800,    400,    920,    460,    18, 53500,      0,  5,  0,  0x1412  ), // 10x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060280,    850,    425,    1265,   632,    24, 59000,      0,  6,  0,  0x1413  ), // 10x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060281,    1100,   550,    1265,   632,    24, 64500,      0,  6,  0,  0x1414  ), // 10x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060282,    1100,   550,    1265,   632,    24, 70000,      0,  7,  0,  0x1415  ), // 10x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060283,    1150,   575,    1323,   661,    24, 75500,      0,  7,  0,  0x1416  ), // 10x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060289,    750,    375,    863,    431,    16, 46500,      0,  4,  0,  0x141C  ), // 11x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060290,    800,    400,    920,    460,    18, 52500,      0,  5,  0,  0x141D  ), // 11x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060291,    850,    425,    1265,   632,    24, 58500,      0,  5,  0,  0x141E  ), // 11x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060292,    1100,   550,    1265,   632,    24, 64500,      0,  6,  0,  0x141F  ), // 11x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060293,    1100,   550,    1265,   632,    24, 70500,      0,  6,  0,  0x1420  ), // 11x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060294,    1150,   575,    1323,   661,    24, 76500,      0,  7,  0,  0x1421  ), // 11x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060295,    1200,   600,    1380,   690,    26, 82500,      0,  7,  0,  0x1422  ), // 11x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060301,    800,    400,    920,    460,    18, 50500,      0,  4,  0,  0x1428  ), // 12x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060302,    850,    425,    1265,   632,    24, 57000,      0,  5,  0,  0x1429  ), // 12x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060303,    1100,   550,    1265,   632,    24, 63500,      0,  5,  0,  0x142A  ), // 12x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060304,    1100,   550,    1265,   632,    24, 70000,      0,  6,  0,  0x142B  ), // 12x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060305,    1150,   575,    1323,   661,    24, 76500,      0,  6,  0,  0x142C  ), // 12x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060306,    1200,   600,    1380,   690,    26, 83000,      0,  7,  0,  0x142D  ), // 12x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060307,    1250,   625,    1438,   719,    26, 89500,      0,  7,  0,  0x142E  ), // 12x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060314,    1100,   550,    1265,   632,    24, 61500,      0,  5,  0,  0x1435  ), // 13x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060315,    1100,   550,    1265,   632,    24, 68500,      0,  5,  0,  0x1436  ), // 13x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060316,    1150,   575,    1323,   661,    24, 75500,      0,  6,  0,  0x1437  ), // 13x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060317,    1200,   600,    1380,   690,    26, 82500,      0,  6,  0,  0x1438  ), // 13x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060318,    1250,   625,    1438,   719,    26, 89500,      0,  7,  0,  0x1439  ), // 13x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060319,    1300,   650,    1495,   747,    28, 96500,      0,  7,  0,  0x143A  )  // 13x13 2-Story Customizable House
		};

		public static HousePlacementEntry[] TwoStoryFoundations => m_TwoStoryFoundations;


		/// HousePlacementTool: 3-Story Foundations
		private static readonly HousePlacementEntry[] m_ThreeStoryFoundations = new HousePlacementEntry[]
		{
			new HousePlacementEntry( typeof( HouseFoundation ),     1060272,    1150,   575,    1323,   661,    24, 73500,      0,  8,  0,  0x140B  ), // 9x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060284,    1200,   600,    1380,   690,    26, 81000,      0,  8,  0,  0x1417  ), // 10x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060285,    1250,   625,    1438,   719,    26, 86500,      0,  8,  0,  0x1418  ), // 10x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060296,    1250,   625,    1438,   719,    26, 88500,      0,  8,  0,  0x1423  ), // 11x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060297,    1300,   650,    1495,   747,    28, 94500,      0,  8,  0,  0x1424  ), // 11x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060298,    1350,   675,    1553,   776,    28, 100500,     0,  9,  0,  0x1425  ), // 11x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060308,    1300,   650,    1495,   747,    28, 96000,      0,  8,  0,  0x142F  ), // 12x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060309,    1350,   675,    1553,   776,    28, 102500,     0,  8,  0,  0x1430  ), // 12x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060310,    1370,   685,    1576,   788,    28, 109000,     0,  9,  0,  0x1431  ), // 12x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060311,    1370,   685,    1576,   788,    28, 115500,     0,  9,  0,  0x1432  ), // 12x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060320,    1350,   675,    1553,   776,    28, 103500,     0,  8,  0,  0x143B  ), // 13x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060321,    1370,   685,    1576,   788,    28, 110500,     0,  8,  0,  0x143C  ), // 13x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060322,    1370,   685,    1576,   788,    28, 117500,     0,  9,  0,  0x143D  ), // 13x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060323,    2119,   1059,   2437,   1218,   42, 124500,     0,  9,  0,  0x143E  ), // 13x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060324,    2119,   1059,   2437,   1218,   42, 131500,     0,  10, 0,  0x143F  ), // 13x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060327,    1150,   575,    1323,   661,    24, 73500,      0,  5,  0,  0x1442  ), // 14x9 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060328,    1200,   600,    1380,   690,    26, 81000,      0,  6,  0,  0x1443  ), // 14x10 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060329,    1250,   625,    1438,   719,    26, 88500,      0,  6,  0,  0x1444  ), // 14x11 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060330,    1300,   650,    1495,   747,    28, 96000,      0,  7,  0,  0x1445  ), // 14x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060331,    1350,   675,    1553,   776,    28, 103500,     0,  7,  0,  0x1446  ), // 14x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060332,    1370,   685,    1576,   788,    28, 111000,     0,  8,  0,  0x1447  ), // 14x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060333,    1370,   685,    1576,   788,    28, 118500,     0,  8,  0,  0x1448  ), // 14x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060334,    2119,   1059,   2437,   1218,   42, 126000,     0,  9,  0,  0x1449  ), // 14x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060335,    2119,   1059,   2437,   1218,   42, 133500,     0,  9,  0,  0x144A  ), // 14x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060336,    2119,   1059,   2437,   1218,   42, 141000,     0,  10, 0,  0x144B  ), // 14x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060340,    1250,   625,    1438,   719,    26, 86500,      0,  6,  0,  0x144F  ), // 15x10 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060341,    1300,   650,    1495,   747,    28, 94500,      0,  6,  0,  0x1450  ), // 15x11 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060342,    1350,   675,    1553,   776,    28, 102500,     0,  7,  0,  0x1451  ), // 15x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060343,    1370,   685,    1576,   788,    28, 110500,     0,  7,  0,  0x1452  ), // 15x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060344,    1370,   685,    1576,   788,    28, 118500,     0,  8,  0,  0x1453  ), // 15x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060345,    2119,   1059,   2437,   1218,   42, 126500,     0,  8,  0,  0x1454  ), // 15x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060346,    2119,   1059,   2437,   1218,   42, 134500,     0,  9,  0,  0x1455  ), // 15x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060347,    2119,   1059,   2437,   1218,   42, 142500,     0,  9,  0,  0x1456  ), // 15x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060348,    2119,   1059,   2437,   1218,   42, 150500,     0,  10, 0,  0x1457  ), // 15x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060353,    1350,   675,    1553,   776,    28, 100500,     0,  6,  0,  0x145C  ), // 16x11 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060354,    1370,   685,    1576,   788,    28, 109000,     0,  7,  0,  0x145D  ), // 16x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060355,    1370,   685,    1576,   788,    28, 117500,     0,  7,  0,  0x145E  ), // 16x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060356,    2119,   1059,   2437,   1218,   42, 126000,     0,  8,  0,  0x145F  ), // 16x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060357,    2119,   1059,   2437,   1218,   42, 134500,     0,  8,  0,  0x1460  ), // 16x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060358,    2119,   1059,   2437,   1218,   42, 143000,     0,  9,  0,  0x1461  ), // 16x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060359,    2119,   1059,   2437,   1218,   42, 151500,     0,  9,  0,  0x1462  ), // 16x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060360,    2119,   1059,   2437,   1218,   42, 160000,     0,  10, 0,  0x1463  ), // 16x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060366,    1370,   685,    1576,   788,    28, 115500,     0,  7,  0,  0x1469  ), // 17x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060367,    2119,   1059,   2437,   1218,   42, 124500,     0,  7,  0,  0x146A  ), // 17x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060368,    2119,   1059,   2437,   1218,   42, 133500,     0,  8,  0,  0x146B  ), // 17x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060369,    2119,   1059,   2437,   1218,   42, 142500,     0,  8,  0,  0x146C  ), // 17x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060370,    2119,   1059,   2437,   1218,   42, 151500,     0,  9,  0,  0x146D  ), // 17x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060371,    2119,   1059,   2437,   1218,   42, 160500,     0,  9,  0,  0x146E  ), // 17x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060372,    2119,   1059,   2437,   1218,   42, 169500,     0,  10, 0,  0x146F  ), // 17x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060379,    2119,   1059,   2437,   1218,   42, 131500,     0,  7,  0,  0x1476  ), // 18x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060380,    2119,   1059,   2437,   1218,   42, 141000,     0,  8,  0,  0x1477  ), // 18x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060381,    2119,   1059,   2437,   1218,   42, 150500,     0,  8,  0,  0x1478  ), // 18x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060382,    2119,   1059,   2437,   1218,   42, 160000,     0,  9,  0,  0x1479  ), // 18x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060383,    2119,   1059,   2437,   1218,   42, 169500,     0,  9,  0,  0x147A  ), // 18x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060384,    2119,   1059,   2437,   1218,   42, 179000,     0,  10, 0,  0x147B  )  // 18x18 3-Story Customizable House
		};

		public static HousePlacementEntry[] ThreeStoryFoundations => m_ThreeStoryFoundations;
	}
}

namespace Server.Multis
{
	public partial class HousePlacementEntry
	{
		/// HouseSystemEntries: Classic Houses
		private static readonly HousePlacementEntry[] m_ClassicHouses = new HousePlacementEntry[]
		{
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011303,    425,    212,    489,    244,    10, 37000,      0,  4,  0,  0x0064  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011304,    425,    212,    489,    244,    10, 37000,      0,  4,  0,  0x0066  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011305,    425,    212,    489,    244,    10, 36750,      0,  4,  0,  0x0068  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011306,    425,    212,    489,    244,    10, 35250,      0,  4,  0,  0x006A  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011307,    425,    212,    489,    244,    10, 36750,      0,  4,  0,  0x006C  ),
			new HousePlacementEntry( typeof( SmallOldHouse ),       1011308,    425,    212,    489,    244,    10, 36750,      0,  4,  0,  0x006E  ),
			new HousePlacementEntry( typeof( SmallShop ),           1011321,    425,    212,    489,    244,    10, 50500,     -1,  4,  0,  0x00A0  ),
			new HousePlacementEntry( typeof( SmallShop ),           1011322,    425,    212,    489,    244,    10, 52500,      0,  4,  0,  0x00A2  ),
			new HousePlacementEntry( typeof( SmallTower ),          1011317,    580,    290,    667,    333,    14, 73500,      3,  4,  0,  0x0098  ),
			new HousePlacementEntry( typeof( TwoStoryVilla ),       1011319,    1100,   550,    1265,   632,    24, 113750,     3,  6,  0,  0x009E  ),
			new HousePlacementEntry( typeof( SandStonePatio ),      1011320,    850,    425,    1265,   632,    24, 76500,     -1,  4,  0,  0x009C  ),
			new HousePlacementEntry( typeof( LogCabin ),            1011318,    1100,   550,    1265,   632,    24, 81750,      1,  6,  0,  0x009A  ),
			new HousePlacementEntry( typeof( GuildHouse ),          1011309,    1370,   685,    1576,   788,    28, 131500,    -1,  7,  0,  0x0074  ),
			new HousePlacementEntry( typeof( TwoStoryHouse ),       1011310,    1370,   685,    1576,   788,    28, 162750,    -3,  7,  0,  0x0076  ),
			new HousePlacementEntry( typeof( TwoStoryHouse ),       1011311,    1370,   685,    1576,   788,    28, 162000,    -3,  7,  0,  0x0078  ),
			new HousePlacementEntry( typeof( LargePatioHouse ),     1011315,    1370,   685,    1576,   788,    28, 129250,    -4,  7,  0,  0x008C  ),
			new HousePlacementEntry( typeof( LargeMarbleHouse ),    1011316,    1370,   685,    1576,   788,    28, 160500,    -4,  7,  0,  0x0096  ),
			new HousePlacementEntry( typeof( Tower ),               1011312,    2119,   1059,   2437,   1218,   42, 366500,     0,  7,  0,  0x007A  ),
			new HousePlacementEntry( typeof( Keep ),                1011313,    2625,   1312,   3019,   1509,   52, 572750,     0, 11,  0,  0x007C  ),
			new HousePlacementEntry( typeof( Castle ),              1011314,    4076,   2038,   4688,   2344,   78, 865250,     0, 16,  0,  0x007E  )
		};

		public static HousePlacementEntry[] ClassicHouses => m_ClassicHouses;


		/// HouseSystemEntries: 2-Story Foundations
		private static readonly HousePlacementEntry[] m_TwoStoryFoundations = new HousePlacementEntry[]
		{
			new HousePlacementEntry( typeof( HouseFoundation ),     1060241,    425,    212,    489,    244,    10, 30500,      0,  4,  0,  0x13EC  ), // 7x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060242,    580,    290,    667,    333,    14, 34500,      0,  5,  0,  0x13ED  ), // 7x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060243,    650,    325,    748,    374,    16, 38500,      0,  5,  0,  0x13EE  ), // 7x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060244,    700,    350,    805,    402,    16, 42500,      0,  6,  0,  0x13EF  ), // 7x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060245,    750,    375,    863,    431,    16, 46500,      0,  6,  0,  0x13F0  ), // 7x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060246,    800,    400,    920,    460,    18, 50500,      0,  7,  0,  0x13F1  ), // 7x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060253,    580,    290,    667,    333,    14, 34500,      0,  4,  0,  0x13F8  ), // 8x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060254,    650,    325,    748,    374,    16, 39000,      0,  5,  0,  0x13F9  ), // 8x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060255,    700,    350,    805,    402,    16, 43500,      0,  5,  0,  0x13FA  ), // 8x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060256,    750,    375,    863,    431,    16, 48000,      0,  6,  0,  0x13FB  ), // 8x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060257,    800,    400,    920,    460,    18, 52500,      0,  6,  0,  0x13FC  ), // 8x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060258,    850,    425,    1265,   632,    24, 57000,      0,  7,  0,  0x13FD  ), // 8x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060259,    1100,   550,    1265,   632,    24, 61500,      0,  7,  0,  0x13FE  ), // 8x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060265,    650,    325,    748,    374,    16, 38500,      0,  4,  0,  0x1404  ), // 9x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060266,    700,    350,    805,    402,    16, 43500,      0,  5,  0,  0x1405  ), // 9x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060267,    750,    375,    863,    431,    16, 48500,      0,  5,  0,  0x1406  ), // 9x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060268,    800,    400,    920,    460,    18, 53500,      0,  6,  0,  0x1407  ), // 9x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060269,    850,    425,    1265,   632,    24, 58500,      0,  6,  0,  0x1408  ), // 9x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060270,    1100,   550,    1265,   632,    24, 63500,      0,  7,  0,  0x1409  ), // 9x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060271,    1100,   550,    1265,   632,    24, 68500,      0,  7,  0,  0x140A  ), // 9x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060277,    700,    350,    805,    402,    16, 42500,      0,  4,  0,  0x1410  ), // 10x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060278,    750,    375,    863,    431,    16, 48000,      0,  5,  0,  0x1411  ), // 10x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060279,    800,    400,    920,    460,    18, 53500,      0,  5,  0,  0x1412  ), // 10x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060280,    850,    425,    1265,   632,    24, 59000,      0,  6,  0,  0x1413  ), // 10x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060281,    1100,   550,    1265,   632,    24, 64500,      0,  6,  0,  0x1414  ), // 10x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060282,    1100,   550,    1265,   632,    24, 70000,      0,  7,  0,  0x1415  ), // 10x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060283,    1150,   575,    1323,   661,    24, 75500,      0,  7,  0,  0x1416  ), // 10x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060289,    750,    375,    863,    431,    16, 46500,      0,  4,  0,  0x141C  ), // 11x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060290,    800,    400,    920,    460,    18, 52500,      0,  5,  0,  0x141D  ), // 11x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060291,    850,    425,    1265,   632,    24, 58500,      0,  5,  0,  0x141E  ), // 11x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060292,    1100,   550,    1265,   632,    24, 64500,      0,  6,  0,  0x141F  ), // 11x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060293,    1100,   550,    1265,   632,    24, 70500,      0,  6,  0,  0x1420  ), // 11x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060294,    1150,   575,    1323,   661,    24, 76500,      0,  7,  0,  0x1421  ), // 11x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060295,    1200,   600,    1380,   690,    26, 82500,      0,  7,  0,  0x1422  ), // 11x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060301,    800,    400,    920,    460,    18, 50500,      0,  4,  0,  0x1428  ), // 12x7 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060302,    850,    425,    1265,   632,    24, 57000,      0,  5,  0,  0x1429  ), // 12x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060303,    1100,   550,    1265,   632,    24, 63500,      0,  5,  0,  0x142A  ), // 12x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060304,    1100,   550,    1265,   632,    24, 70000,      0,  6,  0,  0x142B  ), // 12x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060305,    1150,   575,    1323,   661,    24, 76500,      0,  6,  0,  0x142C  ), // 12x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060306,    1200,   600,    1380,   690,    26, 83000,      0,  7,  0,  0x142D  ), // 12x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060307,    1250,   625,    1438,   719,    26, 89500,      0,  7,  0,  0x142E  ), // 12x13 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060314,    1100,   550,    1265,   632,    24, 61500,      0,  5,  0,  0x1435  ), // 13x8 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060315,    1100,   550,    1265,   632,    24, 68500,      0,  5,  0,  0x1436  ), // 13x9 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060316,    1150,   575,    1323,   661,    24, 75500,      0,  6,  0,  0x1437  ), // 13x10 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060317,    1200,   600,    1380,   690,    26, 82500,      0,  6,  0,  0x1438  ), // 13x11 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060318,    1250,   625,    1438,   719,    26, 89500,      0,  7,  0,  0x1439  ), // 13x12 2-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060319,    1300,   650,    1495,   747,    28, 96500,      0,  7,  0,  0x143A  )  // 13x13 2-Story Customizable House
		};

		public static HousePlacementEntry[] TwoStoryFoundations => m_TwoStoryFoundations;


		/// HouseSystemEntries: 3-Story Foundations
		private static readonly HousePlacementEntry[] m_ThreeStoryFoundations = new HousePlacementEntry[]
		{
			new HousePlacementEntry( typeof( HouseFoundation ),     1060272,    1150,   575,    1323,   661,    24, 73500,      0,  8,  0,  0x140B  ), // 9x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060284,    1200,   600,    1380,   690,    26, 81000,      0,  8,  0,  0x1417  ), // 10x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060285,    1250,   625,    1438,   719,    26, 86500,      0,  8,  0,  0x1418  ), // 10x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060296,    1250,   625,    1438,   719,    26, 88500,      0,  8,  0,  0x1423  ), // 11x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060297,    1300,   650,    1495,   747,    28, 94500,      0,  8,  0,  0x1424  ), // 11x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060298,    1350,   675,    1553,   776,    28, 100500,     0,  9,  0,  0x1425  ), // 11x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060308,    1300,   650,    1495,   747,    28, 96000,      0,  8,  0,  0x142F  ), // 12x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060309,    1350,   675,    1553,   776,    28, 102500,     0,  8,  0,  0x1430  ), // 12x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060310,    1370,   685,    1576,   788,    28, 109000,     0,  9,  0,  0x1431  ), // 12x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060311,    1370,   685,    1576,   788,    28, 115500,     0,  9,  0,  0x1432  ), // 12x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060320,    1350,   675,    1553,   776,    28, 103500,     0,  8,  0,  0x143B  ), // 13x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060321,    1370,   685,    1576,   788,    28, 110500,     0,  8,  0,  0x143C  ), // 13x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060322,    1370,   685,    1576,   788,    28, 117500,     0,  9,  0,  0x143D  ), // 13x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060323,    2119,   1059,   2437,   1218,   42, 124500,     0,  9,  0,  0x143E  ), // 13x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060324,    2119,   1059,   2437,   1218,   42, 131500,     0,  10, 0,  0x143F  ), // 13x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060327,    1150,   575,    1323,   661,    24, 73500,      0,  5,  0,  0x1442  ), // 14x9 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060328,    1200,   600,    1380,   690,    26, 81000,      0,  6,  0,  0x1443  ), // 14x10 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060329,    1250,   625,    1438,   719,    26, 88500,      0,  6,  0,  0x1444  ), // 14x11 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060330,    1300,   650,    1495,   747,    28, 96000,      0,  7,  0,  0x1445  ), // 14x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060331,    1350,   675,    1553,   776,    28, 103500,     0,  7,  0,  0x1446  ), // 14x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060332,    1370,   685,    1576,   788,    28, 111000,     0,  8,  0,  0x1447  ), // 14x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060333,    1370,   685,    1576,   788,    28, 118500,     0,  8,  0,  0x1448  ), // 14x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060334,    2119,   1059,   2437,   1218,   42, 126000,     0,  9,  0,  0x1449  ), // 14x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060335,    2119,   1059,   2437,   1218,   42, 133500,     0,  9,  0,  0x144A  ), // 14x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060336,    2119,   1059,   2437,   1218,   42, 141000,     0,  10, 0,  0x144B  ), // 14x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060340,    1250,   625,    1438,   719,    26, 86500,      0,  6,  0,  0x144F  ), // 15x10 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060341,    1300,   650,    1495,   747,    28, 94500,      0,  6,  0,  0x1450  ), // 15x11 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060342,    1350,   675,    1553,   776,    28, 102500,     0,  7,  0,  0x1451  ), // 15x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060343,    1370,   685,    1576,   788,    28, 110500,     0,  7,  0,  0x1452  ), // 15x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060344,    1370,   685,    1576,   788,    28, 118500,     0,  8,  0,  0x1453  ), // 15x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060345,    2119,   1059,   2437,   1218,   42, 126500,     0,  8,  0,  0x1454  ), // 15x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060346,    2119,   1059,   2437,   1218,   42, 134500,     0,  9,  0,  0x1455  ), // 15x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060347,    2119,   1059,   2437,   1218,   42, 142500,     0,  9,  0,  0x1456  ), // 15x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060348,    2119,   1059,   2437,   1218,   42, 150500,     0,  10, 0,  0x1457  ), // 15x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060353,    1350,   675,    1553,   776,    28, 100500,     0,  6,  0,  0x145C  ), // 16x11 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060354,    1370,   685,    1576,   788,    28, 109000,     0,  7,  0,  0x145D  ), // 16x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060355,    1370,   685,    1576,   788,    28, 117500,     0,  7,  0,  0x145E  ), // 16x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060356,    2119,   1059,   2437,   1218,   42, 126000,     0,  8,  0,  0x145F  ), // 16x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060357,    2119,   1059,   2437,   1218,   42, 134500,     0,  8,  0,  0x1460  ), // 16x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060358,    2119,   1059,   2437,   1218,   42, 143000,     0,  9,  0,  0x1461  ), // 16x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060359,    2119,   1059,   2437,   1218,   42, 151500,     0,  9,  0,  0x1462  ), // 16x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060360,    2119,   1059,   2437,   1218,   42, 160000,     0,  10, 0,  0x1463  ), // 16x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060366,    1370,   685,    1576,   788,    28, 115500,     0,  7,  0,  0x1469  ), // 17x12 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060367,    2119,   1059,   2437,   1218,   42, 124500,     0,  7,  0,  0x146A  ), // 17x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060368,    2119,   1059,   2437,   1218,   42, 133500,     0,  8,  0,  0x146B  ), // 17x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060369,    2119,   1059,   2437,   1218,   42, 142500,     0,  8,  0,  0x146C  ), // 17x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060370,    2119,   1059,   2437,   1218,   42, 151500,     0,  9,  0,  0x146D  ), // 17x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060371,    2119,   1059,   2437,   1218,   42, 160500,     0,  9,  0,  0x146E  ), // 17x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060372,    2119,   1059,   2437,   1218,   42, 169500,     0,  10, 0,  0x146F  ), // 17x18 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060379,    2119,   1059,   2437,   1218,   42, 131500,     0,  7,  0,  0x1476  ), // 18x13 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060380,    2119,   1059,   2437,   1218,   42, 141000,     0,  8,  0,  0x1477  ), // 18x14 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060381,    2119,   1059,   2437,   1218,   42, 150500,     0,  8,  0,  0x1478  ), // 18x15 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060382,    2119,   1059,   2437,   1218,   42, 160000,     0,  9,  0,  0x1479  ), // 18x16 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060383,    2119,   1059,   2437,   1218,   42, 169500,     0,  9,  0,  0x147A  ), // 18x17 3-Story Customizable House
			new HousePlacementEntry( typeof( HouseFoundation ),     1060384,    2119,   1059,   2437,   1218,   42, 179000,     0,  10, 0,  0x147B  )  // 18x18 3-Story Customizable House
		};

		public static HousePlacementEntry[] ThreeStoryFoundations => m_ThreeStoryFoundations;
	}
}