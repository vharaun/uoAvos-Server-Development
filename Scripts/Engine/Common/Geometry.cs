
using Server.Targeting;

using System;

namespace Server.Misc
{
	public delegate void DoEffect_Callback(Point3D p, Map map);

	public static class Geometry
	{
		public static void Swap<T>(ref T a, ref T b)
		{
			var temp = a;
			a = b;
			b = temp;
		}

		public static double RadiansToDegrees(double angle)
		{
			return angle * (180.0 / Math.PI);
		}

		public static double DegreesToRadians(double angle)
		{
			return angle * (Math.PI / 180.0);
		}

		public class CirclePoint
		{
			private Point2D point;
			private readonly int angle;
			private readonly int quadrant;

			public Point2D Point => point;
			public int Angle => angle;
			public int Quadrant => quadrant;

			public CirclePoint(Point2D point, int angle, int quadrant)
			{
				this.point = point;
				this.angle = angle;
				this.quadrant = quadrant;
			}
		}

		public static Point2D ArcPoint(Point3D loc, int radius, int angle)
		{
			int sideA, sideB;

			if (angle < 0)
			{
				angle = 0;
			}

			if (angle > 90)
			{
				angle = 90;
			}

			sideA = (int)Math.Round(radius * Math.Sin(DegreesToRadians(angle)));
			sideB = (int)Math.Round(radius * Math.Cos(DegreesToRadians(angle)));

			return new Point2D(loc.X - sideB, loc.Y - sideA);
		}

		public static void Circle2D(Point3D loc, Map map, int radius, DoEffect_Callback effect)
		{
			Circle2D(loc, map, radius, effect, 0, 360);
		}

		public static void Circle2D(Point3D loc, Map map, int radius, DoEffect_Callback effect, int angleStart, int angleEnd)
		{
			if (angleStart < 0 || angleStart > 360)
			{
				angleStart = 0;
			}

			if (angleEnd > 360 || angleEnd < 0)
			{
				angleEnd = 360;
			}

			if (angleStart == angleEnd)
			{
				return;
			}

			var opposite = angleStart > angleEnd;

			var startQuadrant = angleStart / 90;
			var endQuadrant = angleEnd / 90;

			var start = ArcPoint(loc, radius, angleStart % 90);
			var end = ArcPoint(loc, radius, angleEnd % 90);

			if (opposite)
			{
				Swap(ref start, ref end);
				Swap(ref startQuadrant, ref endQuadrant);
			}

			var startPoint = new CirclePoint(start, angleStart, startQuadrant);
			var endPoint = new CirclePoint(end, angleEnd, endQuadrant);

			var error = -radius;
			var x = radius;
			var y = 0;

			while (x > y)
			{
				plot4points(loc, map, x, y, startPoint, endPoint, effect, opposite);
				plot4points(loc, map, y, x, startPoint, endPoint, effect, opposite);

				error += (y * 2) + 1;
				++y;

				if (error >= 0)
				{
					--x;
					error -= x * 2;
				}
			}

			plot4points(loc, map, x, y, startPoint, endPoint, effect, opposite);
		}

		public static void plot4points(Point3D loc, Map map, int x, int y, CirclePoint start, CirclePoint end, DoEffect_Callback effect, bool opposite)
		{
			var pointA = new Point2D(loc.X - x, loc.Y - y);
			var pointB = new Point2D(loc.X - y, loc.Y - x);

			var quadrant = 2;

			if (x == 0 && start.Quadrant == 3)
			{
				quadrant = 3;
			}

			if (WithinCircleBounds(quadrant == 3 ? pointB : pointA, quadrant, loc, start, end, opposite))
			{
				effect(new Point3D(loc.X + x, loc.Y + y, loc.Z), map);
			}

			quadrant = 3;

			if (y == 0 && start.Quadrant == 0)
			{
				quadrant = 0;
			}

			if (x != 0 && WithinCircleBounds(quadrant == 0 ? pointA : pointB, quadrant, loc, start, end, opposite))
			{
				effect(new Point3D(loc.X - x, loc.Y + y, loc.Z), map);
			}

			if (y != 0 && WithinCircleBounds(pointB, 1, loc, start, end, opposite))
			{
				effect(new Point3D(loc.X + x, loc.Y - y, loc.Z), map);
			}

			if (x != 0 && y != 0 && WithinCircleBounds(pointA, 0, loc, start, end, opposite))
			{
				effect(new Point3D(loc.X - x, loc.Y - y, loc.Z), map);
			}
		}

