using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Clothing => m_Clothing;

		#region Backward Compatibility

		public static Type[] ClothingTypes => m_Clothing;
		public static Type[] MLClothingTypes => m_Clothing;
		public static Type[] SEClothingTypes => m_Clothing;
		public static Type[] AosClothingTypes => m_Clothing;

		public static Type[] HatTypes => m_Clothing;
		public static Type[] SEHatTypes => m_Clothing;
		public static Type[] AosHatTypes => m_Clothing;

		#endregion

		private static readonly Type[] m_Clothing = new Type[]
		{
			typeof( MaleElvenRobe ),        typeof( FemaleElvenRobe ),      typeof( ElvenPants ),
			typeof( ElvenShirt ),           typeof( ElvenDarkShirt ),       typeof( ElvenBoots ),
			typeof( VultureHelm ),          typeof( WoodlandBelt ),

			typeof( ClothNinjaJacket ),     typeof( FemaleKimono ),         typeof( Hakama ),
			typeof( HakamaShita ),          typeof( JinBaori ),             typeof( Kamishimo ),
			typeof( MaleKimono ),           typeof( NinjaTabi ),            typeof( Obi ),
			typeof( SamuraiTabi ),          typeof( TattsukeHakama ),       typeof( Waraji ),

			typeof( FurSarong ),            typeof( FurCape ),              typeof( FlowerGarland ),
			typeof( GildedDress ),          typeof( FurBoots ),             typeof( FormalShirt ),

			typeof( Cloak ),
			typeof( Bonnet ),               typeof( Cap ),                  typeof( FeatheredHat ),
			typeof( FloppyHat ),            typeof( JesterHat ),            typeof( Surcoat ),
			typeof( SkullCap ),             typeof( StrawHat ),             typeof( TallStrawHat ),
			typeof( TricorneHat ),          typeof( WideBrimHat ),          typeof( WizardsHat ),
			typeof( BodySash ),             typeof( Doublet ),              typeof( Boots ),
			typeof( FullApron ),            typeof( JesterSuit ),           typeof( Sandals ),
			typeof( Tunic ),                typeof( Shoes ),                typeof( Shirt ),
			typeof( Kilt ),                 typeof( Skirt ),                typeof( FancyShirt ),
			typeof( FancyDress ),           typeof( ThighBoots ),           typeof( LongPants ),
			typeof( PlainDress ),           typeof( Robe ),                 typeof( ShortPants ),
			typeof( HalfApron ),

			typeof( ClothNinjaHood ),       typeof( Kasa ),

			typeof( FlowerGarland ),    typeof( BearMask ),     typeof( DeerMask ),

			typeof( SkullCap ),         typeof( Bandana ),      typeof( FloppyHat ),
			typeof( Cap ),              typeof( WideBrimHat ),  typeof( StrawHat ),
			typeof( TallStrawHat ),     typeof( WizardsHat ),   typeof( Bonnet ),
			typeof( FeatheredHat ),     typeof( TricorneHat ),  typeof( JesterHat ),
		};
	}
}