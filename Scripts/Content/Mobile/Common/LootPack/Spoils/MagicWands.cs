using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] SpellWands => m_SpellWands;

		public static Type[] WandTypes => m_SpellWands;
		public static Type[] NewWandTypes => m_SpellWands;
		public static Type[] OldWandTypes => m_SpellWands;

		private static readonly Type[] m_SpellWands = new Type[]
		{
			typeof( FireballWand ),     typeof( LightningWand ),        typeof( MagicArrowWand ),
			typeof( GreaterHealWand ),  typeof( HarmWand ),             typeof( HealWand ),

			typeof( ClumsyWand ),       typeof( FeebleWand ),
			typeof( ManaDrainWand ),    typeof( WeaknessWand ),

			typeof( IDWand )
		};
	}
}