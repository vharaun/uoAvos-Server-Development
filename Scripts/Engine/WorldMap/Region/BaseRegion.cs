using Server.Gumps;
using Server.Items;
using Server.Mobiles;

using System;
using System.Collections.Generic;
using System.Xml;

namespace Server.Regions
{
	public enum SpawnZLevel
	{
		Lowest,
		Highest,
		Random
	}

	public class BaseRegion : Region
	{
		public virtual bool YoungProtected => true;
		public virtual bool YoungMayEnter => true;
		public virtual bool MountsAllowed => true;
		public virtual bool DeadMayEnter => true;
		public virtual bool ResurrectionAllowed => true;
		public virtual bool LogoutAllowed => true;

		public static void Configure()
		{
			Region.DefaultRegionType = typeof(BaseRegion);
		}

		private string m_RuneName;
		private bool m_NoLogoutDelay;

		private SpawnEntry[] m_Spawns;
		private SpawnZLevel m_SpawnZLevel;
		private bool m_ExcludeFromParentSpawns;

		public string RuneName { get => m_RuneName; set => m_RuneName = value; }

		public bool NoLogoutDelay { get => m_NoLogoutDelay; set => m_NoLogoutDelay = value; }

		public SpawnEntry[] Spawns
		{
			get => m_Spawns;
			set
			{
				if (m_Spawns != null)
				{
					for (var i = 0; i < m_Spawns.Length; i++)
					{
						m_Spawns[i].Delete();
					}
				}

				m_Spawns = value;
			}
		}

		public SpawnZLevel SpawnZLevel { get => m_SpawnZLevel; set => m_SpawnZLevel = value; }

		public bool ExcludeFromParentSpawns { get => m_ExcludeFromParentSpawns; set => m_ExcludeFromParentSpawns = value; }

		public override void OnUnregister()
		{
			base.OnUnregister();

			Spawns = null;
		}

		public static string GetRuneNameFor(Region region)
		{
			while (region != null)
			{
				var br = region as BaseRegion;

				if (br != null && br.m_RuneName != null)
				{
					return br.m_RuneName;
				}

				region = region.Parent;
			}

			return null;
		}

		public override TimeSpan GetLogoutDelay(Mobile m)
		{
			if (m_NoLogoutDelay)
			{
				if (m.Aggressors.Count == 0 && m.Aggressed.Count == 0 && !m.Criminal)
				{
					return TimeSpan.Zero;
				}
			}

			return base.GetLogoutDelay(m);
		}

		public static bool CanSpawn(Region region, params Type[] types)
		{
			while (region != null)
			{
				if (!region.AllowSpawn())
				{
					return false;
				}

				var br = region as BaseRegion;

				if (br != null)
				{
					if (br.Spawns != null)
					{
						for (var i = 0; i < br.Spawns.Length; i++)
						{
							var entry = br.Spawns[i];

							if (entry.Definition.CanSpawn(types))
							{
								return true;
							}
						}
					}

					if (br.ExcludeFromParentSpawns)
					{
						return false;
					}
				}

				region = region.Parent;
			}

			return false;
		}

		public override void OnEnter(Mobile m)
		{
			if (m is PlayerMobile && ((PlayerMobile)m).Young)
			{
				if (!YoungProtected)
				{
					m.SendGump(new YoungDungeonWarning());
				}
			}
		}

		public override bool AcceptsSpawnsFrom(Region region)
		{
			if (region == this || !m_ExcludeFromParentSpawns)
			{
				return base.AcceptsSpawnsFrom(region);
			}

			return false;
		}

		private Rectangle3D[] m_Rectangles;
		private int[] m_RectangleWeights;
		private int m_TotalWeight;

		private static readonly List<Rectangle3D> m_RectBuffer1 = new List<Rectangle3D>();
		private static readonly List<Rectangle3D> m_RectBuffer2 = new List<Rectangle3D>();

