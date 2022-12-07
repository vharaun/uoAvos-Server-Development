namespace Server.Items
{
	public class AgilityScroll : SpellScroll
	{
		[Constructable]
		public AgilityScroll() : this(1)
		{
		}

		[Constructable]
		public AgilityScroll(int amount) : base(SpellName.Agility, 0x1F35, amount)
		{
		}

		public AgilityScroll(Serial serial) : base(serial)
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

	public class CunningScroll : SpellScroll
	{
		[Constructable]
		public CunningScroll() : this(1)
		{
		}

		[Constructable]
		public CunningScroll(int amount) : base(SpellName.Cunning, 0x1F36, amount)
		{
		}

		public CunningScroll(Serial serial) : base(serial)
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

	public class CureScroll : SpellScroll
	{
		[Constructable]
		public CureScroll() : this(1)
		{
		}

		[Constructable]
		public CureScroll(int amount) : base(SpellName.Cure, 0x1F37, amount)
		{
		}

		public CureScroll(Serial serial) : base(serial)
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

	public class HarmScroll : SpellScroll
	{
		[Constructable]
		public HarmScroll() : this(1)
		{
		}

		[Constructable]
		public HarmScroll(int amount) : base(SpellName.Harm, 0x1F38, amount)
		{
		}

		public HarmScroll(Serial serial) : base(serial)
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

	public class MagicTrapScroll : SpellScroll
	{
		[Constructable]
		public MagicTrapScroll() : this(1)
		{
		}

		[Constructable]
		public MagicTrapScroll(int amount) : base(SpellName.MagicTrap, 0x1F39, amount)
		{
		}

		public MagicTrapScroll(Serial serial) : base(serial)
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

	public class RemoveTrapScroll : SpellScroll
	{
		[Constructable]
		public RemoveTrapScroll() : this(1)
		{
		}

		[Constructable]
		public RemoveTrapScroll(int amount) : base(SpellName.RemoveTrap, 0x1F3A, amount)
		{
		}

		public RemoveTrapScroll(Serial serial) : base(serial)
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

	public class ProtectionScroll : SpellScroll
	{
		[Constructable]
		public ProtectionScroll() : this(1)
		{
		}

		[Constructable]
		public ProtectionScroll(int amount) : base(SpellName.Protection, 0x1F3B, amount)
		{
		}

		public ProtectionScroll(Serial serial) : base(serial)
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

	public class StrengthScroll : SpellScroll
	{
		[Constructable]
		public StrengthScroll() : this(1)
		{
		}

		[Constructable]
		public StrengthScroll(int amount) : base(SpellName.Strength, 0x1F3C, amount)
		{
		}

		public StrengthScroll(Serial serial) : base(serial)
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