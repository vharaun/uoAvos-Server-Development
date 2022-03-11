using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Armor => m_Armor;

		#region Backward Compatibility

		public static Type[] ArmorTypes => m_Armor;
		public static Type[] MLArmorTypes => m_Armor;
		public static Type[] SEArmorTypes => m_Armor;
		public static Type[] ShieldTypes => m_Armor;
		public static Type[] AosShieldTypes => m_Armor;

		#endregion

		private static readonly Type[] m_Armor = new Type[]
		{
			typeof( Circlet ),              typeof( GemmedCirclet ),        typeof( LeafTonlet ),
			typeof( RavenHelm ),            typeof( RoyalCirclet ),         typeof( VultureHelm ),
			typeof( WingedHelm ),           typeof( LeafArms ),             typeof( LeafChest ),
			typeof( LeafGloves ),           typeof( LeafGorget ),           typeof( LeafLegs ),
			typeof( WoodlandArms ),         typeof( WoodlandChest ),        typeof( WoodlandGloves ),
			typeof( WoodlandGorget ),       typeof( WoodlandLegs ),         typeof( HideChest ),
			typeof( HideGloves ),           typeof( HideGorget ),           typeof( HidePants ),
			typeof( HidePauldrons ),

			typeof( ChainHatsuburi ),       typeof( LeatherDo ),            typeof( LeatherHaidate ),
			typeof( LeatherHiroSode ),      typeof( LeatherJingasa ),       typeof( LeatherMempo ),
			typeof( LeatherNinjaHood ),     typeof( LeatherNinjaJacket ),   typeof( LeatherNinjaMitts ),
			typeof( LeatherNinjaPants ),    typeof( LeatherSuneate ),       typeof( DecorativePlateKabuto ),
			typeof( HeavyPlateJingasa ),    typeof( LightPlateJingasa ),    typeof( PlateBattleKabuto ),
			typeof( PlateDo ),              typeof( PlateHaidate ),         typeof( PlateHatsuburi ),
			typeof( PlateHiroSode ),        typeof( PlateMempo ),           typeof( PlateSuneate ),
			typeof( SmallPlateJingasa ),    typeof( StandardPlateKabuto ),  typeof( StuddedDo ),
			typeof( StuddedHaidate ),       typeof( StuddedHiroSode ),      typeof( StuddedMempo ),
			typeof( StuddedSuneate ),

			typeof( BoneArms ),             typeof( BoneChest ),            typeof( BoneGloves ),
			typeof( BoneLegs ),             typeof( BoneHelm ),             typeof( ChainChest ),
			typeof( ChainLegs ),            typeof( ChainCoif ),            typeof( Bascinet ),
			typeof( CloseHelm ),            typeof( Helmet ),               typeof( NorseHelm ),
			typeof( OrcHelm ),              typeof( FemaleLeatherChest ),   typeof( LeatherArms ),
			typeof( LeatherBustierArms ),   typeof( LeatherChest ),         typeof( LeatherGloves ),
			typeof( LeatherGorget ),        typeof( LeatherLegs ),          typeof( LeatherShorts ),
			typeof( LeatherSkirt ),         typeof( LeatherCap ),           typeof( FemalePlateChest ),
			typeof( PlateArms ),            typeof( PlateChest ),           typeof( PlateGloves ),
			typeof( PlateGorget ),          typeof( PlateHelm ),            typeof( PlateLegs ),
			typeof( RingmailArms ),         typeof( RingmailChest ),        typeof( RingmailGloves ),
			typeof( RingmailLegs ),         typeof( FemaleStuddedChest ),   typeof( StuddedArms ),
			typeof( StuddedBustierArms ),   typeof( StuddedChest ),         typeof( StuddedGloves ),
			typeof( StuddedGorget ),        typeof( StuddedLegs )
		};
	}
}