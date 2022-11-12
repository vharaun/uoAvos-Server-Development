namespace Server.Items
{
	public class BladeSpiritsScroll : SpellScroll
	{
		[Constructable]
		public BladeSpiritsScroll() : this(1)
		{
		}

		[Constructable]
		public BladeSpiritsScroll(int amount) : base(SpellName.BladeSpirits, 0x1F4D, amount)
		{
		}

		public BladeSpiritsScroll(Serial serial) : base(serial)
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

	public class DispelFieldScroll : SpellScroll
	{
		[Constructable]
		public DispelFieldScroll() : this(1)
		{
		}

		[Constructable]
		public DispelFieldScroll(int amount) : base(SpellName.DispelField, 0x1F4E, amount)
		{
		}

		public DispelFieldScroll(Serial serial) : base(serial)
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

	public class IncognitoScroll : SpellScroll
	{
		[Constructable]
		public IncognitoScroll() : this(1)
		{
		}

		[Constructable]
		public IncognitoScroll(int amount) : base(SpellName.Incognito, 0x1F4F, amount)
		{
		}

		public IncognitoScroll(Serial serial) : base(serial)
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

	public class MagicReflectScroll : SpellScroll
	{
		[Constructable]
		public MagicReflectScroll() : this(1)
		{
		}

		[Constructable]
		public MagicReflectScroll(int amount) : base(SpellName.MagicReflect, 0x1F50, amount)
		{
		}

		public MagicReflectScroll(Serial serial) : base(serial)
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

	public class MindBlastScroll : SpellScroll
	{
		[Constructable]
		public MindBlastScroll() : this(1)
		{
		}

		[Constructable]
		public MindBlastScroll(int amount) : base(SpellName.MindBlast, 0x1F51, amount)
		{
		}

		public MindBlastScroll(Serial serial) : base(serial)
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

	public class ParalyzeScroll : SpellScroll
	{
		[Constructable]
		public ParalyzeScroll() : this(1)
		{
		}

		[Constructable]
		public ParalyzeScroll(int amount) : base(SpellName.Paralyze, 0x1F52, amount)
		{
		}

		public ParalyzeScroll(Serial serial) : base(serial)
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

	public class PoisonFieldScroll : SpellScroll
	{
		[Constructable]
		public PoisonFieldScroll() : this(1)
		{
		}

		[Constructable]
		public PoisonFieldScroll(int amount) : base(SpellName.PoisonField, 0x1F53, amount)
		{
		}

		public PoisonFieldScroll(Serial serial) : base(serial)
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

	public class SummonCreatureScroll : SpellScroll
	{
		[Constructable]
		public SummonCreatureScroll() : this(1)
		{
		}

		[Constructable]
		public SummonCreatureScroll(int amount) : base(SpellName.SummonCreature, 0x1F54, amount)
		{
		}

		public SummonCreatureScroll(Serial serial) : base(serial)
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