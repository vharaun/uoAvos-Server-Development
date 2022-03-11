namespace Server.Items
{
	public class LesserCurePotion : BaseCurePotion
	{
		private static readonly CureLevelInfo[] m_OldLevelInfo = new CureLevelInfo[]
			{
				new CureLevelInfo( Poison.Lesser,  0.75 ), // 75% chance to cure lesser poison
				new CureLevelInfo( Poison.Regular, 0.50 ), // 50% chance to cure regular poison
				new CureLevelInfo( Poison.Greater, 0.15 )  // 15% chance to cure greater poison
			};

		private static readonly CureLevelInfo[] m_AosLevelInfo = new CureLevelInfo[]
			{
				new CureLevelInfo( Poison.Lesser,  0.75 ),
				new CureLevelInfo( Poison.Regular, 0.50 ),
				new CureLevelInfo( Poison.Greater, 0.25 )
			};

		public override CureLevelInfo[] LevelInfo => Core.AOS ? m_AosLevelInfo : m_OldLevelInfo;

		[Constructable]
		public LesserCurePotion() : base(PotionEffect.CureLesser)
		{
		}

		public LesserCurePotion(Serial serial) : base(serial)
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

	public class CurePotion : BaseCurePotion
	{
		private static readonly CureLevelInfo[] m_OldLevelInfo = new CureLevelInfo[]
			{
				new CureLevelInfo( Poison.Lesser,  1.00 ), // 100% chance to cure lesser poison
				new CureLevelInfo( Poison.Regular, 0.75 ), //  75% chance to cure regular poison
				new CureLevelInfo( Poison.Greater, 0.50 ), //  50% chance to cure greater poison
				new CureLevelInfo( Poison.Deadly,  0.15 )  //  15% chance to cure deadly poison
			};

		private static readonly CureLevelInfo[] m_AosLevelInfo = new CureLevelInfo[]
			{
				new CureLevelInfo( Poison.Lesser,  1.00 ),
				new CureLevelInfo( Poison.Regular, 0.95 ),
				new CureLevelInfo( Poison.Greater, 0.75 ),
				new CureLevelInfo( Poison.Deadly,  0.50 ),
				new CureLevelInfo( Poison.Lethal,  0.25 )
			};

		public override CureLevelInfo[] LevelInfo => Core.AOS ? m_AosLevelInfo : m_OldLevelInfo;

		[Constructable]
		public CurePotion() : base(PotionEffect.Cure)
		{
		}

		public CurePotion(Serial serial) : base(serial)
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

	public class GreaterCurePotion : BaseCurePotion
	{
		private static readonly CureLevelInfo[] m_OldLevelInfo = new CureLevelInfo[]
			{
				new CureLevelInfo( Poison.Lesser,  1.00 ), // 100% chance to cure lesser poison
				new CureLevelInfo( Poison.Regular, 1.00 ), // 100% chance to cure regular poison
				new CureLevelInfo( Poison.Greater, 1.00 ), // 100% chance to cure greater poison
				new CureLevelInfo( Poison.Deadly,  0.75 ), //  75% chance to cure deadly poison
				new CureLevelInfo( Poison.Lethal,  0.25 )  //  25% chance to cure lethal poison
			};

		private static readonly CureLevelInfo[] m_AosLevelInfo = new CureLevelInfo[]
			{
				new CureLevelInfo( Poison.Lesser,  1.00 ),
				new CureLevelInfo( Poison.Regular, 1.00 ),
				new CureLevelInfo( Poison.Greater, 1.00 ),
				new CureLevelInfo( Poison.Deadly,  0.95 ),
				new CureLevelInfo( Poison.Lethal,  0.75 )
			};

		public override CureLevelInfo[] LevelInfo => Core.AOS ? m_AosLevelInfo : m_OldLevelInfo;

		[Constructable]
		public GreaterCurePotion() : base(PotionEffect.CureGreater)
		{
		}

		public GreaterCurePotion(Serial serial) : base(serial)
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