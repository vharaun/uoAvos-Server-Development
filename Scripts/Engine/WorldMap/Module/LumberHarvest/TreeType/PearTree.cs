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
	/// Pear Tree 1
	public class PearTree : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 3492 }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { 3493, 3494, 3495 }; } }
		public override Type StartingGrowthPhase { get { return typeof(PearTree); } }
		public static void Configure() { RegisterHarvestablePhase(new PearTree()); }
	}

	/// Pear Tree 2
	public class PearTree2 : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 3496 }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { 3497, 3498, 3499 }; } }
		public override Type StartingGrowthPhase { get { return typeof(PearTree2); } }
		public static void Configure() { RegisterHarvestablePhase(new PearTree2()); }
	}
}