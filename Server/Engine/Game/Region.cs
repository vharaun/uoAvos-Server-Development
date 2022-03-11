using Server.Items;
using Server.Network;
using Server.Targeting;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Server
{
	public enum MusicName
	{
		Invalid = -1,
		OldUlt01 = 0,
		Create1,
		DragFlit,
		OldUlt02,
		OldUlt03,
		OldUlt04,
		OldUlt05,
		OldUlt06,
		Stones2,
		Britain1,
		Britain2,
		Bucsden,
		Jhelom,
		LBCastle,
		Linelle,
		Magincia,
		Minoc,
		Ocllo,
		Samlethe,
		Serpents,
		Skarabra,
		Trinsic,
		Vesper,
		Wind,
		Yew,
		Cave01,
		Dungeon9,
		Forest_a,
		InTown01,
		Jungle_a,
		Mountn_a,
		Plains_a,
		Sailing,
		Swamp_a,
		Tavern01,
		Tavern02,
		Tavern03,
		Tavern04,
		Combat1,
		Combat2,
		Combat3,
		Approach,
		Death,
		Victory,
		BTCastle,
		Nujelm,
		Dungeon2,
		Cove,
		Moonglow,
		Zento,
		TokunoDungeon,
		Taiko,
		DreadHornArea,
		ElfCity,
		GrizzleDungeon,
		MelisandesLair,
		ParoxysmusLair,
		GwennoConversation,
		GoodEndGame,
		GoodVsEvil,
		GreatEarthSerpents,
		Humanoids_U9,
		MinocNegative,
		Paws,
		SelimsBar,
		SerpentIsleCombat_U7,
		ValoriaShips,
		TheWanderer,
		Castle,
		Festival,
		Honor,
		Medieval,
		BattleOnStones,
		Docktown,
		GargoyleQueen,
		GenericCombat,
		Holycity,
		HumanLevel,
		LoginLoop,
		NorthernForestBattleonStones,
		PrimevalLich,
		QueenPalace,
		RoyalCity,
		SlasherVeil,
		StygianAbyss,
		StygianDragon,
		Void,
		CodexShrine,
		AnvilStrikeInMinoc,
		ASkaranLullaby,
		BlackthornsMarch,
		DupresNightInTrinsic,
		FayaxionAndTheSix,
		FlightOfTheNexus,
		GalehavenJaunt,
		JhelomToArms,
		MidnightInYew,
		MoonglowSonata,
		NewMaginciaMarch,
		NujelmWaltz,
		SherrysSong,
		StarlightInBritain,
		TheVesperMist
	}

	public partial class Region : IComparable
	{
		private static readonly List<Region> m_Regions = new List<Region>();

		public static List<Region> Regions => m_Regions;

		public static Region Find(Point3D p, Map map)
		{
			if (map == null)
			{
				return Map.Internal.DefaultRegion;
			}

			var sector = map.GetSector(p);
			var list = sector.RegionRects;

			for (var i = 0; i < list.Count; ++i)
			{
				var regRect = list[i];

				if (regRect.Contains(p))
				{
					return regRect.Region;
				}
			}

			return map.DefaultRegion;
		}

		private static Type m_DefaultRegionType = typeof(Region);
		public static Type DefaultRegionType { get => m_DefaultRegionType; set => m_DefaultRegionType = value; }

		private static TimeSpan m_StaffLogoutDelay = TimeSpan.Zero;
		private static TimeSpan m_DefaultLogoutDelay = TimeSpan.FromMinutes(5.0);

		public static TimeSpan StaffLogoutDelay { get => m_StaffLogoutDelay; set => m_StaffLogoutDelay = value; }
		public static TimeSpan DefaultLogoutDelay { get => m_DefaultLogoutDelay; set => m_DefaultLogoutDelay = value; }

		public static readonly int DefaultPriority = 50;

		public static readonly int MinZ = SByte.MinValue;
		public static readonly int MaxZ = SByte.MaxValue + 1;

		public static Rectangle3D ConvertTo3D(Rectangle2D rect)
		{
			return new Rectangle3D(new Point3D(rect.Start, MinZ), new Point3D(rect.End, MaxZ));
		}

		public static Rectangle3D[] ConvertTo3D(Rectangle2D[] rects)
		{
			var ret = new Rectangle3D[rects.Length];

			for (var i = 0; i < ret.Length; i++)
			{
				ret[i] = ConvertTo3D(rects[i]);
			}

			return ret;
		}

		private readonly string m_Name;
		private readonly Map m_Map;
		private readonly Region m_Parent;
		private readonly List<Region> m_Children = new List<Region>();
		private readonly Rectangle3D[] m_Area;
		private Sector[] m_Sectors;
		private readonly bool m_Dynamic;
		private readonly int m_Priority;
		private readonly int m_ChildLevel;
		private bool m_Registered;

		private Point3D m_GoLocation;
		private MusicName m_Music;

		public string Name => m_Name;
		public Map Map => m_Map;
		public Region Parent => m_Parent;
		public List<Region> Children => m_Children;
		public Rectangle3D[] Area => m_Area;
		public Sector[] Sectors => m_Sectors;
		public bool Dynamic => m_Dynamic;
		public int Priority => m_Priority;
		public int ChildLevel => m_ChildLevel;
		public bool Registered => m_Registered;

		public Point3D GoLocation { get => m_GoLocation; set => m_GoLocation = value; }
		public MusicName Music { get => m_Music; set => m_Music = value; }

		public bool IsDefault => m_Map.DefaultRegion == this;
		public virtual MusicName DefaultMusic => m_Parent != null ? m_Parent.Music : MusicName.Invalid;

		public Region(string name, Map map, int priority, params Rectangle2D[] area) : this(name, map, priority, ConvertTo3D(area))
		{
		}

		public Region(string name, Map map, int priority, params Rectangle3D[] area) : this(name, map, null, area)
		{
			m_Priority = priority;
		}

		public Region(string name, Map map, Region parent, params Rectangle2D[] area) : this(name, map, parent, ConvertTo3D(area))
		{
		}

		public Region(string name, Map map, Region parent, params Rectangle3D[] area)
		{
			m_Name = name;
			m_Map = map;
			m_Parent = parent;
			m_Area = area;
			m_Dynamic = true;
			m_Music = DefaultMusic;

			if (m_Parent == null)
			{
				m_ChildLevel = 0;
				m_Priority = DefaultPriority;
			}
			else
			{
				m_ChildLevel = m_Parent.ChildLevel + 1;
				m_Priority = m_Parent.Priority;
			}
		}

		public void Register()
		{
			if (m_Registered)
			{
				return;
			}

			OnRegister();

			m_Registered = true;

			if (m_Parent != null)
			{
				m_Parent.m_Children.Add(this);
				m_Parent.OnChildAdded(this);
			}

			m_Regions.Add(this);

			m_Map.RegisterRegion(this);

			var sectors = new List<Sector>();

			for (var i = 0; i < m_Area.Length; i++)
			{
				var rect = m_Area[i];

				var start = m_Map.Bound(new Point2D(rect.Start));
				var end = m_Map.Bound(new Point2D(rect.End));

				var startSector = m_Map.GetSector(start);
				var endSector = m_Map.GetSector(end);

				for (var x = startSector.X; x <= endSector.X; x++)
				{
					for (var y = startSector.Y; y <= endSector.Y; y++)
					{
						var sector = m_Map.GetRealSector(x, y);

						sector.OnEnter(this, rect);

						if (!sectors.Contains(sector))
						{
							sectors.Add(sector);
						}
					}
				}
			}

			m_Sectors = sectors.ToArray();
		}

		public void Unregister()
		{
			if (!m_Registered)
			{
				return;
			}

			OnUnregister();

			m_Registered = false;

			if (m_Children.Count > 0)
			{
				Console.WriteLine("Warning: Unregistering region '{0}' with children", this);
			}

			if (m_Parent != null)
			{
				m_Parent.m_Children.Remove(this);
				m_Parent.OnChildRemoved(this);
			}

			m_Regions.Remove(this);

			m_Map.UnregisterRegion(this);

			if (m_Sectors != null)
			{
				for (var i = 0; i < m_Sectors.Length; i++)
				{
					m_Sectors[i].OnLeave(this);
				}
			}

			m_Sectors = null;
		}

		public bool Contains(Point3D p)
		{
			for (var i = 0; i < m_Area.Length; i++)
			{
				var rect = m_Area[i];

				if (rect.Contains(p))
				{
					return true;
				}
			}

			return false;
		}

		public bool IsChildOf(Region region)
		{
			if (region == null)
			{
				return false;
			}

			var p = m_Parent;

			while (p != null)
			{
				if (p == region)
				{
					return true;
				}

				p = p.m_Parent;
			}

			return false;
		}

		public Region GetRegion(Type regionType)
		{
			if (regionType == null)
			{
				return null;
			}

			var r = this;

			do
			{
				if (regionType.IsAssignableFrom(r.GetType()))
				{
					return r;
				}

				r = r.m_Parent;
			}
			while (r != null);

			return null;
		}

		public Region GetRegion(string regionName)
		{
			if (regionName == null)
			{
				return null;
			}

			var r = this;

			do
			{
				if (r.m_Name == regionName)
				{
					return r;
				}

				r = r.m_Parent;
			}
			while (r != null);

			return null;
		}

		public bool IsPartOf(Region region)
		{
			if (this == region)
			{
				return true;
			}

			return IsChildOf(region);
		}

		public bool IsPartOf(Type regionType)
		{
			return (GetRegion(regionType) != null);
		}

		public bool IsPartOf(string regionName)
		{
			return (GetRegion(regionName) != null);
		}

		public virtual bool AcceptsSpawnsFrom(Region region)
		{
			if (!AllowSpawn())
			{
				return false;
			}

			if (region == this)
			{
				return true;
			}

			if (m_Parent != null)
			{
				return m_Parent.AcceptsSpawnsFrom(region);
			}

			return false;
		}

		public List<Mobile> GetPlayers()
		{
			var list = new List<Mobile>();

			if (m_Sectors != null)
			{
				for (var i = 0; i < m_Sectors.Length; i++)
				{
					var sector = m_Sectors[i];

					foreach (var player in sector.Players)
					{
						if (player.Region.IsPartOf(this))
						{
							list.Add(player);
						}
					}
				}
			}

			return list;
		}

		public int GetPlayerCount()
		{
			var count = 0;

			if (m_Sectors != null)
			{
				for (var i = 0; i < m_Sectors.Length; i++)
				{
					var sector = m_Sectors[i];

					foreach (var player in sector.Players)
					{
						if (player.Region.IsPartOf(this))
						{
							count++;
						}
					}
				}
			}

			return count;
		}

		public List<Mobile> GetMobiles()
		{
			var list = new List<Mobile>();

			if (m_Sectors != null)
			{
				for (var i = 0; i < m_Sectors.Length; i++)
				{
					var sector = m_Sectors[i];

					foreach (var mobile in sector.Mobiles)
					{
						if (mobile.Region.IsPartOf(this))
						{
							list.Add(mobile);
						}
					}
				}
			}

			return list;
		}

		public int GetMobileCount()
		{
			var count = 0;

			if (m_Sectors != null)
			{
				for (var i = 0; i < m_Sectors.Length; i++)
				{
					var sector = m_Sectors[i];

					foreach (var mobile in sector.Mobiles)
					{
						if (mobile.Region.IsPartOf(this))
						{
							count++;
						}
					}
				}
			}

			return count;
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}

			var reg = obj as Region;

			if (reg == null)
			{
				throw new ArgumentException("obj is not a Region", "obj");
			}

			// Dynamic regions go first
			if (Dynamic)
			{
				if (!reg.Dynamic)
				{
					return -1;
				}
			}
			else if (reg.Dynamic)
			{
				return 1;
			}

			var thisPriority = Priority;
			var regPriority = reg.Priority;

			if (thisPriority != regPriority)
			{
				return (regPriority - thisPriority);
			}

			return (reg.ChildLevel - ChildLevel);
		}

		public override string ToString()
		{
			if (m_Name != null)
			{
				return m_Name;
			}
			else
			{
				return GetType().Name;
			}
		}


		public virtual void OnRegister()
		{
		}

		public virtual void OnUnregister()
		{
		}

		public virtual void OnChildAdded(Region child)
		{
		}

		public virtual void OnChildRemoved(Region child)
		{
		}

		public virtual bool OnMoveInto(Mobile m, Direction d, Point3D newLocation, Point3D oldLocation)
		{
			return (m.WalkRegion == null || AcceptsSpawnsFrom(m.WalkRegion));
		}

		public virtual void OnEnter(Mobile m)
		{
		}

		public virtual void OnExit(Mobile m)
		{
		}

		public virtual void MakeGuard(Mobile focus)
		{
			if (m_Parent != null)
			{
				m_Parent.MakeGuard(focus);
			}
		}

		public virtual Type GetResource(Type type)
		{
			if (m_Parent != null)
			{
				return m_Parent.GetResource(type);
			}

			return type;
		}

		public virtual bool CanUseStuckMenu(Mobile m)
		{
			if (m_Parent != null)
			{
				return m_Parent.CanUseStuckMenu(m);
			}

			return true;
		}

		public virtual void OnAggressed(Mobile aggressor, Mobile aggressed, bool criminal)
		{
			if (m_Parent != null)
			{
				m_Parent.OnAggressed(aggressor, aggressed, criminal);
			}
		}

		public virtual void OnDidHarmful(Mobile harmer, Mobile harmed)
		{
			if (m_Parent != null)
			{
				m_Parent.OnDidHarmful(harmer, harmed);
			}
		}

		public virtual void OnGotHarmful(Mobile harmer, Mobile harmed)
		{
			if (m_Parent != null)
			{
				m_Parent.OnGotHarmful(harmer, harmed);
			}
		}

		public virtual void OnLocationChanged(Mobile m, Point3D oldLocation)
		{
			if (m_Parent != null)
			{
				m_Parent.OnLocationChanged(m, oldLocation);
			}
		}

		public virtual bool OnTarget(Mobile m, Target t, object o)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnTarget(m, t, o);
			}

			return true;
		}

		public virtual bool OnCombatantChange(Mobile m, Mobile Old, Mobile New)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnCombatantChange(m, Old, New);
			}

			return true;
		}

		public virtual bool AllowHousing(Mobile from, Point3D p)
		{
			if (m_Parent != null)
			{
				return m_Parent.AllowHousing(from, p);
			}

			return true;
		}

		public virtual bool SendInaccessibleMessage(Item item, Mobile from)
		{
			if (m_Parent != null)
			{
				return m_Parent.SendInaccessibleMessage(item, from);
			}

			return false;
		}

		public virtual bool CheckAccessibility(Item item, Mobile from)
		{
			if (m_Parent != null)
			{
				return m_Parent.CheckAccessibility(item, from);
			}

			return true;
		}

		public virtual bool OnDecay(Item item)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnDecay(item);
			}

			return true;
		}

		public virtual bool AllowHarmful(Mobile from, Mobile target)
		{
			if (m_Parent != null)
			{
				return m_Parent.AllowHarmful(from, target);
			}

			if (Mobile.AllowHarmfulHandler != null)
			{
				return Mobile.AllowHarmfulHandler(from, target);
			}

			return true;
		}

		public virtual void OnCriminalAction(Mobile m, bool message)
		{
			if (m_Parent != null)
			{
				m_Parent.OnCriminalAction(m, message);
			}
			else if (message)
			{
				m.SendLocalizedMessage(1005040); // You've committed a criminal act!!
			}
		}

		public virtual bool AllowBeneficial(Mobile from, Mobile target)
		{
			if (m_Parent != null)
			{
				return m_Parent.AllowBeneficial(from, target);
			}

			if (Mobile.AllowBeneficialHandler != null)
			{
				return Mobile.AllowBeneficialHandler(from, target);
			}

			return true;
		}

		public virtual void OnBeneficialAction(Mobile helper, Mobile target)
		{
			if (m_Parent != null)
			{
				m_Parent.OnBeneficialAction(helper, target);
			}
		}

		public virtual void OnGotBeneficialAction(Mobile helper, Mobile target)
		{
			if (m_Parent != null)
			{
				m_Parent.OnGotBeneficialAction(helper, target);
			}
		}

		public virtual void SpellDamageScalar(Mobile caster, Mobile target, ref double damage)
		{
			if (m_Parent != null)
			{
				m_Parent.SpellDamageScalar(caster, target, ref damage);
			}
		}

		public virtual void OnSpeech(SpeechEventArgs args)
		{
			if (m_Parent != null)
			{
				m_Parent.OnSpeech(args);
			}
		}

		public virtual bool OnSkillUse(Mobile m, int Skill)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnSkillUse(m, Skill);
			}

			return true;
		}

		public virtual bool OnBeginSpellCast(Mobile m, ISpell s)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnBeginSpellCast(m, s);
			}

			return true;
		}

		public virtual void OnSpellCast(Mobile m, ISpell s)
		{
			if (m_Parent != null)
			{
				m_Parent.OnSpellCast(m, s);
			}
		}

		public virtual bool OnResurrect(Mobile m)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnResurrect(m);
			}

			return true;
		}

		public virtual bool OnBeforeDeath(Mobile m)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnBeforeDeath(m);
			}

			return true;
		}

		public virtual void OnDeath(Mobile m)
		{
			if (m_Parent != null)
			{
				m_Parent.OnDeath(m);
			}
		}

		public virtual bool OnDamage(Mobile m, ref int Damage)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnDamage(m, ref Damage);
			}

			return true;
		}

		public virtual bool OnHeal(Mobile m, ref int Heal)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnHeal(m, ref Heal);
			}

			return true;
		}

		public virtual bool OnDoubleClick(Mobile m, object o)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnDoubleClick(m, o);
			}

			return true;
		}

		public virtual bool OnSingleClick(Mobile m, object o)
		{
			if (m_Parent != null)
			{
				return m_Parent.OnSingleClick(m, o);
			}

			return true;
		}

		public virtual bool AllowSpawn()
		{
			if (m_Parent != null)
			{
				return m_Parent.AllowSpawn();
			}

			return true;
		}

		public virtual void AlterLightLevel(Mobile m, ref int global, ref int personal)
		{
			if (m_Parent != null)
			{
				m_Parent.AlterLightLevel(m, ref global, ref personal);
			}
		}

		public virtual TimeSpan GetLogoutDelay(Mobile m)
		{
			if (m_Parent != null)
			{
				return m_Parent.GetLogoutDelay(m);
			}
			else if (m.AccessLevel > AccessLevel.Player)
			{
				return m_StaffLogoutDelay;
			}
			else
			{
				return m_DefaultLogoutDelay;
			}
		}


		internal static bool CanMove(Mobile m, Direction d, Point3D newLocation, Point3D oldLocation, Map map)
		{
			var oldRegion = m.Region;
			var newRegion = Find(newLocation, map);

			while (oldRegion != newRegion)
			{
				if (!newRegion.OnMoveInto(m, d, newLocation, oldLocation))
				{
					return false;
				}

				if (newRegion.m_Parent == null)
				{
					return true;
				}

				newRegion = newRegion.m_Parent;
			}

			return true;
		}

		internal static void OnRegionChange(Mobile m, Region oldRegion, Region newRegion)
		{
			if (newRegion != null && m.NetState != null)
			{
				m.CheckLightLevels(false);

				if (oldRegion == null || oldRegion.Music != newRegion.Music)
				{
					m.Send(PlayMusic.GetInstance(newRegion.Music));
				}
			}

			var oldR = oldRegion;
			var newR = newRegion;

			while (oldR != newR)
			{
				var oldRChild = (oldR != null ? oldR.ChildLevel : -1);
				var newRChild = (newR != null ? newR.ChildLevel : -1);

				if (oldRChild >= newRChild)
				{
					oldR.OnExit(m);
					oldR = oldR.Parent;
				}

				if (newRChild >= oldRChild)
				{
					newR.OnEnter(m);
					newR = newR.Parent;
				}
			}
		}

		internal static void Load()
		{
			Console.Write("Regions: Loading...");

			var count = 0;

			foreach (var entry in m_Definitions)
			{
				var map = Map.Parse(entry.Key);

				if (map == Map.Internal)
				{
					Console.WriteLine("Invalid internal map in a facet element");
				}
				else
				{
					count += LoadRegions(entry.Value, map, null);
				}
			}

			Console.WriteLine("done ({0:N0} regions)", count);
		}

		private static int LoadRegions(HashSet<RegionDefinition> defs, Map map, Region parent)
		{
			var count = 0;

			foreach (var def in defs)
			{
				var type = def.Type ?? DefaultRegionType;

				if (!typeof(Region).IsAssignableFrom(type))
				{
					Console.WriteLine("Invalid region type '{0}'", type.FullName);
					continue;
				}

				Region region;

				try
				{
					region = (Region)Activator.CreateInstance(type, def, map, parent);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error during the creation of region type '{0}':", type.FullName);
					Console.WriteLine(ex);
					continue;
				}

				region.Register();

				//Console.WriteLine($"Region '{region.Name}' registered.");

				count += LoadRegions(def.Children, map, region);
			}

			return count;
		}

		public Region(RegionDefinition def, Map map, Region parent)
		{
			m_Map = map;
			m_Parent = parent;
			m_Dynamic = false;

			if (m_Parent == null)
			{
				m_ChildLevel = 0;
				m_Priority = DefaultPriority;
			}
			else
			{
				m_ChildLevel = m_Parent.ChildLevel + 1;
				m_Priority = m_Parent.Priority;
			}

			m_Music = DefaultMusic;

			m_Area = def.Bounds.ToArray();

			var type = GetType();

			foreach (var entry in def.Props)
			{
				object val;

				try
				{
					var prop = type.GetProperty(entry.Key);

					if (prop != null && prop.SetMethod != null)
					{
						if (prop.PropertyType == typeof(Map))
						{
							val = Map.Parse(entry.Value.ToString());
						}
						else if (prop.PropertyType == typeof(Type))
						{
							val = ScriptCompiler.FindTypeByName(entry.Value.ToString());
						}
						else if (prop.PropertyType.IsEnum)
						{
							if (!Enum.TryParse(prop.PropertyType, entry.Value.ToString(), true, out val))
							{
								val = Enum.ToObject(prop.PropertyType, 0);
							}
						}
						else
						{
							val = entry.Value;
						}

						prop.SetValue(this, val);
					}
					else
					{
						var t = type;

						while (t != null)
						{
							var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
							var field = t.GetField($"m_{entry.Key}", flags) ?? t.GetField($"_{entry.Key}", flags);

							if (field != null)
							{
								if (field.FieldType == typeof(Map))
								{
									val = Map.Parse(entry.Value.ToString());
								}
								else if (field.FieldType == typeof(Type))
								{
									val = ScriptCompiler.FindTypeByName(entry.Value.ToString());
								}
								else if (field.FieldType.IsEnum)
								{
									if (!Enum.TryParse(field.FieldType, entry.Value.ToString(), true, out val))
									{
										val = Enum.ToObject(field.FieldType, 0);
									}
								}
								else
								{
									val = entry.Value;
								}

								field.SetValue(this, val);

								break;
							}
							else
							{
								t = t.BaseType;
							}
						}
					}
				}
				catch 
				{
					Console.WriteLine($"Warning: Could not set '{entry.Key}' for '{type.Name}'");
				}
			}

			if (String.IsNullOrWhiteSpace(m_Name))
			{
				m_Name = null;
			}

			if (m_Area.Length == 0)
			{
				Console.WriteLine("Empty area for region '{0}'", this);
			}

			if (m_GoLocation == Point3D.Zero && m_Area.Length > 0)
			{
				var start = m_Area[0].Start;
				var end = m_Area[0].End;

				var x = start.X + (end.X - start.X) / 2;
				var y = start.Y + (end.Y - start.Y) / 2;

				m_GoLocation = new Point3D(x, y, m_Map.GetAverageZ(x, y));
			}
		}
	}

	public class RegionRect : IComparable
	{
		private readonly Region m_Region;
		private Rectangle3D m_Rect;

		public Region Region => m_Region;
		public Rectangle3D Rect => m_Rect;

		public RegionRect(Region region, Rectangle3D rect)
		{
			m_Region = region;
			m_Rect = rect;
		}

		public bool Contains(Point3D loc)
		{
			return m_Rect.Contains(loc);
		}

		int IComparable.CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}

			var regRect = obj as RegionRect;

			if (regRect == null)
			{
				throw new ArgumentException("obj is not a RegionRect", "obj");
			}

			return ((IComparable)m_Region).CompareTo(regRect.m_Region);
		}
	}

	public class Sector
	{
		private readonly int m_X, m_Y;
		private readonly Map m_Owner;
		private List<Mobile> m_Mobiles;
		private List<Mobile> m_Players;
		private List<Item> m_Items;
		private List<NetState> m_Clients;
		private List<BaseMulti> m_Multis;
		private List<RegionRect> m_RegionRects;
		private bool m_Active;

		// TODO: Can we avoid this?
		private static readonly List<Mobile> m_DefaultMobileList = new List<Mobile>();
		private static readonly List<Item> m_DefaultItemList = new List<Item>();
		private static readonly List<NetState> m_DefaultClientList = new List<NetState>();
		private static readonly List<BaseMulti> m_DefaultMultiList = new List<BaseMulti>();
		private static readonly List<RegionRect> m_DefaultRectList = new List<RegionRect>();

		public Sector(int x, int y, Map owner)
		{
			m_X = x;
			m_Y = y;
			m_Owner = owner;
			m_Active = false;
		}

		private void Add<T>(ref List<T> list, T value)
		{
			if (list == null)
			{
				list = new List<T>();
			}

			list.Add(value);
		}

		private void Remove<T>(ref List<T> list, T value)
		{
			if (list != null)
			{
				list.Remove(value);

				if (list.Count == 0)
				{
					list = null;
				}
			}
		}

		private void Replace<T>(ref List<T> list, T oldValue, T newValue)
		{
			if (oldValue != null && newValue != null)
			{
				var index = (list != null ? list.IndexOf(oldValue) : -1);

				if (index >= 0)
				{
					list[index] = newValue;
				}
				else
				{
					Add(ref list, newValue);
				}
			}
			else if (oldValue != null)
			{
				Remove(ref list, oldValue);
			}
			else if (newValue != null)
			{
				Add(ref list, newValue);
			}
		}

		public void OnClientChange(NetState oldState, NetState newState)
		{
			Replace(ref m_Clients, oldState, newState);
		}

		public void OnEnter(Item item)
		{
			Add(ref m_Items, item);
		}

		public void OnLeave(Item item)
		{
			Remove(ref m_Items, item);
		}

		public void OnEnter(Mobile mob)
		{
			Add(ref m_Mobiles, mob);

			if (mob.NetState != null)
			{
				Add(ref m_Clients, mob.NetState);
			}

			if (mob.Player)
			{
				if (m_Players == null)
				{
					m_Owner.ActivateSectors(m_X, m_Y);
				}

				Add(ref m_Players, mob);
			}
		}

		public void OnLeave(Mobile mob)
		{
			Remove(ref m_Mobiles, mob);

			if (mob.NetState != null)
			{
				Remove(ref m_Clients, mob.NetState);
			}

			if (mob.Player && m_Players != null)
			{
				Remove(ref m_Players, mob);

				if (m_Players == null)
				{
					m_Owner.DeactivateSectors(m_X, m_Y);
				}
			}
		}

		public void OnEnter(Region region, Rectangle3D rect)
		{
			Add(ref m_RegionRects, new RegionRect(region, rect));

			m_RegionRects.Sort();

			UpdateMobileRegions();
		}

		public void OnLeave(Region region)
		{
			if (m_RegionRects != null)
			{
				for (var i = m_RegionRects.Count - 1; i >= 0; i--)
				{
					var regRect = m_RegionRects[i];

					if (regRect.Region == region)
					{
						m_RegionRects.RemoveAt(i);
					}
				}

				if (m_RegionRects.Count == 0)
				{
					m_RegionRects = null;
				}
			}

			UpdateMobileRegions();
		}

		private void UpdateMobileRegions()
		{
			if (m_Mobiles != null)
			{
				var sandbox = new List<Mobile>(m_Mobiles);

				foreach (var mob in sandbox)
				{
					mob.UpdateRegion();
				}
			}
		}

		public void OnMultiEnter(BaseMulti multi)
		{
			Add(ref m_Multis, multi);
		}

		public void OnMultiLeave(BaseMulti multi)
		{
			Remove(ref m_Multis, multi);
		}

		public void Activate()
		{
			if (!Active && m_Owner != Map.Internal)
			{
				if (m_Items != null)
				{
					foreach (var item in m_Items)
					{
						item.OnSectorActivate();
					}
				}

				if (m_Mobiles != null)
				{
					foreach (var mob in m_Mobiles)
					{
						mob.OnSectorActivate();
					}
				}

				m_Active = true;
			}
		}

		public void Deactivate()
		{
			if (Active)
			{
				if (m_Items != null)
				{
					foreach (var item in m_Items)
					{
						item.OnSectorDeactivate();
					}
				}

				if (m_Mobiles != null)
				{
					foreach (var mob in m_Mobiles)
					{
						mob.OnSectorDeactivate();
					}
				}

				m_Active = false;
			}
		}

		public List<RegionRect> RegionRects
		{
			get
			{
				if (m_RegionRects == null)
				{
					return m_DefaultRectList;
				}

				return m_RegionRects;
			}
		}

		public List<BaseMulti> Multis
		{
			get
			{
				if (m_Multis == null)
				{
					return m_DefaultMultiList;
				}

				return m_Multis;
			}
		}

		public List<Mobile> Mobiles
		{
			get
			{
				if (m_Mobiles == null)
				{
					return m_DefaultMobileList;
				}

				return m_Mobiles;
			}
		}

		public List<Item> Items
		{
			get
			{
				if (m_Items == null)
				{
					return m_DefaultItemList;
				}

				return m_Items;
			}
		}

		public List<NetState> Clients
		{
			get
			{
				if (m_Clients == null)
				{
					return m_DefaultClientList;
				}

				return m_Clients;
			}
		}

		public List<Mobile> Players
		{
			get
			{
				if (m_Players == null)
				{
					return m_DefaultMobileList;
				}

				return m_Players;
			}
		}

		public bool Active => (m_Active && m_Owner != Map.Internal);

		public Map Owner => m_Owner;

		public int X => m_X;

		public int Y => m_Y;
	}

	public sealed class RegionDefinition : IEnumerable<object>
	{
		public static void Generate()
		{
			var fs = File.OpenWrite(Path.Combine(Core.BaseDirectory, "Server", "Engine", "Game", "Regions.cs"));
			var fw = new StreamWriter(fs);

			void write(ref int tabs, string line)
			{
				if (line == "{")
				{
					for (var i = 0; i < tabs; i++)
					{
						fw.Write('\t');
					}

					fw.WriteLine(line);

					++tabs;
				}
				else
				{
					if (line == "}" || line == "}," || line == "};")
					{
						--tabs;
					}

					if (line != "")
					{
						for (var i = 0; i < tabs; i++)
						{
							fw.Write('\t');
						}
					}

					fw.WriteLine(line);
				}

				fw.Flush();
			};

			void writeRegion(ref int tabs, Region reg)
			{
				var type = reg.GetType();

				write(ref tabs, $"#region {reg.Name}");
				write(ref tabs, $"");
				write(ref tabs, $"new(\"{type.Name}\")");
				write(ref tabs, $"{{");

				var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

				foreach (var prop in props)
				{
					if (prop.GetMethod.IsVirtual)
					{
						continue;
					}

					if (prop.Name.Contains("Default") || prop.Name == "ChildLevel" || prop.Name == "Dynamic" || prop.Name == "Map" || prop.Name == "Registered")
					{
						continue;
					}

					var val = prop.GetValue(reg, null);

					if (prop.PropertyType.IsEnum || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(Map))
					{
						write(ref tabs, $"{{ \"{prop.Name}\", \"{val}\" }},");
					}
					else if (prop.PropertyType == typeof(bool))
					{
						write(ref tabs, $"{{ \"{prop.Name}\", {(val?.ToString() ?? Boolean.FalseString).ToLower()} }},");
					}
					else if (prop.PropertyType == typeof(Type))
					{
						write(ref tabs, $"{{ \"{prop.Name}\", \"{(val as Type)?.Name}\" }},");
					}
					else if (prop.PropertyType.GetCustomAttributes(typeof(ParsableAttribute), true)?.Length > 0)
					{
						write(ref tabs, $"{{ \"{prop.Name}\", new {prop.PropertyType.Name}{val} }},");
					}
					else if (prop.PropertyType.IsValueType)
					{
						write(ref tabs, $"{{ \"{prop.Name}\", {val} }},");
					}
				}

				if (reg.Area.Length > 0)
				{
					write(ref tabs, $"");

					foreach (var rect in reg.Area)
					{
						write(ref tabs, $"{{ {rect.Start.X}, {rect.Start.Y}, {rect.Start.Z}, {rect.Width}, {rect.Height}, {rect.Depth} }},");
					}
				}

				if (reg.Children.Count > 0)
				{
					write(ref tabs, $"");

					var firstChild = true;

					foreach (var child in reg.Children)
					{
						if (!firstChild)
						{
							write(ref tabs, $"");
						}

						writeRegion(ref tabs, child);

						firstChild = false;
					}
				}

				write(ref tabs, $"}},");
				write(ref tabs, $"");
				write(ref tabs, $"#endregion");
			};

			var indent = 0;

			write(ref indent, $"using System.Collections.Generic;");
			write(ref indent, $"");
			write(ref indent, $"namespace Server");
			write(ref indent, $"{{");
			{
				write(ref indent, $"public partial class Region");
				write(ref indent, $"{{");
				{
					write(ref indent, "private static readonly Dictionary<string, HashSet<RegionDefinition>> m_Definitions = new()");
					write(ref indent, $"{{");
					{
						var firstMap = true;

						foreach (var map in Map.Maps)
						{
							if (map == null || map == Map.Internal)
							{
								continue;
							}

							if (!firstMap)
							{
								write(ref indent, $"");
							}

							write(ref indent, $"#region {map.Name}");
							write(ref indent, $"");
							write(ref indent, $"[\"{map.Name}\"] = new()");
							write(ref indent, $"{{");

							var firstReg = true;

							foreach (var reg in map.Regions.Values)
							{
								if (reg.Parent != null)
								{
									continue;
								}

								if (!firstReg)
								{
									write(ref indent, $"");
								}

								writeRegion(ref indent, reg);

								firstReg = false;
							}

							write(ref indent, $"}},");
							write(ref indent, $"");
							write(ref indent, $"#endregion");

							firstMap = false;
						}
					}
					write(ref indent, $"}};");
				}
				write(ref indent, $"}}");
			}
			write(ref indent, $"}}");

			fw.Flush();
			fw.Close();
			fs.Close();
		}

		public Type Type { get; }

		public Dictionary<string, object> Props { get; } = new Dictionary<string, object>();

		public HashSet<Rectangle3D> Bounds { get; } = new HashSet<Rectangle3D>();

		public HashSet<RegionDefinition> Children { get; } = new HashSet<RegionDefinition>();

		public RegionDefinition(string type)
		{
			Type = ScriptCompiler.FindTypeByName(type, true);
		}

		public void Add(RegionDefinition child)
		{
			Children.Add(child);
		}

		public void Add(string prop, object value)
		{
			Props[prop] = value;
		}

		public void Add(int x, int y, int z, int width, int height, int depth)
		{
			Bounds.Add(new Rectangle3D(x, y, z, width, height, depth));
		}

		public IEnumerator<object> GetEnumerator()
		{
			foreach (var rect in Bounds)
			{
				yield return rect;
			}

			foreach (var child in Children)
			{
				yield return child;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}