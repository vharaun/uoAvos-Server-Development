using Server.Items;

using System;

#region Developer Notations

/// This System Utilizes The 'TrickOrTreat' Event And Directly Affects BaseVendor.cs

#endregion

namespace Server.Events.Halloween
{
	internal class HolidaySettings
	{
		public static DateTime StartHalloween => new DateTime(2023, 10, 30);
		public static DateTime FinishHalloween => new DateTime(2023, 11, 01);

		#region Vendor Beggar GiveAway

		public static Item RandomHalloweenItem => (Item)Activator.CreateInstance(m_RandomHalloweenItem[Utility.Random(m_RandomHalloweenItem.Length)]);
		public static Item RandomHalloweenTreat => (Item)Activator.CreateInstance(m_RandomHalloweenTreat[Utility.Random(m_RandomHalloweenTreat.Length)]);

		private static readonly Type[] m_RandomHalloweenItem =
		{
				  typeof( CreepyCake ),
				  typeof( PumpkinPizza ),
				  typeof( GrimWarning ),
				  typeof( HarvestWine ),
				  typeof( MurkyMilk ),
				  typeof( MrPlainsCookies ),
				  typeof( SkullsOnPike ),
				  typeof( ChairInAGhostCostume ),
				  typeof( ExcellentIronMaiden ),
				  typeof( HalloweenGuillotine ),
				  typeof( ColoredSmallWebs )
		};

		private static readonly Type[] m_RandomHalloweenTreat =
		{
				  typeof( Lollipops ),
				  typeof( WrappedCandy ),
				  typeof( JellyBeans ),
				  typeof( Taffy ),
				  typeof( NougatSwirl )
		};

		#endregion
	}
}