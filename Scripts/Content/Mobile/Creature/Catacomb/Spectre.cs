using Server.Items;

namespace Server.Mobiles
{
	[CorpseName("a ghostly corpse")]
	public class Spectre : BaseCreature
	{
		[Constructable]
		public Spectre() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a spectre";
			Body = 26;
			Hue = 0x4001;
			BaseSoundID = 0x482;

			SetStr(76, 100);
			SetDex(76, 95);
			SetInt(36, 60);

			SetHits(46, 60);

			SetDamage(7, 11);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Cold, 50);

			SetResistance(ResistanceType.Physical, 25, 30);
			SetResistance(ResistanceType.Cold, 15, 25);
			SetResistance(ResistanceType.Poison, 10, 20);

			SetSkill(SkillName.EvalInt, 55.1, 70.0);
			SetSkill(SkillName.Magery, 55.1, 70.0);
			SetSkill(SkillName.MagicResist, 55.1, 70.0);
			SetSkill(SkillName.Tactics, 45.1, 60.0);
			SetSkill(SkillName.Wrestling, 45.1, 55.0);

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 28;

			PackReg(10);
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.Meager);
		}

		public override bool BleedImmune => true;

		public override OppositionGroup OppositionGroup => OppositionGroup.FeyAndUndead;

		public override Poison PoisonImmune => Poison.Lethal;

		public override void OnDamagedBySpell(Mobile caster)
		{
			if (caster == this)
			{
				return;
			}

			SpawnSpectralArmour(caster);
		}

		public void SpawnSpectralArmour(Mobile target)
		{
			var map = target.Map;

			if (map == null)
			{
				return;
			}

			var spectres = 0;

			foreach (var m in GetMobilesInRange(10))
			{
				if (m is SpectralArmour)
				{
					++spectres;
				}
			}

			if (spectres < 10)
			{
				BaseCreature spectre = new SpectralArmour {
					Team = Team
				};

				var loc = target.Location;
				var validLocation = false;

				for (var j = 0; !validLocation && j < 10; ++j)
				{
					var x = target.X + Utility.Random(3) - 1;
					var y = target.Y + Utility.Random(3) - 1;
					var z = map.GetAverageZ(x, y);

					if (validLocation = map.CanFit(x, y, Z, 16, false, false))
					{
						loc = new Point3D(x, y, Z);
					}
					else if (validLocation = map.CanFit(x, y, z, 16, false, false))
					{
						loc = new Point3D(x, y, z);
					}
				}

				spectre.MoveToWorld(loc, map);

				spectre.Combatant = target;
			}
		}

		public Spectre(Serial serial) : base(serial)
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

	public class SpectralArmour : BaseCreature
	{
		public override bool DeleteCorpseOnDeath => true;

		[Constructable]
		public SpectralArmour() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Body = 637;
			Hue = 0x8026;
			Name = "spectral armour";

			var buckler = new Buckler();
			var coif = new ChainCoif();
			var gloves = new PlateGloves();

			buckler.Hue = 0x835; buckler.Movable = false;
			coif.Hue = 0x835;
			gloves.Hue = 0x835;

			AddItem(buckler);
			AddItem(coif);
			AddItem(gloves);

			SetStr(101, 110);
			SetDex(101, 110);
			SetInt(101, 110);

			SetHits(178, 201);
			SetStam(191, 200);

			SetDamage(10, 22);

			SetDamageType(ResistanceType.Physical, 75);
			SetDamageType(ResistanceType.Cold, 25);

			SetResistance(ResistanceType.Physical, 35, 45);
			SetResistance(ResistanceType.Fire, 20, 30);
			SetResistance(ResistanceType.Cold, 30, 40);
			SetResistance(ResistanceType.Poison, 20, 30);
			SetResistance(ResistanceType.Energy, 20, 30);

			SetSkill(SkillName.Wrestling, 75.1, 100.0);
			SetSkill(SkillName.Tactics, 90.1, 100.0);
			SetSkill(SkillName.MagicResist, 90.1, 100);

			VirtualArmor = 40;
			Fame = 7000;
			Karma = -7000;
		}

		public override int GetIdleSound()
		{
			return 0x200;
		}

		public override int GetAngerSound()
		{
			return 0x56;
		}

		public override bool OnBeforeDeath()
		{
			if (!base.OnBeforeDeath())
			{
				return false;
			}

			var gold = new Gold(Utility.RandomMinMax(240, 375));
			gold.MoveToWorld(Location, Map);

			Effects.SendLocationEffect(Location, Map, 0x376A, 10, 1);
			return true;
		}

		public override Poison PoisonImmune => Poison.Regular;

		public SpectralArmour(Serial serial) : base(serial)
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