#region References
using Server.Commands;
using Server.Gumps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion

namespace Server.Mobiles
{
	[PropertyObject]
	public abstract class Formation
	{
		public static Type[] Types { get; } = Type.EmptyTypes;

		public static HashSet<Formation> Instances { get; } = new();

		public static string FilePath => Path.Combine(Core.CurrentSavesDirectory, "Formations", "Formations.bin");

		static Formation()
		{
			var types = new List<Type>();

			foreach (var type in typeof(Formation).Assembly.GetTypes())
			{
				if (!type.IsAbstract && type.IsAssignableTo(typeof(Formation)))
				{
					if (type.GetConstructor(Type.EmptyTypes) != null)
					{
						types.Add(type);
					}
				}
			}

			Types = types.ToArray();

			types.Clear();
			types.TrimExcess();
		}

		public static void Configure()
		{
			CommandSystem.Register("Formation", AccessLevel.GameMaster, e => BoundingBoxPicker.Begin(e.Mobile, OnTarget, e));

			EventSink.WorldSave += OnWorldSave;
			EventSink.WorldLoad += OnWorldLoad;
		}

		public static T CreateInstance<T>(params BaseCreature[] troops) where T : Formation, new()
		{
			return CreateInstance<T>(troops?.AsEnumerable());
		}

		public static T CreateInstance<T>(IEnumerable<BaseCreature> troops) where T : Formation, new()
		{
			var formation = new T();

			if (troops != null)
			{
				foreach (var t in troops)
				{
					formation.Add(t);
				}
			}

			return formation;
		}

		public static Formation CreateInstance(Type type, params BaseCreature[] troops)
		{
			return CreateInstance(type, troops?.AsEnumerable());
		}

		public static Formation CreateInstance(Type type, IEnumerable<BaseCreature> troops)
		{
			Formation formation = null;

			if (Array.IndexOf(Types, type) >= 0)
			{
				formation = Utility.CreateInstance<Formation>(type);

				if (formation != null && troops != null)
				{
					foreach (var t in troops)
					{
						formation.Add(t);
					}
				}
			}

			return formation;
		}

		private static void OnTarget(Mobile m, Map map, Point3D start, Point3D end, object state)
		{
			var e = (CommandEventArgs)state;

			Type t = null;

			var a = e.GetString(0);

			if (!String.IsNullOrWhiteSpace(a))
			{
				t = Types.FirstOrDefault(o => Insensitive.StartsWith(o.Name, a));
			}

			t ??= Utility.RandomList(Types);

			var nf = CreateInstance(t);

			if (nf == null)
			{
				return;
			}

			Utility.FixPoints(ref start, ref end);

			var mobs = map.GetMobilesInBounds(new Rectangle2D(start, end));

			foreach (var c in mobs.OfType<BaseCreature>())
			{
				c.Formation = nf;
			}

			mobs.Free();

			m.SendMessage($"Created Formation: {nf}");

			m.SendGump(new PropertiesGump(m, nf));
		}

		private static void OnWorldSave(WorldSaveEventArgs e)
		{
			Persistence.Serialize(FilePath, OnSerialize);
		}

		private static void OnSerialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0);

			writer.WriteEncodedInt(Instances.Count);

