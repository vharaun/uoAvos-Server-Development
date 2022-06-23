using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] MeleeWeapons => m_MeleeWeapons;

		#region Backward Compatibility

		public static Type[] WeaponTypes => m_MeleeWeapons;
		public static Type[] MLWeaponTypes => m_MeleeWeapons;
		public static Type[] SEWeaponTypes => m_MeleeWeapons;
		public static Type[] AosWeaponTypes => m_MeleeWeapons;

		#endregion

		private static readonly Type[] m_MeleeWeapons = new Type[]
		{
			typeof( AssassinSpike ),        typeof( DiamondMace ),          typeof( ElvenMachete ),
			typeof( ElvenSpellblade ),      typeof( Leafblade ),            typeof( OrnateAxe ),
			typeof( RadiantScimitar ),      typeof( RuneBlade ),            typeof( WarCleaver ),
			typeof( WildStaff ),

			typeof( Bokuto ),               typeof( Daisho ),               typeof( Kama ),
			typeof( Lajatang ),             typeof( NoDachi ),              typeof( Nunchaku ),
			typeof( Sai ),                  typeof( Tekagi ),               typeof( Tessen ),
			typeof( Tetsubo ),              typeof( Wakizashi ),

			typeof( Scythe ),               typeof( BoneHarvester ),        typeof( Scepter ),
			typeof( BladedStaff ),          typeof( Pike ),                 typeof( DoubleBladedStaff ),
			typeof( Lance ),                typeof( CrescentBlade ),

			typeof( Axe ),                  typeof( BattleAxe ),            typeof( DoubleAxe ),
			typeof( ExecutionersAxe ),      typeof( Hatchet ),              typeof( LargeBattleAxe ),
			typeof( TwoHandedAxe ),         typeof( WarAxe ),               typeof( Club ),
			typeof( Mace ),                 typeof( Maul ),                 typeof( WarHammer ),
			typeof( WarMace ),              typeof( Bardiche ),             typeof( Halberd ),
			typeof( Spear ),                typeof( ShortSpear ),           /*typeof( Pitchfork ),*/
			typeof( WarFork ),              typeof( BlackStaff ),           typeof( GnarledStaff ),
			typeof( QuarterStaff ),         typeof( Broadsword ),           typeof( Cutlass ),
			typeof( Katana ),               typeof( Kryss ),                typeof( Longsword ),
			typeof( Scimitar ),             typeof( VikingSword ),          typeof( Pickaxe ),
			typeof( HammerPick ),           typeof( ButcherKnife ),         typeof( Cleaver ),
			typeof( Dagger ),               typeof( SkinningKnife ),        typeof( ShepherdsCrook )
		};
	}
}