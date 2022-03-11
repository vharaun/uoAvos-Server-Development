namespace Server.Items
{
	public class LesserPoisonPotion : BasePoisonPotion
	{
		public override Poison Poison => Poison.Lesser;

		public override double MinPoisoningSkill => 0.0;
		public override double MaxPoisoningSkill => 60.0;

		[Constructable]
		public LesserPoisonPotion() : base(PotionEffect.PoisonLesser)
		{
		}

		public LesserPoisonPotion(Serial serial) : base(serial)
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

	public class PoisonPotion : BasePoisonPotion
	{
		public override Poison Poison => Poison.Regular;

		public override double MinPoisoningSkill => 30.0;
		public override double MaxPoisoningSkill => 70.0;

		[Constructable]
		public PoisonPotion() : base(PotionEffect.Poison)
		{
		}

		public PoisonPotion(Serial serial) : base(serial)
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

	public class GreaterPoisonPotion : BasePoisonPotion
	{
		public override Poison Poison => Poison.Greater;

		public override double MinPoisoningSkill => 60.0;
		public override double MaxPoisoningSkill => 100.0;

		[Constructable]
		public GreaterPoisonPotion() : base(PotionEffect.PoisonGreater)
		{
		}

		public GreaterPoisonPotion(Serial serial) : base(serial)
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

	public class DeadlyPoisonPotion : BasePoisonPotion
	{
		public override Poison Poison => Poison.Deadly;

		public override double MinPoisoningSkill => 95.0;
		public override double MaxPoisoningSkill => 100.0;

		[Constructable]
		public DeadlyPoisonPotion() : base(PotionEffect.PoisonDeadly)
		{
		}

		public DeadlyPoisonPotion(Serial serial) : base(serial)
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