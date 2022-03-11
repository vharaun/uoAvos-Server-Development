namespace Server.Items
{
	public class SummonAirElementalScroll : SpellScroll
	{
		[Constructable]
		public SummonAirElementalScroll() : this(1)
		{
		}

		[Constructable]
		public SummonAirElementalScroll(int amount) : base(59, 0x1F68, amount)
		{
		}

		public SummonAirElementalScroll(Serial serial) : base(serial)
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

	public class SummonEarthElementalScroll : SpellScroll
	{
		[Constructable]
		public SummonEarthElementalScroll() : this(1)
		{
		}

		[Constructable]
		public SummonEarthElementalScroll(int amount) : base(61, 0x1F6A, amount)
		{
		}

		public SummonEarthElementalScroll(Serial serial) : base(serial)
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

	public class EarthquakeScroll : SpellScroll
	{
		[Constructable]
		public EarthquakeScroll() : this(1)
		{
		}

		[Constructable]
		public EarthquakeScroll(int amount) : base(56, 0x1F65, amount)
		{
		}

		public EarthquakeScroll(Serial serial) : base(serial)
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

	public class EnergyVortexScroll : SpellScroll
	{
		[Constructable]
		public EnergyVortexScroll() : this(1)
		{
		}

		[Constructable]
		public EnergyVortexScroll(int amount) : base(57, 0x1F66, amount)
		{
		}

		public EnergyVortexScroll(Serial serial) : base(serial)
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

	public class SummonFireElementalScroll : SpellScroll
	{
		[Constructable]
		public SummonFireElementalScroll() : this(1)
		{
		}

		[Constructable]
		public SummonFireElementalScroll(int amount) : base(62, 0x1F6B, amount)
		{
		}

		public SummonFireElementalScroll(Serial serial) : base(serial)
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

	public class ResurrectionScroll : SpellScroll
	{
		[Constructable]
		public ResurrectionScroll() : this(1)
		{
		}

		[Constructable]
		public ResurrectionScroll(int amount) : base(58, 0x1F67, amount)
		{
		}

		public ResurrectionScroll(Serial serial) : base(serial)
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

	public class SummonDaemonScroll : SpellScroll
	{
		[Constructable]
		public SummonDaemonScroll() : this(1)
		{
		}

		[Constructable]
		public SummonDaemonScroll(int amount) : base(60, 0x1F69, amount)
		{
		}

		public SummonDaemonScroll(Serial serial) : base(serial)
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

	public class SummonWaterElementalScroll : SpellScroll
	{
		[Constructable]
		public SummonWaterElementalScroll() : this(1)
		{
		}

		[Constructable]
		public SummonWaterElementalScroll(int amount) : base(63, 0x1F6C, amount)
		{
		}

		public SummonWaterElementalScroll(Serial serial) : base(serial)
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