namespace Server.Items
{
	public class LesserExplosionPotion : BaseExplosionPotion
	{
		public override int MinDamage => 5;
		public override int MaxDamage => 10;

		[Constructable]
		public LesserExplosionPotion() : base(PotionEffect.ExplosionLesser)
		{
		}

		public LesserExplosionPotion(Serial serial) : base(serial)
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

	public class ExplosionPotion : BaseExplosionPotion
	{
		public override int MinDamage => 10;
		public override int MaxDamage => 20;

		[Constructable]
		public ExplosionPotion() : base(PotionEffect.Explosion)
		{
		}

		public ExplosionPotion(Serial serial) : base(serial)
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

	public class GreaterExplosionPotion : BaseExplosionPotion
	{
		public override int MinDamage => Core.AOS ? 20 : 15;
		public override int MaxDamage => Core.AOS ? 40 : 30;

		[Constructable]
		public GreaterExplosionPotion() : base(PotionEffect.ExplosionGreater)
		{
		}

		public GreaterExplosionPotion(Serial serial) : base(serial)
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