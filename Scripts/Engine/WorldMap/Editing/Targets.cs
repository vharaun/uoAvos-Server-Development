using Server;
using Server.Commands;
using Server.Commands.Generic;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Engine.Facet
{
	public class BaseLandTarget : Target
	{
		protected IPoint3D m_Location;
		public BaseLandTarget() : base(-1, true, TargetFlags.None)
		{
		}

		protected override void OnTarget(Mobile from, object o)
		{
		}

		protected bool SetupTarget(Mobile from, object o)
		{
			if (!BaseCommand.IsAccessible(from, o))
			{
				from.SendMessage("That is not accessible.");

				return false;
			}

			if (!(o is IPoint3D))
			{
				return false;
			}

			m_Location = (IPoint3D)o;

			return true;
		}
	}

	public class RadialTarget : Target
	{
		private int m_Height;
		private int m_TType;
		private int m_Radius;

		public int Height
		{
			get { return m_Height; }
			set { m_Height = value; }
		}

		public int TType
		{
			get { return m_TType; }
			set { m_TType = value; }
		}

		public int Radius
		{
			get { return m_Radius; }
			set { m_Radius = value; }
		}

		public RadialTarget(int TType, int Radius, int Height) : base(-1, true, TargetFlags.None)
		{
			m_TType = TType;
			m_Radius = Radius;
			m_Height = Height;
		}

		public override Packet GetPacketFor(NetState ns)
		{
			List<TargetObject> objs = new List<TargetObject>();
			List<Point2D> circle = FacetEditingUtility.rasterCircle(new Point2D(0, 0), m_Radius);

			foreach (Point2D p in circle)
			{
				TargetObject t = new TargetObject();

				t.ItemID = 0xA12;
				t.Hue = 35;
				t.xOffset = p.X;
				t.yOffset = p.Y;
				t.zOffset = 0;

				objs.Add(t);
			}

			return new TargetObjectList(objs, ns.Mobile, true);
		}
	}

	public class BaseLandRadialTarget : RadialTarget
	{
		protected IPoint3D m_Location;
		public BaseLandRadialTarget(int TType, int Radius, int Height) : base(TType, Radius, Height)
		{
		}

		protected override void OnTarget(Mobile from, object o)
		{
		}

		protected bool SetupTarget(Mobile from, object o)
		{
			if (!BaseCommand.IsAccessible(from, o))
			{
				from.SendMessage("That is not accessible.");

				return false;
			}

			if (!(o is IPoint3D))
			{
				return false;
			}

			m_Location = (IPoint3D)o;

			return true;
		}
	}
}