		private void InitRectangles()
		{
			if (m_Rectangles != null)
			{
				return;
			}

			// Test if area rectangles are overlapping, and in that case break them into smaller non overlapping rectangles
			for (var i = 0; i < Area.Length; i++)
			{
				m_RectBuffer2.Add(Area[i]);

				for (var j = 0; j < m_RectBuffer1.Count && m_RectBuffer2.Count > 0; j++)
				{
					var comp = m_RectBuffer1[j];

					for (var k = m_RectBuffer2.Count - 1; k >= 0; k--)
					{
						var rect = m_RectBuffer2[k];

						int l1 = rect.Start.X, r1 = rect.End.X, t1 = rect.Start.Y, b1 = rect.End.Y;
						int l2 = comp.Start.X, r2 = comp.End.X, t2 = comp.Start.Y, b2 = comp.End.Y;

						if (l1 < r2 && r1 > l2 && t1 < b2 && b1 > t2)
						{
							m_RectBuffer2.RemoveAt(k);

							var sz = rect.Start.Z;
							var ez = rect.End.X;

							if (l1 < l2)
							{
								m_RectBuffer2.Add(new Rectangle3D(new Point3D(l1, t1, sz), new Point3D(l2, b1, ez)));
							}

							if (r1 > r2)
							{
								m_RectBuffer2.Add(new Rectangle3D(new Point3D(r2, t1, sz), new Point3D(r1, b1, ez)));
							}

							if (t1 < t2)
							{
								m_RectBuffer2.Add(new Rectangle3D(new Point3D(Math.Max(l1, l2), t1, sz), new Point3D(Math.Min(r1, r2), t2, ez)));
							}

							if (b1 > b2)
							{
								m_RectBuffer2.Add(new Rectangle3D(new Point3D(Math.Max(l1, l2), b2, sz), new Point3D(Math.Min(r1, r2), b1, ez)));
							}
						}
					}
				}

				m_RectBuffer1.AddRange(m_RectBuffer2);
				m_RectBuffer2.Clear();
			}

			m_Rectangles = m_RectBuffer1.ToArray();
			m_RectBuffer1.Clear();

			m_RectangleWeights = new int[m_Rectangles.Length];
			for (var i = 0; i < m_Rectangles.Length; i++)
			{
				var rect = m_Rectangles[i];
				var weight = rect.Width * rect.Height;

				m_RectangleWeights[i] = weight;
				m_TotalWeight += weight;
			}
		}

		private static readonly List<int> m_SpawnBuffer1 = new List<int>();
		private static readonly List<Item> m_SpawnBuffer2 = new List<Item>();

