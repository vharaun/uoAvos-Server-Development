
using System;
using System.IO;

namespace Server
{
	public enum BodyType : byte
	{
		Empty,
		Monster,
		Sea,
		Animal,
		Human,
		Equipment
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class BodyAttribute : Attribute
	{
		public BodyAttribute()
		{
		}
	}

	public struct Body
	{
		public static Body[] Bodies { get; } = new Body[0x1000];
		public static BodyType[] Types { get; } = new BodyType[0x1000];

		static Body()
		{
			Load();
		}

		public static void Clear()
		{
			Array.Clear(Bodies, 0, Bodies.Length);
			Array.Clear(Types, 0, Types.Length);
		}

		public static void Load()
		{
			var path = Core.FindDataFile("mobtypes.txt");

			if (!File.Exists(path))
			{
				Console.WriteLine($"Warning: File not found: {path}");
				return;
			}

			Clear();

			foreach (var line in File.ReadLines(path))
			{
				var entry = line.Trim();

				if (entry.Length == 0 || entry.StartsWith("#"))
				{
					continue;
				}

				var split = entry.Split(m_Splitters, StringSplitOptions.RemoveEmptyEntries);

				if (split.Length > 4)
				{
					var subsplit = split[..4];
					var last = subsplit.Length - 1;

					subsplit[last] = String.Join(" ", split[last..]);

					split = subsplit;
				}

				if (split.Length < 2)
				{
					Console.WriteLine($"Warning: Invalid body entry: {entry}");
					continue;
				}

				if (!Int32.TryParse(split[0], out var body) || body < 0 || body >= Types.Length)
				{
					Console.WriteLine($"Warning: Invalid body entry: {entry}");
					continue;
				}

				var space = split[1].IndexOf('_');

				if (space > 0)
				{
					split[1] = split[1].Substring(0, space);
				}

				if (!Enum.TryParse(split[1], true, out BodyType type))
				{
					Console.WriteLine($"Warning: Invalid body entry: {entry}");
					continue;
				}

				Types[body] = type;
				Bodies[body] = body;
			}
		}

		private static readonly char[] m_Splitters = { '\t', ' ' };

		private readonly int m_BodyID;

		public Body(int bodyID)
		{
			m_BodyID = bodyID;
		}

		public BodyType Type
		{
			get
			{
				if (m_BodyID >= 0 && m_BodyID < Types.Length)
				{
					return Types[m_BodyID];
				}
				else
				{
					return BodyType.Empty;
				}
			}
		}

		public bool IsHuman => m_BodyID >= 0 && m_BodyID < Types.Length && Types[m_BodyID] == BodyType.Human
		 && m_BodyID != 402
		 && m_BodyID != 403
		 && m_BodyID != 607
		 && m_BodyID != 608
		 && m_BodyID != 694
		 && m_BodyID != 695
		 && m_BodyID != 970;

		public bool IsGargoyle =>
			m_BodyID == 666
		 || m_BodyID == 667
		 || m_BodyID == 694
		 || m_BodyID == 695;

		public bool IsMale =>
			m_BodyID == 183
		 || m_BodyID == 185
		 || m_BodyID == 400
		 || m_BodyID == 402
		 || m_BodyID == 605
		 || m_BodyID == 607
		 || m_BodyID == 666
		 || m_BodyID == 694
		 || m_BodyID == 750;

		public bool IsFemale =>
			m_BodyID == 184
		 || m_BodyID == 186
		 || m_BodyID == 401
		 || m_BodyID == 403
		 || m_BodyID == 606
		 || m_BodyID == 608
		 || m_BodyID == 667
		 || m_BodyID == 695
		 || m_BodyID == 751;

		public bool IsGhost =>
			m_BodyID == 402
		 || m_BodyID == 403
		 || m_BodyID == 607
		 || m_BodyID == 608
		 || m_BodyID == 694
		 || m_BodyID == 695
		 || m_BodyID == 970;

		public bool IsMonster => m_BodyID >= 0 && m_BodyID < Types.Length && Types[m_BodyID] == BodyType.Monster;

		public bool IsAnimal => m_BodyID >= 0 && m_BodyID < Types.Length && Types[m_BodyID] == BodyType.Animal;

		public bool IsEmpty => m_BodyID >= 0 && m_BodyID < Types.Length && Types[m_BodyID] == BodyType.Empty;

		public bool IsSea => m_BodyID >= 0 && m_BodyID < Types.Length && Types[m_BodyID] == BodyType.Sea;

		public bool IsEquipment => m_BodyID >= 0 && m_BodyID < Types.Length && Types[m_BodyID] == BodyType.Equipment;

		public int BodyID => m_BodyID;

		public static implicit operator int(Body a)
		{
			return a.m_BodyID;
		}

		public static implicit operator Body(int a)
		{
			return new Body(a);
		}

		public override string ToString()
		{
			return String.Format("0x{0:X}", m_BodyID);
		}

		public override int GetHashCode()
		{
			return m_BodyID;
		}

		public override bool Equals(object o)
		{
			if (o == null || !(o is Body))
			{
				return false;
			}

			return ((Body)o).m_BodyID == m_BodyID;
		}

		public static bool operator ==(Body l, Body r)
		{
			return l.m_BodyID == r.m_BodyID;
		}

		public static bool operator !=(Body l, Body r)
		{
			return l.m_BodyID != r.m_BodyID;
		}

		public static bool operator >(Body l, Body r)
		{
			return l.m_BodyID > r.m_BodyID;
		}

		public static bool operator >=(Body l, Body r)
		{
			return l.m_BodyID >= r.m_BodyID;
		}

		public static bool operator <(Body l, Body r)
		{
			return l.m_BodyID < r.m_BodyID;
		}

		public static bool operator <=(Body l, Body r)
		{
			return l.m_BodyID <= r.m_BodyID;
		}
	}
}