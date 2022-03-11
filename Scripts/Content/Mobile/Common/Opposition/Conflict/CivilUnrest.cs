
using System;

/// CivilUnrest.cs: 
/// The idea surrounding this category is to focus on npc fighting, rioting, and disputes

namespace Server
{
	public partial class OppositionGroup
	{
		#region Rioters And Guards

		private static readonly OppositionGroup m_RiotersAndGuards = new OppositionGroup(new Type[][]
			{
				new Type[]
				{
                    // Add Aggressor(s) Here
                },
				new Type[]
				{
                    // Add Defender(s) Here
                }
			});

		public static OppositionGroup RiotersAndGuards => m_RiotersAndGuards;

		#endregion
	}
}