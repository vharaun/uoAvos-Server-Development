namespace Server.Items
{
	public class LesserHealPotion : BaseHealPotion
	{
		public override int MinHeal => (Core.AOS ? 6 : 3);
		public override int MaxHeal => (Core.AOS ? 8 : 10);
		public override double Delay => (Core.AOS ? 3.0 : 10.0);

		[Constructable]
		public LesserHealPotion() : base(PotionEffect.HealLesser)
		{
		}

		public LesserHealPotion(Serial serial) : base(serial)
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

	public class HealPotion : BaseHealPotion
	{
		public override int MinHeal => (Core.AOS ? 13 : 6);
		public override int MaxHeal => (Core.AOS ? 16 : 20);
		public override double Delay => (Core.AOS ? 8.0 : 10.0);

		[Constructable]
		public HealPotion() : base(PotionEffect.Heal)
		{
		}

		public HealPotion(Serial serial) : base(serial)
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

	public class GreaterHealPotion : BaseHealPotion
	{
		public override int MinHeal => (Core.AOS ? 20 : 9);
		public override int MaxHeal => (Core.AOS ? 25 : 30);
		public override double Delay => 10.0;

		[Constructable]
		public GreaterHealPotion() : base(PotionEffect.HealGreater)
		{
		}

		public GreaterHealPotion(Serial serial) : base(serial)
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