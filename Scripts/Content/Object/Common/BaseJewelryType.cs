namespace Server.Items
{
	/// BaseBracelet
	public abstract class BaseBracelet : BaseJewel
	{
		public override int BaseGemTypeNumber => 1044221;  // star sapphire bracelet

		public BaseBracelet(int itemID) : base(itemID, Layer.Bracelet)
		{
		}

		public BaseBracelet(Serial serial) : base(serial)
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

	/// BaseRing
	public abstract class BaseRing : BaseJewel
	{
		public override int BaseGemTypeNumber => 1044176;  // star sapphire ring

		public BaseRing(int itemID) : base(itemID, Layer.Ring)
		{
		}

		public BaseRing(Serial serial) : base(serial)
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

	/// BaseEarrings
	public abstract class BaseEarrings : BaseJewel
	{
		public override int BaseGemTypeNumber => 1044203;  // star sapphire earrings

		public BaseEarrings(int itemID) : base(itemID, Layer.Earrings)
		{
		}

		public BaseEarrings(Serial serial) : base(serial)
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

	/// BaseNecklace
	public abstract class BaseNecklace : BaseJewel
	{
		public override int BaseGemTypeNumber => 1044241;  // star sapphire necklace

		public BaseNecklace(int itemID) : base(itemID, Layer.Neck)
		{
		}

		public BaseNecklace(Serial serial) : base(serial)
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