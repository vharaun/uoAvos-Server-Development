namespace Server.Regions
{
	public sealed class GenericRegion : BaseRegion
	{
		public override bool WeatherSupported => true;

		public GenericRegion(string name, Map map, int priority, params Rectangle2D[] area) : base(name, map, priority, area)
		{
		}

		public GenericRegion(string name, Map map, int priority, params Poly2D[] area) : base(name, map, priority, area)
		{
		}

		public GenericRegion(string name, Map map, int priority, params Rectangle3D[] area) : base(name, map, priority, area)
		{
		}

		public GenericRegion(string name, Map map, int priority, params Poly3D[] area) : base(name, map, priority, area)
		{
		}

		public GenericRegion(string name, Map map, Region parent, params Rectangle2D[] area) : base(name, map, parent, area)
		{
		}

		public GenericRegion(string name, Map map, Region parent, params Poly2D[] area) : base(name, map, parent, area)
		{
		}

		public GenericRegion(string name, Map map, Region parent, params Rectangle3D[] area) : base(name, map, parent, area)
		{
		}

		public GenericRegion(string name, Map map, Region parent, params Poly3D[] area) : base(name, map, parent, area)
		{
		}

		public GenericRegion(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}

		public GenericRegion(int id) : base(id)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}
}