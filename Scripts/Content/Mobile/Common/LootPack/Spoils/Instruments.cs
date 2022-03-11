using Server.Items;

using System;

namespace Server
{
	public partial class Loot
	{
		public static Type[] Instruments => m_Instruments;
		public static Type[] InstrumentTypes => m_Instruments;
		public static Type[] SEInstrumentTypes => m_Instruments;

		private static readonly Type[] m_Instruments = new Type[]
		{
			typeof( BambooFlute ),

			typeof( Drums ),      typeof( Harp ),             typeof( LapHarp ),
			typeof( Lute ),         typeof( Tambourine ),       typeof( TambourineTassel )
		};
	}
}