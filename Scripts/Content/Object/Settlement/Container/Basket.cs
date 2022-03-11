namespace Server.Items
{
	/// Basket
	public class Basket : BaseContainer
	{
		[Constructable]
		public Basket() : base(0x990)
		{
			Weight = 1.0; // Stratics doesn't know weight
		}

		public Basket(Serial serial) : base(serial)
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

	/// PicnicBasket
	public class PicnicBasket : BaseContainer
	{
		[Constructable]
		public PicnicBasket() : base(0xE7A)
		{
			Weight = 2.0; // Stratics doesn't know weight
		}

		public PicnicBasket(Serial serial) : base(serial)
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