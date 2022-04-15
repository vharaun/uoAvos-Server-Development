using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.PathAlgorithms;
using Server.PathAlgorithms.FastAStar;
using Server.PathAlgorithms.SlowAStar;
using Server.Targeting;

using System;
using System.Collections.Generic;
using System.Linq;

using CalcMoves = Server.Movement.Movement;

#region Developer Notations

/// This fastwalk detection is no longer required
/// As of B36 PlayerMobile implements movement packet throttling which more reliably controls movement speeds

#endregion

namespace Server
{
	public partial class SpeedInfo
	{
		// Should we use the new method of speeds?
		private static readonly bool Enabled = true;

		private double m_ActiveSpeed;
		private double m_PassiveSpeed;
		private Type[] m_Types;

		public double ActiveSpeed
		{
			get => m_ActiveSpeed;
			set => m_ActiveSpeed = value;
		}

		public double PassiveSpeed
		{
			get => m_PassiveSpeed;
			set => m_PassiveSpeed = value;
		}

		public Type[] Types
		{
			get => m_Types;
			set => m_Types = value;
		}

		public SpeedInfo(double activeSpeed, double passiveSpeed, Type[] types)
		{
			m_ActiveSpeed = activeSpeed;
			m_PassiveSpeed = passiveSpeed;
			m_Types = types;
		}

		public static bool Contains(object obj)
		{
			if (!Enabled)
			{
				return false;
			}

			if (m_Table == null)
			{
				LoadTable();
			}

			SpeedInfo sp = null;

			m_Table.TryGetValue(obj.GetType(), out sp);

			return (sp != null);
		}

		public static bool GetSpeeds(object obj, ref double activeSpeed, ref double passiveSpeed)
		{
			if (!Enabled)
			{
				return false;
			}

			if (m_Table == null)
			{
				LoadTable();
			}

			SpeedInfo sp = null;

			m_Table.TryGetValue(obj.GetType(), out sp);

			if (sp == null)
			{
				return false;
			}

			activeSpeed = sp.ActiveSpeed;
			passiveSpeed = sp.PassiveSpeed;

			return true;
		}

		private static void LoadTable()
		{
			m_Table = new Dictionary<Type, SpeedInfo>();

			for (var i = 0; i < m_Speeds.Length; ++i)
			{
				var info = m_Speeds[i];
				var types = info.Types;

				for (var j = 0; j < types.Length; ++j)
				{
					m_Table[types[j]] = info;
				}
			}
		}
	}

	public delegate MoveResult MoveMethod(Direction d);

	public enum MoveResult
	{
		BadState,
		Blocked,
		Success,
		SuccessAutoTurn
	}

	public sealed class MovementPath
	{
		private readonly Map m_Map;
		private Point3D m_Start;
		private Point3D m_Goal;
		private readonly Direction[] m_Directions;

		public Map Map => m_Map;
		public Point3D Start => m_Start;
		public Point3D Goal => m_Goal;
		public Direction[] Directions => m_Directions;
		public bool Success => (m_Directions != null && m_Directions.Length > 0);

		public static void Initialize()
		{
			CommandSystem.Register("Path", AccessLevel.GameMaster, new CommandEventHandler(Path_OnCommand));
		}

		public static void Path_OnCommand(CommandEventArgs e)
		{
			e.Mobile.BeginTarget(-1, true, TargetFlags.None, new TargetCallback(Path_OnTarget));
			e.Mobile.SendMessage("Target a location and a path will be drawn there.");
		}

		private static void Path(Mobile from, IPoint3D p, PathAlgorithm alg, string name, int zOffset)
		{
			m_OverrideAlgorithm = alg;

			var start = DateTime.UtcNow.Ticks;
			var path = new MovementPath(from, new Point3D(p));
			var end = DateTime.UtcNow.Ticks;
			var len = Math.Round((end - start) / 10000.0, 2);

			if (!path.Success)
			{
				from.SendMessage("{0} path failed: {1}ms", name, len);
			}
			else
			{
				from.SendMessage("{0} path success: {1}ms", name, len);

				var x = from.X;
				var y = from.Y;
				var z = from.Z;

				for (var i = 0; i < path.Directions.Length; ++i)
				{
					Movement.Movement.Offset(path.Directions[i], ref x, ref y);

					new Items.RecallRune().MoveToWorld(new Point3D(x, y, z + zOffset), from.Map);
				}
			}
		}

		public static void Path_OnTarget(Mobile from, object obj)
		{
			var p = obj as IPoint3D;

			if (p == null)
			{
				return;
			}

			Spells.SpellHelper.GetSurfaceTop(ref p);

			Path(from, p, FastAStarAlgorithm.Instance, "Fast", 0);
			Path(from, p, SlowAStarAlgorithm.Instance, "Slow", 2);
			m_OverrideAlgorithm = null;

			/*MovementPath path = new MovementPath( from, new Point3D( p ) );

			if ( !path.Success )
			{
				from.SendMessage( "No path to there could be found." );
			}
			else
			{
				//for ( int i = 0; i < path.Directions.Length; ++i )
				//	Timer.DelayCall( TimeSpan.FromSeconds( 0.1 + (i * 0.3) ),  Pathfind , new object[]{ from, path.Directions[i] } );
				int x = from.X;
				int y = from.Y;
				int z = from.Z;

				for ( int i = 0; i < path.Directions.Length; ++i )
				{
					Movement.Movement.Offset( path.Directions[i], ref x, ref y );

					new Items.RecallRune().MoveToWorld( new Point3D( x, y, z ), from.Map );
				}
			}*/
		}

		public static void Pathfind(object state)
		{
			var states = (object[])state;
			var from = (Mobile)states[0];
			var d = (Direction)states[1];

			try
			{
				from.Direction = d;
				from.NetState.BlockAllPackets = true;
				from.Move(d);
				from.NetState.BlockAllPackets = false;
				from.ProcessDelta();
			}
			catch
			{
			}
		}

		private static PathAlgorithm m_OverrideAlgorithm;

		public static PathAlgorithm OverrideAlgorithm
		{
			get => m_OverrideAlgorithm;
			set => m_OverrideAlgorithm = value;
		}

