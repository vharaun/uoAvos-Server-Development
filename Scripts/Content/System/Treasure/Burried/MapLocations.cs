using Server.ContextMenus;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections.Generic;
using System.IO;

namespace Server.Items
{
	public class TreasureMap : MapItem
	{
		private int m_Level;
		private bool m_Completed;
		private Mobile m_CompletedBy;
		private Mobile m_Decoder;
		private Map m_Map;
		private Point2D m_Location;

		[CommandProperty(AccessLevel.GameMaster)]
		public int Level { get => m_Level; set { m_Level = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Completed { get => m_Completed; set { m_Completed = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile CompletedBy { get => m_CompletedBy; set { m_CompletedBy = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Decoder { get => m_Decoder; set { m_Decoder = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public Map ChestMap { get => m_Map; set { m_Map = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point2D ChestLocation { get => m_Location; set => m_Location = value; }

		public static Point2D[] Locations { get; } = 
		{
			#region Locations

			new(2643, 851),
			new(2672, 392),
			new(3404, 238),
			new(3369, 637),
			new(2740, 435),
			new(2770, 345),
			new(2781, 289),
			new(2836, 233),
			new(3014, 250),
			new(3082, 202),
			new(3246, 245),
			new(3375, 458),
			new(1314, 317),
			new(1470, 229),
			new(1504, 366),
			new(2340, 645),
			new(2350, 688),
			new(2395, 723),
			new(2433, 767),
			new(1319, 889),
			new(1414, 771),
			new(1529, 753),
			new(1555, 806),
			new(1511, 967),
			new(1510, 1071),
			new(1562, 1058),
			new(961, 506),
			new(1162, 189),
			new(2337, 1159),
			new(2392, 1154),
			new(2517, 1066),
			new(2458, 1042),
			new(1658, 2030),
			new(2062, 1962),
			new(2089, 1987),
			new(2097, 1975),
			new(2066, 1979),
			new(2058, 1992),
			new(2071, 2007),
			new(2093, 2006),
			new(2187, 1991),
			new(1689, 1993),
			new(1709, 1964),
			new(1726, 1998),
			new(1731, 2016),
			new(1743, 2028),
			new(1754, 2020),
			new(2033, 1942),
			new(2054, 1962),
			new(581, 1455),
			new(358, 1337),
			new(208, 1444),
			new(199, 1461),
			new(348, 1565),
			new(620, 1706),
			new(1027, 1180),
			new(1037, 1975),
			new(1042, 1960),
			new(1042, 1903),
			new(1034, 1877),
			new(1018, 1859),
			new(980, 1849),
			new(962, 1858),
			new(977, 1879),
			new(968, 1884),
			new(969, 1893),
			new(974, 1992),
			new(989, 1992),
			new(1024, 1990),
			new(2648, 2167),
			new(2956, 2200),
			new(2968, 2170),
			new(2957, 2150),
			new(2951, 2177),
			new(2629, 2221),
			new(2642, 2289),
			new(2682, 2290),
			new(2727, 2309),
			new(2782, 2293),
			new(2804, 2255),
			new(2850, 2252),
			new(2932, 2240),
			new(3425, 2723),
			new(3476, 2761),
			new(3594, 2825),
			new(4419, 3117),
			new(4471, 3188),
			new(4507, 3227),
			new(4496, 3241),
			new(4642, 3369),
			new(4694, 3485),
			new(4448, 3130),
			new(4453, 3148),
			new(4500, 3108),
			new(4513, 3103),
			new(4424, 3152),
			new(4466, 3209),
			new(4477, 3230),
			new(4477, 3282),
			new(2797, 3452),
			new(2803, 3488),
			new(2793, 3519),
			new(2831, 3511),
			new(2989, 3606),
			new(3035, 3603),
			new(1427, 2405),
			new(1466, 2181),
			new(1519, 2214),
			new(1523, 2150),
			new(1541, 2115),
			new(1534, 2189),
			new(1546, 2221),
			new(1595, 2193),
			new(1619, 2236),
			new(1654, 2268),
			new(1655, 2304),
			new(1433, 2381),
			new(1724, 2288),
			new(1703, 2318),
			new(1772, 2321),
			new(1758, 2333),
			new(1765, 2430),
			new(1647, 2641),
			new(1562, 2705),
			new(1670, 2808),
			new(1471, 2340),
			new(1562, 2312),
			new(1450, 2301),
			new(1437, 2294),
			new(1478, 2273),
			new(1464, 2245),
			new(1439, 2217),
			new(1383, 2840),
			new(1388, 2984),
			new(1415, 3059),
			new(1602, 3012),
			new(1664, 3062),
			new(2062, 2144),
			new(2178, 2151),
			new(2104, 2123),
			new(2098, 2101),
			new(2123, 2120),
			new(2130, 2108),
			new(2129, 2132),
			new(2153, 2120),
			new(2162, 2148),
			new(2186, 2144),
			new(492, 2027),
			new(477, 2044),
			new(451, 2053),
			new(468, 2087),
			new(465, 2100),
			new(958, 2504),
			new(1025, 2702),
			new(1290, 2735),
			new(2013, 3269),
			new(2149, 3362),
			new(2097, 3384),
			new(2039, 3427),
			new(2516, 3999),
			new(2453, 3942),
			new(2528, 3982),
			new(2513, 3962),
			new(2512, 3918),
			new(2513, 3901),
			new(2480, 3908),
			new(2421, 3902),
			new(2415, 3920),
			new(2422, 3928),
			new(2370, 3428),
			new(2341, 3482),
			new(2360, 3507),
			new(2387, 3505),
			new(2152, 3950),
			new(2157, 3924),
			new(2140, 3940),
			new(2143, 3986),
			new(2154, 3983),
			new(2162, 3988),
			new(2467, 3581),
			new(2527, 3585),
			new(2482, 3624),
			new(2535, 3608),
			new(1090, 3110),
			new(1094, 3131),
			new(1073, 3133),
			new(1076, 3156),
			new(1068, 3182),
			new(1096, 3178),
			new(1129, 3403),
			new(1135, 3445),
			new(1162, 3469),
			new(1128, 3500),

			#endregion
		};

		public static Point2D[] HavenLocations { get; }

		private static readonly Type[][] m_SpawnTypes = new Type[][]
		{
			new Type[]{ typeof( HeadlessOne ), typeof( Skeleton ) },
			new Type[]{ typeof( Mongbat ), typeof( Ratman ), typeof( HeadlessOne ), typeof( Skeleton ), typeof( Zombie ) },
			new Type[]{ typeof( OrcishMage ), typeof( Gargoyle ), typeof( Gazer ), typeof( HellHound ), typeof( EarthElemental ) },
			new Type[]{ typeof( Lich ), typeof( OgreLord ), typeof( DreadSpider ), typeof( AirElemental ), typeof( FireElemental ) },
			new Type[]{ typeof( DreadSpider ), typeof( LichLord ), typeof( Daemon ), typeof( ElderGazer ), typeof( OgreLord ) },
			new Type[]{ typeof( LichLord ), typeof( Daemon ), typeof( ElderGazer ), typeof( PoisonElemental ), typeof( BloodElemental ) },
			new Type[]{ typeof( AncientWyrm ), typeof( Balron ), typeof( BloodElemental ), typeof( PoisonElemental ), typeof( Titan ) }
		};

		public const double LootChance = 0.01; // 1% chance to appear as loot

		static TreasureMap()
		{
			var havenList = new List<Point2D>();

			foreach (var loc in Locations)
			{
				if (IsInHavenIsland(loc))
				{
					havenList.Add(loc);
				}
			}

			HavenLocations = havenList.ToArray();

			havenList.Clear();
			havenList.TrimExcess();
		}

		public static Point2D GetRandomLocation()
		{
			return Utility.RandomList(Locations);
		}

		public static Point2D GetRandomHavenLocation()
		{
			return Utility.RandomList(HavenLocations);
		}

		public static bool IsInHavenIsland(IPoint2D loc)
		{
			return (loc.X >= 3314 && loc.X <= 3814 && loc.Y >= 2345 && loc.Y <= 3095);
		}

		public static BaseCreature Spawn(int level, Point3D p, bool guardian)
		{
			if (level >= 0 && level < m_SpawnTypes.Length)
			{
				BaseCreature bc;

				try
				{
					bc = (BaseCreature)Activator.CreateInstance(m_SpawnTypes[level][Utility.Random(m_SpawnTypes[level].Length)]);
				}
				catch
				{
					return null;
				}

				bc.Home = p;
				bc.RangeHome = 5;

				if (guardian && level == 0)
				{
					bc.Name = "a chest guardian";
					bc.Hue = 0x835;
				}

				return bc;
			}

			return null;
		}

		public static BaseCreature Spawn(int level, Point3D p, Map map, Mobile target, bool guardian)
		{
			if (map == null)
			{
				return null;
			}

			var c = Spawn(level, p, guardian);

			if (c != null)
			{
				var spawned = false;

				for (var i = 0; !spawned && i < 10; ++i)
				{
					var x = p.X - 3 + Utility.Random(7);
					var y = p.Y - 3 + Utility.Random(7);

					if (map.CanSpawnMobile(x, y, p.Z))
					{
						c.MoveToWorld(new Point3D(x, y, p.Z), map);
						spawned = true;
					}
					else
					{
						var z = map.GetAverageZ(x, y);

						if (map.CanSpawnMobile(x, y, z))
						{
							c.MoveToWorld(new Point3D(x, y, z), map);
							spawned = true;
						}
					}
				}

				if (!spawned)
				{
					c.Delete();
					return null;
				}

				if (target != null)
				{
					c.Combatant = target;
				}

				return c;
			}

			return null;
		}

		[Constructable]
		public TreasureMap(int level, Map map)
		{
			m_Level = level;
			m_Map = map;

			if (level == 0)
			{
				m_Location = GetRandomHavenLocation();
			}
			else
			{
				m_Location = GetRandomLocation();
			}

			Width = 300;
			Height = 300;

			var width = 600;
			var height = 600;

			var x1 = m_Location.X - Utility.RandomMinMax(width / 4, (width / 4) * 3);
			var y1 = m_Location.Y - Utility.RandomMinMax(height / 4, (height / 4) * 3);

			if (x1 < 0)
			{
				x1 = 0;
			}

			if (y1 < 0)
			{
				y1 = 0;
			}

			var x2 = x1 + width;
			var y2 = y1 + height;

			if (x2 >= 5120)
			{
				x2 = 5119;
			}

			if (y2 >= 4096)
			{
				y2 = 4095;
			}

			x1 = x2 - width;
			y1 = y2 - height;

			Bounds = new Rectangle2D(x1, y1, width, height);
			Protected = true;

			AddWorldPin(m_Location.X, m_Location.Y);
		}

		public TreasureMap(Serial serial) : base(serial)
		{
		}

		public static bool HasDiggingTool(Mobile m)
		{
			if (m.Backpack == null)
			{
				return false;
			}

			var items = m.Backpack.FindItemsByType<BaseHarvestTool>();

			foreach (var tool in items)
			{
				if (tool.HarvestSystem == Engines.Harvest.Mining.System)
				{
					return true;
				}
			}

			return false;
		}

		public void OnBeginDig(Mobile from)
		{
			if (m_Completed)
			{
				from.SendLocalizedMessage(503028); // The treasure for this map has already been found.
			}
			else if (m_Level == 0 && !CheckYoung(from))
			{
				from.SendLocalizedMessage(1046447); // Only a young player may use this treasure map.
			}
			/*
			else if ( from != m_Decoder )
			{
				from.SendLocalizedMessage( 503016 ); // Only the person who decoded this map may actually dig up the treasure.
			}
			*/
			else if (m_Decoder != from && !HasRequiredSkill(from))
			{
				from.SendLocalizedMessage(503031); // You did not decode this map and have no clue where to look for the treasure.
			}
			else if (!from.CanBeginAction(typeof(TreasureMap)))
			{
				from.SendLocalizedMessage(503020); // You are already digging treasure.
			}
			else if (from.Map != m_Map)
			{
				from.SendLocalizedMessage(1010479); // You seem to be in the right place, but may be on the wrong facet!
			}
			else
			{
				from.SendLocalizedMessage(503033); // Where do you wish to dig?
				from.Target = new DigTarget(this);
			}
		}

		private class DigTarget : Target
		{
			private readonly TreasureMap m_Map;

			public DigTarget(TreasureMap map) : base(6, true, TargetFlags.None)
			{
				m_Map = map;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Map.Deleted)
				{
					return;
				}

				var map = m_Map.m_Map;

				if (m_Map.m_Completed)
				{
					from.SendLocalizedMessage(503028); // The treasure for this map has already been found.
				}
				/*
				else if ( from != m_Map.m_Decoder )
				{
					from.SendLocalizedMessage( 503016 ); // Only the person who decoded this map may actually dig up the treasure.
				}
				*/
				else if (m_Map.m_Decoder != from && !m_Map.HasRequiredSkill(from))
				{
					from.SendLocalizedMessage(503031); // You did not decode this map and have no clue where to look for the treasure.
					return;
				}
				else if (!from.CanBeginAction(typeof(TreasureMap)))
				{
					from.SendLocalizedMessage(503020); // You are already digging treasure.
				}
				else if (!HasDiggingTool(from))
				{
					from.SendMessage("You must have a digging tool to dig for treasure.");
				}
				else if (from.Map != map)
				{
					from.SendLocalizedMessage(1010479); // You seem to be in the right place, but may be on the wrong facet!
				}
				else
				{
					var p = targeted as IPoint3D;

					Point3D targ3D;
					if (p is Item)
					{
						targ3D = ((Item)p).GetWorldLocation();
					}
					else
					{
						targ3D = new Point3D(p);
					}

					int maxRange;
					var skillValue = from.Skills[SkillName.Mining].Value;

					if (skillValue >= 100.0)
					{
						maxRange = 4;
					}
					else if (skillValue >= 81.0)
					{
						maxRange = 3;
					}
					else if (skillValue >= 51.0)
					{
						maxRange = 2;
					}
					else
					{
						maxRange = 1;
					}

					var loc = m_Map.m_Location;
					int x = loc.X, y = loc.Y;

					var chest3D0 = new Point3D(loc, 0);

					if (Utility.InRange(targ3D, chest3D0, maxRange))
					{
						if (from.Location.X == x && from.Location.Y == y)
						{
							from.SendLocalizedMessage(503030); // The chest can't be dug up because you are standing on top of it.
						}
						else if (map != null)
						{
							var z = map.GetAverageZ(x, y);

							if (!map.CanFit(x, y, z, 16, true, true))
							{
								from.SendLocalizedMessage(503021); // You have found the treasure chest but something is keeping it from being dug up.
							}
							else if (from.BeginAction(typeof(TreasureMap)))
							{
								new DigTimer(from, m_Map, new Point3D(x, y, z), map).Start();
							}
							else
							{
								from.SendLocalizedMessage(503020); // You are already digging treasure.
							}
						}
					}
					else if (m_Map.Level > 0)
					{
						if (Utility.InRange(targ3D, chest3D0, 8)) // We're close, but not quite
						{
							from.SendLocalizedMessage(503032); // You dig and dig but no treasure seems to be here.
						}
						else
						{
							from.SendLocalizedMessage(503035); // You dig and dig but fail to find any treasure.
						}
					}
					else
					{
						if (Utility.InRange(targ3D, chest3D0, 8)) // We're close, but not quite
						{
							from.SendAsciiMessage(0x44, "The treasure chest is very close!");
						}
						else
						{
							var dir = Utility.GetDirection(targ3D, chest3D0);

							string sDir;
							switch (dir)
							{
								case Direction.North: sDir = "north"; break;
								case Direction.Right: sDir = "northeast"; break;
								case Direction.East: sDir = "east"; break;
								case Direction.Down: sDir = "southeast"; break;
								case Direction.South: sDir = "south"; break;
								case Direction.Left: sDir = "southwest"; break;
								case Direction.West: sDir = "west"; break;
								default: sDir = "northwest"; break;
							}

							from.SendAsciiMessage(0x44, "Try looking for the treasure chest more to the {0}.", sDir);
						}
					}
				}
			}
		}

		private class DigTimer : Timer
		{
			private readonly Mobile m_From;
			private readonly TreasureMap m_TreasureMap;

			private Point3D m_Location;
			private readonly Map m_Map;

			private TreasureChestDirt m_Dirt1;
			private TreasureChestDirt m_Dirt2;
			private TreasureMapChest m_Chest;

			private int m_Count;

			private readonly long m_NextSkillTime;
			private readonly long m_NextSpellTime;
			private readonly long m_NextActionTime;
			private readonly long m_LastMoveTime;

			public DigTimer(Mobile from, TreasureMap treasureMap, Point3D location, Map map) : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.0))
			{
				m_From = from;
				m_TreasureMap = treasureMap;

				m_Location = location;
				m_Map = map;

				m_NextSkillTime = from.NextSkillTime;
				m_NextSpellTime = from.NextSpellTime;
				m_NextActionTime = from.NextActionTime;
				m_LastMoveTime = from.LastMoveTime;

				Priority = TimerPriority.TenMS;
			}

			private void Terminate()
			{
				Stop();
				m_From.EndAction(typeof(TreasureMap));

				if (m_Chest != null)
				{
					m_Chest.Delete();
				}

				if (m_Dirt1 != null)
				{
					m_Dirt1.Delete();
					m_Dirt2.Delete();
				}
			}

			protected override void OnTick()
			{
				if (m_NextSkillTime != m_From.NextSkillTime || m_NextSpellTime != m_From.NextSpellTime || m_NextActionTime != m_From.NextActionTime)
				{
					Terminate();
					return;
				}

				if (m_LastMoveTime != m_From.LastMoveTime)
				{
					m_From.SendLocalizedMessage(503023); // You cannot move around while digging up treasure. You will need to start digging anew.
					Terminate();
					return;
				}

				var z = (m_Chest != null) ? m_Chest.Z + m_Chest.ItemData.Height : Int32.MinValue;
				var height = 16;

				if (z > m_Location.Z)
				{
					height -= (z - m_Location.Z);
				}
				else
				{
					z = m_Location.Z;
				}

				if (!m_Map.CanFit(m_Location.X, m_Location.Y, z, height, true, true, false))
				{
					m_From.SendLocalizedMessage(503024); // You stop digging because something is directly on top of the treasure chest.
					Terminate();
					return;
				}

				m_Count++;

				m_From.RevealingAction();
				m_From.Direction = m_From.GetDirectionTo(m_Location);

				if (m_Count > 1 && m_Dirt1 == null)
				{
					m_Dirt1 = new TreasureChestDirt();
					m_Dirt1.MoveToWorld(m_Location, m_Map);

					m_Dirt2 = new TreasureChestDirt();
					m_Dirt2.MoveToWorld(new Point3D(m_Location.X, m_Location.Y - 1, m_Location.Z), m_Map);
				}

				if (m_Count == 5)
				{
					m_Dirt1.Turn1();
				}
				else if (m_Count == 10)
				{
					m_Dirt1.Turn2();
					m_Dirt2.Turn2();
				}
				else if (m_Count > 10)
				{
					if (m_Chest == null)
					{
						m_Chest = new TreasureMapChest(m_From, m_TreasureMap.Level, true);
						m_Chest.MoveToWorld(new Point3D(m_Location.X, m_Location.Y, m_Location.Z - 15), m_Map);
					}
					else
					{
						m_Chest.Z++;
					}

					Effects.PlaySound(m_Chest, m_Map, 0x33B);
				}

				if (m_Chest != null && m_Chest.Location.Z >= m_Location.Z)
				{
					Stop();
					m_From.EndAction(typeof(TreasureMap));

					m_Chest.Temporary = false;
					m_TreasureMap.Completed = true;
					m_TreasureMap.CompletedBy = m_From;

					int spawns;
					switch (m_TreasureMap.Level)
					{
						case 0: spawns = 3; break;
						case 1: spawns = 0; break;
						default: spawns = 4; break;
					}

					for (var i = 0; i < spawns; ++i)
					{
						var bc = Spawn(m_TreasureMap.Level, m_Chest.Location, m_Chest.Map, null, true);

						if (bc != null)
						{
							m_Chest.Guardians.Add(bc);
						}
					}
				}
				else
				{
					if (m_From.Body.IsHuman && !m_From.Mounted)
					{
						m_From.Animate(11, 5, 1, true, false, 0);
					}

					new SoundTimer(m_From, 0x125 + (m_Count % 2)).Start();
				}
			}

			private class SoundTimer : Timer
			{
				private readonly Mobile m_From;
				private readonly int m_SoundID;

				public SoundTimer(Mobile from, int soundID) : base(TimeSpan.FromSeconds(0.9))
				{
					m_From = from;
					m_SoundID = soundID;

					Priority = TimerPriority.TenMS;
				}

				protected override void OnTick()
				{
					m_From.PlaySound(m_SoundID);
				}
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!from.InRange(GetWorldLocation(), 2))
			{
				from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
				return;
			}

			if (!m_Completed && m_Decoder == null)
			{
				Decode(from);
			}
			else
			{
				DisplayTo(from);
			}
		}

		private bool CheckYoung(Mobile from)
		{
			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				return true;
			}

			if (from is PlayerMobile && ((PlayerMobile)from).Young)
			{
				return true;
			}

			if (from == Decoder)
			{
				Level = 1;
				from.SendLocalizedMessage(1046446); // This is now a level one treasure map.
				return true;
			}

			return false;
		}

		private double GetMinSkillLevel()
		{
			switch (m_Level)
			{
				case 1: return -3.0;
				case 2: return 41.0;
				case 3: return 51.0;
				case 4: return 61.0;
				case 5: return 70.0;
				case 6: return 70.0;

				default: return 0.0;
			}
		}

		private bool HasRequiredSkill(Mobile from)
		{
			return (from.Skills[SkillName.Cartography].Value >= GetMinSkillLevel());
		}

		public void Decode(Mobile from)
		{
			if (m_Completed || m_Decoder != null)
			{
				return;
			}

			if (m_Level == 0)
			{
				if (!CheckYoung(from))
				{
					from.SendLocalizedMessage(1046447); // Only a young player may use this treasure map.
					return;
				}
			}
			else
			{
				var minSkill = GetMinSkillLevel();

				if (from.Skills[SkillName.Cartography].Value < minSkill)
				{
					from.SendLocalizedMessage(503013); // The map is too difficult to attempt to decode.
				}

				var maxSkill = minSkill + 60.0;

				if (!from.CheckSkill(SkillName.Cartography, minSkill, maxSkill))
				{
					from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 503018); // You fail to make anything of the map.
					return;
				}
			}

			from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 503019); // You successfully decode a treasure map!
			Decoder = from;

			if (Core.AOS)
			{
				LootType = LootType.Blessed;
			}

			DisplayTo(from);
		}

		public override void DisplayTo(Mobile from)
		{
			if (m_Completed)
			{
				SendLocalizedMessageTo(from, 503014); // This treasure hunt has already been completed.
			}
			else if (m_Level == 0 && !CheckYoung(from))
			{
				from.SendLocalizedMessage(1046447); // Only a young player may use this treasure map.
				return;
			}
			else if (m_Decoder != from && !HasRequiredSkill(from))
			{
				from.SendLocalizedMessage(503031); // You did not decode this map and have no clue where to look for the treasure.
				return;
			}
			else
			{
				SendLocalizedMessageTo(from, 503017); // The treasure is marked by the red pin. Grab a shovel and go dig it up!
			}

			from.PlaySound(0x249);
			base.DisplayTo(from);
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (!m_Completed)
			{
				if (m_Decoder == null)
				{
					list.Add(new DecodeMapEntry(this));
				}
				else
				{
					var digTool = HasDiggingTool(from);

					list.Add(new OpenMapEntry(this));
					list.Add(new DigEntry(this, digTool));
				}
			}
		}

		private class DecodeMapEntry : ContextMenuEntry
		{
			private readonly TreasureMap m_Map;

			public DecodeMapEntry(TreasureMap map) : base(6147, 2)
			{
				m_Map = map;
			}

			public override void OnClick()
			{
				if (!m_Map.Deleted)
				{
					m_Map.Decode(Owner.From);
				}
			}
		}

		private class OpenMapEntry : ContextMenuEntry
		{
			private readonly TreasureMap m_Map;

			public OpenMapEntry(TreasureMap map) : base(6150, 2)
			{
				m_Map = map;
			}

			public override void OnClick()
			{
				if (!m_Map.Deleted)
				{
					m_Map.DisplayTo(Owner.From);
				}
			}
		}

		private class DigEntry : ContextMenuEntry
		{
			private readonly TreasureMap m_Map;

			public DigEntry(TreasureMap map, bool enabled) : base(6148, 2)
			{
				m_Map = map;

				if (!enabled)
				{
					Flags |= CMEFlags.Disabled;
				}
			}

			public override void OnClick()
			{
				if (m_Map.Deleted)
				{
					return;
				}

				var from = Owner.From;

				if (HasDiggingTool(from))
				{
					m_Map.OnBeginDig(from);
				}
				else
				{
					from.SendMessage("You must have a digging tool to dig for treasure.");
				}
			}
		}

		public override int LabelNumber
		{
			get
			{
				if (m_Decoder != null)
				{
					if (m_Level == 6)
					{
						return 1063453;
					}
					else
					{
						return 1041516 + m_Level;
					}
				}
				else if (m_Level == 6)
				{
					return 1063452;
				}
				else
				{
					return 1041510 + m_Level;
				}
			}
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add(m_Map == Map.Felucca ? 1041502 : 1041503); // for somewhere in Felucca : for somewhere in Trammel

			if (m_Completed)
			{
				list.Add(1041507, m_CompletedBy == null ? "someone" : m_CompletedBy.Name); // completed by ~1_val~
			}
		}

		public override void OnSingleClick(Mobile from)
		{
			if (m_Completed)
			{
				from.Send(new MessageLocalizedAffix(Serial, ItemID, MessageType.Label, 0x3B2, 3, 1048030, "", AffixType.Append, String.Format(" completed by {0}", m_CompletedBy == null ? "someone" : m_CompletedBy.Name), ""));
			}
			else if (m_Decoder != null)
			{
				if (m_Level == 6)
				{
					LabelTo(from, 1063453);
				}
				else
				{
					LabelTo(from, 1041516 + m_Level);
				}
			}
			else
			{
				if (m_Level == 6)
				{
					LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1063452, m_Map == Map.Felucca ? 1041502 : 1041503));
				}
				else
				{
					LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1041510 + m_Level, m_Map == Map.Felucca ? 1041502 : 1041503));
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1);

			writer.Write(m_CompletedBy);

			writer.Write(m_Level);
			writer.Write(m_Completed);
			writer.Write(m_Decoder);
			writer.Write(m_Map);
			writer.Write(m_Location);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_CompletedBy = reader.ReadMobile();

						goto case 0;
					}
				case 0:
					{
						m_Level = reader.ReadInt();
						m_Completed = reader.ReadBool();
						m_Decoder = reader.ReadMobile();
						m_Map = reader.ReadMap();
						m_Location = reader.ReadPoint2D();

						if (version == 0 && m_Completed)
						{
							m_CompletedBy = m_Decoder;
						}

						break;
					}
			}

			if (Core.AOS && m_Decoder != null && LootType == LootType.Regular)
			{
				LootType = LootType.Blessed;
			}
		}
	}

	public class TreasureChestDirt : Item
	{
		public TreasureChestDirt() : base(0x912)
		{
			Movable = false;

			Timer.DelayCall(TimeSpan.FromMinutes(2.0), Delete);
		}

		public TreasureChestDirt(Serial serial) : base(serial)
		{
		}

		public void Turn1()
		{
			ItemID = 0x913;
		}

		public void Turn2()
		{
			ItemID = 0x914;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadEncodedInt();

			Delete();
		}
	}
}