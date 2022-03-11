using Server.ContextMenus;
using Server.Items;
using Server.Network;

using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName("a plague beast corpse")]
	public class PlagueBeast : BaseCreature, IDevourer
	{
		private int m_DevourTotal;
		private int m_DevourGoal;
		private bool m_HasMetalChest = false;

		[CommandProperty(AccessLevel.GameMaster)]
		public int TotalDevoured
		{
			get => m_DevourTotal;
			set => m_DevourTotal = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int DevourGoal
		{
			get => (IsParagon ? m_DevourGoal + 25 : m_DevourGoal);
			set => m_DevourGoal = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool HasMetalChest => m_HasMetalChest;

		[Constructable]
		public PlagueBeast() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a plague beast";
			Body = 775;

			SetStr(302, 500);
			SetDex(80);
			SetInt(16, 20);

			SetHits(318, 404);

			SetDamage(20, 24);

			SetDamageType(ResistanceType.Physical, 60);
			SetDamageType(ResistanceType.Poison, 40);

			SetResistance(ResistanceType.Physical, 45, 55);
			SetResistance(ResistanceType.Fire, 40, 50);
			SetResistance(ResistanceType.Cold, 25, 35);
			SetResistance(ResistanceType.Poison, 65, 75);
			SetResistance(ResistanceType.Energy, 25, 35);

			SetSkill(SkillName.MagicResist, 35.0);
			SetSkill(SkillName.Tactics, 100.0);
			SetSkill(SkillName.Wrestling, 100.0);

			Fame = 13000;
			Karma = -13000;

			VirtualArmor = 30;
			PackArmor(1, 5);
			if (Utility.RandomDouble() < 0.80)
			{
				PackItem(new PlagueBeastGland());
			}

			if (Core.ML && Utility.RandomDouble() < 0.33)
			{
				PackItem(Engines.Plants.Seed.RandomPeculiarSeed(4));
			}

			m_DevourTotal = 0;
			m_DevourGoal = Utility.RandomMinMax(15, 25); // How many corpses must be devoured before a metal chest is awarded
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.FilthyRich);
			AddLoot(LootPack.Gems, Utility.Random(1, 3));
			// TODO: dungeon chest, healthy gland
		}

		public override void OnGaveMeleeAttack(Mobile defender)
		{
			base.OnGaveMeleeAttack(defender);

			defender.ApplyPoison(this, IsParagon ? Poison.Lethal : Poison.Deadly);
			defender.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
			defender.PlaySound(0x1CB);
		}

		public override void OnDamagedBySpell(Mobile caster)
		{
			if (Map != null && caster != this && 0.25 > Utility.RandomDouble())
			{
				BaseCreature spawn = new PlagueSpawn(this) {
					Team = Team
				};
				spawn.MoveToWorld(Location, Map);
				spawn.Combatant = caster;

				Say(1053034); // * The plague beast creates another beast from its flesh! *
			}

			base.OnDamagedBySpell(caster);
		}

		public override bool AutoDispel => true;
		public override Poison PoisonImmune => Poison.Lethal;

		public override void OnGotMeleeAttack(Mobile attacker)
		{
			if (Map != null && attacker != this && 0.25 > Utility.RandomDouble())
			{
				BaseCreature spawn = new PlagueSpawn(this) {
					Team = Team
				};
				spawn.MoveToWorld(Location, Map);
				spawn.Combatant = attacker;

				Say(1053034); // * The plague beast creates another beast from its flesh! *
			}

			base.OnGotMeleeAttack(attacker);
		}

		public PlagueBeast(Serial serial) : base(serial)
		{
		}

		public override int GetIdleSound()
		{
			return 0x1BF;
		}

		public override int GetAttackSound()
		{
			return 0x1C0;
		}

		public override int GetHurtSound()
		{
			return 0x1C1;
		}

		public override int GetDeathSound()
		{
			return 0x1C2;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1);

			writer.Write(m_HasMetalChest);
			writer.Write(m_DevourTotal);
			writer.Write(m_DevourGoal);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_HasMetalChest = reader.ReadBool();
						m_DevourTotal = reader.ReadInt();
						m_DevourGoal = reader.ReadInt();
						break;
					}
			}
		}

		public override void OnThink()
		{
			base.OnThink();

			// Check to see if we need to devour any corpses
			IPooledEnumerable eable = GetItemsInRange(3); // Get all corpses in range

			foreach (Item item in eable)
			{
				if (item is Corpse) // For each Corpse
				{
					var corpse = item as Corpse;

					// Ensure that the corpse was killed by us
					if (corpse != null && corpse.Killer == this && corpse.Owner != null)
					{
						if (!corpse.DevourCorpse() && !corpse.Devoured)
						{
							PublicOverheadMessage(MessageType.Emote, 0x3B2, 1053032); // * The plague beast attempts to absorb the remains, but cannot! *
						}
					}
				}
			}
			eable.Free();
		}

		#region IDevourer Members

		public bool Devour(Corpse corpse)
		{
			if (corpse == null || corpse.Owner == null) // sorry we can't devour because the corpse's owner is null
			{
				return false;
			}

			if (corpse.Owner.Body.IsHuman)
			{
				corpse.TurnToBones(); // Not bones yet, and we are a human body therefore we turn to bones.
			}

			IncreaseHits((int)Math.Ceiling(corpse.Owner.HitsMax * 0.75));
			m_DevourTotal++;

			PublicOverheadMessage(MessageType.Emote, 0x3B2, 1053033); // * The plague beast absorbs the fleshy remains of the corpse *

			if (!m_HasMetalChest && m_DevourTotal >= DevourGoal)
			{
				PackItem(new MetalChest());
				m_HasMetalChest = true;
			}

			return true;
		}

		#endregion

		private void IncreaseHits(int hp)
		{
			var maxhits = 2000;

			if (IsParagon)
			{
				maxhits = (int)(maxhits * Paragon.HitsBuff);
			}

			if (hp < 1000 && !Core.AOS)
			{
				hp = (hp * 100) / 60;
			}

			if (HitsMaxSeed >= maxhits)
			{
				HitsMaxSeed = maxhits;

				var newHits = Hits + hp + Utility.RandomMinMax(10, 20); // increase the hp until it hits if it goes over it'll max at 2000

				Hits = Math.Min(maxhits, newHits);
				// Also provide heal for each devour on top of the hp increase
			}
			else
			{
				var min = (hp / 2) + 10;
				var max = hp + 20;
				var hpToIncrease = Utility.RandomMinMax(min, max);

				HitsMaxSeed += hpToIncrease;
				Hits += hpToIncrease;
				// Also provide heal for each devour
			}
		}
	}

	[CorpseName("a plague spawn corpse")]
	public class PlagueSpawn : BaseCreature
	{
		private Mobile m_Owner;
		private DateTime m_ExpireTime;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Owner
		{
			get => m_Owner;
			set => m_Owner = value;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime ExpireTime
		{
			get => m_ExpireTime;
			set => m_ExpireTime = value;
		}

		[Constructable]
		public PlagueSpawn() : this(null)
		{
		}

		public override bool AlwaysMurderer => true;

		public override void DisplayPaperdollTo(Mobile to)
		{
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			for (var i = 0; i < list.Count; ++i)
			{
				if (list[i] is ContextMenus.PaperdollEntry)
				{
					list.RemoveAt(i--);
				}
			}
		}

		public override void OnThink()
		{
			if (m_Owner != null && (DateTime.UtcNow >= m_ExpireTime || m_Owner.Deleted || Map != m_Owner.Map || !InRange(m_Owner, 16)))
			{
				PlaySound(GetIdleSound());
				Delete();
			}
			else
			{
				base.OnThink();
			}
		}

		public PlagueSpawn(Mobile owner) : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			m_Owner = owner;
			m_ExpireTime = DateTime.UtcNow + TimeSpan.FromMinutes(1.0);

			Name = "a plague spawn";
			Hue = Utility.Random(0x11, 15);

			switch (Utility.Random(12))
			{
				case 0: // earth elemental
					Body = 14;
					BaseSoundID = 268;
					break;
				case 1: // headless one
					Body = 31;
					BaseSoundID = 0x39D;
					break;
				case 2: // person
					Body = Utility.RandomList(400, 401);
					break;
				case 3: // gorilla
					Body = 0x1D;
					BaseSoundID = 0x9E;
					break;
				case 4: // serpent
					Body = 0x15;
					BaseSoundID = 0xDB;
					break;
				default:
				case 5: // slime
					Body = 51;
					BaseSoundID = 456;
					break;
			}

			SetStr(201, 300);
			SetDex(80);
			SetInt(16, 20);

			SetHits(121, 180);

			SetDamage(11, 17);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 35, 45);
			SetResistance(ResistanceType.Fire, 30, 40);
			SetResistance(ResistanceType.Cold, 25, 35);
			SetResistance(ResistanceType.Poison, 65, 75);
			SetResistance(ResistanceType.Energy, 25, 35);

			SetSkill(SkillName.MagicResist, 25.0);
			SetSkill(SkillName.Tactics, 25.0);
			SetSkill(SkillName.Wrestling, 50.0);

			Fame = 1000;
			Karma = -1000;

			VirtualArmor = 20;
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Poor);
			AddLoot(LootPack.Gems);
		}

		public PlagueSpawn(Serial serial) : base(serial)
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
		}
	}
}