using ActionAI;

using Server;
using Server.Engines.Harvest;
using Server.Items;
using Server.Misc;
using Server.Multis;

using System;
using System.Collections.Generic;

#region Developer Notations

#endregion

/// Description:
/// this mobile will harvest resources just as if they were real players on your server. They will appear
/// to place a camp, work (harvest their designated resource), move to pre-defined waypoints, and then when
/// their work is done they will return to their camp (or home location) and drop off their harvest into a
/// crate which will self-delete (with its contents) after a duration; players can loot these crates and
/// obtain free resources should they stumble upon these mobiles.

namespace ActionAI
{
    public class Lumberjack_Paths_Felucca
    {
        public static List<Tuple<Point3D, Direction>> lumberjack_path_0001 = new List<Tuple<Point3D, Direction>>
        {
            /// Outside Vesper (Left Side Of The Path)
            (new Tuple<Point3D, Direction> (new Point3D(2691, 1002, 0), Direction.East)),
            (new Tuple<Point3D, Direction> (new Point3D(2685, 1002, 0), Direction.West)),
            (new Tuple<Point3D, Direction> (new Point3D(2677, 1002, 0), Direction.West)),
            (new Tuple<Point3D, Direction> (new Point3D(2672, 1007, 0), Direction.South)),
            (new Tuple<Point3D, Direction> (new Point3D(2661, 1010, 0), Direction.Left)),
            (new Tuple<Point3D, Direction> (new Point3D(2664, 1018, 0), Direction.Right))

        };

        public static List<Tuple<Point3D, Direction>> lumberjack_path_0002 = new List<Tuple<Point3D, Direction>>
        {
            /// Outside Vesper (Right Side Of The Path)
            (new Tuple<Point3D, Direction> (new Point3D(2676, 980, 0), Direction.South)),
            (new Tuple<Point3D, Direction> (new Point3D(2676, 976, 0), Direction.North)),
            (new Tuple<Point3D, Direction> (new Point3D(2684, 973, 0), Direction.North)),
            (new Tuple<Point3D, Direction> (new Point3D(2695, 972, 0), Direction.East)),
            (new Tuple<Point3D, Direction> (new Point3D(2696, 961, 0), Direction.Right)),
            (new Tuple<Point3D, Direction> (new Point3D(2685, 954, 0), Direction.Left))
        };

        public static List<Tuple<Point3D, Direction>> lumberjack_path_0003 = new List<Tuple<Point3D, Direction>>
        {
            /// Outside Vesper (Left Side Of The Path)
            (new Tuple<Point3D, Direction> (new Point3D(2705, 1017, 0), Direction.West)),
            (new Tuple<Point3D, Direction> (new Point3D(2708, 1028, 0), Direction.South)),
            (new Tuple<Point3D, Direction> (new Point3D(2719, 1033, 0), Direction.Right)),
            (new Tuple<Point3D, Direction> (new Point3D(2713, 1043, 0), Direction.Left))

        };

        public static List<Tuple<Point3D, List<Tuple<Point3D, Direction>>>> ListOfPaths = new List<Tuple<Point3D, List<Tuple<Point3D, Direction>>>>
        {
            (new Tuple<Point3D, List<Tuple<Point3D, Direction>> > (new Point3D(lumberjack_path_0001[0].Item1), lumberjack_path_0001)),
            (new Tuple<Point3D, List<Tuple<Point3D, Direction>> > (new Point3D(lumberjack_path_0002[0].Item1), lumberjack_path_0002)),
            (new Tuple<Point3D, List<Tuple<Point3D, Direction>> > (new Point3D(lumberjack_path_0003[0].Item1), lumberjack_path_0003))
        };
    }

    public class Lumberjack_Paths_Trammel
    {
        public static List<Tuple<Point3D, Direction>> lumberjack_path_0001 = new List<Tuple<Point3D, Direction>>
        {
            /// Outside Vesper (Left Side Of The Path)
            (new Tuple<Point3D, Direction> (new Point3D(2691, 1002, 0), Direction.East)),
            (new Tuple<Point3D, Direction> (new Point3D(2685, 1002, 0), Direction.West)),
            (new Tuple<Point3D, Direction> (new Point3D(2677, 1002, 0), Direction.West)),
            (new Tuple<Point3D, Direction> (new Point3D(2672, 1007, 0), Direction.South)),
            (new Tuple<Point3D, Direction> (new Point3D(2661, 1010, 0), Direction.Left)),
            (new Tuple<Point3D, Direction> (new Point3D(2664, 1018, 0), Direction.Right))
        };

