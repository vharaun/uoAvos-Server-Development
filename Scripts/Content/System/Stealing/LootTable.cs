using Server.Engines.Stealables;

namespace Server.Items
{
	public partial class StealableSpawner : Item
	{
		private static readonly StealableEntry[] m_Entries = new StealableEntry[]
		{
			#region Stealable Server Rares

			/// Container
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Bucket ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( ClosedBarrel ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( UnfinishedBarrel ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( WaterBarrel ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Tub ) ),

			/// Dirty Cookware
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DirtyKettle ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DirtySmallPot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DirtyFrypan ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DirtyRoundPot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DirtyPot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DirtySmallRoundPot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DirtyPan ) ),

			/// Dried
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( WhiteDriedFlowers ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( GreenDriedFlowers ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DriedOnions ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DriedHerbs ) ),

			/// Flower
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoFlower ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoFlower2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoRoseOfTrinsic ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoRoseOfTrinsic2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoRoseOfTrinsic3 ) ),

			/// Food
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoBottlesOfLiquor ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( SkinnedFish ) ),

			/// Furniture
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( BrokenChair ) ),

			/// Game
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Checkers ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Checkers2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Chessmen ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Chessmen2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Chessmen3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Cards ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Cards2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Cards3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Cards4 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoCards5 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( PlayingCards ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( PlayingCards2 ) ),

			/// Glass Jar
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( EmptyJar ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( EmptyJars ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( EmptyJars2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( EmptyJars3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( EmptyJars4 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoFullJar ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoFullJars3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoFullJars4 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( HalfEmptyJar ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( HalfEmptyJars ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Jars2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Jars3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Jars4 ) ),

			/// Ingot
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGoldIngot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGoldIngot2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGoldIngots ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGoldIngots2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGoldIngots3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGoldIngots4 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngot2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngots ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngots2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngots3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngots4 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngots5 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoIronIngots6 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSilverIngot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSilverIngot2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSilverIngots ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSilverIngots2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSilverIngots3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSilverIngots4 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSilverIngots5 ) ),

			/// Magic
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoCrystalBall ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoMagicalCrystal ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoDeckOfTarot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoDeckOfTarot2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTarot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTarot2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTarot3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTarot4 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTarot5 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTarot6 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTarot7 ) ),

			/// Magic: Reagent
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoBlackmoor ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoBloodspawn ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoBrimstone ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoDragonsBlood ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoDragonsBlood2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoEyeOfNewt ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGarlic ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGarlic2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGarlicBulb ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGarlicBulb2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGinseng ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGinseng2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGinsengRoot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoGinsengRoot2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoMandrake ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoMandrake2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoMandrake3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoMandrakeRoot ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoMandrakeRoot2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoNightshade ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoNightshade2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoNightshade3 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoObsidian ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoPumice ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoWyrmsHeart ) ),

			/// Miscellaneous
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoSpittoon ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( PaintsAndBrush ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( PenAndInk ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTray ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoTray2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( TeakwoodTray ) ),

			/// Rock
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoRock ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoRock2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoRocks ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoRocks2 ) ),

			/// Stable
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoBridle ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoBridle2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoHay ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoHay2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoHorseDung ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Whip ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Rope ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( HorseShoes ) ),

			/// Trade
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( ToolKit ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( EmptyToolKit ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( EmptyToolKit2 ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( Lockpicks ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( ChiselsNorth ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( ChiselsWest ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( ForgedMetal ) ),

			/// Weapon: Ammunition
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( DecoArrowShafts ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( CrossbowBolts ) ),

			/// Wire
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( IronWire ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( SilverWire ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( GoldWire ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0,  0 ), 72, 108, typeof( CopperWire ) ),

			#endregion

			#region Stealable Server Relic

			/// Container
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket1Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket2Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket3NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket3WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket4Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket5NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket5WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Basket6Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BackpackArtifact ) ),

			/// Flower
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( FlowersArtifact ) ),

			/// Medallion
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( AncientMedallion ) ),

			/// Miscellaneous
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BowlArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BowlsVerticalArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BowlsHorizontalArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( CupsArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( FanNorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( FanWestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( TripleFanNorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( TripleFanWestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( TeapotNorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( TeapotWestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( TowerLanternArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Urn1Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Urn2Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( ZenRock1Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( ZenRock2Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( ZenRock3Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BloodyWaterArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BooksNorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BooksWestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BooksFaceDownArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BottleArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( BrazierArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( CocoonArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( DamagedBooksArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( EggCaseArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( GruesomeStandardArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( LampPostArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( LeatherTunicArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( RockArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SaddleArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SkinnedDeerArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SkinnedGoatArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SkullCandleArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( StretchedHideArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( StuddedTunicArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( StuddedLeggingsArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( TarotCardsArtifact ) ),

			/// Painting
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting1NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting1WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting2NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting2WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting3Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting4NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting4WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting5NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting5WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting6NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Painting6WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( RuinedPaintingArtifact ) ),

			/// Food
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SakeArtifact ) ),

			/// Sculpture
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Sculpture1Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( Sculpture2Artifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( DolphinRightArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( DolphinLeftArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( ManStatuetteSouthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( ManStatuetteEastArtifact ) ),

			/// SwordDisplay
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay1NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay1WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay2NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay2WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay3SouthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay3EastArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay4NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay4WestArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay5NorthArtifact ) ),
			new StealableEntry( Map.Trammel, new Point3D( 0,  0, 0 ), 72, 108, typeof( SwordDisplay5WestArtifact ) )

			#endregion
		};
	}
}