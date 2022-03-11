using Server.Engines.Stealables;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName("a leviathan corpse")]
	public class Leviathan : BaseCreature
	{
		private Mobile m_Fisher;

		public Mobile Fisher
		{
			get => m_Fisher;
			set => m_Fisher = value;
		}

		[Constructable]
		public Leviathan() : this(null)
		{
		}

		[Constructable]
		public Leviathan(Mobile fisher) : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			m_Fisher = fisher;

			Name = "a leviathan";
			Body = 77;
			BaseSoundID = 353;

			Hue = 0x481;

			SetStr(1000);
			SetDex(501, 520);
			SetInt(501, 515);

			SetHits(1500);

			SetDamage(25, 33);

			SetDamageType(ResistanceType.Physical, 70);
			SetDamageType(ResistanceType.Cold, 30);

			SetResistance(ResistanceType.Physical, 55, 65);
			SetResistance(ResistanceType.Fire, 45, 55);
			SetResistance(ResistanceType.Cold, 45, 55);
			SetResistance(ResistanceType.Poison, 35, 45);
			SetResistance(ResistanceType.Energy, 25, 35);

			SetSkill(SkillName.EvalInt, 97.6, 107.5);
			SetSkill(SkillName.Magery, 97.6, 107.5);
			SetSkill(SkillName.MagicResist, 97.6, 107.5);
			SetSkill(SkillName.Meditation, 97.6, 107.5);
			SetSkill(SkillName.Tactics, 97.6, 107.5);
			SetSkill(SkillName.Wrestling, 97.6, 107.5);

			Fame = 24000;
			Karma = -24000;

			VirtualArmor = 50;

			CanSwim = true;
			CantWalk = true;

			PackItem(new MessageInABottle());

			var rope = new Rope {
				ItemID = 0x14F8
			};
			PackItem(rope);

			rope = new Rope {
				ItemID = 0x14FA
			};
			PackItem(rope);
		}

		#region Leviathan Attacks/ Defenses

		public override bool HasBreath => true;

		public override int BreathEffectHue => 0x1ED;

		public override int BreathPhysicalDamage => 70;

		public override int BreathColdDamage => 30;

		public override int BreathFireDamage => 0;

		public override double BreathDamageScalar => 0.05;

		public override double BreathMinDelay => 5.0;

		public override double BreathMaxDelay => 7.5;

		#endregion

		public override void GenerateLoot()
		{
			AddLoot(LootPack.FilthyRich, 5);
		}

		public override double TreasureMapChance => 0.25;
		public override int TreasureMapLevel => 5;

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			if (m_Fisher != null && !Summoned && !NoKillAwards && BaseAquaBossAward.CheckSaltWaterArtifactChance(this))
			{
				BaseAquaBossAward.DistributeSaltWaterArtifact(this);
			}

			m_Fisher = null;
		}

		public Leviathan(Serial serial) : base(serial)
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