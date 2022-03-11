using Server.Items;

using System;

#region Developer Notations

/// This System Utilizes The 'CupidKiss' Event And Directly Affects BaseVendor.cs

#endregion

namespace Server.Events.Valentine
{
	internal class HolidaySettings
	{
		public static DateTime StartValentine => new DateTime(2023, 02, 13);
		public static DateTime FinishValentine => new DateTime(2023, 02, 15);

		#region Vendor Beggar GiveAway

		public static Item RandomValentineItem => (Item)Activator.CreateInstance(m_RandomValentineItem[Utility.Random(m_RandomValentineItem.Length)]);
		public static Item RandomValentineTreat => (Item)Activator.CreateInstance(m_RandomValentineTreat[Utility.Random(m_RandomValentineTreat.Length)]);

		private static readonly Type[] m_RandomValentineItem =
		{
			typeof( DragonEasterEgg )
		};

		private static readonly Type[] m_RandomValentineTreat =
		{
			typeof( EasterEggs ),
			typeof( BrightlyColoredEggs )
		};

		#endregion
	}
}