using Server.Items;

using System;

#region Developer Notations

/// This System Utilizes The 'Eggfest' Event And Directly Affects BaseVendor.cs

#endregion

namespace Server.Events.Easter
{
	internal class HolidaySettings
	{
		public static DateTime StartEaster => new DateTime(2023, 04, 16);
		public static DateTime FinishEaster => new DateTime(2023, 04, 18);

		#region Vendor Beggar GiveAway

		public static Item RandomEasterItem => (Item)Activator.CreateInstance(m_RandomEasterItem[Utility.Random(m_RandomEasterItem.Length)]);
		public static Item RandomEasterTreat => (Item)Activator.CreateInstance(m_RandomEasterTreat[Utility.Random(m_RandomEasterTreat.Length)]);

		private static readonly Type[] m_RandomEasterItem =
		{
			typeof( DragonEasterEgg )
		};

		private static readonly Type[] m_RandomEasterTreat =
		{
			typeof( EasterEggs ),
			typeof( BrightlyColoredEggs )
		};

		#endregion
	}
}