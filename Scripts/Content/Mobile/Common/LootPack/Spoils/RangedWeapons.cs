using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] RangedWeapons => m_RangedWeapons;

		#region Backward Compatibility

		public static Type[] RangedWeaponTypes => m_RangedWeapons;
		public static Type[] MLRangedWeaponTypes => m_RangedWeapons;
		public static Type[] SERangedWeaponTypes => m_RangedWeapons;
		public static Type[] AosRangedWeaponTypes => m_RangedWeapons;

		#endregion

		private static readonly Type[] m_RangedWeapons = new Type[]
		{
			typeof( ElvenCompositeLongbow ),    typeof( MagicalShortbow ),

			typeof( Yumi ),

			typeof( CompositeBow ),         typeof( RepeatingCrossbow ),

			typeof( Bow ),                  typeof( Crossbow ),             typeof( HeavyCrossbow ),


		};
	}
}