		public MovementPath(Mobile m, Point3D goal)
		{
			var start = m.Location;
			var map = m.Map;

			m_Map = map;
			m_Start = start;
			m_Goal = goal;

			if (map == null || map == Map.Internal)
			{
				return;
			}

			if (Utility.InRange(start, goal, 1))
			{
				return;
			}

			try
			{
				var alg = m_OverrideAlgorithm;

				if (alg == null)
				{
					alg = FastAStarAlgorithm.Instance;

					//if ( !alg.CheckCondition( m, map, start, goal ) )	// SlowAstar is still broken
					//	alg = SlowAStarAlgorithm.Instance;		// TODO: Fix SlowAstar
				}

				if (alg != null && alg.CheckCondition(m, map, start, goal))
				{
					m_Directions = alg.Find(m, map, start, goal);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Warning: {0}: Pathing error from {1} to {2}", e.GetType().Name, start, goal);
			}
		}
	}

	public class PathFollower
	{
		// Should we use pathfinding? 'false' for not
		private static readonly bool Enabled = true;

		private readonly Mobile m_From;
		private readonly IPoint3D m_Goal;
		private MovementPath m_Path;
		private int m_Index;
		private Point3D m_Next, m_LastGoalLoc;
		private DateTime m_LastPathTime;
		private MoveMethod m_Mover;

		public MoveMethod Mover
		{
			get => m_Mover;
			set => m_Mover = value;
		}

		public IPoint3D Goal => m_Goal;

		public PathFollower(Mobile from, IPoint3D goal)
		{
			m_From = from;
			m_Goal = goal;
		}

		public MoveResult Move(Direction d)
		{
			if (m_Mover == null)
			{
				return (m_From.Move(d) ? MoveResult.Success : MoveResult.Blocked);
			}

			return m_Mover(d);
		}

		public Point3D GetGoalLocation()
		{
			if (m_Goal is Item)
			{
				return ((Item)m_Goal).GetWorldLocation();
			}

			return new Point3D(m_Goal);
		}

		private static readonly TimeSpan RepathDelay = TimeSpan.FromSeconds(2.0);

		public void Advance(ref Point3D p, int index)
		{
			if (m_Path != null && m_Path.Success)
			{
				var dirs = m_Path.Directions;

				if (index >= 0 && index < dirs.Length)
				{
					int x = p.X, y = p.Y;

					CalcMoves.Offset(dirs[index], ref x, ref y);

					p.X = x;
					p.Y = y;
				}
			}
		}

		public void ForceRepath()
		{
			m_Path = null;
		}

		public bool CheckPath()
		{
			if (!Enabled)
			{
				return false;
			}

			var repath = false;

			var goal = GetGoalLocation();

			if (m_Path == null)
			{
				repath = true;
			}
			else if ((!m_Path.Success || goal != m_LastGoalLoc) && (m_LastPathTime + RepathDelay) <= DateTime.UtcNow)
			{
				repath = true;
			}
			else if (m_Path.Success && Check(m_From.Location, m_LastGoalLoc, 0))
			{
				repath = true;
			}

			if (!repath)
			{
				return false;
			}

			m_LastPathTime = DateTime.UtcNow;
			m_LastGoalLoc = goal;

			m_Path = new MovementPath(m_From, goal);

			m_Index = 0;
			m_Next = m_From.Location;

			Advance(ref m_Next, m_Index);

			return true;
		}

		public bool Check(Point3D loc, Point3D goal, int range)
		{
			if (!Utility.InRange(loc, goal, range))
			{
				return false;
			}

			if (range <= 1 && Math.Abs(loc.Z - goal.Z) >= 16)
			{
				return false;
			}

			return true;
		}

		public bool Follow(bool run, int range)
		{
			var goal = GetGoalLocation();
			Direction d;

			if (Check(m_From.Location, goal, range))
			{
				return true;
			}

			var repathed = CheckPath();

			if (!Enabled || !m_Path.Success)
			{
				d = m_From.GetDirectionTo(goal);

				if (run)
				{
					d |= Direction.Running;
				}

				m_From.SetDirection(d);
				Move(d);

				return Check(m_From.Location, goal, range);
			}

			d = m_From.GetDirectionTo(m_Next);

			if (run)
			{
				d |= Direction.Running;
			}

			m_From.SetDirection(d);

			var res = Move(d);

			if (res == MoveResult.Blocked)
			{
				if (repathed)
				{
					return false;
				}

				m_Path = null;
				CheckPath();

				if (!m_Path.Success)
				{
					d = m_From.GetDirectionTo(goal);

					if (run)
					{
						d |= Direction.Running;
					}

					m_From.SetDirection(d);
					Move(d);

					return Check(m_From.Location, goal, range);
				}

				d = m_From.GetDirectionTo(m_Next);

				if (run)
				{
					d |= Direction.Running;
				}

				m_From.SetDirection(d);

				res = Move(d);

				if (res == MoveResult.Blocked)
				{
					return false;
				}
			}

			if (m_From.X == m_Next.X && m_From.Y == m_Next.Y)
			{
				if (m_From.Z == m_Next.Z)
				{
					++m_Index;
					Advance(ref m_Next, m_Index);
				}
				else
				{
					m_Path = null;
				}
			}

			return Check(m_From.Location, goal, range);
		}
	}
}

namespace Server.Misc
{
	public class Fastwalk
	{
		private static readonly int MaxSteps = 4;            // Maximum number of queued steps until fastwalk is detected
		private static readonly bool Enabled = false;        // Is fastwalk detection enabled?
		private static readonly bool UOTDOverride = false;   // Should UO:TD clients not be checked for fastwalk?
		private static readonly AccessLevel AccessOverride = AccessLevel.GameMaster; // Anyone with this or higher access level is not checked for fastwalk

		public static void Initialize()
		{
			Mobile.FwdMaxSteps = MaxSteps;
			Mobile.FwdEnabled = Enabled;
			Mobile.FwdUOTDOverride = UOTDOverride;
			Mobile.FwdAccessOverride = AccessOverride;

			if (Enabled)
			{
				EventSink.FastWalk += new FastWalkEventHandler(OnFastWalk);
			}
		}

		public static void OnFastWalk(FastWalkEventArgs e)
		{
			e.Blocked = true;//disallow this fastwalk
			Console.WriteLine("Client: {0}: Fast movement detected (name={1})", e.NetState, e.NetState.Mobile.Name);
		}
	}
}

namespace Server.Movement
{
	public class MovementImpl : IMovementImpl
	{
		private const int PersonHeight = 16;
		private const int StepHeight = 2;

		private const TileFlag ImpassableSurface = TileFlag.Impassable | TileFlag.Surface;

