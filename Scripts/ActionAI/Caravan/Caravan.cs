using Server.Items;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server
{
	public class ActionAI_CaravanPaths
	{
		public static readonly Point2D[] ArmorerPath =
		{
			new(2538, 622),
			new(2524, 622),
			new(2518, 620),
			new(2513, 618),
			new(2513, 605),
			new(2513, 595),
			new(2517, 591),
			new(2517, 574),
			new(2517, 562),
			new(2503, 562),
			new(2501, 560),
		};
	}

	[PropertyObject]
	public class ActionAI_Path : IEnumerable<Point2D>
	{
		private readonly List<Point2D> _Points;

		private int _Current = -1;

		[CommandProperty(AccessLevel.GameMaster, true)]
		public Point2D Current
		{
			get => _Current >= 0 && _Current < _Points.Count ? _Points[_Current] : Point2D.Zero;
			set => _Current = _Points.IndexOf(value);
		}

		[CommandProperty(AccessLevel.GameMaster, true)]
		public int Count => _Points.Count;

		[CommandProperty(AccessLevel.GameMaster, true)]
		public bool IsEmpty => _Points.Count == 0;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool ForceClear
		{
			get => false; 
			set
			{
				if (value)
				{
					Clear();
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool ForceReverse
		{
			get => false;
			set
			{
				if (value)
				{
					Reverse();
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool ForceNext
		{
			get => false;
			set
			{
				if (value)
				{
					Next();
				}
			}
		}

		public Point2D this[int index] { get => _Points[index]; set => _Points[index] = value; }

		public ActionAI_Path(params Point2D[] points)
		{
			_Points = new(points ?? Array.Empty<Point2D>());
		}

		public void Reverse()
		{
			_Points.Reverse();

			_Current = _Points.Count - (_Current + 1);
		}

		public bool Next()
		{
			return _Current < _Points.Count && ++_Current < _Points.Count;
		}

		public void Reset()
		{
			_Current = -1;
		}

		public void Clear()
		{
			_Points.Clear();

			_Current = -1;
		}

		public void Add(Point2D p)
		{
			_Points.Add(p);

			if (_Current == _Points.Count - 1)
			{
				++_Current;
			}
		}

		public void Insert(int index, Point2D p)
		{
			_Points.Insert(index, p);

			if (_Current >= index)
			{
				++_Current;
			}
		}

		public bool Remove(Point2D p)
		{
			var result = _Points.Remove(p);

			if (result && _Current > _Points.Count)
			{
				--_Current;
			}

			return result;
		}

		public void RemoveAt(int index)
		{
			_Points.RemoveAt(index);

			if (_Current > _Points.Count)
			{
				--_Current;
			}
		}

		public IEnumerator<Point2D> GetEnumerator()
		{
			return _Points.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _Points.GetEnumerator();
		}
	}
}

namespace Server.Mobiles
{
	public class ActionAI_CaravanVendor : BaseVendor
	{
		private bool _Deleting;
		private long _NextMove;

		protected override List<SBInfo> SBInfos { get; } = new();

		[CommandProperty(AccessLevel.GameMaster)]
		public ActionAI_Path Path { get; private set; } = new(ActionAI_CaravanPaths.ArmorerPath);

		[CommandProperty(AccessLevel.GameMaster)]
		public HashSet<Guard> Guards { get; private set; } = new();

		[CommandProperty(AccessLevel.GameMaster)]
		public PackHorse PackHorse { get; private set; }

		private WayPoint _WayPointItem;

		[CommandProperty(AccessLevel.GameMaster)]
		public WayPoint WayPointItem
		{
			get
			{
				if (World.Loaded && _WayPointItem?.Deleted != false)
				{
					PackItem(_WayPointItem = new WayPoint()
					{
						Name = "Caravan Way Point",
						Movable = false
					});
				}

				return _WayPointItem;
			}
			private set => _WayPointItem = value;
		}

		private PathMap _PathMapItem;

		[CommandProperty(AccessLevel.GameMaster)]
		public PathMap PathMapItem
		{
			get
			{
				if (World.Loaded && _PathMapItem?.Deleted != false)
				{
					PackItem(_PathMapItem = new PathMap(this));
				}

				return _PathMapItem;
			}
			private set => _PathMapItem = value;
		}

		public override bool PlayerRangeSensitive => false;
		public override bool ReturnsToHome => false;

		public override bool InitialInnocent => true;
		public override bool IsInvulnerable => false;

		[Constructable]
		public ActionAI_CaravanVendor()
			: base("the Caravan Vendor")
		{
			Fame = 500;
			Karma = 1000;

			VirtualArmor = 24;

			ActiveSpeed = PassiveSpeed = 0.2;

			SetStr(600, 800);
			SetDex(91, 510);
			SetInt(161, 585);

			SetHits(222, 308);

			SetDamage(23, 46);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 60, 80);
			SetResistance(ResistanceType.Fire, 60, 80);
			SetResistance(ResistanceType.Cold, 70, 80);
			SetResistance(ResistanceType.Poison, 70, 80);
			SetResistance(ResistanceType.Energy, 70, 80);

			SetSkill(SkillName.EvalInt, 97.5, 150.0);
			SetSkill(SkillName.Fencing, 92.5, 135.0);
			SetSkill(SkillName.Macing, 92.5, 135.0);
			SetSkill(SkillName.Magery, 92.5, 135.0);
			SetSkill(SkillName.Meditation, 97.5, 300.0);
			SetSkill(SkillName.MagicResist, 97.5, 130.0);
			SetSkill(SkillName.Swords, 92.5, 135.0);
			SetSkill(SkillName.Tactics, 92.5, 135.0);
			SetSkill(SkillName.Wrestling, 92.5, 135.0);
		}

		public ActionAI_CaravanVendor(Serial serial)
			: base(serial)
		{
		}

		private T SpawnHelper<T>() where T : BaseCreature, new()
		{
			var mob = new T();

			mob.OnBeforeSpawn(Location, Map);

			if (!mob.Deleted)
			{
				mob.MoveToWorld(Location, Map);

				if (!mob.Deleted)
				{
					mob.OnAfterSpawn();
				}
			}

			if (mob?.Deleted == false)
			{
				mob.Formation = Formation ??= new PathFormation();

				return mob;
			}

			return null;
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();

			var guard1 = SpawnHelper<Guard>();

			if (guard1 != null)
			{
				guard1.Protecting = this;
			}

			var horse = SpawnHelper<PackHorse>();

			if (horse != null)
			{
				horse.Controlled = true;
				horse.ControlMaster = this;

				//horse.ControlOrder = OrderType.Follow;
				//horse.ControlTarget = this;

				var guard2 = SpawnHelper<Guard>();

				if (guard2 != null)
				{
					guard2.Protecting = this;
				}
			}

			SetWayPoint(Location);

			PathMapItem.Update();
		}

		public override void OnThink()
		{
			base.OnThink();

			if (Path.IsEmpty)
			{
				return;
			}

			if (!WayPointItem.AtWorldPoint(X, Y))
			{
				return;
			}

			if (Core.TickCount < _NextMove)
			{
				return;
			}

			if (!Path.Next())
			{
				if (_Deleting)
				{
					Delete();
					return;
				}

				Path.Reverse();
				Path.Reset();

				PathMapItem.Update();

				_NextMove = Core.TickCount + 60000;

				CantWalk = true;

				if (!Path.Next())
				{
					_Deleting = true;
					return;
				}
			}
			else
			{
				_NextMove = Core.TickCount + 1000;

				CantWalk = false;

				_Deleting = false;
			}

			SetWayPoint(Path.Current);
		}

		private void SetWayPoint(IPoint2D p)
		{
			if (p == Point2D.Zero)
			{
				p = Location;
			}

			var loc = new Point3D(p, Z);

			loc.Z = Map.GetAverageZ(loc.X, loc.Y);

			WayPointItem.MoveToWorld(loc, Map);

			CurrentWayPoint = WayPointItem;
		}

		public override void InitSBInfo()
		{
			SBInfos.Add(new SBProvisioner());

			if (IsTokunoVendor)
			{
				SBInfos.Add(new SBSEHats());
			}
		}

		public override void OnDelete()
		{
			base.OnDelete();

			_WayPointItem?.Delete();
			_PathMapItem?.Delete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.WriteEncodedLong(_NextMove - Core.TickCount);

			writer.Write(_Deleting);

			writer.Write(PathMapItem);
			writer.Write(WayPointItem);
			writer.Write(PackHorse);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();

			_NextMove = Core.TickCount + reader.ReadEncodedLong();

			_Deleting = reader.ReadBool();

			PathMapItem = reader.ReadItem<PathMap>();
			WayPointItem = reader.ReadItem<WayPoint>();
			PackHorse = reader.ReadMobile<PackHorse>();
		}

		public sealed class Guard : BaseCreature
		{
			private ActionAI_CaravanVendor _Protecting;

			[CommandProperty(AccessLevel.GameMaster)]
			public ActionAI_CaravanVendor Protecting
			{
				get => _Protecting;
				set
				{
					_Protecting?.Guards.Remove(this);

					_Protecting = value;

					if (_Protecting?.Deleted == false)
					{
						_Protecting.Guards.Add(this);
						/*
						Controlled = true;
						ControlMaster = _Protecting;

						ControlOrder = OrderType.Guard;
						ControlTarget = _Protecting;*/
					}
					/*else
					{
						Controlled = false;
						ControlMaster = null;

						ControlOrder = OrderType.None; 
						ControlTarget = null;
					}*/
				}
			}

			public override bool PlayerRangeSensitive => false;
			public override bool ReturnsToHome => false;

			public override bool InitialInnocent => true;
			public override bool IsInvulnerable => false;

			[Constructable]
			public Guard()
				: base(AIType.AI_Melee, FightMode.Aggressor, 15, 1, 0.2, 0.6)
			{
				Name = NameList.RandomName("male");

				Hue = Utility.RandomSkinHue();

				Body = 0x190;

				Fame = 5000;
				Karma = 1000;

				SetStr(600, 800);
				SetDex(91, 510);
				SetInt(161, 585);

				SetHits(222, 308);

				SetDamage(23, 46);

				SetDamageType(ResistanceType.Physical, 100);

				SetResistance(ResistanceType.Physical, 60, 80);
				SetResistance(ResistanceType.Fire, 60, 80);
				SetResistance(ResistanceType.Cold, 70, 80);
				SetResistance(ResistanceType.Poison, 70, 80);
				SetResistance(ResistanceType.Energy, 70, 80);

				SetSkill(SkillName.EvalInt, 97.5, 150.0);
				SetSkill(SkillName.Fencing, 92.5, 135.0);
				SetSkill(SkillName.Macing, 92.5, 135.0);
				SetSkill(SkillName.Magery, 92.5, 135.0);
				SetSkill(SkillName.Meditation, 97.5, 300.0);
				SetSkill(SkillName.MagicResist, 97.5, 130.0);
				SetSkill(SkillName.Swords, 92.5, 135.0);
				SetSkill(SkillName.Tactics, 92.5, 135.0);
				SetSkill(SkillName.Wrestling, 92.5, 135.0);

				AddItem(new PlateArms
				{
					Resource = CraftResource.ShadowIron
				});

				AddItem(new PlateLegs
				{
					Resource = CraftResource.ShadowIron
				});

				AddItem(new PlateChest
				{
					Resource = CraftResource.ShadowIron
				});

				AddItem(new Halberd
				{
					Resource = CraftResource.ShadowIron
				});

				PackItem(new Bandage(Utility.RandomMinMax(1, 15)));

				PackGold(1770, 3100);
				PackReg(10, 15);

				_ = PackArmor(2, 5, 0.8);
				_ = PackWeapon(3, 5, 0.8);
				_ = PackSlayer();
			}

			public Guard(Serial serial)
				: base(serial)
			{
			}

			public override void OnThink()
			{
				base.OnThink();

				if (Protecting?.Deleted != false)
				{
					return;
				}

				if (Protecting.Alive && !InRange(Protecting.Location, RangePerception))
				{
					Combatant = null;

					//ControlOrder = OrderType.Guard;
					//ControlTarget = Protecting;

					//CurrentWayPoint = Protecting.WayPointItem;
				}
				/*else
				{
					if (Combatant == null && Protecting.Combatant != null)
					{
						Attack(Protecting.Combatant);
					}

					if (Combatant == null && Protecting.PackHorse?.Combatant != null)
					{
						Attack(Protecting.PackHorse.Combatant);
					}
				}*/
			}

			public override void OnDelete()
			{
				base.OnDelete();

				Protecting = null;
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(0); // version

				writer.Write(Protecting);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				_ = reader.ReadInt();

				Protecting = reader.ReadMobile<ActionAI_CaravanVendor>();
			}
		}

		public sealed class PathMap : MapItem
		{
			[CommandProperty(AccessLevel.GameMaster)]
			public ActionAI_CaravanVendor Owner { get; private set; }

			public override int MaxUserPins => 0; // unlimited

			public override string DefaultName => "Caravan Path Map";

			public PathMap(ActionAI_CaravanVendor owner)
			{
				Owner = owner;

				Width = Height = 800;

				Editable = true;

				Movable = false;
				Visible = false;
			}

			public PathMap(Serial serial)
				: base(serial)
			{
			}

			public override bool Validate(Mobile from)
			{
				return from?.AccessLevel >= AccessLevel.GameMaster;
			}

			public override bool ValidateEdit(Mobile from)
			{
				return from?.AccessLevel >= AccessLevel.GameMaster;
			}

			public override void OnDoubleClick(Mobile from)
			{
				if (Validate(from))
				{
					DisplayTo(from);
				}
			}

			public override void DisplayTo(Mobile from)
			{
				Update();

				base.DisplayTo(from);
			}

			public void Update()
			{
				SetDisplay(Owner.Map);

				Pins.Clear();

				foreach (var p in Owner.Path)
				{
					ConvertToMap(p.X, p.Y, out var mapX, out var mapY);

					Pins.Add(new Point2D(mapX, mapY));
				}
			}

			public override void ClearPins()
			{
				Pins.Clear();
				Owner.Path.Clear();
			}

			public override void ChangePin(int index, int x, int y)
			{
				if (index >= 0 && index < Pins.Count)
				{
					var pin = new Point2D(x, y);

					Pins[index] = pin;

					ConvertToWorld(pin.X, pin.Y, out x, out y);

					pin.X = x;
					pin.Y = y;

					Owner.Path[index] = pin;
				}
			}

			public override void AddPin(int x, int y)
			{
				var pin = new Point2D(x, y);

				Pins.Add(pin);

				ConvertToWorld(pin.X, pin.Y, out x, out y);

				pin.X = x;
				pin.Y = y;

				Owner.Path.Add(pin);
			}

			public override void InsertPin(int index, int x, int y)
			{
				var pin = new Point2D(x, y);

				if (index < 0 || index >= Pins.Count)
				{
					Pins.Add(pin);

					ConvertToWorld(pin.X, pin.Y, out x, out y);

					pin.X = x;
					pin.Y = y;

					Owner.Path.Add(pin);
				}
				else
				{
					Pins.Insert(index, pin);

					ConvertToWorld(pin.X, pin.Y, out x, out y);

					pin.X = x;
					pin.Y = y;

					Owner.Path.Insert(index, pin);
				}
			}

			public override void RemovePin(int index)
			{
				if (index > 0 && index < Pins.Count)
				{
					Pins.RemoveAt(index);
					Owner.Path.RemoveAt(index);
				}
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(0);

				writer.Write(Owner);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				_ = reader.ReadInt();

				Owner = reader.ReadMobile<ActionAI_CaravanVendor>();
			}
		}

		public sealed class PathFormation : LineFormation
		{
			public PathFormation()
			{
			}

			protected override BaseCreature GetStrongest(BaseCreature a, BaseCreature b)
			{
				if (a is ActionAI_CaravanVendor)
				{
					return a;
				}

				if (b is ActionAI_CaravanVendor)
				{
					return b;
				}

				return base.GetStrongest(a, b);
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.WriteEncodedInt(0);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				reader.ReadEncodedInt();
			}
		}
	}
}
