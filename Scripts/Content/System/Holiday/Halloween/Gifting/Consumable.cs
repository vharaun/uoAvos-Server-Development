namespace Server.Items
{
	/// Beverages
	public class HarvestWine : BeverageBottle
	{
		public override string DefaultName => "Harvest Wine";
		public override double DefaultWeight => 1;

		[Constructable]
		public HarvestWine()
			: base(BeverageType.Wine)
		{
			Hue = 0xe0;
		}

		public HarvestWine(Serial serial)
			: base(serial)
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

	public class MurkyMilk : Pitcher
	{
		public override string DefaultName { get { return "Murky Milk"; ; } }
		public override int MaxQuantity => 5;
		public override double DefaultWeight => 1;

		[Constructable]
		public MurkyMilk()
			: base(BeverageType.Milk)
		{
			Hue = 0x3e5;
			Quantity = MaxQuantity;
			ItemID = (Utility.RandomBool()) ? 0x09F0 : 0x09AD;
		}

		public MurkyMilk(Serial serial)
			: base(serial)
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


	/// Food Items
	public class CreepyCake : Food
	{
		public override string DefaultName => "Creepy Cake";

		[Constructable]
		public CreepyCake()
			: base(0x9e9)
		{
			Hue = 0x3E4;
		}

		public CreepyCake(Serial serial)
			: base(serial)
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

	public class MrPlainsCookies : Food
	{
		public override string DefaultName => "Mr Plain's Cookies";

		[Constructable]
		public MrPlainsCookies()
			: base(0x160C)
		{
			Weight = 1.0;
			FillFactor = 4;
			Hue = 0xF4;
		}

		public MrPlainsCookies(Serial serial)
			: base(serial)
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

	public class PumpkinPizza : CheesePizza
	{
		public override string DefaultName => "Pumpkin Pizza";

		[Constructable]
		public PumpkinPizza()
			: base()
		{
			Hue = 0xF3;
		}

		public PumpkinPizza(Serial serial)
			: base(serial)
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


	/// Candy Items
	public class JellyBeans : CandyCane
	{
		public override int LabelNumber => 1096932;  /* jellybeans */

		[Constructable]
		public JellyBeans()
			: this(1)
		{
		}

		public JellyBeans(int amount)
			: base(0x468C)
		{
			Stackable = true;
		}

		public JellyBeans(Serial serial)
			: base(serial)
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

	[TypeAlias("Server.Items.Lollipop")]
	public class Lollipops : CandyCane
	{
		[Constructable]
		public Lollipops()
			: this(1)
		{
		}

		[Constructable]
		public Lollipops(int amount)
			: base(0x468D + Utility.Random(3))
		{
			Stackable = true;
		}

		public Lollipops(Serial serial)
			: base(serial)
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

	public class NougatSwirl : CandyCane
	{
		public override int LabelNumber => 1096936;  /* nougat swirl */

		[Constructable]
		public NougatSwirl() : this(1)
		{

		}

		[Constructable]
		public NougatSwirl(int amount)
			: base(0x4690)
		{
			Stackable = true;
		}

		public NougatSwirl(Serial serial)
			: base(serial)
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

	public class Taffy : CandyCane
	{
		public override int LabelNumber => 1096949;  /* taffy */

		[Constructable]
		public Taffy()
			: this(1)
		{
		}

		public Taffy(int amount)
			: base(0x469D)
		{
			Stackable = true;
		}

		public Taffy(Serial serial)
			: base(serial)
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

	public class WrappedCandy : CandyCane
	{
		public override int LabelNumber => 1096950;  /* wrapped candy */

		[Constructable]
		public WrappedCandy()
			: this(1)
		{
		}

		public WrappedCandy(int amount)
			: base(0x469e)
		{
			Stackable = true;
		}

		public WrappedCandy(Serial serial)
			: base(serial)
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