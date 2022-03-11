namespace Server.Items
{
	public class OrdersFromTheCouncilOfMages : Item
	{
		[Constructable]
		public OrdersFromTheCouncilOfMages() : base(0x2279)
		{
			Name = "Orders From Nystul";
			Hue = 1325; // Blue
			LootType = LootType.Blessed;
		}

		public OrdersFromTheCouncilOfMages(Serial serial) : base(serial)
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

	public class OrdersFromMinax : Item
	{
		[Constructable]
		public OrdersFromMinax() : base(0x2279)
		{
			Name = "Orders From The Dark Mistress";
			Hue = 1645; // Red
			LootType = LootType.Blessed;
		}

		public OrdersFromMinax(Serial serial) : base(serial)
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

	public class OrdersFromTheShadowLords : Item
	{
		[Constructable]
		public OrdersFromTheShadowLords() : base(0x2279)
		{
			Name = "Orders From Captain Johne";
			Hue = 1109; // Shadow
			LootType = LootType.Blessed;
		}

		public OrdersFromTheShadowLords(Serial serial) : base(serial)
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

	public class OrdersFromTheTrueBriannians : Item
	{
		[Constructable]
		public OrdersFromTheTrueBriannians() : base(0x2279)
		{
			Name = "Orders From Lord British";
			Hue = 1254; // Purple
			LootType = LootType.Blessed;
		}

		public OrdersFromTheTrueBriannians(Serial serial) : base(serial)
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