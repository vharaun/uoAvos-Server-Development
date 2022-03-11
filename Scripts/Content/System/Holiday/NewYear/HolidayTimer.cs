using Server.Items;

using System;

#region Developer Notations

/// This System Utilizes The 'FatherTime' Event And Directly Affects BaseVendor.cs

#endregion

namespace Server.Events.NewYear
{
	internal class HolidaySettings
	{
		public static DateTime StartNewYear => new DateTime(2022, 12, 31);
		public static DateTime FinishNewYear => new DateTime(2023, 01, 02);

		#region Vendor Beggar GiveAway

		public static Item RandomNewYearItem => (Item)Activator.CreateInstance(m_RandomNewYearItem[Utility.Random(m_RandomNewYearItem.Length)]);
		public static Item RandomNewYearTreat => (Item)Activator.CreateInstance(m_RandomNewYearTreat[Utility.Random(m_RandomNewYearTreat.Length)]);

		private static readonly Type[] m_RandomNewYearItem =
		{
			typeof( DragonEasterEgg )
		};

		private static readonly Type[] m_RandomNewYearTreat =
		{
			typeof( EasterEggs ),
			typeof( BrightlyColoredEggs )
		};

		#endregion
	}
}