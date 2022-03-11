namespace Server.Items
{
	/// RuinedFallenChairA
	[FlipableAttribute(0xC10, 0xC11)]
	public class RuinedFallenChairA : Item
	{
		[Constructable]
		public RuinedFallenChairA() : base(0xC10)
		{
			Movable = false;
		}

		public RuinedFallenChairA(Serial serial) : base(serial)
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

	/// RuinedFallenChairB
	[FlipableAttribute(0xC19, 0xC1A)]
	public class RuinedFallenChairB : Item
	{
		[Constructable]
		public RuinedFallenChairB() : base(0xC19)
		{
			Movable = false;
		}

		public RuinedFallenChairB(Serial serial) : base(serial)
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