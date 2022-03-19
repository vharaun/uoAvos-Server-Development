
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
	#region 2D Facet Locations

	public interface IPoint2D
	{
		int X { get; }
		int Y { get; }
	}

	[Parsable]
	public struct Point2D : IPoint2D, IComparable, IComparable<Point2D>
	{
		internal int m_X;
		internal int m_Y;

		public static readonly Point2D Zero = new Point2D(0, 0);

		public Point2D(int x, int y)
		{
			m_X = x;
			m_Y = y;
		}

		public Point2D(IPoint2D p) : this(p.X, p.Y)
		{
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int X
		{
			get => m_X;
			set => m_X = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int Y
		{
			get => m_Y;
			set => m_Y = value;
		}

		public override string ToString()
		{
			return String.Format("({0}, {1})", m_X, m_Y);
		}

		public static Point2D Parse(string value)
		{
			var start = value.IndexOf('(');
			var end = value.IndexOf(',', start + 1);

			var param1 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(')', start + 1);

			var param2 = value.Substring(start + 1, end - (start + 1)).Trim();

			return new Point2D(Convert.ToInt32(param1), Convert.ToInt32(param2));
		}

		public int CompareTo(Point2D other)
		{
			var v = (m_X.CompareTo(other.m_X));

			if (v == 0)
			{
				v = (m_Y.CompareTo(other.m_Y));
			}

			return v;
		}

		public int CompareTo(object other)
		{
			if (other is Point2D)
			{
				return CompareTo((Point2D)other);
			}
			else if (other == null)
			{
				return -1;
			}

			throw new ArgumentException();
		}

		public override bool Equals(object o)
		{
			if (o == null || !(o is IPoint2D))
			{
				return false;
			}

			var p = (IPoint2D)o;

			return m_X == p.X && m_Y == p.Y;
		}

		public override int GetHashCode()
		{
			return m_X ^ m_Y;
		}

		public static bool operator ==(Point2D l, Point2D r)
		{
			return l.m_X == r.m_X && l.m_Y == r.m_Y;
		}

		public static bool operator !=(Point2D l, Point2D r)
		{
			return l.m_X != r.m_X || l.m_Y != r.m_Y;
		}

		public static bool operator ==(Point2D l, IPoint2D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X == r.X && l.m_Y == r.Y;
		}

		public static bool operator !=(Point2D l, IPoint2D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X != r.X || l.m_Y != r.Y;
		}

		public static bool operator >(Point2D l, Point2D r)
		{
			return l.m_X > r.m_X && l.m_Y > r.m_Y;
		}

		public static bool operator >(Point2D l, Point3D r)
		{
			return l.m_X > r.m_X && l.m_Y > r.m_Y;
		}

		public static bool operator >(Point2D l, IPoint2D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X > r.X && l.m_Y > r.Y;
		}

		public static bool operator <(Point2D l, Point2D r)
		{
			return l.m_X < r.m_X && l.m_Y < r.m_Y;
		}

		public static bool operator <(Point2D l, Point3D r)
		{
			return l.m_X < r.m_X && l.m_Y < r.m_Y;
		}

		public static bool operator <(Point2D l, IPoint2D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X < r.X && l.m_Y < r.Y;
		}

		public static bool operator >=(Point2D l, Point2D r)
		{
			return l.m_X >= r.m_X && l.m_Y >= r.m_Y;
		}

		public static bool operator >=(Point2D l, Point3D r)
		{
			return l.m_X >= r.m_X && l.m_Y >= r.m_Y;
		}

		public static bool operator >=(Point2D l, IPoint2D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X >= r.X && l.m_Y >= r.Y;
		}

		public static bool operator <=(Point2D l, Point2D r)
		{
			return l.m_X <= r.m_X && l.m_Y <= r.m_Y;
		}

		public static bool operator <=(Point2D l, Point3D r)
		{
			return l.m_X <= r.m_X && l.m_Y <= r.m_Y;
		}

		public static bool operator <=(Point2D l, IPoint2D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X <= r.X && l.m_Y <= r.Y;
		}
	}

	[NoSort]
	[Parsable]
	[PropertyObject]
	public struct Rectangle2D
	{
		private Point2D m_Start;
		private Point2D m_End;

		public Rectangle2D(IPoint2D start, IPoint2D end)
		{
			m_Start = new Point2D(start);
			m_End = new Point2D(end);
		}

		public Rectangle2D(int x, int y, int width, int height)
		{
			m_Start = new Point2D(x, y);
			m_End = new Point2D(x + width, y + height);
		}

		public void Set(int x, int y, int width, int height)
		{
			m_Start = new Point2D(x, y);
			m_End = new Point2D(x + width, y + height);
		}

		public static Rectangle2D Parse(string value)
		{
			var start = value.IndexOf('(');
			var end = value.IndexOf(',', start + 1);

			var param1 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			var param2 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			var param3 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(')', start + 1);

			var param4 = value.Substring(start + 1, end - (start + 1)).Trim();

			return new Rectangle2D(Convert.ToInt32(param1), Convert.ToInt32(param2), Convert.ToInt32(param3), Convert.ToInt32(param4));
		}

		[CommandProperty(AccessLevel.Counselor)]
		public Point2D Start
		{
			get => m_Start;
			set => m_Start = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public Point2D End
		{
			get => m_End;
			set => m_End = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int X
		{
			get => m_Start.m_X;
			set => m_Start.m_X = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int Y
		{
			get => m_Start.m_Y;
			set => m_Start.m_Y = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int Width
		{
			get => m_End.m_X - m_Start.m_X;
			set => m_End.m_X = m_Start.m_X + value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int Height
		{
			get => m_End.m_Y - m_Start.m_Y;
			set => m_End.m_Y = m_Start.m_Y + value;
		}

		public void MakeHold(Rectangle2D r)
		{
			if (r.m_Start.m_X < m_Start.m_X)
			{
				m_Start.m_X = r.m_Start.m_X;
			}

			if (r.m_Start.m_Y < m_Start.m_Y)
			{
				m_Start.m_Y = r.m_Start.m_Y;
			}

			if (r.m_End.m_X > m_End.m_X)
			{
				m_End.m_X = r.m_End.m_X;
			}

			if (r.m_End.m_Y > m_End.m_Y)
			{
				m_End.m_Y = r.m_End.m_Y;
			}
		}

		public bool Contains(Point3D p)
		{
			return (m_Start.m_X <= p.m_X && m_Start.m_Y <= p.m_Y && m_End.m_X > p.m_X && m_End.m_Y > p.m_Y);
			//return ( m_Start <= p && m_End > p );
		}

		public bool Contains(Point2D p)
		{
			return (m_Start.m_X <= p.m_X && m_Start.m_Y <= p.m_Y && m_End.m_X > p.m_X && m_End.m_Y > p.m_Y);
			//return ( m_Start <= p && m_End > p );
		}

		public bool Contains(IPoint2D p)
		{
			return (m_Start <= p && m_End > p);
		}

		public override string ToString()
		{
			return String.Format("({0}, {1})+({2}, {3})", X, Y, Width, Height);
		}
	}

	[NoSort, Parsable, PropertyObject]
	public readonly struct Poly2D
	{
		public static readonly Poly2D Empty = new(null);

		public static bool TryParse(string value, out Poly2D t)
		{
			try
			{
				t = Parse(value);
				return true;
			}
			catch
			{
				t = Empty;
				return false;
			}
		}

		public static Poly2D Parse(string value)
		{
			try
			{
				return new Poly2D(value.Split('+').Select(Point2D.Parse).ToArray());
			}
			catch
			{
				throw new FormatException("The specified polygon must be represented by Point2D coords using the format '(x1,y1)+(xN,yN)'");
			}
		}

		internal readonly Point2D[] m_Points;

		internal readonly Rectangle2D m_Bounds;

		public readonly IEnumerable<Point2D> Points => m_Points.AsEnumerable();

		public readonly Rectangle2D Bounds => m_Bounds;

		public readonly int Count => m_Points.Length;

		public readonly Point2D this[int index] => m_Points[index];

		public Poly2D(Poly3D poly)
			: this(poly.m_Poly)
		{ }

		public Poly2D(Poly2D poly)
			: this(poly.m_Points)
		{ }

		public Poly2D(params Point2D[] points)
		{
			m_Points = points?.ToArray() ?? Array.Empty<Point2D>();

			if (m_Points.Length == 0)
			{
				m_Bounds = new Rectangle2D(0, 0, 0, 0);
				return;
			}

			int x1 = Int32.MinValue, y1 = Int32.MinValue;
			int x2 = Int32.MaxValue, y2 = Int32.MaxValue;

			foreach (var p in m_Points)
			{
				x1 = Math.Min(x1, p.m_X);
				y1 = Math.Min(y1, p.m_Y);
				
				x2 = Math.Max(x2, p.m_X);
				y2 = Math.Max(y2, p.m_Y);
			}

			m_Bounds = new Rectangle2D(x1, y1, x2 - x1, y2 - y1);
		}

		public Point2D[] ToArray()
		{
			return m_Points.ToArray();
		}

		public bool Contains(IPoint2D p)
		{
			return Contains(p.X, p.Y);
		}

		public bool Contains(IPoint3D p)
		{
			return Contains(p.X, p.Y);
		}

		public bool Contains(Point2D p)
		{
			return Contains(p.m_X, p.m_Y);
		}

		public bool Contains(Point3D p)
		{
			return Contains(p.m_X, p.m_Y);
		}

		public bool Contains(int x, int y)
		{
			if (m_Points.Length == 0)
			{
				return false;
			}

			var first = m_Points[0];
			var last = m_Points[^1];

			if (first.X == last.X && first.Y == last.Y)
			{
				return x == first.X && y == first.Y;
			}

			static double product(int x1, int y1, int x2, int y2, int x3, int y3)
			{
				return Math.Atan2((x1 - x2) * (y3 - y2) - (y1 - y2) * (x3 - x2), (x1 - x2) * (x3 - x2) + (y1 - y2) * (y3 - y2));
			};

			var total = product(last.X, last.Y, x, y, first.X, first.Y);

			for (int i = 0, n = 1; n < m_Points.Length; i++, n++)
			{
				total += product(m_Points[i].X, m_Points[i].Y, x, y, m_Points[n].X, m_Points[n].Y);
			}

			return Math.Abs(total) > 1;
		}

		public override string ToString()
		{
			return String.Join("+", m_Points);
		}

		public static implicit operator Poly2D(Poly3D poly)
		{
			return poly.m_Poly;
		}

		public static implicit operator Poly2D(Rectangle2D rect)
		{
			Point2D r1 = rect.Start, r2 = rect.End;

			Point2D p = Point2D.Zero, p1 = p, p2 = p, p3 = p, p4 = p;

			p1.m_X = r1.m_X;
			p1.m_Y = r1.m_Y;

			p2.m_X = r2.m_X;
			p2.m_Y = r1.m_Y;

			p3.m_X = r2.m_X;
			p3.m_Y = r2.m_Y;

			p4.m_X = r1.m_X;
			p4.m_Y = r2.m_Y;

			return new Poly2D(p1, p2, p3, p4);
		}

		public static implicit operator Poly2D(Rectangle3D rect)
		{
			Point3D r1 = rect.Start, r2 = rect.End;

			Point2D p = Point2D.Zero, p1 = p, p2 = p, p3 = p, p4 = p;

			p1.m_X = r1.m_X;
			p1.m_Y = r1.m_Y;

			p2.m_X = r2.m_X;
			p2.m_Y = r1.m_Y;

			p3.m_X = r2.m_X;
			p3.m_Y = r2.m_Y;

			p4.m_X = r1.m_X;
			p4.m_Y = r2.m_Y;

			return new Poly2D(p1, p2, p3, p4);
		}
	}

	#endregion

	#region 3D Facet Locations

	public interface IPoint3D : IPoint2D
	{
		int Z { get; }
	}

	[Parsable]
	public struct Point3D : IPoint3D, IComparable, IComparable<Point3D>
	{
		internal int m_X;
		internal int m_Y;
		internal int m_Z;

		public static readonly Point3D Zero = new Point3D(0, 0, 0);

		public Point3D(int x, int y, int z)
		{
			m_X = x;
			m_Y = y;
			m_Z = z;
		}

		public Point3D(IPoint3D p)
			: this(p.X, p.Y, p.Z)
		{
		}

		public Point3D(IPoint2D p, int z)
			: this(p.X, p.Y, z)
		{
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int X
		{
			get => m_X;
			set => m_X = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int Y
		{
			get => m_Y;
			set => m_Y = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int Z
		{
			get => m_Z;
			set => m_Z = value;
		}

		public override string ToString()
		{
			return String.Format("({0}, {1}, {2})", m_X, m_Y, m_Z);
		}

		public override bool Equals(object o)
		{
			if (o == null || !(o is IPoint3D))
			{
				return false;
			}

			var p = (IPoint3D)o;

			return m_X == p.X && m_Y == p.Y && m_Z == p.Z;
		}

		public override int GetHashCode()
		{
			return m_X ^ m_Y ^ m_Z;
		}

		public static Point3D Parse(string value)
		{
			var start = value.IndexOf('(');
			var end = value.IndexOf(',', start + 1);

			var param1 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			var param2 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(')', start + 1);

			var param3 = value.Substring(start + 1, end - (start + 1)).Trim();

			return new Point3D(Convert.ToInt32(param1), Convert.ToInt32(param2), Convert.ToInt32(param3));
		}

		public static bool operator ==(Point3D l, Point3D r)
		{
			return l.m_X == r.m_X && l.m_Y == r.m_Y && l.m_Z == r.m_Z;
		}

		public static bool operator !=(Point3D l, Point3D r)
		{
			return l.m_X != r.m_X || l.m_Y != r.m_Y || l.m_Z != r.m_Z;
		}

		public static bool operator ==(Point3D l, IPoint3D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X == r.X && l.m_Y == r.Y && l.m_Z == r.Z;
		}

		public static bool operator !=(Point3D l, IPoint3D r)
		{
			if (Object.ReferenceEquals(r, null))
			{
				return false;
			}

			return l.m_X != r.X || l.m_Y != r.Y || l.m_Z != r.Z;
		}

		public int CompareTo(Point3D other)
		{
			var v = (m_X.CompareTo(other.m_X));

			if (v == 0)
			{
				v = (m_Y.CompareTo(other.m_Y));

				if (v == 0)
				{
					v = (m_Z.CompareTo(other.m_Z));
				}
			}

			return v;
		}

		public int CompareTo(object other)
		{
			if (other is Point3D)
			{
				return CompareTo((Point3D)other);
			}
			else if (other == null)
			{
				return -1;
			}

			throw new ArgumentException();
		}
	}

	[NoSort]
	[PropertyObject]
	public struct Rectangle3D
	{
		private Point3D m_Start;
		private Point3D m_End;

		public Rectangle3D(Point3D start, Point3D end)
		{
			m_Start = start;
			m_End = end;
		}

		public Rectangle3D(int x, int y, int z, int width, int height, int depth)
		{
			m_Start = new Point3D(x, y, z);
			m_End = new Point3D(x + width, y + height, z + depth);
		}

		[CommandProperty(AccessLevel.Counselor)]
		public Point3D Start
		{
			get => m_Start;
			set => m_Start = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public Point3D End
		{
			get => m_End;
			set => m_End = value;
		}

		[CommandProperty(AccessLevel.Counselor)]
		public int Width => m_End.X - m_Start.X;

		[CommandProperty(AccessLevel.Counselor)]
		public int Height => m_End.Y - m_Start.Y;

		[CommandProperty(AccessLevel.Counselor)]
		public int Depth => m_End.Z - m_Start.Z;

		public bool Contains(Point3D p)
		{
			return (p.m_X >= m_Start.m_X)
				&& (p.m_X < m_End.m_X)
				&& (p.m_Y >= m_Start.m_Y)
				&& (p.m_Y < m_End.m_Y)
				&& (p.m_Z >= m_Start.m_Z)
				&& (p.m_Z < m_End.m_Z);
		}

		public bool Contains(IPoint3D p)
		{
			return (p.X >= m_Start.m_X)
				&& (p.X < m_End.m_X)
				&& (p.Y >= m_Start.m_Y)
				&& (p.Y < m_End.m_Y)
				&& (p.Z >= m_Start.m_Z)
				&& (p.Z < m_End.m_Z);
		}
	}

	[NoSort, Parsable, PropertyObject]
	public readonly struct Poly3D
	{
		public static readonly Poly3D Empty = new();

		public static bool TryParse(string value, out Poly3D t)
		{
			try
			{
				t = Parse(value);
				return true;
			}
			catch
			{
				t = Empty;
				return false;
			}
		}

		public static Poly3D Parse(string value)
		{
			try
			{
				var param = value.Split('~');
				var level = param[0].Split(',');
				var points = param[1].Split('+');

				var minZ = Int32.Parse(level[0]);
				var maxZ = Int32.Parse(level[1]);

				return new Poly3D(minZ, maxZ, points.Select(Point2D.Parse).ToArray());
			}
			catch
			{
				throw new FormatException("The specified polygon must be represented by Point2D coords using the format '(zMin,zMax)~(x1,y1)+(xN,yN)'");
			}
		}

		internal readonly Poly2D m_Poly;

		internal readonly int m_MinZ, m_MaxZ;

		public readonly Point2D this[int index] => m_Poly.m_Points[index];

		public readonly IEnumerable<Point2D> Points => m_Poly.m_Points.AsEnumerable();

		public readonly Rectangle2D Bounds => m_Poly.m_Bounds;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int Count => m_Poly.Count;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int MinZ => m_MinZ;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int MaxZ => m_MaxZ;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int Depth => m_MinZ - m_MaxZ;

		public Poly3D(Poly3D poly)
			: this(poly.MinZ, poly.MaxZ, poly.m_Poly.m_Points)
		{ }

		public Poly3D(int minZ, int maxZ, params Point2D[] points)
		{
			m_MinZ = minZ;
			m_MaxZ = maxZ;
			m_Poly = new(points);
		}

		public Point2D[] ToArray()
		{
			return m_Poly.ToArray();
		}

		public bool Contains(IPoint2D p)
		{
			return m_Poly.Contains(p.X, p.Y);
		}

		public bool Contains(IPoint3D p)
		{
			return m_Poly.Contains(p.X, p.Y) && p.Z >= m_MinZ && p.Z < m_MaxZ;
		}

		public bool Contains(Point2D p)
		{
			return m_Poly.Contains(p.m_X, p.m_Y);
		}

		public bool Contains(Point3D p)
		{
			return m_Poly.Contains(p.m_X, p.m_Y) && p.m_Z >= m_MinZ && p.m_Z < m_MaxZ;
		}

		public bool Contains(int x, int y)
		{
			return m_Poly.Contains(x, y);
		}

		public bool Contains(int x, int y, int z)
		{
			return m_Poly.Contains(x, y) && z >= m_MinZ && z < m_MaxZ;
		}

		public override string ToString()
		{
			return $"{m_Poly}~({m_MinZ},{m_MaxZ})";
		}

		public static implicit operator Poly3D(Poly2D poly)
		{
			return new Poly3D(Region.MinZ, Region.MaxZ, poly.m_Points);
		}

		public static implicit operator Poly3D(Rectangle2D rect)
		{
			Point2D r1 = rect.Start, r2 = rect.End;

			Point2D p = Point2D.Zero, p1 = p, p2 = p, p3 = p, p4 = p;

			p1.m_X = r1.m_X;
			p1.m_Y = r1.m_Y;

			p2.m_X = r2.m_X;
			p2.m_Y = r1.m_Y;

			p3.m_X = r2.m_X;
			p3.m_Y = r2.m_Y;

			p4.m_X = r1.m_X;
			p4.m_Y = r2.m_Y;

			return new Poly3D(Region.MinZ, Region.MaxZ, p1, p2, p3, p4);
		}

		public static implicit operator Poly3D(Rectangle3D rect)
		{
			Point3D r1 = rect.Start, r2 = rect.End;

			Point2D p = Point2D.Zero, p1 = p, p2 = p, p3 = p, p4 = p;

			p1.m_X = r1.m_X;
			p1.m_Y = r1.m_Y;

			p2.m_X = r2.m_X;
			p2.m_Y = r1.m_Y;

			p3.m_X = r2.m_X;
			p3.m_Y = r2.m_Y;

			p4.m_X = r1.m_X;
			p4.m_Y = r2.m_Y;

			return new Poly3D(rect.Start.Z, rect.End.Z, p1, p2, p3, p4);
		}
	}

	public class Point3DList
	{
		private Point3D[] m_List;
		private int m_Count;

		public Point3DList()
		{
			m_List = new Point3D[8];
			m_Count = 0;
		}

		public int Count => m_Count;

		public void Clear()
		{
			m_Count = 0;
		}

		public Point3D Last => m_List[m_Count - 1];

		public Point3D this[int index] => m_List[index];

		public void Add(int x, int y, int z)
		{
			if ((m_Count + 1) > m_List.Length)
			{
				var old = m_List;
				m_List = new Point3D[old.Length * 2];

				for (var i = 0; i < old.Length; ++i)
				{
					m_List[i] = old[i];
				}
			}

			m_List[m_Count].m_X = x;
			m_List[m_Count].m_Y = y;
			m_List[m_Count].m_Z = z;
			++m_Count;
		}

		public void Add(Point3D p)
		{
			if ((m_Count + 1) > m_List.Length)
			{
				var old = m_List;
				m_List = new Point3D[old.Length * 2];

				for (var i = 0; i < old.Length; ++i)
				{
					m_List[i] = old[i];
				}
			}

			m_List[m_Count].m_X = p.m_X;
			m_List[m_Count].m_Y = p.m_Y;
			m_List[m_Count].m_Z = p.m_Z;
			++m_Count;
		}

		private static readonly Point3D[] m_EmptyList = new Point3D[0];

		public Point3D[] ToArray()
		{
			if (m_Count == 0)
			{
				return m_EmptyList;
			}

			var list = new Point3D[m_Count];

			for (var i = 0; i < m_Count; ++i)
			{
				list[i] = m_List[i];
			}

			m_Count = 0;

			return list;
		}
	}

	#endregion
}