		public Point3D RandomSpawnLocation(int spawnHeight, bool land, bool water, Point3D home, int range)
		{
			var map = Map;

			if (map == Map.Internal)
			{
				return Point3D.Zero;
			}

			InitRectangles();

			if (m_TotalWeight <= 0)
			{
				return Point3D.Zero;
			}

			for (var i = 0; i < 10; i++) // Try 10 times
			{
				int x, y, minZ, maxZ;

				if (home == Point3D.Zero)
				{
					var rand = Utility.Random(m_TotalWeight);

					x = Int32.MinValue; y = Int32.MinValue;
					minZ = Int32.MaxValue; maxZ = Int32.MinValue;
					for (var j = 0; j < m_RectangleWeights.Length; j++)
					{
						var curWeight = m_RectangleWeights[j];

						if (rand < curWeight)
						{
							var rect = m_Rectangles[j];

							x = rect.Start.X + rand % rect.Width;
							y = rect.Start.Y + rand / rect.Width;

							minZ = rect.Start.Z;
							maxZ = rect.End.Z;

							break;
						}

						rand -= curWeight;
					}
				}
				else
				{
					x = Utility.RandomMinMax(home.X - range, home.X + range);
					y = Utility.RandomMinMax(home.Y - range, home.Y + range);

					minZ = Int32.MaxValue; maxZ = Int32.MinValue;
					for (var j = 0; j < Area.Length; j++)
					{
						var rect = Area[j];

						if (x >= rect.Start.X && x < rect.End.X && y >= rect.Start.Y && y < rect.End.Y)
						{
							minZ = rect.Start.Z;
							maxZ = rect.End.Z;
							break;
						}
					}

					if (minZ == Int32.MaxValue)
					{
						continue;
					}
				}

				if (x < 0 || y < 0 || x >= map.Width || y >= map.Height)
				{
					continue;
				}

				var lt = map.Tiles.GetLandTile(x, y);

				int ltLowZ = 0, ltAvgZ = 0, ltTopZ = 0;
				map.GetAverageZ(x, y, ref ltLowZ, ref ltAvgZ, ref ltTopZ);

				var ltFlags = TileData.LandTable[lt.ID & TileData.MaxLandValue].Flags;
				var ltImpassable = ((ltFlags & TileFlag.Impassable) != 0);

				if (!lt.Ignored && ltAvgZ >= minZ && ltAvgZ < maxZ)
				{
					if ((ltFlags & TileFlag.Wet) != 0)
					{
						if (water)
						{
							m_SpawnBuffer1.Add(ltAvgZ);
						}
					}
					else if (land && !ltImpassable)
					{
						m_SpawnBuffer1.Add(ltAvgZ);
					}
				}

				var staticTiles = map.Tiles.GetStaticTiles(x, y, true);

				for (var j = 0; j < staticTiles.Length; j++)
				{
					var tile = staticTiles[j];
					var id = TileData.ItemTable[tile.ID & TileData.MaxItemValue];
					var tileZ = tile.Z + id.CalcHeight;

					if (tileZ >= minZ && tileZ < maxZ)
					{
						if ((id.Flags & TileFlag.Wet) != 0)
						{
							if (water)
							{
								m_SpawnBuffer1.Add(tileZ);
							}
						}
						else if (land && id.Surface && !id.Impassable)
						{
							m_SpawnBuffer1.Add(tileZ);
						}
					}
				}


				var sector = map.GetSector(x, y);

				for (var j = 0; j < sector.Items.Count; j++)
				{
					var item = sector.Items[j];

					if (!(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue && item.AtWorldPoint(x, y))
					{
						m_SpawnBuffer2.Add(item);

						if (!item.Movable)
						{
							var id = item.ItemData;
							var itemZ = item.Z + id.CalcHeight;

							if (itemZ >= minZ && itemZ < maxZ)
							{
								if ((id.Flags & TileFlag.Wet) != 0)
								{
									if (water)
									{
										m_SpawnBuffer1.Add(itemZ);
									}
								}
								else if (land && id.Surface && !id.Impassable)
								{
									m_SpawnBuffer1.Add(itemZ);
								}
							}
						}
					}
				}


				if (m_SpawnBuffer1.Count == 0)
				{
					m_SpawnBuffer1.Clear();
					m_SpawnBuffer2.Clear();
					continue;
				}

				int z;
				switch (m_SpawnZLevel)
				{
					case SpawnZLevel.Lowest:
						{
							z = Int32.MaxValue;

							for (var j = 0; j < m_SpawnBuffer1.Count; j++)
							{
								var l = m_SpawnBuffer1[j];

								if (l < z)
								{
									z = l;
								}
							}

							break;
						}
					case SpawnZLevel.Highest:
						{
							z = Int32.MinValue;

							for (var j = 0; j < m_SpawnBuffer1.Count; j++)
							{
								var l = m_SpawnBuffer1[j];

								if (l > z)
								{
									z = l;
								}
							}

							break;
						}
					default: // SpawnZLevel.Random
						{
							var index = Utility.Random(m_SpawnBuffer1.Count);
							z = m_SpawnBuffer1[index];

							break;
						}
				}

				m_SpawnBuffer1.Clear();


				if (!Region.Find(new Point3D(x, y, z), map).AcceptsSpawnsFrom(this))
				{
					m_SpawnBuffer2.Clear();
					continue;
				}

				var top = z + spawnHeight;

				var ok = true;
				for (var j = 0; j < m_SpawnBuffer2.Count; j++)
				{
					var item = m_SpawnBuffer2[j];
					var id = item.ItemData;

					if ((id.Surface || id.Impassable) && item.Z + id.CalcHeight > z && item.Z < top)
					{
						ok = false;
						break;
					}
				}

				m_SpawnBuffer2.Clear();

				if (!ok)
				{
					continue;
				}

				if (ltImpassable && ltAvgZ > z && ltLowZ < top)
				{
					continue;
				}

				for (var j = 0; j < staticTiles.Length; j++)
				{
					var tile = staticTiles[j];
					var id = TileData.ItemTable[tile.ID & TileData.MaxItemValue];

					if ((id.Surface || id.Impassable) && tile.Z + id.CalcHeight > z && tile.Z < top)
					{
						ok = false;
						break;
					}
				}

				if (!ok)
				{
					continue;
				}

				for (var j = 0; j < sector.Mobiles.Count; j++)
				{
					var m = sector.Mobiles[j];

					if (m.X == x && m.Y == y && (m.AccessLevel == AccessLevel.Player || !m.Hidden))
					{
						if (m.Z + 16 > z && m.Z < top)
						{
							ok = false;
							break;
						}
					}
				}

				if (ok)
				{
					return new Point3D(x, y, z);
				}
			}

			return Point3D.Zero;
		}

		public override string ToString()
		{
			if (Name != null)
			{
				return Name;
			}
			else if (RuneName != null)
			{
				return RuneName;
			}
			else
			{
				return GetType().Name;
			}
		}

		public BaseRegion(string name, Map map, int priority, params Rectangle2D[] area) : base(name, map, priority, area)
		{
		}

		public BaseRegion(string name, Map map, int priority, params Rectangle3D[] area) : base(name, map, priority, area)
		{
		}

		public BaseRegion(string name, Map map, Region parent, params Rectangle2D[] area) : base(name, map, parent, area)
		{
		}

		public BaseRegion(string name, Map map, Region parent, params Rectangle3D[] area) : base(name, map, parent, area)
		{
		}

		public BaseRegion(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}
	}
}