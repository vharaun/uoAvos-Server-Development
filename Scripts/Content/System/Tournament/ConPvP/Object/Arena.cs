using Server.Gumps;
using Server.Mobiles;
using Server.Network;

using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Engines.ConPVP
{
	public class ArenaController : Item
	{
		private Arena m_Arena;
		private bool m_IsPrivate;

		[CommandProperty(AccessLevel.GameMaster)]
		public Arena Arena { get => m_Arena; set { } }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsPrivate { get => m_IsPrivate; set => m_IsPrivate = value; }

		public override string DefaultName => "arena controller";

		[Constructable]
		public ArenaController() : base(0x1B7A)
		{
			Visible = false;
			Movable = false;

			m_Arena = new Arena();

			m_Instances.Add(this);
		}

		public override void OnDelete()
		{
			base.OnDelete();

			m_Instances.Remove(this);
			m_Arena.Delete();
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from.AccessLevel >= AccessLevel.GameMaster)
			{
				from.SendGump(new Gumps.PropertiesGump(from, m_Arena));
			}
		}

		public ArenaController(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1);

			writer.Write(m_IsPrivate);

			m_Arena.Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_IsPrivate = reader.ReadBool();

						goto case 0;
					}
				case 0:
					{
						m_Arena = new Arena(reader);
						break;
					}
			}

			m_Instances.Add(this);
		}

		private static List<ArenaController> m_Instances = new List<ArenaController>();

		public static List<ArenaController> Instances { get => m_Instances; set => m_Instances = value; }
	}

	[PropertyObject]
	public class ArenaStartPoints
	{
		private readonly Point3D[] m_Points;

		public Point3D[] Points => m_Points;

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D EdgeWest { get => m_Points[0]; set => m_Points[0] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D EdgeEast { get => m_Points[1]; set => m_Points[1] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D EdgeNorth { get => m_Points[2]; set => m_Points[2] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D EdgeSouth { get => m_Points[3]; set => m_Points[3] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D CornerNW { get => m_Points[4]; set => m_Points[4] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D CornerSE { get => m_Points[5]; set => m_Points[5] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D CornerSW { get => m_Points[6]; set => m_Points[6] = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D CornerNE { get => m_Points[7]; set => m_Points[7] = value; }

		public override string ToString()
		{
			return "...";
		}

		public ArenaStartPoints() : this(new Point3D[8])
		{
		}

		public ArenaStartPoints(Point3D[] points)
		{
			m_Points = points;
		}

		public ArenaStartPoints(GenericReader reader)
		{
			m_Points = new Point3D[reader.ReadEncodedInt()];

			for (var i = 0; i < m_Points.Length; ++i)
			{
				m_Points[i] = reader.ReadPoint3D();
			}
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(m_Points.Length);

			for (var i = 0; i < m_Points.Length; ++i)
			{
				writer.Write(m_Points[i]);
			}
		}
	}

	[PropertyObject]
	public class Arena : IComparable
	{
		private Map m_Facet;
		private Rectangle2D m_Bounds;
		private Rectangle2D m_Zone;
		private Point3D m_Outside;
		private Point3D m_Wall;
		private Point3D m_GateIn;
		private Point3D m_GateOut;
		private readonly ArenaStartPoints m_Points;
		private bool m_Active;
		private string m_Name;

		private bool m_IsGuarded;

		private Item m_Teleporter;

		private readonly List<Mobile> m_Players;

		private TournamentController m_Tournament;
		private Mobile m_Announcer;

		private LadderController m_Ladder;

		[CommandProperty(AccessLevel.GameMaster)]
		public LadderController Ladder
		{
			get => m_Ladder;
			set => m_Ladder = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsGuarded
		{
			get => m_IsGuarded;
			set
			{
				m_IsGuarded = value;

				if (m_Region != null)
				{
					m_Region.Disabled = !m_IsGuarded;
				}
			}
		}

		public Ladder AcquireLadder()
		{
			if (m_Ladder != null)
			{
				return m_Ladder.Ladder;
			}

			return Server.Engines.ConPVP.Ladder.Instance;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public TournamentController Tournament
		{
			get => m_Tournament;
			set
			{
				if (m_Tournament != null)
				{
					m_Tournament.Tournament.Arenas.Remove(this);
				}

				m_Tournament = value;

				if (m_Tournament != null)
				{
					m_Tournament.Tournament.Arenas.Add(this);
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Announcer
		{
			get => m_Announcer;
			set => m_Announcer = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string Name
		{
			get => m_Name;
			set
			{
				m_Name = value; if (m_Active)
				{
					m_Arenas.Sort();
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Map Facet
		{
			get => m_Facet;
			set
			{
				m_Facet = value;

				if (m_Teleporter != null)
				{
					m_Teleporter.Map = value;
				}

				if (m_Region != null)
				{
					m_Region.Delete();
					m_Region = null;
				}

				if (m_Zone.Start != Point2D.Zero && m_Zone.End != Point2D.Zero && m_Facet != null)
				{
					m_Region = new SafeZone(m_Zone, m_Outside, m_Facet, m_IsGuarded);
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Rectangle2D Bounds { get => m_Bounds; set => m_Bounds = value; }

		private SafeZone m_Region;

		public int Spectators
		{
			get
			{
				if (m_Region == null)
				{
					return 0;
				}

				var specs = m_Region.GetPlayerCount() - m_Players.Count;

				if (specs < 0)
				{
					specs = 0;
				}

				return specs;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Rectangle2D Zone
		{
			get => m_Zone;
			set
			{
				m_Zone = value;

				if (m_Zone.Start != Point2D.Zero && m_Zone.End != Point2D.Zero && m_Facet != null)
				{
					if (m_Region != null)
					{
						m_Region.Delete();
						m_Region = null;
					}

					m_Region = new SafeZone(m_Zone, m_Outside, m_Facet, m_IsGuarded);
				}
				else
				{
					if (m_Region != null)
					{
						m_Region.Delete();
						m_Region = null;
					}
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D Outside { get => m_Outside; set => m_Outside = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D GateIn { get => m_GateIn; set => m_GateIn = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D GateOut { get => m_GateOut; set { m_GateOut = value; if (m_Teleporter != null) { m_Teleporter.Location = m_GateOut; } } }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D Wall { get => m_Wall; set => m_Wall = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsOccupied => (m_Players.Count > 0);

		[CommandProperty(AccessLevel.GameMaster)]
		public ArenaStartPoints Points { get => m_Points; set { } }

		public Item Teleporter { get => m_Teleporter; set => m_Teleporter = value; }

		public List<Mobile> Players => m_Players;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Active
		{
			get => m_Active;
			set
			{
				if (m_Active == value)
				{
					return;
				}

				m_Active = value;

				if (m_Active)
				{
					m_Arenas.Add(this);
					m_Arenas.Sort();
				}
				else
				{
					m_Arenas.Remove(this);
				}
			}
		}

		public void Delete()
		{
			Active = false;

			if (m_Region != null)
			{
				m_Region.Delete();
				m_Region = null;
			}
		}

		public override string ToString()
		{
			return "...";
		}

		public Point3D GetBaseStartPoint(int index)
		{
			if (index < 0)
			{
				index = 0;
			}

			return m_Points.Points[index % m_Points.Points.Length];
		}

		#region Offsets & Rotation
		private static readonly Point2D[] m_EdgeOffsets = new Point2D[]
			{
				/*
				 *        /\
				 *       /\/\
				 *      /\/\/\
				 *      \/\/\/
				 *       \/\/\
				 *        \/\/
				 */
				new Point2D( 0, 0 ),
				new Point2D( 0, -1 ),
				new Point2D( 0, +1 ),
				new Point2D( 1, 0 ),
				new Point2D( 1, -1 ),
				new Point2D( 1, +1 ),
				new Point2D( 2, 0 ),
				new Point2D( 2, -1 ),
				new Point2D( 2, +1 ),
				new Point2D( 3, 0 )
			};

		// nw corner
		private static readonly Point2D[] m_CornerOffsets = new Point2D[]
			{
				/*
				 *         /\
				 *        /\/\
				 *       /\/\/\
				 *      /\/\/\/\
				 *      \/\/\/\/
				 */
				new Point2D( 0, 0 ),
				new Point2D( 0, 1 ),
				new Point2D( 1, 0 ),
				new Point2D( 1, 1 ),
				new Point2D( 0, 2 ),
				new Point2D( 2, 0 ),
				new Point2D( 2, 1 ),
				new Point2D( 1, 2 ),
				new Point2D( 0, 3 ),
				new Point2D( 3, 0 )
			};

		private static readonly int[][,] m_Rotate = new int[][,]
			{
				new int[,]{ { +1, 0 }, { 0, +1 } }, // west
				new int[,]{ { -1, 0 }, { 0, -1 } }, // east
				new int[,]{ { 0, +1 }, { +1, 0 } }, // north
				new int[,]{ { 0, -1 }, { -1, 0 } }, // south
				new int[,]{ { +1, 0 }, { 0, +1 } }, // nw
				new int[,]{ { -1, 0 }, { 0, -1 } }, // se
				new int[,]{ { 0, +1 }, { +1, 0 } }, // sw
				new int[,]{ { 0, -1 }, { -1, 0 } }, // ne
			};
		#endregion

		public void MoveInside(DuelPlayer[] players, int index)
		{
			if (index < 0)
			{
				index = 0;
			}
			else
			{
				index %= m_Points.Points.Length;
			}

			var start = GetBaseStartPoint(index);

			var offset = 0;

			var offsets = (index < 4) ? m_EdgeOffsets : m_CornerOffsets;
			var matrix = m_Rotate[index];

			for (var i = 0; i < players.Length; ++i)
			{
				var pl = players[i];

				if (pl == null)
				{
					continue;
				}

				var mob = pl.Mobile;

				Point2D p;

				if (offset < offsets.Length)
				{
					p = offsets[offset++];
				}
				else
				{
					p = offsets[offsets.Length - 1];
				}

				p.X = (p.X * matrix[0, 0]) + (p.Y * matrix[0, 1]);
				p.Y = (p.X * matrix[1, 0]) + (p.Y * matrix[1, 1]);

				mob.MoveToWorld(new Point3D(start.X + p.X, start.Y + p.Y, start.Z), m_Facet);
				mob.Direction = mob.GetDirectionTo(m_Wall);

				m_Players.Add(mob);
			}
		}

		public Arena()
		{
			m_Points = new ArenaStartPoints();
			m_Players = new List<Mobile>();
		}

		public Arena(GenericReader reader)
		{
			var version = reader.ReadEncodedInt();

			switch (version)
			{
				case 8:
					{
						m_Region = reader.ReadRegion<SafeZone>();

						goto case 7;
					}
				case 7:
					{
						m_IsGuarded = reader.ReadBool();

						goto case 6;
					}
				case 6:
					{
						m_Ladder = reader.ReadItem() as LadderController;

						goto case 5;
					}
				case 5:
					{
						m_Tournament = reader.ReadItem() as TournamentController;
						m_Announcer = reader.ReadMobile();

						goto case 4;
					}
				case 4:
					{
						m_Name = reader.ReadString();

						goto case 3;
					}
				case 3:
					{
						m_Zone = reader.ReadRect2D();

						goto case 2;
					}
				case 2:
					{
						m_GateIn = reader.ReadPoint3D();
						m_GateOut = reader.ReadPoint3D();
						m_Teleporter = reader.ReadItem();

						goto case 1;
					}
				case 1:
					{
						m_Players = reader.ReadStrongMobileList();

						goto case 0;
					}
				case 0:
					{
						m_Facet = reader.ReadMap();
						m_Bounds = reader.ReadRect2D();
						m_Outside = reader.ReadPoint3D();
						m_Wall = reader.ReadPoint3D();

						if (version == 0)
						{
							reader.ReadBool();
							m_Players = new List<Mobile>();
						}

						m_Active = reader.ReadBool();
						m_Points = new ArenaStartPoints(reader);

						if (m_Active)
						{
							m_Arenas.Add(this);
							m_Arenas.Sort();
						}

						break;
					}
			}

			if (IsOccupied)
			{
				Timer.DelayCall(TimeSpan.FromSeconds(2.0), Evict);
			}

			if (m_Region == null)
			{
				Timer.DelayCall(UpdateRegion_Sandbox);
			}

			if (m_Tournament != null)
			{
				Timer.DelayCall(AttachToTournament_Sandbox);
			}
		}

		private void UpdateRegion_Sandbox()
		{
			if (m_Region == null && m_Zone.Start != Point2D.Zero && m_Zone.End != Point2D.Zero && m_Facet != null)
			{
				m_Region = new SafeZone(m_Zone, m_Outside, m_Facet, m_IsGuarded);
			}
		}

		private void AttachToTournament_Sandbox()
		{
			if (m_Tournament != null)
			{
				m_Tournament.Tournament.Arenas.Add(this);
			}
		}

		[CommandProperty(AccessLevel.Administrator, AccessLevel.Administrator)]
		public bool ForceEvict { get => false; set { if (value) { Evict(); } } }

		public void Evict()
		{
			Point3D loc;
			Map facet;

			if (m_Facet == null)
			{
				loc = new Point3D(2715, 2165, 0);
				facet = Map.Felucca;
			}
			else
			{
				loc = m_Outside;
				facet = m_Facet;
			}

			var hasBounds = (m_Bounds.Start != Point2D.Zero && m_Bounds.End != Point2D.Zero);

			for (var i = 0; i < m_Players.Count; ++i)
			{
				var mob = m_Players[i];

				if (mob == null)
				{
					continue;
				}

				if (mob.Map == Map.Internal)
				{
					if ((m_Facet == null || mob.LogoutMap == m_Facet) && (!hasBounds || m_Bounds.Contains(mob.LogoutLocation)))
					{
						mob.LogoutLocation = loc;
					}
				}
				else if ((m_Facet == null || mob.Map == m_Facet) && (!hasBounds || m_Bounds.Contains(mob.Location)))
				{
					mob.MoveToWorld(loc, facet);
				}

				mob.Combatant = null;
				mob.Frozen = false;
				DuelContext.Debuff(mob);
				DuelContext.CancelSpell(mob);
			}

			if (hasBounds)
			{
				var pets = new List<Mobile>();

				foreach (var mob in facet.GetMobilesInBounds(m_Bounds))
				{
					var pet = mob as BaseCreature;

					if (pet != null && pet.Controlled && pet.ControlMaster != null)
					{
						if (m_Players.Contains(pet.ControlMaster))
						{
							pets.Add(pet);
						}
					}
				}

				foreach (var pet in pets)
				{
					pet.Combatant = null;
					pet.Frozen = false;

					pet.MoveToWorld(loc, facet);
				}
			}

			m_Players.Clear();
		}

		public void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(8);

			writer.Write(m_Region);

			writer.Write(m_IsGuarded);

			writer.Write(m_Ladder);

			writer.Write(m_Tournament);
			writer.Write(m_Announcer);

			writer.Write(m_Name);

			writer.Write(m_Zone);

			writer.Write(m_GateIn);
			writer.Write(m_GateOut);
			writer.Write(m_Teleporter);

			writer.Write(m_Players);

			writer.Write(m_Facet);
			writer.Write(m_Bounds);
			writer.Write(m_Outside);
			writer.Write(m_Wall);
			writer.Write(m_Active);

			m_Points.Serialize(writer);
		}

		private static readonly List<Arena> m_Arenas = new List<Arena>();

		public static List<Arena> Arenas => m_Arenas;

		public static Arena FindArena(List<Mobile> players)
		{
			var prefs = Preferences.Instance;

			if (prefs == null)
			{
				return FindArena();
			}

			if (m_Arenas.Count == 0)
			{
				return null;
			}

			if (players.Count > 0)
			{
				var first = players[0];

				var allControllers = ArenaController.Instances;

				for (var i = 0; i < allControllers.Count; ++i)
				{
					var controller = allControllers[i];

					if (controller != null && !controller.Deleted && controller.Arena != null && controller.IsPrivate && controller.Map == first.Map && first.InRange(controller, 24))
					{
						var house = Multis.BaseHouse.FindHouseAt(controller);
						var allNear = true;

						for (var j = 0; j < players.Count; ++j)
						{
							var check = players[j];
							bool isNear;

							if (house == null)
							{
								isNear = (controller.Map == check.Map && check.InRange(controller, 24));
							}
							else
							{
								isNear = (Multis.BaseHouse.FindHouseAt(check) == house);
							}

							if (!isNear)
							{
								allNear = false;
								break;
							}
						}

						if (allNear)
						{
							return controller.Arena;
						}
					}
				}
			}

			var arenas = new List<ArenaEntry>();

			for (var i = 0; i < m_Arenas.Count; ++i)
			{
				var arena = m_Arenas[i];

				if (!arena.IsOccupied)
				{
					arenas.Add(new ArenaEntry(arena));
				}
			}

			if (arenas.Count == 0)
			{
				return m_Arenas[0];
			}

			var tc = 0;

			for (var i = 0; i < arenas.Count; ++i)
			{
				var ae = arenas[i];

				for (var j = 0; j < players.Count; ++j)
				{
					var pe = prefs.Find(players[j]);

					if (pe.Disliked.Contains(ae.m_Arena.Name))
					{
						++ae.m_VotesAgainst;
					}
					else
					{
						++ae.m_VotesFor;
					}
				}

				tc += ae.Value;
			}

			var rn = Utility.Random(tc);

			for (var i = 0; i < arenas.Count; ++i)
			{
				var ae = arenas[i];

				if (rn < ae.Value)
				{
					return ae.m_Arena;
				}

				rn -= ae.Value;
			}

			return arenas[Utility.Random(arenas.Count)].m_Arena;
		}

		private class ArenaEntry
		{
			public Arena m_Arena;
			public int m_VotesFor;
			public int m_VotesAgainst;

			public int Value => m_VotesFor;/*if ( m_VotesFor > m_VotesAgainst )
						return m_VotesFor - m_VotesAgainst;
					else if ( m_VotesFor > 0 )
						return 1;
					else
						return 0;*/

			public ArenaEntry(Arena arena)
			{
				m_Arena = arena;
			}
		}

		public static Arena FindArena()
		{
			if (m_Arenas.Count == 0)
			{
				return null;
			}

			var offset = Utility.Random(m_Arenas.Count);

			for (var i = 0; i < m_Arenas.Count; ++i)
			{
				var arena = m_Arenas[(i + offset) % m_Arenas.Count];

				if (!arena.IsOccupied)
				{
					return arena;
				}
			}

			return m_Arenas[offset];
		}

		public int CompareTo(object obj)
		{
			var c = (Arena)obj;

			var a = m_Name;
			var b = c.m_Name;

			if (a == null && b == null)
			{
				return 0;
			}
			else if (a == null)
			{
				return -1;
			}
			else if (b == null)
			{
				return +1;
			}

			return a.CompareTo(b);
		}
	}

	public class ArenasMoongate : Item
	{
		public override string DefaultName => "arena moongate";

		[Constructable]
		public ArenasMoongate() : base(0x1FD4)
		{
			Movable = false;
			Light = LightType.Circle300;
		}

		public ArenasMoongate(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
			Light = LightType.Circle300;
		}

		public bool UseGate(Mobile from)
		{
			if (DuelContext.CheckCombat(from))
			{
				from.SendMessage(0x22, "You have recently been in combat with another player and cannot use this moongate.");
				return false;
			}
			else if (from.Spell != null)
			{
				from.SendLocalizedMessage(1049616); // You are too busy to do that at the moment.
				return false;
			}
			else
			{
				from.CloseGump(typeof(ArenaGump));
				from.SendGump(new ArenaGump(from, this));

				if (!from.Hidden || from.AccessLevel == AccessLevel.Player)
				{
					Effects.PlaySound(from.Location, from.Map, 0x20E);
				}

				return true;
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from.InRange(GetWorldLocation(), 1))
			{
				UseGate(from);
			}
			else
			{
				from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that
			}
		}

		public override bool OnMoveOver(Mobile m)
		{
			return (!m.Player || UseGate(m));
		}
	}

	public class ArenaGump : Gump
	{
		private readonly Mobile m_From;
		private readonly ArenasMoongate m_Gate;
		private readonly List<Arena> m_Arenas;

		private void Append(StringBuilder sb, LadderEntry le)
		{
			if (le == null)
			{
				return;
			}

			if (sb.Length > 0)
			{
				sb.Append(", ");
			}

			sb.Append(le.Mobile.Name);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID != 1)
			{
				return;
			}

			var switches = info.Switches;

			if (switches.Length == 0)
			{
				return;
			}

			var opt = switches[0];

			if (opt < 0 || opt >= m_Arenas.Count)
			{
				return;
			}

			var arena = m_Arenas[opt];

			if (!m_From.InRange(m_Gate.GetWorldLocation(), 1) || m_From.Map != m_Gate.Map)
			{
				m_From.SendLocalizedMessage(1019002); // You are too far away to use the gate.
			}
			else if (DuelContext.CheckCombat(m_From))
			{
				m_From.SendMessage(0x22, "You have recently been in combat with another player and cannot use this moongate.");
			}
			else if (m_From.Spell != null)
			{
				m_From.SendLocalizedMessage(1049616); // You are too busy to do that at the moment.
			}
			else if (m_From.Map == arena.Facet && arena.Zone.Contains(m_From))
			{
				m_From.SendLocalizedMessage(1019003); // You are already there.
			}
			else
			{
				BaseCreature.TeleportPets(m_From, arena.GateIn, arena.Facet);

				m_From.Combatant = null;
				m_From.Warmode = false;
				m_From.Hidden = true;

				m_From.MoveToWorld(arena.GateIn, arena.Facet);

				Effects.PlaySound(arena.GateIn, arena.Facet, 0x1FE);
			}
		}

		public ArenaGump(Mobile from, ArenasMoongate gate) : base(50, 50)
		{
			m_From = from;
			m_Gate = gate;
			m_Arenas = Arena.Arenas;

			AddPage(0);

			var height = 12 + 20 + (m_Arenas.Count * 31) + 24 + 12;

			AddBackground(0, 0, 499 + 40, height, 0x2436);

			var list = m_Arenas;

			for (var i = 1; i < list.Count; i += 2)
			{
				AddImageTiled(12, 32 + (i * 31), 475 + 40, 30, 0x2430);
			}

			AddAlphaRegion(10, 10, 479 + 40, height - 20);

			AddColumnHeader(35, null);
			AddColumnHeader(115, "Arena");
			AddColumnHeader(325, "Participants");
			AddColumnHeader(40, "Obs");

			AddButton(499 + 40 - 12 - 63 - 4 - 63, height - 12 - 24, 247, 248, 1, GumpButtonType.Reply, 0);
			AddButton(499 + 40 - 12 - 63, height - 12 - 24, 241, 242, 2, GumpButtonType.Reply, 0);

			for (var i = 0; i < list.Count; ++i)
			{
				var ar = list[i];

				var name = ar.Name;

				if (name == null)
				{
					name = "(no name)";
				}

				var x = 12;
				var y = 32 + (i * 31);

				var color = (ar.Players.Count > 0 ? 0xCCFFCC : 0xCCCCCC);

				AddRadio(x + 3, y + 1, 9727, 9730, false, i);
				x += 35;

				AddBorderedText(x + 5, y + 5, 115 - 5, name, color, 0);
				x += 115;

				var sb = new StringBuilder();

				if (ar.Players.Count > 0)
				{
					var ladder = Ladder.Instance;

					if (ladder == null)
					{
						continue;
					}

					LadderEntry p1 = null, p2 = null, p3 = null, p4 = null;

					for (var j = 0; j < ar.Players.Count; ++j)
					{
						var mob = ar.Players[j];
						var c = ladder.Find(mob);

						if (p1 == null || c.Index < p1.Index)
						{
							p4 = p3;
							p3 = p2;
							p2 = p1;
							p1 = c;
						}
						else if (p2 == null || c.Index < p2.Index)
						{
							p4 = p3;
							p3 = p2;
							p2 = c;
						}
						else if (p3 == null || c.Index < p3.Index)
						{
							p4 = p3;
							p3 = c;
						}
						else if (p4 == null || c.Index < p4.Index)
						{
							p4 = c;
						}
					}

					Append(sb, p1);
					Append(sb, p2);
					Append(sb, p3);
					Append(sb, p4);

					if (ar.Players.Count > 4)
					{
						sb.Append(", ...");
					}
				}
				else
				{
					sb.Append("Empty");
				}

				AddBorderedText(x + 5, y + 5, 325 - 5, sb.ToString(), color, 0);
				x += 325;

				AddBorderedText(x, y + 5, 40, Center(ar.Spectators.ToString()), color, 0);
			}
		}

		public string Center(string text)
		{
			return String.Format("<CENTER>{0}</CENTER>", text);
		}

		public string Color(string text, int color)
		{
			return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
		}

		private void AddBorderedText(int x, int y, int width, string text, int color, int borderColor)
		{
			/*AddColoredText( x - 1, y, width, text, borderColor );
			AddColoredText( x + 1, y, width, text, borderColor );
			AddColoredText( x, y - 1, width, text, borderColor );
			AddColoredText( x, y + 1, width, text, borderColor );*/
			/*AddColoredText( x - 1, y - 1, width, text, borderColor );
			AddColoredText( x + 1, y + 1, width, text, borderColor );*/
			AddColoredText(x, y, width, text, color);
		}

		private void AddColoredText(int x, int y, int width, string text, int color)
		{
			if (color == 0)
			{
				AddHtml(x, y, width, 20, text, false, false);
			}
			else
			{
				AddHtml(x, y, width, 20, Color(text, color), false, false);
			}
		}

		private int m_ColumnX = 12;

		private void AddColumnHeader(int width, string name)
		{
			AddBackground(m_ColumnX, 12, width, 20, 0x242C);
			AddImageTiled(m_ColumnX + 2, 14, width - 4, 16, 0x2430);

			if (name != null)
			{
				AddBorderedText(m_ColumnX, 13, width, Center(name), 0xFFFFFF, 0);
			}

			m_ColumnX += width;
		}
	}
}