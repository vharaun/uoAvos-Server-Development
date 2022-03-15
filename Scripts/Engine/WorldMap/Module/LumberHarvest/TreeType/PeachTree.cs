//#define CUSTOM_TREE_GRAPHICS

using Server;
using Server.Engine.Facet;
using Server.Engines.Harvest;
using Server.Items;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections.Generic;

namespace Server.Engine.Facet.Module.LumberHarvest
{
	/// Peach Tree 1
	public class PeachTree : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 3484 }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { 3485, 3486, 3487 }; } }
		public override Type StartingGrowthPhase { get { return typeof(PeachTree); } }
		public static void Configure() { RegisterHarvestablePhase(new PeachTree()); }
	}

	/// Peach Tree 2
	public class PeachTree2 : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 3488 }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { 3489, 3490, 3491 }; } }
		public override Type StartingGrowthPhase { get { return typeof(PeachTree2); } }
		public static void Configure() { RegisterHarvestablePhase(new PeachTree2()); }
	}
}