        public static List<Tuple<Point3D, Direction>> lumberjack_path_0002 = new List<Tuple<Point3D, Direction>>
        {
            /// Outside Vesper (Right Side Of The Path)
            (new Tuple<Point3D, Direction> (new Point3D(2676, 980, 0), Direction.South)),
            (new Tuple<Point3D, Direction> (new Point3D(2676, 976, 0), Direction.North)),
            (new Tuple<Point3D, Direction> (new Point3D(2684, 973, 0), Direction.North)),
            (new Tuple<Point3D, Direction> (new Point3D(2695, 972, 0), Direction.East)),
            (new Tuple<Point3D, Direction> (new Point3D(2696, 961, 0), Direction.Right)),
            (new Tuple<Point3D, Direction> (new Point3D(2685, 954, 0), Direction.Left))
        };

        public static List<Tuple<Point3D, Direction>> lumberjack_path_0003 = new List<Tuple<Point3D, Direction>>
        {
            /// Outside Vesper (Left Side Of The Path)
            (new Tuple<Point3D, Direction> (new Point3D(2705, 1017, 0), Direction.West)),
            (new Tuple<Point3D, Direction> (new Point3D(2708, 1028, 0), Direction.South)),
            (new Tuple<Point3D, Direction> (new Point3D(2719, 1033, 0), Direction.Right)),
            (new Tuple<Point3D, Direction> (new Point3D(2713, 1043, 0), Direction.Left))

        };

        public static List<Tuple<Point3D, List<Tuple<Point3D, Direction>>>> ListOfPaths = new List<Tuple<Point3D, List<Tuple<Point3D, Direction>>>>
        {
            (new Tuple<Point3D, List<Tuple<Point3D, Direction>> > (new Point3D(lumberjack_path_0001[0].Item1), lumberjack_path_0001)),
            (new Tuple<Point3D, List<Tuple<Point3D, Direction>> > (new Point3D(lumberjack_path_0002[0].Item1), lumberjack_path_0002)),
            (new Tuple<Point3D, List<Tuple<Point3D, Direction>> > (new Point3D(lumberjack_path_0003[0].Item1), lumberjack_path_0003))
        };
    }
}

namespace Server.Mobiles
{
    public class ActionAI_Lumberjack : BaseCreature
    {
        public PathFollower m_Path;

        private LumberjackCamp m_Camp;
        private int m_Index;
        private WayPoint m_waypointFirst;
        private List<Tuple<Point3D, Direction>> m_MobilePath;

        /// Active Harvest System Mobile Uses
        public override HarvestDefinition harvestDefinition { get { return Lumberjacking.System.Definition; } }

        public override HarvestSystem harvestSystem { get { return Lumberjacking.System; } }

        public override bool PlayerRangeSensitive { get { return false; } } // Mobile will continue to follow waypoints even if players aren't around

        #region Getter And Setters

