namespace Server.Items
{
	/// Kasa
	public class Kasa : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public Kasa() : this(0)
		{
		}

		[Constructable]
		public Kasa(int hue) : base(0x2798, hue)
		{
			Weight = 3.0;
		}

		public Kasa(Serial serial) : base(serial)
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

	/// ClothNinjaHood
	[Flipable(0x278F, 0x27DA)]
	public class ClothNinjaHood : BaseHat
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 9;
		public override int BaseEnergyResistance => 9;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public ClothNinjaHood() : this(0)
		{
		}

		[Constructable]
		public ClothNinjaHood(int hue) : base(0x278F, hue)
		{
			Weight = 2.0;
		}

		public ClothNinjaHood(Serial serial) : base(serial)
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

	/// FlowerGarland
	[Flipable(0x2306, 0x2305)]
	public class FlowerGarland : BaseHat
	{
		public override int BasePhysicalResistance => 3;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 6;
		public override int BasePoisonResistance => 9;
		public override int BaseEnergyResistance => 9;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public FlowerGarland() : this(0)
		{
		}

		[Constructable]
		public FlowerGarland(int hue) : base(0x2306, hue)
		{
			Weight = 1.0;
		}

		public FlowerGarland(Serial serial) : base(serial)
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

	/// FloppyHat
	public class FloppyHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public FloppyHat() : this(0)
		{
		}

		[Constructable]
		public FloppyHat(int hue) : base(0x1713, hue)
		{
			Weight = 1.0;
		}

		public FloppyHat(Serial serial) : base(serial)
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

	/// WideBrimHat
	public class WideBrimHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public WideBrimHat() : this(0)
		{
		}

		[Constructable]
		public WideBrimHat(int hue) : base(0x1714, hue)
		{
			Weight = 1.0;
		}

		public WideBrimHat(Serial serial) : base(serial)
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

	/// Cap
	public class Cap : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public Cap() : this(0)
		{
		}

		[Constructable]
		public Cap(int hue) : base(0x1715, hue)
		{
			Weight = 1.0;
		}

		public Cap(Serial serial) : base(serial)
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

	/// SkullCap
	public class SkullCap : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 8;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => (Core.ML ? 14 : 7);
		public override int InitMaxHits => (Core.ML ? 28 : 12);

		[Constructable]
		public SkullCap() : this(0)
		{
		}

		[Constructable]
		public SkullCap(int hue) : base(0x1544, hue)
		{
			Weight = 1.0;
		}

		public SkullCap(Serial serial) : base(serial)
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

	/// Bandana
	public class Bandana : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 5;
		public override int BasePoisonResistance => 8;
		public override int BaseEnergyResistance => 8;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public Bandana() : this(0)
		{
		}

		[Constructable]
		public Bandana(int hue) : base(0x1540, hue)
		{
			Weight = 1.0;
		}

		public Bandana(Serial serial) : base(serial)
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

	/// TallStrawHat
	public class TallStrawHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public TallStrawHat() : this(0)
		{
		}

		[Constructable]
		public TallStrawHat(int hue) : base(0x1716, hue)
		{
			Weight = 1.0;
		}

		public TallStrawHat(Serial serial) : base(serial)
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

	/// StrawHat
	public class StrawHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public StrawHat() : this(0)
		{
		}

		[Constructable]
		public StrawHat(int hue) : base(0x1717, hue)
		{
			Weight = 1.0;
		}

		public StrawHat(Serial serial) : base(serial)
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

	/// WizardsHat
	public class WizardsHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public WizardsHat() : this(0)
		{
		}

		[Constructable]
		public WizardsHat(int hue) : base(0x1718, hue)
		{
			Weight = 1.0;
		}

		public WizardsHat(Serial serial) : base(serial)
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

	/// MagicWizardsHat
	public class MagicWizardsHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		public override int LabelNumber => 1041072;  // a magical wizard's hat

		public override int BaseStrBonus => -5;
		public override int BaseDexBonus => -5;
		public override int BaseIntBonus => +5;

		[Constructable]
		public MagicWizardsHat() : this(0)
		{
		}

		[Constructable]
		public MagicWizardsHat(int hue) : base(0x1718, hue)
		{
			Weight = 1.0;
		}

		public MagicWizardsHat(Serial serial) : base(serial)
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

	/// Bonnet
	public class Bonnet : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public Bonnet() : this(0)
		{
		}

		[Constructable]
		public Bonnet(int hue) : base(0x1719, hue)
		{
			Weight = 1.0;
		}

		public Bonnet(Serial serial) : base(serial)
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

	/// FeatheredHat
	public class FeatheredHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public FeatheredHat() : this(0)
		{
		}

		[Constructable]
		public FeatheredHat(int hue) : base(0x171A, hue)
		{
			Weight = 1.0;
		}

		public FeatheredHat(Serial serial) : base(serial)
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

	/// TricorneHat
	public class TricorneHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public TricorneHat() : this(0)
		{
		}

		[Constructable]
		public TricorneHat(int hue) : base(0x171B, hue)
		{
			Weight = 1.0;
		}

		public TricorneHat(Serial serial) : base(serial)
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

	/// JesterHat
	public class JesterHat : BaseHat
	{
		public override int BasePhysicalResistance => 0;
		public override int BaseFireResistance => 5;
		public override int BaseColdResistance => 9;
		public override int BasePoisonResistance => 5;
		public override int BaseEnergyResistance => 5;

		public override int InitMinHits => 20;
		public override int InitMaxHits => 30;

		[Constructable]
		public JesterHat() : this(0)
		{
		}

		[Constructable]
		public JesterHat(int hue) : base(0x171C, hue)
		{
			Weight = 1.0;
		}

		public JesterHat(Serial serial) : base(serial)
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