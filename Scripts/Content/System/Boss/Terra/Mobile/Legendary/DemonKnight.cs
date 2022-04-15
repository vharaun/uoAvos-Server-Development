using Server.Items;

using System;

namespace Server.Mobiles
{
	[CorpseName("a demon knight corpse")]
	public class DemonKnight : BaseCreature
	{
		private static bool m_InHere;

		[Constructable]
		public DemonKnight() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = NameList.RandomName("demon knight");
			Title = "the Dark Father";
			Body = 318;
			BaseSoundID = 0x165;

			SetStr(500);
			SetDex(100);
			SetInt(1000);

			SetHits(30000);
			SetMana(5000);

			SetDamage(17, 21);

			SetDamageType(ResistanceType.Physical, 20);
			SetDamageType(ResistanceType.Fire, 20);
			SetDamageType(ResistanceType.Cold, 20);
			SetDamageType(ResistanceType.Poison, 20);
			SetDamageType(ResistanceType.Energy, 20);

			SetResistance(ResistanceType.Physical, 30);
			SetResistance(ResistanceType.Fire, 30);
			SetResistance(ResistanceType.Cold, 30);
			SetResistance(ResistanceType.Poison, 30);
			SetResistance(ResistanceType.Energy, 30);

			SetSkill(SkillName.Necromancy, 120, 120.0);
			SetSkill(SkillName.SpiritSpeak, 120.0, 120.0);

			SetSkill(SkillName.DetectHidden, 80.0);
			SetSkill(SkillName.EvalInt, 100.0);
			SetSkill(SkillName.Magery, 100.0);
			SetSkill(SkillName.Meditation, 120.0);
			SetSkill(SkillName.MagicResist, 150.0);
			SetSkill(SkillName.Tactics, 100.0);
			SetSkill(SkillName.Wrestling, 120.0);

			Fame = 28000;
			Karma = -28000;

			VirtualArmor = 64;
		}

		public override bool IgnoreYoungProtection => Core.ML;

		public override Poison PoisonImmune => Poison.Lethal;

		public override bool BardImmune => !Core.SE;

		public override bool AreaPeaceImmune => Core.SE;

		public override bool Unprovokable => Core.SE;

		public override int TreasureMapLevel => 1;

		public override WeaponAbility GetWeaponAbility()
		{
			switch (Utility.Random(3))
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			if (from != null && from != this && !m_InHere)
			{
				m_InHere = true;
				AOS.Damage(from, this, Utility.RandomMinMax(8, 20), 100, 0, 0, 0, 0);

				MovingEffect(from, 0xECA, 10, 0, false, false, 0, 0);
				PlaySound(0x491);

				if (0.05 > Utility.RandomDouble())
				{
					Timer.DelayCall(TimeSpan.FromSeconds(1.0), CreateBones_Callback, from);
				}

				m_InHere = false;
			}
		}

		public virtual void CreateBones_Callback(object state)
		{
			var from = (Mobile)state;
			var map = from.Map;

			if (map == null)
			{
				return;
			}

			var count = Utility.RandomMinMax(1, 3);

			for (var i = 0; i < count; ++i)
			{
				var x = from.X + Utility.RandomMinMax(-1, 1);
				var y = from.Y + Utility.RandomMinMax(-1, 1);
				var z = from.Z;

				if (!map.CanFit(x, y, z, 16, false, true))
				{
					z = map.GetAverageZ(x, y);

					if (z == from.Z || !map.CanFit(x, y, z, 16, false, true))
					{
						continue;
					}
				}

				var bone = new UnholyBone {
					Hue = 0,
					Name = "unholy bones",
					ItemID = Utility.Random(0xECA, 9)
				};

				bone.MoveToWorld(new Point3D(x, y, z), map);
			}
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			if (!Summoned && !NoKillAwards && BaseTerraBossAward.CheckArtifactChance(this))
			{
				BaseTerraBossAward.DistributeArtifact(this);
			}
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.SuperBoss, 2);
			AddLoot(LootPack.HighScrolls, Utility.RandomMinMax(6, 60));
		}

		public DemonKnight(Serial serial) : base(serial)
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