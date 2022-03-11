using Server.Mobiles;

using System;

/// Ecological.cs: 
/// The idea surrounding this category is to focus on natural selection among creatures

namespace Server
{
	public partial class OppositionGroup
	{
		#region Eagle And Prey

		private static readonly OppositionGroup m_EagleAndPrey = new OppositionGroup(new Type[][]
			{
				new Type[]
				{
					typeof( Eagle )
				},
				new Type[]
				{
					typeof( Snake ),
					typeof( Rabbit ),
					typeof( Squirrel )
				}
			});

		public static OppositionGroup EagleAndPrey => m_EagleAndPrey;

		#endregion
	}
}