		private static bool m_AlwaysIgnoreDoors;
		private static bool m_IgnoreMovableImpassables;
		private static bool m_IgnoreSpellFields;
		private static Point3D m_Goal;

		public static bool AlwaysIgnoreDoors { get => m_AlwaysIgnoreDoors; set => m_AlwaysIgnoreDoors = value; }
		public static bool IgnoreMovableImpassables { get => m_IgnoreMovableImpassables; set => m_IgnoreMovableImpassables = value; }
		public static bool IgnoreSpellFields { get => m_IgnoreSpellFields; set => m_IgnoreSpellFields = value; }
		public static Point3D Goal { get => m_Goal; set => m_Goal = value; }

		public static void Configure()
		{
			Movement.Impl = new MovementImpl();
		}

		private MovementImpl()
		{
		}

		private bool IsOk(bool ignoreDoors, bool ignoreSpellFields, int ourZ, int ourTop, StaticTile[] tiles, List<Item> items)
		{
			for (var i = 0; i < tiles.Length; ++i)
			{
				var check = tiles[i];
				var itemData = TileData.ItemTable[check.ID & TileData.MaxItemValue];

				if ((itemData.Flags & ImpassableSurface) != 0) // Impassable || Surface
				{
					var checkZ = check.Z;
					var checkTop = checkZ + itemData.CalcHeight;

					if (checkTop > ourZ && ourTop > checkZ)
					{
						return false;
					}
				}
			}

			for (var i = 0; i < items.Count; ++i)
			{
				var item = items[i];
				var itemID = item.ItemID & TileData.MaxItemValue;
				var itemData = TileData.ItemTable[itemID];
				var flags = itemData.Flags;

				if ((flags & ImpassableSurface) != 0) // Impassable || Surface
				{
					if (ignoreDoors && ((flags & TileFlag.Door) != 0 || itemID == 0x692 || itemID == 0x846 || itemID == 0x873 || (itemID >= 0x6F5 && itemID <= 0x6F6)))
					{
						continue;
					}

					if (ignoreSpellFields && (itemID == 0x82 || itemID == 0x3946 || itemID == 0x3956))
					{
						continue;
					}

					var checkZ = item.Z;
					var checkTop = checkZ + itemData.CalcHeight;

					if (checkTop > ourZ && ourTop > checkZ)
					{
						return false;
					}
				}
			}

			return true;
		}

		private readonly List<Item>[] m_Pools = new List<Item>[4]
			{
				new List<Item>(), new List<Item>(),
				new List<Item>(), new List<Item>(),
			};

		private readonly List<Mobile>[] m_MobPools = new List<Mobile>[3]
			{
				new List<Mobile>(), new List<Mobile>(),
				new List<Mobile>(),
			};

		private readonly List<Sector> m_Sectors = new List<Sector>();

		private bool Check(Map map, Mobile m, List<Item> items, List<Mobile> mobiles, int x, int y, int startTop, int startZ, bool canSwim, bool cantWalk, out int newZ)
		{
			newZ = 0;

			var tiles = map.Tiles.GetStaticTiles(x, y, true);
			var landTile = map.Tiles.GetLandTile(x, y);

			var landBlocks = (TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags & TileFlag.Impassable) != 0;
			var considerLand = !landTile.Ignored;

			if (landBlocks && canSwim && (TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags & TileFlag.Wet) != 0)   //Impassable, Can Swim, and Is water.  Don't block it.
			{
				landBlocks = false;
			}
			else if (cantWalk && (TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags & TileFlag.Wet) == 0)   //Can't walk and it's not water
			{
				landBlocks = true;
			}

			int landZ = 0, landCenter = 0, landTop = 0;

			map.GetAverageZ(x, y, ref landZ, ref landCenter, ref landTop);

			var moveIsOk = false;

			var stepTop = startTop + StepHeight;
			var checkTop = startZ + PersonHeight;

			var ignoreDoors = (m_AlwaysIgnoreDoors || !m.Alive || m.Body.BodyID == 0x3DB || m.IsDeadBondedPet);
			var ignoreSpellFields = m is PlayerMobile && map != Map.Felucca;

			#region Tiles
			for (var i = 0; i < tiles.Length; ++i)
			{
				var tile = tiles[i];
				var itemData = TileData.ItemTable[tile.ID & TileData.MaxItemValue];
				var flags = itemData.Flags;

				if ((flags & ImpassableSurface) == TileFlag.Surface || (canSwim && (flags & TileFlag.Wet) != 0)) // Surface && !Impassable
				{
					if (cantWalk && (flags & TileFlag.Wet) == 0)
					{
						continue;
					}

					var itemZ = tile.Z;
					var itemTop = itemZ;
					var ourZ = itemZ + itemData.CalcHeight;
					var ourTop = ourZ + PersonHeight;
					var testTop = checkTop;

					if (moveIsOk)
					{
						var cmp = Math.Abs(ourZ - m.Z) - Math.Abs(newZ - m.Z);

						if (cmp > 0 || (cmp == 0 && ourZ > newZ))
						{
							continue;
						}
					}

					if (ourZ + PersonHeight > testTop)
					{
						testTop = ourZ + PersonHeight;
					}

					if (!itemData.Bridge)
					{
						itemTop += itemData.Height;
					}

					if (stepTop >= itemTop)
					{
						var landCheck = itemZ;

						if (itemData.Height >= StepHeight)
						{
							landCheck += StepHeight;
						}
						else
						{
							landCheck += itemData.Height;
						}

						if (considerLand && landCheck < landCenter && landCenter > ourZ && testTop > landZ)
						{
							continue;
						}

						if (IsOk(ignoreDoors, ignoreSpellFields, ourZ, testTop, tiles, items))
						{
							newZ = ourZ;
							moveIsOk = true;
						}
					}
				}
			}
			#endregion

			#region Items
			for (var i = 0; i < items.Count; ++i)
			{
				var item = items[i];
				var itemData = item.ItemData;
				var flags = itemData.Flags;

				if (!item.Movable && ((flags & ImpassableSurface) == TileFlag.Surface || (m.CanSwim && (flags & TileFlag.Wet) != 0))) // Surface && !Impassable && !Movable
				{
					if (cantWalk && (flags & TileFlag.Wet) == 0)
					{
						continue;
					}

					var itemZ = item.Z;
					var itemTop = itemZ;
					var ourZ = itemZ + itemData.CalcHeight;
					var ourTop = ourZ + PersonHeight;
					var testTop = checkTop;

					if (moveIsOk)
					{
						var cmp = Math.Abs(ourZ - m.Z) - Math.Abs(newZ - m.Z);

						if (cmp > 0 || (cmp == 0 && ourZ > newZ))
						{
							continue;
						}
					}

					if (ourZ + PersonHeight > testTop)
					{
						testTop = ourZ + PersonHeight;
					}

					if (!itemData.Bridge)
					{
						itemTop += itemData.Height;
					}

					if (stepTop >= itemTop)
					{
						var landCheck = itemZ;

						if (itemData.Height >= StepHeight)
						{
							landCheck += StepHeight;
						}
						else
						{
							landCheck += itemData.Height;
						}

						if (considerLand && landCheck < landCenter && landCenter > ourZ && testTop > landZ)
						{
							continue;
						}

						if (IsOk(ignoreDoors, ignoreSpellFields, ourZ, testTop, tiles, items))
						{
							newZ = ourZ;
							moveIsOk = true;
						}
					}
				}
			}
			#endregion

			if (considerLand && !landBlocks && stepTop >= landZ)
			{
				var ourZ = landCenter;
				var ourTop = ourZ + PersonHeight;
				var testTop = checkTop;

				if (ourZ + PersonHeight > testTop)
				{
					testTop = ourZ + PersonHeight;
				}

				var shouldCheck = true;

				if (moveIsOk)
				{
					var cmp = Math.Abs(ourZ - m.Z) - Math.Abs(newZ - m.Z);

					if (cmp > 0 || (cmp == 0 && ourZ > newZ))
					{
						shouldCheck = false;
					}
				}

				if (shouldCheck && IsOk(ignoreDoors, ignoreSpellFields, ourZ, testTop, tiles, items))
				{
					newZ = ourZ;
					moveIsOk = true;
				}
			}

			#region Mobiles
			if (moveIsOk)
			{
				for (var i = 0; moveIsOk && i < mobiles.Count; ++i)
				{
					var mob = mobiles[i];

					if (mob != m && (mob.Z + 15) > newZ && (newZ + 15) > mob.Z && !CanMoveOver(m, mob))
					{
						moveIsOk = false;
					}
				}
			}
			#endregion

			return moveIsOk;
		}