			foreach (var formation in Instances)
			{
				Persistence.SerializeBlock(writer, w =>
				{
					w.WriteObjectType(formation);

					formation.Serialize(w);
				});
			}
		}

		private static void OnWorldLoad()
		{
			Persistence.Deserialize(FilePath, OnDeserialize);
		}

		private static void OnDeserialize(GenericReader reader)
		{
			_ = reader.ReadEncodedInt();

			var count = reader.ReadEncodedInt();

			while (--count >= 0)
			{
				Persistence.DeserializeBlock(reader, r =>
				{
					var type = r.ReadObjectType();

					var formation = CreateInstance(type);

					formation?.Deserialize(r);
				});
			}
		}

		[CommandProperty(AccessLevel.Counselor, true)]
		public HashSet<Point3D> Points { get; } = new();

		[CommandProperty(AccessLevel.Counselor, true)]
		public HashSet<BaseCreature> Troops { get; } = new();

		[CommandProperty(AccessLevel.Counselor)]
		public int Count => Troops.Count;

		private BaseCreature m_Commander;

		[CommandProperty(AccessLevel.Counselor, true)]
		public BaseCreature Commander
		{
			get => m_Commander;
			private set
			{
				if (m_Commander == value || value?.Deleted == true)
				{
					return;
				}

				if (m_Commander != null)
				{
					m_Commander.SolidHueOverride = -1;
				}

				m_Commander = value;

				if (m_Commander != null && CommanderHue > 0)
				{
					m_Commander.SolidHueOverride = CommanderHue;
				}
			}
		}

		[CommandProperty(AccessLevel.Counselor, true)]
		public Point3D Location => Commander?.Deleted == false ? Commander.Location : Point3D.Zero;

		[CommandProperty(AccessLevel.Counselor, true)]
		public int X => Commander?.Deleted == false ? Commander.X : 0;

		[CommandProperty(AccessLevel.Counselor, true)]
		public int Y => Commander?.Deleted == false ? Commander.Y : 0;

		[CommandProperty(AccessLevel.Counselor, true)]
		public int Z => Commander?.Deleted == false ? Commander.Z : 0;

		[CommandProperty(AccessLevel.Counselor, true)]
		public Map Map => Commander?.Deleted == false ? Commander.Map : Map.Internal;

		[CommandProperty(AccessLevel.Counselor, true)]
		public Direction Facing => Commander?.Deleted == false ? Commander.Direction : default;

		[CommandProperty(AccessLevel.Counselor, true)]
		public bool Disbanding { get; private set; }

		[CommandProperty(AccessLevel.Counselor, true)]
		public int Range { get; private set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int Separation { get; set; } = 1;

		private int m_CommanderHue = 0x22;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public int CommanderHue
		{
			get => m_CommanderHue;
			set
			{
				if (m_CommanderHue == value)
				{
					return;
				}

				m_CommanderHue = value;

				if (m_Commander != null)
				{
					if (m_CommanderHue > 0)
					{
						m_Commander.SolidHueOverride = m_CommanderHue;
					}
					else
					{
						m_Commander.SolidHueOverride = -1;
					}
				}
			}
		}

		private Point3D m_LastLocation;
		private Map m_LastMap;

		private string m_TypeName;

		public Formation()
		{
		}

		public override string ToString()
		{
			m_TypeName ??= GetType().Name;

			if (Commander != null)
			{
				return $"{m_TypeName}[{Count:N0}] ({Commander})";
			}

			return $"{m_TypeName}[{Count:N0}]";
		}

		public bool IsMember(Mobile m)
		{
			return m != null && Troops.Contains(m);
		}

		public void Add(BaseCreature c)
		{
			if (Disbanding || c?.Deleted != false)
			{
				return;
			}

			if (Troops.Add(c) && Troops.Count == 1)
			{
				_ = Instances.Add(this);
			}

			c.Formation = this;

			if (IsEligibleCommander(c))
			{
				Commander = GetStrongest(Commander, c);
			}
		}

		public void Remove(BaseCreature c)
		{
			if (Commander == c)
			{
				Commander = null;
			}

			if (c?.Formation == this && (Disbanding || Troops.Remove(c)))
			{
				c.Formation = null;
			}

			if (Troops.Count == 0)
			{
				_ = Instances.Remove(this);

				Points.Clear();
			}
		}

		public void Invalidate(bool updatePoints)
		{
			if (Disbanding)
			{
				return;
			}

			if (!IsEligibleCommander(Commander))
			{
				Remove(Commander);
			}

			if (Commander == null && Count > 0)
			{
				InvalidateCommander();
			}

			if (Commander == null || Count <= 0)
			{
				Disband();
				return;
			}

			if (updatePoints)
			{
				var map = Map;
				var loc = Location;

				if (map != null && map != Map.Internal && loc != Point3D.Zero && (m_LastLocation != loc || m_LastMap != map))
				{
					Points.Clear();

					var dist = 0.0;
					var sep = Separation + 1;

					foreach (var p in ComputePoints())
					{
						if (sep > 1 && ((p.X - loc.X) % sep != 0 || (p.Y - loc.Y) % sep != 0))
						{
							continue;
						}

						int z = 0, _1 = 0, _2 = 0;

						map.GetAverageZ(p.X, p.Y, ref _1, ref _2, ref z);

						if (Points.Add(new Point3D(p, z)))
						{
							dist = Math.Max(dist, Utility.GetDistanceToSqrt(p, loc));
						}
					}

					Range = (int)Math.Ceiling(dist);

					m_LastLocation = loc;
					m_LastMap = map;
				}
			}

			OnInvalidate();
		}

		protected virtual void OnInvalidate()
		{
		}

		public void InvalidateCommander()
		{
			if (Disbanding)
			{
				return;
			}

			var strongest = Commander;

			foreach (var troop in Troops)
			{
				if (IsEligibleCommander(troop))
				{
					strongest = GetStrongest(strongest, troop);
				}
			}

			Commander = strongest;
		}

		protected virtual BaseCreature GetStrongest(BaseCreature a, BaseCreature b)
		{
			if (a?.Deleted != false)
			{
				return b;
			}

			if (b?.Deleted != false)
			{
				return a;
			}

			var x = a.RawStatTotal + a.SkillsTotal;
			var y = b.RawStatTotal + b.SkillsTotal;

			return x >= y ? a : b;
		}

		public void Disband()
		{
			Disbanding = true;

			foreach (var troop in Troops.ToArray())
			{
				Remove(troop);
			}

			Troops.Clear();

			Disbanding = false;

			_ = Instances.Remove(this);

			Points.Clear();
		}

		public virtual bool IsEligibleCommander(BaseCreature m)
		{
			return m?.Deleted == false && Troops.Contains(m);
		}

		public bool CheckMove(BaseCreature c, out Point3D to)
		{
			to = Point3D.Zero;

			Invalidate(true);

			if (Disbanding)
			{
				return false;
			}

			if (c?.Deleted != false || Commander?.Deleted != false)
			{
				return false;
			}

			if (Commander == c || Commander.Map != c.Map)
			{
				return false;
			}

			var map = Map;
			var loc = Location;

			if (map == null || map == Map.Internal || loc == Point3D.Zero)
			{
				return false;
			}

			if (Points.Count == 0)
			{
				return false;
			}

			double? dist = null;

			foreach (var p in Points)
			{
				if (!map.CanFit(p, 16, true, false))
				{
					continue;
				}

				if (Troops.Any(t => t != c && t.X == p.X && t.Y == p.Y))
				{
					continue;
				}

				var d = Utility.GetDistanceToSqrt(p, c);

				if (dist == null || d < dist)
				{
					dist = d;
					to = p;
				}
			}

			return dist != null;
		}

		protected abstract IEnumerable<Point2D> ComputePoints();

		public virtual void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0);

			writer.Write(Separation);

			writer.Write(Commander);
			writer.WriteEncodedInt(CommanderHue);

			writer.WriteMobileSet(Troops, true);
		}

		public virtual void Deserialize(GenericReader reader)
		{
			_ = reader.ReadEncodedInt();

			Separation = reader.ReadInt();

			Commander = reader.ReadMobile<BaseCreature>();
			CommanderHue = reader.ReadEncodedInt();

			foreach (var c in reader.ReadMobileSet<BaseCreature>())
			{
				Add(c);
			}
		}
	}
}