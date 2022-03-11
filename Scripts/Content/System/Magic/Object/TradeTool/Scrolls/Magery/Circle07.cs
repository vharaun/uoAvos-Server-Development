namespace Server.Items
{
	public class ChainLightningScroll : SpellScroll
	{
		[Constructable]
		public ChainLightningScroll() : this(1)
		{
		}

		[Constructable]
		public ChainLightningScroll(int amount) : base(48, 0x1F5D, amount)
		{
		}

		public ChainLightningScroll(Serial serial) : base(serial)
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

	public class EnergyFieldScroll : SpellScroll
	{
		[Constructable]
		public EnergyFieldScroll() : this(1)
		{
		}

		[Constructable]
		public EnergyFieldScroll(int amount) : base(49, 0x1F5E, amount)
		{
		}

		public EnergyFieldScroll(Serial serial) : base(serial)
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

	public class FlamestrikeScroll : SpellScroll
	{
		[Constructable]
		public FlamestrikeScroll() : this(1)
		{
		}

		[Constructable]
		public FlamestrikeScroll(int amount) : base(50, 0x1F5F, amount)
		{
		}

		public FlamestrikeScroll(Serial serial) : base(serial)
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

	public class GateTravelScroll : SpellScroll
	{
		[Constructable]
		public GateTravelScroll() : this(1)
		{
		}

		[Constructable]
		public GateTravelScroll(int amount) : base(51, 0x1F60, amount)
		{
		}

		public GateTravelScroll(Serial serial) : base(serial)
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

	public class ManaVampireScroll : SpellScroll
	{
		[Constructable]
		public ManaVampireScroll() : this(1)
		{
		}

		[Constructable]
		public ManaVampireScroll(int amount) : base(52, 0x1F61, amount)
		{
		}

		public ManaVampireScroll(Serial serial) : base(serial)
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

	public class MassDispelScroll : SpellScroll
	{
		[Constructable]
		public MassDispelScroll() : this(1)
		{
		}

		[Constructable]
		public MassDispelScroll(int amount) : base(53, 0x1F62, amount)
		{
		}

		public MassDispelScroll(Serial serial) : base(serial)
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

	public class MeteorSwarmScroll : SpellScroll
	{
		[Constructable]
		public MeteorSwarmScroll() : this(1)
		{
		}

		[Constructable]
		public MeteorSwarmScroll(int amount) : base(54, 0x1F63, amount)
		{
		}

		public MeteorSwarmScroll(Serial serial) : base(serial)
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

	public class PolymorphScroll : SpellScroll
	{
		[Constructable]
		public PolymorphScroll() : this(1)
		{
		}

		[Constructable]
		public PolymorphScroll(int amount) : base(55, 0x1F64, amount)
		{
		}

		public PolymorphScroll(Serial serial) : base(serial)
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