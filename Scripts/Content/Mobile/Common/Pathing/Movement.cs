using Server.Commands;
using Server.Items;
using Server.Misc;
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

		public double ActiveSpeed { get; set; }

		public double PassiveSpeed { get; set; }

		public Type[] Types { get; set; }

		public SpeedInfo(double activeSpeed, double passiveSpeed, Type[] types)
		{
			ActiveSpeed = activeSpeed;
			PassiveSpeed = passiveSpeed;
			Types = types;
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

			SpeedInfo sp;
			_ = m_Table.TryGetValue(obj.GetType(), out sp);

			return sp != null;
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

			SpeedInfo sp;
			_ = m_Table.TryGetValue(obj.GetType(), out sp);

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
		private Point3D m_Start;
		private Point3D m_Goal;

		public Map Map { get; }
		public Point3D Start => m_Start;
		public Point3D Goal => m_Goal;
		public Direction[] Directions { get; }
		public bool Success => Directions != null && Directions.Length > 0;

		public static void Initialize()
		{
			CommandSystem.Register("Path", AccessLevel.GameMaster, new CommandEventHandler(Path_OnCommand));
		}

		public static void Path_OnCommand(CommandEventArgs e)
		{
			_ = e.Mobile.BeginTarget(-1, true, TargetFlags.None, new TargetCallback(Path_OnTarget));
			e.Mobile.SendMessage("Target a location and a path will be drawn there.");
		}

		private static void Path(Mobile from, IPoint3D p, PathAlgorithm alg, string name, int zOffset)
		{
			OverrideAlgorithm = alg;

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
					CalcMoves.Offset(path.Directions[i], ref x, ref y);

					new RecallRune().MoveToWorld(new Point3D(x, y, z + zOffset), from.Map);
				}
			}
		}

		public static void Path_OnTarget(Mobile from, object obj)
		{
			if (obj is not IPoint3D p)
			{
				return;
			}

			Spells.SpellHelper.GetSurfaceTop(ref p);

			Path(from, p, FastAStarAlgorithm.Instance, "Fast", 0);
			Path(from, p, SlowAStarAlgorithm.Instance, "Slow", 2);
			OverrideAlgorithm = null;

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
				_ = from.Move(d);
				from.NetState.BlockAllPackets = false;
				from.ProcessDelta();
			}
			catch
			{
			}
		}

		public static PathAlgorithm OverrideAlgorithm { get; set; }

		public MovementPath(Mobile m, Point3D goal)
		{
			var start = m.Location;
			var map = m.Map;

			Map = map;
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
				var alg = OverrideAlgorithm;

				alg ??= FastAStarAlgorithm.Instance;

				if (alg != null && alg.CheckCondition(m, map, start, goal))
				{
					Directions = alg.Find(m, map, start, goal);
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
		private MovementPath m_Path;
		private int m_Index;
		private Point3D m_Next, m_LastGoalLoc;
		private DateTime m_LastPathTime;

		public MoveMethod Mover { get; set; }

		public IPoint3D Goal { get; }

		public PathFollower(Mobile from, IPoint3D goal)
		{
			m_From = from;
			Goal = goal;
		}

		public MoveResult Move(Direction d)
		{
			if (Mover == null)
			{
				return m_From.Move(d) ? MoveResult.Success : MoveResult.Blocked;
			}

			return Mover(d);
		}

		public Point3D GetGoalLocation()
		{
			if (Goal is Item g)
			{
				return g.GetWorldLocation();
			}

			return new Point3D(Goal);
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

		public static bool Check(Point3D loc, Point3D goal, int range)
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
				_ = Move(d);

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
				_ = CheckPath();

				if (!m_Path.Success)
				{
					d = m_From.GetDirectionTo(goal);

					if (run)
					{
						d |= Direction.Running;
					}

					m_From.SetDirection(d);
					_ = Move(d);

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
		private const int PersonHeight = CalcMoves.PersonHeight;
		private const int StepHeight = CalcMoves.StepHeight;

		private const TileFlag ImpassableSurface = TileFlag.Impassable | TileFlag.Surface;

		public static bool AlwaysIgnoreDoors { get; set; }
		public static bool IgnoreMovableImpassables { get; set; }
		public static bool IgnoreSpellFields { get; set; }

		public static Point3D Goal { get; set; }

		public static void Configure()
		{
			CalcMoves.Impl = new MovementImpl();
		}

		private MovementImpl()
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

			if (ignoreDoors && (itemData.Door || itemID == 0x692 || itemID == 0x846 || itemID == 0x873 || (itemID >= 0x6F5 && itemID <= 0x6F6)))
			{
				return true;
			}

			if (ignoreSpellFields && (itemID == 0x82 || itemID == 0x3946 || itemID == 0x3956))
			{
				return true;
			}

			return item.Z + itemData.CalcHeight <= ourZ || ourTop <= item.Z;
		}

		private static bool IsOk(bool ignoreDoors, bool ignoreSpellFields, int ourZ, int ourTop, IEnumerable<StaticTile> tiles, IEnumerable<Item> items)
		{
			return tiles.All(t => IsOk(t, ourZ, ourTop)) && items.All(i => IsOk(i, ourZ, ourTop, ignoreDoors, ignoreSpellFields));
		}

		private static bool? CheckFlying(Map map, BaseCreature c, List<Item> items, int x, int y, int _, int startZ, int flyingH, out int newZ)
		{
			var ignoreDoors = MovementImpl.AlwaysIgnoreDoors || !c.Alive || c.IsDeadBondedPet || c.Body.IsGhost || c.Body.BodyID == 987;

			bool? result = null;

			newZ = 0;

			var landTile = map.Tiles.GetLandTile(x, y);

			int landZ = 0, landCenter = 0, landTop = 0;

			map.GetAverageZ(x, y, ref landZ, ref landCenter, ref landTop);

			var testZ = startZ;

			if (!landTile.Ignored && landZ <= startZ)
			{
				var data = TileData.LandTable[landTile.ID & TileData.MaxLandValue];

				if (data.Impassable || data.Surface || data.Wet)
				{
					result = true;
					testZ = landZ + flyingH;
				}
			}

			var tiles = map.Tiles.GetStaticTiles(x, y, true);

			foreach (var tile in tiles)
			{
				var data = TileData.ItemTable[tile.ID & TileData.MaxItemValue];

				var id = tile.ID;

				if (ignoreDoors && (data.Door || id == 0x692 || id == 0x846 || id == 0x873 || (id >= 0x6F5 && id <= 0x6F6)))
				{
					continue;
				}

				if (!data.Impassable && !data.Wall && !data.Window && !data.Roof && !data.Door && !data.Surface && !data.Wet)
				{
					continue;
				}
				/*
				if (Geometry.Intersects(startZ, PersonHeight, tile))
				{
					result = false;
					break;
				}
				*/
				/*
				if (startZ != testZ && Geometry.Intersects(testZ, PersonHeight, tile))
				{
					result = false;
					break;
				}
				*/
				if (tile.Z > startZ)
				{
					continue;
				}

				testZ = tile.Z + flyingH;

				if (Geometry.GetHeight(tile, out var h))
				{
					testZ += h;
				}
			}

			foreach (var item in items)
			{
				if (item.Movable)
				{
					continue;
				}

				var data = item.ItemData;

				if (!data.Impassable && !data.Wall && !data.Window && !data.Roof && !data.Door && !data.Surface && !data.Wet)
				{
					continue;
				}

				var id = item.ItemID;

				if (ignoreDoors && (data.Door || id == 0x692 || id == 0x846 || id == 0x873 || (id >= 0x6F5 && id <= 0x6F6)))
				{
					continue;
				}
				/*
				if (Geometry.Intersects(startZ, PersonHeight, item))
				{
					result = false;
					break;
				}

				if (startZ != testZ && Geometry.Intersects(testZ, PersonHeight, item))
				{
					result = false;
					break;
				}
				*/
				if (item.Z > startZ)
				{
					continue;
				}

				testZ = item.Z + flyingH;

				if (Geometry.GetHeight(item, out var h))
				{
					testZ += h;
				}
			}

			if (result == true)
			{
				newZ = Math.Clamp(testZ, Region.MinZ + 1, Region.MaxZ - (PersonHeight + 1));
			}
			else
			{
				newZ = 0;
			}

			return result;
		}

		private static bool Check(Map map, Mobile m, List<Item> items, int x, int y, int startTop, int startZ, bool canSwim, bool cantWalk, out int newZ)
		{
			if (m is BaseCreature c && (c.Flying || c.FlyingHeightCur > 0))
			{
				var result = CheckFlying(map, c, items, x, y, startTop, startZ, c.FlyingHeightCur, out newZ);

				if (result != null)
				{
					return result.Value;
				}
			}

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

			var ignoreDoors = MovementImpl.AlwaysIgnoreDoors || !m.Alive || m.IsDeadBondedPet || m.Body.IsGhost || m.Body.BodyID == 987;
			var ignoreSpellFields = m is PlayerMobile && map.MapID != 0;

			int itemZ, itemTop, ourZ, ourTop, testTop;
			ItemData itemData;
			TileFlag flags;

			#region Tiles
			foreach (var tile in tiles)
			{
				itemData = TileData.ItemTable[tile.ID & TileData.MaxItemValue];

				if (m.Flying)
				{
					if (Insensitive.Equals(itemData.Name, "hover over"))
					{
						newZ = tile.Z;
						return true;
					}

					if (map != null && map.MapID == 5)
					{
						if (x >= 307 && x <= 354 && y >= 126 && y <= 192)
						{
							if (tile.Z > newZ)
							{
								newZ = tile.Z;
							}

							moveIsOk = true;
						}
						else if (x is >= 42 and <= 89)
						{
							if (y is (>= 333 and <= 399) or (>= 531 and <= 597) or (>= 739 and <= 805))
							{
								if (tile.Z > newZ)
								{
									newZ = tile.Z;
								}

								moveIsOk = true;
							}
						}
					}
				}

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

				if (m.Flying)
				{
					if (Insensitive.Equals(itemData.Name, "hover over"))
					{
						newZ = item.Z;
						return true;
					}
				}

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
				var calcTop = tile.Z + tileData.CalcHeight;

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

		public static void Offset(Direction d, ref int x, ref int y)
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
			private static readonly object _MovePoolLock = new();
			private static readonly Queue<List<Item>> _MoveCachePool = new(0x400);

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