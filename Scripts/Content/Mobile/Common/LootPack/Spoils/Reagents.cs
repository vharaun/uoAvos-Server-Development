using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Reagents => m_Reagents;
		public static Type[] RegTypes => m_Reagents;
		public static Type[] NecroRegTypes => m_Reagents;

		private static readonly Type[] m_Reagents = new Type[]
		{
			typeof( BlackPearl ),           typeof( Bloodmoss ),            typeof( Garlic ),
			typeof( Ginseng ),              typeof( MandrakeRoot ),         typeof( Nightshade ),
			typeof( SulfurousAsh ),         typeof( SpidersSilk ),

			typeof( BatWing ),              typeof( GraveDust ),            typeof( DaemonBlood ),
			typeof( NoxCrystal ),           typeof( PigIron ),


		};
	}
}