namespace Server.Items
{
	public class ArchCureScroll : SpellScroll
	{
		[Constructable]
		public ArchCureScroll() : this(1)
		{
		}

		[Constructable]
		public ArchCureScroll(int amount) : base(24, 0x1F45, amount)
		{
		}

		public ArchCureScroll(Serial serial) : base(serial)
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

	public class ArchProtectionScroll : SpellScroll
	{
		[Constructable]
		public ArchProtectionScroll() : this(1)
		{
		}

		[Constructable]
		public ArchProtectionScroll(int amount) : base(25, 0x1F46, amount)
		{
		}

		public ArchProtectionScroll(Serial serial) : base(serial)
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

	public class CurseScroll : SpellScroll
	{
		[Constructable]
		public CurseScroll() : this(1)
		{
		}

		[Constructable]
		public CurseScroll(int amount) : base(26, 0x1F47, amount)
		{
		}

		public CurseScroll(Serial serial) : base(serial)
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

	public class FireFieldScroll : SpellScroll
	{
		[Constructable]
		public FireFieldScroll() : this(1)
		{
		}

		[Constructable]
		public FireFieldScroll(int amount) : base(27, 0x1F48, amount)
		{
		}

		public FireFieldScroll(Serial serial) : base(serial)
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

	public class GreaterHealScroll : SpellScroll
	{
		[Constructable]
		public GreaterHealScroll() : this(1)
		{
		}

		[Constructable]
		public GreaterHealScroll(int amount) : base(28, 0x1F49, amount)
		{
		}

		public GreaterHealScroll(Serial serial) : base(serial)
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

	public class LightningScroll : SpellScroll
	{
		[Constructable]
		public LightningScroll() : this(1)
		{
		}

		[Constructable]
		public LightningScroll(int amount) : base(29, 0x1F4A, amount)
		{
		}

		public LightningScroll(Serial serial) : base(serial)
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

	public class ManaDrainScroll : SpellScroll
	{
		[Constructable]
		public ManaDrainScroll() : this(1)
		{
		}

		[Constructable]
		public ManaDrainScroll(int amount) : base(30, 0x1F4B, amount)
		{
		}

		public ManaDrainScroll(Serial serial) : base(serial)
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

	public class RecallScroll : SpellScroll
	{
		[Constructable]
		public RecallScroll() : this(1)
		{
		}

		[Constructable]
		public RecallScroll(int amount) : base(31, 0x1F4C, amount)
		{
		}

		public RecallScroll(Serial serial) : base(serial)
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