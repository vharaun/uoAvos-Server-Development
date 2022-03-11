using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Potions => m_Potions;
		public static Type[] PotionTypes => m_Potions;

		private static readonly Type[] m_Potions = new Type[]
		{
			typeof( AgilityPotion ),        typeof( StrengthPotion ),       typeof( RefreshPotion ),
			typeof( LesserCurePotion ),     typeof( LesserHealPotion ),     typeof( LesserPoisonPotion )
		};
	}
}