        [CommandProperty(AccessLevel.GameMaster)]
        public int Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public WayPoint waypointFirst
        {
            get { return m_waypointFirst; }
            set { m_waypointFirst = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public List<Tuple<Point3D, Direction>> MobilePath
        {
            get { return m_MobilePath; }
            set { m_MobilePath = value; }
        }

        #endregion

        #region Mobile Constructor

        [Constructable]
        public ActionAI_Lumberjack() : base(AIType.AI_ActionAI, FightMode.None, 10, 1, 0.2, 1.6)
        {
            Title = "The Lumberjack";

            Hue = Utility.RandomSkinHue();
            Utility.AssignRandomHair(this);
            SpeechHue = Utility.RandomDyedHue();

            if (this.Female = Utility.RandomBool())
            {
                this.Body = 0x191;
                this.Name = NameList.RandomName("female");
            }
            else
            {
                this.Body = 0x190;
                this.Name = NameList.RandomName("male");
            }

            InitStats(31, 41, 51);

            SetSkill(SkillName.Healing, 36, 68);
            SetSkill(SkillName.Lumberjacking, 200, 300);

            RangeHome = 0;

            /// Clothing Mobile Will Wear
            AddItem(new Doublet(Utility.RandomDyedHue()));
            AddItem(new Sandals(Utility.RandomNeutralHue()));
            AddItem(new ShortPants(Utility.RandomNeutralHue()));
            AddItem(new HalfApron(Utility.RandomDyedHue()));

            /// Utility Mobile Will Equip
            AddItem(new Hatchet());

            /// Mobile Backpack And Items
            Container backpack = new StrongBackpack();
            backpack.Movable = false;
            AddItem(backpack);

            backpack.DropItem(new Gold(250, 300));

            /// ActionAI Mobile Labor Camp
            RangeHome = 10;
            Timer.DelayCall(CreateCamp);
        }

        #endregion

        public void CreateCamp()
        {
            if (!Alive && Deleted)
            {
                return;
            }

            Home = this.Location;

            LumberjackCamp camp = new LumberjackCamp();
            camp.MoveToWorld(this.Location, this.Map);
            m_Camp = camp;

            if (Backpack == null)
            {
                AddItem(new StrongBackpack());
            }

            SetPath();

            if (m_MobilePath == null)
            {
                return;
            }

            /// Create The First Waypoint
            m_waypointFirst = new WayPoint();
            m_waypointFirst.MoveToWorld(m_MobilePath[0].Item1, Map);

            CurrentWayPoint = m_waypointFirst;
            Timer.DelayCall(TimeSpan.FromSeconds(10.0), MoveWayPoint);
        }

        /// NPC Moves Using Standard WayPoints
        private void SetPath()
        {
            if (!Alive && Deleted && (Map == Map.Internal))
            {
                return;
            }

            if (this.Map == Map.Felucca)
            {
                List<Tuple<Point3D, List<Tuple<Point3D, Direction>>>> MapPaths = Lumberjack_Paths_Felucca.ListOfPaths;

                for (int i = 0; i < MapPaths.Count; i++)
                {
                    if (Utility.InRange(this.Home, MapPaths[i].Item1, 25))
                    {
                        m_MobilePath = MapPaths[i].Item2;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else if (this.Map == Map.Trammel)
            {
                List<Tuple<Point3D, List<Tuple<Point3D, Direction>>>> MapPaths = Lumberjack_Paths_Trammel.ListOfPaths;

                for (int i = 0; i < MapPaths.Count; i++)
                {
                    if (Utility.InRange(this.Home, MapPaths[i].Item1, 25))
                    {
                        m_MobilePath = MapPaths[i].Item2;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Timer.DelayCall(TimeSpan.FromSeconds(10.0), MoveWayPoint);
        }

        public override void OnThink()
        {
            if (!Alive && Deleted)
            {
                return;
            }

            if (m_MobilePath == null || m_waypointFirst == null)
            {
                return;
            }

            if (Alive && !Deleted)
            {
                if (m_waypointFirst.Location == Home)
                {
                    CurrentSpeed = 2.0;

                    Timer.DelayCall(TimeSpan.FromMinutes(5.0), MoveWayPoint);
                }

                if (Location != Home && m_waypointFirst != null && (m_waypointFirst.X == Location.X & m_waypointFirst.Y == Location.Y))
                {
                    CantWalk = true;
                    CurrentSpeed = 2.0;

                    Direction = m_MobilePath[m_Index].Item2;

                    Animate(Utility.RandomList(harvestDefinition.EffectActions), 5, 1, true, false, 0);
                    PlaySound(Utility.RandomList(harvestDefinition.EffectSounds));
                }
                else
                {
                    CurrentSpeed = 0.2;
                    CantWalk = false;
                }
            }
        }

        public void MoveWayPoint()
        {
            if (!Alive && Deleted)
            {
                return;
            }

            if (Alive && !Deleted)
            {
                if (waypointFirst != null && (waypointFirst.X == Location.X & waypointFirst.Y == Location.Y))
                {
                    CantWalk = false;

                    if ((m_Index + 1) < m_MobilePath.Count)
                    {
                        m_Index++;

                        waypointFirst.Location = m_MobilePath[m_Index].Item1;
                        CurrentWayPoint = waypointFirst;
                        Timer.DelayCall(TimeSpan.FromSeconds(10.0), MoveWayPoint);
                    }
                    else
                    {
                        m_Index = 0;
                        waypointFirst.Location = Home;
                        CurrentWayPoint = waypointFirst;
                    }
                }
            }
        }

        /// Force NPC To Move On Server Startup
        public void MoveWayPointOnDeserialize()
        {
            if (!Alive && Deleted)
            {
                return;
            }

            if (Alive && !Deleted)
            {
                SetPath();
                CurrentWayPoint = waypointFirst;

                if (m_MobilePath == null)
                {
                    return;
                }

                if (waypointFirst != null)
                {
                    CantWalk = false;

                    if ((m_Index + 1) < m_MobilePath.Count)
                    {
                        m_Index++;
                        // Emote("moving to next point"); // Debug

                        waypointFirst.Location = m_MobilePath[m_Index].Item1;
                        CurrentWayPoint = waypointFirst;

                        Timer.DelayCall(TimeSpan.FromSeconds(10.0), MoveWayPoint);
                    }
                    else
                    {
                        m_Index = 0;
                        // Emote("returning to camp"); // Debug

                        waypointFirst.Location = Home;
                        CurrentWayPoint = waypointFirst;
                    }
                }
            }
        }

        public override void OnDelete()
        {
            if (m_Camp != null && !m_Camp.Deleted)
            {
                m_Camp.Delete();
            }

            if (m_waypointFirst != null && !m_waypointFirst.Deleted)
            {
                m_waypointFirst.Delete();
            }

            base.OnDelete();
        }

        public ActionAI_Lumberjack(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // Current Version 

            writer.Write(m_Camp);
            writer.Write(m_waypointFirst);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Camp = reader.ReadItem() as LumberjackCamp;
            m_waypointFirst = reader.ReadItem() as WayPoint;

            // Timer.DelayCall(TimeSpan.FromSeconds(10.0), MoveWayPointOnDeserialize);
            Timer.DelayCall(TimeSpan.FromSeconds(3.0), SetPath);
        }
    }
}