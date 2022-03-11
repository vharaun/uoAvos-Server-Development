namespace Server.Items
{
	public class DispelScroll : SpellScroll
	{
		[Constructable]
		public DispelScroll() : this(1)
		{
		}

		[Constructable]
		public DispelScroll(int amount) : base(40, 0x1F55, amount)
		{
		}

		public DispelScroll(Serial serial) : base(serial)
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

	public class EnergyBoltScroll : SpellScroll
	{
		[Constructable]
		public EnergyBoltScroll() : this(1)
		{
		}

		[Constructable]
		public EnergyBoltScroll(int amount) : base(41, 0x1F56, amount)
		{
		}

		public EnergyBoltScroll(Serial serial) : base(serial)
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

	public class ExplosionScroll : SpellScroll
	{
		[Constructable]
		public ExplosionScroll() : this(1)
		{
		}

		[Constructable]
		public ExplosionScroll(int amount) : base(42, 0x1F57, amount)
		{
		}

		public ExplosionScroll(Serial serial) : base(serial)
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

	public class InvisibilityScroll : SpellScroll
	{
		[Constructable]
		public InvisibilityScroll() : this(1)
		{
		}

		[Constructable]
		public InvisibilityScroll(int amount) : base(43, 0x1F58, amount)
		{
		}

		public InvisibilityScroll(Serial serial) : base(serial)
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

	public class MarkScroll : SpellScroll
	{
		[Constructable]
		public MarkScroll() : this(1)
		{
		}

		[Constructable]
		public MarkScroll(int amount) : base(44, 0x1F59, amount)
		{
		}

		public MarkScroll(Serial serial) : base(serial)
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

	public class MassCurseScroll : SpellScroll
	{
		[Constructable]
		public MassCurseScroll() : this(1)
		{
		}

		[Constructable]
		public MassCurseScroll(int amount) : base(45, 0x1F5A, amount)
		{
		}

		public MassCurseScroll(Serial serial) : base(serial)
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

	public class ParalyzeFieldScroll : SpellScroll
	{
		[Constructable]
		public ParalyzeFieldScroll() : this(1)
		{
		}

		[Constructable]
		public ParalyzeFieldScroll(int amount) : base(46, 0x1F5B, amount)
		{
		}

		public ParalyzeFieldScroll(Serial serial) : base(serial)
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

	public class RevealScroll : SpellScroll
	{
		[Constructable]
		public RevealScroll() : this(1)
		{
		}

		[Constructable]
		public RevealScroll(int amount) : base(47, 0x1F5C, amount)
		{
		}

		public RevealScroll(Serial serial) : base(serial)
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