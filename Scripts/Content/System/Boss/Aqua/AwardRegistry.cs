using Server.Items;

using System;

namespace Server.Mobiles
{
	public partial class BaseAquaBossAward : Item
	{
		#region Fresh Water Boss Artifact Registry

		public static Type[] FreshWaterArtifact => m_FreshWaterArtifact;

		private static readonly Type[] m_FreshWaterArtifact = new Type[]
		{
			// Reserved For Future Expansion
		};

		/// Bonus: Custom Leveled Treasure Chests
		public static Type[] AncientFWaterTreasureChest => m_AncientFWaterTreasureChest;

		private static readonly Type[] m_AncientFWaterTreasureChest = new Type[]
		{
			// Reserved For Future Expansion
		};

		#endregion

		#region Salty Water Boss Artifact Registry

		public static Type[] SaltWaterArtifact => m_SaltWaterArtifact;

		private static readonly Type[] m_SaltWaterArtifact = new Type[]
		{
			// Decorations
			typeof( CandelabraOfSouls ),
			typeof( GhostShipAnchor ),
			typeof( SeahorseStatuette ),
			typeof( ShipModel ),
			typeof( AdmiralsHeartyRum ),
			typeof( ShimmeringCrystals ),

			// Equipment
			typeof( CaptainQuacklebushsCutlass ),
			typeof( DreadPirateHat ),
			typeof( ColdBlood ),
		};

		/// Bonus: Custom Leveled Treasure Chests
		public static Type[] AncientSWaterTreasureChest => m_AncientSWaterTreasureChest;

		private static readonly Type[] m_AncientSWaterTreasureChest = new Type[]
		{
			// Reserved For Future Expansion
		};

		#endregion
	}
}