		public static bool WithinCircleBounds(Point2D pointLoc, int pointQuadrant, Point3D center, CirclePoint start, CirclePoint end, bool opposite)
		{
			if (start.Angle == 0 && end.Angle == 360)
			{
				return true;
			}

			var startX = start.Point.X;
			var startY = start.Point.Y;
			var endX = end.Point.X;
			var endY = end.Point.Y;

			var x = pointLoc.X;
			var y = pointLoc.Y;

			if (pointQuadrant < start.Quadrant || pointQuadrant > end.Quadrant)
			{
				return opposite;
			}

			if (pointQuadrant > start.Quadrant && pointQuadrant < end.Quadrant)
			{
				return !opposite;
			}

			var withinBounds = true;

			if (start.Quadrant == end.Quadrant)
			{
				if (startX == endX && (x > startX || y > startY || y < endY))
				{
					withinBounds = false;
				}
				else if (startY == endY && (y < startY || x < startX || x > endX))
				{
					withinBounds = false;
				}
				else if (x < startX || x > endX || y > startY || y < endY)
				{
					withinBounds = false;
				}
			}
			else if (pointQuadrant == start.Quadrant && (x < startX || y > startY))
			{
				withinBounds = false;
			}
			else if (pointQuadrant == end.Quadrant && (x > endX || y < endY))
			{
				withinBounds = false;
			}

			return opposite ? !withinBounds : withinBounds;
		}

		public static void Line2D(IPoint3D start, IPoint3D end, Map map, DoEffect_Callback effect)
		{
			var steep = Math.Abs(end.Y - start.Y) > Math.Abs(end.X - start.X);

			var x0 = start.X;
			var x1 = end.X;
			var y0 = start.Y;
			var y1 = end.Y;

			if (steep)
			{
				Swap(ref x0, ref y0);
				Swap(ref x1, ref y1);
			}

			if (x0 > x1)
			{
				Swap(ref x0, ref x1);
				Swap(ref y0, ref y1);
			}

			var deltax = x1 - x0;
			var deltay = Math.Abs(y1 - y0);
			var error = deltax / 2;
			var ystep = y0 < y1 ? 1 : -1;
			var y = y0;

			for (var x = x0; x <= x1; x++)
			{
				if (steep)
				{
					effect(new Point3D(y, x, start.Z), map);
				}
				else
				{
					effect(new Point3D(x, y, start.Z), map);
				}

				error -= deltay;

				if (error < 0)
				{
					y += ystep;
					error += deltax;
				}
			}
		}

		public static bool GetHeight(IPoint3D p, out int h)
		{
			h = 0;

			if (p is LandTarget)
			{
				h = 1;
			}
			else if (p is StaticTarget s)
			{
				h = Math.Max(1, s.Data.CalcHeight);
			}
			else if (p is Mobile)
			{
				h = 16;
			}
			else if (p is Item i)
			{
				if (i.Parent != null)
				{
					return false;
				}

				h = Math.Max(1, i.ItemData.CalcHeight);
			}

			return true;
		}

		public static bool GetHeight(LandTile l, out int h)
		{
			h = l.Ignored ? 0 : 1;

			return h > 0;
		}

		public static bool GetHeight(StaticTile s, out int h)
		{
			try
			{
				h = s.Ignored ? 0 : Math.Max(1, TileData.ItemTable[s.ID].CalcHeight);

				return h > 0;
			}
			catch
			{
				h = 0;

				return false;
			}
		}

