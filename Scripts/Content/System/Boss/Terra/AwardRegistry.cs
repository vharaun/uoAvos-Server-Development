using Server.Items;

using System;

namespace Server.Mobiles
{
	public partial class BaseTerraBossAward : Item
	{
		/// Artifact Weapons: Rarity 10
		public static Type[] ArtifactRarity10 => m_ArtifactRarity10;

		private static readonly Type[] m_ArtifactRarity10 = new Type[]
			{
				typeof( LegacyOfTheDreadLord ),
				typeof( TheTaskmaster ),
				typeof( InquisitorsResolution ),
				typeof( BladeOfTheRighteous ),
				typeof( TitansHammer ),
				typeof( ZyronicClaw ),
				typeof( MelisandesCorrodedHatchet),
				typeof( TombstoneOfTheDamned),

				/// Added
				typeof( EternallyCorruptTree ),
			};

		/// Artifact Weapons: Rarity 11
		public static Type[] ArtifactRarity11 => m_ArtifactRarity11;

		private static readonly Type[] m_ArtifactRarity11 = new Type[]
			{
				typeof( TheDragonSlayer ),
				typeof( ArmorOfFortune ),
				typeof( GauntletsOfNobility ),
				typeof( HelmOfInsight ),
				typeof( HolyKnightsBreastplate ),
				typeof( JackalsCollar ),
				typeof( LeggingsOfBane ),
				typeof( MidnightBracers ),
				typeof( OrnateCrownOfTheHarrower ),
				typeof( ShadowDancerLeggings ),
				typeof( TunicOfFire ),
				typeof( VoiceOfTheFallenKing ),
				typeof( BraceletOfHealth ),
				typeof( OrnamentOfTheMagician ),
				typeof( RingOfTheElements ),
				typeof( RingOfTheVile ),
				typeof( Aegis ),
				typeof( ArcaneShield ),
				typeof( AxeOfTheHeavens ),
				typeof( BladeOfInsanity ),
				typeof( BoneCrusher ),
				typeof( BreathOfTheDead ),
				typeof( Frostbringer ),
				typeof( SerpentsFang ),
				typeof( StaffOfTheMagi ),
				typeof( TheBeserkersMaul ),
				typeof( TheDryadBow ),
				typeof( DivineCountenance ),
				typeof( HatOfTheMagi ),
				typeof( HuntersHeaddress ),
				typeof( SpiritOfTheTotem )
			};
	}
}