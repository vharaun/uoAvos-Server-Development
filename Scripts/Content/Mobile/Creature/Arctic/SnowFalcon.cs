using Server.Items;

using System;

namespace Server.Mobiles
{
	[CorpseName("a snow falcon's corpse")]
	public class SnowFalcon : BaseCreature
	{
		[Constructable]
		public SnowFalcon() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a snow falcon";
			Body = 5;
			Hue = 1153;

			BaseSoundID = 0x2EE;
			SpeechHue = 1157;

			SetStr(605, 611);
			SetDex(391, 519);
			SetInt(669, 818);

			SetHits(1000, 1500);
			SetDamage(50, 75);

			SetDamageType(ResistanceType.Physical, 50);

			SetResistance(ResistanceType.Cold, 100);

			SetResistance(ResistanceType.Physical, 65, 85);
			SetResistance(ResistanceType.Fire, 50, 85);
			SetResistance(ResistanceType.Cold, 100);
			SetResistance(ResistanceType.Poison, 50, 85);
			SetResistance(ResistanceType.Energy, 50, 85);

			SetSkill(SkillName.Wrestling, 121.9, 130.6);
			SetSkill(SkillName.Tactics, 114.4, 117.4);
			SetSkill(SkillName.MagicResist, 147.7, 153.0);
			SetSkill(SkillName.Poisoning, 122.8, 124.0);
			SetSkill(SkillName.Magery, 121.8, 127.8);
			SetSkill(SkillName.EvalInt, 103.6, 117.0);
			SetSkill(SkillName.Meditation, 100.0, 110.0);

			Fame = 21000;
			Karma = -21000;

			VirtualArmor = 34;

			Tamable = false;

			CanFly = true;
		}

		public override void GenerateLoot()
		{
			AddLoot(LootPack.UltraRich, 3);
		}

		#region Freeze Attack - Custom Offensive Attacks

		public void FreezeAttack(Mobile m)
		{
			m.Paralyze(TimeSpan.FromSeconds(10));
			m.PlaySound(541);
			m.FixedEffect(0x376A, 6, 1);
			m.HueMod = 1152;
			m.SendMessage("The snow falcon's breath turns you to ice!");
			new FreezeAttackTimer(m).Start();
		}

		private class FreezeAttackTimer : Timer
		{
			private readonly Mobile m_Owner;

			public FreezeAttackTimer(Mobile owner) : base(TimeSpan.FromSeconds(10.0))
			{
				m_Owner = owner;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				m_Owner.HueMod = -1;
				m_Owner.PlaySound(65);
			}
		}

		public override void OnGotMeleeAttack(Mobile attacker)
		{
			base.OnGotMeleeAttack(attacker);

			if (0.1 >= Utility.RandomDouble())
			{
				FreezeAttack(attacker);
			}
		}

		public override void OnDamagedBySpell(Mobile attacker)
		{
			base.OnDamagedBySpell(attacker);

			if (Hits > 2000)
			{
				FreezeAttack(attacker);
			}
		}

		#endregion

		#region Mobiles Can Be Assigned Weapon Abilities

		public override WeaponAbility GetWeaponAbility()
		{
			if (Utility.RandomBool())
			{
				return WeaponAbility.ParalyzingBlow;
			}
			else
			{
				return WeaponAbility.BleedAttack;
			}
		}

		#endregion

		//Harvestable Resources
		public override int Meat => 1;
		public override MeatType MeatType => MeatType.Bird;
		public override int Feathers => 36;
		public override FoodType FavoriteFood => FoodType.Meat | FoodType.Fish;

		//Reward Drops After Kill
		public override bool GivesMLMinorArtifact => true;
		public override int TreasureMapLevel => 5;

		//Has An Area Damage Effect
		public override bool HasAura => true;

		//Player Attack Immunities 
		public override bool BardImmune => true;

		public SnowFalcon(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}