		public static bool Intersects(StaticTile p1, StaticTile p2)
		{
			return GetHeight(p1, out var h1) && GetHeight(p2, out var h2) && Intersects(p1.X, p1.Y, p1.Z, h1, p2.X, p2.Y, p2.Z, h2);
		}

		public static bool Intersects(StaticTile p1, int x2, int y2, int z2, int h2)
		{
			return GetHeight(p1, out var h1) && Intersects(p1.X, p1.Y, p1.Z, h1, x2, y2, z2, h2);
		}

		public static bool Intersects(int x1, int y1, int z1, int h1, StaticTile p2)
		{
			return GetHeight(p2, out var h2) && Intersects(x1, y1, z1, h1, p2.X, p2.Y, p2.Z, h2);
		}

		public static bool Intersects(int z1, int h1, StaticTile p2)
		{
			return GetHeight(p2, out var h2) && Intersects(0, 0, z1, h1, 0, 0, p2.Z, h2);
		}

		public static bool Intersects(StaticTile p1, int z2, int h2)
		{
			return GetHeight(p1, out var h1) && Intersects(0, 0, p1.Z, h1, 0, 0, z2, h2);
		}

		public static bool Intersects(IPoint3D p1, IPoint3D p2)
		{
			return GetHeight(p1, out var h1) && GetHeight(p2, out var h2) && Intersects(p1.X, p1.Y, p1.Z, h1, p2.X, p2.Y, p2.Z, h2);
		}

		public static bool Intersects(IPoint3D p1, int x2, int y2, int z2, int h2)
		{
			return GetHeight(p1, out var h1) && Intersects(p1.X, p1.Y, p1.Z, h1, x2, y2, z2, h2);
		}

		public static bool Intersects(int x1, int y1, int z1, int h1, IPoint3D p2)
		{
			return GetHeight(p2, out var h2) && Intersects(x1, y1, z1, h1, p2.X, p2.Y, p2.Z, h2);
		}

		public static bool Intersects(int z1, int h1, IPoint3D p2)
		{
			return GetHeight(p2, out var h2) && Intersects(0, 0, z1, h1, 0, 0, p2.Z, h2);
		}

		public static bool Intersects(IPoint3D p1, int z2, int h2)
		{
			return GetHeight(p1, out var h1) && Intersects(0, 0, p1.Z, h1, 0, 0, z2, h2);
		}

		public static bool Intersects(Point2D p1, int z1, int h1, Point2D p2, int z2, int h2)
		{
			return Intersects(p1.X, p1.Y, z1, h1, p2.X, p2.Y, z2, h2);
		}

		public static bool Intersects(int z1, int h1, Point3D p2)
		{
			return Intersects(0, 0, z1, h1, 0, 0, p2.Z, 1);
		}

		public static bool Intersects(Point3D p1, int z2, int h2)
		{
			return Intersects(0, 0, p1.Z, 1, 0, 0, z2, h2);
		}

		public static bool Intersects(Point3D p1, int h1, Point3D p2, int h2)
		{
			return Intersects(p1.X, p1.Y, p1.Z, h1, p2.X, p2.Y, p2.Z, h2);
		}

		public static bool Intersects(int z1, int h1, int z2, int h2)
		{
			return Intersects(0, 0, z1, h1, 0, 0, z2, h2);
		}

		public static bool Intersects(int x1, int y1, int z1, int h1, int x2, int y2, int z2, int h2)
		{
			if (x1 != x2 || y1 != y2)
			{
				return false;
			}

			if (z1 == z2 || z1 + h1 == z2 + h2)
			{
				return true;
			}

			if (z1 >= z2 && z1 <= z2 + h2)
			{
				return true;
			}

			if (z2 >= z1 && z2 <= z1 + h1)
			{
				return true;
			}

			if (z1 <= z2 && z1 + h1 >= z2)
			{
				return true;
			}

			if (z2 <= z1 && z2 + h2 >= z1)
			{
				return true;
			}

			return false;
		}
	}
}