using Server.Items;

using System;

#region Developer Notations

/// This System Utilizes The 'PotsOGold' Event And Directly Affects BaseVendor.cs

#endregion

namespace Server.Events.SaintPatrick
{
	internal class HolidaySettings
	{
		public static DateTime StartSaintPatrick => new DateTime(2023, 03, 16);
		public static DateTime FinishSaintPatrick => new DateTime(2023, 03, 18);

		#region Vendor Beggar GiveAway

		public static Item RandomSaintPatrickItem => (Item)Activator.CreateInstance(m_RandomSaintPatrickItem[Utility.Random(m_RandomSaintPatrickItem.Length)]);
		public static Item RandomSaintPatrickTreat => (Item)Activator.CreateInstance(m_RandomSaintPatrickTreat[Utility.Random(m_RandomSaintPatrickTreat.Length)]);

		private static readonly Type[] m_RandomSaintPatrickItem =
		{
				  typeof( CreepyCake ),
				  typeof( PumpkinPizza )
		};

		private static readonly Type[] m_RandomSaintPatrickTreat =
		{
				  typeof( Lollipops ),
				  typeof( WrappedCandy )
		};

		#endregion
	}
}