namespace Server.Items
{
	public class CheeseWedge : Food
	{
		public override double DefaultWeight => 0.1;

		[Constructable]
		public CheeseWedge() : this(1)
		{
		}

		[Constructable]
		public CheeseWedge(int amount) : base(amount, 0x97D)
		{
			Name = "Cheese Wedge";
			FillFactor = 3;
		}

		public CheeseWedge(Serial serial) : base(serial)
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

	public class CheeseWedgeItem : Item
	{
		[Constructable]
		public CheeseWedgeItem() : base(0x97D)
		{
			Name = "Cheese Wedge";
		}

		public override void OnDoubleClick(Mobile from)
		{
			from.SendAsciiMessage("You rip apart the cheese wedge into a smaller bite");
			from.AddToBackpack(new CheeseSlice(5));
			Consume();

			base.OnDoubleClick(from);
		}

		public CheeseWedgeItem(Serial serial) : base(serial)
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