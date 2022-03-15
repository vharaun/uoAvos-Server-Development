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
	public class LeafLessTree : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 0xCCA }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { }; } }
		public static void Configure() { RegisterHarvestablePhase(new LeafLessTree()); }
		public override Type StartingGrowthPhase { get { return typeof(LeafLessTree); } }

	}

	public class LeafLessTree2 : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 0xCCB }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { }; } }
		public static void Configure() { RegisterHarvestablePhase(new LeafLessTree2()); }
		public override Type StartingGrowthPhase { get { return typeof(LeafLessTree2); } }
	}

	public class LeafLessTree3 : SmallTree
	{
		public override int[] SmallTreeTrunkGraphics { get { return new int[] { 0xCCC }; } }
		public override int[] SmallTreeLeafGraphics { get { return new int[] { }; } }
		public static void Configure() { RegisterHarvestablePhase(new LeafLessTree3()); }
		public override Type StartingGrowthPhase { get { return typeof(LeafLessTree3); } }
	}
}