		private bool CanMoveOver(Mobile m, Mobile t)
		{
			return (!t.Alive || !m.Alive || t.IsDeadBondedPet || m.IsDeadBondedPet) || (t.Hidden && t.AccessLevel > AccessLevel.Player);
		}

		public bool CheckMovement(Mobile m, Map map, Point3D loc, Direction d, out int newZ)
		{
			if (map == null || map == Map.Internal)
			{
				newZ = 0;
				return false;
			}

			var xStart = loc.X;
			var yStart = loc.Y;
			int xForward = xStart, yForward = yStart;
			int xRight = xStart, yRight = yStart;
			int xLeft = xStart, yLeft = yStart;

			var checkDiagonals = ((int)d & 0x1) == 0x1;

			Offset(d, ref xForward, ref yForward);
			Offset((Direction)(((int)d - 1) & 0x7), ref xLeft, ref yLeft);
			Offset((Direction)(((int)d + 1) & 0x7), ref xRight, ref yRight);

			if (xForward < 0 || yForward < 0 || xForward >= map.Width || yForward >= map.Height)
			{
				newZ = 0;
				return false;
			}

			int startZ, startTop;

			var itemsStart = m_Pools[0];
			var itemsForward = m_Pools[1];
			var itemsLeft = m_Pools[2];
			var itemsRight = m_Pools[3];

			var ignoreMovableImpassables = m_IgnoreMovableImpassables;
			var reqFlags = ImpassableSurface;

			if (m.CanSwim)
			{
				reqFlags |= TileFlag.Wet;
			}

			var mobsForward = m_MobPools[0];
			var mobsLeft = m_MobPools[1];
			var mobsRight = m_MobPools[2];

			var checkMobs = (m is BaseCreature && !((BaseCreature)m).Controlled && (xForward != m_Goal.X || yForward != m_Goal.Y));

			if (checkDiagonals)
			{
				var sectorStart = map.GetSector(xStart, yStart);
				var sectorForward = map.GetSector(xForward, yForward);
				var sectorLeft = map.GetSector(xLeft, yLeft);
				var sectorRight = map.GetSector(xRight, yRight);

				var sectors = m_Sectors;

				sectors.Add(sectorStart);

				if (!sectors.Contains(sectorForward))
				{
					sectors.Add(sectorForward);
				}

				if (!sectors.Contains(sectorLeft))
				{
					sectors.Add(sectorLeft);
				}

				if (!sectors.Contains(sectorRight))
				{
					sectors.Add(sectorRight);
				}

				for (var i = 0; i < sectors.Count; ++i)
				{
					var sector = sectors[i];

					for (var j = 0; j < sector.Items.Count; ++j)
					{
						var item = sector.Items[j];

						if (ignoreMovableImpassables && item.Movable && (item.ItemData.Flags & ImpassableSurface) != 0)
						{
							continue;
						}

						if ((item.ItemData.Flags & reqFlags) == 0)
						{
							continue;
						}

						if (sector == sectorStart && item.AtWorldPoint(xStart, yStart) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsStart.Add(item);
						}
						else if (sector == sectorForward && item.AtWorldPoint(xForward, yForward) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsForward.Add(item);
						}
						else if (sector == sectorLeft && item.AtWorldPoint(xLeft, yLeft) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsLeft.Add(item);
						}
						else if (sector == sectorRight && item.AtWorldPoint(xRight, yRight) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsRight.Add(item);
						}
					}

					if (checkMobs)
					{
						for (var j = 0; j < sector.Mobiles.Count; ++j)
						{
							var mob = sector.Mobiles[j];

							if (sector == sectorForward && mob.X == xForward && mob.Y == yForward)
							{
								mobsForward.Add(mob);
							}
							else if (sector == sectorLeft && mob.X == xLeft && mob.Y == yLeft)
							{
								mobsLeft.Add(mob);
							}
							else if (sector == sectorRight && mob.X == xRight && mob.Y == yRight)
							{
								mobsRight.Add(mob);
							}
						}
					}
				}

				if (m_Sectors.Count > 0)
				{
					m_Sectors.Clear();
				}
			}
			else
			{
				var sectorStart = map.GetSector(xStart, yStart);
				var sectorForward = map.GetSector(xForward, yForward);

				if (sectorStart == sectorForward)
				{
					for (var i = 0; i < sectorStart.Items.Count; ++i)
					{
						var item = sectorStart.Items[i];

						if (ignoreMovableImpassables && item.Movable && (item.ItemData.Flags & ImpassableSurface) != 0)
						{
							continue;
						}

						if ((item.ItemData.Flags & reqFlags) == 0)
						{
							continue;
						}

						if (item.AtWorldPoint(xStart, yStart) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsStart.Add(item);
						}
						else if (item.AtWorldPoint(xForward, yForward) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsForward.Add(item);
						}
					}
				}
				else
				{
					for (var i = 0; i < sectorForward.Items.Count; ++i)
					{
						var item = sectorForward.Items[i];

						if (ignoreMovableImpassables && item.Movable && (item.ItemData.Flags & ImpassableSurface) != 0)
						{
							continue;
						}

						if ((item.ItemData.Flags & reqFlags) == 0)
						{
							continue;
						}

						if (item.AtWorldPoint(xForward, yForward) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsForward.Add(item);
						}
					}

					for (var i = 0; i < sectorStart.Items.Count; ++i)
					{
						var item = sectorStart.Items[i];

						if (ignoreMovableImpassables && item.Movable && (item.ItemData.Flags & ImpassableSurface) != 0)
						{
							continue;
						}

						if ((item.ItemData.Flags & reqFlags) == 0)
						{
							continue;
						}

						if (item.AtWorldPoint(xStart, yStart) && !(item is BaseMulti) && item.ItemID <= TileData.MaxItemValue)
						{
							itemsStart.Add(item);
						}
					}
				}

				if (checkMobs)
				{
					for (var i = 0; i < sectorForward.Mobiles.Count; ++i)
					{
						var mob = sectorForward.Mobiles[i];

						if (mob.X == xForward && mob.Y == yForward)
						{
							mobsForward.Add(mob);
						}
					}
				}
			}

			GetStartZ(m, map, loc, itemsStart, out startZ, out startTop);

			var moveIsOk = Check(map, m, itemsForward, mobsForward, xForward, yForward, startTop, startZ, m.CanSwim, m.CantWalk, out newZ);

			if (moveIsOk && checkDiagonals)
			{
				int hold;

				if (m.Player && m.AccessLevel < AccessLevel.GameMaster)
				{
					if (!Check(map, m, itemsLeft, mobsLeft, xLeft, yLeft, startTop, startZ, m.CanSwim, m.CantWalk, out hold) || !Check(map, m, itemsRight, mobsRight, xRight, yRight, startTop, startZ, m.CanSwim, m.CantWalk, out hold))
					{
						moveIsOk = false;
					}
				}
				else
				{
					if (!Check(map, m, itemsLeft, mobsLeft, xLeft, yLeft, startTop, startZ, m.CanSwim, m.CantWalk, out hold) && !Check(map, m, itemsRight, mobsRight, xRight, yRight, startTop, startZ, m.CanSwim, m.CantWalk, out hold))
					{
						moveIsOk = false;
					}
				}
			}

			for (var i = 0; i < (checkDiagonals ? 4 : 2); ++i)
			{
				if (m_Pools[i].Count != 0)
				{
					m_Pools[i].Clear();
				}
			}

			for (var i = 0; i < (checkDiagonals ? 3 : 1); ++i)
			{
				if (m_MobPools[i].Count != 0)
				{
					m_MobPools[i].Clear();
				}
			}

			if (!moveIsOk)
			{
				newZ = startZ;
			}

			return moveIsOk;
		}

