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
	/// Apple Tree 1
	public class AppleTree : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 3476 }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { 3477, 3478, 3479 }; } }
		public override Type StartingGrowthPhase { get { return typeof(AppleTree); } }
		public static void Configure() { RegisterHarvestablePhase(new AppleTree()); }
	}

	/// Apple Tree 2
	public class AppleTree2 : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 3480 }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { 3481, 3482, 3483 }; } }
		public override Type StartingGrowthPhase { get { return typeof(AppleTree2); } }
		public static void Configure() { RegisterHarvestablePhase(new AppleTree2()); }
	}
}