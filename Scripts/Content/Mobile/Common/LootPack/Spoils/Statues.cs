using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Statues => m_Statues;
		public static Type[] StatueTypes => m_Statues;

		private static readonly Type[] m_Statues = new Type[]
		{
			typeof( StatueSouth ),          typeof( StatueSouth2 ),         typeof( StatueNorth ),
			typeof( StatueWest ),           typeof( StatueEast ),           typeof( StatueEast2 ),
			typeof( StatueSouthEast ),      typeof( BustSouth ),            typeof( BustEast )
		};
	}
}