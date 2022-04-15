namespace Server.Regions
{
	public class Jail : BaseRegion
	{
		public Jail(string name, Map map, int priority, params Rectangle2D[] area) : base(name, map, priority, area)
		{
		}

		public Jail(string name, Map map, int priority, params Poly2D[] area) : base(name, map, priority, area)
		{
		}

		public Jail(string name, Map map, int priority, params Rectangle3D[] area) : base(name, map, priority, area)
		{
		}

		public Jail(string name, Map map, int priority, params Poly3D[] area) : base(name, map, priority, area)
		{
		}

		public Jail(string name, Map map, Region parent, params Rectangle2D[] area) : base(name, map, parent, area)
		{
		}

		public Jail(string name, Map map, Region parent, params Poly2D[] area) : base(name, map, parent, area)
		{
		}

		public Jail(string name, Map map, Region parent, params Rectangle3D[] area) : base(name, map, parent, area)
		{
		}

		public Jail(string name, Map map, Region parent, params Poly3D[] area) : base(name, map, parent, area)
		{
		}

		public Jail(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}

		public Jail(int id) : base(id)
		{
		}

		protected override void DefaultInit()
		{
			base.DefaultInit();

			HousingAllowed = false;
		}

		public override bool AllowBeneficial(Mobile from, Mobile target)
		{
			if (from.AccessLevel < AccessLevel.Counselor)
			{
				from.SendMessage("You may not do that in jail.");
				return false;
			}

			return true;
		}

		public override bool AllowHarmful(Mobile from, Mobile target)
		{
			if (from.AccessLevel < AccessLevel.Counselor)
			{
				from.SendMessage("You may not do that in jail.");
				return false;
			}

			return true;
		}

		public override void AlterLightLevel(Mobile m, ref int global, ref int personal)
		{
			base.AlterLightLevel(m, ref global, ref personal);

			global = LightCycle.JailLevel;
		}

		public override bool OnBeginSpellCast(Mobile from, ISpell s)
		{
			if (from.AccessLevel < AccessLevel.Counselor)
			{
				from.SendLocalizedMessage(502629); // You cannot cast spells here.
				return false;
			}

			return true;
		}

		public override bool OnSkillUse(Mobile from, int Skill)
		{
			if (from.AccessLevel < AccessLevel.Counselor)
			{
				from.SendMessage("You may not use skills in jail.");
				return false;
			}

			return true;
		}

		public override bool OnCombatantChange(Mobile from, Mobile Old, Mobile New)
		{
			return from.AccessLevel >= AccessLevel.Counselor;
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