using Server.Items;

using System;

#region Developer Notations

/// This System Utilizes The 'NaughtyOrNice' Event And Directly Affects BaseVendor.cs

#endregion

namespace Server.Events.Christmas
{
	internal class HolidaySettings
	{
		public static DateTime StartChristmas => new DateTime(2023, 12, 24);
		public static DateTime FinishChristmas => new DateTime(2023, 12, 26);

		#region Vendor Beggar GiveAway

		public static Item RandomChristmasItem => (Item)Activator.CreateInstance(m_RandomChristmasItem[Utility.Random(m_RandomChristmasItem.Length)]);
		public static Item RandomChristmasTreat => (Item)Activator.CreateInstance(m_RandomChristmasTreat[Utility.Random(m_RandomChristmasTreat.Length)]);

		private static readonly Type[] m_RandomChristmasItem =
		{
				  typeof( SnowGlobe ),
				  typeof( WreathAddon )
		};

		private static readonly Type[] m_RandomChristmasTreat =
		{
				  typeof( CandyCane ),
				  typeof( GingerBreadCookie )
		};

		#endregion
	}
}