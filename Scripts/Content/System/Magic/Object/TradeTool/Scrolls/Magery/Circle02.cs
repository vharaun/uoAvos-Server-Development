namespace Server.Items
{
	public class AgilityScroll : SpellScroll
	{
		[Constructable]
		public AgilityScroll() : this(1)
		{
		}

		[Constructable]
		public AgilityScroll(int amount) : base(8, 0x1F35, amount)
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
		public CunningScroll(int amount) : base(9, 0x1F36, amount)
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
		public CureScroll(int amount) : base(10, 0x1F37, amount)
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
		public HarmScroll(int amount) : base(11, 0x1F38, amount)
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
		public MagicTrapScroll(int amount) : base(12, 0x1F39, amount)
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

	public class MagicUnTrapScroll : SpellScroll
	{
		[Constructable]
		public MagicUnTrapScroll() : this(1)
		{
		}

		[Constructable]
		public MagicUnTrapScroll(int amount) : base(13, 0x1F3A, amount)
		{
		}

		public MagicUnTrapScroll(Serial serial) : base(serial)
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
		public ProtectionScroll(int amount) : base(14, 0x1F3B, amount)
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
		public StrengthScroll(int amount) : base(15, 0x1F3C, amount)
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