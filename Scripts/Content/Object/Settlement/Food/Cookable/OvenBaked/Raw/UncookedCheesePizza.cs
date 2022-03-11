namespace Server.Items
{
	[TypeAlias("Server.Items.UncookedPizza")]
	public class UncookedCheesePizza : CookableFood
	{
		public override int LabelNumber => 1041341;  // uncooked cheese pizza

		[Constructable]
		public UncookedCheesePizza() : base(0x1083, 20)
		{
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new CheesePizza();
		}

		public UncookedCheesePizza(Serial serial) : base(serial)
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

			if (ItemID == 0x1040)
			{
				ItemID = 0x1083;
			}

			if (Hue == 51)
			{
				Hue = 0;
			}
		}
	}

#if false
	// ********** UncookedPizza **********
	public class UncookedPizza : CookableFood
	{
		[Constructable]
		public UncookedPizza() : base( 0x1083, 20 )
		{
			Weight = 1.0;
		}

		public override Food Cook()
		{
			return new Pizza();
		}

		public UncookedPizza( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( ItemID == 0x1040 )
				ItemID = 0x1083;

			if ( Hue == 51 )
				Hue = 0;
		}
	}
#endif
}