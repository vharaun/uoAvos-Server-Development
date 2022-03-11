namespace Server.Items
{
	/// SmallBagBall
	public class SmallBagBall : BaseBagBall
	{
		[Constructable]
		public SmallBagBall() : base(0x2256)
		{
		}

		public SmallBagBall(Serial serial) : base(serial)
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

	/// LargeBagBall
	public class LargeBagBall : BaseBagBall
	{
		[Constructable]
		public LargeBagBall() : base(0x2257)
		{
		}

		public LargeBagBall(Serial serial) : base(serial)
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