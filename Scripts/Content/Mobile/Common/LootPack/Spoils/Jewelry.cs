using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Jewelry => m_Jewelry;
		public static Type[] JewelryTypes => m_Jewelry;

		private static readonly Type[] m_Jewelry = new Type[]
		{
			typeof( GoldRing ),             typeof( GoldBracelet ),
			typeof( SilverRing ),           typeof( SilverBracelet )
		};
	}
}