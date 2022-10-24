namespace Server.Items
{
	public class ChainLightningScroll : SpellScroll
	{
		[Constructable]
		public ChainLightningScroll() : this(1)
		{
		}

		[Constructable]
		public ChainLightningScroll(int amount) : base(SpellName.ChainLightning, 0x1F5D, amount)
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
		public EnergyFieldScroll(int amount) : base(SpellName.EnergyField, 0x1F5E, amount)
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

	public class FlameStrikeScroll : SpellScroll
	{
		[Constructable]
		public FlameStrikeScroll() : this(1)
		{
		}

		[Constructable]
		public FlameStrikeScroll(int amount) : base(SpellName.FlameStrike, 0x1F5F, amount)
		{
		}

		public FlameStrikeScroll(Serial serial) : base(serial)
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
		public GateTravelScroll(int amount) : base(SpellName.GateTravel, 0x1F60, amount)
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
		public ManaVampireScroll(int amount) : base(SpellName.ManaVampire, 0x1F61, amount)
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
		public MassDispelScroll(int amount) : base(SpellName.MassDispel, 0x1F62, amount)
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
		public MeteorSwarmScroll(int amount) : base(SpellName.MeteorSwarm, 0x1F63, amount)
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
		public PolymorphScroll(int amount) : base(SpellName.Polymorph, 0x1F64, amount)
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