		public bool CheckMovement(Mobile m, Direction d, out int newZ)
		{
			return CheckMovement(m, m.Map, m.Location, d, out newZ);
		}

		private void GetStartZ(Mobile m, Map map, Point3D loc, List<Item> itemList, out int zLow, out int zTop)
		{
			int xCheck = loc.X, yCheck = loc.Y;

			var landTile = map.Tiles.GetLandTile(xCheck, yCheck);
			int landZ = 0, landCenter = 0, landTop = 0;
			var landBlocks = (TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags & TileFlag.Impassable) != 0;

			if (landBlocks && m.CanSwim && (TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags & TileFlag.Wet) != 0)
			{
				landBlocks = false;
			}
			else if (m.CantWalk && (TileData.LandTable[landTile.ID & TileData.MaxLandValue].Flags & TileFlag.Wet) == 0)
			{
				landBlocks = true;
			}

			map.GetAverageZ(xCheck, yCheck, ref landZ, ref landCenter, ref landTop);

			var considerLand = !landTile.Ignored;

			var zCenter = zLow = zTop = 0;
			var isSet = false;

			if (considerLand && !landBlocks && loc.Z >= landCenter)
			{
				zLow = landZ;
				zCenter = landCenter;

				if (!isSet || landTop > zTop)
				{
					zTop = landTop;
				}

				isSet = true;
			}

			var staticTiles = map.Tiles.GetStaticTiles(xCheck, yCheck, true);

			for (var i = 0; i < staticTiles.Length; ++i)
			{
				var tile = staticTiles[i];
				var id = TileData.ItemTable[tile.ID & TileData.MaxItemValue];

				var calcTop = (tile.Z + id.CalcHeight);

				if ((!isSet || calcTop >= zCenter) && ((id.Flags & TileFlag.Surface) != 0 || (m.CanSwim && (id.Flags & TileFlag.Wet) != 0)) && loc.Z >= calcTop)
				{
					if (m.CantWalk && (id.Flags & TileFlag.Wet) == 0)
					{
						continue;
					}

					zLow = tile.Z;
					zCenter = calcTop;

					var top = tile.Z + id.Height;

					if (!isSet || top > zTop)
					{
						zTop = top;
					}

					isSet = true;
				}
			}

			for (var i = 0; i < itemList.Count; ++i)
			{
				var item = itemList[i];

				var id = item.ItemData;

				var calcTop = item.Z + id.CalcHeight;

				if ((!isSet || calcTop >= zCenter) && ((id.Flags & TileFlag.Surface) != 0 || (m.CanSwim && (id.Flags & TileFlag.Wet) != 0)) && loc.Z >= calcTop)
				{
					if (m.CantWalk && (id.Flags & TileFlag.Wet) == 0)
					{
						continue;
					}

					zLow = item.Z;
					zCenter = calcTop;

					var top = item.Z + id.Height;

					if (!isSet || top > zTop)
					{
						zTop = top;
					}

					isSet = true;
				}
			}

			if (!isSet)
			{
				zLow = zTop = loc.Z;
			}
			else if (loc.Z > zTop)
			{
				zTop = loc.Z;
			}
		}

