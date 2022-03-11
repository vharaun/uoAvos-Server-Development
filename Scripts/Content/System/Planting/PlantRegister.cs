using Server.Items;

namespace Server.Engines.Plants
{
	public partial class PlantTypeInfo
	{
		private static readonly PlantTypeInfo[] m_Table = new PlantTypeInfo[]
		{
			new PlantTypeInfo( 0xC83, 0, 0,         PlantType.CampionFlowers,       false, true, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xC86, 0, 0,         PlantType.Poppies,              false, true, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xC88, 0, 10,        PlantType.Snowdrops,            false, true, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xC94, -15, 0,       PlantType.Bulrushes,            false, true, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xC8B, 0, 0,         PlantType.Lilies,               false, true, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xCA5, -8, 0,        PlantType.PampasGrass,          false, true, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xCA7, -10, 0,       PlantType.Rushes,               false, true, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xC97, -20, 0,       PlantType.ElephantEarPlant,     true, false, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xC9F, -20, 0,       PlantType.Fern,                 false, false, true, true,       PlantCategory.Default ),
			new PlantTypeInfo( 0xCA6, -16, -5,      PlantType.PonytailPalm,         false, false, true, true,       PlantCategory.Default ),
			new PlantTypeInfo( 0xC9C, -5, -10,      PlantType.SmallPalm,            false, false, true, true,       PlantCategory.Default ),
			new PlantTypeInfo( 0xD31, 0, -27,       PlantType.CenturyPlant,         true, false, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xD04, 0, 10,        PlantType.WaterPlant,           true, false, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xCA9, 0, 0,         PlantType.SnakePlant,           true, false, true, true,        PlantCategory.Default ),
			new PlantTypeInfo( 0xD2C, 0, 10,        PlantType.PricklyPearCactus,    false, false, true, true,       PlantCategory.Default ),
			new PlantTypeInfo( 0xD26, 0, 10,        PlantType.BarrelCactus,         false, false, true, true,       PlantCategory.Default ),
			new PlantTypeInfo( 0xD27, 0, 10,        PlantType.TribarrelCactus,      false, false, true, true,       PlantCategory.Default ),
			new PlantTypeInfo( 0x28DC, -5, 5,       PlantType.CommonGreenBonsai,    true, false, false, false,      PlantCategory.Common ),
			new PlantTypeInfo( 0x28DF, -5, 5,       PlantType.CommonPinkBonsai,     true, false, false, false,      PlantCategory.Common ),
			new PlantTypeInfo( 0x28DD, -5, 5,       PlantType.UncommonGreenBonsai,  true, false, false, false,      PlantCategory.Uncommon ),
			new PlantTypeInfo( 0x28E0, -5, 5,       PlantType.UncommonPinkBonsai,   true, false, false, false,      PlantCategory.Uncommon ),
			new PlantTypeInfo( 0x28DE, -5, 5,       PlantType.RareGreenBonsai,      true, false, false, false,      PlantCategory.Rare ),
			new PlantTypeInfo( 0x28E1, -5, 5,       PlantType.RarePinkBonsai,       true, false, false, false,      PlantCategory.Rare ),
			new PlantTypeInfo( 0x28E2, -5, 5,       PlantType.ExceptionalBonsai,    true, false, false, false,      PlantCategory.Exceptional ),
			new PlantTypeInfo( 0x28E3, -5, 5,       PlantType.ExoticBonsai,         true, false, false, false,      PlantCategory.Exotic ),
			new PlantTypeInfo( 0x0D25, 0, 0,        PlantType.Cactus,               false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x1A9A, 5, 10,       PlantType.FlaxFlowers,          false, true, false, false,      PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0C84, 0, 0,        PlantType.FoxgloveFlowers,      false, true, false, false,      PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x1A9F, 5, -25,      PlantType.HopsEast,             false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0CC1, 0, 0,        PlantType.OrfluerFlowers,       false, true, false, false,      PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0CFE, -45, -30,    PlantType.CypressTwisted,       false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0C8F, 0, 0,        PlantType.HedgeShort,           false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0CC8, 0, 0,        PlantType.JuniperBush,          true, false, false, false,      PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0C8E, -20, 0,      PlantType.SnowdropPatch,        false, true, false, false,      PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0CB7, 0, 0,        PlantType.Cattails,             false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0CBE, -20, 0,      PlantType.PoppyPatch,           false, true, false, false,      PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0CC9, 0, 0,        PlantType.SpiderTree,           false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0DC1, -5, 15,      PlantType.WaterLily,            false, true, false, false,      PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0CFB, -45, -30,    PlantType.CypressStraight,      false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x0DB8, 0, -20,      PlantType.HedgeTall,            false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x1AA1, 10, -25,     PlantType.HopsSouth,            false, false, false, false,     PlantCategory.Peculiar ),
			new PlantTypeInfo( 0x246C, -25, -20,    PlantType.SugarCanes,           false, false, false, false,     PlantCategory.Peculiar,     1114898, 1114898, 1094702, 1094703, 1095221, 1113715 ),
			new PlantTypeInfo( 0xC9E, -40, -30,     PlantType.CocoaTree,            false, false, false, true,      PlantCategory.Fragrant,     1080536, 1080536, 1080534, 1080531, 1080533, 1113716 )
		};
	}

	public partial class PlantResourceInfo
	{
		private static readonly PlantResourceInfo[] m_ResourceList = new PlantResourceInfo[]
		{
			new PlantResourceInfo( PlantType.ElephantEarPlant, PlantHue.BrightRed, typeof( RedLeaves ) ),
			new PlantResourceInfo( PlantType.PonytailPalm, PlantHue.BrightRed, typeof( RedLeaves ) ),
			new PlantResourceInfo( PlantType.CenturyPlant, PlantHue.BrightRed, typeof( RedLeaves ) ),
			new PlantResourceInfo( PlantType.Poppies, PlantHue.BrightOrange, typeof( OrangePetals ) ),
			new PlantResourceInfo( PlantType.Bulrushes, PlantHue.BrightOrange, typeof( OrangePetals ) ),
			new PlantResourceInfo( PlantType.PampasGrass, PlantHue.BrightOrange, typeof( OrangePetals ) ),
			new PlantResourceInfo( PlantType.SnakePlant, PlantHue.BrightGreen, typeof( GreenThorns ) ),
			new PlantResourceInfo( PlantType.BarrelCactus, PlantHue.BrightGreen, typeof( GreenThorns ) ),
			new PlantResourceInfo( PlantType.CocoaTree, PlantHue.Plain, typeof( CocoaPulp ) )
		};
	}
}