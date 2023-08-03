﻿using Server.Commands;
using Server.Gumps;
using Server.Items;
using Server.Multis;
using Server.Network;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

#region Developer Notations

/// UsesSpawnerHome true causes normal behavior, while false will cause the spawner to set the 
/// mobile's home to be its spawn location, thus, not walking back to the spawner.  This will
/// create a less artificial feel to mobiles attempting to return to their home location.
///
/// Also, the spawn area and home range work together. If the area is not set, they will behave 
/// pretty much like they always have.  If the area is set, the mobile will spawn within that 
/// rectangle.  If both are set, the spawn location will be based on the rectangle and allow an 
/// additional # of tiles, which is the home range.
///
/// Also, since the home does not necessarily equate to the spawner location any longer, a 
/// getter/ setter was added to the BaseCreature.

#endregion

namespace Server.Mobiles
{
	public class Spawner : Item, ISpawner
	{
		private int m_Team;
		private int m_HomeRange;
		private int m_WalkingRange;
		private int m_Count;
		private TimeSpan m_MinDelay;
		private TimeSpan m_MaxDelay;
		private List<string> m_SpawnNames;
		private List<ISpawnable> m_Spawned;
		private DateTime m_End;
		private InternalTimer m_Timer;
		private bool m_Running;
		private bool m_Group;
		private WayPoint m_WayPoint;
		private bool m_UsesSpawnerHome;
		private Rectangle2D m_SpawnArea;
		private bool m_IgnoreHousing;
		private bool m_MobilesSeekHome;

		public bool IsFull => (m_Spawned.Count >= m_Count);
		public bool IsEmpty => (m_Spawned.Count == 0);

		public List<string> SpawnNames
		{
			get => m_SpawnNames;
			set
			{
				m_SpawnNames = value;
				if (m_SpawnNames.Count < 1)
				{
					Stop();
				}

				InvalidateProperties();
			}
		}

		public List<ISpawnable> Spawned => m_Spawned;

		public virtual int SpawnNamesCount => m_SpawnNames.Count;

