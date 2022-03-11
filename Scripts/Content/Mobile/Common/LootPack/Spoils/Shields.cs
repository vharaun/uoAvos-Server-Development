using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Shields => m_Shields;


		private static readonly Type[] m_Shields = new Type[]
		{
			typeof( ChaosShield ),          typeof( OrderShield ),

			typeof( BronzeShield ),         typeof( Buckler ),              typeof( HeaterShield ),
			typeof( MetalShield ),          typeof( MetalKiteShield ),      typeof( WoodenKiteShield ),
			typeof( WoodenShield )
		};
	}
}