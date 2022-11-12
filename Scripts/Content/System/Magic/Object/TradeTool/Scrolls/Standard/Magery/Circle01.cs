namespace Server.Items
{
	public class ClumsyScroll : SpellScroll
	{
		[Constructable]
		public ClumsyScroll() : this(1)
		{
		}

		[Constructable]
		public ClumsyScroll(int amount) : base(SpellName.Clumsy, 0x1F2E, amount)
		{
		}

		public ClumsyScroll(Serial serial) : base(serial)
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

	public class CreateFoodScroll : SpellScroll
	{
		[Constructable]
		public CreateFoodScroll() : this(1)
		{
		}

		[Constructable]
		public CreateFoodScroll(int amount) : base(SpellName.CreateFood, 0x1F2F, amount)
		{
		}

		public CreateFoodScroll(Serial serial) : base(serial)
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

	public class FeeblemindScroll : SpellScroll
	{
		[Constructable]
		public FeeblemindScroll() : this(1)
		{
		}

		[Constructable]
		public FeeblemindScroll(int amount) : base(SpellName.Feeblemind, 0x1F30, amount)
		{
		}

		public FeeblemindScroll(Serial serial) : base(serial)
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

	public class HealScroll : SpellScroll
	{
		[Constructable]
		public HealScroll() : this(1)
		{
		}

		[Constructable]
		public HealScroll(int amount) : base(SpellName.Heal, 0x1F31, amount)
		{
		}

		public HealScroll(Serial serial) : base(serial)
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

	public class MagicArrowScroll : SpellScroll
	{
		[Constructable]
		public MagicArrowScroll() : this(1)
		{
		}

		[Constructable]
		public MagicArrowScroll(int amount) : base(SpellName.MagicArrow, 0x1F32, amount)
		{
		}

		public MagicArrowScroll(Serial serial) : base(serial)
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

	public class NightSightScroll : SpellScroll
	{
		[Constructable]
		public NightSightScroll() : this(1)
		{
		}

		[Constructable]
		public NightSightScroll(int amount) : base(SpellName.NightSight, 0x1F33, amount)
		{
		}

		public NightSightScroll(Serial ser) : base(ser)
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

	public class ReactiveArmorScroll : SpellScroll
	{
		[Constructable]
		public ReactiveArmorScroll() : this(1)
		{
		}

		[Constructable]
		public ReactiveArmorScroll(int amount) : base(SpellName.ReactiveArmor, 0x1F2D, amount)
		{
		}

		public ReactiveArmorScroll(Serial ser) : base(ser)
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

	public class WeakenScroll : SpellScroll
	{
		[Constructable]
		public WeakenScroll() : this(1)
		{
		}

		[Constructable]
		public WeakenScroll(int amount) : base(SpellName.Weaken, 0x1F34, amount)
		{
		}

		public WeakenScroll(Serial serial) : base(serial)
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