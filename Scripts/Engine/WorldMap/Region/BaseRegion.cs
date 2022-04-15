using Server.Commands;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Server.Regions
{
	public class RegionEditorGump : BaseGump
	{
		private static Timer m_PreviewTimer;

		public static void Initialize()
		{
			CommandSystem.Register("RegionEditor", AccessLevel.GameMaster, e =>
			{
				if (e.Mobile is PlayerMobile pm && !pm.HasGump(typeof(RegionEditorGump)))
				{
					BaseGump.SendGump(new RegionEditorGump(pm));
				}
			});

			CommandSystem.Register("RegionPreview", AccessLevel.GameMaster, e=>
			{
				if (m_PreviewTimer?.Running == true)
				{
					m_PreviewTimer.Stop();
					m_PreviewTimer = null;
					return;
				}

				m_PreviewTimer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(1), reg =>
				{
					foreach (var p in reg.Area)
					{
						for (var i = 0; i < p.Count; i++) 
						{
							Geometry.Line2D(new Point3D(p[i], 0), new Point3D(p[(i + 1) % p.Count], 0), reg.Map, (loc, map) =>
							{
								loc.Z = map.GetAverageZ(loc.X, loc.Y);

								Effects.SendLocationEffect(loc, map, 0x50D, 10, 1, 0x22, 0);
							});
						}
					}
				}, e.Mobile.Region);
			});
		}

		private static void Resize(ref int x, ref int y, ref int w, ref int h, int delta)
		{
			x += delta * -1;
			y += delta * -1;
			w += delta * +2;
			h += delta * +2;
		}

		private Poly3D[] m_LastArea;

		public Map Facet { get; private set; }
		public Region Region { get; private set; }

		private int m_Width = 800, m_Height = 600;

		private int m_NavPage, m_FacetPage, m_RegionPage;

		public RegionEditorGump(PlayerMobile user) : base(user)
		{
			Region = user.Region;
			Facet = user.Map;
		}

		private void Slice()
		{
			if (Region?.IsDefault == true)
			{
				Region = null;
			}

			if (Region?.Map != null && Region.Map != Facet)
			{
				Facet = Region.Map;

				m_FacetPage = 0;
			}
		}

		public override void AddGumpLayout()
		{
			Slice();

			var x = 0;
			var y = 0;
			var w = m_Width;
			var h = m_Height;

			var mx = x;
			var my = y;
			var mw = w / 4;
			var mh = h;

			AddMenuPanel(mx, my, mw, mh);

			var tx = mx + mw;
			var ty = y;
			var tw = w - mw;
			var th = 40;

			AddTitlePanel(tx, ty, tw, th);

			var cx = tx;
			var cy = ty + th;
			var cw = tw;
			var ch = h - th;

			AddContentPanel(cx, cy, cw, ch);
		}

		private void AddMenuPanel(int x, int y, int w, int h)
		{
			AddBackground(x, y, w, h, 2620);

			Resize(ref x, ref y, ref w, ref h, -10);

			var per = (h - 30) / 22;
			var pages = (int)Math.Ceiling(Map.AllMaps.Count / (double)per);

			m_NavPage = Math.Clamp(m_NavPage, 0, Math.Max(0, pages - 1));

			foreach (var map in Map.AllMaps.Skip(m_NavPage * per).Take(per))
			{
				var color = Color.White;

				if (map != Map.Internal)
				{
					color = map != Facet ? Color.White : Color.Yellow;
					
					AddButton(x, y, map != Facet ? 4005 : 4006, 4007, () => SelectFacet(map));
				}
				else
				{
					color = Color.Red;

					AddImage(x, y, 4005, 900);
				}

				AddHtml(x + 35, y, w - 35, 40, map.Name ?? $"Facet {map.MapIndex}", false, false, color);

				y += 22;
				h -= 22;
			}

			y += h - 30;
			h = 30;

			y += 8;
			h -= 8;

			if (pages > 1)
			{
				AddButton(x, y, 4015, 4016, () =>
				{
					if (--m_NavPage < 0)
					{
						m_NavPage = pages - 1;
					}

					Refresh();
				});
				AddTooltip(1011067);

				AddButton(x + (w - 30), y, 4006, 4007, () =>
				{
					if (++m_NavPage >= pages)
					{
						m_NavPage = 0;
					}

					Refresh();
				});
				AddTooltip(1011066);
			}
			else
			{
				AddImage(x, y, 4014, 900);
				AddImage(x + (w - 30), y, 4005, 900);
			}

			AddHtml(x + 30, y, w - 60, 20, Center($"{m_NavPage + 1:N0} / {Math.Max(1, pages):N0}"), false, false, Color.Yellow);
		}

		private void AddTitlePanel(int x, int y, int w, int h)
		{
			AddBackground(x, y, w, h, 2620);

			Resize(ref x, ref y, ref w, ref h, -10);

			if (Facet != null)
			{
				if (Region != null)
				{
					AddHtml(x, y, w, h, $"{Facet?.Name ?? "Unnamed Facet"} : {Region}", false, false, Color.White);
				}
				else
				{
					AddHtml(x, y, w, h, $"{Facet?.Name ?? "Unnamed Facet"}", false, false, Color.White);
				}
			}
		}

		private void AddContentPanel(int x, int y, int w, int h)
		{
			AddBackground(x, y, w, h, 2620);

			Resize(ref x, ref y, ref w, ref h, -10);

			if (Region == null)
			{
				var per = (h - 30) / 22;
				var pages = (int)Math.Ceiling(Facet.Regions.Count / (double)per);

				m_FacetPage = Math.Clamp(m_FacetPage, 0, Math.Max(0, pages - 1));

				foreach (var reg in Facet.Regions.Skip(m_FacetPage * per).Take(per))
				{
					AddButton(x, y, 208, 209, () => SelectRegion(reg));

					var name = reg.ToString();

					if (reg.ChildLevel > 0)
					{
						name = $"{new string('\u25B6', reg.ChildLevel)}{name}";
					}

					AddHtml(x + 25, y, w - 25, 40, name, false, false, Color.White);

					y += 22;
					h -= 22;
				}

				y += h - 30;
				h = 30;

				y += 8;
				h -= 8;

				if (pages > 1)
				{
					AddButton(x, y, 4015, 4016, () =>
					{
						if (--m_FacetPage < 0)
						{
							m_FacetPage = pages - 1;
						}

						Refresh();
					});
					AddTooltip(1011067);

					AddButton(x + (w - 30), y, 4006, 4007, () =>
					{
						if (++m_FacetPage >= pages)
						{
							m_FacetPage = 0;
						}

						Refresh();
					});
					AddTooltip(1011066);
				}
				else
				{
					AddImage(x, y, 4014, 900);
					AddImage(x + (w - 30), y, 4005, 900);
				}

				AddHtml(x + 30, y, w - 60, 20, Center($"{m_FacetPage + 1:N0} / {Math.Max(1, pages):N0}"), false, false, Color.Yellow);
			}
			else
			{
				var xo = x;
				var yo = y;
				var wo = w;

				var per = (h - 30) / 22;
				var pages = (int)Math.Ceiling(Region.Area.Length / (double)per);

				m_RegionPage = Math.Clamp(m_RegionPage, 0, Math.Max(0, pages - 1));

				foreach (var poly in Region.Area.Skip(m_RegionPage * per).Take(per))
				{
					AddButton(xo, yo, 4018, 4019, () => RemovePoly(poly));

					xo += 32;
					wo -= 32;

					if (poly.Count > 0)
					{
						AddButton(xo, yo, 4012, 4013, () => EditPoly(poly));
					}
					else
					{
						AddImage(xo, yo, 4011, 900);
					}

					xo += 32;
					wo -= 32;

					if (poly.Count > 0)
					{
						AddButton(xo, yo, 4009, 4010, () => VisualPoly(poly));
					}
					else
					{
						AddImage(xo, yo, 4008, 900);
					}

					xo += 32;
					wo -= 32;

					if (poly.Count > 0)
					{
						AddButton(xo, yo, 4006, 4007, () => VisitPoly(poly));
					}
					else
					{
						AddImage(xo, yo, 4005, 900);
					}

					xo += 32;
					wo -= 32;

					if (poly.Count > 0)
					{
						AddHtml(xo, yo + 2, wo, 20, $"{poly[0]}..[{poly.Count - 1}], {poly.MinZ}..{poly.MaxZ}", false, false, Color.White);
					}
					else
					{
						AddHtml(xo, yo + 2, wo, 20, $"Empty, {poly.MinZ}\u261E{poly.MaxZ}...[{poly.Depth}]", false, false, Color.Red);
					}

					xo = x;
					yo += 22;
					wo = w;
				}

				y += h - 30;
				h = 30;

				y += 8;
				h -= 8;

				if (pages > 1)
				{
					AddButton(x, y, 4015, 4016, () =>
					{
						if (--m_RegionPage < 0)
						{
							m_RegionPage = pages - 1;
						}

						Refresh();
					});
					AddTooltip(1011067);

					AddButton(x + (w - 30), y, 4006, 4007, () =>
					{
						if (++m_RegionPage >= pages)
						{
							m_RegionPage = 0;
						}

						Refresh();
					});
					AddTooltip(1011066);
				}
				else
				{
					AddImage(x, y, 4014, 900);
					AddImage(x + (w - 30), y, 4005, 900);
				}

				AddHtml(x + 30, y, w - 60, 20, Center($"{m_RegionPage + 1:N0} / {Math.Max(1, pages):N0}"), false, false, Color.Yellow);
			}
		}

		private void SelectFacet(Map map)
		{
			if (Facet != map)
			{
				m_LastArea = null;

				m_FacetPage = 0;
				m_RegionPage = 0;
			}

			Facet = map;
			Region = null;

			Refresh();
		}

		private void SelectRegion(Region reg)
		{
			if (Region != reg)
			{
				m_LastArea = null;

				m_RegionPage = 0;
			}
			
			Region = reg;

			Refresh();
		}

		private void RemovePoly(Poly3D poly)
		{
			var oldArea = m_LastArea = Region.Area;
			var newArea = new Poly3D[oldArea.Length - 1];

			for (int i = 0, n = 0; i < oldArea.Length; i++)
			{
				if (oldArea[i] != poly)
				{
					newArea[n++] = oldArea[i];
				}
			}

			Region.Area = newArea;

			Refresh();
		}

		private void EditPoly(Poly3D poly)
		{
			/*var oldArea = Region.Area;
			var newArea = new Poly3D[oldArea.Length - 1];

			for (int i = 0, n = 0; i < oldArea.Length; i++)
			{
				if (oldArea[i] != poly)
				{
					newArea[n++] = oldArea[i];
				}
			}

			Region.Area = newArea;*/

			Refresh();
		}

		private void VisualPoly(Poly3D poly)
		{
			Refresh();
		}

		private void VisitPoly(Poly3D poly)
		{
			if (poly.Count > 0)
			{
				var p = poly[0];
				var z = Facet.GetAverageZ(p.X, p.Y);

				User.MoveToWorld(new Point3D(p, z), Facet);
			}

			Refresh();
		}

		private void UndoAreaEdit()
		{
			Region.Area = m_LastArea;

			m_LastArea = null;

			Refresh();
		}
	}

	public enum SpawnZLevel
	{
		Lowest,
		Highest,
		Random
	}

	public class BaseRegion : Region
	{
		private static readonly List<Poly3D> m_RectBuffer1 = new();
		private static readonly List<Poly3D> m_RectBuffer2 = new();

		private static readonly List<int> m_SpawnBuffer1 = new();
		private static readonly List<Item> m_SpawnBuffer2 = new();

		public static void Configure()
		{
			DefaultRegionType = typeof(BaseRegion);
		}

		public static string GetRuneNameFor(Region region)
		{
			while (region != null)
			{
				if (region is BaseRegion br && br.RuneName != null)
				{
					return br.RuneName;
				}

				region = region.Parent;
			}

			return null;
		}

		public static bool CanSpawn(Region region, params Type[] types)
		{
			while (region != null)
			{
				if (!region.AllowSpawn())
				{
					return false;
				}

				if (region is BaseRegion br)
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

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public string RuneName { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool HousingAllowed { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool YoungProtected { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool YoungMayEnter { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool MountsAllowed { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool DeadMayEnter { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool ResurrectionAllowed { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool LogoutAllowed { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool NoLogoutDelay { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public bool ExcludeFromParentSpawns { get; set; }

		[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
		public SpawnZLevel SpawnZLevel { get; set; }

		private SpawnEntry[] m_Spawns;

		public SpawnEntry[] Spawns
		{
			get => m_Spawns;
			set
			{
				if (m_Spawns != null)
				{
					for (var i = 0; i < m_Spawns.Length; i++)
					{
						m_Spawns[i]?.Delete();
					}
				}

				m_Spawns = value;
			}
		}

		private Poly3D[] m_Areas;
		private int[] m_RectangleWeights;
		private int m_TotalWeight;

		public BaseRegion(string name, Map map, int priority, params Rectangle2D[] area) : base(name, map, priority, area)
		{
		}

		public BaseRegion(string name, Map map, int priority, params Poly2D[] area) : base(name, map, priority, area)
		{
		}

		public BaseRegion(string name, Map map, int priority, params Rectangle3D[] area) : base(name, map, priority, area)
		{
		}

		public BaseRegion(string name, Map map, int priority, params Poly3D[] area) : base(name, map, priority, area)
		{
		}

		public BaseRegion(string name, Map map, Region parent, params Rectangle2D[] area) : base(name, map, parent, area)
		{
		}

		public BaseRegion(string name, Map map, Region parent, params Poly2D[] area) : base(name, map, parent, area)
		{
		}

		public BaseRegion(string name, Map map, Region parent, params Rectangle3D[] area) : base(name, map, parent, area)
		{
		}

		public BaseRegion(string name, Map map, Region parent, params Poly3D[] area) : base(name, map, parent, area)
		{
		}

		public BaseRegion(RegionDefinition def, Map map, Region parent) : base(def, map, parent)
		{
		}

		public BaseRegion(int id) : base(id)
		{ 
		}

		protected override void DefaultInit()
		{
			base.DefaultInit();

			HousingAllowed = true;
			YoungProtected = true;
			YoungMayEnter = true;
			MountsAllowed = true;
			DeadMayEnter = true;
			ResurrectionAllowed = true;
			LogoutAllowed = true;
			NoLogoutDelay = false;
			ExcludeFromParentSpawns = true;

			SpawnZLevel = SpawnZLevel.Lowest;
		}

		public override TimeSpan GetLogoutDelay(Mobile m)
		{
			if (NoLogoutDelay && m.Aggressors.Count == 0 && m.Aggressed.Count == 0 && !m.Criminal)
			{
				return TimeSpan.Zero;
			}

			return base.GetLogoutDelay(m);
		}

		public override void OnEnter(Mobile m)
		{
			base.OnEnter(m);

			if (m is PlayerMobile pm && pm.Young && !YoungProtected)
			{
				pm.SendGump(new YoungDungeonWarning());
			}
		}

		public override bool AcceptsSpawnsFrom(Region region)
		{
			if (region == this || !ExcludeFromParentSpawns)
			{
				return base.AcceptsSpawnsFrom(region);
			}

			return false;
		}

		public override bool AllowHousing(Mobile from, Point3D p)
		{
			return HousingAllowed && base.AllowHousing(from, p);
		}

		private void InitArea()
		{
			if (m_Areas != null)
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

						int l1 = rect.Bounds.Start.X, r1 = rect.Bounds.End.X, t1 = rect.Bounds.Start.Y, b1 = rect.Bounds.End.Y;
						int l2 = comp.Bounds.Start.X, r2 = comp.Bounds.End.X, t2 = comp.Bounds.Start.Y, b2 = comp.Bounds.End.Y;

						if (l1 < r2 && r1 > l2 && t1 < b2 && b1 > t2)
						{
							m_RectBuffer2.RemoveAt(k);

							var sz = rect.MinZ;
							var ez = rect.MaxZ;

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

			m_Areas = m_RectBuffer1.ToArray();
			m_RectBuffer1.Clear();

			m_RectangleWeights = new int[m_Areas.Length];

			for (var i = 0; i < m_Areas.Length; i++)
			{
				var rect = m_Areas[i];
				var weight = rect.Bounds.Width * rect.Bounds.Height;

				m_RectangleWeights[i] = weight;
				m_TotalWeight += weight;
			}
		}

		public Point3D RandomSpawnLocation(int spawnHeight, bool land, bool water, Point3D home, int range)
		{
			var map = Map;

			if (map == Map.Internal)
			{
				return Point3D.Zero;
			}

			InitArea();

			if (m_TotalWeight <= 0)
			{
				return Point3D.Zero;
			}

			for (var i = 0; i < 100; i++)
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
							var poly = m_Areas[j];
							var rect = poly.Bounds;

							x = rect.Start.X + rand % rect.Width;
							y = rect.Start.Y + rand / rect.Width;

							if (poly.Contains(x, y))
							{
								minZ = poly.MinZ;
								maxZ = poly.MaxZ;
								break;
							}
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
						var poly = Area[j];

						if (poly.Contains(x, y))
						{
							minZ = poly.MinZ;
							maxZ = poly.MaxZ;
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
				switch (SpawnZLevel)
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

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);

			writer.Write(RuneName);

			writer.Write(HousingAllowed);
			writer.Write(YoungProtected);
			writer.Write(YoungMayEnter);
			writer.Write(MountsAllowed);
			writer.Write(DeadMayEnter);
			writer.Write(ResurrectionAllowed);
			writer.Write(LogoutAllowed);
			writer.Write(NoLogoutDelay);
			writer.Write(ExcludeFromParentSpawns);

			writer.Write(SpawnZLevel);

			if (m_Spawns != null)
			{
				writer.Write(m_Spawns.Length);

				foreach (var se in m_Spawns)
				{
					writer.Write(se.ID);
				}
			}
			else
			{
				writer.Write(0);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
			
			RuneName = reader.ReadString();

			HousingAllowed = reader.ReadBool();
			YoungProtected = reader.ReadBool();
			YoungMayEnter = reader.ReadBool();
			MountsAllowed = reader.ReadBool();
			DeadMayEnter = reader.ReadBool();
			ResurrectionAllowed = reader.ReadBool();
			LogoutAllowed = reader.ReadBool();
			NoLogoutDelay = reader.ReadBool();
			ExcludeFromParentSpawns = reader.ReadBool();

			SpawnZLevel = reader.ReadEnum<SpawnZLevel>();

			var count = reader.ReadInt();

			if (count > 0)
			{
				var spawns = new List<SpawnEntry>(count);

				while (--count >= 0)
				{
					var index = reader.ReadInt();

					if (SpawnEntry.Table[index] is SpawnEntry e)
					{
						spawns.Add(e);
					}
				}

				if (spawns.Count > 0)
				{
					m_Spawns = spawns.ToArray();

					spawns.Clear();
				}
				
				spawns.TrimExcess();
			}
		}
	}
}