		public void Offset(Direction d, ref int x, ref int y)
		{
			switch (d & Direction.Mask)
			{
				case Direction.North: --y; break;
				case Direction.South: ++y; break;
				case Direction.West: --x; break;
				case Direction.East: ++x; break;
				case Direction.Right: ++x; --y; break;
				case Direction.Left: --x; ++y; break;
				case Direction.Down: ++x; ++y; break;
				case Direction.Up: --x; --y; break;
			}
		}
	}

	public class FastMovementImpl : IMovementImpl
	{
		public static bool Enabled = false;

		private const int PersonHeight = 16;
		private const int StepHeight = 2;

		private const TileFlag ImpassableSurface = TileFlag.Impassable | TileFlag.Surface;

		private static IMovementImpl _Successor;

		public static void Initialize()
		{
			_Successor = Movement.Impl;
			Movement.Impl = new FastMovementImpl();
		}

		private FastMovementImpl()
		{ }

		private static bool IsOk(StaticTile tile, int ourZ, int ourTop)
		{
			var itemData = TileData.ItemTable[tile.ID & TileData.MaxItemValue];

			return tile.Z + itemData.CalcHeight <= ourZ || ourTop <= tile.Z || (itemData.Flags & ImpassableSurface) == 0;
		}

		private static bool IsOk(Item item, int ourZ, int ourTop, bool ignoreDoors, bool ignoreSpellFields)
		{
			var itemID = item.ItemID & TileData.MaxItemValue;
			var itemData = TileData.ItemTable[itemID];

			if ((itemData.Flags & ImpassableSurface) == 0)
			{
				return true;
			}

			if (((itemData.Flags & TileFlag.Door) != 0 || itemID == 0x692 || itemID == 0x846 || itemID == 0x873 ||
				 (itemID >= 0x6F5 && itemID <= 0x6F6)) && ignoreDoors)
			{
				return true;
			}

			if ((itemID == 0x82 || itemID == 0x3946 || itemID == 0x3956) && ignoreSpellFields)
			{
				return true;
			}

			return item.Z + itemData.CalcHeight <= ourZ || ourTop <= item.Z;
		}

		private static bool IsOk(
			bool ignoreDoors,
			bool ignoreSpellFields,
			int ourZ,
			int ourTop,
			IEnumerable<StaticTile> tiles,
			IEnumerable<Item> items)
		{
			return tiles.All(t => IsOk(t, ourZ, ourTop)) && items.All(i => IsOk(i, ourZ, ourTop, ignoreDoors, ignoreSpellFields));
		}

		private static bool Check(
			Map map,
			Mobile m,
			List<Item> items,
			int x,
			int y,
			int startTop,
			int startZ,
			bool canSwim,
			bool cantWalk,
			out int newZ)
		{
			newZ = 0;

			var tiles = map.Tiles.GetStaticTiles(x, y, true);
			var landTile = map.Tiles.GetLandTile(x, y);
			var landData = TileData.LandTable[landTile.ID & TileData.MaxLandValue];
			var landBlocks = (landData.Flags & TileFlag.Impassable) != 0;
			var considerLand = !landTile.Ignored;

			if (landBlocks && canSwim && (landData.Flags & TileFlag.Wet) != 0)
			{
				//Impassable, Can Swim, and Is water.  Don't block it.
				landBlocks = false;
			}
			else if (cantWalk && (landData.Flags & TileFlag.Wet) == 0)
			{
				//Can't walk and it's not water
				landBlocks = true;
			}

			int landZ = 0, landCenter = 0, landTop = 0;

			map.GetAverageZ(x, y, ref landZ, ref landCenter, ref landTop);

			var moveIsOk = false;

			var stepTop = startTop + StepHeight;
			var checkTop = startZ + PersonHeight;

			var ignoreDoors = MovementImpl.AlwaysIgnoreDoors || !m.Alive || m.IsDeadBondedPet || m.Body.IsGhost ||
							  m.Body.BodyID == 987;
			var ignoreSpellFields = m is PlayerMobile && map.MapID != 0;

			int itemZ, itemTop, ourZ, ourTop, testTop;
			ItemData itemData;
			TileFlag flags;

			#region Tiles
			foreach (var tile in tiles)
			{
				itemData = TileData.ItemTable[tile.ID & TileData.MaxItemValue];

				#region SA
				if (m.Flying && Insensitive.Equals(itemData.Name, "hover over"))
				{
					newZ = tile.Z;
					return true;
				}

				// Stygian Dragon
				if (m.Body == 826 && map != null && map.MapID == 5)
				{
					if (x >= 307 && x <= 354 && y >= 126 && y <= 192)
					{
						if (tile.Z > newZ)
						{
							newZ = tile.Z;
						}

						moveIsOk = true;
					}
					else if (x >= 42 && x <= 89)
					{
						if ((y >= 333 && y <= 399) || (y >= 531 && y <= 597) || (y >= 739 && y <= 805))
						{
							if (tile.Z > newZ)
							{
								newZ = tile.Z;
							}

							moveIsOk = true;
						}
					}
				}
				#endregion

				flags = itemData.Flags;

				if ((flags & ImpassableSurface) != TileFlag.Surface && (!canSwim || (flags & TileFlag.Wet) == 0))
				{
					continue;
				}

				if (cantWalk && (flags & TileFlag.Wet) == 0)
				{
					continue;
				}

				itemZ = tile.Z;
				itemTop = itemZ;
				ourZ = itemZ + itemData.CalcHeight;
				ourTop = ourZ + PersonHeight;
				testTop = checkTop;

				if (moveIsOk)
				{
					var cmp = Math.Abs(ourZ - m.Z) - Math.Abs(newZ - m.Z);

					if (cmp > 0 || (cmp == 0 && ourZ > newZ))
					{
						continue;
					}
				}

				if (ourTop > testTop)
				{
					testTop = ourTop;
				}

				if (!itemData.Bridge)
				{
					itemTop += itemData.Height;
				}

				if (stepTop < itemTop)
				{
					continue;
				}

				var landCheck = itemZ;

				if (itemData.Height >= StepHeight)
				{
					landCheck += StepHeight;
				}
				else
				{
					landCheck += itemData.Height;
				}

				if (considerLand && landCheck < landCenter && landCenter > ourZ && testTop > landZ)
				{
					continue;
				}

				if (!IsOk(ignoreDoors, ignoreSpellFields, ourZ, testTop, tiles, items))
				{
					continue;
				}

				newZ = ourZ;
				moveIsOk = true;
			}
			#endregion

			#region Items
			foreach (var item in items)
			{
				itemData = item.ItemData;
				flags = itemData.Flags;

				#region SA
				if (m.Flying && Insensitive.Equals(itemData.Name, "hover over"))
				{
					newZ = item.Z;
					return true;
				}
				#endregion

				if (item.Movable)
				{
					continue;
				}

				if ((flags & ImpassableSurface) != TileFlag.Surface && (!m.CanSwim || (flags & TileFlag.Wet) == 0))
				{
					continue;
				}

				if (cantWalk && (flags & TileFlag.Wet) == 0)
				{
					continue;
				}

				itemZ = item.Z;
				itemTop = itemZ;
				ourZ = itemZ + itemData.CalcHeight;
				ourTop = ourZ + PersonHeight;
				testTop = checkTop;

				if (moveIsOk)
				{
					var cmp = Math.Abs(ourZ - m.Z) - Math.Abs(newZ - m.Z);

					if (cmp > 0 || (cmp == 0 && ourZ > newZ))
					{
						continue;
					}
				}

				if (ourTop > testTop)
				{
					testTop = ourTop;
				}

				if (!itemData.Bridge)
				{
					itemTop += itemData.Height;
				}

				if (stepTop < itemTop)
				{
					continue;
				}

				var landCheck = itemZ;

				if (itemData.Height >= StepHeight)
				{
					landCheck += StepHeight;
				}
				else
				{
					landCheck += itemData.Height;
				}

				if (considerLand && landCheck < landCenter && landCenter > ourZ && testTop > landZ)
				{
					continue;
				}

				if (!IsOk(ignoreDoors, ignoreSpellFields, ourZ, testTop, tiles, items))
				{
					continue;
				}

				newZ = ourZ;
				moveIsOk = true;
			}
			#endregion

			if (!considerLand || landBlocks || stepTop < landZ)
			{
				return moveIsOk;
			}

			ourZ = landCenter;
			ourTop = ourZ + PersonHeight;
			testTop = checkTop;

			if (ourTop > testTop)
			{
				testTop = ourTop;
			}

			var shouldCheck = true;

			if (moveIsOk)
			{
				var cmp = Math.Abs(ourZ - m.Z) - Math.Abs(newZ - m.Z);

				if (cmp > 0 || (cmp == 0 && ourZ > newZ))
				{
					shouldCheck = false;
				}
			}

			if (!shouldCheck || !IsOk(ignoreDoors, ignoreSpellFields, ourZ, testTop, tiles, items))
			{
				return moveIsOk;
			}

			newZ = ourZ;
			moveIsOk = true;

			return moveIsOk;
		}

