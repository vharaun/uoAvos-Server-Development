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
	public class TuscanyPineTree : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 7038 }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { }; } }
		public override Type StartingGrowthPhase { get { return typeof(TuscanyPineTree); } }
		public static void Configure() { RegisterHarvestablePhase(new TuscanyPineTree()); }
	}
}