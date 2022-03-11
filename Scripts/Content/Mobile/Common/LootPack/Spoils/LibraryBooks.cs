using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] LibraryBooks => m_LibraryBooks;
		public static Type[] LibraryBookTypes => m_LibraryBooks;

		private static readonly Type[] m_LibraryBooks = new Type[]
		{
			typeof( GrammarOfOrcish ),      typeof( CallToAnarchy ),                typeof( ArmsAndWeaponsPrimer ),
			typeof( SongOfSamlethe ),       typeof( TaleOfThreeTribes ),            typeof( GuideToGuilds ),
			typeof( BirdsOfBritannia ),     typeof( BritannianFlora ),              typeof( ChildrenTalesVol2 ),
			typeof( TalesOfVesperVol1 ),    typeof( DeceitDungeonOfHorror ),        typeof( DimensionalTravel ),
			typeof( EthicalHedonism ),      typeof( MyStory ),                      typeof( DiversityOfOurLand ),
			typeof( QuestOfVirtues ),       typeof( RegardingLlamas ),              typeof( TalkingToWisps ),
			typeof( TamingDragons ),        typeof( BoldStranger ),                 typeof( BurningOfTrinsic ),
			typeof( TheFight ),             typeof( LifeOfATravellingMinstrel ),    typeof( MajorTradeAssociation ),
			typeof( RankingsOfTrades ),     typeof( WildGirlOfTheForest ),          typeof( TreatiseOnAlchemy ),
			typeof( VirtueBook )
		};
	}
}