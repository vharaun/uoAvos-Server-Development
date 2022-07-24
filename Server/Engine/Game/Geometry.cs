
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
	public struct Point2D : IPoint2D, IComparable<Point2D>, IEquatable<Point2D>, IComparable<IPoint2D>, IEquatable<IPoint2D>
	{
		public static readonly Point2D Zero = new(0, 0);

		public static bool TryParse(string value, out Point2D o)
		{
			try
			{
				o = Parse(value);
				return true;
			}
			catch
			{
				o = Zero;
				return false;
			}
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

		internal int m_X, m_Y;

		[CommandProperty(AccessLevel.Counselor)]
		public int X { get => m_X; set => m_X = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Y { get => m_Y; set => m_Y = value; }

		public Point2D(IPoint2D p)
			: this(p.X, p.Y)
		{
		}

		public Point2D(int x, int y)
		{
			m_X = x;
			m_Y = y;
		}

		public int CompareTo(Point2D p)
		{
			var v = m_X.CompareTo(p.m_X);

			if (v == 0)
			{
				v = m_Y.CompareTo(p.m_Y);
			}

			return v;
		}

		public int CompareTo(IPoint2D p)
		{
			var v = m_X.CompareTo(p?.X);

			if (v == 0)
			{
				v = m_Y.CompareTo(p?.Y);
			}

			return v;
		}

		public bool Equals(Point2D p)
		{
			return m_X == p.m_X && m_Y == p.m_Y;
		}

		public bool Equals(IPoint2D p)
		{
			return m_X == p?.X && m_Y == p?.Y;
		}

		public override bool Equals(object o)
		{
			return o is IPoint2D p && Equals(p);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(m_X, m_Y);
		}

		public override string ToString()
		{
			return $"({m_X}, {m_Y})";
		}

		#region Operators

		public static bool operator ==(Point2D l, Point2D r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(Point2D l, Point2D r)
		{
			return !l.Equals(r);
		}

		public static bool operator >(Point2D l, Point2D r)
		{
			return l.m_X > r.m_X && l.m_Y > r.m_Y;
		}

		public static bool operator >(Point2D l, Point3D r)
		{
			return l.m_X > r.m_X && l.m_Y > r.m_Y;
		}

		public static bool operator <(Point2D l, Point2D r)
		{
			return l.m_X < r.m_X && l.m_Y < r.m_Y;
		}

		public static bool operator <(Point2D l, Point3D r)
		{
			return l.m_X < r.m_X && l.m_Y < r.m_Y;
		}

		public static bool operator >=(Point2D l, Point2D r)
		{
			return l.m_X >= r.m_X && l.m_Y >= r.m_Y;
		}

		public static bool operator >=(Point2D l, Point3D r)
		{
			return l.m_X >= r.m_X && l.m_Y >= r.m_Y;
		}

		public static bool operator <=(Point2D l, Point2D r)
		{
			return l.m_X <= r.m_X && l.m_Y <= r.m_Y;
		}

		public static bool operator <=(Point2D l, Point3D r)
		{
			return l.m_X <= r.m_X && l.m_Y <= r.m_Y;
		}

		#endregion

		#region Interface Operators

		public static bool operator >(Point2D l, IPoint2D r)
		{
			return l.m_X > r.X && l.m_Y > r.Y;
		}

		public static bool operator >(IPoint2D l, Point2D r)
		{
			return l.X > r.m_X && l.Y > r.m_Y;
		}

		public static bool operator >(Point2D l, IPoint3D r)
		{
			return l.m_X > r.X && l.m_Y > r.Y;
		}

		public static bool operator >(IPoint3D l, Point2D r)
		{
			return l.X > r.m_X && l.Y > r.m_Y;
		}

		public static bool operator <(Point2D l, IPoint2D r)
		{
			return l.m_X < r.X && l.m_Y < r.Y;
		}

		public static bool operator <(IPoint2D l, Point2D r)
		{
			return l.X < r.m_X && l.Y < r.m_Y;
		}

		public static bool operator <(Point2D l, IPoint3D r)
		{
			return l.m_X < r.X && l.m_Y < r.Y;
		}

		public static bool operator <(IPoint3D l, Point2D r)
		{
			return l.X < r.m_X && l.Y < r.m_Y;
		}

		public static bool operator >=(Point2D l, IPoint2D r)
		{
			return l.m_X >= r.X && l.m_Y >= r.Y;
		}

		public static bool operator >=(IPoint2D l, Point2D r)
		{
			return l.X >= r.m_X && l.Y >= r.m_Y;
		}

		public static bool operator >=(Point2D l, IPoint3D r)
		{
			return l.m_X >= r.X && l.m_Y >= r.Y;
		}

		public static bool operator >=(IPoint3D l, Point2D r)
		{
			return l.X >= r.m_X && l.Y >= r.m_Y;
		}

		public static bool operator <=(Point2D l, IPoint2D r)
		{
			return l.m_X <= r.X && l.m_Y <= r.Y;
		}

		public static bool operator <=(IPoint2D l, Point2D r)
		{
			return l.X <= r.m_X && l.Y <= r.m_Y;
		}

		public static bool operator <=(Point2D l, IPoint3D r)
		{
			return l.m_X <= r.X && l.m_Y <= r.Y;
		}

		public static bool operator <=(IPoint3D l, Point2D r)
		{
			return l.X <= r.m_X && l.Y <= r.m_Y;
		}

		#endregion
	}

	[NoSort, Parsable, PropertyObject]
	public struct Rectangle2D : IEquatable<Rectangle2D>
	{
		public static readonly Rectangle2D Empty = new(0, 0, 0, 0);

		public static bool TryParse(string value, out Rectangle2D o)
		{
			try
			{
				o = Parse(value);
				return true;
			}
			catch
			{
				o = Empty;
				return false;
			}
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

		private Point2D m_Start, m_End;

		[CommandProperty(AccessLevel.Counselor)]
		public Point2D Start { get => m_Start; set => m_Start = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public Point2D End { get => m_End; set => m_End = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int X { get => m_Start.m_X; set => m_Start.m_X = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Y { get => m_Start.m_Y; set => m_Start.m_Y = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Width { get => m_End.m_X - m_Start.m_X; set => m_End.m_X = m_Start.m_X + value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Height { get => m_End.m_Y - m_Start.m_Y; set => m_End.m_Y = m_Start.m_Y + value; }

		public Rectangle2D(Point2D start, Point2D end)
		{
			m_Start = start;
			m_End = end;
		}

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

		public bool Contains(Point2D p)
		{
			return Contains(p, false);
		}

		public bool Contains(Point2D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Contains(IPoint2D p)
		{
			return Contains(p, false);
		}

		public bool Contains(IPoint2D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Contains(Point3D p)
		{
			return Contains(p, false);
		}

		public bool Contains(Point3D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Contains(IPoint3D p)
		{
			return Contains(p, false);
		}

		public bool Contains(IPoint3D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Equals(Rectangle2D r)
		{
			return m_Start == r.m_Start && m_End == r.m_End;
		}

		public override bool Equals(object o)
		{
			return o is Rectangle2D r && Equals(r);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(m_Start, m_End);
		}

		public override string ToString()
		{
			return $"({X}, {Y})+({Width}, {Height})";
		}

		public static bool operator ==(Rectangle2D left, Rectangle2D right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Rectangle2D left, Rectangle2D right)
		{
			return !left.Equals(right);
		}
	}

	[NoSort, Parsable, PropertyObject]
	public readonly struct Poly2D : IEquatable<Poly2D>
	{
		public enum ContainsImpl
		{
			Trace, // less accurate, faster
			Product, // more accurate, slower
		}

		public static ContainsImpl ContainmentImpl { get; set; } = ContainsImpl.Trace;

		public static readonly Poly2D Empty = new(null);

		public static bool TryParse(string value, out Poly2D o)
		{
			try
			{
				o = Parse(value);
				return true;
			}
			catch
			{
				o = Empty;
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

		private readonly int m_Hash;

		internal readonly Point2D[] m_Points;

		internal readonly Rectangle2D m_Bounds;

		public readonly IEnumerable<Point2D> Points => m_Points.AsEnumerable();

		[CommandProperty(AccessLevel.Counselor)]
		public readonly Rectangle2D Bounds => m_Bounds;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int Count => m_Points?.Length ?? 0;

		public readonly Point2D this[int index] => m_Points[index];

		public Poly2D(Poly3D poly)
			: this(poly.m_Poly)
		{ }

		public Poly2D(Poly2D poly)
			: this(poly.m_Points)
		{ }

		public Poly2D(IEnumerable<Point2D> points)
		{
			m_Hash = 0;
			m_Bounds = Rectangle2D.Empty;

			m_Points = points?.ToArray() ?? Array.Empty<Point2D>();

			Initialize(ref m_Hash, ref m_Bounds);
		}

		public Poly2D(params Point2D[] points)
		{
			m_Hash = 0;
			m_Bounds = Rectangle2D.Empty;

			m_Points = points?.ToArray() ?? Array.Empty<Point2D>();

			Initialize(ref m_Hash, ref m_Bounds);
		}

		private void Initialize(ref int hash, ref Rectangle2D bounds)
		{
			if (m_Points.Length == 0)
			{
				return;
			}

			int x1 = Int32.MaxValue, y1 = Int32.MaxValue;
			int x2 = Int32.MinValue, y2 = Int32.MinValue;

			for (var i = 0; i < m_Points.Length; i++)
			{
				x1 = Math.Min(x1, m_Points[i].m_X);
				y1 = Math.Min(y1, m_Points[i].m_Y);

				x2 = Math.Max(x2, m_Points[i].m_X);
				y2 = Math.Max(y2, m_Points[i].m_Y);

				hash = HashCode.Combine(hash, m_Points[i]);
			}

			bounds = new Rectangle2D(x1, y1, x2 - x1, y2 - y1);
		}

		public Point2D[] ToArray()
		{
			return m_Points.ToArray();
		}

		public bool Contains(Point2D p)
		{
			return Contains(p.m_X, p.m_Y);
		}

		public bool Contains(IPoint2D p)
		{
			return Contains(p.X, p.Y);
		}

		public bool Contains(Point3D p)
		{
			return Contains(p.m_X, p.m_Y);
		}

		public bool Contains(IPoint3D p)
		{
			return Contains(p.X, p.Y);
		}

		public bool Contains(int x, int y)
		{
			if (m_Points.Length == 0)
			{
				return false;
			}

			if (m_Points[0] == m_Points[^1])
			{
				return x == m_Points[0].m_X && y == m_Points[0].m_Y;
			}

			return ContainmentImpl switch
			{
				ContainsImpl.Trace => TraceContains(x, y),
				ContainsImpl.Product => ProductContains(x, y),
				_ => false,
			};
		}

		public bool TraceContains(int x, int y)
		{
			if (x < m_Bounds.Start.m_X || y < m_Bounds.Start.m_Y)
			{
				return false;
			}

			if (x >= m_Bounds.End.m_X || y >= m_Bounds.End.m_Y)
			{
				return false;
			}

			var test = false;

			for (int i = 0, n = 1; i < m_Points.Length; i = n++)
			{
				var p1 = m_Points[i];
				var p2 = m_Points[n % m_Points.Length];

				if (y < p1.m_Y != y < p2.m_Y && x < (p2.m_X - p1.m_X) * (y - p1.m_Y) / (p2.m_Y - p1.m_Y) + p1.m_X)
				{
					test = !test;
				}
			}

			return test;
		}

		public bool ProductContains(int x, int y)
		{
			if (x < m_Bounds.Start.m_X || y < m_Bounds.Start.m_Y)
			{
				return false;
			}

			if (x >= m_Bounds.End.m_X || y >= m_Bounds.End.m_Y)
			{
				return false;
			}

			static double product(int x1, int y1, int x2, int y2, int x3, int y3)
			{
				return Math.Atan2((x1 - x2) * (y3 - y2) - (y1 - y2) * (x3 - x2), (x1 - x2) * (x3 - x2) + (y1 - y2) * (y3 - y2));
			};

			var total = 0.0;

			for (int i = 0, n = 1; i < m_Points.Length; i = n++)
			{
				var p1 = m_Points[i];
				var p2 = m_Points[n % m_Points.Length];

				total += product(p1.m_X, p1.m_Y, x, y, p2.m_X, p2.m_Y);
			}

			return Math.Abs(total) > 1;
		}

		public bool Intersects(Poly2D p)
		{
			return Intersects(p, out _);
		}

		public bool Intersects(Poly2D p, out Point2D loc)
		{
			static bool test(Point2D a1, Point2D b1, Point2D a2, Point2D b2, out Point2D result)
			{
				if ((a1.X == a2.X && a1.Y == a2.Y) || (a1.X == b2.X && a1.Y == b2.Y))
				{
					result = new Point2D(a1.X, a1.Y);
					return true;
				}

				if ((b1.X == b2.X && b1.Y == b2.Y) || (b1.X == a2.X && b1.Y == a2.Y))
				{
					result = new Point2D(b1.X, b1.Y);
					return true;
				}

				var da1 = b1.Y - a1.Y;
				var da2 = a1.X - b1.X;
				var da3 = da1 * a1.X + da2 * a1.Y;

				var db1 = b2.Y - a2.Y;
				var db2 = a2.X - b2.X;
				var db3 = db1 * a2.X + db2 * a2.Y;

				var delta = da1 * db2 - db1 * da2;

				if (delta != 0)
				{
					result = new Point2D((db2 * da3 - da2 * db3) / delta, (da1 * db3 - db1 * da3) / delta);
					return true;
				}

				result = Point2D.Zero;
				return false;
			};

			for (int i = 0, j = m_Points.Length - 1; i < m_Points.Length; j = i++)
			{
				for (int k = 0, l = p.m_Points.Length - 1; k < p.m_Points.Length; l = k++)
				{
					if (test(m_Points[i], m_Points[j], p.m_Points[k], p.m_Points[l], out loc))
					{
						return true;
					}
				}
			}

			loc = Point2D.Zero;
			return false;
		}
/*
		public void Scale(double scale)
		{
			var center = new Point2D(m_Bounds.X + (m_Bounds.Width / 2), m_Bounds.Y + (m_Bounds.Height / 2));

			for (var i = 0; i < m_Points.Length; i++)
			{
				var point = m_Points[i];

				var xDelta = center.m_X - point.m_X;
				var yDelta = center.m_Y - point.m_Y;

				var dist = Math.Sqrt((xDelta * xDelta) + (yDelta * yDelta));

				var angle = Angle.FromPoints(center, point);

				m_Points[i] = angle.GetPoint2D(center.X, center.m_Y, dist * scale);
			}
		}

		public void Scale(int offset)
		{
			var center = new Point2D(m_Bounds.X + (m_Bounds.Width / 2), m_Bounds.Y + (m_Bounds.Height / 2));

			for (var i = 0; i < m_Points.Length; i++)
			{
				var point = m_Points[i];

				var xDelta = center.m_X - point.m_X;
				var yDelta = center.m_Y - point.m_Y;

				var dist = Math.Sqrt((xDelta * xDelta) + (yDelta * yDelta));

				var angle = Angle.FromPoints(center, point);

				m_Points[i] = angle.GetPoint2D(center.X, center.m_Y, dist + offset);
			}
		}
*/
		public bool Equals(Poly2D p)
		{
			return m_Hash == p.m_Hash;
		}

		public override bool Equals(object o)
		{
			return o is Poly2D p && Equals(p);
		}

		public override int GetHashCode()
		{
			return m_Hash;
		}

		public override string ToString()
		{
			return String.Join("+", m_Points);
		}

		public static bool operator ==(Poly2D l, Poly2D r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(Poly2D l, Poly2D r)
		{
			return !l.Equals(r);
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
	public struct Point3D : IPoint3D, IComparable<Point3D>, IEquatable<Point3D>, IComparable<IPoint3D>, IEquatable<IPoint3D>
	{
		public static readonly Point3D Zero = new(0, 0, 0);

		public static bool TryParse(string value, out Point3D o)
		{
			try
			{
				o = Parse(value);
				return true;
			}
			catch
			{
				o = Zero;
				return false;
			}
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

		internal int m_X, m_Y, m_Z;

		[CommandProperty(AccessLevel.Counselor)]
		public int X { get => m_X; set => m_X = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Y { get => m_Y; set => m_Y = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Z { get => m_Z; set => m_Z = value; }

		public Point3D(IPoint3D p)
			: this(p.X, p.Y, p.Z)
		{
		}

		public Point3D(IPoint2D p, int z)
			: this(p.X, p.Y, z)
		{
		}

		public Point3D(int x, int y, int z)
		{
			m_X = x;
			m_Y = y;
			m_Z = z;
		}

		public int CompareTo(Point3D other)
		{
			var v = m_X.CompareTo(other.m_X);

			if (v == 0)
			{
				v = m_Y.CompareTo(other.m_Y);

				if (v == 0)
				{
					v = m_Z.CompareTo(other.m_Z);
				}
			}

			return v;
		}

		public int CompareTo(IPoint3D other)
		{
			var v = m_X.CompareTo(other?.X);

			if (v == 0)
			{
				v = m_Y.CompareTo(other?.Y);

				if (v == 0)
				{
					v = m_Z.CompareTo(other?.Z);
				}
			}

			return v;
		}

		public bool Equals(Point3D p)
		{
			return m_X == p.m_X && m_Y == p.m_Y && m_Z == p.m_Z;
		}

		public bool Equals(IPoint3D p)
		{
			return m_X == p?.X && m_Y == p?.Y && m_Z == p?.Z;
		}

		public override bool Equals(object o)
		{
			return o is IPoint3D p && Equals(p);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(m_X, m_Y, m_Z);
		}

		public override string ToString()
		{
			return $"({m_X}, {m_Y}, {m_Z})";
		}

		#region Operators

		public static bool operator ==(Point3D l, Point3D r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(Point3D l, Point3D r)
		{
			return !l.Equals(r);
		}

		public static bool operator >(Point3D l, Point3D r)
		{
			return l.m_X > r.m_X && l.m_Y > r.m_Y && l.m_Z > r.m_Z;
		}

		public static bool operator >(Point3D l, Point2D r)
		{
			return l.m_X > r.m_X && l.m_Y > r.m_Y;
		}

		public static bool operator <(Point3D l, Point3D r)
		{
			return l.m_X < r.m_X && l.m_Y < r.m_Y && l.m_Z < r.m_Z;
		}

		public static bool operator <(Point3D l, Point2D r)
		{
			return l.m_X < r.m_X && l.m_Y < r.m_Y;
		}

		public static bool operator >=(Point3D l, Point3D r)
		{
			return l.m_X >= r.m_X && l.m_Y >= r.m_Y && l.m_Z >= r.m_Z;
		}

		public static bool operator >=(Point3D l, Point2D r)
		{
			return l.m_X >= r.m_X && l.m_Y >= r.m_Y;
		}

		public static bool operator <=(Point3D l, Point3D r)
		{
			return l.m_X <= r.m_X && l.m_Y <= r.m_Y && l.m_Z <= r.m_Z;
		}

		public static bool operator <=(Point3D l, Point2D r)
		{
			return l.m_X <= r.m_X && l.m_Y <= r.m_Y;
		}

		#endregion

		#region Interface Operators

		public static bool operator >(Point3D l, IPoint2D r)
		{
			return l.m_X > r.X && l.m_Y > r.Y;
		}

		public static bool operator >(IPoint2D l, Point3D r)
		{
			return l.X > r.m_X && l.Y > r.m_Y;
		}

		public static bool operator >(Point3D l, IPoint3D r)
		{
			return l.m_X > r.X && l.m_Y > r.Y && l.m_Z > r.Z;
		}

		public static bool operator >(IPoint3D l, Point3D r)
		{
			return l.X > r.m_X && l.Y > r.m_Y && l.Z > r.m_Z;
		}

		public static bool operator <(Point3D l, IPoint2D r)
		{
			return l.m_X < r.X && l.m_Y < r.Y;
		}

		public static bool operator <(IPoint2D l, Point3D r)
		{
			return l.X < r.m_X && l.Y < r.m_Y;
		}

		public static bool operator <(Point3D l, IPoint3D r)
		{
			return l.m_X < r.X && l.m_Y < r.Y && l.m_Z < r.Z;
		}

		public static bool operator <(IPoint3D l, Point3D r)
		{
			return l.X < r.m_X && l.Y < r.m_Y && l.Z < r.m_Z;
		}

		public static bool operator >=(Point3D l, IPoint2D r)
		{
			return l.m_X >= r.X && l.m_Y >= r.Y;
		}

		public static bool operator >=(IPoint2D l, Point3D r)
		{
			return l.X >= r.m_X && l.Y >= r.m_Y;
		}

		public static bool operator >=(Point3D l, IPoint3D r)
		{
			return l.m_X >= r.X && l.m_Y >= r.Y && l.m_Z >= r.Z;
		}

		public static bool operator >=(IPoint3D l, Point3D r)
		{
			return l.X >= r.m_X && l.Y >= r.m_Y && l.Z >= r.m_Z;
		}

		public static bool operator <=(Point3D l, IPoint2D r)
		{
			return l.m_X <= r.X && l.m_Y <= r.Y;
		}

		public static bool operator <=(IPoint2D l, Point3D r)
		{
			return l.X <= r.m_X && l.Y <= r.m_Y;
		}

		public static bool operator <=(Point3D l, IPoint3D r)
		{
			return l.m_X <= r.X && l.m_Y <= r.Y && l.m_Z <= r.Z;
		}

		public static bool operator <=(IPoint3D l, Point3D r)
		{
			return l.X <= r.m_X && l.Y <= r.m_Y && l.Z <= r.m_Z;
		}

		#endregion
	}

	[NoSort, Parsable, PropertyObject]
	public struct Rectangle3D : IEquatable<Rectangle3D>
	{
		public static readonly Rectangle3D Empty = new(0, 0, 0, 0, 0, 0);

		public static bool TryParse(string value, out Rectangle3D o)
		{
			try
			{
				o = Parse(value);
				return true;
			}
			catch
			{
				o = Empty;
				return false;
			}
		}

		public static Rectangle3D Parse(string value)
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
			end = value.IndexOf(',', start + 1);

			var param4 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			var param5 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(')', start + 1);

			var param6 = value.Substring(start + 1, end - (start + 1)).Trim();

			return new Rectangle3D(Convert.ToInt32(param1), Convert.ToInt32(param2), Convert.ToInt32(param3), Convert.ToInt32(param4), Convert.ToInt32(param5), Convert.ToInt32(param6));
		}

		private Point3D m_Start, m_End;

		[CommandProperty(AccessLevel.Counselor)]
		public Point3D Start { get => m_Start; set => m_Start = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public Point3D End { get => m_End; set => m_End = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int X { get => m_Start.m_X; set => m_Start.m_X = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Y { get => m_Start.m_Y; set => m_Start.m_Y = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Z { get => m_Start.m_Z; set => m_Start.m_Z = value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Width { get => m_End.m_X - m_Start.m_X; set => m_End.m_X = m_Start.m_X + value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Height { get => m_End.m_Y - m_Start.m_Y; set => m_End.m_Y = m_Start.m_Y + value; }

		[CommandProperty(AccessLevel.Counselor)]
		public int Depth { get => m_End.m_Z - m_Start.m_Z; set => m_End.m_Z = m_Start.m_Z + value; }

		public Rectangle3D(Point3D start, Point3D end)
		{
			m_Start = start;
			m_End = end;
		}

		public Rectangle3D(IPoint3D start, IPoint3D end)
		{
			m_Start = new Point3D(start);
			m_End = new Point3D(end);
		}

		public Rectangle3D(int x, int y, int z, int width, int height, int depth)
		{
			m_Start = new Point3D(x, y, z);
			m_End = new Point3D(x + width, y + height, z + depth);
		}

		public void Set(int x, int y, int z, int width, int height, int depth)
		{
			m_Start = new Point3D(x, y, z);
			m_End = new Point3D(x + width, y + height, z + depth);
		}

		public bool Contains(Point2D p)
		{
			return Contains(p, false);
		}

		public bool Contains(Point2D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Contains(IPoint2D p)
		{
			return Contains(p, false);
		}

		public bool Contains(IPoint2D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Contains(Point3D p)
		{
			return Contains(p, false);
		}

		public bool Contains(Point3D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Contains(IPoint3D p)
		{
			return Contains(p, false);
		}

		public bool Contains(IPoint3D p, bool inclusive)
		{
			return p >= m_Start && (inclusive ? p <= m_End : p < m_End);
		}

		public bool Equals(Rectangle3D r)
		{
			return m_Start == r.m_Start && m_End == r.m_End;
		}

		public override bool Equals(object o)
		{
			return o is Rectangle3D r && Equals(r);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(m_Start, m_End);
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z})+({Width}, {Height}, {Depth})";
		}

		public static bool operator ==(Rectangle3D left, Rectangle3D right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Rectangle3D left, Rectangle3D right)
		{
			return !left.Equals(right);
		}
	}

	[NoSort, Parsable, PropertyObject]
	public readonly struct Poly3D : IEquatable<Poly3D>
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

		private readonly int m_Hash;

		internal readonly Poly2D m_Poly;

		internal readonly int m_MinZ, m_MaxZ;

		public readonly Point2D this[int index] => m_Poly.m_Points[index];

		public readonly IEnumerable<Point2D> Points => m_Poly.m_Points.AsEnumerable();

		[CommandProperty(AccessLevel.Counselor)]
		public readonly Rectangle2D Bounds => m_Poly.m_Bounds;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int Count => m_Poly.Count;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int MinZ => m_MinZ;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int MaxZ => m_MaxZ;

		[CommandProperty(AccessLevel.Counselor)]
		public readonly int Depth => Math.Abs(m_MaxZ - m_MinZ);

		public Poly3D(Poly3D poly)
			: this(poly.m_MinZ, poly.m_MaxZ, poly.m_Poly.m_Points)
		{ }

		public Poly3D(int minZ, int maxZ, IEnumerable<Point2D> points)
		{
			m_MinZ = minZ;
			m_MaxZ = maxZ;
			m_Poly = new(points);

			m_Hash = HashCode.Combine(m_MinZ, m_MaxZ, m_Poly);
		}

		public Poly3D(int minZ, int maxZ, params Point2D[] points)
		{
			m_MinZ = minZ;
			m_MaxZ = maxZ;
			m_Poly = new(points);

			m_Hash = HashCode.Combine(m_MinZ, m_MaxZ, m_Poly);
		}

		public Point2D[] ToArray()
		{
			return m_Poly.ToArray();
		}

		public bool Contains(Point2D p)
		{
			return m_Poly.Contains(p);
		}

		public bool Contains(IPoint2D p)
		{
			return m_Poly.Contains(p);
		}

		public bool Contains(Point3D p)
		{
			return p.m_Z >= m_MinZ && p.m_Z < m_MaxZ && m_Poly.Contains(p);
		}

		public bool Contains(IPoint3D p)
		{
			return p.Z >= m_MinZ && p.Z < m_MaxZ && m_Poly.Contains(p);
		}

		public bool Contains(int x, int y)
		{
			return m_Poly.Contains(x, y);
		}

		public bool Contains(int x, int y, int z)
		{
			return z >= m_MinZ && z < m_MaxZ && m_Poly.Contains(x, y);
		}
		
		public bool TraceContains(int x, int y)
		{
			return m_Poly.TraceContains(x, y);
		}

		public bool TraceContains(int x, int y, int z)
		{
			return z >= m_MinZ && z < m_MaxZ && m_Poly.TraceContains(x, y);
		}

		public bool ProductContains(int x, int y)
		{
			return m_Poly.ProductContains(x, y);
		}

		public bool ProductContains(int x, int y, int z)
		{
			return z >= m_MinZ && z < m_MaxZ && m_Poly.ProductContains(x, y);
		}
/*
		public void Scale(double scale)
		{
			m_Poly.Scale(scale);
		}

		public void Scale(int tiles)
		{
			m_Poly.Scale(tiles);
		}
*/
		public bool Equals(Poly3D p)
		{
			return m_Hash == p.m_Hash;
		}

		public override bool Equals(object o)
		{
			return o is Poly3D p && Equals(p);
		}

		public override int GetHashCode()
		{
			return m_Hash;
		}

		public override string ToString()
		{
			return $"{m_Poly}~({m_MinZ},{m_MaxZ})";
		}

		public static bool operator ==(Poly3D l, Poly3D r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(Poly3D l, Poly3D r)
		{
			return !l.Equals(r);
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

		private static readonly Point3D[] m_EmptyList = Array.Empty<Point3D>();

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

	[Parsable, PropertyObject]
	public struct Angle : IEquatable<Angle>, IEquatable<int>, IEquatable<double>, IComparable<Angle>, IComparable<int>, IComparable<double>
	{
		public const double D2R = Math.PI / 180.0;
		public const double R2D = 180.0 / Math.PI;

		public static readonly Angle Zero = 0;

		public static readonly Angle MinValue = -360;
		public static readonly Angle MaxValue = 360;

		public static Angle FromDirection(Direction dir)
		{
			int x = 0, y = 0;

			Movement.Movement.Offset(dir & Direction.Mask, ref x, ref y);

			return FromPoints(0, 0, x, y);
		}

		public static Angle FromPoints(IPoint2D p1, IPoint2D p2)
		{
			return FromPoints(p1.X, p1.Y, p2.X, p2.Y);
		}

		public static Angle FromPoints(IPoint2D p1, IPoint2D p2, IPoint2D p3)
		{
			return FromPoints(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
		}

		public static Angle FromPoints(int x1, int y1, int x2, int y2)
		{
			return Math.Atan2(y2, x2) - Math.Atan2(y1, x1);
		}

		public static Angle FromPoints(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			return FromPoints(x2, y2, x1, y1) - FromPoints(x2, y2, x3, y3);
		}

		public static Angle FromDegrees(int degrees)
		{
			return degrees;
		}

		public static Angle FromRadians(double radians)
		{
			return radians;
		}

		public static Angle GetPitch(IPoint3D p1, IPoint3D p2)
		{
			int x = p2.X - p1.X, y = p2.Y - p1.Y, z = p2.Z - p1.Z;

			return -Math.Atan2(z, Math.Sqrt((x * x) + (y * y)));
		}

		public static Angle GetYaw(IPoint2D p, IPoint2D left, IPoint2D right)
		{
			return Math.Abs(FromPoints(p, left) - FromPoints(p, right));
		}

		public static void Transform(ref Point3D p, Angle angle, double offset)
		{
			int x = p.X, y = p.Y, z = p.Z;

			Transform(ref x, ref y, angle, offset);

			p = new Point3D(x, y, z);
		}

		public static void Transform(ref Point2D p, Angle angle, double offset)
		{
			int x = p.X, y = p.Y;

			Transform(ref x, ref y, angle, offset);

			p = new Point2D(x, y);
		}

		public static void Transform(ref int x, ref int y, Angle angle, double offset)
		{
			x += (int)(offset * Math.Cos(angle.m_Radians));
			y += (int)(offset * Math.Sin(angle.m_Radians));
		}

		public static Point2D GetPoint2D(int x, int y, Angle angle, double distance)
		{
			return new Point2D(x + (int)(distance * Math.Cos(angle.m_Radians)), y + (int)(distance * Math.Sin(angle.m_Radians)));
		}

		public static Point3D GetPoint3D(int x, int y, int z, Angle angle, double distance)
		{
			return new Point3D(x + (int)(distance * Math.Cos(angle.m_Radians)),				y + (int)(distance * Math.Sin(angle.m_Radians)),				z);
		}

		public static bool TryParse(string value, out Angle angle)
		{
			try
			{
				angle = Parse(value);
				return true;
			}
			catch
			{
				angle = Zero;
				return false;
			}
		}

		public static Angle Parse(string value)
		{
			value ??= String.Empty;
			value = value.Trim();

			int d;
			double r;

			if (!value.Contains(","))
			{
				if (Int32.TryParse(value, out d))
				{
					return d;
				}

				if (Double.TryParse(value, out r))
				{
					return r;
				}
			}
			else
			{
				value = value.Trim('(', ')', ' ');

				var i = value.IndexOf(',');

				if (Int32.TryParse(value.Substring(0, i).Trim(), out d))
				{
					return d;
				}

				if (Double.TryParse(value.Substring(i + 1).Trim(), out r))
				{
					return r;
				}
			}

			throw new FormatException(
				"The specified angle must be represented by Int32 (Degrees) or Double (Radians) using the format " + //
				"'###', '#.##', or '(###, #.##)'");
		}

		internal readonly int m_Degrees;
		internal readonly double m_Radians;

		[CommandProperty(AccessLevel.Counselor)]
		public int Degrees => m_Degrees;

		[CommandProperty(AccessLevel.Counselor)]
		public double Radians => m_Radians;

		public Angle(Angle angle)
		{
			m_Degrees = angle.m_Degrees;
			m_Radians = angle.m_Radians;
		}

		public Angle(int degrees)
		{
			m_Degrees = degrees;
			m_Radians = m_Degrees * D2R;
		}

		public Angle(double radians)
			: this((int)(radians * R2D))
		{ }

		public Angle(int x1, int y1, int x2, int y2)
			: this(Math.Atan2(y2, x2) - Math.Atan2(y1, x1))
		{ }

		public Angle(IPoint2D p1, IPoint2D p2)
			: this(p1.X, p1.Y, p2.X, p2.Y)
		{ }

		public void Transform(ref Point3D p, double offset)
		{
			Transform(ref p, this, offset);
		}

		public void Transform(ref Point2D p, double offset)
		{
			Transform(ref p, this, offset);
		}

		public void Transform(ref int x, ref int y, double offset)
		{
			Transform(ref x, ref y, this, offset);
		}

		public Point2D GetPoint2D(int x, int y, double distance)
		{
			return GetPoint2D(x, y, this, distance);
		}

		public Point3D GetPoint3D(int x, int y, int z, double distance)
		{
			return GetPoint3D(x, y, z, this, distance);
		}

		public override int GetHashCode()
		{
			return m_Degrees;
		}

		public override bool Equals(object obj)
		{
			return (obj is Angle a && Equals(a)) || (obj is int i && Equals(i)) || (obj is double d && Equals(d));
		}

		public bool Equals(Angle angle)
		{
			return m_Degrees == angle.m_Degrees;
		}

		public bool Equals(int degrees)
		{
			return m_Degrees == degrees;
		}

		public bool Equals(double radians)
		{
			return m_Radians == radians;
		}

		public int CompareTo(Angle angle)
		{
			return m_Degrees.CompareTo(angle.m_Degrees);
		}

		public int CompareTo(int degrees)
		{
			return m_Degrees.CompareTo(degrees);
		}

		public int CompareTo(double radians)
		{
			return m_Radians.CompareTo(radians);
		}

		public override string ToString()
		{
			return $"({m_Degrees}, {m_Radians})";
		}

		public Angle Normalize()
		{
			return m_Degrees % 360;
		}

		#region Operators

		public static Angle operator --(Angle a)
		{
			return a.m_Degrees - 1;
		}

		public static Angle operator ++(Angle a)
		{
			return a.m_Degrees + 1;
		}

		public static implicit operator int(Angle a)
		{
			return a.m_Degrees;
		}

		public static implicit operator double(Angle a)
		{
			return a.m_Radians;
		}

		public static implicit operator Angle(int d)
		{
			return new Angle(d);
		}

		public static implicit operator Angle(double r)
		{
			return new Angle(r);
		}

		public static bool operator ==(Angle left, Angle right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Angle left, Angle right)
		{
			return !left.Equals(right);
		}

		public static bool operator <(Angle left, Angle right)
		{
			return left.CompareTo(right) < 0;
		}

		public static bool operator <=(Angle left, Angle right)
		{
			return left.CompareTo(right) <= 0;
		}

		public static bool operator >(Angle left, Angle right)
		{
			return left.CompareTo(right) > 0;
		}

		public static bool operator >=(Angle left, Angle right)
		{
			return left.CompareTo(right) >= 0;
		}

		#endregion Operators
	}
}