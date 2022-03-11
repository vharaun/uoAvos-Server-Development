using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Gems => m_Gems;
		public static Type[] GemTypes => m_Gems;

		private static readonly Type[] m_Gems = new Type[]
		{
			typeof( Amber ),                typeof( Amethyst ),             typeof( Citrine ),
			typeof( Diamond ),              typeof( Emerald ),              typeof( Ruby ),
			typeof( Sapphire ),             typeof( StarSapphire ),         typeof( Tourmaline )
		};
	}
}