		public bool CheckMovement(Mobile m, Map map, Point3D loc, Direction d, out int newZ)
		{
			if (!Enabled && _Successor != null)
			{
				return _Successor.CheckMovement(m, map, loc, d, out newZ);
			}

			if (map == null || map == Map.Internal)
			{
				newZ = 0;
				return false;
			}

			var xStart = loc.X;
			var yStart = loc.Y;

			int xForward = xStart, yForward = yStart;
			int xRight = xStart, yRight = yStart;
			int xLeft = xStart, yLeft = yStart;

			var checkDiagonals = ((int)d & 0x1) == 0x1;

			Offset(d, ref xForward, ref yForward);
			Offset((Direction)(((int)d - 1) & 0x7), ref xLeft, ref yLeft);
			Offset((Direction)(((int)d + 1) & 0x7), ref xRight, ref yRight);

			if (xForward < 0 || yForward < 0 || xForward >= map.Width || yForward >= map.Height)
			{
				newZ = 0;
				return false;
			}

			int startZ, startTop;

			IEnumerable<Item> itemsStart, itemsForward, itemsLeft, itemsRight;

			var ignoreMovableImpassables = MovementImpl.IgnoreMovableImpassables;
			var reqFlags = ImpassableSurface;

			if (m.CanSwim)
			{
				reqFlags |= TileFlag.Wet;
			}

			if (checkDiagonals)
			{
				var sStart = map.GetSector(xStart, yStart);
				var sForward = map.GetSector(xForward, yForward);
				var sLeft = map.GetSector(xLeft, yLeft);
				var sRight = map.GetSector(xRight, yRight);

				itemsStart = sStart.Items.Where(i => Verify(i, reqFlags, ignoreMovableImpassables, xStart, yStart));
				itemsForward = sForward.Items.Where(i => Verify(i, reqFlags, ignoreMovableImpassables, xForward, yForward));
				itemsLeft = sLeft.Items.Where(i => Verify(i, reqFlags, ignoreMovableImpassables, xLeft, yLeft));
				itemsRight = sRight.Items.Where(i => Verify(i, reqFlags, ignoreMovableImpassables, xRight, yRight));
			}
			else
			{
				var sStart = map.GetSector(xStart, yStart);
				var sForward = map.GetSector(xForward, yForward);

				itemsStart = sStart.Items.Where(i => Verify(i, reqFlags, ignoreMovableImpassables, xStart, yStart));
				itemsForward = sForward.Items.Where(i => Verify(i, reqFlags, ignoreMovableImpassables, xForward, yForward));
				itemsLeft = Enumerable.Empty<Item>();
				itemsRight = Enumerable.Empty<Item>();
			}

			GetStartZ(m, map, loc, itemsStart, out startZ, out startTop);

			List<Item> list = null;

			MovementPool.AcquireMoveCache(ref list, itemsForward);

			var moveIsOk = Check(map, m, list, xForward, yForward, startTop, startZ, m.CanSwim, m.CantWalk, out newZ);

			if (moveIsOk && checkDiagonals)
			{
				int hold;

				if (m.Player && m.AccessLevel < AccessLevel.GameMaster)
				{
					MovementPool.AcquireMoveCache(ref list, itemsLeft);

					if (!Check(map, m, list, xLeft, yLeft, startTop, startZ, m.CanSwim, m.CantWalk, out hold))
					{
						moveIsOk = false;
					}
					else
					{
						MovementPool.AcquireMoveCache(ref list, itemsRight);

						if (!Check(map, m, list, xRight, yRight, startTop, startZ, m.CanSwim, m.CantWalk, out hold))
						{
							moveIsOk = false;
						}
					}
				}
				else
				{
					MovementPool.AcquireMoveCache(ref list, itemsLeft);

					if (!Check(map, m, list, xLeft, yLeft, startTop, startZ, m.CanSwim, m.CantWalk, out hold))
					{
						MovementPool.AcquireMoveCache(ref list, itemsRight);

						if (!Check(map, m, list, xRight, yRight, startTop, startZ, m.CanSwim, m.CantWalk, out hold))
						{
							moveIsOk = false;
						}
					}
				}
			}

			MovementPool.ClearMoveCache(ref list, true);

			if (!moveIsOk)
			{
				newZ = startZ;
			}

			return moveIsOk;
		}

