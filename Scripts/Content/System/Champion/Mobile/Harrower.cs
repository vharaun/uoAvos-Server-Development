using Server.Items;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class Harrower : BaseCreature
	{
		public Type[] UniqueList => new Type[] { typeof(AcidProofRobe) };
		public Type[] SharedList => new Type[] { typeof(TheRobeOfBritanniaAri) };
		public Type[] DecorativeList => new Type[] { typeof(EvilIdolSkull), typeof(SkullPole) };

		private bool m_TrueForm;
		private Item m_GateItem;
		private List<HarrowerTentacles> m_Tentacles;
		private Timer m_Timer;

		private class SpawnEntry
		{
			public Point3D m_Location;
			public Point3D m_Entrance;

			public SpawnEntry(Point3D loc, Point3D ent)
			{
				m_Location = loc;
				m_Entrance = ent;
			}
		}

		private static readonly SpawnEntry[] m_Entries = new SpawnEntry[]
			{
				new SpawnEntry( new Point3D( 5242, 945, -40 ), new Point3D( 1176, 2638, 0 ) ),	// Destard
				new SpawnEntry( new Point3D( 5225, 798, 0 ), new Point3D( 1176, 2638, 0 ) ),	// Destard
				new SpawnEntry( new Point3D( 5556, 886, 30 ), new Point3D( 1298, 1080, 0 ) ),	// Despise
				new SpawnEntry( new Point3D( 5187, 615, 0 ), new Point3D( 4111, 432, 5 ) ),		// Deceit
				new SpawnEntry( new Point3D( 5319, 583, 0 ), new Point3D( 4111, 432, 5 ) ),		// Deceit
				new SpawnEntry( new Point3D( 5713, 1334, -1 ), new Point3D( 2923, 3407, 8 ) ),	// Fire
				new SpawnEntry( new Point3D( 5860, 1460, -2 ), new Point3D( 2923, 3407, 8 ) ),	// Fire
				new SpawnEntry( new Point3D( 5328, 1620, 0 ), new Point3D( 5451, 3143, -60 ) ),	// Terathan Keep
				new SpawnEntry( new Point3D( 5690, 538, 0 ), new Point3D( 2042, 224, 14 ) ),	// Wrong
				new SpawnEntry( new Point3D( 5609, 195, 0 ), new Point3D( 514, 1561, 0 ) ),		// Shame
				new SpawnEntry( new Point3D( 5475, 187, 0 ), new Point3D( 514, 1561, 0 ) ),		// Shame
				new SpawnEntry( new Point3D( 6085, 179, 0 ), new Point3D( 4721, 3822, 0 ) ),	// Hythloth
				new SpawnEntry( new Point3D( 6084, 66, 0 ), new Point3D( 4721, 3822, 0 ) ),		// Hythloth
				new SpawnEntry( new Point3D( 5499, 2003, 0 ), new Point3D( 2499, 919, 0 ) ),	// Covetous
				new SpawnEntry( new Point3D( 5579, 1858, 0 ), new Point3D( 2499, 919, 0 ) )		// Covetous
			};

		private static readonly ArrayList m_Instances = new ArrayList();

		public static ArrayList Instances => m_Instances;

		public static Harrower Spawn(Point3D platLoc, Map platMap)
		{
			if (m_Instances.Count > 0)
			{
				return null;
			}

			var entry = m_Entries[Utility.Random(m_Entries.Length)];

			var harrower = new Harrower();

			harrower.MoveToWorld(entry.m_Location, Map.Felucca);

			harrower.m_GateItem = new HarrowerGate(harrower, platLoc, platMap, entry.m_Entrance, Map.Felucca);

			return harrower;
		}

		public static bool CanSpawn => (m_Instances.Count == 0);

		[Constructable]
		public Harrower() : base(AIType.AI_Mage, FightMode.Closest, 18, 1, 0.2, 0.4)
		{
			m_Instances.Add(this);

			Name = "the harrower";
			BodyValue = 146;

			SetStr(900, 1000);
			SetDex(125, 135);
			SetInt(1000, 1200);

			Fame = 22500;
			Karma = -22500;

			VirtualArmor = 60;

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Energy, 50);

			SetResistance(ResistanceType.Physical, 55, 65);
			SetResistance(ResistanceType.Fire, 60, 80);
			SetResistance(ResistanceType.Cold, 60, 80);
			SetResistance(ResistanceType.Poison, 60, 80);
			SetResistance(ResistanceType.Energy, 60, 80);

			SetSkill(SkillName.Wrestling, 90.1, 100.0);
			SetSkill(SkillName.Tactics, 90.2, 110.0);
			SetSkill(SkillName.MagicResist, 120.2, 160.0);
			SetSkill(SkillName.Magery, 120.0);
			SetSkill(SkillName.EvalInt, 120.0);
			SetSkill(SkillName.Meditation, 120.0);

			m_Tentacles = new List<HarrowerTentacles>();

			m_Timer = new TeleportTimer(this);
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.SuperBoss, 2);
			AddLoot(LootPack.Meager);
		}

		public override bool AutoDispel => true;
		public override bool Unprovokable => true;
		public override Poison PoisonImmune => Poison.Lethal;

		private static readonly double[] m_Offsets = new double[]
			{
				Math.Cos( 000.0 / 180.0 * Math.PI ), Math.Sin( 000.0 / 180.0 * Math.PI ),
				Math.Cos( 040.0 / 180.0 * Math.PI ), Math.Sin( 040.0 / 180.0 * Math.PI ),
				Math.Cos( 080.0 / 180.0 * Math.PI ), Math.Sin( 080.0 / 180.0 * Math.PI ),
				Math.Cos( 120.0 / 180.0 * Math.PI ), Math.Sin( 120.0 / 180.0 * Math.PI ),
				Math.Cos( 160.0 / 180.0 * Math.PI ), Math.Sin( 160.0 / 180.0 * Math.PI ),
				Math.Cos( 200.0 / 180.0 * Math.PI ), Math.Sin( 200.0 / 180.0 * Math.PI ),
				Math.Cos( 240.0 / 180.0 * Math.PI ), Math.Sin( 240.0 / 180.0 * Math.PI ),
				Math.Cos( 280.0 / 180.0 * Math.PI ), Math.Sin( 280.0 / 180.0 * Math.PI ),
				Math.Cos( 320.0 / 180.0 * Math.PI ), Math.Sin( 320.0 / 180.0 * Math.PI ),
			};

		public void Morph()
		{
			if (m_TrueForm)
			{
				return;
			}

			m_TrueForm = true;

			Name = "the true harrower";
			BodyValue = 780;
			Hue = 0x497;

			Hits = HitsMax;
			Stam = StamMax;
			Mana = ManaMax;

			ProcessDelta();

			Say(1049499); // Behold my true form!

			var map = Map;

			if (map != null)
			{
				for (var i = 0; i < m_Offsets.Length; i += 2)
				{
					var rx = m_Offsets[i];
					var ry = m_Offsets[i + 1];

					var dist = 0;
					var ok = false;
					int x = 0, y = 0, z = 0;

					while (!ok && dist < 10)
					{
						var rdist = 10 + dist;

						x = X + (int)(rx * rdist);
						y = Y + (int)(ry * rdist);
						z = map.GetAverageZ(x, y);

						if (!(ok = map.CanFit(x, y, Z, 16, false, false)))
						{
							ok = map.CanFit(x, y, z, 16, false, false);
						}

						if (dist >= 0)
						{
							dist = -(dist + 1);
						}
						else
						{
							dist = -(dist - 1);
						}
					}

					if (!ok)
					{
						continue;
					}

					var spawn = new HarrowerTentacles(this) {
						Team = Team
					};

					spawn.MoveToWorld(new Point3D(x, y, z), map);

					m_Tentacles.Add(spawn);
				}
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public override int HitsMax => m_TrueForm ? 65000 : 30000;

		[CommandProperty(AccessLevel.GameMaster)]
		public override int ManaMax => 5000;

		public Harrower(Serial serial) : base(serial)
		{
			m_Instances.Add(this);
		}

		public override void OnAfterDelete()
		{
			m_Instances.Remove(this);

			base.OnAfterDelete();
		}

		public override bool DisallowAllMoves => m_TrueForm;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_TrueForm);
			writer.Write(m_GateItem);
			writer.WriteMobileList<HarrowerTentacles>(m_Tentacles);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_TrueForm = reader.ReadBool();
						m_GateItem = reader.ReadItem();
						m_Tentacles = reader.ReadStrongMobileList<HarrowerTentacles>();

						m_Timer = new TeleportTimer(this);
						m_Timer.Start();

						break;
					}
			}
		}

		public void GivePowerScrolls()
		{
			var toGive = new List<Mobile>();
			var rights = BaseCreature.GetLootingRights(DamageEntries, HitsMax);

			for (var i = rights.Count - 1; i >= 0; --i)
			{
				var ds = rights[i];

				if (ds.m_HasRight)
				{
					toGive.Add(ds.m_Mobile);
				}
			}

			if (toGive.Count == 0)
			{
				return;
			}

			// Randomize
			for (var i = 0; i < toGive.Count; ++i)
			{
				var rand = Utility.Random(toGive.Count);
				var hold = toGive[i];
				toGive[i] = toGive[rand];
				toGive[rand] = hold;
			}

			for (var i = 0; i < 16; ++i)
			{
				int level;
				var random = Utility.RandomDouble();

				if (0.1 >= random)
				{
					level = 25;
				}
				else if (0.25 >= random)
				{
					level = 20;
				}
				else if (0.45 >= random)
				{
					level = 15;
				}
				else if (0.70 >= random)
				{
					level = 10;
				}
				else
				{
					level = 5;
				}

				var m = toGive[i % toGive.Count];

				m.SendLocalizedMessage(1049524); // You have received a scroll of power!
				m.AddToBackpack(new StatCapScroll(225 + level));

				if (m is PlayerMobile)
				{
					var pm = (PlayerMobile)m;

					for (var j = 0; j < pm.JusticeProtectors.Count; ++j)
					{
						var prot = pm.JusticeProtectors[j];

						if (prot.Map != m.Map || prot.Murderer || prot.Criminal || !JusticeVirtue.CheckMapRegion(m, prot))
						{
							continue;
						}

						var chance = 0;

						switch (VirtueHelper.GetLevel(prot, VirtueName.Justice))
						{
							case VirtueLevel.Seeker: chance = 60; break;
							case VirtueLevel.Follower: chance = 80; break;
							case VirtueLevel.Knight: chance = 100; break;
						}

						if (chance > Utility.Random(100))
						{
							prot.SendLocalizedMessage(1049368); // You have been rewarded for your dedication to Justice!
							prot.AddToBackpack(new StatCapScroll(225 + level));
						}
					}
				}
			}
		}

		public override bool OnBeforeDeath()
		{
			if (m_TrueForm)
			{
				var rights = BaseCreature.GetLootingRights(DamageEntries, HitsMax);

				for (var i = rights.Count - 1; i >= 0; --i)
				{
					var ds = rights[i];

					if (ds.m_HasRight && ds.m_Mobile is PlayerMobile)
					{
						PlayerMobile.ChampionTitleInfo.AwardHarrowerTitle((PlayerMobile)ds.m_Mobile);
					}
				}

				if (!NoKillAwards)
				{
					GivePowerScrolls();

					var map = Map;

					if (map != null)
					{
						for (var x = -16; x <= 16; ++x)
						{
							for (var y = -16; y <= 16; ++y)
							{
								var dist = Math.Sqrt(x * x + y * y);

								if (dist <= 16)
								{
									new GoodiesTimer(map, X + x, Y + y).Start();
								}
							}
						}
					}

					m_DamageEntries = new Dictionary<Mobile, int>();

					for (var i = 0; i < m_Tentacles.Count; ++i)
					{
						Mobile m = m_Tentacles[i];

						if (!m.Deleted)
						{
							m.Kill();
						}

						RegisterDamageTo(m);
					}

					m_Tentacles.Clear();

					RegisterDamageTo(this);
					AwardArtifact(GetArtifact());

					if (m_GateItem != null)
					{
						m_GateItem.Delete();
					}
				}

				return base.OnBeforeDeath();
			}
			else
			{
				Morph();
				return false;
			}
		}

		private Dictionary<Mobile, int> m_DamageEntries;

		public virtual void RegisterDamageTo(Mobile m)
		{
			if (m == null)
			{
				return;
			}

			foreach (var de in m.DamageEntries)
			{
				var damager = de.Damager;

				var master = damager.GetDamageMaster(m);

				if (master != null)
				{
					damager = master;
				}

				RegisterDamage(damager, de.DamageGiven);
			}
		}

		public void RegisterDamage(Mobile from, int amount)
		{
			if (from == null || !from.Player)
			{
				return;
			}

			if (m_DamageEntries.ContainsKey(from))
			{
				m_DamageEntries[from] += amount;
			}
			else
			{
				m_DamageEntries.Add(from, amount);
			}

			from.SendMessage(String.Format("Total Damage: {0}", m_DamageEntries[from]));
		}

		public void AwardArtifact(Item artifact)
		{
			if (artifact == null)
			{
				return;
			}

			var totalDamage = 0;

			var validEntries = new Dictionary<Mobile, int>();

			foreach (var kvp in m_DamageEntries)
			{
				if (IsEligible(kvp.Key, artifact))
				{
					validEntries.Add(kvp.Key, kvp.Value);
					totalDamage += kvp.Value;
				}
			}

			var randomDamage = Utility.RandomMinMax(1, totalDamage);

			totalDamage = 0;

			foreach (var kvp in validEntries)
			{
				totalDamage += kvp.Value;

				if (totalDamage >= randomDamage)
				{
					GiveArtifact(kvp.Key, artifact);
					return;
				}
			}

			artifact.Delete();
		}

		public void GiveArtifact(Mobile to, Item artifact)
		{
			if (to == null || artifact == null)
			{
				return;
			}

			var pack = to.Backpack;

			if (pack == null || !pack.TryDropItem(to, artifact, false))
			{
				artifact.Delete();
			}
			else
			{
				to.SendLocalizedMessage(1062317); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
			}
		}

		public bool IsEligible(Mobile m, Item Artifact)
		{
			return m.Player && m.Alive && m.InRange(Location, 32) && m.Backpack != null && m.Backpack.CheckHold(m, Artifact, false);
		}

		public Item GetArtifact()
		{
			var random = Utility.RandomDouble();
			if (0.05 >= random)
			{
				return CreateArtifact(UniqueList);
			}
			else if (0.15 >= random)
			{
				return CreateArtifact(SharedList);
			}
			else if (0.30 >= random)
			{
				return CreateArtifact(DecorativeList);
			}

			return null;
		}

		public Item CreateArtifact(Type[] list)
		{
			if (list.Length == 0)
			{
				return null;
			}

			var random = Utility.Random(list.Length);

			var type = list[random];

			return Loot.Construct(type);
		}

		private class TeleportTimer : Timer
		{
			private readonly Mobile m_Owner;

			private static readonly int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

			public TeleportTimer(Mobile owner) : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(5.0))
			{
				Priority = TimerPriority.TwoFiftyMS;

				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if (m_Owner.Deleted)
				{
					Stop();
					return;
				}

				var map = m_Owner.Map;

				if (map == null)
				{
					return;
				}

				if (0.25 < Utility.RandomDouble())
				{
					return;
				}

				Mobile toTeleport = null;

				foreach (var m in m_Owner.GetMobilesInRange(16))
				{
					if (m != m_Owner && m.Player && m_Owner.CanBeHarmful(m) && m_Owner.CanSee(m))
					{
						toTeleport = m;
						break;
					}
				}

				if (toTeleport != null)
				{
					var offset = Utility.Random(8) * 2;

					var to = m_Owner.Location;

					for (var i = 0; i < m_Offsets.Length; i += 2)
					{
						var x = m_Owner.X + m_Offsets[(offset + i) % m_Offsets.Length];
						var y = m_Owner.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

						if (map.CanSpawnMobile(x, y, m_Owner.Z))
						{
							to = new Point3D(x, y, m_Owner.Z);
							break;
						}
						else
						{
							var z = map.GetAverageZ(x, y);

							if (map.CanSpawnMobile(x, y, z))
							{
								to = new Point3D(x, y, z);
								break;
							}
						}
					}

					var m = toTeleport;

					var from = m.Location;

					m.Location = to;

					Server.Spells.SpellHelper.Turn(m_Owner, toTeleport);
					Server.Spells.SpellHelper.Turn(toTeleport, m_Owner);

					m.ProcessDelta();

					Effects.SendLocationParticles(EffectItem.Create(from, m.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
					Effects.SendLocationParticles(EffectItem.Create(to, m.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);

					m.PlaySound(0x1FE);

					m_Owner.Combatant = toTeleport;
				}
			}
		}

		private class GoodiesTimer : Timer
		{
			private readonly Map m_Map;
			private readonly int m_X, m_Y;

			public GoodiesTimer(Map map, int x, int y) : base(TimeSpan.FromSeconds(Utility.RandomDouble() * 10.0))
			{
				Priority = TimerPriority.TwoFiftyMS;

				m_Map = map;
				m_X = x;
				m_Y = y;
			}

			protected override void OnTick()
			{
				var z = m_Map.GetAverageZ(m_X, m_Y);
				var canFit = m_Map.CanFit(m_X, m_Y, z, 6, false, false);

				for (var i = -3; !canFit && i <= 3; ++i)
				{
					canFit = m_Map.CanFit(m_X, m_Y, z + i, 6, false, false);

					if (canFit)
					{
						z += i;
					}
				}

				if (!canFit)
				{
					return;
				}

				var g = new Gold(750, 1250);

				g.MoveToWorld(new Point3D(m_X, m_Y, z), m_Map);

				if (0.5 >= Utility.RandomDouble())
				{
					switch (Utility.Random(3))
					{
						case 0: // Fire column
							{
								Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x3709, 10, 30, 5052);
								Effects.PlaySound(g, g.Map, 0x208);

								break;
							}
						case 1: // Explosion
							{
								Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x36BD, 20, 10, 5044);
								Effects.PlaySound(g, g.Map, 0x307);

								break;
							}
						case 2: // Ball of fire
							{
								Effects.SendLocationParticles(EffectItem.Create(g.Location, g.Map, EffectItem.DefaultDuration), 0x36FE, 10, 10, 5052);

								break;
							}
					}
				}
			}
		}
	}

	[CorpseName("a tentacles corpse")]
	public class HarrowerTentacles : BaseCreature
	{
		private Mobile m_Harrower;

		private DrainTimer m_Timer;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Harrower
		{
			get => m_Harrower;
			set => m_Harrower = value;
		}

		[Constructable]
		public HarrowerTentacles() : this(null)
		{
		}

		public HarrowerTentacles(Mobile harrower) : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			m_Harrower = harrower;

			Name = "tentacles of the harrower";
			Body = 129;

			SetStr(901, 1000);
			SetDex(126, 140);
			SetInt(1001, 1200);

			SetHits(541, 600);

			SetDamage(13, 20);

			SetDamageType(ResistanceType.Physical, 20);
			SetDamageType(ResistanceType.Fire, 20);
			SetDamageType(ResistanceType.Cold, 20);
			SetDamageType(ResistanceType.Poison, 20);
			SetDamageType(ResistanceType.Energy, 20);

			SetResistance(ResistanceType.Physical, 55, 65);
			SetResistance(ResistanceType.Fire, 35, 45);
			SetResistance(ResistanceType.Cold, 35, 45);
			SetResistance(ResistanceType.Poison, 35, 45);
			SetResistance(ResistanceType.Energy, 35, 45);

			SetSkill(SkillName.Meditation, 100.0);
			SetSkill(SkillName.MagicResist, 120.1, 140.0);
			SetSkill(SkillName.Swords, 90.1, 100.0);
			SetSkill(SkillName.Tactics, 90.1, 100.0);
			SetSkill(SkillName.Wrestling, 90.1, 100.0);

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			m_Timer = new DrainTimer(this);
			m_Timer.Start();

			PackReg(50);
			PackNecroReg(15, 75);
		}

		public override void CheckReflect(Mobile caster, ref bool reflect)
		{
			reflect = true;
		}

		public override int GetIdleSound()
		{
			return 0x101;
		}

		public override int GetAngerSound()
		{
			return 0x5E;
		}

		public override int GetDeathSound()
		{
			return 0x1C2;
		}

		public override int GetAttackSound()
		{
			return -1; // unknown
		}

		public override int GetHurtSound()
		{
			return 0x289;
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.FilthyRich, 2);
			AddLoot(LootPack.MedScrolls, 3);
			AddLoot(LootPack.HighScrolls, 2);
		}

		public override bool AutoDispel => true;
		public override bool Unprovokable => true;
		public override Poison PoisonImmune => Poison.Lethal;
		public override bool DisallowAllMoves => true;

		public HarrowerTentacles(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(m_Harrower);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();

			switch (version)
			{
				case 0:
					{
						m_Harrower = reader.ReadMobile();

						m_Timer = new DrainTimer(this);
						m_Timer.Start();

						break;
					}
			}
		}

		public override void OnAfterDelete()
		{
			if (m_Timer != null)
			{
				m_Timer.Stop();
			}

			m_Timer = null;

			base.OnAfterDelete();
		}

		private class DrainTimer : Timer
		{
			private readonly HarrowerTentacles m_Owner;

			public DrainTimer(HarrowerTentacles owner) : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(5.0))
			{
				m_Owner = owner;
				Priority = TimerPriority.TwoFiftyMS;
			}

			private static readonly ArrayList m_ToDrain = new ArrayList();

			protected override void OnTick()
			{
				if (m_Owner.Deleted)
				{
					Stop();
					return;
				}

				foreach (var m in m_Owner.GetMobilesInRange(9))
				{
					if (m == m_Owner || m == m_Owner.Harrower || !m_Owner.CanBeHarmful(m))
					{
						continue;
					}

					if (m is BaseCreature)
					{
						var bc = m as BaseCreature;

						if (bc.Controlled || bc.Summoned)
						{
							m_ToDrain.Add(m);
						}
					}
					else if (m.Player)
					{
						m_ToDrain.Add(m);
					}
				}

				foreach (Mobile m in m_ToDrain)
				{
					m_Owner.DoHarmful(m);

					m.FixedParticles(0x374A, 10, 15, 5013, 0x455, 0, EffectLayer.Waist);
					m.PlaySound(0x1F1);

					var drain = Utility.RandomMinMax(14, 30);

					m_Owner.Hits += drain;

					if (m_Owner.Harrower != null)
					{
						m_Owner.Harrower.Hits += drain;
					}

					m.Damage(drain, m_Owner);
				}

				m_ToDrain.Clear();
			}
		}
	}
}