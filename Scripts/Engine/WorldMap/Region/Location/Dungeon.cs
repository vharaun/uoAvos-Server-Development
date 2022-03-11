namespace Server.Regions
{
	public class DungeonRegion : BaseRegion
	{
		public override bool YoungProtected => false;

		public Point3D EntranceLocation { get; set; }
		public Map EntranceMap { get; set; }

		public DungeonRegion(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}

		public override bool AllowHousing(Mobile from, Point3D p)
		{
			return false;
		}

		public override void AlterLightLevel(Mobile m, ref int global, ref int personal)
		{
			global = LightCycle.DungeonLevel;
		}

		public override bool CanUseStuckMenu(Mobile m)
		{
			if (Map == Map.Felucca)
			{
				return false;
			}

			return base.CanUseStuckMenu(m);
		}
	}
}