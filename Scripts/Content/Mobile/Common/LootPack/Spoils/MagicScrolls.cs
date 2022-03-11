using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] SpellScrolls => m_SpellScrolls;

		#region Backward Compatibility

		public static Type[] RegularScrollTypes => m_SpellScrolls;
		public static Type[] NecromancyScrollTypes => m_SpellScrolls;
		public static Type[] SENecromancyScrollTypes => m_SpellScrolls;
		public static Type[] PaladinScrollTypes => m_SpellScrolls;
		public static Type[] ArcanistScrollTypes => m_SpellScrolls;

		#endregion

		private static readonly Type[] m_SpellScrolls = new Type[]
		{
			typeof( ReactiveArmorScroll ),  typeof( ClumsyScroll ),         typeof( CreateFoodScroll ),     typeof( FeeblemindScroll ),
			typeof( HealScroll ),           typeof( MagicArrowScroll ),     typeof( NightSightScroll ),     typeof( WeakenScroll ),
			typeof( AgilityScroll ),        typeof( CunningScroll ),        typeof( CureScroll ),           typeof( HarmScroll ),
			typeof( MagicTrapScroll ),      typeof( MagicUnTrapScroll ),    typeof( ProtectionScroll ),     typeof( StrengthScroll ),
			typeof( BlessScroll ),          typeof( FireballScroll ),       typeof( MagicLockScroll ),      typeof( PoisonScroll ),
			typeof( TelekinisisScroll ),    typeof( TeleportScroll ),       typeof( UnlockScroll ),         typeof( WallOfStoneScroll ),
			typeof( ArchCureScroll ),       typeof( ArchProtectionScroll ), typeof( CurseScroll ),          typeof( FireFieldScroll ),
			typeof( GreaterHealScroll ),    typeof( LightningScroll ),      typeof( ManaDrainScroll ),      typeof( RecallScroll ),
			typeof( BladeSpiritsScroll ),   typeof( DispelFieldScroll ),    typeof( IncognitoScroll ),      typeof( MagicReflectScroll ),
			typeof( MindBlastScroll ),      typeof( ParalyzeScroll ),       typeof( PoisonFieldScroll ),    typeof( SummonCreatureScroll ),
			typeof( DispelScroll ),         typeof( EnergyBoltScroll ),     typeof( ExplosionScroll ),      typeof( InvisibilityScroll ),
			typeof( MarkScroll ),           typeof( MassCurseScroll ),      typeof( ParalyzeFieldScroll ),  typeof( RevealScroll ),
			typeof( ChainLightningScroll ), typeof( EnergyFieldScroll ),    typeof( FlamestrikeScroll ),    typeof( GateTravelScroll ),
			typeof( ManaVampireScroll ),    typeof( MassDispelScroll ),     typeof( MeteorSwarmScroll ),    typeof( PolymorphScroll ),
			typeof( EarthquakeScroll ),     typeof( EnergyVortexScroll ),   typeof( ResurrectionScroll ),   typeof( SummonAirElementalScroll ),
			typeof( SummonDaemonScroll ),   typeof( SummonEarthElementalScroll ),   typeof( SummonFireElementalScroll ),    typeof( SummonWaterElementalScroll ),

			typeof( AnimateDeadScroll ),        typeof( BloodOathScroll ),      typeof( CorpseSkinScroll ), typeof( CurseWeaponScroll ),
			typeof( EvilOmenScroll ),           typeof( HorrificBeastScroll ),  typeof( LichFormScroll ),   typeof( MindRotScroll ),
			typeof( PainSpikeScroll ),          typeof( PoisonStrikeScroll ),   typeof( StrangleScroll ),   typeof( SummonFamiliarScroll ),
			typeof( VampiricEmbraceScroll ),    typeof( VengefulSpiritScroll ), typeof( WitherScroll ),     typeof( WraithFormScroll ),

			typeof( AnimateDeadScroll ),        typeof( BloodOathScroll ),      typeof( CorpseSkinScroll ), typeof( CurseWeaponScroll ),
			typeof( EvilOmenScroll ),           typeof( HorrificBeastScroll ),  typeof( LichFormScroll ),   typeof( MindRotScroll ),
			typeof( PainSpikeScroll ),          typeof( PoisonStrikeScroll ),   typeof( StrangleScroll ),   typeof( SummonFamiliarScroll ),
			typeof( VampiricEmbraceScroll ),    typeof( VengefulSpiritScroll ), typeof( WitherScroll ),     typeof( WraithFormScroll ),
			typeof( ExorcismScroll ),

			typeof( ArcaneCircleScroll ),   typeof( GiftOfRenewalScroll ),  typeof( ImmolatingWeaponScroll ),   typeof( AttuneWeaponScroll ),
			typeof( ThunderstormScroll ),   typeof( NatureFuryScroll ),		/*typeof( SummonFeyScroll ),			typeof( SummonFiendScroll ),*/
               typeof( ReaperFormScroll ),     typeof( WildfireScroll ),       typeof( EssenceOfWindScroll ),      typeof( DryadAllureScroll ),
			typeof( EtherealVoyageScroll ), typeof( WordOfDeathScroll ),    typeof( GiftOfLifeScroll ),         typeof( ArcaneEmpowermentScroll )
		};
	}
}