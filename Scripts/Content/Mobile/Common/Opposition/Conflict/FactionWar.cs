using Server.Mobiles;

using System;

/// FactionWar.cs: 
/// The idea surrounding this category is to focus on territorial control

namespace Server
{
	public partial class OppositionGroup
	{
		#region Terathan And Ophidian

		private static readonly OppositionGroup m_TerathansAndOphidians = new OppositionGroup(new Type[][]
		{
			new Type[]
			{
				typeof( TerathanAvenger ),
				typeof( TerathanDrone ),
				typeof( TerathanMatriarch ),
				typeof( TerathanWarrior )
			},
			new Type[]
			{
				typeof( OphidianArchmage ),
				typeof( OphidianKnight ),
				typeof( OphidianMage ),
				typeof( OphidianMatriarch ),
				typeof( OphidianWarrior )
			}
		});

		public static OppositionGroup TerathansAndOphidians => m_TerathansAndOphidians;

		#endregion

		#region Savage And Orc

		private static readonly OppositionGroup m_SavagesAndOrcs = new OppositionGroup(new Type[][]
			{
				new Type[]
				{
					typeof( Orc ),
					typeof( OrcBomber ),
					typeof( OrcBrute ),
					typeof( OrcCaptain ),
					typeof( OrcishLord ),
					typeof( OrcishMage ),
					typeof( SpawnedOrcishLord )
				},
				new Type[]
				{
					typeof( Savage ),
					typeof( SavageRider ),
					typeof( SavageRidgeback ),
					typeof( SavageShaman )
				}
			});

		public static OppositionGroup SavagesAndOrcs => m_SavagesAndOrcs;

		#endregion
	}
}