		public bool CheckMovement(Mobile m, Direction d, out int newZ)
		{
			if (!Enabled && _Successor != null)
			{
				return _Successor.CheckMovement(m, d, out newZ);
			}

			return CheckMovement(m, m.Map, m.Location, d, out newZ);
		}

		private static bool Verify(Item item, int x, int y)
		{
			return item != null && item.AtWorldPoint(x, y);
		}

		private static bool Verify(Item item, TileFlag reqFlags, bool ignoreMovableImpassables)
		{
			if (item == null)
			{
				return false;
			}

			if (ignoreMovableImpassables && item.Movable && item.ItemData.Impassable)
			{
				return false;
			}

			if ((item.ItemData.Flags & reqFlags) == 0)
			{
				return false;
			}

			if (item is BaseMulti || item.ItemID > TileData.MaxItemValue)
			{
				return false;
			}

			return true;
		}

		private static bool Verify(Item item, TileFlag reqFlags, bool ignoreMovableImpassables, int x, int y)
		{
			return Verify(item, reqFlags, ignoreMovableImpassables) && Verify(item, x, y);
		}

		private static void GetStartZ(Mobile m, Map map, Point3D loc, IEnumerable<Item> itemList, out int zLow, out int zTop)
		{
			int xCheck = loc.X, yCheck = loc.Y;

			var landTile = map.Tiles.GetLandTile(xCheck, yCheck);
			var landData = TileData.LandTable[landTile.ID & TileData.MaxLandValue];
			var landBlocks = (landData.Flags & TileFlag.Impassable) != 0;

			if (landBlocks && m.CanSwim && (landData.Flags & TileFlag.Wet) != 0)
			{
				landBlocks = false;
			}
			else if (m.CantWalk && (landData.Flags & TileFlag.Wet) == 0)
			{
				landBlocks = true;
			}

			int landZ = 0, landCenter = 0, landTop = 0;

			map.GetAverageZ(xCheck, yCheck, ref landZ, ref landCenter, ref landTop);

			var considerLand = !landTile.Ignored;

			var zCenter = zLow = zTop = 0;
			var isSet = false;

			if (considerLand && !landBlocks && loc.Z >= landCenter)
			{
				zLow = landZ;
				zCenter = landCenter;
				zTop = landTop;
				isSet = true;
			}

			var staticTiles = map.Tiles.GetStaticTiles(xCheck, yCheck, true);

			foreach (var tile in staticTiles)
			{
				var tileData = TileData.ItemTable[tile.ID & TileData.MaxItemValue];
				var calcTop = (tile.Z + tileData.CalcHeight);

				if (isSet && calcTop < zCenter)
				{
					continue;
				}

				if ((tileData.Flags & TileFlag.Surface) == 0 && (!m.CanSwim || (tileData.Flags & TileFlag.Wet) == 0))
				{
					continue;
				}

				if (loc.Z < calcTop)
				{
					continue;
				}

				if (m.CantWalk && (tileData.Flags & TileFlag.Wet) == 0)
				{
					continue;
				}

				zLow = tile.Z;
				zCenter = calcTop;

				var top = tile.Z + tileData.Height;

				if (!isSet || top > zTop)
				{
					zTop = top;
				}

				isSet = true;
			}

			ItemData itemData;

			foreach (var item in itemList)
			{
				itemData = item.ItemData;

				var calcTop = item.Z + itemData.CalcHeight;

				if (isSet && calcTop < zCenter)
				{
					continue;
				}

				if ((itemData.Flags & TileFlag.Surface) == 0 && (!m.CanSwim || (itemData.Flags & TileFlag.Wet) == 0))
				{
					continue;
				}

				if (loc.Z < calcTop)
				{
					continue;
				}

				if (m.CantWalk && (itemData.Flags & TileFlag.Wet) == 0)
				{
					continue;
				}

				zLow = item.Z;
				zCenter = calcTop;

				var top = item.Z + itemData.Height;

				if (!isSet || top > zTop)
				{
					zTop = top;
				}

				isSet = true;
			}

			if (!isSet)
			{
				zLow = zTop = loc.Z;
			}
			else if (loc.Z > zTop)
			{
				zTop = loc.Z;
			}
		}

		public void Offset(Direction d, ref int x, ref int y)
		{
			switch (d & Direction.Mask)
			{
				case Direction.North:
					--y;
					break;
				case Direction.South:
					++y;
					break;
				case Direction.West:
					--x;
					break;
				case Direction.East:
					++x;
					break;
				case Direction.Right:
					++x;
					--y;
					break;
				case Direction.Left:
					--x;
					++y;
					break;
				case Direction.Down:
					++x;
					++y;
					break;
				case Direction.Up:
					--x;
					--y;
					break;
			}
		}

		private static class MovementPool
		{
			private static readonly object _MovePoolLock = new object();
			private static readonly Queue<List<Item>> _MoveCachePool = new Queue<List<Item>>(0x400);

			public static void AcquireMoveCache(ref List<Item> cache, IEnumerable<Item> items)
			{
				if (cache == null)
				{
					lock (_MovePoolLock)
					{
						cache = _MoveCachePool.Count > 0 ? _MoveCachePool.Dequeue() : new List<Item>(0x10);
					}
				}
				else
				{
					cache.Clear();
				}

				cache.AddRange(items);
			}

			public static void ClearMoveCache(ref List<Item> cache, bool free)
			{
				if (cache != null)
				{
					cache.Clear();
				}

				if (!free)
				{
					return;
				}

				lock (_MovePoolLock)
				{
					if (_MoveCachePool.Count < 0x400)
					{
						_MoveCachePool.Enqueue(cache);
					}
				}

				cache = null;
			}
		}
	}
}