using Server.Spells.Chivalry;
using Server.Spells.Fourth;
using Server.Spells.Seventh;
using Server.Spells.Sixth;

namespace Server.Regions
{
	public class GreenAcres : BaseRegion
	{
		public GreenAcres(string name, Map map, int priority, params Rectangle2D[] area) : base(name, map, priority, area)
		{
		}

		public GreenAcres(string name, Map map, int priority, params Poly2D[] area) : base(name, map, priority, area)
		{
		}

		public GreenAcres(string name, Map map, int priority, params Rectangle3D[] area) : base(name, map, priority, area)
		{
		}

		public GreenAcres(string name, Map map, int priority, params Poly3D[] area) : base(name, map, priority, area)
		{
		}

		public GreenAcres(string name, Map map, Region parent, params Rectangle2D[] area) : base(name, map, parent, area)
		{
		}

		public GreenAcres(string name, Map map, Region parent, params Poly2D[] area) : base(name, map, parent, area)
		{
		}

		public GreenAcres(string name, Map map, Region parent, params Rectangle3D[] area) : base(name, map, parent, area)
		{
		}

		public GreenAcres(string name, Map map, Region parent, params Poly3D[] area) : base(name, map, parent, area)
		{
		}

		public GreenAcres(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}

		public GreenAcres(int id) : base(id)
		{
		}

		public override bool AllowHousing(Mobile m, Point3D p)
		{
			if (m.AccessLevel < AccessLevel.Counselor)
			{
				return false;
			}

			return base.AllowHousing(m, p);
		}

		public override bool OnBeginSpellCast(Mobile m, ISpell s)
		{
			if (m.AccessLevel < AccessLevel.Counselor)
			{
				if (s is GateTravelSpell || s is RecallSpell || s is MarkSpell || s is SacredJourneySpell)
				{
					m.SendMessage("You cannot cast that spell here.");
					return false;
				}
			}

			return base.OnBeginSpellCast(m, s);
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