		public override void OnAfterDuped(Item newItem)
		{
			var s = newItem as Spawner;

			if (s == null)
			{
				return;
			}

			s.m_SpawnNames = new List<string>(m_SpawnNames);
			s.m_Spawned = new List<ISpawnable>();
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IgnoreHousing
		{
			get => m_IgnoreHousing;
			set => m_IgnoreHousing = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool MobilesSeekHome
		{
			get => m_MobilesSeekHome;
			set => m_MobilesSeekHome = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Rectangle2D SpawnArea
		{
			get => m_SpawnArea;
			set => m_SpawnArea = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Count
		{
			get => m_Count;
			set { m_Count = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public WayPoint WayPoint
		{
			get => m_WayPoint;
			set => m_WayPoint = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Running
		{
			get => m_Running;
			set
			{
				if (value)
				{
					Start();
				}
				else
				{
					Stop();
				}

				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool UsesSpawnerHome
		{
			get => m_UsesSpawnerHome;
			set => m_UsesSpawnerHome = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int HomeRange
		{
			get => m_HomeRange;
			set { m_HomeRange = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int WalkingRange
		{
			get => m_WalkingRange;
			set { m_WalkingRange = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Team
		{
			get => m_Team;
			set { m_Team = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan MinDelay
		{
			get => m_MinDelay;
			set { m_MinDelay = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan MaxDelay
		{
			get => m_MaxDelay;
			set { m_MaxDelay = value; InvalidateProperties(); }
		}

		public DateTime End
		{
			get => m_End;
			set => m_End = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TimeSpan NextSpawn
		{
			get
			{
				if (m_Running)
				{
					return m_End - DateTime.UtcNow;
				}
				else
				{
					return TimeSpan.FromSeconds(0);
				}
			}
			set
			{
				Start();
				DoTimer(value);
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Group
		{
			get => m_Group;
			set { m_Group = value; InvalidateProperties(); }
		}

		[Constructable]
		public Spawner()
			: this(null)
		{
		}

		[Constructable]
		public Spawner(string spawnName)
			: this(1, 5, 10, 0, 4, spawnName)
		{
		}

		[Constructable]
		public Spawner(int amount, int minDelay, int maxDelay, int team, int homeRange, string spawnName)
			: this(amount, TimeSpan.FromMinutes(minDelay), TimeSpan.FromMinutes(maxDelay), team, homeRange, spawnName)
		{
		}

		[Constructable]
		public Spawner(int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, string spawnName)
			: base(0x1f13)
		{
			var spawnNames = new List<string>();

			if (!String.IsNullOrEmpty(spawnName))
			{
				spawnNames.Add(spawnName);
			}

			InitSpawner(amount, minDelay, maxDelay, team, homeRange, spawnNames);
		}

		public Spawner(int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, List<string> spawnNames)
			: base(0x1f13)
		{
			InitSpawner(amount, minDelay, maxDelay, team, homeRange, spawnNames);
		}

		public override string DefaultName => "Spawner";

		private void InitSpawner(int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, List<string> spawnNames)
		{
			Visible = false;
			Movable = false;
			m_Running = true;
			m_Group = false;
			m_MinDelay = minDelay;
			m_MaxDelay = maxDelay;
			m_Count = amount;
			m_Team = team;
			m_HomeRange = homeRange;
			m_WalkingRange = -1;
			m_SpawnNames = spawnNames;
			m_Spawned = new List<ISpawnable>();
			DoTimer(TimeSpan.FromSeconds(1));
		}

		public Spawner(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from.AccessLevel < AccessLevel.GameMaster)
			{
				return;
			}

			var g = new SpawnerGump(this);
			from.SendGump(g);
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (m_Running)
			{
				list.Add(1060742); // active

				list.Add(1060656, m_Count.ToString()); // amount to make: ~1_val~
				list.Add(1061169, m_HomeRange.ToString()); // range ~1_val~
				list.Add(1060658, "walking range\t{0}", m_WalkingRange); // ~1_val~: ~2_val~

				list.Add(1060659, "group\t{0}", m_Group); // ~1_val~: ~2_val~
				list.Add(1060660, "team\t{0}", m_Team); // ~1_val~: ~2_val~
				list.Add(1060661, "speed\t{0} to {1}", m_MinDelay, m_MaxDelay); // ~1_val~: ~2_val~

				if (m_SpawnNames.Count != 0)
				{
					list.Add(SpawnedStats());
				}
			}
			else
			{
				list.Add(1060743); // inactive
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			base.OnSingleClick(from);

			if (m_Running)
			{
				LabelTo(from, "[Running]");
			}
			else
			{
				LabelTo(from, "[Off]");
			}
		}

		public void Start()
		{
			if (!m_Running)
			{
				if (SpawnNamesCount > 0)
				{
					m_Running = true;
					DoTimer();
				}
			}
		}

		public void Stop()
		{
			if (m_Running)
			{
				if (m_Timer != null)
				{
					m_Timer.Stop();
				}

				m_Running = false;
			}
		}

		public static string ParseType(string s)
		{
			return s.Split(null, 2)[0];
		}

		public void Defrag()
		{
			var removed = false;

			for (var i = 0; i < m_Spawned.Count; ++i)
			{
				var e = m_Spawned[i];

				var toRemove = false;

				if (e is Item)
				{
					var item = (Item)e;

					if (item.Deleted || item.Parent != null)
					{
						toRemove = true;
					}
				}
				else if (e is Mobile)
				{
					var m = (Mobile)e;

					if (m.Deleted)
					{
						toRemove = true;
					}
					else if (m is BaseCreature)
					{
						var bc = (BaseCreature)m;

						if (bc.Controlled || bc.IsStabled)
						{
							toRemove = true;
						}
					}
				}

				if (toRemove)
				{
					m_Spawned.RemoveAt(i);
					--i;
					removed = true;
				}
			}

			if (removed)
			{
				InvalidateProperties();
			}
		}

		bool ISpawner.UnlinkOnTaming => true;

		void ISpawner.Remove(ISpawnable spawn)
		{
			m_Spawned.Remove(spawn);

			InvalidateProperties();
		}

		public void OnTick()
		{
			DoTimer();

			if (m_Group)
			{
				Defrag();

				if (m_Spawned.Count == 0)
				{
					Respawn();
				}
				else
				{
					return;
				}
			}
			else
			{
				Spawn();
			}
		}

		public virtual void Respawn()
		{
			RemoveSpawned();

			for (var i = 0; i < m_Count; i++)
			{
				Spawn();
			}
		}

		public virtual void Spawn()
		{
			if (SpawnNamesCount > 0)
			{
				Spawn(Utility.Random(SpawnNamesCount));
			}
		}

		public void Spawn(string creatureName)
		{
			for (var i = 0; i < m_SpawnNames.Count; i++)
			{
				if (m_SpawnNames[i] == creatureName)
				{
					Spawn(i);
					break;
				}
			}
		}

		protected virtual ISpawnable CreateSpawnedObject(int index)
		{
			if (index >= m_SpawnNames.Count)
			{
				return null;
			}

			var type = ScriptCompiler.FindTypeByName(ParseType(m_SpawnNames[index]));

			if (type != null)
			{
				try
				{
					return Build(type, CommandSystem.Split(m_SpawnNames[index]));
				}
				catch
				{
				}
			}

			return null;
		}

		public static ISpawnable Build(Type type, string[] args)
		{
			var isISpawnable = typeof(ISpawnable).IsAssignableFrom(type);

			if (!isISpawnable)
			{
				return null;
			}

			Add.FixArgs(ref args);

			string[,] props = null;

			for (var i = 0; i < args.Length; ++i)
			{
				if (Insensitive.Equals(args[i], "set"))
				{
					var remains = args.Length - i - 1;

					if (remains >= 2)
					{
						props = new string[remains / 2, 2];

						remains /= 2;

						for (var j = 0; j < remains; ++j)
						{
							props[j, 0] = args[i + (j * 2) + 1];
							props[j, 1] = args[i + (j * 2) + 2];
						}

						Add.FixSetString(ref args, i);
					}

					break;
				}
			}

			PropertyInfo[] realProps = null;

			if (props != null)
			{
				realProps = new PropertyInfo[props.GetLength(0)];

				var allProps = type.GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

				for (var i = 0; i < realProps.Length; ++i)
				{
					PropertyInfo thisProp = null;

					var propName = props[i, 0];

					for (var j = 0; thisProp == null && j < allProps.Length; ++j)
					{
						if (Insensitive.Equals(propName, allProps[j].Name))
						{
							thisProp = allProps[j];
						}
					}

					if (thisProp != null)
					{
						var attr = Props.GetCPA(thisProp);

						if (attr != null && AccessLevel.GameMaster >= attr.WriteLevel && thisProp.CanWrite && !attr.ReadOnly)
						{
							realProps[i] = thisProp;
						}
					}
				}
			}

			var ctors = type.GetConstructors();

			for (var i = 0; i < ctors.Length; ++i)
			{
				var ctor = ctors[i];

				if (!Add.IsConstructable(ctor, AccessLevel.GameMaster))
				{
					continue;
				}

				var paramList = ctor.GetParameters();

				if (args.Length == paramList.Length)
				{
					var paramValues = Add.ParseValues(paramList, args);

					if (paramValues == null)
					{
						continue;
					}

					var built = ctor.Invoke(paramValues);

					if (built != null && realProps != null)
					{
						for (var j = 0; j < realProps.Length; ++j)
						{
							if (realProps[j] == null)
							{
								continue;
							}

							var result = Props.InternalSetValue(built, realProps[j], props[j, 1]);
						}
					}

					return (ISpawnable)built;
				}
			}

			return null;
		}

		public Point3D HomeLocation => Location;

		public virtual bool CheckSpawnerFull()
		{
			return (m_Spawned.Count >= m_Count);
		}

		public void Spawn(int index)
		{
			var map = Map;

			if (map == null || map == Map.Internal || SpawnNamesCount == 0 || index >= SpawnNamesCount || Parent != null)
			{
				return;
			}

			Defrag();

			if (CheckSpawnerFull())
			{
				return;
			}

			var spawned = CreateSpawnedObject(index);

			if (spawned == null)
			{
				return;
			}

			spawned.Spawner = this;
			m_Spawned.Add(spawned);

			var loc = (spawned is BaseVendor ? Location : GetSpawnPosition(spawned));

			spawned.OnBeforeSpawn(loc, map);
			spawned.MoveToWorld(loc, map);
			spawned.OnAfterSpawn();

			if (spawned is BaseCreature)
			{
				var bc = (BaseCreature)spawned;

				if (m_WalkingRange >= 0)
				{
					bc.RangeHome = m_WalkingRange;
				}
				else
				{
					bc.RangeHome = m_HomeRange;
				}

				bc.CurrentWayPoint = m_WayPoint;

				bc.SeeksHome = m_MobilesSeekHome;

				if (m_Team > 0)
				{
					bc.Team = m_Team;
				}

				bc.Home = (m_UsesSpawnerHome) ? HomeLocation : bc.Location;
			}

			InvalidateProperties();
		}

		public Point3D GetSpawnPosition()
		{
			return GetSpawnPosition(null);
		}

		private int GetAdjustedLocation(int range, int side, int coord, int coord_this)
		{
			return (((coord > 0) ? coord : (coord_this - range)) + (Utility.Random(Math.Max((((range * 2) + 1) + side), 1))));
		}

		public Point3D GetSpawnPosition(ISpawnable spawned)
		{
			var map = Map;

			if (map == null)
			{
				return Location;
			}

			bool waterMob, waterOnlyMob;

			if (spawned is Mobile)
			{
				var mob = (Mobile)spawned;

				waterMob = mob.CanSwim;
				waterOnlyMob = (mob.CanSwim && mob.CantWalk);
			}
			else
			{
				waterMob = false;
				waterOnlyMob = false;
			}

			for (var i = 0; i < 10; ++i)
			{
				var x = GetAdjustedLocation(m_HomeRange, m_SpawnArea.Width, m_SpawnArea.X, X);
				var y = GetAdjustedLocation(m_HomeRange, m_SpawnArea.Height, m_SpawnArea.Y, Y);

				var mapZ = map.GetAverageZ(x, y);

				if (m_IgnoreHousing || ((BaseHouse.FindHouseAt(new Point3D(x, y, mapZ), Map, 16) == null &&
					BaseHouse.FindHouseAt(new Point3D(x, y, Z), Map, 16) == null)))
				{
					if (waterMob)
					{
						if (IsValidWater(map, x, y, Z))
						{
							return new Point3D(x, y, Z);
						}
						else if (IsValidWater(map, x, y, mapZ))
						{
							return new Point3D(x, y, mapZ);
						}
					}

					if (!waterOnlyMob)
					{
						if (map.CanSpawnMobile(x, y, Z))
						{
							return new Point3D(x, y, Z);
						}
						else if (map.CanSpawnMobile(x, y, mapZ))
						{
							return new Point3D(x, y, mapZ);
						}
					}
				}
			}

			return Location;
		}

		public static bool IsValidWater(Map map, int x, int y, int z)
		{
			if (!Region.Find(new Point3D(x, y, z), map).AllowSpawn() || !map.CanFit(x, y, z, 16, false, true, false))
			{
				return false;
			}

			var landTile = map.Tiles.GetLandTile(x, y);

			if (landTile.Z == z && (TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags & TileFlag.Wet) != 0)
			{
				return true;
			}

			var staticTiles = map.Tiles.GetStaticTiles(x, y, true);

			for (var i = 0; i < staticTiles.Length; ++i)
			{
				var staticTile = staticTiles[i];

				if (staticTile.Z == z && (TileData.ItemTable[staticTile.ID & TileData.MaxItemValue].Flags & TileFlag.Wet) != 0)
				{
					return true;
				}
			}

			return false;
		}

		public void DoTimer()
		{
			if (!m_Running)
			{
				return;
			}

			var minSeconds = (int)m_MinDelay.TotalSeconds;
			var maxSeconds = (int)m_MaxDelay.TotalSeconds;

			var delay = TimeSpan.FromSeconds(Utility.RandomMinMax(minSeconds, maxSeconds));
			DoTimer(delay);
		}

		public virtual void DoTimer(TimeSpan delay)
		{
			if (!m_Running)
			{
				return;
			}

			m_End = DateTime.UtcNow + delay;

			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			m_Timer = new InternalTimer(this, delay);
			m_Timer.Start();
		}

		private class InternalTimer : Timer
		{
			private readonly Spawner m_Spawner;

			public InternalTimer(Spawner spawner, TimeSpan delay) : base(delay)
			{
				if (spawner.IsFull)
				{
					Priority = TimerPriority.FiveSeconds;
				}
				else
				{
					Priority = TimerPriority.OneSecond;
				}

				m_Spawner = spawner;
			}

			protected override void OnTick()
			{
				if (m_Spawner != null)
				{
					if (!m_Spawner.Deleted)
					{
						m_Spawner.OnTick();
					}
				}
			}
		}

		public string SpawnedStats()
		{
			Defrag();

			var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

			foreach (var entry in m_SpawnNames)
			{
				var name = ParseType(entry);
				var type = ScriptCompiler.FindTypeByName(name);

				if (type == null)
				{
					counts[name] = 0;
				}
				else
				{
					counts[type.Name] = 0;
				}
			}

			foreach (var spawned in m_Spawned)
			{
				var name = spawned.GetType().Name;

				if (counts.ContainsKey(name))
				{
					++counts[name];
				}
				else
				{
					counts[name] = 1;
				}
			}

			var names = new List<string>(counts.Keys);
			names.Sort();

			var result = new StringBuilder();

			for (var i = 0; i < names.Count; ++i)
			{
				result.AppendFormat("{0}{1}: {2}", (i == 0) ? "" : "<BR>", names[i], counts[names[i]]);
			}

			return result.ToString();
		}

		public int CountCreatures(string creatureName)
		{
			Defrag();

			var count = 0;

			for (var i = 0; i < m_Spawned.Count; ++i)
			{
				if (Insensitive.Equals(creatureName, m_Spawned[i].GetType().Name))
				{
					++count;
				}
			}

			return count;
		}

		public void RemoveSpawned(string creatureName)
		{
			Defrag();

			for (var i = m_Spawned.Count - 1; i >= 0; --i)
			{
				IEntity e = m_Spawned[i];

				if (Insensitive.Equals(creatureName, e.GetType().Name))
				{
					e.Delete();
				}
			}

			InvalidateProperties();
		}

		public void RemoveSpawned()
		{
			Defrag();

			for (var i = m_Spawned.Count - 1; i >= 0; --i)
			{
				m_Spawned[i].Delete();
			}

			InvalidateProperties();
		}

		public void BringToHome()
		{
			Defrag();

			for (var i = 0; i < m_Spawned.Count; ++i)
			{
				var e = m_Spawned[i];

				e.MoveToWorld(Location, Map);
			}
		}

		public override void OnDelete()
		{
			base.OnDelete();

			RemoveSpawned();

			if (m_Timer != null)
			{
				m_Timer.Stop();
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(6); // version

			writer.Write(m_MobilesSeekHome);

			writer.Write(m_IgnoreHousing);

			writer.Write(m_SpawnArea);

			writer.Write(m_UsesSpawnerHome);

			writer.Write(m_WalkingRange);

			writer.Write(m_WayPoint);

			writer.Write(m_Group);

			writer.Write(m_MinDelay);
			writer.Write(m_MaxDelay);
			writer.Write(m_Count);
			writer.Write(m_Team);
			writer.Write(m_HomeRange);
			writer.Write(m_Running);

			if (m_Running)
			{
				writer.WriteDeltaTime(m_End);
			}

			writer.Write(m_SpawnNames.Count);

			for (var i = 0; i < m_SpawnNames.Count; ++i)
			{
				writer.Write(m_SpawnNames[i]);
			}

			writer.Write(m_Spawned.Count);

			for (var i = 0; i < m_Spawned.Count; ++i)
			{
				IEntity e = m_Spawned[i];

				if (e is Item)
				{
					writer.Write((Item)e);
				}
				else if (e is Mobile)
				{
					writer.Write((Mobile)e);
				}
				else
				{
					writer.Write(Serial.MinusOne);
				}
			}
		}

		private static WarnTimer m_WarnTimer;

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 6:
					{
						m_MobilesSeekHome = reader.ReadBool();
						m_UsesSpawnerHome = reader.ReadBool();
						goto case 5;
					}
				case 5:
					{
						m_SpawnArea = reader.ReadRect2D();
						m_UsesSpawnerHome = reader.ReadBool();

						goto case 4;
					}
				case 4:
					{
						m_WalkingRange = reader.ReadInt();

						goto case 3;
					}
				case 3:
				case 2:
					{
						m_WayPoint = reader.ReadItem() as WayPoint;

						goto case 1;
					}

				case 1:
					{
						m_Group = reader.ReadBool();

						goto case 0;
					}

				case 0:
					{
						m_MinDelay = reader.ReadTimeSpan();
						m_MaxDelay = reader.ReadTimeSpan();
						m_Count = reader.ReadInt();
						m_Team = reader.ReadInt();
						m_HomeRange = reader.ReadInt();
						m_Running = reader.ReadBool();

						var ts = TimeSpan.Zero;

						if (m_Running)
						{
							ts = reader.ReadDeltaTime() - DateTime.UtcNow;
						}

						var size = reader.ReadInt();

						m_SpawnNames = new List<string>(size);

						for (var i = 0; i < size; ++i)
						{
							var creatureString = reader.ReadString();

							m_SpawnNames.Add(creatureString);
							var typeName = ParseType(creatureString);

							if (ScriptCompiler.FindTypeByName(typeName) == null)
							{
								if (m_WarnTimer == null)
								{
									m_WarnTimer = new WarnTimer();
								}

								m_WarnTimer.Add(Location, Map, typeName);
							}
						}

						var count = reader.ReadInt();

						m_Spawned = new List<ISpawnable>(count);

						for (var i = 0; i < count; ++i)
						{
							var e = reader.ReadEntity<ISpawnable>();

							if (e != null)
							{
								e.Spawner = this;
								m_Spawned.Add(e);
							}
						}

						if (m_Running)
						{
							DoTimer(ts);
						}

						break;
					}
			}

			if (version < 3 && Weight == 0)
			{
				Weight = -1;
			}
		}

		private class WarnTimer : Timer
		{
			private readonly List<WarnEntry> m_List;

			private class WarnEntry
			{
				public Point3D m_Point;
				public Map m_Map;
				public string m_Name;

				public WarnEntry(Point3D p, Map map, string name)
				{
					m_Point = p;
					m_Map = map;
					m_Name = name;
				}
			}

			public WarnTimer() : base(TimeSpan.FromSeconds(1.0))
			{
				m_List = new List<WarnEntry>();
				Start();
			}

			public void Add(Point3D p, Map map, string name)
			{
				m_List.Add(new WarnEntry(p, map, name));
			}

			protected override void OnTick()
			{
				try
				{
					Console.WriteLine("Warning: {0} bad spawns detected, logged: 'badspawn.log'", m_List.Count);

					using (var op = new StreamWriter("badspawn.log", true))
					{
						op.WriteLine("# Bad spawns : {0}", DateTime.UtcNow);
						op.WriteLine("# Format: X Y Z F Name");
						op.WriteLine();

						foreach (var e in m_List)
						{
							op.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", e.m_Point.X, e.m_Point.Y, e.m_Point.Z, e.m_Map, e.m_Name);
						}

						op.WriteLine();
						op.WriteLine();
					}
				}
				catch
				{
				}
			}
		}
	}

	public class SpawnerGump : Gump
	{
		private readonly Spawner m_Spawner;

		public SpawnerGump(Spawner spawner) : base(50, 50)
		{
			m_Spawner = spawner;

			AddPage(0);

			AddBackground(0, 0, 410, 371, 5054);

			AddLabel(160, 1, 0, "Creatures List");

			AddButton(5, 347, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
			AddLabel(38, 347, 0x384, "Cancel");

			AddButton(5, 325, 0xFB7, 0xFB9, 1, GumpButtonType.Reply, 0);
			AddLabel(38, 325, 0x384, "Apply");

			AddButton(110, 325, 0xFB4, 0xFB6, 2, GumpButtonType.Reply, 0);
			AddLabel(143, 325, 0x384, "Bring to Home");

			AddButton(110, 347, 0xFA8, 0xFAA, 3, GumpButtonType.Reply, 0);
			AddLabel(143, 347, 0x384, "Total Respawn");

			for (var i = 0; i < 13; i++)
			{
				AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
				AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

				AddImageTiled(71, (22 * i) + 20, 309, 23, 0xA40);
				AddImageTiled(72, (22 * i) + 21, 307, 21, 0xBBC);

				var str = "";

				if (i < spawner.SpawnNames.Count)
				{
					str = spawner.SpawnNames[i];
					var count = m_Spawner.CountCreatures(str);

					AddLabel(382, (22 * i) + 20, 0, count.ToString());
				}

				AddTextEntry(75, (22 * i) + 21, 304, 21, 0, i, str);
			}
		}

		public List<string> CreateArray(RelayInfo info, Mobile from)
		{
			var creaturesName = new List<string>();

			for (var i = 0; i < 13; i++)
			{
				var te = info.GetTextEntry(i);

				if (te != null)
				{
					var str = te.Text;

					if (str.Length > 0)
					{
						str = str.Trim();

						var t = Spawner.ParseType(str);

						var type = ScriptCompiler.FindTypeByName(t);

						if (type != null)
						{
							creaturesName.Add(str);
						}
						else
						{
							from.SendMessage("{0} is not a valid type name.", t);
						}
					}
				}
			}

			return creaturesName;
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (m_Spawner.Deleted || state.Mobile.AccessLevel < AccessLevel.GameMaster)
			{
				return;
			}

			switch (info.ButtonID)
			{
				case 0: // Closed
					{
						return;
					}
				case 1: // Apply
					{
						m_Spawner.SpawnNames = CreateArray(info, state.Mobile);

						break;
					}
				case 2: // Bring to Home
					{
						m_Spawner.BringToHome();

						break;
					}
				case 3: // Total Respawn
					{
						m_Spawner.Respawn();

						break;
					}
				default:
					{
						var buttonID = info.ButtonID - 4;
						var index = buttonID / 2;
						var type = buttonID % 2;

						var entry = info.GetTextEntry(index);

						if (entry != null && entry.Text.Length > 0)
						{
							if (type == 0) // Spawn creature
							{
								m_Spawner.Spawn(entry.Text);
							}
							else // Remove creatures
							{
								m_Spawner.RemoveSpawned(entry.Text);
							}

							m_Spawner.SpawnNames = CreateArray(info, state.Mobile);
						}

						break;
					}
			}

			state.Mobile.SendGump(new SpawnerGump(m_Spawner));
		}
	}

	public class SpawnerType
	{
		public static Type GetType(string name)
		{
			return ScriptCompiler.FindTypeByName(name);
		}
	}
}