using System.Xml;

namespace Server.Regions
{
	public class TownRegion : GuardedRegion
	{
		public TownRegion(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}
	}
}